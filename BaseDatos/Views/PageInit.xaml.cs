using static SQLite.SQLite3;

namespace BaseDatos.Views;

public partial class PageInit : ContentPage
{
	public PageInit()
	{
		InitializeComponent();
	}

    private async void btnagregar_Clicked(object sender, EventArgs e)
    {

        var persona = new Modelos.Personas
        {
            Nombre = nombres.Text,
            Apellido = apellidos.Text,
            fecha = Fecha.Date,
            Telefono = Tel.Text
        };

        if (await App.DataBase.StorePerson(persona)>0) {
            await DisplayAlert("Aviso", "Registrado con exito", "OK");
        }

        //var pagina = new Views.PageDetalle();
        //pagina.BindingContext = persona;
        //await Navigation.PushAsync( pagina );

        //await DisplayAlert("aviso", "Hola", "ok");

    }

    private async void btnnave_Clicked(object sender, EventArgs e)
    {
        var pagina = new Views.PageDetalle();
        await Navigation.PushAsync( pagina );


    }

}