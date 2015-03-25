using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RedPill
{
    /*
     * IRedPill interface replicate from KnockKnock.readify.net RedPill webservice
     */
    [ServiceContract(Namespace = "http://KnockKnock.readify.net")]
    public interface IRedPill
    {
        /*
         * Service Operations
         */
        [OperationContract]
        Guid WhatIsYourToken();

        [OperationContract, FaultContract(typeof(ArgumentOutOfRangeException))]
        long FibonacciNumber(long n);

        [OperationContract]
        TriangleType WhatShapeIsThis(int a, int b, int c);

        [OperationContract, FaultContract(typeof(ArgumentNullException))]
        string ReverseWords(string s);

    }


    /*
     * TriangleType enumeration type replcated from KnockKnock.readify.net RedPill webservice
     */
    [DataContract(Namespace = "http://KnockKnock.readify.net")]
    public enum TriangleType
    {
        [EnumMember]
        Error,
        [EnumMember]
        Equilateral,
        [EnumMember]
        Isosceles,
        [EnumMember]
        Scalene
    }
}
