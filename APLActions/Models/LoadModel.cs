using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace APLActions.Models
{
    [DataContract]
    public class LoadModel
    {
        [DataMember(Name = "load")]
        public Dictionary<string, Dictionary<string, string>> Load { get; set; }
    }
}
