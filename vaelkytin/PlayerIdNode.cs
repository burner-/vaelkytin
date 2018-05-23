using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSGSI.Nodes;

namespace vaelkytin
{
    class PlayerIdNode
    {
        public string Name;
        public string SteamID;

        public PlayerIdNode(PlayerNode node)
        {
            this.Name = node.Name;
            this.SteamID = node.SteamID;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
