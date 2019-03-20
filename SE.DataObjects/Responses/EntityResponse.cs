using System;
using System.Runtime.Serialization;

namespace SE.DataObjects
{
    [Serializable]
    [DataContract]
    public class EntityResponse<T> : BaseResponse
    {
        [DataMember]
        public T EntityData { get; set; }
    }
}
