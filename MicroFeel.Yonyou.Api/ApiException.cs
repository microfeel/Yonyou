﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MicroFeel.Yonyou.Api
{
    public class ApiException: ApplicationException
    {
        public ApiException()
            : base() { }

        public ApiException(string message)
            : base(message) { }

        public ApiException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
