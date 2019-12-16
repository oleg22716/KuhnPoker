using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuhnPoker
{

    internal class Event {
        public enum EventType { Player, Chance, Terminal }
        string name;
        string[] children;
        string historyToAdd;
        Func<string, string, string[]> getChildrenByHistory;//history, arg. returns  
        public string Name { get => name; private set => name = value; }
        public string[] Children { get => children;private set => children = value; }
        public string HistoryToAdd { get => historyToAdd; private set => historyToAdd = value; }

        internal Event(string name, string[] children,string history) {
            this.Name = name;
            this.Children = children;
            this.HistoryToAdd = history;
        }

    }
    internal class ProtoEvent
    {
        public enum EventType { Player, Chance, Terminal }
        string[] children;
        static int lastId = 0;
        int id;
        string name;
        EventType type;
        int branches;

        public ProtoEvent(EventType type,string name,int branches)
        {
            this.type = type;
            lastId += 1;
            id = lastId;
            this.name = name;

        }
        public override string ToString()
        {
            return String.Format("Type: {0} ; Id: {1} ; Name: {2} ;{3}",type,id,name,"");
        }
    }
}
