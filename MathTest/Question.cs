using System;
using System.Collections.Generic;

namespace MathTest
{
    public class Question
    {
		public List<string> allQustion = new List<string>();

		virtual public void Init(){
			
		}

		public List<string> select(int cnt)
        {
            var selectedTable = RandomSelect.selectXTimesInYSpace(cnt, allQustion.Count);
            List<string> selected = new List<string>();
            foreach (var v in selectedTable)
            {
                selected.Add(allQustion[v]);
                //Console.WriteLine(allQustion[v]);
                //Console.WriteLine(Answer(allQustion[v]));
            }
            return selected;
        }
    }
}
