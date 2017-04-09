using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlimexDAL.Entity
{
    public class Kategory:Base
    {
        public string KategoryName { get; set; }
        public virtual ICollection<Medicine> Medicines { get; set; }

    }
}
