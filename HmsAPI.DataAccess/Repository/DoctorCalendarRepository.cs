﻿using HmsAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.DataAccess
{
    public class DoctorCalendarRepository : BaseRepository<DoctorCalendar>, IDoctorCalendarRepository
    {
        public void DeleteDoctorCalendar(int DoctorCalendarID)
        {
            var objDoctorCalendar = GetDoctorCalendarByID(DoctorCalendarID);
            Delete(objDoctorCalendar);
        }

        public DoctorCalendar GetDoctorCalendarByID(int doctorCalendarID)
        {
            using (SessionWrapper sessionWrapper = new SessionWrapper())
            {
                using (var session = sessionWrapper.Session)
                {
                    var objDoctorCalendar = session.Query<DoctorCalendar>().Where(x => x.DoctorCalendarID == doctorCalendarID).FirstOrDefault();
                    return objDoctorCalendar;
                }
            }
        }
    }
}
