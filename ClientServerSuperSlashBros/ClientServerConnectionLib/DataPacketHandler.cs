using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ShareClientServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientServerConnectionLib
{
    public abstract class DataPacketHandler
    {
        public bool handlePacket(String packetJson)
        {

            dynamic jsonPacket = JsonConvert.DeserializeObject(packetJson);
            int type = jsonPacket.type;
            dynamic parameters = jsonPacket.parameters;
            

            switch (type)
            {
                case (int) DataPacketType.MESSAGE:
                    HandleMessage(parameters);
                    break;
                case (int) DataPacketType.PLAYERPOS:
                    HandlePlayerPos(parameters);
                    break;
                case (int)DataPacketType.HIT:
                    HandleHit(parameters);
                    break;
                case (int)DataPacketType.STOP_CONNECTION:
                    return HandleStop(parameters);
                default:

                    break;
            }
            return true;
        }

        public abstract bool HandleStop(dynamic parameters);

        public abstract void HandleMessage(dynamic parameters);
        public abstract void HandlePlayerPos(dynamic parameters);
        public abstract void HandleHit(dynamic parameters);



    }
}
