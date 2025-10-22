using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Traversals_List
{
    internal class Graph
    {
        public int nodes, edges;
        LinkedList<int>[] adjacencyList;
        
        public Graph (string fileName)
        {                       
            if (File.Exists(fileName))
            {
                StreamReader sr = new StreamReader(File.OpenRead(fileName));
                //First line in the edge_list file contains number of nodes and edges. 
                if (!sr.EndOfStream)
                {
                    
                    string[] first_line = sr.ReadLine().Split(' ');
                    nodes = Convert.ToInt32(first_line[0]);
                    edges = Convert.ToInt32(first_line[1]);
                    adjacencyList = new LinkedList<int>[nodes];
                    for (int i = 0; i < adjacencyList.Length; ++i)                    
                        adjacencyList[i] = new LinkedList<int>();
                    
                }
                //Read the edges from second line.
                while (!sr.EndOfStream)
                {
                    string[] edge = sr.ReadLine().Split(' ');
                    int s = Convert.ToInt32(edge[0]);
                    int d = Convert.ToInt32(edge[1]);
                    adjacencyList[s].AddLast(d);
                }
            }            
        }
       
        public void printGraph()
        {
            Console.WriteLine("Adjacency List");
            int i = 0;
            foreach (LinkedList<int> list in adjacencyList)
            {
                Console.Write("adjacencyList[" + i + "] -> ");
                foreach (int edge in list)
                    Console.Write(edge + " -> ");
                ++i;
                Console.WriteLine("Null");
            }
        }
        public void BFT(bool[] visited, int v)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(v);
            visited[v] = true;
            while (queue.Count != 0)
            {
                int currentVertex = queue.Dequeue();
                Console.Write(currentVertex + " ");                
                foreach (var neighbor in adjacencyList[currentVertex])
                {
                   if (!visited[neighbor])
                   {
                        visited[neighbor]=true;
                        queue.Enqueue(neighbor);
                   }
                }                
            }
        }

        public void DFT(bool[] visited, int v)
        {
            visited[v]=true;
            Console.Write(v + " ");
            foreach (var neighbor in adjacencyList[v])
            {
                if (!visited[neighbor])
                    DFT(visited, neighbor);
            }
        }
    }
}
