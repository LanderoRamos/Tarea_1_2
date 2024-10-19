using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDatos.Modelos;

    [Table("Autores")]
    public class Autores
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }         // ID autoincrementable
        [SQLite.MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;
        [SQLite.MaxLength(100)]
        public string Nacionalidad { get; set; } = string.Empty;

        public string FotoBase64 { get; set; } = string.Empty;   // Imagen en formato Base64
    }

