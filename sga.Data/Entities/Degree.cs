﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sga.Data.Entities
{
    public class Degree
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Duration { get; set; }
        public string Modality { get; set; }
    }
}
