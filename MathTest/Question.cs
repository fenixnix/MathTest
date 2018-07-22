using System;
using System.Collections.Generic;

namespace MathTest
{
    public class Question
    {
		public List<string> allQuestion = new List<string>();

		virtual public List<string> Init(){
			return new List<string>();
		}

		public List<string> select(int cnt)
        {
			return select(allQuestion, cnt);
        }

		public List<string> select(List<string> backLog, int cnt)
        {
			var selectedTable = RandomSelect.selectXTimesInYSpace(cnt, backLog.Count);
            List<string> selected = new List<string>();
            foreach (var v in selectedTable)
            {
				selected.Add(backLog[v]);
                //Console.WriteLine(allQustion[v]);
                //Console.WriteLine(Answer(allQustion[v]));
            }
            return selected;
        }
    }
}
