using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSmartHouse
{
    class Fridge : Device, IState
    {
        private bool stateFrize;
        private int power;
       

        public Fridge(string name, bool state, bool stateFrize, int programm)
        {
            this.Name = name;
            this.State = state;
            this.stateFrize = stateFrize;
            this.power = programm;
            Id = "Fridge";
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
        public bool SwitchFrize()
        {
            if (this.stateFrize)
            {
                this.stateFrize = false;
            }
            else
            {
                this.stateFrize = true;
            }

            return this.stateFrize;
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

            return state;
        }
        public string ToStringFrize()
        {
            string stateFrize;

            if (this.stateFrize)
            {
                stateFrize = "Включен";
            }
            else
            {
                stateFrize = "Выключен";
            }
            return stateFrize;
        }



        public void ProgrammUP()
        {
            if (power < 5)
                power++;
        }
        public void ProgrammDown()
        {
            if (power > 1)
                power--;
        }
        public int GetPower()
        {
            return this.power;
        }


        
    }
}
