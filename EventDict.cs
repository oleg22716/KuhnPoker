using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuhnPoker
{
    public sealed class EventDict
    {
        #region Singletone
        private static readonly EventDict instance = new EventDict();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static EventDict()
        {
        }



        public static EventDict Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion
        Dictionary<string, Event> Events;

        private EventDict()
        {

            string[] children;//their type
            string[] args;//decision info by node
            Events = new Dictionary<string, Event>();
            Event toAdd;
            toAdd = new Event("rr", new string[6] { "JQ", "JK", "QJ", "QK", "KJ", "KQ" }, "rr");
            Events.Add("rr", toAdd);


        }
        //todo add interface
        internal static string GetChildType(string parentType, int leafNumber)
        {
            if (parentType == "c2")
                return "";
            return "";
        }
        internal static string GetArg(string state, int leafNumber)
        {
            if (state.Length == 0)//c1
            {
                if (leafNumber == 0) return "J";
                if (leafNumber == 1) return "Q";
                if (leafNumber == 2) return "K";
            }
            if (state.Length == 1)
            {
                if (state == "J")//c2
                {
                    if (leafNumber == 0) return "Q";
                    if (leafNumber == 1) return "K";
                }
                if (state == "Q")
                {
                    if (leafNumber == 0) return "J";
                    if (leafNumber == 1) return "K";
                }
                if (state == "K")
                {
                    if (leafNumber == 0) return "J";
                    if (leafNumber == 1) return "Q";
                }
            }
            if (state.Length==2||state.Length==3)
            {
                if (leafNumber == 0) return "C";
                if (leafNumber == 1) return "B";
            }
            if(state.Length==4)
                if(state.Contains("CB"))
                {
                    if (leafNumber == 0) return "C";
                    if (leafNumber == 1) return "B";
                }

            return "N";

        }
    }
}
