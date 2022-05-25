﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_Core.Models.Entities
{
    public abstract class BaseEntityAbstract
    {
        public abstract int Id { get; set; }
        public abstract string toLogString();
    }
}
