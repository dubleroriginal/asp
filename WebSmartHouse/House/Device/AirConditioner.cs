using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSmartHouse
{
    class AirConditioning : Device, IState
    {
        private int programm;
     
        public AirConditioning(string name, bool state, int programm)
        {
            this.Name = name;
            this.State = state;
            this.programm = programm;
            Id = "Cond";
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


        public void ProgramUp()
        {
            if (programm < 3)
                programm++;
        }
        public void ProgramDown()
        {
            if (programm > 1)
                programm--;
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
        public string ProgramState()
        {
            string program;

            if (this.programm == 1)
            {
                program = "охлаждение";
            }
            else if (this.programm == 2)
            {
                program = "проветривание";
            }
            else
            {
                program = "нагрев";
            }
            return program;
        }

        
    }
}
