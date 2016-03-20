﻿using Entity.Models;
using Entity.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;


namespace Entity.Controllers
{
    public class ChanelController : Controller
    {
        private DevicesContext dbconnect = new DevicesContext();

        public ActionResult Nextchanel(int id, string chanel)
        {
            IDictionary<int, Models.Devices.Device> deviceList = new SortedDictionary<int, Models.Devices.Device>();
            deviceList = CreateObject(id, chanel);

            ((Models.IChanel)deviceList[0]).ChanelUp();
            SaveChange(id, chanel, deviceList);
            deviceList = ChouseDevice(chanel);
            
            return View("~/Views/Database/Index.cshtml", deviceList);
        }

        public ActionResult Beakchanel(int id,string chanel)
        {
            IDictionary<int, Models.Devices.Device> deviceList = new SortedDictionary<int, Models.Devices.Device>();
            deviceList = CreateObject(id,chanel);
            ((Models.IChanel)deviceList[0]).ChanelDown();
            SaveChange(id, chanel, deviceList);
            deviceList = ChouseDevice(chanel);
           
            return View("~/Views/Database/Index.cshtml", deviceList);
        }

        public ActionResult Chusechanel(int id, string chanel,string color)
        {
            IDictionary<int, Models.Devices.Device> deviceList = new SortedDictionary<int, Models.Devices.Device>();
            deviceList = CreateObject(id,chanel);
            ((Models.IChanel)deviceList[0]).ChuseChanel(color);

            SaveChange(id, chanel, deviceList);
            deviceList = ChouseDevice(chanel);

            return View("~/Views/Database/Index.cshtml", deviceList);
        }



