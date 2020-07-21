using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace APLActions.Models
{
    [DataContract]
    class LoadInputsModel
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "material")]
        public string Material { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "position")]
        public string Position { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "barcode")]
        public string Barcode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "device_type")]
        public string DeviceType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "device_id")]
        public string DeviceId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "location")]
        public string Location { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "rack_idx")]
        public string RackIdx { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "rack_id")]
        public string RackId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "level_idx")]
        public string LevelIdx { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "sealing")]
        public string Sealing { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "tearing")]
        public string Tearing { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "centrifuge")]
        public string Centrifuge { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "idx")]
        public int Idx { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "centrifuge_pn")]
        public string CentrifugePn { get; set; }
    }
}
