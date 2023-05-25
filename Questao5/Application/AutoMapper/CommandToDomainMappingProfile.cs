using AutoMapper;
using Questao5.Application.Commands.Requests;
using Questao5.Domain.Entities;
using Questao5.Domain.Enumerators;

namespace Questao5.Application.AutoMapper
{
    public class CommandToDomainMappingProfile : Profile
    {
        public CommandToDomainMappingProfile()
        {
            CreateMap<MovimentarContaCorrenteCommand, Movimento>()
                ;
        }
    }
}
