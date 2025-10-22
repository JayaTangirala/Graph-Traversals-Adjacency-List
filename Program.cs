using System;
using System.ComponentModel;

namespace Traversals_List
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string fileName = "edge_list1.txt";  //Make sure that in the properties of edge_list1.txt, "Copy to Output directory" is set to "Copy as always"
            Graph G= new Graph(fileName);            
            G.printGraph();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Breadth First Traversal");
            bool[] visited = new bool[G.nodes];
            //for loop to handle disconnected Graph
            for (int i = 0; i < G.nodes; i++)
            {
                if (!visited[i])
                    G.BFT(visited,i);
            }

            Console.WriteLine();
            
            Console.WriteLine("\nDepth First Traversal");
            for (int i = 0; i < G.nodes; i++)
            {
                visited[i] = false;
            }
            //for loop to handle disconnected Graph
            for (int i = 0; i < G.nodes; i++)
            {
                if (!visited[i])
                    G.DFT(visited, i);
            }
            Console.WriteLine();
        }
    }
}