using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppProject_2
{
    internal class Teacher
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public string Section { get; set; }

        public override string ToString()
        {
            return $"{ID},{Name},{Class},{Section}";
        }
    }
}
