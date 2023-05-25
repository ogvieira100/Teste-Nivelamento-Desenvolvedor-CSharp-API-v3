using AutoMapper;
using MediatR;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;
using Questao5.Application.Queries.Requests;
using Questao5.Application.Queries.Responses;
using Questao5.Domain.Entities;
using Questao5.Domain.Language;
using Questao5.Domain.Repository;
using Questao5.Infrastructure.CrossCutting;

namespace Questao5.Application.Handlers
{
    public class MovimentarContaCorrenteCommandHandler
        : IRequestHandler<MovimentarContaCorrenteCommand, MovimentarContaCorrenteResponse>,
          IRequestHandler<ObterSaldoContaCorrenteQuery, ObterSaldoContaCorrenteViewModel>
    
    {
        readonly IBaseRepository<ContaCorrente> _contaCorrenteRepository;
        readonly IBaseRepository<Movimento> _movimentoRepository;
        readonly LNotifications _notifications;
        readonly ILanguageSystem _languageSystem;
        readonly IMapper _mapper;

        public MovimentarContaCorrenteCommandHandler(IBaseRepository<ContaCorrente> contaCorrenteRepository
                                                    , LNotifications notifications
                                                    , IMapper mapper
                                                    , ILanguageSystem languageSystem
                                                     )
        {
            _contaCorrenteRepository = contaCorrenteRepository;
            _notifications = notifications ?? new LNotifications();
            _languageSystem = languageSystem;
            _mapper = mapper;
        }
        public async Task<MovimentarContaCorrenteResponse> Handle(MovimentarContaCorrenteCommand request, CancellationToken cancellationToken)
        {
            var resp = new MovimentarContaCorrenteResponse();

            var contaCorrente = await MovimentIsValid(request);
            if (_notifications.Any())
                return resp;

            var movimentoAdd = _mapper.Map<Movimento>(request);

            if (contaCorrente is not null)
                contaCorrente.Movimentos.Add(movimentoAdd);

            await _movimentoRepository.UnitOfWork.CommitAsync();
            return resp;
        }

        public async Task<ObterSaldoContaCorrenteViewModel> Handle(ObterSaldoContaCorrenteQuery request, CancellationToken cancellationToken)
        {
            var resp = new ObterSaldoContaCorrenteViewModel();
            var contaCorrente = await CurrentAccountIsValid(request.Numero);
            if (_notifications.Any())
                return resp;

            var  sqlCredito = @" 
                            SELECT 
                            coalesce(SUM(VALOR),0)
                            FROM
                            contacorrente CC JOIN 
                            movimento MV ON MV.idcontacorrente = CC.idcontacorrente
                            WHERE tipomovimento = 'C'
                            AND CC.numero = @conta
                        ";

            var sqlDebito = @" 
                            SELECT 
                            coalesce(SUM(VALOR),0)
                            FROM
                            contacorrente CC JOIN 
                            movimento MV ON MV.idcontacorrente = CC.idcontacorrente
                            WHERE tipomovimento = 'D'
                            AND CC.numero = @conta
                        ";
            /*aqui utilizo dapper */
            var valorCredito   =   await _movimentoRepository.RepositoryConsult.GetOneAsync<decimal>(sqlCredito, new { conta = request.Numero });
            var valorDebito = await _movimentoRepository.RepositoryConsult.GetOneAsync<decimal>(sqlDebito, new { conta = request.Numero });


            resp = _mapper.Map<ObterSaldoContaCorrenteViewModel>(contaCorrente);
            resp.Saldo = valorCredito +  (valorDebito * -1);
            return resp;
        }

        async Task<ContaCorrente?> MovimentIsValid(MovimentarContaCorrenteCommand request)
        {
            if (request.Valor <= 0)
                _notifications.Add(new Notifications { Message = _languageSystem.InvalidValue() });

            var numeroConta = request.NumeroContaCorrente;

            ContaCorrente? contaCorrente = await CurrentAccountIsValid(numeroConta);

            if (!Enum.IsDefined(request.TipoMovimento))
                _notifications.Add(new Notifications { Message = _languageSystem.InvalidType() });

            return contaCorrente;
        }

        async Task<ContaCorrente?> CurrentAccountIsValid(int numeroConta)
        {
            var contaCorrente = (await _contaCorrenteRepository.RepositoryConsult.SearchAsync(x => x.Numero == numeroConta))
                                  ?.FirstOrDefault();

            if (contaCorrente is null)
                _notifications.Add(new Notifications { Message = _languageSystem.InvalidAccount() });

            if (contaCorrente is not null
                              && !contaCorrente.Ativo)
                _notifications.Add(new Notifications { Message = _languageSystem.InactiveAccount() });
            return contaCorrente;
        }
    }
}
