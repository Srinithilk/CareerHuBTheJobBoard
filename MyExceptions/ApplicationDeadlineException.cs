﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHuBTheJobBoard.MyExceptions
{
    internal class ApplicationDeadlineException : Exception
    {
        public ApplicationDeadlineException(string message) : base(message) { }
    }
}