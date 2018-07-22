using System;
using System.Threading;
using System.Configuration;
using System.Text.RegularExpressions;

namespace MathTest
{
    class Program
    {
        static int timeCnt = 0;

        static void Main(string[] args)
        {
            Configuration cfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if(cfg.AppSettings.Settings["Token"] == null)
            {
                cfg.AppSettings.Settings.Add("Token", "0");
            }
            int token = (int)(float.Parse(cfg.AppSettings.Settings["Token"].Value.ToString()));
            Console.WriteLine("你有{0}块钱",token);

            float totelScore = 100.0f;
            int qustionCnt = 20;

            MultiplicationQustion q = new MultiplicationQustion();

            var qus = q.select(qustionCnt);

            float score = totelScore;
            float scorePerQustion = totelScore / qustionCnt;

            Console.WriteLine("乘法测试，{0}题，满分{1}分", qustionCnt, totelScore);
            Console.WriteLine("*****************************");
            Console.WriteLine("按下任意键开始测试,并开始计时！");
            Console.ReadKey();

            timeCnt = 0;
            Timer timer = new Timer(OnTimer,"",0,100);
            
            for (int i = 0; i < qus.Count; i++)
            {
                Console.WriteLine(" ");
                Console.WriteLine("第{0:d}题", i + 1);
                Console.WriteLine(qus[i]);

                string input;
                Regex reg = new Regex("[\\d]{1,2}");
                while (true)
                {
                    input = Console.ReadLine();
                    var match = reg.Match(input);
                    if (match.Success)
                    {
                        input = match.Value;
                        break;
                    }
                    Console.WriteLine("???无法识别输入???");
                }
                //Console.WriteLine(input);
                //Console.ReadKey();

                var ans = int.Parse(input);
                var correctAns = MultiplicationQustion.Answer(qus[i]);
                if (ans == correctAns)
                {
                    Console.WriteLine("答对了！（'v'）");
                }
                else
                {
                    Console.WriteLine("回答错误！（'^'）");
                    Console.WriteLine("答案是：{0:d}", correctAns);
                    score -= scorePerQustion;
                }

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
            cfg.AppSettings.Settings["Token"].Value = (token + (int)score).ToString();
            cfg.Save();
            Console.ReadKey();
        }

        static void OnTimer(object state)
        {
            timeCnt++;
        }
    }
}
