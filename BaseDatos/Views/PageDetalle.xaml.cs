
namespace BaseDatos.Views;

public partial class PageDetalle : ContentPage
{
    private Modelos.DBService _dbService;
    

    public PageDetalle()
	{
		InitializeComponent();
        _dbService = new Modelos.DBService();

    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // Obtener la lista de personas de la base de datos
        var personasList = await _dbService.GetPersonas();

        // Asignar la lista al ListView
        personasListView.ItemsSource = personasList;
    }
}