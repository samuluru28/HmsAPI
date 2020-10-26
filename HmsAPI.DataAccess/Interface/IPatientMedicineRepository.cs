using HmsAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.DataAccess
{
    public interface IPatientMedicineRepository
    {
        PatientMedicine SaveorUpdate(PatientMedicine obj);
        IEnumerable<PatientMedicine> GetAll();

        PatientMedicine GetMedicineByID(int PatientMedicineID);

        void DeleteMedicine(int PatientMedicineID);
    }
}
