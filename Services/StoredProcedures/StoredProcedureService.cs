//using FIS_Data.AppContext;
//using Microsoft.EntityFrameworkCore;
//using FIS_Models.Model;
//using FIS_Models.ViewModel;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using FIS_Services.Mail;
//using FIS_Models.ViewModel.Complaint;

//namespace FIS_Services.StoredProcedures
//{
//    public class StoredProcedureService : IStoredProcedureService
//    {
//        private readonly fisContext context;
//        private readonly IMailService mailService;
//        public StoredProcedureService(fisContext context, IMailService mailService)
//        {
//            this.context = context;
//            this.mailService = mailService;
//        }

//        public async Task<Response<GateRegisterMail>> SPGateRegisterMailAsync()
//        {
//            try
//            {
//                var data = await context.GateRegisterMail.FromSqlInterpolated($"EXEC Sp_GateRegisterMail").ToListAsync();
//                if (data is null)
//                    return new Response<GateRegisterMail>
//                    {
//                        Message = "Data Not Found",
//                        Status = false
//                    };
//                return new Response<GateRegisterMail>
//                {
//                    Message = "Data Found Successfully",
//                    Status = true,
//                    List = data
//                };
//            }
//            catch
//            {
//                throw;
//            }
//        }

//        public async Task<Response<SummaryReport>> SPGetSummaryReportAsync(int query)
//        {
//            try
//            {
//                var data = await context.SummaryReport.FromSqlInterpolated($"EXEC Sp_ComplaintSummaryReport {query}").ToListAsync();
//                if (data is null)
//                    return new Response<SummaryReport>
//                    {
//                        Message = "Data Not Found",
//                        Status = false
//                    };
//                return new Response<SummaryReport>
//                {
//                    Message = "Data Found Successfully",
//                    Status = true,
//                    List = data
//                };
//            }
//            catch
//            {
//                throw;
//            }
//        }

//        public async Task<Response<SummaryDetailReport>> SPGetSummaryDetailReportAsync()
//        {
//            try
//            {
//                var data = await context.SummaryDetailReport.FromSqlInterpolated($"Exec Sp_ComplaintSummaryDetailReport").ToListAsync();
//                if (data is null)
//                    return new Response<SummaryDetailReport>
//                    {
//                        Message = "Data Not Found",
//                        Status = false
//                    };
//                return new Response<SummaryDetailReport>
//                {
//                    Message = "Data Found Successfully",
//                    Status = true,
//                    List = data
//                };
//            }
//            catch
//            {
//                throw;
//            }
//        }

//        public async Task<Response<ComplaintVerficationDepartmentViewModel>> SPGetComplaintVerficationDepartmentAsync()
//        {
//            try
//            {
//                var data = await context.ComplaintVerficationDepartment.FromSqlInterpolated($"Exec Sp_ComplaintVerficationDepartment").ToListAsync();
//                if (data is null)
//                    return new Response<ComplaintVerficationDepartmentViewModel>
//                    {
//                        Message = "Data Not Found",
//                        Status = false
//                    };
//                return new Response<ComplaintVerficationDepartmentViewModel>
//                {
//                    Message = "Data Found Successfully",
//                    Status = true,
//                    List = data
//                };
//            }
//            catch
//            {
//                throw;
//            }
//        }

//        public async Task<Response<ComplaintVerficationViewModel>> SPGetComplaintVerificationAsync(int Dept)
//        {
//            try
//            {
//                var data = await context.ComplaintVerfication.FromSqlInterpolated($"Exec Sp_ComplaintVerfication {Dept}").ToListAsync();
//                if (data is null)
//                    return new Response<ComplaintVerficationViewModel>
//                    {
//                        Message = "Data Not Found",
//                        Status = false
//                    };
//                return new Response<ComplaintVerficationViewModel>
//                {
//                    Message = "Data Found Successfully",
//                    Status = true,
//                    List = data
//                };
//            }
//            catch
//            {
//                throw;
//            }
//        }

//        public async Task<Response<ComplaintVerficationDepartmentViewModel>> SPGetComplaintVerificationDeptAfter48HoursAsync()
//        {
//            try
//            {
//                var data = await context.ComplaintVerficationDepartment.FromSqlInterpolated($"Exec Sp_ComplaintVerficationIsVerified 2,0").ToListAsync();
//                if (data is null)
//                    return new Response<ComplaintVerficationDepartmentViewModel>
//                    {
//                        Message = "Data Not Found",
//                        Status = false
//                    };
//                return new Response<ComplaintVerficationDepartmentViewModel>
//                {
//                    Message = "Data Found Successfully",
//                    Status = true,
//                    List = data
//                };
//            }
//            catch
//            {
//                throw;
//            }
//        }

