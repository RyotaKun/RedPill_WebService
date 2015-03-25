using RedPill_WebService.RedPill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace RedPill_WebService
{
    /// <summary>
    /// The implimentation of thr RedPill web service from https://knockknock.readify.net/
    /// </summary>
    [WebService(Namespace = "http://sangtruong.somee.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class RedPill_Implementation : IRedPill
    {

        /*
         * Return the assigned Token 1899e661-d529-4bbb-95b7-7d27ce38b4f5
         */
        [WebMethod]
        public Guid WhatIsYourToken()
        {
            return new System.Guid("1899e661-d529-4bbb-95b7-7d27ce38b4f5");
        }

        public System.Threading.Tasks.Task<Guid> WhatIsYourTokenAsync()
        {
            throw new NotImplementedException();
        }

        /*
         * Return the Fibonacci value of a nth number
         */
        [WebMethod]
        public long FibonacciNumber(long n)
        {
                return MyFibonacci(n);
        }
        long MyFibonacci (long value)
        {
            if (value == 0 || value == 1)
                return value;
            return MyFibonacci(value - 1) + MyFibonacci(value - 2);
        }

        public System.Threading.Tasks.Task<long> FibonacciNumberAsync(long n)
        {
            throw new NotImplementedException();
        }

        /*
         * Return the shape of a given triangle
         */
        [WebMethod]
        public TriangleType WhatShapeIsThis(int a, int b, int c)
        {
            int[] value = new int[3] { a, b, c };
            if (a <= 0 || b <= 0 || c <= 0)
            {
                return TriangleType.Error;
            }
            else
            {
                int check = value.Distinct().Count(); //count distinct value(s) int the set
                switch (check)
                {
                    case 1:
                        return TriangleType.Equilateral;
                    case 2:
                        return TriangleType.Isosceles;
                    default:
                        return TriangleType.Scalene;
                }
            }
        }

        public System.Threading.Tasks.Task<TriangleType> WhatShapeIsThisAsync(int a, int b, int c)
        {
            throw new NotImplementedException();
        }

        /*
         * Return the reverse value of a given string
         */
        [WebMethod]
        public string ReverseWords(string s)
        {
            char[] result = s.ToCharArray();
            Array.Reverse(result);
            return string.Format("Reveresed word of " + s + " is: " + new string(result));
        }

        public System.Threading.Tasks.Task<string> ReverseWordsAsync(string s)
        {
            throw new NotImplementedException();
        }
    }
}
