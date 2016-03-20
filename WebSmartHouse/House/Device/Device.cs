using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSmartHouse
{
    public class Device
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        private bool state;
        public bool State
        {
            get { return state; }
            set { state = value; }
        }

        private string id;
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

    }
}
