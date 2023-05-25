using AutoMapper;
using Questao5.Application.Commands.Requests;
using Questao5.Domain.Entities;
using Questao5.Domain.Enumerators;

namespace Questao5.Application.AutoMapper
{
    public class CommandToDomainMappingProfile : Profile
    {

        string ObterMovimento(TipoMovimentoEnum tipoMovimento)
        {
            switch (tipoMovimento)
            {
                case TipoMovimentoEnum.Credito:
                    return "C";
                case TipoMovimentoEnum.Debito:
                    return "D";
                default:
                    return "C";
            }
        }
        public CommandToDomainMappingProfile()
        {
            CreateMap<MovimentarContaCorrenteCommand, Movimento>()
                 .ForMember(d => d.TipoMovimento, s => s.MapFrom(m => ObterMovimento(m.TipoMovimento)))
                ;
        }
    }
}
