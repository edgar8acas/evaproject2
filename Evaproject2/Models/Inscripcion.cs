using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evaproject2.Models
{
    public class Inscripcion
    {
        public int ID { get; set; }
        public int ConvocatoriaID { get; set; }
        public int ParticipanteID { get; set; }
        public int TipoInscripcion { get; set; }
        public string PdfProyecto { get; set; }

        //Navigation Properties
        public virtual Convocatoria Convocatoria { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Evaluacion> Evaluaciones { get; set; }

        public DateTime FC { get; set; }
        public DateTime FM { get; set; }
    }
}
