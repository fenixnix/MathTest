using System;
namespace MathTest
{
	public class SubtractionQuestion : Question
    {
        public SubtractionQuestion()
        {
			Init();
        }
		public override void Init()
		{
			for (int i = 0; i <= 100; i++)
            {
                for (int j = 0; i-j >= 0; j++)
                {
                    string q = i.ToString() + " - " + j.ToString();
                    //Console.WriteLine(q);
                    allQustion.Add(q);
                }
            }
		}
	}
}
