using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureFinancing
{
    class PyramidNode
    {
        public int value { get; set; }
        public PyramidNode leftChild { get; set; }
        public PyramidNode rightChild { get; set; }
        public string pathString { get; set; }
        public int sumOfChildren { get; set; }

        public PyramidNode(int value)
        {
            this.value = value;
        }
    }
}
