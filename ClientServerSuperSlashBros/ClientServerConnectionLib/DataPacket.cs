using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShareClientServer
{
    public class DataPacket
    {
        public DataPacketType type;

        public Dictionary<String, dynamic> parameters;

        public DataPacket(DataPacketType type)
        {
            this.type = type;
            this.parameters = new Dictionary<string, dynamic>();
        }

        public void clearParams()
        {
            this.parameters = new Dictionary<string, dynamic>();
        }

        public void addParam(String paramName, dynamic value)
        {
            this.parameters.Add(paramName, value);
        }


        public Dictionary<string, dynamic> getParameters()
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
        MESSAGE, PLAYERPOS, HIT, STOP_CONNECTION
    }
}
