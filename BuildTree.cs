using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuhnPoker
{
    class Tree
    {
        Node root;

        public Tree() {
        root = new Node(null);
            Build(root);
        }

        internal void Build(Node root) {
            
            while (AddChild(root)) { }
            foreach (Node leaf in root.Children)
                Build(leaf);
            


        }
        bool AddChild(Node parent) {
            Node toAdd;
            int count = parent.Children.Count;
            string historyAddition = "";
            string arg = EventDict.GetArg(parent.State,count);
            if (arg == "N")//something went wrong, could not be added
            {
                Console.WriteLine("This {0} node can not have additional children",parent.ToString());
                return false;
            }
            if (arg == "J" || arg == "Q" || arg == "K")
                historyAddition = "r";
            else historyAddition = arg.ToLower();
            toAdd = new Node(parent, parent.History + historyAddition, parent.State + arg);
            parent.AddChild(toAdd);
            return true;
        }
        
        string GetArg(Node node) {
            if (node.Parent == null) return "";
            return "";
        }
        string GetNodeType(Node node) {
            if (node.Parent == null) return "r";
            return "";
        }
    }
}
