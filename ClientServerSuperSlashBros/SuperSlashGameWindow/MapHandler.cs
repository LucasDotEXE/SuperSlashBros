using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperSLashWPF.Map;

namespace SuperSLashWPF
{
    class MapHandler
    {
        private Map.Map map;
        public MapHandler()
        {
            map = new Map.Map();
        }

        public Map.Map GetMap() {
            return this.map;
        }

    }
}
