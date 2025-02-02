﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_Core.Models.Entities
{
    public abstract class StatusAbstract : BaseEntityAbstract
    {
        public abstract string Key { get; set; }
        public abstract string Description { get; set; }
    }
}
