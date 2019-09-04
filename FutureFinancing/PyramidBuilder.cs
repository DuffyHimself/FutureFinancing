using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureFinancing
{
    class PyramidBuilder
    {
        private string Input { get; set; }
        private List<List<int>> IntScaffold { get; set; }
        //Used for looking up already created nodes
        private List<List<PyramidNode>> Pyramid { get; set; }

        public PyramidBuilder(string input)
        {
            this.Input = input;
        }

        internal void BuildIntScaffold()
        {
            IntScaffold = new List<List<int>>();
            Pyramid = new List<List<PyramidNode>>();
            string[] rows = Input.Split('\n');
            for (int i = 0; i < rows.Length - 1; i++)
            {
                IntScaffold.Add(new List<int>());
                Pyramid.Add(new List<PyramidNode>());
                string[] columns = rows[i].Split(' ');
                for (int j = 0; j < columns.Length; j++)
                {
                    IntScaffold[i].Add(int.Parse(columns[j]));
                }
            }
        }

        internal PyramidNode BuildPyramid()
        {
            PyramidNode root = GenerateNode(0, 0);
            return root;
        }

        private PyramidNode GenerateNode(int row, int col)
        {
            int nodeValue = IntScaffold[row][col];
            PyramidNode newNode = new PyramidNode(nodeValue);
            
            if(IntScaffold.Count > row + 1)
            {
                //Node has children
                //Add children
                if(col == 0)
                {
                    newNode.leftChild = GenerateNode(row + 1, col);
                    Pyramid[row + 1].Add(newNode.leftChild);
                }
                else
                {
                    //The child was already created by the previous node
                    newNode.leftChild = Pyramid[row + 1][col];
                }
                newNode.rightChild = GenerateNode(row + 1, col + 1);
                Pyramid[row + 1].Add(newNode.rightChild);

                //Find the child node with different modulo 2 and highest path value
                if (nodeValue % 2 != newNode.leftChild.value % 2)
                {
                    if (nodeValue % 2 != newNode.rightChild.value % 2)
                    {
                        //Both children have different modulo 2
                        if((newNode.leftChild.value + newNode.leftChild.sumOfChildren ) > (newNode.rightChild.value + newNode.rightChild.sumOfChildren))
                        {
                            newNode.sumOfChildren = newNode.leftChild.value + newNode.leftChild.sumOfChildren;
                            newNode.pathString += newNode.value + " " + newNode.leftChild.pathString;
                        }
                        else
                        {
                            newNode.sumOfChildren = newNode.rightChild.value + newNode.rightChild.sumOfChildren;
                            newNode.pathString += newNode.value + " " + newNode.rightChild.pathString;
                        }
                    }
                    else
                    {
                        //Only left child has different modulo 2
                        newNode.sumOfChildren = newNode.leftChild.value + newNode.leftChild.sumOfChildren;
                        newNode.pathString += newNode.value + " " + newNode.leftChild.pathString;
                    }
                }
                else if (nodeValue % 2 != newNode.rightChild.value % 2)
                {
                    //Only right child has different modulo 2
                    newNode.sumOfChildren = newNode.rightChild.value + newNode.rightChild.sumOfChildren;
                    newNode.pathString += newNode.value + " " + newNode.rightChild.pathString;
                }
                else
                {
                    //No children with different modulo 2
                    newNode.sumOfChildren = 0;
                    newNode.pathString = newNode.value.ToString();
                }
            }
            else
            {
                //Stop at bottom of pyramid
                newNode.sumOfChildren = 0;
                newNode.pathString = newNode.value.ToString();
            }
            
            return newNode;
        }
    }
}
