using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Sums_Of_Subsets
{
    class Sums
    {
        List<int> list = new List<int>();
        int i;
      
        public Sums(List<int> l,int z)
        {
            list = l;
            i = z;
        }
        public List<int> find() //if I double length of list will time taken be doubled?
        {
         
            List<int> valid = check();
            if (valid == null)
            {
                Console.WriteLine("Not possible");
                return null;
            }
            int length = valid.Count()-1;
            List<int> int_return = new List<int>();
            DateTime now = DateTime.Now;
            int timeleft;
            while (int_return.Sum()!= i)
            {
                Random ran = new Random();
                int num = ran.Next(0, length);
                if(!int_return.Contains(valid[num]))
                    int_return.Add(valid[num]);
                if (int_return.Sum() > i)
                    int_return.Clear();
                DateTime now2 = DateTime.Now;
                timeleft = now2.Second - now.Second;
         
                if (timeleft > 15)
                {
                    Console.WriteLine("Timed out");
                    return null;
                }
            }
            return int_return;
        }
        public List<int> check() //are there numbers less than i, //does sum of valid numbers reach i
        {
            List <int>valid = (from x in list where x <= i select x).ToList();
            Console.WriteLine($"valid is {string.Join(",", valid)}");
            if (valid.Count() == 0)
                return null;
            if (valid.Sum() < i)
                return null;
            else
                return valid;
        }
    }
}
