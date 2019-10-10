using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShareClientServer
{
    public class DataPacket
    {
        public DataPacketType type;

        private List<Tuple<String, dynamic>> parameters;

        public DataPacket(DataPacketType type)
        {
            this.type = type;
            this.parameters = new List<Tuple<string, dynamic>>();
        }

        public void clearParams()
        {
            this.parameters = new List<Tuple<string, dynamic>>();
        }

        public void addParam(Tuple<String, dynamic> param)
        {
            this.parameters.Add(param);
        }


        public List<Tuple<string, dynamic>> getParameters()
        {
            return this.parameters;
        }

        public String getProtocolJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public DataPacket returnProtocolFormJson(String json)
        {
            return JsonConvert.DeserializeObject(json) as DataPacket;
        }
    }

    public enum DataPacketType
    {
        MESSAGE, PLAYERPOS, HIT
    }
}
