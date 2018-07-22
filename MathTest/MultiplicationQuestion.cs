﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathTest
{
	public class MultiplicationQuestion : Question
    {
        public MultiplicationQuestion()
        {
			allQuestion = Init();
        }

		public override List<string> Init()
        {
			List<string> tmp = new List<string>();
            for(int i = 2; i < 10; i++)
            {
                for(int j = 2; j < 10; j++)
                {
                    string q = i.ToString() + " * " + j.ToString();
                    //Console.WriteLine(q);
                    tmp.Add(q);
                }
            }
			return tmp;
        }
    }
}
