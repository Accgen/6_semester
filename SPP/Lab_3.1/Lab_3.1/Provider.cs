﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3._1
{
    public class Provider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }

        public List<Car> Cars { get; set; }

    }
}