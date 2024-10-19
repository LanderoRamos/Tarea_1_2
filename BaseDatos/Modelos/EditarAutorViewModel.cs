using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDatos.Modelos
{
    class EditarAutorViewModel
    {
        private DBService _dbService;
        public Modelos.Autores Autor { get; set; }

        public EditarAutorViewModel(Modelos.Autores autor, DBService dbService)
        {
            Autor = autor;
            _dbService = dbService;
            GuardarCommand = new Command(async () => await GuardarAutor());
        }

        public Command GuardarCommand { get; }

        private async Task GuardarAutor()
        {
            await _dbService.StoreAutor(Autor); // Utiliza el método StoreAutor para actualizar o insertar
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
