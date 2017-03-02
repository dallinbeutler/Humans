using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    public class Opinion
    {
        public string topic;
        public float feelings;

        public Opinion(String inTop, float inFeel)
        {
            topic = inTop;
            feelings = inFeel;
            Console.Out.WriteLine("opinion made");
        }

        public string display()
        {
            return "\n- " + topic + " " + feelings ;
        }

    }

}
