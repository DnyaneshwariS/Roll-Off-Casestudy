
using System.ComponentModel.DataAnnotations;


namespace RollOff_Test4API.Models.DTO
{
    #region employee


    public class GetEmployee//only this much code will display in userinterface
    {

   
        public int GlobalGroupID { get; set; }

        public int? EmployeeNo { get; set; }
        public string? Name { get; set; }
        public string? LocalGrade { get; set; }
       
        [Required]
        public string Email { get; set; }
       
    }
    #endregion
}
