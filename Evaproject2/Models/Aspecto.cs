using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evaproject2.Models
{
    public class Aspecto
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public double Valor { get; set; }
        public double Calificacion { get; set; }
        public int CriterioID { get; set; }

        //Navigation property
        public virtual Criterio Criterio { get; set; }

        public DateTime FC { get; set; }
        public DateTime FM { get; set; }
    }
}
