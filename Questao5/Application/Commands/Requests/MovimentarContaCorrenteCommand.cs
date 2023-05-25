using MediatR;
using Questao5.Application.Commands.Responses;
using Questao5.Domain.Enumerators;

namespace Questao5.Application.Commands.Requests
{
    public class MovimentarContaCorrenteCommand:IRequest<MovimentarContaCorrenteResponse>
    {

        public string TipoMovimento { get; set; } = "";

        public int Numero { get; set; }

        public decimal Valor { get; set; }


        public MovimentarContaCorrenteCommand()
        {
            
        }
    }
}
