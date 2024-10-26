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

    private async void OnItemTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item == null) return;

        var autorSeleccionado = (Modelos.Autores)e.Item;
        await Navigation.PushAsync(new EditarAutoresPage(autorSeleccionado));

        ((ListView)sender).SelectedItem = null;

        //menu
        /*string action = await DisplayActionSheet("Selecciona una opción", "Cancelar", null, "Opción 1", "Opción 2", "Opción 3");

        if (action != null)
        {
            // Realiza una acción basada en la opción seleccionada
            switch (action)
            {
                case "Opción 1":
                    await DisplayAlert("Seleccionaste", "Opción 1", "OK");
                    break;
                case "Opción 2":
                    await DisplayAlert("Seleccionaste", "Opción 2", "OK");
                    break;
                case "Opción 3":
                    await DisplayAlert("Seleccionaste", "Opción 3", "OK");
                    break;
                default:
                    await DisplayAlert("Cancelar", "No seleccionaste ninguna opción.", "OK");
                    break;
            }
        }*/


    }

    private async void EliminarAutor_SwipeItemInvoked(object sender, EventArgs e)
    {
        var swipeItem = (SwipeItem)sender;
        var autor = (Modelos.Autores)swipeItem.CommandParameter;

        bool confirmacion = await DisplayAlert("Eliminar", "¿Estás seguro de eliminar este autor?", "Sí", "No");
        if (confirmacion)
        {
            await _dbService.DeleteAutores(autor); // Eliminar de la base de datos
            personasListView.ItemsSource = await _dbService.GetAutores(); // Recargar la lista
        }
    }



}