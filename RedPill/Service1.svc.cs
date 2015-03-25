/* RedPill_WebService RedPill
 *
 * Service Service1.svc
 *
 * Objective: reimplement KnockKnock.readify.net RedPill webservice
 *      Has four service operations:
 *          GUID WhatIsYourToken()
 *          long FibonacciNumber(long n)
 *          TriangleType WhatShapeIsThis(int a, int b, int c)
 *          string ReverseWords(string s)
 *          
 * Implemented by: Sang M Truong
 *
 * Started: 24 March 2015
 *
 * Revised by: 
 *
 * Member variables: 
 *
 * Public methods:
 *
 * Private methods:
 *
 * Input: 
 *
 * Output: 
 *
 * Error handling: 
 *
 * Regression testing: 
 *
 * Known bugs: 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RedPill
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(Namespace = "http://KnockKnock.readify.net")]
    public class Service1 : IRedPill
    {
        /*
         * Operation returns predefined Token
         * Precondition:
         * Postcondition:
         */
        public Guid WhatIsYourToken()
        {
            return new Guid("1899e661-d529-4bbb-95b7-7d27ce38b4f5");
        }

        /*
         * Operation returns Fibonacci value of nth number 
         * Precondition: 
         * Postcondition:  
         */
        public long FibonacciNumber(long n)
        {
            //if (value < 0 throw new FaultException(new ArgumentOutOfRangeException("Require value >= 0"));
            //if (n < 0 ) throw new ArgumentOutOfRangeException("Require value >= 0");
            //if (n <= 2)
            //{
            //    if (n == 2)
            //        return 1;
            //    else
            //        return n;
            //}
            //else
            //    return FibonacciNumber(n - 1) + FibonacciNumber(n - 2);
            
            //Attempt 2, matrix, solve in O(logn)
            //if (n < -92 || n > 92) throw new ArgumentOutOfRangeException("Require 92 >= value >= -92");
            if (n < -92 || n > 92) FaultExp(new ArgumentOutOfRangeException("n", "Require 92 >= value >= -92"));
            //
            Boolean negSignCheck = false;
            if (n < 0)
            {
                n = -n;
                if(n%2 == 0)
                    negSignCheck = true;
            }
            if (n <= 1)
            {
                return n;
            }
            long[,] A = { { 1, 0 }, { 0, 1 } };
            long[,] M = { { 1, 1 }, { 1, 0 } };
            while ( n > 0)
            {
                if (n%2 == 1)
                {
                    matrixMult(A, M);
                    n -= 1;
                }
                n /= 2;
                matrixMult(M, M);
            }
            if(negSignCheck) return -A[1,0];
            return A[1,0];
        }

        /*
         * 2x2 Matrix multiplication implementation using two 2x2 arrays
         * Preconditon:
         * Postcondition:
         */
        void matrixMult(long[,] m, long[,] n)
        {
            long a = m[0, 0] * n[0, 0] + m[0, 1] * n[1, 0];
            long b = m[0, 0] * n[0, 1] + m[0, 1] * n[1, 1];
            long c = m[1, 0] * n[0, 0] + m[1, 1] * n[1, 0];
            long d = m[1, 0] * n[0, 1] + m[1, 1] * n[1, 1];
            m[0,0]= a;
            m[0,1]= b;
            m[1,0]= c;
            m[1,1]= d;
        }

        /*
         * Operation returns the shape of a given triangle
         * Precondition:
         * Postcondition:
         */
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

        /*
         * Operation returns a reversed value of a given string
         * Precondition:
         * Postcondition:
         */
        public string ReverseWords(string s)
        {
            //if (s == null) throw new ArgumentNullException("Require input value != null");
            if (s == null) FaultExp(new ArgumentNullException("s", "Require s != null"));
            char[] result = s.ToCharArray();
            Array.Reverse(result);
            return new string(result);
        }

        /*
         * Exception handling using FaultException
         * Precondition:
         * Postcondition:
         */
        void FaultExp<T>(T detail) where T : Exception
        {
            throw new FaultException<T>(detail, detail.Message);
        }
        }
}
