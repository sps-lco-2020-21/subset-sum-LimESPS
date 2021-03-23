using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sums_Of_Subsets
{
    class Program
    {
        static void Main(string[] args)
        {
            Sums first = new Sums(new List<int> { 3, 10, 5, 17, 8, 7, 4, 4 }, 21);
            List<int> val = first.find();
            Console.WriteLine(string.Join(",",val));
            process(); //my random method works the best (Sums.cs)
            Standard_Sum();
            Console.ReadKey();
        }
        static void process() //for Sum
        {
            for(int i=0; i < 12; ++i)
            {
                List<int> now = generate();
                int now2 = ran();
                Console.WriteLine($"List is {string.Join(",", now)}");
                Console.WriteLine($"p is {now2}");
                Sums trial = new Sums(now, now2);
                DateTime tnow = DateTime.Now;
                
                List<int> val4 = trial.find(); //likelyhood of i being in list is very high, hence it is more dependant on how fast can computer spot i in list.
                if (val4 != null)
                    Console.WriteLine($"subset is {string.Join(",", val4)}");
                else if (val4 == null)
                    Console.WriteLine("Not possible");
                DateTime tnow2 = DateTime.Now;
                Console.WriteLine($"time taken is {tnow2.Second - tnow.Second }");
            }
        }
        static List<int> generate() //for Sum
        {
            List<int> to_return = new List<int>();
            Random val = new Random();
            int length = val.Next(1, 100);
            while (to_return.Count() < length)
            {
                int num = val.Next(1, 100);
                to_return.Add(num);
            }
            return to_return;
        }
        static int ran() //for Sum
        {
            Random val = new Random();
          
            return val.Next(0, 50);
        }
        static void Standard_Sum()
        {
            List<int> Standard = new List<int> { 3, 10, 5, 17, 8, 7, 4, 4 };
            int val = 21;
            Sums_Standard norm = new Sums_Standard(Standard, val);
            norm.find2();
        }
    }
}
