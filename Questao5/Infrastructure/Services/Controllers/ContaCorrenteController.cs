using MediatR;
using Microsoft.AspNetCore.Mvc;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Queries.Requests;
using Questao5.Infrastructure.CrossCutting;
using System.Net;

namespace Questao5.Infrastructure.Services.Controllers
{

    [Route("api/contacorrente")]
    public class ContaCorrenteController : MainController
    {

        IMediator _mediator;
        public ContaCorrenteController(ILogger<MainController> logger,
            LNotifications notifications, IMediator mediator) : base(logger, notifications)
        {

            _mediator = mediator;

        }

        /// <summary>
        /// MovimentarContaCorrenteCommand
        ///     Movimentar a conta com créditos ou débitos
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Retorna o item solicitado</response>
        /// <response code="400">Regras de negócios inválidas ou solicitação mal formatada</response>   
        /// <response code="500">Erro do Servidor Interno</response>   
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> MovimentarConta([FromBody] MovimentarContaCorrenteCommand  movimentarContaCorrenteCommand)
                    => await ExecControllerAsync(() => _mediator.Send (movimentarContaCorrenteCommand));


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Retorna o item solicitado</response>
        /// <response code="400">Regras de negócios inválidas ou solicitação mal formatada</response>   
        /// <response code="500">Erro do Servidor Interno</response>   
        /// <response code="401">Não autorizado</response>
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ObterSaldoContaCorrenteQuery getProjectRequest)
                    => await ExecControllerAsync(() => _mediator.Send(getProjectRequest));
    }
}
