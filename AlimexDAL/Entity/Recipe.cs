using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlimexDAL.Entity
{
    public class Recipe:Base
    {
        public double ToplamAmount { get; set; }
        //public virtual ICollection<Doctor> Doctors { get; set; }
        //public virtual ICollection<Pharmacy> Pharmacyies { get; set; }
        //public virtual ICollection<Patient> Patients { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual Pharmacy Pharmacy { get; set; }
        public virtual Patient Patient { get; set; }

       


    }
}
