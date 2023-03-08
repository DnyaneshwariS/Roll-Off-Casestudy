using RollOff_Test4API.Models.Domain;
using RollOff_Test4API.Repository;

using System.Threading.Tasks;

namespace RollOff_Test4API.Services
{
    #region Registerservice

   
    public class registerservice
    {
        private IRegisterRepository _registerRepository;
        public registerservice(IRegisterRepository registerRepository)
        {
            _registerRepository = registerRepository;
        }
        public async Task<Register>CreateUser(Register reg)
        {
            return await _registerRepository.CreateUser(reg);
        }
      

    }
    #endregion
}
