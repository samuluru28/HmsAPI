using HmsAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.DataAccess
{
    public interface IDoctorRepository
    {
        Doctor SaveorUpdate(Doctor obj);
        IEnumerable<Doctor> GetAll();

        Doctor GetDoctorByID(int DoctorID);

        void DeleteDoctor(int DoctorID);
        List<Doctor> GetDoctorsByHospitalID(int hospitalID);
        List<Doctor> GetDoctorsBySpecialization(string specialist);
    }
}
