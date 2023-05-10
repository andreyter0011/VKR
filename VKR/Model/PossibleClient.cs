using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKR.Model
{
    public class PossibleClient
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public DateTime Birth { get; set; }
        public int Passport { get; set; }
    }
}
