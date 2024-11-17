using CadastroEventos.Models;

namespace CadastroEventos.Views;

public partial class Cadastro : ContentPage
{
    App PropriedadesApp;
    public Cadastro()
    {
        InitializeComponent();
        PropriedadesApp = (App)Application.Current;

        dtpck_dataInicio.MinimumDate = DateTime.Now;
        dtpck_dataInicio.MaximumDate = DateTime.Now.AddMonths(6);

        dtpck_dataTermino.IsEnabled = false;
    }

    private async void BtAvancar_Clicked(object sender, EventArgs e)
    {
        try
        {
            DateTime dataInicio = dtpck_dataInicio.Date;
            DateTime dataTermino = dtpck_dataTermino.Date;

            TimeSpan duracao = dataTermino - dataInicio;
            int totalDias = duracao.Days;

            Evento c = new Evento
            {
                Nome = NomeEvento.Text,
                NumeroParticipantes = Convert.ToInt32(stp_participantes.Value),
                DataInicio = dataInicio,
                DataTermino = dataTermino,
                Duracao = totalDias,
                Local = LocalEvento.Text,
                Custo = Convert.ToDouble(CustoEvento.Text),
            };

            await Navigation.PushAsync(new EventoContratado()
            {
                BindingContext = c
            });
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", ex.Message, "OK");
        }
    }

    private void dtpck_dataInicio_DateSelected(object sender, DateChangedEventArgs e)
    {
        DatePicker elemento = sender as DatePicker;
        DateTime dataInicioSelecionada = elemento.Date;

        dtpck_dataTermino.IsEnabled = true;

        dtpck_dataTermino.MinimumDate = dataInicioSelecionada.AddDays(1);
        dtpck_dataTermino.MaximumDate = dataInicioSelecionada.AddDays(3);

        if (dtpck_dataTermino.Date < dtpck_dataTermino.MinimumDate || dtpck_dataTermino.Date > dtpck_dataTermino.MaximumDate)
        {
            dtpck_dataTermino.Date = dtpck_dataTermino.MinimumDate;
        }
    }
}
