using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFestival
{
    public class Artista
    {
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public string Pais { get; set; }
        public string TipoMusica { get; set; }
        public string Descripcion { get; set; }
        public string Foto { get; set; }
    }

    public class Escenario
    {
        public string Nombre { get; set; }
        public int Capacidad { get; set; }
        public string Ubicacion { get; set; }
    }

    public class Festival
    {
        public string Nombre { get; set; }
        public string Fecha { get; set; }
        public string Lugar { get; set; }
    }
}
