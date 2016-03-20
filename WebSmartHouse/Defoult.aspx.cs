using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSmartHouse
{
    public partial class Defoult : System.Web.UI.Page
    {
        private IDictionary<int, Device> deviceList;
        private string filtr;

        private int id;
       

        protected void Page_Init(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                deviceList = (SortedDictionary<int, Device>)Session["Devices"];

            }
            else
            {
                deviceList = new SortedDictionary<int, Device>();



                deviceList.Add(0, new Lamp("Лампа 1", false, 50));
                deviceList.Add(1, new Fridge("Холодильник 1", false, false, 1));
                deviceList.Add(2, new StereoSystem("Музыкальный центр 1", false, false, 20));
                deviceList.Add(3, new AirConditioning("Кондиционер 1", false, 2));
                deviceList.Add(4, new TeleVision("Телевизор 1", false, 50));
                deviceList.Add(5, new Kettle("Чайник 1", false));



                Session["Devices"] = deviceList;
                Session["nextID"] = 6;

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                LampButt.Click += ChangeFiltre;
                FridgeButt.Click += ChangeFiltre;
                StereoSystemButt.Click += ChangeFiltre;
                AirConditioningButt.Click += ChangeFiltre;
                TVButt.Click += ChangeFiltre;
                KettleButt.Click += ChangeFiltre;
                AddDevice.Click += NewDevice;

            }

            filtr = Convert.ToString(Session["Filtr"]);
            LoadDevices(filtr);
        }

        private void NewDevice(object sender, EventArgs e)
        {
            int nextid = Convert.ToInt32(Session["nextID"]);
            filtr = Convert.ToString(Session["Filtr"]);

            switch (filtr)
            {
                case "Lamp":

                    Lamp newLamp;
                    newLamp = new Lamp("Лампа " + nextid, false, 50);
                    deviceList.Add(nextid, newLamp);
                    DevicePanel.Controls.Add(new FormForDevice(nextid, deviceList));


                    break;

                case "Fridge":

                    Fridge newFridge;
                    newFridge = new Fridge("Холодильник " + nextid, false, false, 1);
                    deviceList.Add(nextid, newFridge);
                    DevicePanel.Controls.Add(new FormForDevice(nextid, deviceList));

                    break;

                case "TR":

                    StereoSystem newTR;
                    newTR = new StereoSystem("Музыкальный центр " + nextid, false, false, 20);
                    deviceList.Add(nextid, newTR);
                    DevicePanel.Controls.Add(new FormForDevice(nextid, deviceList));

                    break;

                case "Cond":

                    AirConditioning newCond;
                    newCond = new AirConditioning("Кондиционер " + nextid, false, 2);
                    deviceList.Add(nextid, newCond);
                    DevicePanel.Controls.Add(new FormForDevice(nextid, deviceList));

                    break;

                case "TV":

                    TeleVision newTV;

                    newTV = new TeleVision("Телевизор " + nextid, false, 50);
                    deviceList.Add(nextid, newTV);
                    DevicePanel.Controls.Add(new FormForDevice(nextid, deviceList));

                    break;

                case "Kettle":

                    Kettle newKettle;

                    newKettle = new Kettle("Чайник " + nextid, false);
                    deviceList.Add(nextid, newKettle);
                    DevicePanel.Controls.Add(new FormForDevice(nextid, deviceList));

                    break;
            }



            nextid++;
            Session["nextID"] = nextid;
        }
        private void ChangeFiltre(object sender, EventArgs e)
        {

            switch (((Button)sender).ID)
            {
                case "LampButt":


                    filtr = "Lamp";
                    Session["Filtr"] = filtr;
                    DevicePanel.Controls.Clear();
                    LoadDevices(filtr);
                    
                    break;

                case "FridgeButt":

                    filtr = "Fridge";

                    Session["Filtr"] = filtr;
                    DevicePanel.Controls.Clear();

                    LoadDevices(filtr);

                    break;

                case "StereoSystemButt":

                    filtr = "TR";


                    Session["Filtr"] = filtr;
                    DevicePanel.Controls.Clear();

                    LoadDevices(filtr);

                    break;

                case "AirConditioningButt":

                    filtr = "Cond";


                    Session["Filtr"] = filtr;
                    DevicePanel.Controls.Clear();

                    LoadDevices(filtr);

                    break;

                case "TVButt":

                    filtr = "TV";

                    Session["Filtr"] = filtr;
                    DevicePanel.Controls.Clear();

                    LoadDevices(filtr);

                    break;

                case "KettleButt":

                    filtr = "Kettle";


                    Session["Filtr"] = filtr;
                    DevicePanel.Controls.Clear();

                    LoadDevices(filtr);

                    break;
            }
        }



        private void LoadDevices(string filtr)
        {
           
            foreach(int key in deviceList.Keys)
            {
                try
                {
                    if (deviceList[key].Id == filtr)
                    {
                        DevicePanel.Controls.Add(new FormForDevice(key, deviceList));
                    }
                }
               catch
                {

                }
            }
        }








    }
}