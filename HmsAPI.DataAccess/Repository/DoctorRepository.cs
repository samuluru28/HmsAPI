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

        public List<Doctor> GetDoctorsByHospitalID(int hospitalID)
        {
            using (SessionWrapper sessionWrapper = new SessionWrapper())
            {
                using (var session = sessionWrapper.Session)
                {
                    var query = "select d.* from doctor d join DoctorCalendar dc on dc.DoctorID = d.DoctorID  inner join Hospital h on h.HospitalID = dc.HospitalID where h.HospitalID =" + hospitalID;

                    var results = session.CreateSQLQuery(query).AddEntity(typeof(Doctor)).List<Doctor>().ToList();
                    return results;
                }

            }

        }

        public List<Doctor> GetDoctorsBySpecialization(string specialist)
        {
            using (SessionWrapper sessionWrapper = new SessionWrapper())
            {
                using (var session = sessionWrapper.Session)
                {
                    var query = session.Query<Doctor>().Where(x => x.Specialist.Contains(specialist)).ToList();

                    return query;
                }

            }

        }

        
       
    }
}
