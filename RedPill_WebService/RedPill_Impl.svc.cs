using RedPill_WebService.RedPill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RedPill_WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RedPill_Impl" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RedPill_Impl.svc or RedPill_Impl.svc.cs at the Solution Explorer and start debugging.
    public class RedPill_Impl : IRedPill
    {

        public Guid WhatIsYourToken()
        {
            return new System.Guid("1899e661-d529-4bbb-95b7-7d27ce38b4f5");
        }

        public long FibonacciNumber(long n)
        {
            return MyFibonacci(n);
        }
        long MyFibonacci(long value)
        {
            if (value == 0 || value == 1)
                return value;
            return MyFibonacci(value - 1) + MyFibonacci(value - 2);
        }

        public RedPill.TriangleType WhatShapeIsThis(int a, int b, int c)
        {
            int[] value = new int[3] { a, b, c };
            if (a <= 0 || b <= 0 || c <= 0)
            {
                return RedPill.TriangleType.Error;
            }
            else
            {
                int check = value.Distinct().Count(); //count distinct value(s) int the set
                switch (check)
                {
                    case 1:
                        return RedPill.TriangleType.Equilateral;
                    case 2:
                        return RedPill.TriangleType.Isosceles;
                    default:
                        return RedPill.TriangleType.Scalene;
                }
            }
        }


        public string ReverseWords(string s)
        {
            char[] result = s.ToCharArray();
            Array.Reverse(result);
            return string.Format("Reveresed word of " + s + " is: " + new string(result));
        }



        public System.Threading.Tasks.Task<Guid> WhatIsYourTokenAsync()
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<long> FibonacciNumberAsync(long n)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<TriangleType> WhatShapeIsThisAsync(int a, int b, int c)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<string> ReverseWordsAsync(string s)
        {
            throw new NotImplementedException();
        }
    }
}
