﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HmsAPI.Controllers
{
    public class HomeController: ApiController
    {
        public string Get()
        {
            return "Hello";
        }
    }
}
