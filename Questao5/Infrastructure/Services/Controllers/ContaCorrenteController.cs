using Microsoft.AspNetCore.Mvc;
using Questao5.Infrastructure.CrossCutting;
using System.Net;

namespace Questao5.Infrastructure.Services.Controllers
{

    [Route("api/contacorrente")]
    public class ContaCorrenteController : MainController
    {
        public ContaCorrenteController(ILogger<MainController> logger,
            LNotifications notifications) : base(logger, notifications)
        {


            ///// <summary>
            ///// 
            ///// </summary>
            ///// <returns></returns>
            ///// <response code="200">Retorna o item solicitado</response>
            ///// <response code="400">Regras de negócios inválidas ou solicitação mal formatada</response>   
            ///// <response code="500">Erro do Servidor Interno</response>   
            ///// <response code="401">Não autorizado</response>
            //[ProducesResponseType((int)HttpStatusCode.OK)]
            //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
            //[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
            //[HttpGet]
            //public async Task<IActionResult> Get([FromQuery] GetInvoicesRequest getProjectRequest)
            //            => await ExecControllerAsync(() => _invoicesApplication.GetAsync(getProjectRequest));

        }
    }
}
