using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BinaryTreeExam
{
    internal class BinarySearchTree
    {
        private Node Root;

        public BinarySearchTree()
        {
            Root = null;
        }

        public void Insert(NodeJson data)
        {
            Root = RecursiveInsert(Root, data);
        }

        //o(log(n))
        private Node RecursiveInsert(Node node, NodeJson data)
        {
            if (node == null)
            {
                node = new Node(data);
                return node;
            }
            if (data.MinSeverity < node.MinSeverity)
            {
                node.Left = RecursiveInsert(node.Left, data);
            }
            else
            {
                node.Right = RecursiveInsert(node.Right, data);
            }
            return node;

        }


        public void PrintTree()
        {
            //Console.WriteLine($"Root: [{Root.MinSeverity}-{Root.MaxSeverity}] Defenses: {Root.Defenses[0]}, {Root.Defenses[1]}");
            PrintTree(Root, "", true);
        }
        private void PrintTree(Node node, string indent, bool last)
        {
            if (node != null)
            {
                Console.Write(indent);
                if (last)
                {
                    Console.Write("Right ");
                    indent += "   ";
                }
                else
                {
                    Console.Write("Left ");
                    indent += "|----";
                }
                Console.WriteLine($"Child: [{node.MinSeverity}-{node.MaxSeverity}] Defenses: {node.Defenses[0]}, {node.Defenses[1]}");

                //Console.WriteLine();
                PrintTree(node.Left, indent, false);
                PrintTree(node.Right, indent, true);
            }
        }          
    }
}
