using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuhnPoker
{
    internal class KuhnNode : Node
    {
        #region Types
        internal enum Type { Chance1, Chance2, Terminal, Player1, Player2, NotAssigned }
        #endregion
        #region Fields
        internal Type type;
        string history;
        private char[] argHistory;

        //protected KuhnNode[] children;
        public KuhnNode[] children;

        //protected KuhnNode parent;
        internal KuhnNode parent;//debug

        #endregion
        #region Properties
        public string History { get => history; set => SetHistory(); }
        public char[] ArgHistory { get => argHistory; set => SetArgs(); }
        #endregion

        #region Constructors
        internal KuhnNode(KuhnNode parent)
        {
            this.parent = parent;
            this.History = "Setter calls SetHistory() regardless";
            this.type = GetMyType();
            uint number = GetNumberOfLeaves(type);
            SetArgs();
            //this.ArgHistory = parent.ArgHistory;
            //this.ArgHistory[number] = GetArg();

            children = new KuhnNode[number];
            for (int i = 0; i < number; i++)
            {
                children[i] = new KuhnNode(this);
            }



        }


        #endregion
        #region Methods
        private void SetHistoryOld()
        {
            string history;
            if (parent == null)
            {
                history = "r";
                this.history = history;
                return;
            }
            history = parent.History;
            if (history == "r") history += "r";
            //else if (this.Equals(parent.children[0])) history += "c";
            else if (this == parent.children[0]) history += "c";
            else history += "b";
            this.history = history;


        }
        private void SetHistory()
        {
            string history;
            if (parent == null)
            {
                history = "";
                this.history = history;
                return;
            }
            history = parent.History;
            //Console.WriteLine("Parent history {0}", history);
            if (history == "" || history == "r") history += "r";
            else if (this.Equals(parent.children[0])) history += "c";
            //else if (this == parent.children[0]) history += "c";
            else history += "b";

            Console.WriteLine("End of SetHistory. history={0}, ", history);//debug
            this.history = history;
        }

        private Type GetMyType()
        {
            if (this.parent == null)
                return Type.Chance1;
            if (this.parent.type == Type.Chance1)
                return Type.Chance2;
            if (this.parent.type == Type.Chance2)
                return Type.Player1;
            if (this.parent.type == Type.Player1)
            {
                if (this.parent.History.Length < 2)//history = "r"
                    return Type.Player2;
                else return Type.Terminal;
            }
            if (this.parent.type == Type.Player2)
            {
                if (History == "rrcb")
                    return Type.Player1;
                else return Type.Terminal;
            }
            else return Type.NotAssigned;
        }
        private uint GetNumberOfLeaves(Type type)
        {
            if (type == Type.Chance1)
            {
                return 3;//3 cards
            }

            if (type == Type.Terminal)
            {
                return 0;
            }
            //todo: validate/assert
            return 2;
        }
        private void SetArgsOld()
        {
            int len;
         
            if (this.parent == null)
            {
                len = 1;

            }
            else
            {
                len = parent.argHistory.Length;
            }
                
            char[] arr = new char[len + 1];
            arr[len] = GetArg();
            if (this.parent == null) {
                argHistory = arr;
                
                return; }

                for (int i = 0; i < parent.ArgHistory.Length; i++)
                {
                    arr[i] = parent.ArgHistory[i];
                }
            argHistory = arr;
        }
        private void SetArgs() {
            int len = 0;
            char[] args;
            if (this.parent == null) {
                args = new char[1];
                args[0] = 'a';
                argHistory = args;
                return;
            }
            len = parent.ArgHistory.Length + 1;
            args = new char[len];
            for (int i = 0; i < parent.ArgHistory.Length; i++)
            {
                args[i] = parent.ArgHistory[i];
            }
            args[len - 1] = GetArg();
            argHistory = args;
        }
        private char LowCard(char card)
        {
            if (card == 'J') return 'Q';
            if (card == 'Q') return 'J';
            if (card == 'K') return 'J';
            return '0';
        }
        private char HighCard(char card)
        {
            if (card == 'J') return 'K';
            if (card == 'Q') return 'K';
            if (card == 'K') return 'Q';
            return '0';
        }
        private char GetArg()
        {
            if (this.type == Type.Chance1)
            {
                return 'a';//antes
            }
            if (type == Type.Chance2)
            {
                if (this == parent.children[0]) return 'J';//jack
                if (this == parent.children[1]) return 'Q';//Queen
                if (this == parent.children[2]) return 'K';//King
            }
            if (history.Length == 1)
            {//history r, parent.arghistory contains one card
                if (this == parent.children[0]) //todo: add enum cards and loop through it
                    return LowCard(parent.GetLastArg());
                else return HighCard(parent.GetLastArg());
            }
            else {
                Console.WriteLine(this == parent.children[0]);
                if (this == parent.children[0]) return 'c';
                else return 'b';
            }






        }
        internal char GetLastArg() { return argHistory[argHistory.Length - 1]; }
        internal char GetArg(int number) { return argHistory[number]; }
        internal KuhnNode GetChild(int number) { return this.children[number]; }

        public override string ToString()
        {
            string retValue = String.Format(
                "Node has {0} children, its history is {1}, Type is {2}, arghistory is {3}",
                children.Length, History, type, string.Join("",argHistory));
            return retValue;
        }
        #endregion

    }
}
