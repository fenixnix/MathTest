using System;
using System.Threading;
using System.Text.RegularExpressions;

namespace MathTest
{
    class Program
    {
        static int timeCnt = 0;

        static void Main(string[] args)
        {
            //Configuration cfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //if(cfg.AppSettings.Settings["Token"] == null)
            //{
                //cfg.AppSettings.Settings.Add("Token", "0");
            //}
            //int token = (int)(float.Parse(cfg.AppSettings.Settings["Token"].Value.ToString()));
            //Console.WriteLine("你有{0}块钱",token);

            float totelScore = 100.0f;
            int qustionCnt = 50;

            float scorePerQustion = totelScore / qustionCnt;
            float score = 0;

            Console.WriteLine($"算术测试，{qustionCnt}题，满分{totelScore}分");
            Console.WriteLine("*****************************");
            Console.WriteLine("按下数字键选择题目类型开始测试,并开始计时！");
			Console.WriteLine("1.加法");
			Console.WriteLine("2.减法");
			Console.WriteLine("3.加减混合运算");
			Console.WriteLine("4.乘法");
            Console.WriteLine("5.加法一年级");
            Console.WriteLine("6.超级加法");

			var sel = Console.ReadLine();

			Question q = new Question();
			switch(sel){
				case "1":q.Add(0,20);break;
				case "2":q.Sub(0,20);break;
				case "3":q.Add(0,20);q.Sub(0,20); break;
				case "4":q.Mul();break;
                case "5": q.Add(10,99); break;
                case "6": q.Add(99, 999);break;
                default:break;
			}
            var qus = q.select(qustionCnt);

            timeCnt = 0;
            Timer timer = new Timer(OnTimer,"",0,100);
            
            for (int i = 0; i < qus.Count; i++)
            {
                Console.WriteLine(" ");
                Console.WriteLine("第{0:d}题", i + 1);
                Console.WriteLine(qus[i] + " = ?");

                string input;
                Regex reg = new Regex("[\\d]{1,3}");
                while (true)
                {
                    input = Console.ReadLine();
                    var match = reg.Match(input);
                    if (match.Success)
                    {
                        input = match.Value;
                        break;
                    }
                    Console.WriteLine("???不能识别答案???");
                }
                //Console.WriteLine(input);
                //Console.ReadKey();
                
                var ans = int.Parse(input);
				var correctAns = Answer.Calc(qus[i]);
                if (ans == correctAns)
                {
                    Console.WriteLine("答对了！（'v'）");
                    score += scorePerQustion;
                }
                else
                {
                    Console.WriteLine("回答错误！（'^'）");
                    Console.WriteLine("答案是：{0:d}", correctAns);
                    //score -= scorePerQustion;
                }
                Console.WriteLine($"当前分数{(int)score}");
                float tf = (float)timeCnt / 10.0f;
                Console.WriteLine("定时{0:f}秒", tf);
            }

            float timefloat = (float)timeCnt / 10.0f;
            Console.WriteLine("恭喜你！测试结束。总分：{0:d}", (int)score);
            Console.WriteLine("总耗时{0:f}秒", timefloat);
            if (score > totelScore * 0.9f)
            {
                Console.WriteLine("你实在是太棒了");
            }
            //cfg.AppSettings.Settings["Token"].Value = (token + (int)score).ToString();
            //cfg.Save();
            Console.ReadKey();
        }

        static void OnTimer(object state)
        {
            timeCnt++;
        }
    }
}
