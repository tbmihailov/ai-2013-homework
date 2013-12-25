using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.Graphs
{
    public class Node<T> where T : struct
    {

        private T _value;
        public T Value
        {
            get { return _value; }
            set { _value = value; }
        }

        private List<Node<T>> _children;
        public List<Node<T>> Children
        {
            get { return _children; }
        }

        private bool _isProcessed;
        public bool IsProcessed
        {
            get { return _isProcessed; }
            set { _isProcessed = value; }
        }
        
        public Node(T value, params Node<T>[] children)
        {
            this._value = value;
            
            this._children = new List<Node<T>>();
            this._children.AddRange(children);
        }
    }
}
