using System;
using System.Collections.Generic;

namespace MathTest
{
	public class AdditionQuestion : Question
	{
        public AdditionQuestion()
        {
			allQuestion = Init();
        }

		public override List<string> Init()
		{
			List<string> tmp = new List<string>();
			for (int i = 0; i <= 100; i++)
			{
				for (int j = 0; j + i <= 100; j++)
				{
					string q = i.ToString() + " + " + j.ToString();
					//Console.WriteLine(q);
					tmp.Add(q);
				}
			}
			return tmp;
		}
    }
}
