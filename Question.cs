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

		public void Clear(){
			allQuestion.Clear();
		}

		public void Add(int min = 0, int max = 100){
			allQuestion.AddRange(Addition(min, max));
		}

		public void Sub(int min = 1, int max = 100)
        {
			allQuestion.AddRange(Subtraction(min, max));
        }

		public void Mul(int min = 2, int max = 9)
        {
			allQuestion.AddRange(Multiplication(min, max));
            PrintMulTable();
        }

        public void PrintMulTable(){
            Console.WriteLine("乘法口诀表:");
            for(int j = 1;j<10;j++){
                for(int i = 1;i<=j;i++){
                   Console.Write($"{i} * {j} = {i*j}   ");
                }
                Console.WriteLine();
            }
        }
        
		static public List<string> Addition(int min, int max){
			List<string> tmp = new List<string>();
            for (int i = min; i <= max; i++)
            {
                for (int j = min; j + i <= max; j++)
                {
                    string q = i.ToString() + " + " + j.ToString();
                    //Console.WriteLine(q);
                    tmp.Add(q);
                }
            }
            return tmp;
		}
        
		static public List<string> Subtraction(int min, int max){
			List<string> tmp = new List<string>();
            for (int i = min; i <= max; i++)
            {
                for (int j = min; i - j >= 0; j++)
                {
                    string q = i.ToString() + " - " + j.ToString();
                    //Console.WriteLine(q);
                    tmp.Add(q);
                }
            }
            return tmp;
		}

		static public List<string> Multiplication(int min, int max){
			List<string> tmp = new List<string>();
            for (int i = min; i <= max; i++)
            {
                for (int j = min; j <= max; j++)
                {
                    string q = i.ToString() + " * " + j.ToString();
                    //Console.WriteLine(q);
                    tmp.Add(q);
                }
            }
            return tmp;
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
