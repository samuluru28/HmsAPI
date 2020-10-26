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
        public void DeleteMedicine(int PatientMedicineID)
        {
            var objMedicine = GetMedicineByID(PatientMedicineID);
            Delete(objMedicine);
        }

        public PatientMedicine GetMedicineByID(int PatientMedicineID)
        {
            var session = FluentNHibernateHelper.OpenSession();
            var objMedicine = session.Query<PatientMedicine>().Where(x => x.PatientMedicineID == PatientMedicineID).FirstOrDefault();
            return objMedicine;
        }
    }
}
