using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKR.Model
{
    public class InsuranceCase
    {
        public Guid Id { get; set; }
        public DateTime date { get; set; }
        public string? description { get; set; }
        public string? repairCost { get; set; }
        public string? losses { get; set; }
        public string? status { get; set; }
        public string? expert { get; set; }
        [ForeignKey("InsuranceId")]
        public insurance insurance { get; set; }
    }
}
