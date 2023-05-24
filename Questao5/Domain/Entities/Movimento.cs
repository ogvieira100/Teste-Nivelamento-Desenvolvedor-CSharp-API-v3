using Questao5.Domain.Enumerators;
using System.ComponentModel;

namespace Questao5.Domain.Entities
{

    public class Movimento
    {
        public Guid IdMovimento { get; set; }
        public virtual Guid IdContaCorrente { get; set; }
        public virtual ContaCorrente ContaCorrente { get; set; }
        public DateTime DataMovimento { get; set; }
        public string TipoMovimento { get; set; }

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
            TipoMovimento = "D";
            DataMovimento = DateTime.Now;
        }

    }
}
