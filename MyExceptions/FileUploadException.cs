﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHuBTheJobBoard.MyExceptions
{
    internal class FileUploadException : Exception
    {
        public FileUploadException(string messsage) : base(messsage) { }
    }
}
