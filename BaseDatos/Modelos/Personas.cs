using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace BaseDatos.Modelos;

    [Table("Personas")]
    public class Personas
    {
    [PrimaryKey, AutoIncrement]
        public int Id { get; set; }         // ID autoincrementable
    [SQLite.MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;
    [SQLite.MaxLength(100)]
        public string Apellido { get; set; } = string.Empty;
    
        public DateTime fecha { get; set; }
    [Unique]
        public string Telefono { get; set; } = string.Empty;   // Imagen en formato Base64

    }
