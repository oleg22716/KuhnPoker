using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuhnPoker
{
    public class Poker
    {
        public enum Cards
        {
            Jack,
            Queen,
            King
        }
        public enum Actions
        {
            Check,
            Raise,
            Fold,
            Call
        }

        public int ranks;
        public int suits;
        public int players;
        public int ante;
        public int pot;
        public int bettingRounds;
        public bool suitsEnabled;
        Poker()
        {
            suitsEnabled = false;
            ranks = Enum.GetNames(typeof(Cards)).Length;
            ante = 1;
            bettingRounds = 1;
            players = 2;
            pot = players * ante;

        }
    }
    class TreeNode<T>
    {


        public List<TreeNode<T>> Children = new List<TreeNode<T>>();
        T Item { get; set; }
        public TreeNode(T item)
        {
            Item = item;
        }
        public TreeNode<T> AddChild(T item)
        {
            TreeNode<T> nodeItem = new TreeNode<T>(item);
            Children.Add(nodeItem);
            return nodeItem;
        }

        public bool hasChildren = false;
        public void PrintTree()
        {

        }
    }
    public class Tree {
        public enum TraverseNodeStatus
        {
            Unvisited,
            Visited,
            Done

        }
    }
    class Program
    {
        static void Main(string[] args)
        {


        }



        public void dft(TreeNode<int> node)
        {
            Tree.TraverseNodeStatus thisNodeStatus = Tree.TraverseNodeStatus.Visited;
            if (node.hasChildren)
            {
                foreach (var child in node.Children)
                {
                    dft(child);
                }

            }
            else
            {

            }
            thisNodeStatus = Tree.TraverseNodeStatus.Done;

        }

        public void traverse(string history, string node_type) {
            string updated_history = history + node_type;

        }


        public void build_kuhn_tree() {
            TreeNode root = new KuhnPoker.TreeNode();
        }
    }
    //todo: betting rounds, number of cards, number of players

}


/*
 Continues action space..
 https://www.youtube.com/watch?v=kWHSH2HgbNQ

     exploit vs explore



    Inspiring stuff
     https://www.youtube.com/watch?v=lEOOZDbMrgE&list=PL-3Jw4xpRU4yxOBoFJxPJ55Nb5XiVrAeG
     https://visme.co/blog/7-storytelling-techniques-used-by-the-most-inspiring-ted-presenters/



    Counterfactual regret minimization papers
    https://pdfs.semanticscholar.org/0184/855c7baafdbcadcab967d4bfa7d4f8b86285.pdf

    Human behaviour simulation
    https://repositorio-aberto.up.pt/bitstream/10216/85156/2/139546.pdf

    game tree
    https://en.wikipedia.org/wiki/Game_tree
     */
