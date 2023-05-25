namespace Questao5.Application.Queries.Responses
{
    public class ObterSaldoContaCorrenteViewModel
    {

        public string Saldo { get; set; } = "R$ 0,00";

        public int Numero { get; set; }

        public string Nome { get; set; } = "";

        public string DataHoraConsulta { get; set; }


        public ObterSaldoContaCorrenteViewModel()
        {
            DataHoraConsulta = DateTime.Now.ToString();
        }

    }
}
