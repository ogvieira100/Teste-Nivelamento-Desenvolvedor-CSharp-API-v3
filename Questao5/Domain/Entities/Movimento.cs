using Questao5.Domain.Enumerators;
using System.ComponentModel;

namespace Questao5.Domain.Entities
{

    public class Movimento
    {
        public Guid IdMovimento { get; set; }
        public virtual Guid IdContaCorrente { get; set; }
        public virtual ContaCorrente ContaCorrente { get; set; } = new ContaCorrente();
        public string DataMovimento { get; set; } = DateTime.Now.ToShortDateString();
        public string TipoMovimento { get; set; } = "C";
        public decimal Valor { get; set; }

        public TipoMovimentoEnum TipoMovimentoEnum
        {
            get
            {
                if (TipoMovimento.Trim() == "C")
                    return TipoMovimentoEnum.Credito;
                else
                    return TipoMovimentoEnum.Debito;
            }
        }

        public Movimento()
        {
            IdMovimento = Guid.NewGuid();
        }

    }
}
