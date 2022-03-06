namespace AlgorithmCS
{
    public class UnionFindTree
    {
        private int[] _rank { get; set; }
        private int[] _parent { get; set; }

        public UnionFindTree() { }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="size"></param>
        public UnionFindTree(int size)
        {
            _rank = new int[size];
            _parent = new int[size];
            for (int i = 0; i < size; i++) _makeSet(i);

        }
        public bool Same(int x, int y) => _findSet(x) == _findSet(y);

        public void Unite(int x, int y)
        {
            _link(_findSet(x), _findSet(y));
        }

        private void _makeSet(int x)
        {
            _parent[x] = x;
            _rank[x] = 0;
        }

        private int _findSet(int x)
        {
            int p = x;
            while (p != _parent[p])
            {
                p = _parent[p];
            }
            return p;
        }

        private void _link(int x, int y)
        {
            if (_rank[x] > _rank[y])
            {
                _parent[y] = x;

            }
            else
            {
                _parent[x] = y;
                if (_rank[x] == _rank[y]) _rank[y]++;
            }
        }
    }
}