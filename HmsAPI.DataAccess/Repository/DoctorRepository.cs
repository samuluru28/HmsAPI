using HmsAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.DataAccess
{
    public class DoctorRepository : BaseRepository<Doctor>, IDoctorRepository
    {
        public void DeleteDoctor(int DoctorID)
        {
            var objDoctor = GetDoctorByID(DoctorID);
            Delete(objDoctor);
        }

        public Doctor GetDoctorByID(int doctorID)
        {

            using (SessionWrapper sessionWrapper = new SessionWrapper())
            {
                using (var session = sessionWrapper.Session)
                {
                    var objDoctor = session.Query<Doctor>().Where(x => x.DoctorID == doctorID).FirstOrDefault();
                    return objDoctor;
                }
            }
        }
    }
}
