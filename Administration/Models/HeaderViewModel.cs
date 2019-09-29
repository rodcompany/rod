﻿using Architecture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Administration.Models
{
    public class HeaderViewModel : LayoutViewModel
    { 
        public HeaderViewModel() { }
        public HeaderViewModel(int? userId, string username)
        {
            UserId = userId;
            IsLoggedIn = userId > 0;
            Greeting = username;
        }
    }
}