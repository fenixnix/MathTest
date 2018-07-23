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
			return Addition(0, 100);
		}
    }
}
