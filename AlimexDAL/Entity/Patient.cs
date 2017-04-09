using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlimexDAL.Entity
{
    public class Patient:Base
    {
        public string TcNo { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }

    }
}
