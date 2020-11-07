using HmsAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.DataAccess.Interface
{
    public interface IHospitalRepository
    {

        Hospital SaveorUpdate(Hospital obj);
        IEnumerable<Hospital> GetAll();

        Hospital GetHospitalByID(int HospitalID);

        void DeleteHospital(int HospitalID);
        Hospital GetHospitalByDoctorID(int doctorID);
    }
}
