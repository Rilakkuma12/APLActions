using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace APLActions.Manage
{
    [DataContract]
    class AplQueryModel
    {
        [DataMember(Name = "status_code")]
        public string StatusCode { get; set; }
        [DataMember(Name = "Content")]
        public string Content { get; set; }
        [DataMember(Name = "Position")]
        public string Position { get; set; }
        [DataMember(Name = "BarCode")]
        public string BarCode { get; set; }
    }
}
