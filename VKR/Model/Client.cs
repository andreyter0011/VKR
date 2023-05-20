using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using VKR.ViewModel;

namespace VKR.Model
{
    public class Client
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public DateTime Birth { get; set; }
        public int Passport { get; set; }
        public string? Contract { get; set; }
        public DateTime DataStartContract { get; set; }
        public DateTime DataEndContract { get; set; }
        public string? TypeContract { get; set; }
        public decimal PriceContract { get; set; }
        public int HowLongContract { get; set; }
        [ForeignKey("InsuranceId")]
        public insurance? Insurance { get; set; }
    }
}
