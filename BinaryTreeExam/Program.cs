
using BinaryTreeExam;
using System.Text.Json;
using System;

class Program
{
    static void Main(string[] args)
    {

        //NodeJson node1 = new NodeJson() { MinSeverity = 2, MaxSeverity = 3, Defenses = new List<string>() };
        //NodeJson node2 = new NodeJson() { MinSeverity = 4, MaxSeverity = 5, Defenses = new List<string>() };

        //BinarySearchTree searchTree = new BinarySearchTree();

        //searchTree.Insert(node1);
        //searchTree.Insert(node2);

        //searchTree.DisplayRoot();


        List<NodeJson> nodes = new List<NodeJson>();

        string filePath = "C:\\Users\\rn385\\OneDrive\\שולחן העבודה\\הכשרה קודקוד\\c#\\BinaryTreeExam\\BinaryTreeExam\\defenceStrategiesBalanced.json";

        using (StreamReader r = new StreamReader(filePath))
        {
            string json = r.ReadToEnd();
            nodes = JsonSerializer.Deserialize<List<NodeJson>>(json);
        }

        BinarySearchTree defenceTree = new BinarySearchTree();
        //insert nodes to tree
        //o(n)
        foreach (NodeJson node in nodes)
        {
            defenceTree.Insert(node);
            //Console.WriteLine(node.MinSeverity.ToString(), node.MaxSeverity.ToString());
        }

        defenceTree.PrintTree();
        //defenceTree.DisplayRoot();

    }
}

