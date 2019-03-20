using System;
using System.Runtime.Serialization;

namespace SE.DataObjects
{
    [Serializable]
    [DataContract]
    public abstract class BaseResponse
    {
        [DataMember]
        public ResponseCodes ResponseCode { get; set; }

        [DataMember]
        public string ResponseMessage { get; set; }

        [DataMember]
        public string ResponseErrorMessage { get; set; }


    }
}
