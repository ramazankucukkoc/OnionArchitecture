﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Logging.Serilog.Messages
{
    public static class SeriLogMessages
    {
        public static string NullOptionsMessage =>
            "You heve sent a blank value! Something went wrong. Please try again";
    }
}
