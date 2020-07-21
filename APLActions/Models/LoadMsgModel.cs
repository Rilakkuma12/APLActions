using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace APLActions.Models
{
    [DataContract]
    public class LoadMsgModel
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
        public Message_content Message_content { get; set; }
    }
    public class Message_content
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "task_id")]
        public string Task_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "device_id")]
        public string Device_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "command_id")]
        public string Command_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "command")]
        public string Command { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "parameters")]
        public Parameters Parameters { get; set; }
    }
    public class Parameters
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "inputs")]
        public List<string> Inputs { get; set; }
    }

    

  
}
