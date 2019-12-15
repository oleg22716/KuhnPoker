using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuhnPoker
{
    internal class KuhnNode:Node
    {
        #region Types
        internal enum Type { Chance1, Chance2, Terminal, Player1, Player2, NotAssigned }
        #endregion
        #region Fields
        internal Type type;
        string history;

        protected KuhnNode[] children;

        protected KuhnNode parrent;

        #endregion
        #region Properties
        public string History { get => history; set => SetHistory(); }
        #endregion
        #region Constructors
        internal KuhnNode(KuhnNode parrent)
        {
            this.parrent = parrent;
            this.type = GetMyType();
            uint number = GetNumberOfLeaves(type);
            this.History = "Setter calls SetHistory() regardless";

            children = new KuhnNode[number];
            for (int i = 0; i < number; i++)
            {
                children[i] = new KuhnNode(this);
            }



        }

    
    #endregion
    #region Methods
    private void SetHistory()
        {
            string history;
            if (parrent == null)
            {
                history = "r";
                this.history = history;
                return;
            }
            history = parrent.History;
            if (history == "r") history += "r";
            else if(this==parrent.children[0]) history += "c"; 
            else history += "b";
            this.history = history;


        }

        private Type GetMyType()
        {
            if (this.parrent == null)
                return Type.Chance1;
            if (this.parrent.type == Type.Chance1)
                return Type.Chance2;
            if (this.parrent.type == Type.Chance2)
                return Type.Player1;
            if (this.parrent.type == Type.Player1)
            {
                if (this.parrent.History.Length < 3) return Type.Player2;
                else return Type.Terminal;
            }
            if (this.parrent.type == Type.Player2)
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
        internal KuhnNode GetChild(int number) { return this.children[number]; }
        public override string ToString()
        {
            string retValue = String.Format("Node has {0} children, its history is {1}, Type is {2}", children.Length,History, type);
            return retValue;
        }
        #endregion

    }
}
