using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GineSys.Models
{
    public class Ocupacion
    {
        public int OcupacionId { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public string UsuarioModificacion { get; set; }
    }
}