using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmCS.DataStructure
{
    /// <summary>
    /// Directed Graph
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Graph<T>
    {
        List<List<Edge<T>>> _graph = new List<List<Edge<T>>>();
        readonly int _size;
        public Graph(int n)
        {
            _size = n;
            _graph = new List<List<Edge<T>>>();
            for (int i = 0; i < n; i++) _graph.Add(new List<Edge<T>>());
        }

        public void AddEdge(int to, int from, T cost)
        {
            _graph[to].Add(new Edge<T>(to, from, cost));
        }
    }

    /// <summary>
    /// Edge
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class Edge<T>
    {
        public Edge(int to, int from, T cost)
        {
            this.Cost = cost;
            this.To = to;
            this.From = from;
        }
        public int To { get; set; }
        public int From { get; set; }
        public T Cost { get; set; }
    }
}
