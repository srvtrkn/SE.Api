using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SE.DataObjects
{
    [Serializable]
    [DataContract]
    public class EntityListResponse<T> : BaseResponse
    {
        [DataMember]
        public List<T> EntityDataList { get; set; } = new List<T>();
    }
}
