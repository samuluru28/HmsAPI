﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.Dto.Request
{
    public class AppointmentParameters
    {
        public int DoctorID { get; set; }
        public DateTime AppDate { get; set; }
    }
}
