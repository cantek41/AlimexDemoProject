using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlimexDAL.Entity
{
    public class MedicineCopmany:Base
    {
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Web { get; set; }
        public virtual ICollection<Medicine> Medicines { get; set; }


    }
}
