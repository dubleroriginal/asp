﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcSmartHouse.Models
{
    public interface IProgramm
    {
        int Programm { get; set; }


        void ProgrammUp();
        void ProgrammDown();
        string ProgrammState();
    }
}
