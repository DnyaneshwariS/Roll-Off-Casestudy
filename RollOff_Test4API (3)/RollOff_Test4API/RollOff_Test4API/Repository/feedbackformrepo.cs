using Microsoft.EntityFrameworkCore;
using RollOff_Test4API.Data;
using RollOff_Test4API.Models.Domain;
using System;
using System.Collections.Generic;

using System.Threading.Tasks;

namespace RollOff_Test4API.Repository
{
    #region feedbackformrepo

 
    public class feedbackformrepo:Ifeedbackform//Implements interface
    {
        private readonly RollOff4DbContext context;

        public feedbackformrepo(RollOff4DbContext context)
        {
            this.context = context;
        }
        public async Task<feedbackform> AddFormAsync(feedbackform formTable)//adding details
        {
            await context.AddAsync(formTable);
            await context.SaveChangesAsync();
            return formTable;
        }
        public async Task<feedbackform> DeleteFormAsync(double ggid)//deleteing details
        {
            var employee = await context.feedbackforms.FirstOrDefaultAsync(x => x.GlobalGroupID == ggid);
            try
            {
                if (employee == null)
                {
                    return employee;
                }
            }
            catch(Exception e)
            {
                throw;
            }
            context.feedbackforms.Remove(employee);
            await context.SaveChangesAsync();
            return employee;
        }

        public async Task<IEnumerable<feedbackform>> GetAllFormsAsync()//get all the details
        {
            return await context.feedbackforms.ToListAsync();

        }

        public async Task<feedbackform> UdateFormAsync(double ggid, feedbackform form)//update details
        {
            var existingemployee = await context.feedbackforms.FirstOrDefaultAsync(x => x.GlobalGroupID == ggid);
            try
            {
                if (existingemployee == null)
                {
                    return existingemployee;
                }
            }
            catch(Exception e)
            {
                throw;
            }

            existingemployee.EmployeeNumber = form.EmployeeNumber;
            existingemployee.Name = form.Name;
            existingemployee.PrimarySkill = form.PrimarySkill;
            existingemployee.LocalGrade = form.LocalGrade;
            existingemployee.ProjectCode = form.ProjectCode;
            existingemployee.ProjectName = form.ProjectName;
            existingemployee.Practice = form.Practice;
            existingemployee.RollOffEndDate = form.RollOffEndDate;
            existingemployee.ReasonForRollOff = form.ReasonForRollOff;
            existingemployee.ThisReleaseNeedsBackfillIsBackfilled = form.ThisReleaseNeedsBackfillIsBackfilled;
            existingemployee.PerformanceIssue = form.PerformanceIssue;
            existingemployee.Resigned = form.Resigned;
            existingemployee.UnderProbation = form.UnderProbation;
            existingemployee.LongLeave = form.LongLeave;
            existingemployee.TechnicalSkills = form.TechnicalSkills;
            existingemployee.Communication = form.Communication;
            existingemployee.RoleCompetencies = form.RoleCompetencies;
            existingemployee.Remarks = form.Remarks;
            existingemployee.RelevantExperienceYears = form.RelevantExperienceYears;
            existingemployee.Status = form.Status;
            existingemployee.RequestDate = form.RequestDate;

            await context.SaveChangesAsync();
            return existingemployee;

        }
    }
    #endregion
}
