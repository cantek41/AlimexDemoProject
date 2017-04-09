using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlimexDAL.Entity
{
    public class Medicine:Base
    {
        public string BarcodeNo { get; set; }
        public string MedicineName { get; set; }
        public int BoxNumber { get; set; }
        public double Price { get; set; }
        public string PurposeUse { get; set; }
        public int SideEffects { get; set; }
        public string Usage { get; set; }

        public virtual Kategory Kategory { get; set; }
        public virtual MedicineCopmany MedicineCompany { get; set; }


        
    }
}
