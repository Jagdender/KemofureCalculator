using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_F.Models
{
    public class Photo
    {
        public string Name { get; set; }
        public int ID { get; set; }

        public int IndexDmg { get; set; }
        public int IndexDef { get; set; }
        public int IndexHP { get; set; }
        public short MultiDmg { get; set; }
        public short MultiDef { get; set; }
        public short MultiHP { get; set; }

        public Photo(int indexDmg, int indexDef, int indexHP)
        {
            IndexDmg = indexDmg;
            IndexDef = indexDef;
            IndexHP = indexHP;
        }
    }
}
