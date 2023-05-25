namespace Questao5.Domain.Entities
{
    public class ContaCorrente
    {
        public Guid ContaCorrenteId { get; set; }
        public int Numero { get; set; }
        public string Nome { get; set; } = "";
        public bool Ativo { get; set; }
        public virtual List<Movimento> Movimentos { get; set; } =   new List<Movimento>();

        public ContaCorrente()
        {
            ContaCorrenteId = Guid.NewGuid();
        }
    }
}
