using System;
using System.Collections.Generic;
using System.Text;

namespace ShareClientServer
{
    class Protocol
    {
        String type;
        List<Tuple<String, dynamic>> parameters;

        public Protocol(string type)
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
    }
}
