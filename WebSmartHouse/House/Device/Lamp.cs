using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSmartHouse
{
    class Lamp : Device, IState
    {
        private int brightness;
        private System.Drawing.Color colorLight;
        
        private List<System.Drawing.Color> colors;



        public Lamp(string name, bool state, int brightnes)
        {
            this.State = state;
            this.Name = name;
            brightness = brightnes;
            colorLight = System.Drawing.Color.White;
            Id = "Lamp";
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
            return state;
        }

        public int BrightnesUp()
        {
            if (this.brightness < 100)
                this.brightness += 5;

            return this.brightness;
        }
        public int BrightnesDown()
        {
            if (this.brightness > 10)
                this.brightness += -5;

            return this.brightness;
        }

        public string BrightnessRetutn()
        {
            return Convert.ToString(this.brightness);
        }

        public void SelectColor(string idColor)
        {

            colors = new List<System.Drawing.Color>();

            colors.Add(System.Drawing.Color.White);
            colors.Add(System.Drawing.Color.Green);
            colors.Add(System.Drawing.Color.Blue);
            colors.Add(System.Drawing.Color.Red);
            colors.Add(System.Drawing.Color.Yellow);


            switch (idColor)
            {
                case "White":
                    colorLight = colors[0];
                    break;
                case "Green":
                    colorLight = colors[1];
                    break;
                case "Blue":
                    colorLight = colors[2];
                    break;
                case "Red":
                    colorLight = colors[3];
                    break;
                case "Yellow":
                    colorLight = colors[4];
                    break;

            }

        }

        public System.Drawing.Color ReturnColor()
        {
            return this.colorLight;
        }



        
    }
}
