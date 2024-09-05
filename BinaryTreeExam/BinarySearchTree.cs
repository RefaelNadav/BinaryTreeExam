using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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

        //o(n)
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

        public void FindDefenses(int severity)
        {
            int? minSeverity = GetMin();

            if(severity < minSeverity)
            {
                Console.WriteLine("Attack severity is below the threshold. Attack is ignored");
            }
            Node defenses = FindDefensesRecursive(Root, severity);
            if (defenses == null)
            {
                Console.WriteLine("No suitable defence was found!. Brace for impact");
            }
            else
            {
                Console.WriteLine(defenses.Defenses[0]);
                Thread.Sleep(2000);
                Console.WriteLine(defenses.Defenses[1]);
            }
        }

        //o(n)
        private static Node FindDefensesRecursive(Node node, int severity)
        {
            if (node == null)
            {
                return null;
            }

            if (node.MinSeverity > severity)
            {
                return FindDefensesRecursive(node.Left, severity);
            }
            else if (node.MaxSeverity < severity) 
            {               
                return FindDefensesRecursive(node.Right, severity);
            }
            else if (node.MinSeverity <= severity && node.MaxSeverity >= severity)
            {
                return node;
            }

            else
            {
                return null;
            }

        }

        public int? GetMin()
        {
            if (Root == null)
            {
                return null;
            }

            Node curr = Root;
            while (curr.Left != null)
            {
                curr = curr.Left;
            }
            return curr.MinSeverity;
        }

    }
}
