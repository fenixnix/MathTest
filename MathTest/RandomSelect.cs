using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathTest
{
    public class RandomSelect
    {
        public static List<int> selectXTimesInYSpace(int x, int y)
        {
            List<int> selectSpace = new List<int>();
            for(int i = 0; i < y; i++)
            {
                selectSpace.Add(i);
            }

            Random rnd = new Random();
            List<int> selected = new List<int>();
            for(int i = 0; i < x; i++)
            {
                if(selectSpace.Count == 0)
                {
                    return selected;
                }
                int r = rnd.Next() % selectSpace.Count;
                selected.Add(selectSpace[r]);
                selectSpace.RemoveAt(r);
            }

            return selected;
        }
    }
}
