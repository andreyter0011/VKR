using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKR.Model
{
    public class Contract
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int NumberContract { get; set; }
        [ForeignKey("ClientId")]
        public Client Client { get; set; }
        [ForeignKey("InsuranceId")]
        public insurance insurance { get; set; }
    }
}
