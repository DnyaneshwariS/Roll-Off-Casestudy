using RollOff_Test4API.Data;
using RollOff_Test4API.Models.Domain;

using System.Linq;
using System.Threading.Tasks;

namespace RollOff_Test4API.Repository
{
    #region RegisterRepository

  
    public class RegisterRepository : IRegisterRepository//Implements Interface
    {
          private RollOff4DbContext _context; 
        public RegisterRepository(RollOff4DbContext context)
        { 
            _context = context; 
        }
        public async Task<Register> CreateUser(Register reg) //User registration
        { 
            if (_context.Register.Where(x => x.Email == reg.Email).FirstOrDefault() != null)
            { 
             return null; 
            } 
            await _context.AddAsync(reg); 
            await _context.SaveChangesAsync(); 
            return reg; 
        }
    


    }
    #endregion
}
