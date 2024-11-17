namespace CadastroEventos.Models
{
    public class Evento
    {
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public int NumeroParticipantes { get; set; }
        public string Local { get; set; }
        public double Custo { get; set; }
        public int Duracao { get; set; }

        public double ValorTotal
        {
            get
            {
                double valor_evento = NumeroParticipantes * Custo;

                return valor_evento;
            }
        }
    }
}