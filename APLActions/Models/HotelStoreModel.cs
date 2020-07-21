using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace APLActions.Models
{
    [DataContract]
    public class HotelStoreModel
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "message_id")]
        public string Message_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "message_type")]
        public string Message_type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "message_group")]
        public string Message_group { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "message_content")]
        public Message_contentItem Message_content { get; set; }
    }
    public class Message_contentItem
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "module_id")]
        public string Module_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "device_type")]
        public string Device_type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "device_id")]
        public string Device_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "storage")]
        public List<StorageItem> Storage { get; set; }
    }
    public class StorageItem
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "rack_idx")]
        public string Rack_idx { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "rack_id")]
        public string Rack_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "rack_store")]
        public List<Rack_storeItem> Rack_store { get; set; }
    }
    public class Rack_storeItem
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "level_idx")]
        public string Level_idx { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "barcode")]
        public string Barcode { get; set; }
    }

    

    

    
}
