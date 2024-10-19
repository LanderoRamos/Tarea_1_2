using System;
namespace BaseDatos.Views;

public partial class Foto_ComboBox : ContentPage
{
    string base64Image;

    public Foto_ComboBox()
	{
		InitializeComponent();

        //lista para el combobox o spiner
        myPicker.Items.Add("Honduras");
        myPicker.Items.Add("Guatemala");
        myPicker.Items.Add("El Salvador");
        myPicker.Items.Add("Belice");
        myPicker.Items.Add("Nicaragua");
        myPicker.Items.Add("CostaRica");
        myPicker.Items.Add("Panama");

    }

    // Tomar foto inicio
    public async void TakePhoto(object sender, EventArgs e)
    {
        if (MediaPicker.Default.IsCaptureSupported)
        {
            FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

            if (photo != null)
            {
                // Guardar el archivo en almacenamiento local
                string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

                // Usar un bloque using para asegurarse de que los streams se cierran correctamente
                using (Stream sourceStream = await photo.OpenReadAsync())
                {
                    using (FileStream localFileStream = File.OpenWrite(localFilePath))
                    {
                        await sourceStream.CopyToAsync(localFileStream);
                    }
                }

                // Mostrar la imagen capturada
                capturedImage.Source = ImageSource.FromFile(localFilePath);

                // Convertir la imagen a base64 (asegurarse de que los flujos anteriores están cerrados)
                base64Image = await ConvertImageToBase64(localFilePath);
                //await DisplayAlert("Imagen en Base64", base64Image, "OK");
            }
        }
    }
    //fin de tomar foto

    private async Task<string> ConvertImageToBase64(string imagePath)
    {
        byte[] imageBytes;
        using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
        {
            using (MemoryStream ms = new MemoryStream())
            {
                await fs.CopyToAsync(ms);
                imageBytes = ms.ToArray();
            }
        }

        // Convertir los bytes de la imagen a una cadena base64
        return Convert.ToBase64String(imageBytes);
    }

    public async void Agregar1(object sender, EventArgs e)
    {

        string Nombre = MyEntry_Nombre.Text;

        if (Nombre != null && base64Image != null && myPicker.SelectedItem != "")
        {
            var autores = new Modelos.Autores
            {
                Nombre = Nombre,
                Nacionalidad = "" + myPicker.SelectedItem,
                FotoBase64 = base64Image
            };


            if (await App.DataBase.StoreAutor(autores) > 0)
            {
                await DisplayAlert("Aviso", "Registrado con exito", "OK");
            }

        }
        else {
            await DisplayAlert("Aviso", "Registrado sin exito", "OK");
        }
         
        
        


        

        //        DisplayAlert("El resultado es:", "Foto: " + base64Image + " \n" +"Nombre: " + Nombre + "\n" +"Nacionalidad: " + myPicker.SelectedItem, "ok");
    }


    public async void VerLista(object sender, EventArgs e) {
        var pagina = new Views.AutoresDetalle();
        await Navigation.PushAsync(pagina);
    }

    private void OnTextChanged(object sender, TextChangedEventArgs e)
    {
        // Puedes manejar el cambio de texto aqu? si lo necesitas
        // Por ejemplo, validar el texto ingresado
    }


}