using System;
namespace MathTest
{
    public class Answer
    {
        public Answer()
        {
        }
		public static int Calc(string question){
			var elm = question.Split(' ');
            if (elm.Length != 3)
            {
                Console.WriteLine("Error Question!!!");
                return 0;
            }
            var v1 = int.Parse(elm[0]);
            var opr = elm[1];
            var v2 = int.Parse(elm[2]);

            switch (opr)
            {
                case "+": return v1 + v2;
                case "-": return v1 - v2;
                case "x": return v1 * v2;
            }

            Console.WriteLine("InValid Question!!!");
            return 0;
		}
    }
}
