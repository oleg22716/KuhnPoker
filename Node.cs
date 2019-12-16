using System.Collections.Generic;

namespace KuhnPoker
{
    internal class Node
    {
        List<Node> children;
        Node parent;
        //todo
        #region Common
        string history;
        string state;
        #endregion

        #region Properties
        public string State { get => state; set => state = value; }
        public string History { get => history; set => history = value; }
        internal List<Node> Children { get => children; set => children = value; }
        internal Node Parent { get => parent; set => parent = value; }
        #endregion

        #region Constructors
        internal Node(Node parent)
        {
            if (parent == null)
            {
                History = "";
                State = "";
                this.Parent = parent;
                this.children = new List<Node>();
            }

        }

        internal Node(Node parent, string history, string state)
        {
            this.History = history;
            this.State = state;
            this.Parent = parent;
            this.children = new List<Node>();
        }


        #endregion

        internal void AddChild(Node child)
        {
            Children.Add(child);
        }

        public override string ToString()
        {
            return string.Format("History: \"{0}\", State: \"{1}\", has {2} children",
                History,State,Children.Count);
        }
    }
}