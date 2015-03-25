using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RedPillWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IRedPill
    {

        public Guid WhatIsYourToken()
        {
            return new Guid("1899e661-d529-4bbb-95b7-7d27ce38b4f5");
        }

        //public IAsyncResult BeginWhatIsYourToken(AsyncCallback callback, object asyncState)
        //{
        //    throw new NotImplementedException();
        //}

        //public Guid EndWhatIsYourToken(IAsyncResult result)
        //{
        //    throw new NotImplementedException();
        //}

        public long FibonacciNumber(long n)
        {
            return MyFibonacci(n);
        }
        long MyFibonacci(long value)
        {
            //if (value < 0 throw new FaultException(new ArgumentOutOfRangeException("Require value >= 0"));
            if (value < 0) throw new ArgumentOutOfRangeException("Require value >= 0");
            if (value == 0 || value == 1)
                return value;
            return MyFibonacci(value - 1) + MyFibonacci(value - 2);
        }

        //public IAsyncResult BeginFibonacciNumber(long n, AsyncCallback callback, object asyncState)
        //{
        //    throw new NotImplementedException();
        //}

        //public long EndFibonacciNumber(IAsyncResult result)
        //{
        //    throw new NotImplementedException();
        //}

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

        //public IAsyncResult BeginWhatShapeIsThis(int a, int b, int c, AsyncCallback callback, object asyncState)
        //{
        //    throw new NotImplementedException();
        //}

        //public TriangleType EndWhatShapeIsThis(IAsyncResult result)
        //{
        //    throw new NotImplementedException();
        //}

        public string ReverseWords(string s)
        {
            if (s == null) throw new ArgumentNullException("Require s != null");
            char[] result = s.ToCharArray();
            Array.Reverse(result);
            return string.Format("Reveresed word of " + s + " is: " + new string(result));
        }

        //public IAsyncResult BeginReverseWords(string s, AsyncCallback callback, object asyncState)
        //{
        //    throw new NotImplementedException();
        //}

        //public string EndReverseWords(IAsyncResult result)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
