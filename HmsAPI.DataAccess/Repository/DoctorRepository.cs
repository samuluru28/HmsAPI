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

        public Doctor GetDoctorByID(int DoctorID)
        {
            var session = FluentNHibernateHelper.OpenSession();
            var objDoctor = session.Query<Doctor>().Where(x => x.DoctorID == DoctorID).FirstOrDefault();
            return objDoctor;
        }
    }
}
