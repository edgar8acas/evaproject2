using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evaproject2.Models
{
    public class Evaluacion
    {
        public int ID { get; set; }
        public int CriterioID { get; set; }
        public int EvaluadorID { get; set; }
        public int InscripcionID { get; set; }


        //Navigation properties
        //public virtual Inscripcion Inscripcion { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Criterio Criterio { get; set; }

        public DateTime FC { get; set; }
        public DateTime FM { get; set; }
    }
}
