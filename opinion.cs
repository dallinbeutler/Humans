using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class Opinion
    {
        public string topic;
        public float feelings;

        public Opinion(String inTop, float inFeel)
        {
            topic = inTop;
            feelings = inFeel;
        }

        public string display()
        {
            return "-" + topic + " " + feelings;
        }
    }

}
