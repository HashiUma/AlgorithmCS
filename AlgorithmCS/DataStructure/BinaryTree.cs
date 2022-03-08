using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmCS.DataStructure
{
    public class BinaryTree<T> where T : IComparable<T>
    {
        public Node<T> Root;

        public BinaryTree() { }

        public void Insert(T k)
        {
            Node<T> x = Root;
            Node<T> y = null;
            Node<T> z = new Node<T>(k);

            while (x != null)
            {
                y = x;
                if (z._key.CompareTo(x._key) < 0) x = x._left;
                else x = x._right;
            }
            z._parent = y;
            if (y == null) Root = z;
            else
            {
                if (z._key.CompareTo(y._key) < 0) y._left = z;
                else y._right = z;
            }
        }

        public void InOrder() { _inOrder(Root); }
        public void PreOrder() { _preOrder(Root); }

        public Node<T> Find(T k)
        {
            Node<T> x = Root;
            while (x != null && k.CompareTo(x._key) != 0)
            {
                if (k.CompareTo(x._key) < 0)
                {
                    x = x._left;
                }
                else
                {
                    x = x._right;
                }
            }

            return x;
        }

        public void DeleteNode(Node<T> z)
        {
            if (z == null) return;
            Node<T> x, y;//TargetNode
            if (z._left == null || z._right == null) y = z;
            else y = _getSuccessor(z);

            if (y._left != null) x = y._left;
            else x = y._right;

            if (x != null) x._parent = y._parent;

            if (y._parent == null) Root = x;
            else if (y == y._parent._left) y._parent._left = x;
            else y._parent._right = x;

            if (y != z)
            {
                z._key = y._key;
            }
        }

        private Node<T> _getSuccessor(Node<T> x)
        {
            if (x._right != null) return _getMinimum(x._right);

            Node<T> y = x._parent;
            while (y != null && x == y._right)
            {
                x = y;
                y = y._parent;
            }
            return y;
        }

        private Node<T> _getMinimum(Node<T> x)
        {
            while (x._left != null)
            {
                x = x._left;
            }
            return x;
        }

        private void _inOrder(Node<T> u)
        {
            if (u == null) return;
            _inOrder(u._left);
            Console.Write(" " + u._key);
            _inOrder(u._right);
        }

        private void _preOrder(Node<T> u)
        {
            if (u == null) return;
            Console.Write(" " + u._key);
            _preOrder(u._left);
            _preOrder(u._right);
        }

    }

    public class Node<T> where T : IComparable<T>
    {
        public Node(T k) { _key = k; }
        public T _key { get; set; }
        public Node<T> _right { get; set; }
        public Node<T> _left { get; set; }
        public Node<T> _parent { get; set; }
    }
}
