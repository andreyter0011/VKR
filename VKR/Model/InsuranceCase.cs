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
        public string? losses { get; set; }
        [ForeignKey("InsuranceId")]
        public insurance insurance { get; set; }
    }
}
