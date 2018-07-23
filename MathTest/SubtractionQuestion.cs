using System;
using System.Collections.Generic;
namespace MathTest
{
	public class SubtractionQuestion : Question
    {
        public SubtractionQuestion()
        {
			Init();
        }
		public override List<string> Init()
		{
			return Subtraction(1, 100);
		}
	}
}
