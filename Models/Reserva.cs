namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            bool validacaoSuite = hospedes.Count <= Suite.Capacidade;

            if (validacaoSuite)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new Exception("Capacidade Máxima Excedida.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {

            var quantidadePessoas = Hospedes.Count;
            return quantidadePessoas;
        }

        public decimal CalcularValorDiaria()
        {

            decimal valor = DiasReservados * Suite.ValorDiaria;

            bool calcularDesconto = DiasReservados >= 10;
            if (calcularDesconto)
            {
                decimal desconto = valor * 0.1M;
                valor -= desconto;
            }

            return valor;
        }
    }
}