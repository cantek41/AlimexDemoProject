using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlimexDAL.Entity
{
    public class Pharmacy:Base
    {
        public string Name { get; set; }
        public string Adress { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
