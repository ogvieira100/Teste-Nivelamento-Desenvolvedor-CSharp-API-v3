using Castle.Core.Logging;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Logging;
using Moq;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;
using Questao5.Application.Queries.Requests;
using Questao5.Application.Queries.Responses;
using Questao5.Infrastructure.CrossCutting;
using Questao5.Infrastructure.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Tests.ControllersTest
{
    public class ContaCorrenteControllerTests
    {

        Mock<IMediator> _mockIMediator;
        LNotifications _mockLNotifications;
        Mock<ILogger<MainController>> _mockMainController;
        ContaCorrenteController _contaCorrenteController;
        public ContaCorrenteControllerTests()
        {
            _mockIMediator = new Mock<IMediator>();
            _mockLNotifications = new LNotifications();
            _mockMainController = new Mock<ILogger<MainController>>();
            _contaCorrenteController = new ContaCorrenteController(_mockMainController.Object,
                                                                    _mockLNotifications, 
                                                                    _mockIMediator.Object
                                                                  );

        }


        #region  "  MovimentarConta  "

        [Fact]
        public async void MovimentarContaOk()
        {


            //Arrange
            var movimentarContaCorrenteCommand = new MovimentarContaCorrenteCommand()
            { 
                Numero = 123,
                TipoMovimento = "D",
                Valor = 65
            
            };
            var ret = new MovimentarContaCorrenteResponse();
            var statusCodeOk = (int)HttpStatusCode.OK;


            _mockIMediator.Setup(m => m.Send(It.IsAny<MovimentarContaCorrenteCommand>(), It.IsAny<CancellationToken>()))
                                .ReturnsAsync(ret)
                                .Verifiable("Notification was not sent.");

            //Act
            var retController = await _contaCorrenteController.MovimentarConta(movimentarContaCorrenteCommand);



            //Assert
             Assert.True(((IStatusCodeActionResult)retController).StatusCode == statusCodeOk);

        }

        [Fact]
        public async void MovimentarContaBadRequest()
        {


            //Arrange
            var movimentarContaCorrenteCommand = new MovimentarContaCorrenteCommand()
            {
                Numero = 123,
                TipoMovimento = "D",
                Valor = 65

            };
            var ret = new MovimentarContaCorrenteResponse();
            var statusCodeBadRequest = (int)HttpStatusCode.BadRequest;
            _mockLNotifications.Add(new Notifications { Message = "Error" });

            _mockIMediator.Setup(m => m.Send(It.IsAny<MovimentarContaCorrenteCommand>(), It.IsAny<CancellationToken>()))
                                .ReturnsAsync(ret)
                                .Verifiable("Notification was not sent.");

            //Act
            var retController = await _contaCorrenteController.MovimentarConta(movimentarContaCorrenteCommand);



            //Assert
            Assert.True(((IStatusCodeActionResult)retController).StatusCode == statusCodeBadRequest);

        }

        #endregion

        #region " ObterSaldoConta "

        [Fact]
        public async void ObterSaldoContaOk()
        {


            //Arrange
            var obterSaldoContaCorrenteQuery = new ObterSaldoContaCorrenteQuery()
            {
                Numero = 123,
            };
            var ret = new ObterSaldoContaCorrenteViewModel();
            var statusCodeOk = (int)HttpStatusCode.OK;
            

            _mockIMediator.Setup(m => m.Send(It.IsAny<ObterSaldoContaCorrenteQuery>(), It.IsAny<CancellationToken>()))
                                .ReturnsAsync(ret)
                                .Verifiable("Notification was not sent.");

            //Act
            var retController = await _contaCorrenteController.ObterSaldoConta(obterSaldoContaCorrenteQuery);



            //Assert
            Assert.True(((IStatusCodeActionResult)retController).StatusCode == statusCodeOk);

        }

        [Fact]
        public async void ObterSaldoContaBadRequest()
        {


            //Arrange
            var obterSaldoContaCorrenteQuery = new ObterSaldoContaCorrenteQuery()
            {
                Numero = 123,
               

            };
            var ret = new ObterSaldoContaCorrenteViewModel();
            var statusCodeBadRequest = (int)HttpStatusCode.BadRequest;
            _mockLNotifications.Add(new Notifications { Message = "Error" });

            _mockIMediator.Setup(m => m.Send(It.IsAny<ObterSaldoContaCorrenteQuery>(), It.IsAny<CancellationToken>()))
                                .ReturnsAsync(ret)
                                .Verifiable("Notification was not sent.");

            //Act
            var retController = await _contaCorrenteController.ObterSaldoConta(obterSaldoContaCorrenteQuery);



            //Assert
            Assert.True(((IStatusCodeActionResult)retController).StatusCode == statusCodeBadRequest);

        }

        #endregion

    }
}
