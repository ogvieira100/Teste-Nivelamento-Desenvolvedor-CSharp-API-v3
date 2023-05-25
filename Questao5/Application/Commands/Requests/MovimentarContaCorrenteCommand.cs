﻿using MediatR;
using Questao5.Application.Commands.Responses;
using Questao5.Domain.Enumerators;

namespace Questao5.Application.Commands.Requests
{
    public class MovimentarContaCorrenteCommand:IRequest<MovimentarContaCorrenteResponse>
    {

        public TipoMovimentoEnum TipoMovimento { get; set; } = TipoMovimentoEnum.Credito;

        public int NumeroContaCorrente { get; set; }

        public decimal Valor { get; set; }


        public MovimentarContaCorrenteCommand()
        {
            
        }
    }
}