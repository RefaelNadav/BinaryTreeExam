
using BinaryTreeExam;
using System.Text.Json;
using System;
using System.Runtime.CompilerServices;
using System.Threading;

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

        //defenceTree.PrintTree();
        //defenceTree.DisplayRoot();

        List<Threat> threats = new List<Threat>();

        string fileThreatsPath = "C:\\Users\\rn385\\OneDrive\\שולחן העבודה\\הכשרה קודקוד\\c#\\BinaryTreeExam\\BinaryTreeExam\\threats.json";

        using (StreamReader r = new StreamReader(fileThreatsPath))
        {
            string json = r.ReadToEnd();
            threats = JsonSerializer.Deserialize<List<Threat>>(json);
        }
        //Console.WriteLine(threats.Count.ToString());

        int CalculateSeverity(Threat threat)
        {
            int targetValue;

            switch (threat.Target)
            {
                case "Web Server":
                    targetValue = 10;
                    break;

                case "Database":
                    targetValue = 15;
                    break;

                case "User Credentials":
                    targetValue = 20;
                    break;

                default:
                    targetValue = 5; 
                    break;
            }
                
            int severity = (threat.Volume * threat.Sophistication) + targetValue;

            return severity;
        }

        foreach (var item in threats)
        {
            int severity = CalculateSeverity(item);
            Console.WriteLine($"Attac: {item.ThreatType}");
            defenceTree.FindDefenses(severity);
        }
    }
    }

