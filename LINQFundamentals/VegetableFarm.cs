using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LINQFundamentals
{
    public class VegetableFarm
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime ExpiryDate { get; set; }

        public string sayHello(string name)
        {
            return "Hello! " + name;
        }
    }
}
