using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DeathMessage.Serialization
{
    [Serializable]
    public class ExpForKills
    {
        [XmlAttribute("Exp")] public uint Exp;


        public ExpForKills(uint exp)
        {
            Exp = exp;
        }

        public ExpForKills() { }


    }
}
