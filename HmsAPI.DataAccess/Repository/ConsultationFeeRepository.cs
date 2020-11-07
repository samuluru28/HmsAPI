using HmsAPI.DataAccess.Interface;
using HmsAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.DataAccess.Repository
{
    public class ConsultationFeeRepository : BaseRepository<ConsulatationFee>, IConsulatationFeeRepository
    {
        public void DeleteConsultationFee(int consulatationFeeID)
        {
            var objAppointment = GetFeeByID(consulatationFeeID);
            Delete(objAppointment);
        }

        public ConsulatationFee GetFeeByID(int consulatationFeeID)
        {
            using (SessionWrapper sessionWrapper = new SessionWrapper())
            {
                using (var session = sessionWrapper.Session)
                {
                    var objConsultationFee = session.Query<ConsulatationFee>().Where(x => x.ConsulatationFeeID == consulatationFeeID).FirstOrDefault();
                    return objConsultationFee;
                }
            }
        }
    }
}
