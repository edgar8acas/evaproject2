using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evaproject2.Models
{
    public class Usuario
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Pwd { get; set; }
        public int TipoUsuario { get; set; }
        public string Celular { get; set; }
        public string Ciudad { get; set; }
        public string Domicilio { get; set; }
        public string CodigoPostal { get; set; }
        public DateTime FNacimiento { get; set; }
        public string NivelEstudios { get; set; }
        public string CampoEstudios { get; set; }

        //Navigation properties
        public virtual ICollection<Evaluacion> Evaluaciones { get; set; }
        public virtual ICollection<Inscripcion> Inscripciones { get; set; }

        public DateTime FC { get; set; }
        public DateTime FM { get; set; }
    }
}
