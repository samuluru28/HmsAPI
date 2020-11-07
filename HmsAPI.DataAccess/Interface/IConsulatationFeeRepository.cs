using HmsAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.DataAccess.Interface
{
    public interface IConsulatationFeeRepository
    {
        ConsulatationFee SaveorUpdate(ConsulatationFee obj);
        IEnumerable<ConsulatationFee> GetAll();

        ConsulatationFee GetFeeByID(int ConsulatationFeeID);

        void DeleteConsultationFee(int ConsulatationFeeID);
    }
}
