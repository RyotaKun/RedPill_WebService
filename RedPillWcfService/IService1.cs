using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RedPillWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(Namespace = "https://knockknock.readify.net")]
    public interface IRedPill
    {

        [OperationContract]
        Guid WhatIsYourToken();

        [OperationContract, FaultContract(typeof(ArgumentOutOfRangeException))]
        long FibonacciNumber(long n);

        [OperationContract]
        TriangleType WhatShapeIsThis(int a, int b, int c);

        [OperationContract, FaultContract(typeof(ArgumentNullException))]
        string ReverseWords(string s);
        
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract(Namespace = "https://knockknock.readify.net")]
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
