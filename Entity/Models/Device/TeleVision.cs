using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity.Models.Devices
{
    public class TeleVision:Device,IState,IChanel,IVolume,IBrightness,IMode
    {
       public Bluray bluray;


        public TeleVision(string name, Bluray bluray, Addition.Chanel chanel)
        {
            this.Name = name;
            this.Id = "tv";
            this.bluray = bluray;
            this.Chanel = chanel;
            this.Volume=20;
            this.Brightness = 20;
            this.Mode = true;
        }

        public bool State { get; set; }
        public Addition.Chanel Chanel { get; set; }
        public int Volume { get; set; }
        public int Brightness { get; set; }
        public bool Mode { get; set; }



        public bool Switch()
        {
            if (State)
                State = false;
            else
                State = true;

            return State;
        }

       public void ChanelUp()
        {
            if ((int)Chanel < System.Enum.GetValues(typeof(Addition.Chanel)).Length - 1)
            {
                Chanel++;
            }
        }
       public void ChanelDown()
        {
            if ((int)Chanel >0)
            {
                Chanel--;
            }
        }
       public void ChuseChanel(string chuseChanel)
        {
           switch(chuseChanel)
           {
               case "ictv":
                     Chanel=Addition.Chanel.ICTV;
                   break;
               case"NG":
                   Chanel=Addition.Chanel.NationalGeographics;
                   break;
               case "m1":
                   Chanel=Addition.Chanel.M1;
                   break;
               case"inter":
                   Chanel = Addition.Chanel.Інтер;
                   break;
               case"Ukr":
                   Chanel = Addition.Chanel.Україна;
                   break;
           }
        }


       public void VolumeUp()
       {
           if (Volume < 100)
               Volume++;
       }
       public void VolumeDown()
       {
           if (Volume > 1)
               Volume--;
       }

       public void BrightnessUp()
       {
           if (this.Brightness < 100)
               this.Brightness += 10;
       }
       public void BrightnessDown()
       {
           if (this.Brightness > 10)
               this.Brightness -= 10;
       }

       public void ChangeMod()
       {
           
           if (this.Mode)
           {
               Mode = false;               
           }
           else
           {
               Mode = true;              
           }
           
       }
       public string StateMode()
       {
           string mode;

           if (this.Mode)
           {               
               mode = "TV";
           }
           else
           {
               mode = "Bluray";
           }
           return mode;
       }



       public void Bluraycommand(string command)
       {
           if(command=="diskbox")               
                this. bluray.ChangeDiskbox();
           else if(command=="state")
               this.bluray.PlayPouse();
       }
       public bool Bluraystate(string command)
       {
           bool state=false;

           if (command == "diskbox")
               state = this.bluray.IsDiskboxOpen;
         
           else if (command == "state")
               state = this.bluray.IsPlay;

           return state;
       }
       
    }
}