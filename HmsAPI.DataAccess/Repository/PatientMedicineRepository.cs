using HmsAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.DataAccess
{
    public class PatientMedicineRepository : BaseRepository<PatientMedicine>, IPatientMedicineRepository
    {

        public PatientMedicine GetMedicineByID(int patientMedicineID)
        {
            using (SessionWrapper sessionWrapper = new SessionWrapper())
            {
                using (var session = sessionWrapper.Session)
                {
                    var objMedicine = session.Query<PatientMedicine>().Where(x => x.PatientMedicineID == patientMedicineID).FirstOrDefault();
                    return objMedicine;
                }
            }
        }

        public void DeleteMedicine(int PatientMedicineID)
        {
            var objMedicine = GetMedicineByID(PatientMedicineID);
            Delete(objMedicine);
        }

    }
}
