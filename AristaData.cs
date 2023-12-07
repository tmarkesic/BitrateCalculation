using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitrateCalculation
{
    public class AristaData
    {
        public string Device { get; set; }
        public string Model { get; set; }
        public List<AristaDataNIC> NIC { get; set; }
    }
}
