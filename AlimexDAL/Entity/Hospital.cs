using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlimexDAL.Entity
{
    public class Hospital:Base
    {
        public string Name { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; }

    }
}
