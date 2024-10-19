namespace BaseDatos.Views;

public partial class EditarAutoresPage : ContentPage
{
    private Modelos.DBService _dbService;
    public EditarAutoresPage(Modelos.Autores autores)
	{
		InitializeComponent();
        _dbService = new Modelos.DBService();
        BindingContext = autores;
    }
    private async void Guardar_Clicked(object sender, EventArgs e)
    {
        // Llamar a DBService para guardar los cambios
        await _dbService.StoreAutor((Modelos.Autores)BindingContext);
        await Navigation.PopAsync(); // Regresar a la página anterior
    }
}