﻿using System;
using System.Collections.Generic;
using System.Text;

namespace rgomezj.Freelance.Me.Core
{
    public class CaptchaResponse
    {
        public bool success { get; set; }

        public string challenge_ts { get; set; }
    }
}
