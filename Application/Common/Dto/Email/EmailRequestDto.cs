﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Dto.Email
{
    public class EmailRequestDto
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string From { get; set; }
    }
}
