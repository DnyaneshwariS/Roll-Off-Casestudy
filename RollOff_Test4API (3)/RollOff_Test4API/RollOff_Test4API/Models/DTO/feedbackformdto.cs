
using System;




namespace RollOff_Test4API.Models.DTO

{
    #region feedbackformdto

   
    public class feedbackformdto//We want to view selective data to user
    {
        public int GlobalGroupID { get; set; }
        public string Name { get; set; }
        public string LocalGrade { get; set; }
        public string PrimarySkill { get; set; }
        public double? ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public string Practice { get; set; }
        public DateTime? RollOffEndDate { get; set; }
        public string ReasonForRollOff { get; set; }
        public string ThisReleaseNeedsBackfillIsBackfilled { get; set; }
        public string PerformanceIssue { get; set; }
        public string Resigned { get; set; }
        public string UnderProbation { get; set; }
        public string LongLeave { get; set; }
        public string TechnicalSkills { get; set; }
        public string Communication { get; set; }
        public string RoleCompetencies { get; set; }
        public string Remarks { get; set; }
        public double? RelevantExperienceYears { get; set; }
      
    }
    #endregion
}
