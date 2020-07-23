﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApi.Api.Contracts.v1.Responses
{
    public class RegisterUserResponse
    {
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
    }
}
