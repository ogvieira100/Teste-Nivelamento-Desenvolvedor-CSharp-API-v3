namespace Questao5.Domain.Entities
{
    public class IdEmpotencia
    {

        public Guid Id { get; set; }

        public string? Requisicao { get; set; }

        public string? Resultado { get; set; }

        public IdEmpotencia()
        {
            Id = Guid.NewGuid();
        }


    }
}
