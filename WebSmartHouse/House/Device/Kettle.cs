using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSmartHouse
{
    class Kettle : Device, IState
    {
        


        public Kettle(string name, bool state)
        {
            this.Name = name;
            this.State = state;
            Id = "Kettle";
        }

        public bool Switch()
        {
            if (this.State)
            {
                this.State = false;
            }
            else
            {
                this.State = true;
            }

            return this.State;
        }

        public override string ToString()
        {
            string state;
            if (this.State)
            {
                state = "Включен";
            }
            else
            {
                state = "Выключен";
            }
            return  state;
        }


        
    }
}
