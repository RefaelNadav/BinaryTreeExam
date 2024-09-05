using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void DisplayRoot()
        {
            if(Root != null)
            {
                Console.WriteLine($"min: {Root.Right.MinSeverity}, max: {Root.Right.MaxSeverity}, Defenses: {Root.Defenses.Count().ToString()}");
            }
        }
    }
}
