namespace BaseDatos.Views;
using BaseDatos.Helpers;

public partial class AutoresDetalle : ContentPage
{
    private Modelos.DBService _dbService;

    public AutoresDetalle()
	{
		InitializeComponent();
        _dbService = new Modelos.DBService();
    }



    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // Obtener la lista de personas de la base de datos
        var personasList = await _dbService.GetAutores();

        // Asignar la lista al ListView
        personasListView.ItemsSource = personasList;

    }
}