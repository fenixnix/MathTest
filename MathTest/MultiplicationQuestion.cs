using System;
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
			return Multiplication(2, 9);
        }
    }
}
