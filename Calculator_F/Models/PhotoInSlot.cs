using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_F.Models
{
    internal class PhotoInSlot
    {
        public int PhotoIndex { get; set; } = 0;
        public int PhotoMulti { get; set; } = 0;
        PhotoInSlot(int index, int multi)
        {
            PhotoIndex = index;
            PhotoMulti = multi;
        }
        PhotoInSlot()
        {

        }
    }
}
