using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlimexIdentity.Model
{
    public class UserIdentiyModel
    {
        [Required]
        public string userId { get; set; }
        [Required]
        public string userName { get; set; }
        [Required]
        public List<string> role { get; set; }
        /// <summary>
        /// TimeOut dakika cinsinden
        /// null olabilir
        /// eğer null olursa zaman kontrolü yapılmayacaktır
        /// </summary>
        public byte? timeOut { get; set; }
    }
}
