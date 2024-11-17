namespace CadastroEventos.Views;

public partial class EventoContratado : ContentPage
{
	public EventoContratado()
	{
		InitializeComponent();
	}
    private void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            DisplayAlert("Erro", ex.Message, "Ok");
        }

    }
}