using System;
using System.Collections.Generic;
using System.Text;
using BlazorApp1.Data;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace APLActions
{
    public class AplScan
    {
        ///
        private string msg = @"
        {{
            ""message_id"": ""UUID"",
            ""message_type"": ""device_command"",
            ""message_group"": ""{0}"",
            ""message_content"": {{
                ""module_id"": ""7"",
                ""device_type"": ""Hotel"",
                ""device_id"": ""{1}"",
                ""command_id"": ""{2}"",
                ""command"": ""{3}"",
                ""parameters"": {{
                    ""rack_idxs"": []
                }}
            }}
        }}";
        private Guid commandId = Guid.NewGuid();
        private KafkaProducer _producer;
        private int taskid = 123;
        private string topic = "storage_lims_yzq";

        public AplScan(KafkaProducer producer)
        {
            _producer = producer;
        }

        public object Get_CommMessage(string hotelId, out string comm, out string commId)
        {
            
            commId = commandId.ToString().Replace("-", "");
            comm = String.Format(msg, topic, "c37f078529e943f7927686addf928348", commId, "scan");
            var commJson = JsonConvert.DeserializeObject(comm);
            return commJson;

        }
        public async void ScanHotel(string hotelId= "c37f078529e943f7927686addf928348")
        {
            string commMsg, commId;
            var commJson = Get_CommMessage("c37f078529e943f7927686addf928348", out commMsg, out commId);
            var result = await Task.Run(() => _producer.SendMessageAsync(taskid.ToString(), topic, JsonConvert.SerializeObject(commJson)));
            taskid++;
        }






    }
}
