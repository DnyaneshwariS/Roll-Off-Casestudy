using RollOff_Test4API.Models.Domain;

using System.Collections.Generic;

using System.Threading.Tasks;

namespace RollOff_Test4API.Repository
{
    #region Ifeedbackform

 
    public interface Ifeedbackform//interface
    {
        Task<feedbackform> AddFormAsync(feedbackform formTable);

        Task<IEnumerable<feedbackform>> GetAllFormsAsync();

        Task<feedbackform> DeleteFormAsync(double ggid);

        Task<feedbackform> UdateFormAsync(double ggid, feedbackform formTable);
    }
    #endregion
}