        private IDictionary<int, Models.Devices.Device> CreateObject(int id, string chanel)
        {
            IDictionary<int, Models.Devices.Device> filtrDevice = new SortedDictionary<int, Models.Devices.Device>();

            int ID = id;
            if (filtrDevice.Count == 0)
                switch (chanel)
                {
                    case "lamp":

                        Models.Devices.Lamp lamp;

                        var dev1 = dbconnect.Lamp.Find(ID);

                        lamp = new Models.Devices.Lamp("0");

                        lamp.Name = dev1.Name;
                        lamp.Brightness = dev1.Brightness;
                        lamp.State = dev1.State;
                        lamp.currentcolor = dev1.CurrentColor;

                        filtrDevice.Add(0, lamp);

                        break;
                    case "tv":

                        Models.Devices.TeleVision tV;
                        Models.Devices.Bluray bluray = new Models.Devices.Bluray("0");


                        var dev2 = dbconnect.TeleVision.Find(ID);
                        var dev = dbconnect.Bluray.Find(1);

                        bluray.IsDiskboxOpen = dev.IsDiskboxOpen;
                        bluray.IsPlay = dev.IsPlay;
                        bluray.Name = dev.Name;


                        tV = new Models.Devices.TeleVision("0", bluray, Models.Addition.Chanel.ICTV);

                        tV.Name = dev2.Name;
                        tV.State = dev2.State;
                        tV.Brightness = dev2.Brightness;
                        tV.Mode = dev2.Mode;
                        tV.Volume = dev2.Volume;

                        switch (dev2.CurrentChanel)
                        {
                            case "ICTV":
                                tV.Chanel = Models.Addition.Chanel.ICTV;
                                break;
                            case "NationalGeographics":
                                tV.Chanel = Models.Addition.Chanel.NationalGeographics;
                                break;
                            case "M1":
                                tV.Chanel = Models.Addition.Chanel.M1;
                                break;
                            case "Інтер":
                                tV.Chanel = Models.Addition.Chanel.Інтер;
                                break;
                            case "Україна":
                                tV.Chanel = Models.Addition.Chanel.Україна;
                                break;
                        }


                        filtrDevice.Add(0, tV);


                        break;
                    case "ss":

                        Models.Devices.StereoSystem SSys;

                        var dev3 = dbconnect.StereoSystem.Find(ID);

                        SSys = new Models.Devices.StereoSystem("0");

                        SSys.Name = dev3.Name;
                        SSys.State = dev3.State;
                        SSys.Mode = dev3.Mode;
                        SSys.Volume = dev3.Volume;

                        filtrDevice.Add(0, SSys);


                        break;
                    case "kettle":

                        Models.Devices.Kettle ket;

                        var dev4 = dbconnect.Kettle.Find(ID);

                        ket = new Models.Devices.Kettle("0");

                        ket.Name = dev4.Name;
                        ket.State = dev4.State;

                        filtrDevice.Add(0, ket);


                        break;
                    case "fridge":

                        Models.Devices.Fridge fridge;

                        var dev5 = dbconnect.Fridge.Find(ID);

                        fridge = new Models.Devices.Fridge("0");

                        fridge.Name = dev5.Name;
                        fridge.State = dev5.State;
                        fridge.StateFrize = dev5.StateFrize;
                        fridge.Programm = dev5.Programm;


                        filtrDevice.Add(0, fridge);


                        break;
                    case "aircond":

                        Models.Devices.AirConditioning aircond;

                        var dev6 = dbconnect.AirConditioning.Find(ID);

                        aircond = new Models.Devices.AirConditioning("0");

                        aircond.Name = dev6.Name;
                        aircond.State = dev6.State;
                        aircond.Programm = dev6.Programm;

                        filtrDevice.Add(0, aircond);


                        break;
                }


            return filtrDevice;
        }
        private void SaveChange(int id, string type, IDictionary<int, Models.Devices.Device> device)
        {

            switch (type)
            {
                case "aircond":

                    AirConditioning aircond = dbconnect.AirConditioning.Find(id);

                    aircond.Programm = ((Models.Devices.AirConditioning)device[0]).Programm;
                    aircond.State = ((Models.Devices.AirConditioning)device[0]).State;

                    dbconnect.SaveChanges();

                    break;
                case "ss":



                    StereoSystem ss = dbconnect.StereoSystem.Find(id);

                    ss.State = ((Models.Devices.StereoSystem)device[0]).State;
                    ss.Mode = ((Models.Devices.StereoSystem)device[0]).Mode;
                    ss.Volume = ((Models.Devices.StereoSystem)device[0]).Volume;

                    dbconnect.SaveChanges();
                    break;
                case "lamp":

                    Lamp lamp = dbconnect.Lamp.Find(id);

                    lamp.State = ((Models.Devices.Lamp)device[0]).State;
                    lamp.CurrentColor = ((Models.Devices.Lamp)device[0]).currentcolor;
                    lamp.Brightness = ((Models.Devices.Lamp)device[0]).Brightness;

                    dbconnect.SaveChanges();

                    break;
                case "fridge":

                    Fridge fridge = dbconnect.Fridge.Find(id);

                    fridge.Programm = ((Models.Devices.Fridge)device[0]).Programm;
                    fridge.State = ((Models.Devices.Fridge)device[0]).State;
                    fridge.StateFrize = ((Models.Devices.Fridge)device[0]).StateFrize;

                    dbconnect.SaveChanges();

                    break;
                case "kettle":

                    Kettle kettle = dbconnect.Kettle.Find(id);

                    kettle.State = ((Models.Devices.Kettle)device[0]).State;
                    dbconnect.SaveChanges();

                    break;
                case "tv":

                    TeleVision tv = dbconnect.TeleVision.Find(id);

                    tv.State = ((Models.Devices.TeleVision)device[0]).State;
                    tv.Mode = ((Models.Devices.TeleVision)device[0]).Mode;
                    tv.Volume = ((Models.Devices.TeleVision)device[0]).Volume;
                    tv.CurrentChanel = ((Models.Devices.TeleVision)device[0]).Chanel.ToString();
                    tv.Brightness = ((Models.Devices.TeleVision)device[0]).Brightness;


                    dbconnect.SaveChanges();

                    break;


            }
        }
        public IDictionary<int, Models.Devices.Device> ChouseDevice(string id)
        {
            IDictionary<int, Models.Devices.Device> filtrDevice = new SortedDictionary<int, Models.Devices.Device>();


           
            switch (id)
            {
                case "lamp":

                    Models.Devices.Lamp lamp;

                    var dev1 = dbconnect.Lamp.Include(p => p.Device).ToList();
                    foreach (var l in dev1)
                    {
                        lamp = new Models.Devices.Lamp("0");

                        lamp.Name = l.Name;
                        lamp.Brightness = l.Brightness;
                        lamp.State = l.State;
                        lamp.currentcolor = l.CurrentColor;

                        filtrDevice.Add(l.Id, lamp);
                       
                    }


                    break;
                case "tv":

                    Models.Devices.TeleVision tV;
                    Models.Devices.Bluray bluray = new Models.Devices.Bluray("0");

                    var dev = dbconnect.Bluray;
                    var dev2 = dbconnect.TeleVision.Include(p => p.Device).ToList();

                    foreach (var l in dev2)
                    {
                        foreach (var d in dev)
                        {
                            bluray.IsDiskboxOpen = d.IsDiskboxOpen;
                            bluray.IsPlay = d.IsPlay;
                            bluray.Name = d.Name;
                        }

                        tV = new Models.Devices.TeleVision("0", bluray, Models.Addition.Chanel.ICTV);

                        tV.Name = l.Name;
                        tV.State = l.State;
                        tV.Brightness = l.Brightness;
                        tV.Mode = l.Mode;
                        tV.Volume = l.Volume;

                        switch (l.CurrentChanel)
                        {
                            case "ICTV":
                                tV.Chanel = Models.Addition.Chanel.ICTV;
                                break;
                            case "NationalGeographics":
                                tV.Chanel = Models.Addition.Chanel.NationalGeographics;
                                break;
                            case "M1":
                                tV.Chanel = Models.Addition.Chanel.M1;
                                break;
                            case "Інтер":
                                tV.Chanel = Models.Addition.Chanel.Інтер;
                                break;
                            case "Україна":
                                tV.Chanel = Models.Addition.Chanel.Україна;
                                break;
                        }


                        filtrDevice.Add(l.Id, tV);
                      
                    }

                    break;
                case "ss":

                    Models.Devices.StereoSystem SSys;

                    var dev3 = dbconnect.StereoSystem.Include(p => p.Device).ToList();
                    foreach (var l in dev3)
                    {
                        SSys = new Models.Devices.StereoSystem("0");

                        SSys.Name = l.Name;
                        SSys.State = l.State;
                        SSys.Mode = l.Mode;
                        SSys.Volume = l.Volume;


                        filtrDevice.Add(l.Id, SSys);
                        
                    }

                    break;
                case "kettle":

                    Models.Devices.Kettle ket;

                    var dev4 = dbconnect.Kettle.Include(p => p.Device).ToList();
                    foreach (var l in dev4)
                    {
                        ket = new Models.Devices.Kettle("0");

                        ket.Name = l.Name;
                        ket.State = l.State;

                        filtrDevice.Add(l.Id, ket);
                        
                    }

                    break;
                case "fridge":

                    Models.Devices.Fridge fridge;

                    var dev5 = dbconnect.Fridge.Include(p => p.Device).ToList();
                    foreach (var l in dev5)
                    {
                        fridge = new Models.Devices.Fridge("0");

                        fridge.Name = l.Name;
                        fridge.State = l.State;
                        fridge.StateFrize = l.StateFrize;
                        fridge.Programm = l.Programm;


                        filtrDevice.Add(l.Id, fridge);
                        
                    }

                    break;
                case "aircond":

                    Models.Devices.AirConditioning aircond;

                    var dev6 = dbconnect.AirConditioning.Include(p => p.Device).ToList();
                    foreach (var l in dev6)
                    {
                        aircond = new Models.Devices.AirConditioning("0");

                        aircond.Name = l.Name;
                        aircond.State = l.State;
                        aircond.Programm = l.Programm;

                        filtrDevice.Add(l.Id, aircond);
                        
                    }

                    break;
            }


            return filtrDevice;
        }

	}
}