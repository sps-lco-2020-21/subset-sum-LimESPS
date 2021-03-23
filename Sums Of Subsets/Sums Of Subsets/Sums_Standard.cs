using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sums_Of_Subsets
{
    class Sums_Standard
    {
        List<int> l;
        int i;
        public Sums_Standard(List<int> li, int z)
        {
            l = li;
            i = z;
        }
        public void find2()
        {
            int count = 0;
            Stack<int> empty = new Stack<int>();
            Stack<int> wanted = new Stack<int>();
            foreach(int x in l) //remove all numbers more than i
            {
                if (x <= i)
                    wanted.Push(x);
                if (x == i)
                {
                    Console.WriteLine("Number has been found in list"); 
                    empty.Push(x);
                }
            }
            int trial = 0;
            bool end = false;
            while (wanted.Sum() != i) //going to try to find all possible combinations, start from 0, add all values, then move to new list with 1, add all values
            {
                if (count > l.Count() - 1) //reset
                {

                    ++trial;
                    if (trial > l.Count())
                        end = true;
                    count = trial;
                    goto skiptoend;
                }
                empty.Push(l[count]);
                if (empty.Sum() > i)
                    empty.Pop();
                
                ++count;
            skiptoend:
                if (end)
                    break;
                

            }
            Console.WriteLine(string.Join(",", empty));
        }
    }
}
