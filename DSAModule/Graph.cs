namespace DSA.DSAModule;

class Graph
{
    private Dictionary<int, List<int>> adjacencyList;

    public Graph()
    {
        adjacencyList = new Dictionary<int, List<int>>();
    }

    public void AddNode(int node)
    {
        if (!adjacencyList.ContainsKey(node))
        {
            adjacencyList[node] = new List<int>();
        }
    }

    public void AddEdge(int source, int destination)
    {
        if (!adjacencyList.ContainsKey(source) || !adjacencyList.ContainsKey(destination))
        {
            throw new ArgumentException("Source and destination nodes must exist in the graph.");
        }

        adjacencyList[source].Add(destination);
        adjacencyList[destination].Add(source);
    }

    public void PrintGraph()
    {
        foreach (var node in adjacencyList)
        {
            Console.Write(node.Key + " -> ");
            foreach (var neighbor in node.Value)
            {
                Console.Write(neighbor + " -> ");
            }
            Console.WriteLine();
        }
    }
}
