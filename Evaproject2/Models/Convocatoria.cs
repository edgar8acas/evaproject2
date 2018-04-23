using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evaproject2.Models
{
    public class Convocatoria
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public DateTime FRegistro { get; set; }
        public DateTime FEnvio { get; set; }
        public DateTime FEvaluacion { get; set; }
        public DateTime FResultados { get; set; }
        public int NoParticipantes { get; set; }
        public int NoEvaluadores { get; set; }

        public int CriterioID { get; set; }
        public string RutaDescripcion { get; set; }
        public string RutaResultados { get; set; }

        //navigation property
        public virtual Criterio Criterio { get; set; }
        public virtual ICollection<Inscripcion> Inscripciones { get; set; }

        public DateTime FC { get; set; }
        public DateTime FM { get; set; }
    }
}
