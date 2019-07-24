using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    class Room
    {
        private int Number;
        public Room(int number)
        {
            Number = number;
        }

        public int GetNumber()
        {
            return Number;
        }

        public void SetNumber(int number)
        {
            Number = number;
        }
    }
}
