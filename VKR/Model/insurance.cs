using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKR.Model
{
    public class insurance
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string? Type { get; set; }
        public string? PropertyValue { get; set; }
        public string? InsuranceCoverage { get; set; }
        public string? DegreeRisk { get; set; }
        public string? PriceInsurance { get; set; }
        [ForeignKey("ContractId")]
        public Contract? Contract { get; set; }
        [ForeignKey("ClientId")]
        public Client? Client { get; set; }
    }
}
