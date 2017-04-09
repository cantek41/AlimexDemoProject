using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlimexDAL.Entity
{
    public class Doctor:Base
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string DiplomaNumber { get; set; }
        public virtual Hospital Hospital { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }


    }
}
