using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisModel2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ьailCarrier = new MailCarrier();

            ьailCarrier.Execute();
        }
    }

    public class MailCarrier
    {
        public void Execute()
        {
            int vertexCount;
            int[,] adjacencyMatrix;

            try
            {
                StreamReader reader = new StreamReader("C:/Users/admin/Desktop/DM/files/dm2.txt");
                string dimension = reader.ReadLine();
                vertexCount = int.Parse(dimension);
                adjacencyMatrix = new int[vertexCount, vertexCount];

                for (int i = 0; i < vertexCount; i++)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(' ');
                    for (int j = 0; j < vertexCount; j++)
                    {
                        adjacencyMatrix[i, j] = int.Parse(values[j]);
                    }
                }
                reader.Close();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            bool[] visited = new bool[vertexCount];
            int pathLength = 0;

            void DepthFirstSearch(int u)
            {
                visited[u] = true;

                for (int v = 0; v < vertexCount; v++)
                {
                    if (adjacencyMatrix[u, v] != 0 && !visited[v])
                    {
                        pathLength += adjacencyMatrix[u, v];
                        DepthFirstSearch(v);
                    }
                }
            }

            DepthFirstSearch(0);

            for (int i = 0; i < vertexCount; i++)
            {
                if (!visited[i])
                {
                    Console.WriteLine("Not found");
                    return;
                }
            }

            Console.WriteLine("Shortest path: " + pathLength);
        }
    }
}