//        public async Task<Response<ComplaintVerficationViewModel>> SPGetComplaintVerificationAfter48HoursAsync(int Dept)
//        {
//            try
//            {
//                var data = await context.ComplaintVerfication.FromSqlInterpolated($"Exec Sp_ComplaintVerficationIsVerified 1,{Dept}").ToListAsync();
//                if (data is null)
//                    return new Response<ComplaintVerficationViewModel>
//                    {
//                        Message = "Data Not Found",
//                        Status = false
//                    };

//                foreach (var item in data)
//                {
//                    var complaint = await context.Complaints.FindAsync(item.CmpNo);
//                    if (complaint is not null)
//                    {
//                        var AddData = await context.Complaints.AddAsync(complaint);
//                        await context.SaveChangesAsync();
//                    }
//                }
//                return new Response<ComplaintVerficationViewModel>
//                {
//                    Message = "Data Found Successfully",
//                    Status = true,
//                    List = data
//                };
//            }
//            catch
//            {
//                throw;
//            }
//        }

//        public async Task<Response<dynamic>> AutoVerifiedBySystemAsync(int ComplaintId)
//        {
//            try
//            {
//                var complaint = await context.Complaints.FindAsync(ComplaintId);
//                if (complaint is not null)
//                {
//                    complaint.StatusId = 11;
//                    context.Complaints.Update(complaint);
//                    await context.SaveChangesAsync();

//                    ComplaintStatus status = new ComplaintStatus();
//                    status.ComplaintId = ComplaintId;
//                    status.StatusDateTime = DateTime.Now;
//                    status.StatusBy = "System";
//                    status.StatusId = 11;
//                    status.StatusRemarks = "Complaint Automatically Verified After 48 Hours";

//                    await context.ComplaintStatuses.AddAsync(status);
//                    await context.SaveChangesAsync();
//                }
//                return new Response<dynamic>
//                {
//                    Message = "Complaint Verified Successfully",
//                    Status = true,
//                    Data = complaint
//                };
//            }
//            catch
//            {
//                throw;
//            }
//        }

//        public async Task<Response<EmailViewModel>> GetEmailDataAsync(int MailModule)
//        {
//            try
//            {
//                List<string> to = new List<string>();
//                List<string> cc = new List<string>();
//                List<string> bcc = new List<string>();

//                var ModuleList = context.MailModuleList.Where(x => x.Status == "Yes" && x.MailModuleF == MailModule).AsQueryable();

//                var toemail = await ModuleList.Where(x => x.EmailCategory == "To").Select(s => s.Email).ToListAsync();
//                if (toemail.Count > 0)
//                {
//                    foreach (var item in toemail)
//                    {
//                        to.Add(item!);
//                    }
//                }

//                var ccemail = await ModuleList.Where(x => x.EmailCategory == "CC").Select(s => s.Email).ToListAsync();
//                if (ccemail.Count > 0)
//                {
//                    foreach (var item in ccemail)
//                    {
//                        cc.Add(item!);
//                    }
//                }

//                var bccemail = await ModuleList.Where(x => x.EmailCategory == "BCC").Select(s => s.Email).ToListAsync();
//                if (bccemail.Count > 0)
//                {
//                    foreach (var item in bccemail)
//                    {
//                        bcc.Add(item!);
//                    }
//                }

//                var subject = await context.MailModules.Where(x => x.Id == MailModule).Select(s => s.MailSubject).FirstOrDefaultAsync();

//                EmailViewModel data = new EmailViewModel();
//                data.Subject = subject;
//                data.To = to;
//                data.Cc = cc;
//                data.Bcc = bcc;

//                return new Response<EmailViewModel>
//                {
//                    Message = "Data Found Successfully",
//                    Status = true,
//                    Data = data
//                };
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }

//        public async Task<Response<EmailViewModel>> SendEmailAsync(string Content, int MailModule, int Custom)
//        {
//            try
//            {
//                await mailService.SendMailAsync("", Content, MailModule, Custom);
//                return new Response<EmailViewModel>
//                {
//                    Message = "Data Found Successfully",
//                    Status = true
//                };
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }
//    }
//}