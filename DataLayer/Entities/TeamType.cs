﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer
{
    public class TeamType : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}