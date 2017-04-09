using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlimexDAL.Entity
{
    public class RecipeDetail:Base
    {
        public int BoxNumber { get; set; }
        public virtual Recipe Recipe { get; set; }
        public virtual Medicine Medicine { get; set; }
    }
}
