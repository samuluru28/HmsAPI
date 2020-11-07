using HmsAPI.DataAccess.Interface;
using HmsAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.DataAccess.Repository
{
    public class HospitalRepository : BaseRepository<Hospital>, IHospitalRepository
    {
        public void DeleteHospital(int hospitalID)
        {
            var objHospital = GetHospitalByID(hospitalID);
            Delete(objHospital);
        }

        public Hospital GetHospitalByID(int hospitalID)
        {
            using (SessionWrapper sessionWrapper = new SessionWrapper())
            {
                using (var session = sessionWrapper.Session)
                {
                    var objHospital = session.Query<Hospital>().Where(x => x.HospitalID == hospitalID).FirstOrDefault();
                    return objHospital;
                }
            }
        }

        public Hospital GetHospitalByDoctorID(int doctorID)
        {
            using (SessionWrapper sessionWrapper = new SessionWrapper())
            {
                using (var session = sessionWrapper.Session)
                {
                    var query = "select h.* from  Doctor d join DoctorCalendar dc on d.DoctorID = dc.DoctorID and dc.DoctorID = "+ doctorID + " inner join Hospital h on dc.HospitalID = h.HospitalID";
                       
                    var results = session.CreateSQLQuery(query).AddEntity(typeof(Hospital)).List<Hospital>().FirstOrDefault();
                    return results;
                }

            }
        }
    }
}
