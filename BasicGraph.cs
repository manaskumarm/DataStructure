using System.Text;

namespace GraphDataStructureInC_Sharp
{    
    class BasicGraph
    {

        #region private variables
        //This class represents a Directed Graph Implementation using LinkedList private variables
        private int totalVertices; // No. of vertices
        private LinkedList<int>[] linkedListArray;
        #endregion

        // Constructor
        public BasicGraph(int n)
        {
            totalVertices = n;
            linkedListArray = new LinkedList<int>[n];
            for (int i = 0; i < n; i++)
                linkedListArray[i] = new LinkedList<int>();
        }

        // Function to add an edge using adjacent vertex
        public void addEdge(int vertex, int adVertex)
        {
            linkedListArray[vertex].AddLast(adVertex);
        }     
        
        // Function to PrintAdjanceyList
        public void PrintAdjanceyList()
        {
            Console.WriteLine("================================================\n");
            Console.WriteLine("Graph Representation\n");
            Console.WriteLine("================================================\n");
            Console.WriteLine("The Graph Adjacency List Representation:\n");
            Console.WriteLine("------------------------------------------------\n");
            StringBuilder nodeString = new StringBuilder();
            //Taversing over each of the vertices - Printing the vertices
            for (int i = 0; i < linkedListArray.Length; i++)
            {                
                nodeString.Append("[Node Value: " + i + " with Neighbors");
                foreach (var item in linkedListArray[i])
                {
                    nodeString.Append(" -> " + item);
                }
                nodeString.Append(" ]\n"); 
            }
            Console.WriteLine(nodeString.ToString());
        }

        // Function to CreateAdjanceyMatrix
        public void CreateAdjanceyMatrix(BasicGraph graph)
        {  
            
            int?[,] adjanceyMatrix = new int?[graph.totalVertices, graph.totalVertices];

            for (int parentVertex = 0; parentVertex < graph.totalVertices; parentVertex++)
            {
                var parentNode = linkedListArray[parentVertex];

                for (int childNode = 0; childNode < graph.totalVertices; childNode++)
                {  
                    if (parentVertex != childNode)
                    {
                        var arc = parentNode.Find(childNode);

                        if (arc != null)
                        {
                            adjanceyMatrix[parentVertex, childNode] = 1;
                        }
                    }                    
                }
            }

            PrintAdjanceyMatrix(adjanceyMatrix, graph.totalVertices);
        }
        
        // Function to PrintAdjanceyMatrix
        public void PrintAdjanceyMatrix(int?[,] adjanceyMatrix, int Count)
        {
            Console.WriteLine("================================================\n");
            Console.WriteLine("The Graph Adjacency Matrix Representation:\n");
            Console.WriteLine("------------------------------------------------\n");
            Console.WriteLine("Nodes  ");
            for (int i = 0; i < Count; i++)
            {
                Console.WriteLine(string.Format("{0}  ", i));
            }

            Console.WriteLine("\n");

            for (int i = 0; i < Count; i++)
            {
                Console.WriteLine(string.Format("{0} | [ ", i));

                for (int j = 0; j < Count; j++)
                {
                    if (i == j)
                    {
                        Console.WriteLine(" x ");
                    }
                    else if (adjanceyMatrix[i, j] == null)
                    {
                        Console.WriteLine(" . ");
                    }
                    else
                    {
                        Console.WriteLine(string.Format(" {0} ", adjanceyMatrix[i, j]));
                    }

                }
                Console.WriteLine(" ]\r\n");
            }
            Console.WriteLine("================================================\n");
        }        
    }
}

