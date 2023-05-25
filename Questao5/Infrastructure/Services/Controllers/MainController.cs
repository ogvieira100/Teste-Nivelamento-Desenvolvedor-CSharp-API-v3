using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Questao5.Infrastructure.CrossCutting;

namespace Questao5.Infrastructure.Services.Controllers
{

    [ApiController]
    public abstract class MainController : ControllerBase
    {

        protected readonly LNotifications _notifications;
        protected readonly ILogger _logger;

        public MainController(ILogger<MainController> logger,
                              LNotifications notifications)
        {
            _notifications = notifications;
            _logger = logger;
        }

        [NonAction]
        public bool IsValid()
        {
            return !_notifications.Any();
        }

        [NonAction]
        protected void ClearErrors()
        {
            _notifications.Clear();
        }
        [NonAction]
        void LoggerException(Exception ex)
        {
            var err = new ErrorLog();
            err.StackTrace = ex.StackTrace;
            err.Message = ex.Message;
            err.InnerException = ex.InnerException?.ToString();
            _logger.LogError(JsonConvert.SerializeObject(err));
        }
        [NonAction]
        protected async Task<IActionResult> ExecControllerAsync<T>
                            (Func<Task<T>> func)
        {
            try
            {
                return Response(await func());
            }
            catch (Exception ex)
            {
                LoggerException(ex);
                AddError(ex);
                return Response(null);
            }
        }


        [NonAction]
        protected async Task<IActionResult> ExecControllerAsync(Func<Task> func)
        {
            try
            {
                await func.Invoke();
                return Response(null);
            }
            catch (Exception ex)
            {
                LoggerException(ex);
                AddError(ex);
                return Response(null);
            }
        }

        [NonAction]
        protected IActionResult ExecController<T>(Func<T> func)
        {
            try
            {
                return Response(func.Invoke());
            }
            catch (Exception ex)
            {
                LoggerException(ex);
                AddError(ex);
                return Response(null);
            }
        }

        [NonAction]
        protected IActionResult ExecController(object result = null)
        {
            try
            {
                return Response(result);
            }
            catch (Exception ex)
            {
                LoggerException(ex);
                AddError(ex);
                return Response(null);
            }
        }
        [NonAction]
        protected new IActionResult Response(object result = null)
        {
            if (IsValid())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                data = result,
                errors = _notifications
            });
        }

        [NonAction]
        protected void NotifyModelStateErrors()
        {
            var erros = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var erro in erros)
            {
                var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                AddError(new Notifications { Message = erroMsg });

            }
        }
        [NonAction]
        protected void AddIdentityErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
                AddError(new Notifications { Message = error.Description });
        }

        [NonAction]
        protected void AddError(Exception except)
        {
            _notifications.Add(new Notifications { Message = except.Message });
        }
        [NonAction]

        protected void AddError(Notifications erro)
        {
            _notifications.Add(erro);
        }



    }
}
