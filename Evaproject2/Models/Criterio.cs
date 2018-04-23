using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evaproject2.Models
{
    public class Criterio
    {
        public int ID { get; set; }
        public int Calificacion { get; set; }

        //Navigation Properties
        public virtual ICollection<Convocatoria> Convocatorias { get; set; }
        public virtual ICollection<Aspecto> Aspectos { get; set; }
        public virtual ICollection<Evaluacion> Evaluaciones { get; set; }

        public DateTime FC { get; set; }
        public DateTime FM { get; set; }
    }
}
