using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    public class Person
    {
        bool gender;
        string name;
        float malleability;
        float charisma;
        List<Opinion> opinions;

        public Person(String inName)
        {
            Random r = new Random();
            gender = false;
            name = inName;
            malleability = (float)r.NextDouble();
            charisma = (float)r.NextDouble();
            opinions = new List<Opinion>();
        }

        public void interact(Person p)
        {
            Random r = new Random();
            int choiceOp = (int)Math.Round(r.NextDouble() * (double)(opinions.Count));
            for (int i = 0; i < p.opinions.Count; i++)
            {
                if (p.opinions[i].topic == opinions[choiceOp].topic)
                {
                    p.opinions[i].feelings += opinions[choiceOp].feelings * charisma * p.malleability;
                    opinions[choiceOp].feelings += p.opinions[i].feelings * p.charisma * malleability;
                    break;
                }
            }
        }
        public void addOpinion(string inTopic, float infeelings)
        {
            foreach (Opinion op in opinions)
                if (inTopic == op.topic)
                    return;
            opinions.Add(new Opinion(inTopic, infeelings));
        }
        public override string ToString()
        {
            string outstring = name;
            outstring += "\nMalleability:" + malleability;
            outstring += "\nCharisma:" + charisma;

            return outstring;
        }
        public string opinionToString()
        {
            string outstring = "\nOpinions:"; ;
            foreach (Opinion o in opinions)
            {
                outstring += o.display();
            }
            return outstring;
        }
    }
}
