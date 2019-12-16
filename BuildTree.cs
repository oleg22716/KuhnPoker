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
        private int CardToNumber(char card) {
            if (card == 'J') return 0;
            if (card == 'Q') return 1;
            if (card == 'K') return 2;
            return -1;

        }
        private int Payout1(Node node)//from player 1's perspective
        {
            if (!IsTerminal(node)) {
                return 0;
            }
            string state = node.State;
            int firstCard=CardToNumber(state[0]);
            int secondCard=CardToNumber(state[1]);//todo assert/validation
            int firstPot=1;//ante
            int secondPot=1;//ante
            if (state[4] == 'B') { secondPot += 1; }
            if (state.Length == 5)
            {
                if (state[5] == 'B') firstPot += 1;
            }
            else if (state[3] == 'B') firstPot += 1;

            if (firstCard > secondCard) return secondPot;
            else return -firstPot;

        }
        private bool IsTerminal(Node node) {
            if (node.Children.Count == 0) return true;
            return false;
        }
        private void Build(Node root) {
            
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
