using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Ejercicio2_2_Firmas.Modelos
{
    public class Firmas
    {
        [PrimaryKey, AutoIncrement]
        public int Codigo { get; set; }

        [MaxLength(20)]
        public String Nombre { get; set; }

        [MaxLength(150)]
        public String Descripcion { get; set; }

        public Byte[] Imagen { get; set; }
    }
}
