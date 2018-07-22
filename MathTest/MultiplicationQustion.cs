using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathTest
{
    class MultiplicationQustion
    {
        List<string> allQustion = new List<string>();

        public MultiplicationQustion()
        {
            Init();
        }

        void Init()
        {
            for(int i = 2; i < 10; i++)
            {
                for(int j = 2; j < 10; j++)
                {
                    string q = i.ToString() + " * " + j.ToString() + " = ?";
                    //Console.WriteLine(q);
                    allQustion.Add(q);
                }
            }
        }

        public List<string> select(int cnt)
        {
            var selectedTable = RandomSelect.selectXTimesInYSpace(cnt, allQustion.Count);
            List<string> selected = new List<string>();
            foreach(var v in selectedTable)
            {
                selected.Add(allQustion[v]);
                //Console.WriteLine(allQustion[v]);
                //Console.WriteLine(Answer(allQustion[v]));
            }
            return selected;
        }

        public static int Answer(string qustion)
        {
            var pair = qustion.Split('=');
            var ePair = pair[0].Split('*');
            var v1 = int.Parse(ePair[0]);
            var v2 = int.Parse(ePair[1]);
            return v1 * v2;
        }
    }
}
