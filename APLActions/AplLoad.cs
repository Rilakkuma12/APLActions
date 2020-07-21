using System;
using System.Collections.Generic;
using System.Text;
using APLActions.Models;
using APLKafka.kafka;
using BlazorApp1.Data;


namespace APLActions
{
    // 上料相关逻辑
    public class AplLoad
    {
        //private string _msg = @"{{
        //    ""message_id"": ""UUID"",
        //    ""message_type"": ""command"",
        //    ""message_group"": ""{0}"",
        //    ""message_content"": {{
        //        ""task_id"": ""{1}"",
        //        ""device_id"": ""{2}"",
        //        ""command_id"": ""{3}"",
        //        ""command"": ""load"",
        //        ""parameters"": {{
        //            ""inputs"": []
        //        }}
        //    }}
        //}}";
        //private string _msgInput = @"{{
        //    ""material"": ""{0}"",
        //    ""position"": ""{1}"", 
        //    ""barcode"": ""{3}"", 
        //    ""device_type"": ""{4}"", 
        //    ""device_id"": ""{5}"",
        //    ""location"": """", 
        //    ""rack_idx"": ""{6}"", 
        //    ""rack_id"": ""{7}"",
        //    ""level_idx"": ""{8}"",
        //    ""sealing"": ""{9}"", 
        //    ""tearing"": ""{10}"", 
        //    ""centrifuge"": ""{11}"", 
        //    ""centrifuge_pn"": ""{12}"",
        //    ""idx"": {13:G}
        //}}";
        private LoadMsgModel _loadMsgModel;
        private LoadInputsModel _inputsModel;
        private KafkaProducer _producer;
        private KafkaConsumer _consumer;
        private int _turn;
      
        public AplLoad(KafkaProducer producer, KafkaConsumer consumer)
        {
            _producer = producer;
            _consumer = consumer;
        }
        public void LoadAll(string dest, ulong taskId, LoadModel kwargs)
        {
            /// 获取input数据
            /// 组合，发送消息
            /// 等待响应返回
            /// 循环数清零
            GetInputMsg(kwargs);
            SendLoadMsg();
            _turn = 0;
        }
        public void GetInputMsg(LoadModel kwargs)
        {
            Dictionary<string, Dictionary<string, string>> load = kwargs.Load;
            foreach (KeyValuePair<string, Dictionary<string, string>> materialList in load)
            {
                _inputsModel.Material = materialList.Key;
                foreach (KeyValuePair<string, string> posList in materialList.Value)
                {
                    _inputsModel.Position = posList.Key;
                    GetParamList(posList.Value, out string area, out string src, out string location,
            out bool? sealing, out bool? tear, out bool? centrifuge, out string centrifugePn);
                    
                    if (src == "hotel")
                    {
                        /// 从冰箱上料
                        //FindGoodsFromHotel();
                    }
                }
            }
        }
        public void SendLoadMsg()
        {

        }

        public void GetParamList(string paramLists, out string area, out string src, out string location,
            out bool? sealing, out bool? tear, out bool? centrifuge, out string centrifugePn)
        {
            string[] paramList = paramLists.Split(":");
            area = paramList[0];
            src = paramList[1];
            location = paramList[2];
            sealing = Convert.ToBoolean(paramList[3]);
            tear = Convert.ToBoolean(paramList[4]);
            centrifuge = Convert.ToBoolean(paramList[5]);
            centrifugePn = paramList[6];
        }
        public void FindGoodsFromHotel(string pn, bool isPre, bool isFridge)
        {

        }
        public void GetHotelStore()
        {
            var msg = _consumer.ReceiveMessageAsync("storage_apl_yzq");
        }

    }
}
