using Newtonsoft.Json.Linq;
using Recruiting_API.DAC;
using Recruiting_API.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Http;

namespace Recruiting_API.Controllers
{
    public class LoginController : ApiController
    {

    }


    /***Login Page***/
    public class LoginValidationController : ApiController
    {
        public jsonData Post(JObject jObject)
        {
            CloseSQLConnection _close = new CloseSQLConnection();
            Cls_login _in = new Cls_login();
            jsonData _json = new jsonData();
            dynamic json = jObject;
            string username = json.username;
            string password = json.password;

            _json.d = _in.getUserdetails(username, password);
            _close = new CloseSQLConnection();
            return _json;
        }
    }

    /***Dashboard Page***/
    public class RecrutingdashboardController : ApiController
    {
        public jsonData Post(JObject jObject)
        {
            CloseSQLConnection _close = new CloseSQLConnection();
            Cls_login _in = new Cls_login();
            jsonData _json = new jsonData();
            dynamic json = jObject;
            string TWE_Id = json.TWE_Id;
            string stDate = json.Startdate;
            string enDate = json.Enddate;
            string strType = json.strType;

            _json.d = _in.getRecrutingdashboarddetails(TWE_Id, stDate, enDate, strType);

            _close = new CloseSQLConnection();
            return _json;
        }
    }

    public class RecrutingdashboardIndiaController : ApiController
    {
        public jsonData Post(JObject jObject)
        {
            CloseSQLConnection _close = new CloseSQLConnection();
            Cls_login _in = new Cls_login();
            jsonData _json = new jsonData();
            dynamic json = jObject;
            string TWE_Id = json.TWE_Id;
            string stDate = json.Startdate;
            string enDate = json.Enddate;
            string strType = json.strType;

            _json.d = _in.getRecrutingdashboarddetailsIndia(TWE_Id, stDate, enDate, strType);

            _close = new CloseSQLConnection();
            return _json;
        }
    }

    public class DashboardTimerController : ApiController
    {
        public jsonData Post(JObject jObject)
        {
            CloseSQLConnection _close = new CloseSQLConnection();
            Cls_login _in = new Cls_login();
            jsonData _json = new jsonData();

            _json.d = _in.getTimezonedetails();

            _close = new CloseSQLConnection();
            return _json;
        }
    }

    /***Job list Page***/
    public class JobListController : ApiController
    {
        public jsonData Post(JObject jObject)
        {
            CloseSQLConnection _close = new CloseSQLConnection();
            Cls_login _in = new Cls_login();
            jsonData _json = new jsonData();
            dynamic json = jObject;
            string TWE_Id = json.TWE_Id;
            string stDate = json.Startdate;
            string enDate = json.Enddate;
            string tiletype = json.tiletype;

            _json.d = _in.getJobdetails(TWE_Id, stDate, enDate, tiletype);

            _close = new CloseSQLConnection();
            return _json;
        }
    }
    public class SearchController : ApiController
    {
        public jsonData Post(JObject jObject)
        {
            CloseSQLConnection _close = new CloseSQLConnection();
            Cls_login _in = new Cls_login();
            jsonData _json = new jsonData();
            dynamic json = jObject;
            string TWE_Id = json.TWE_Id;
            string stDate = json.Startdate;
            string enDate = json.Enddate;
            string searchdata = json.searchkey;
            _json.d = _in.getJobSearch(TWE_Id, stDate, enDate, searchdata);

            _close = new CloseSQLConnection();
            return _json;
        }
    }

    /***Job Page***/

    public class DropdownListController : ApiController
    {
        public jsonData Post(JObject jObject)
        {
            CloseSQLConnection _close = new CloseSQLConnection();
            Cls_login _in = new Cls_login();
            jsonData _json = new jsonData();
            dynamic json = jObject;
            string region = json.region;
            _json.d = _in.getEmployeedetails(region);

            _close = new CloseSQLConnection();
            return _json;
        }
    }

    public class JobController : ApiController
    {
        public jsonData Post(JObject jObject)
        {
            CloseSQLConnection _close = new CloseSQLConnection();
            Cls_login _in = new Cls_login();
            jsonData _json = new jsonData();
            dynamic json = jObject;
            //string ClientID = json.ClientID;

            _json.d = _in.getFormdetails();
            //_json.d = _in.getClientContactdetails(ClientID);

            _close = new CloseSQLConnection();
            return _json;
        }
    }

    public class JobIndiaController : ApiController
    {
        public jsonData Post(JObject jObject)
        {
            CloseSQLConnection _close = new CloseSQLConnection();
            Cls_login _in = new Cls_login();
            jsonData _json = new jsonData();
            dynamic json = jObject;
            //string ClientID = json.ClientID;

            _json.d = _in.getFormdetailsIndia();
            //_json.d = _in.getClientContactdetails(ClientID);

            _close = new CloseSQLConnection();
            return _json;
        }
    }

    public class ClientContactController : ApiController
    {
        public jsonData Post(JObject jObject)
        {
            CloseSQLConnection _close = new CloseSQLConnection();
            Cls_login _in = new Cls_login();
            jsonData _json = new jsonData();
            dynamic json = jObject;
            string ClientID = json.ClientID;
            _json.d = _in.getClientContactdetails(ClientID);

            _close = new CloseSQLConnection();
            return _json;
        }
    }
    public class AddJobController : ApiController
    {
        public object Post(JObject jObject)
        {
            CloseSQLConnection _close = new CloseSQLConnection();
            Cls_login _in = new Cls_login();
            jsonData _json = new jsonData();
            dynamic json = jObject;
            Jobcode objJob = new Jobcode();

            objJob.Jobcodename = json.Jobcode;
            objJob.JobTitle = json.JobTitle;
            objJob.Duration = json.Duration;
            objJob.EmplType = json.EmplType;
            objJob.Location = json.Location;
            objJob.City = json.City;
            objJob.State = json.State;
            objJob.Country = json.Country;
            objJob.Clientname = json.Clientname;
            objJob.Contactname = json.Contactname;
            objJob.Description = json.Description;
            objJob.AssignedTo = json.Assigned_To;
            objJob.Prioritylevel = json.Prioritylevel;
            objJob.Jobstatus = json.Jobstatus;
            objJob.Rate1 = json.Rate1;
            objJob.Currency1 = json.Currency1;
            objJob.WorkType1 = json.WorkType1;
            objJob.Rate2 = json.Rate2;
            objJob.Currency2 = json.Currency2;
            objJob.WorkType2 = json.WorkType2;
            objJob.Skill = json.Skill;
            objJob.Jobopendate = json.Created_On;
            objJob.OpenComments = json.OpenComments;
            objJob.CloseComments = json.CloseComments;
            objJob.Jobimage = json.Jobimage;
            objJob.Created_On = json.Created_On;
            objJob.Created_By = json.Created_By;
            objJob.Updated_On = json.Updated_On;
            objJob.Updated_By = json.Updated_By;
            objJob.Publish_Web = json.Publish_Web;
            objJob.Mode = json.Mode;

            _json.d = _in.insertJobInfo(objJob);

            _close = new CloseSQLConnection();
            return _json;
        }
    }
    public class viewJobListController : ApiController
    {
        public jsonData Post(JObject jObject)
        {
            CloseSQLConnection _close = new CloseSQLConnection();
            Cls_login _in = new Cls_login();
            jsonData _json = new jsonData();
            dynamic json = jObject;
            string Jobid = json.Jobid;

            _json.d = _in.getJobDetails(Jobid);

            _close = new CloseSQLConnection();
            return _json;
        }
    }


    /***Followup Page***/
    public class FollowupJobController : ApiController
    {
        public jsonData Post(JObject jObject)
        {
            CloseSQLConnection _close = new CloseSQLConnection();
            Cls_login _in = new Cls_login();
            jsonData _json = new jsonData();
            dynamic json = jObject;
            string Jobid = json.Jobid;
            string type = json.type;
            string createdBy = json.createdBy;

            _json.d = _in.getFollowupDetails(Jobid,type,createdBy);

            _close = new CloseSQLConnection();
            return _json;
        }
    }
    public class FollowupSearchController : ApiController
    {
        public jsonData Post(JObject jObject)
        {
            CloseSQLConnection _close = new CloseSQLConnection();
            Cls_login _in = new Cls_login();
            jsonData _json = new jsonData();
            dynamic json = jObject;
            string jobid = json.jobid;
            string stDate = json.Startdate;
            string enDate = json.Enddate;
            string searchdata = json.searchkey;
            _json.d = _in.getFollowupSearch(jobid, stDate, enDate, searchdata);

            _close = new CloseSQLConnection();
            return _json;
        }
    }

    /***Candidate Page***/
    public class CandidateCreationController : ApiController
    {
        public jsonData post(JObject jObject)
        {
            CloseSQLConnection _close = new CloseSQLConnection();
            Cls_login _in = new Cls_login();
            jsonData _json = new jsonData();
            dynamic json = jObject;
            Candidatedetails objcand = new Candidatedetails();
            objcand.candidateid = json.candidateid;
            objcand.jobcode = json.jobcode;
            objcand.jobtitle = json.jobtitle;
            objcand.candidateemailid = json.candidateemailid;
            objcand.candidatemobileno = json.candidatemobileno;
            objcand.candidatename = json.candidatename;
            objcand.currentLocation = json.currentLocation;
            objcand.visastatus = json.visastatus;
            objcand.yrsofexp = json.yrsofexp;
            objcand.ratecoverage = json.ratecoverage;
            objcand.relocate = json.relocate;
            objcand.ratePerHr = json.ratePerHr;
            objcand.type = json.type;
            objcand.skillsandCertif = json.skillsandCertif;
            objcand.linkedinURL = json.linkedinURL;
            objcand.noticePeriod = json.noticePeriod;
            objcand.availableforinterview = json.availableforinterview;
            objcand.employerid = json.employerid;
            objcand.employermailid = json.employermailid;
            objcand.employerContactno = json.employerContactno;
            objcand.employeename = json.employeename;
            objcand.corporationname = json.corporationname;
            objcand.employeradderinformation = json.employeradderinformation;
            objcand.employerspecialization = json.employerspecialization;
            objcand.recruiterrating = json.recruiterrating;
            objcand.candidateRemark = json.candidateRemark;
            objcand.createdBy = json.createdBy;
            objcand.createdOn = DateTime.Now.ToString("yyyy-MM-dd");
            objcand.lastupdatedBy = json.lastupdatedBy;
            objcand.lastupdatedOn = DateTime.Now.ToString("yyyy-MM-dd");
            objcand.candStatus = json.candStatus;
            objcand.mode = json.mode;
            objcand.lstCandProof = new List<candidateProof>();
            for (int i = 0; i < json.documents.Count; i++)
            {
                candidateProof c1 = new candidateProof();
                c1.mode = json.documents[i].mode;
                c1.candproofid = json.documents[i].candproofid;
                c1.documenttype = json.documents[i].docType;
                c1.idNo = json.documents[i].docNo;
                c1.idfilename = json.documents[i].filename;
                objcand.lstCandProof.Add(c1);
            }

            _json.d = _in.insertCandidatedetails(objcand);

            _close = new CloseSQLConnection();
            return _json;
        }
    }

    public class CandidateAssignController : ApiController
    {
        public jsonData Post(JObject jObject)
        {
            CloseSQLConnection _close = new CloseSQLConnection();
            Cls_login _in = new Cls_login();
            jsonData _json = new jsonData();
            dynamic json = jObject;
            string Candidateid = json.Candidateid;
            string Jobid = json.Jobid;

            _json.d = _in.getCandidateInfodata(Candidateid, Jobid);

            _close = new CloseSQLConnection();
            return _json;
        }
    }

    public class CandidateAssignIndiaController : ApiController
    {
        public jsonData Post(JObject jObject)
        {
            CloseSQLConnection _close = new CloseSQLConnection();
            Cls_login _in = new Cls_login();
            jsonData _json = new jsonData();
            dynamic json = jObject;
            string Candidateid = json.Candidateid;
            string Jobid = json.Jobid;

            _json.d = _in.getCandidateInfodataIndia(Candidateid, Jobid);

            _close = new CloseSQLConnection();
            return _json;
        }
    }

    public class CandidateFeedbackController : ApiController
    {
        public jsonData Post(JObject jObject)
        {
            CloseSQLConnection _close = new CloseSQLConnection();
            Cls_login _in = new Cls_login();
            jsonData _json = new jsonData();
            dynamic json = jObject;
            string Jobid = json.Jobid;
            string candid = json.candid;
            

            _json.d = _in.getFeedback(Jobid, candid);

            _close = new CloseSQLConnection();
            return _json;
        }
    }
    public class CandidateFeedbackIndiaController : ApiController
    {
        public jsonData Post(JObject jObject)
        {
            CloseSQLConnection _close = new CloseSQLConnection();
            Cls_login _in = new Cls_login();
            jsonData _json = new jsonData();
            dynamic json = jObject;
            string Jobid = json.Jobid;
            string candid = json.candid;

            _json.d = _in.getFeedbackIndia(Jobid, candid);

            _close = new CloseSQLConnection();
            return _json;
        }
    }
    public class CandidateViewController : ApiController
    {
        public jsonData Post(JObject jObject)
        {
            CloseSQLConnection _close = new CloseSQLConnection();
            Cls_login _in = new Cls_login();
            jsonData _json = new jsonData();
            dynamic json = jObject;
            string Candidateid = json.Candidateid;

            _json.d = _in.getCandidateViewdata(Candidateid);

            _close = new CloseSQLConnection();
            return _json;
        }
    }
    public class CandidateCheckController : ApiController
    {
        public jsonData Post(JObject jObject)
        {
            CloseSQLConnection _close = new CloseSQLConnection();
            Cls_login _in = new Cls_login();
            jsonData _json = new jsonData();
            dynamic json = jObject;
            string emailid = json.emailid;
            string number = json.number;

            _json.d = _in.checkCandidatedata(emailid, number);

            _close = new CloseSQLConnection();
            return _json;
        }
    }

    public class EmployerCheckController : ApiController
    {
        public jsonData Post(JObject jObject)
        {
            CloseSQLConnection _close = new CloseSQLConnection();
            Cls_login _in = new Cls_login();
            jsonData _json = new jsonData();
            dynamic json = jObject;
            string emailid = json.emailid;
            string number = json.number;

            _json.d = _in.checkEmployerdata(emailid, number);

            _close = new CloseSQLConnection();
            return _json;
        }
    }
    public class FileUploadController : ApiController
    {
        [HttpPost()]
        public jsonArray UploadFiles()
        {
            int iUploadedCnt = 0;
            int status = 1;

            MasterFileUploadData _lstdata = new MasterFileUploadData();

            // DEFINE THE PATH WHERE WE WANT TO SAVE THE FILES.
            string sPath = "";
            System.Collections.Specialized.NameValueCollection s1 = System.Web.HttpContext.Current.Request.Form;

            string[] str = s1.AllKeys;
            var str1="";

            if (str[0].Contains("Resume"))
            {
                str1 = str[1] + "_Resume";
            }
            else if (str[0].Contains("Aadhar"))
            {
                str1 = str[1] + "_Aadhar";
            }
            else if (str[0].Contains("PAN"))
            {
                str1 = str[1] + "_PAN";
            }
            else if (str[0].Contains("Others"))
            {
                str1 = str[1] + "_Others";
            }
            else if (str[0].Contains("Driving"))
            {
                str1 = str[1] + "_DLCopy";
            }
            else if (str[0].Contains("Visa"))
            {
                str1 = str[1] + "_Visa";
            }


            if (str1 != "")
            {
                sPath = System.Web.Hosting.HostingEnvironment.MapPath("~/Candidate/" + str[0] + "/");
            }
            else
            {
                sPath = System.Web.Hosting.HostingEnvironment.MapPath("~/" + str[0] + "/");
            }

            System.Web.HttpFileCollection hfc = System.Web.HttpContext.Current.Request.Files;



            // CHECK THE FILE COUNT.
            for (int iCnt = 0; iCnt <= hfc.Count - 1; iCnt++)
            {
                System.Web.HttpPostedFile hpf = hfc[iCnt];

                if (hpf.ContentLength > 0)
                {
                    // CHECK IF THE SELECTED FILE(S) ALREADY EXISTS IN FOLDER. (AVOID DUPLICATE)
                    if (!File.Exists(sPath + Path.GetFileName(hpf.FileName)))
                    {
                        if (str1!="")
                        {
                            try
                            {
                                str1 += Path.GetExtension(hpf.FileName);
                                // SAVE THE FILES IN THE FOLDER.
                                //hpf.SaveAs(sPath + Path.GetFileName(hpf.FileName));
                                hpf.SaveAs(sPath + str1);
                                iUploadedCnt = iUploadedCnt + 1;
                            }
                            catch (Exception Ex)
                            {
                                var path = HttpContext.Current.Server.MapPath("~/error"); ;

                                string text = Ex.Message.ToString() + Ex.InnerException;
                                byte[] data = Encoding.ASCII.GetBytes(text);
                                string newFileName = Guid.NewGuid() + ".txt";
                                File.WriteAllBytes(Path.Combine(path, newFileName), data);
                            }
                        }

                        else
                        {
                            hpf.SaveAs(sPath + Path.GetFileName(hpf.FileName));
                            iUploadedCnt = iUploadedCnt + 1;
                        }
                        
                    }

                    
                }

                if (iUploadedCnt > 0)
                {
                    // _lstdata.fileName = sPath + Path.GetFileName(hpf.FileName);
                    _lstdata.fileName = Path.GetFileName(str1);
                    _lstdata.status = "SUCCESS";
                }
                else
                {
                    _lstdata.fileName = "";
                    _lstdata.status = "FAILED";
                }
            }

            //if (iUploadedCnt > 0)
            //{
            //    return iUploadedCnt + " Files Uploaded Successfully";
            //}
            //else
            //{
            //    return "Upload Failed";
            //}

            // RETURN A MESSAGE.

            jsonArray _json = new jsonArray();
            if (status == 0)
            {
                _json.status = "0";
                _json.message = "SQL QUERY EXECUTION FAILED";
                _json.data = new object();
            }
            else
            {
                _json = new jsonArray();
                _json.status = "1";
                _json.message = "SQL QUERY EXECUTED";
                _json.data = _lstdata;
            }

            return _json;
        }
    }


    public class FileDeleteController : ApiController
    {
        [HttpPost()]
        public jsonArray DeleteFiles()
        {
            int iUploadedCnt = 0;
            int status = 1;

            MasterFileUploadData _lstdata = new MasterFileUploadData();

            // DEFINE THE PATH WHERE WE WANT TO SAVE THE FILES.
            string sPath = "";
            System.Collections.Specialized.NameValueCollection s1 = System.Web.HttpContext.Current.Request.Form;

            string[] str = s1.AllKeys;
            var str1 = "";

            //if (str[0].Contains("Resume"))
            //{
            //    str1 = str[1] + "_Resume";
            //}
            //else if (str[0].Contains("Aadhar"))
            //{
            //    str1 = str[1] + "_Aadhar";
            //}
            //else if (str[0].Contains("PAN"))
            //{
            //    str1 = str[1] + "_PAN";
            //}
            //else if (str[0].Contains("Others"))
            //{
            //    str1 = str[1] + "_Others";
            //}
            //else if (str[0].Contains("Driving"))
            //{
            //    str1 = str[1] + "_DLCopy";
            //}
            //else if (str[0].Contains("Visa"))
            //{
            //    str1 = str[1] + "_Visa";
            //}

            if (str[0] == "Images")
            {
                sPath = System.Web.Hosting.HostingEnvironment.MapPath("~/Candidate/" + str[0] + "/");
            }
            else
            {
                sPath = System.Web.Hosting.HostingEnvironment.MapPath("~/" + str[0] + "/");
            }


            System.Web.HttpFileCollection hfc = System.Web.HttpContext.Current.Request.Files;

            var fileName = sPath + str[1];

            // CHECK THE FILE COUNT.
            //for (int iCnt = 0; iCnt <= hfc.Count - 1; iCnt++)
            //{
            //    System.Web.HttpPostedFile hpf = hfc[iCnt];

            //    if (hpf.ContentLength > 0)
            //    {
                    // CHECK IF THE SELECTED FILE(S) ALREADY EXISTS IN FOLDER. (AVOID DUPLICATE)
                    if (File.Exists(sPath + Path.GetFileName(str[1])))
                    {
                //str1 += Path.GetExtension(fileName);

                FileInfo file = new FileInfo(sPath + Path.GetFileName(str[1]));
                try
                {
                    file.Delete();
                    iUploadedCnt = iUploadedCnt + 1;
                }
                catch(Exception Ex)
                {
                    var path = HttpContext.Current.Server.MapPath("~/error"); ;

                    string text = Ex.Message.ToString() + Ex.InnerException;
                    byte[] data = Encoding.ASCII.GetBytes(text);
                    string newFileName = Guid.NewGuid() + ".txt";
                    File.WriteAllBytes(Path.Combine(path, newFileName), data);
                }
            }
              //  }

                if (iUploadedCnt > 0)
                {
                    // _lstdata.fileName = sPath + Path.GetFileName(hpf.FileName);
                    _lstdata.fileName = Path.GetFileName(str1);
                    _lstdata.status = "SUCCESS";
                }
                else
                {
                    _lstdata.fileName = "";
                    _lstdata.status = "FAILED";
                }
            //}

            //if (iUploadedCnt > 0)
            //{
            //    return iUploadedCnt + " Files Uploaded Successfully";
            //}
            //else
            //{
            //    return "Upload Failed";
            //}

            // RETURN A MESSAGE.

            jsonArray _json = new jsonArray();
            if (status == 0)
            {
                _json.status = "0";
                _json.message = "SQL QUERY EXECUTION FAILED";
                _json.data = new object();
            }
            else
            {
                _json = new jsonArray();
                _json.status = "1";
                _json.message = "SQL QUERY EXECUTED";
                _json.data = _lstdata;
            }

            return _json;
        }
    }


    public class SendMailController : ApiController
    {
        public jsonData Post(JObject jObject)
        {
            CloseSQLConnection _close = new CloseSQLConnection();
            Cls_login _in = new Cls_login();
            jsonData _json = new jsonData();
            dynamic json = jObject;
            mailInfo objmail = new mailInfo();
            objmail.fromAddr = json.fromAddr;
            objmail.toAddr = json.toAddr;
            objmail.ccAddr = json.ccAddr;
            objmail.subject = json.subject;
            objmail.Description = json.Description;
            objmail.jobcode = json.jobcode;
            objmail.candidateemailid = json.candidateemailid;
            objmail.employeremaildid = json.employeremaildid;

            _json.d = _in.sendMail(objmail);

            _close = new CloseSQLConnection();
            return _json;
        }

    }

    public class SendMailIndiaController : ApiController
    {
        public jsonData Post(JObject jObject)
        {
            CloseSQLConnection _close = new CloseSQLConnection();
            Cls_login _in = new Cls_login();
            jsonData _json = new jsonData();
            dynamic json = jObject;
            mailInfo objmail = new mailInfo();
            objmail.fromAddr = json.fromAddr;
            objmail.toAddr = json.toAddr;
            objmail.ccAddr = json.ccAddr;
            objmail.subject = json.subject;
            objmail.Description = json.Description;
            objmail.jobcode = json.jobcode;
            objmail.candidateemailid = json.candidateemailid;
            objmail.employeremaildid = json.employeremaildid;

            _json.d = _in.sendMailIndia(objmail);

            _close = new CloseSQLConnection();
            return _json;
        }

    }

    //public class JobINDController : ApiController
    //{
    //    public jsonData Post(JObject jObject)
    //    {
    //        CloseSQLConnection _close = new CloseSQLConnection();
    //        Cls_login _in = new Cls_login();
    //        jsonData _json = new jsonData();
    //        dynamic json = jObject;
    //        //string ClientID = json.ClientID;

    //        _json.d = _in.getJobFormdetails();
    //        //_json.d = _in.getClientContactdetails(ClientID);

    //        _close = new CloseSQLConnection();
    //        return _json;
    //    }
    //}


    public class AddJobIndiaController : ApiController
    {
        public object Post(JObject jObject)
        {
            CloseSQLConnection _close = new CloseSQLConnection();
            Cls_login _in = new Cls_login();
            jsonData _json = new jsonData();
            dynamic json = jObject;
            JobcodeIndia objJob = new JobcodeIndia();

            objJob.Jobcodename = json.Jobcode;
            objJob.JobTitle = json.JobTitle;
            objJob.Duration = json.Duration;
            objJob.EmplType = json.EmplType;
            objJob.Location = json.Location;
            objJob.Country = json.Country;
            objJob.Startdate = json.Startdate;
            objJob.Noofopening = json.Noofopening;
            objJob.ShiftTiming = json.ShiftTiming;
            objJob.TurnAroundtime = json.TurnAroundtime;
            objJob.Clientname = json.Clientname;
            objJob.Contactname = json.Contactname;
            objJob.Description = json.Description;
            objJob.AssignedTo = json.Assigned_To;
            objJob.Prioritylevel = json.Prioritylevel;
            objJob.Jobstatus = json.Jobstatus;
            objJob.Minrate = json.Minrate;
            objJob.Maxrate = json.Maxrate;
            objJob.Ratetype = json.Ratetype;
            objJob.Currency = json.Currency;
            objJob.Skill = json.Skill;
            objJob.Jobopendate = json.Created_On;
            objJob.OpenComments = json.OpenComments;
            objJob.CloseComments = json.CloseComments;
            objJob.Jobimage = json.Jobimage;
            objJob.Created_On = json.Created_On;
            objJob.Created_By = json.Created_By;
            objJob.Updated_On = json.Updated_On;
            objJob.Updated_By = json.Updated_By;
            objJob.Mode = json.Mode;
            objJob.Publish_Web = json.Publish_Web;

            _json.d = _in.insertJobIndiaInfo(objJob);

            _close = new CloseSQLConnection();
            return _json;
        }
    }

    public class ClientContactIndiaController : ApiController
    {
        public jsonData Post(JObject jObject)
        {
            CloseSQLConnection _close = new CloseSQLConnection();
            Cls_login _in = new Cls_login();
            jsonData _json = new jsonData();
            dynamic json = jObject;
            string ClientID = json.ClientID;
            _json.d = _in.getClientContactIndiadetails(ClientID);

            _close = new CloseSQLConnection();
            return _json;
        }
    }

    public class viewJobListIndiaController : ApiController
    {
        public jsonData Post(JObject jObject)
        {
            CloseSQLConnection _close = new CloseSQLConnection();
            Cls_login _in = new Cls_login();
            jsonData _json = new jsonData();
            dynamic json = jObject;
            string Jobid = json.Jobid;

            _json.d = _in.getJobDetailsIndia(Jobid);

            _close = new CloseSQLConnection();
            return _json;
        }
    }

    public class JobListIndiaController : ApiController
    {
        public jsonData Post(JObject jObject)
        {
            CloseSQLConnection _close = new CloseSQLConnection();
            Cls_login _in = new Cls_login();
            jsonData _json = new jsonData();
            dynamic json = jObject;
            string TWE_Id = json.TWE_Id;
            string stDate = json.Startdate;
            string enDate = json.Enddate;
            string tiletype = json.tiletype;

            _json.d = _in.getJobdetailsIndia(TWE_Id, stDate, enDate, tiletype);

            _close = new CloseSQLConnection();
            return _json;
        }
    }

    public class CandidateIndiaController : ApiController
    {
        public jsonData post(JObject jObject)
        {
            DateTime dateTime_Indian = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));

            CloseSQLConnection _close = new CloseSQLConnection();
            Cls_login _in = new Cls_login();
            jsonData _json = new jsonData();
            dynamic json = jObject;
            CandidatedetailsIndia objcand = new CandidatedetailsIndia();
            objcand.candidateid = json.candidateid;
            objcand.jobcode = json.jobcode;
            objcand.jobtitle = json.jobtitle;
            objcand.candidateemailid = json.candidateemailid;
            objcand.candidatemobileno = json.candidatemobileno;
            objcand.candidatename = json.candidatename;
            objcand.currentLocation = json.currentLocation;
            objcand.TotYearsofExp = json.TotYearsofExp;
            objcand.yrsofexp = json.yrsofexp;
            objcand.currcompany = json.currcompany;
            objcand.startdate = json.startdate;
            objcand.enddate = json.enddate;
            objcand.ratePerHr = json.ratePerHr;
            objcand.type = json.type;
            objcand.skillsandCertif = json.skillsandCertif;
            objcand.linkedinURL = json.linkedinURL;
            objcand.noticePeriod = json.noticePeriod;
            objcand.availableforinterview = json.availableforinterview;
            objcand.employerid = json.employerid;
            objcand.employermailid = json.employermailid;
            objcand.employerContactno = json.employerContactno;
            objcand.employeename = json.employeename;
            objcand.corporationname = json.corporationname;
            objcand.employeradderinformation = json.employeradderinformation;
            objcand.employerspecialization = json.employerspecialization;
            objcand.recruiterrating = json.recruiterrating;
            objcand.candidateRemark = json.candidateRemark;
            objcand.createdBy = json.createdBy;
            objcand.createdOn = dateTime_Indian.ToString("yyyy-MM-dd");
            objcand.lastupdatedBy = json.lastupdatedBy;
            objcand.lastupdatedOn = dateTime_Indian.ToString("yyyy-MM-dd");
            objcand.candStatus = json.candStatus;
            objcand.mode = json.mode;
            objcand.lstCandProof = new List<candidateProof>();
            for (int i = 0; i < json.documents.Count; i++)
            {
                candidateProof c1 = new candidateProof();
                c1.mode = json.documents[i].mode;
                c1.candproofid = json.documents[i].candproofid;
                c1.documenttype = json.documents[i].docType;
                c1.idNo = json.documents[i].docNo;
                c1.idfilename = json.documents[i].filename;
                objcand.lstCandProof.Add(c1);
            }

            _json.d = _in.insertCandidatedetailsIndia(objcand);

            _close = new CloseSQLConnection();
            return _json;
        }
    }


    public class CandidateCheckIndiaController : ApiController
    {
        public jsonData Post(JObject jObject)
        {
            CloseSQLConnection _close = new CloseSQLConnection();
            Cls_login _in = new Cls_login();
            jsonData _json = new jsonData();
            dynamic json = jObject;
            string emailid = json.emailid;
            string number = json.number;

            _json.d = _in.checkCandidatedataIndia(emailid, number);

            _close = new CloseSQLConnection();
            return _json;
        }
    }

    public class FollowupJobIndiaController : ApiController
    {
        public jsonData Post(JObject jObject)
        {
            CloseSQLConnection _close = new CloseSQLConnection();
            Cls_login _in = new Cls_login();
            jsonData _json = new jsonData();
            dynamic json = jObject;
            string Jobid = json.Jobid;
            string type = json.type;
            string createdBy = json.createdBy;

            _json.d = _in.getFollowupDetailsIndia(Jobid,type,createdBy);

            _close = new CloseSQLConnection();
            return _json;
        }
    }

    public class CandidateViewIndiaController : ApiController
    {
        public jsonData Post(JObject jObject)
        {
            CloseSQLConnection _close = new CloseSQLConnection();
            Cls_login _in = new Cls_login();
            jsonData _json = new jsonData();
            dynamic json = jObject;
            string Candidateid = json.Candidateid;

            _json.d = _in.getCandidateViewdataIndia(Candidateid);

            _close = new CloseSQLConnection();
            return _json;
        }


    }

    public class CandidateFormIndiaController : ApiController
    {
        public jsonData Post(JObject jObject)
        {
            CloseSQLConnection _close = new CloseSQLConnection();
            Cls_login _in = new Cls_login();
            jsonData _json = new jsonData();
            dynamic json = jObject;
            //string ClientID = json.ClientID;

            _json.d = _in.getSkilldetails();

            _close = new CloseSQLConnection();
            return _json;
        }
    }

    public class SkillController : ApiController
    {
        public jsonData Post(JObject jObject)
        {
            CloseSQLConnection _close = new CloseSQLConnection();
            Cls_login _in = new Cls_login();
            jsonData _json = new jsonData();
            dynamic json = jObject;
            
            _json.d = _in.getSkills();

            _close = new CloseSQLConnection();
            return _json;
        }
    }

    public class AddSkillController : ApiController
    {
        public object Post(JObject jObject)
        {
            CloseSQLConnection _close = new CloseSQLConnection();
            Cls_login _in = new Cls_login();
            jsonData _json = new jsonData();
            dynamic json = jObject;

            string skillname = json.Skill;
            _json.d = _in.insertSkillInfo(skillname);

            _close = new CloseSQLConnection();
            return _json;
        }
    }

    public class CandidateOveviewController : ApiController
    {
        public jsonData Post(JObject jObject)
        {
            CloseSQLConnection _close = new CloseSQLConnection();
            Cls_login _in = new Cls_login();
            jsonData _json = new jsonData();
            dynamic json = jObject;
            string stDate = json.Startdate;
            string enDate = json.Enddate;
            string TWE_Id = json.TWE_Id;
            string filter = json.filter;
            _json.d = _in.getCandidateoverviewDetails(stDate, enDate, TWE_Id, filter);

            _close = new CloseSQLConnection();
            return _json;
        }


    }

    public class CandidateOveviewListController : ApiController
    {
        public jsonData Post(JObject jObject)
        {
            CloseSQLConnection _close = new CloseSQLConnection();
            Cls_login _in = new Cls_login();
            jsonData _json = new jsonData();
            dynamic json = jObject;
            string stDate = json.Startdate;
            string enDate = json.Enddate;
            string TWE_Id = json.TWE_Id;
            string filter = json.filter;
            _json.d = _in.getCandidateoverviewListDetails(stDate, enDate, TWE_Id, filter);

            _close = new CloseSQLConnection();
            return _json;
        }


    }

    public class CandidateProfileviewController : ApiController
    {
        public jsonData Post(JObject jObject)
        {
            CloseSQLConnection _close = new CloseSQLConnection();
            Cls_login _in = new Cls_login();
            jsonData _json = new jsonData();
            dynamic json = jObject;
            string candidateid = json.candidateid;
            string TWE_Id = json.TWE_Id;
            _json.d = _in.getCandidateProfile(candidateid, TWE_Id);

            _close = new CloseSQLConnection();
            return _json;
        }


    }

    public class CandidateOveviewIndiaController : ApiController
    {
        public jsonData Post(JObject jObject)
        {
            CloseSQLConnection _close = new CloseSQLConnection();
            Cls_login _in = new Cls_login();
            jsonData _json = new jsonData();
            dynamic json = jObject;
            string stDate = json.Startdate;
            string enDate = json.Enddate;
            string TWE_Id = json.TWE_Id;
            string filter = json.filter;
            _json.d = _in.getCandidateoverviewIndiaDetails(stDate, enDate, TWE_Id, filter);

            _close = new CloseSQLConnection();
            return _json;
        }


    }

    public class CandidateOveviewIndiaListController : ApiController
    {
        public jsonData Post(JObject jObject)
        {
            CloseSQLConnection _close = new CloseSQLConnection();
            Cls_login _in = new Cls_login();
            jsonData _json = new jsonData();
            dynamic json = jObject;
            string stDate = json.Startdate;
            string enDate = json.Enddate;
            string TWE_Id = json.TWE_Id;
            string filter = json.filter;
            _json.d = _in.getCandidateoverviewListIndiaDetails(stDate, enDate, TWE_Id, filter);

            _close = new CloseSQLConnection();
            return _json;
        }


    }

    public class CandidateProfileviewIndiaController : ApiController
    {
        public jsonData Post(JObject jObject)
        {
            CloseSQLConnection _close = new CloseSQLConnection();
            Cls_login _in = new Cls_login();
            jsonData _json = new jsonData();
            dynamic json = jObject;
            string candidateid = json.candidateid;
            string TWE_Id = json.TWE_Id;
            _json.d = _in.getCandidateProfileIndia(candidateid, TWE_Id);

            _close = new CloseSQLConnection();
            return _json;
        }

    }

    public class FeedbackPageLoadController : ApiController
    {
        public jsonData Post(JObject jObject)
        {
            CloseSQLConnection _close = new CloseSQLConnection();
            Cls_login _in = new Cls_login();
            jsonData _json = new jsonData();
            dynamic json = jObject;

            string Userid = json.Userid;
            string Prjid = json.prjid;


            _json.d = _in.getfeedbackload(Userid, Prjid);
            _close = new CloseSQLConnection();
            return _json;
        }
    }

    public class saveCandidateCommentsController : ApiController
    {
        public jsonData Post(JObject jObject)
        {
            CloseSQLConnection _close = new CloseSQLConnection();
            Cls_login _in = new Cls_login();
            jsonData _json = new jsonData();
            dynamic json = jObject;

            string Userid = json.Userid;
            string Prjid = json.prjid;
            string rowid = json.rowid;
            string CLComments = json.CLComments;
            string CLcomgivenby = json.CLcomgivenby;
            string CLcomgivenon = json.CLcomgivenon;
            string CLcomgiventime = json.CLcomgiventime;
            string CLupdategivenby = json.CLupdategivenby;
            string CLupdategivenon = json.CLupdategivenon;
            string CLupdategiventime = json.CLupdategiventime;
            string TLComments = json.TLComments;
            string TLRating = json.TLRating;
            string TLcomgivenby = json.TLcomgivenby;
            string TLcomgivenon = json.TLcomgivenon;
            string TLcomgiventime = json.TLcomgiventime;
            string TLupdategivenby = json.TLupdategivenby;
            string TLupdategivenon = json.TLupdategivenon;
            string TLupdategiventime = json.TLupdategiventime;
            string BPComments = json.BPComments;
            string BPcomgivenby = json.BPcomgivenby;
            string BPcomgivenon = json.BPcomgivenon;
            string BPcomgiventime = json.BPcomgiventime;
            string BPupdategivenby = json.BPupdategivenby;
            string BPupdategivenon = json.BPupdategivenon;
            string BPupdategiventime = json.BPupdategiventime;
            string BPIstartdate = json.BPIstartdate;
            string BPItime = json.BPItime;
            string BPIcomgivenby = json.BPIcomgivenby;
            string BPIcomgivenon = json.BPIcomgivenon;
            string BPIcomgiventime = json.BPIcomgiventime;
            string BPIupdategivenby = json.BPIupdategivenby;
            string BPIupdategivenon = json.BPIupdategivenon;
            string BPIupdategiventime = json.BPIupdategiventime;
            string ECComments = json.ECComments;
            string ECcomgivenby = json.ECcomgivenby;
            string ECcomgivenon = json.ECcomgivenon;
            string ECcomgiventime = json.ECcomgiventime;
            string ECupdategivenby = json.ECupdategivenby;
            string ECupdategivenon = json.ECupdategivenon;
            string ECupdategiventime = json.ECupdategiventime;
            string ECIstartdate = json.ECIstartdate;
            string ECItime = json.ECItime;
            string ECIcomgivenby = json.ECIcomgivenby;
            string ECIcomgivenon = json.ECIcomgivenon;
            string ECIcomgiventime = json.ECIcomgiventime;
            string ECIupdategivenby = json.ECIupdategivenby;
            string ECIupdategivenon = json.ECIupdategivenon;
            string ECIupdategiventime = json.ECIupdategiventime;
            string Candstatus = json.Candstatus;


            _json.d = _in.insertfeedback(Userid, Prjid, rowid, CLComments, CLcomgivenby, CLcomgivenon, CLcomgiventime, CLupdategivenby,
                CLupdategivenon, CLupdategiventime, TLComments, TLRating, TLcomgivenby, TLcomgivenon, TLcomgiventime, TLupdategivenby, TLupdategivenon,
                TLupdategiventime, BPComments, BPcomgivenby, BPcomgivenon, BPcomgiventime, BPupdategivenby, BPupdategivenon, BPupdategiventime,
                BPIstartdate, BPItime, BPIcomgivenby, BPIcomgivenon, BPIcomgiventime, BPIupdategivenby, BPIupdategivenon, BPIupdategiventime,
                ECComments, ECcomgivenby, ECcomgivenon, ECcomgiventime, ECupdategivenby, ECupdategivenon, ECupdategiventime, ECIstartdate,
                ECItime, ECIcomgivenby, ECIcomgivenon, ECIcomgiventime, ECIupdategivenby, ECIupdategivenon, ECIupdategiventime, Candstatus);
            _close = new CloseSQLConnection();
            return _json;
        }

    }

    public class CandidateCommentsController : ApiController
    {
        public jsonData Post(JObject jObject)
        {
            CloseSQLConnection _close = new CloseSQLConnection();
            Cls_login _in = new Cls_login();
            jsonData _json = new jsonData();
            dynamic json = jObject;

            string jobId = json.jobId;
            string Candid = json.Candid;

            _json.d = _in.getCandfeedback(jobId, Candid);
            _close = new CloseSQLConnection();
            return _json;
        }

    }

    public class FeedbackPageLoadIndiaController : ApiController
    {
        public jsonData Post(JObject jObject)
        {
            CloseSQLConnection _close = new CloseSQLConnection();
            Cls_login _in = new Cls_login();
            jsonData _json = new jsonData();
            dynamic json = jObject;

            string Userid = json.Userid;
            string Prjid = json.prjid;


            _json.d = _in.getfeedbackloadIndia(Userid, Prjid);
            _close = new CloseSQLConnection();
            return _json;
        }
    }

    public class saveCandidateCommentsIndiaController : ApiController
    {
        public jsonData Post(JObject jObject)
        {
            CloseSQLConnection _close = new CloseSQLConnection();
            Cls_login _in = new Cls_login();
            jsonData _json = new jsonData();
            dynamic json = jObject;

            string Userid = json.Userid;
            string Prjid = json.prjid;
            string rowid = json.rowid;
            string CLComments = json.CLComments;
            string CLcomgivenby = json.CLcomgivenby;
            string CLcomgivenon = json.CLcomgivenon;
            string CLcomgiventime = json.CLcomgiventime;
            string CLupdategivenby = json.CLupdategivenby;
            string CLupdategivenon = json.CLupdategivenon;
            string CLupdategiventime = json.CLupdategiventime;
            string TLComments = json.TLComments;
            string TLRating = json.TLRating;
            string TLcomgivenby = json.TLcomgivenby;
            string TLcomgivenon = json.TLcomgivenon;
            string TLcomgiventime = json.TLcomgiventime;
            string TLupdategivenby = json.TLupdategivenby;
            string TLupdategivenon = json.TLupdategivenon;
            string TLupdategiventime = json.TLupdategiventime;
            string BPComments = json.BPComments;
            string BPcomgivenby = json.BPcomgivenby;
            string BPcomgivenon = json.BPcomgivenon;
            string BPcomgiventime = json.BPcomgiventime;
            string BPupdategivenby = json.BPupdategivenby;
            string BPupdategivenon = json.BPupdategivenon;
            string BPupdategiventime = json.BPupdategiventime;
            string BPIstartdate = json.BPIstartdate;
            string BPItime = json.BPItime;
            string BPIcomgivenby = json.BPIcomgivenby;
            string BPIcomgivenon = json.BPIcomgivenon;
            string BPIcomgiventime = json.BPIcomgiventime;
            string BPIupdategivenby = json.BPIupdategivenby;
            string BPIupdategivenon = json.BPIupdategivenon;
            string BPIupdategiventime = json.BPIupdategiventime;
            string ECComments = json.ECComments;
            string ECcomgivenby = json.ECcomgivenby;
            string ECcomgivenon = json.ECcomgivenon;
            string ECcomgiventime = json.ECcomgiventime;
            string ECupdategivenby = json.ECupdategivenby;
            string ECupdategivenon = json.ECupdategivenon;
            string ECupdategiventime = json.ECupdategiventime;
            string ECIstartdate = json.ECIstartdate;
            string ECItime = json.ECItime;
            string ECIcomgivenby = json.ECIcomgivenby;
            string ECIcomgivenon = json.ECIcomgivenon;
            string ECIcomgiventime = json.ECIcomgiventime;
            string ECIupdategivenby = json.ECIupdategivenby;
            string ECIupdategivenon = json.ECIupdategivenon;
            string ECIupdategiventime = json.ECIupdategiventime;
            string Candstatus = json.Candstatus;


            _json.d = _in.insertfeedbackIndia(Userid, Prjid, rowid, CLComments, CLcomgivenby, CLcomgivenon, CLcomgiventime, CLupdategivenby,
                CLupdategivenon, CLupdategiventime, TLComments, TLRating, TLcomgivenby, TLcomgivenon, TLcomgiventime, TLupdategivenby, TLupdategivenon,
                TLupdategiventime, BPComments, BPcomgivenby, BPcomgivenon, BPcomgiventime, BPupdategivenby, BPupdategivenon, BPupdategiventime,
                BPIstartdate, BPItime, BPIcomgivenby, BPIcomgivenon, BPIcomgiventime, BPIupdategivenby, BPIupdategivenon, BPIupdategiventime,
                ECComments, ECcomgivenby, ECcomgivenon, ECcomgiventime, ECupdategivenby, ECupdategivenon, ECupdategiventime, ECIstartdate,
                ECItime, ECIcomgivenby, ECIcomgivenon, ECIcomgiventime, ECIupdategivenby, ECIupdategivenon, ECIupdategiventime, Candstatus);
            _close = new CloseSQLConnection();
            return _json;
        }

    }

    public class CandidateCommentsIndiaController : ApiController
    {
        public jsonData Post(JObject jObject)
        {
            CloseSQLConnection _close = new CloseSQLConnection();
            Cls_login _in = new Cls_login();
            jsonData _json = new jsonData();
            dynamic json = jObject;

            string jobId = json.jobId;
            string Candid = json.Candid;

            _json.d = _in.getCandfeedbackIndia(jobId, Candid);
            _close = new CloseSQLConnection();
            return _json;
        }

    }


}

/**Config Table**/

public class MasterinsertController : ApiController
{
    public jsonData Post(JObject jObject)
    {
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;
        string fieldname = json.fieldname;
        string status = json.status;
        string mastertype = json.mastertype;
        string mode = json.mode;
        string rowid = json.rowid;

        _json.d = _in.insertmaster(fieldname, status, mastertype, mode, rowid);
        _close = new CloseSQLConnection();
        return _json;
    }
}

public class MasterviewController : ApiController
{
    public jsonData Post(JObject jObject)
    {
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;

        string mastertype = json.mastertype;


        _json.d = _in.viewmaster(mastertype);
        _close = new CloseSQLConnection();
        return _json;
    }
}

public class UserMenuAccessController : ApiController
{
    public jsonData Post(JObject jObject)
    {
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;
        string userid = json.userid;
        string menuid = json.menuid;

        string jobcreate = json.jobcreate;
        string jobedit = json.jobedit;
        string jobview = json.jobview;
        string jobdelete = json.jobdelete;

        string vendorcreate = json.vendorcreate;
        string vendoredit = json.vendoredit;
        string vendorview = json.vendorview;
        string vendordelete = json.vendordelete;

        string candidatecreate = json.candidatecreate;
        string candidateedit = json.candidateedit;
        string candidateview = json.candidateview;
        string candidatedelete = json.candidatedelete;

        string status = json.status;
        string mode = json.mode;



        _json.d = _in.insertaccessmenu(userid, menuid, jobcreate, jobedit, jobview, jobdelete, vendorcreate, vendoredit, vendorview,
            vendordelete, candidatecreate, candidateedit, candidateview, candidatedelete, status, mode);
        _close = new CloseSQLConnection();
        return _json;
    }
}

public class VendorFormController : ApiController
{
    public jsonData Post(JObject jObject)
    {
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;
        //string ClientID = json.ClientID;

        _json.d = _in.getSpecializationdetails();

        _close = new CloseSQLConnection();
        return _json;
    }
}

public class vendorController : ApiController
{
    public jsonData Post(JObject jObject)
    {
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;
        string vendorname = json.vendorname;
        string website = json.website;
        string linkedin = json.linkedin;
        string specilization = json.specilization;
        string address = json.address;
        string city = json.city;
        string country = json.country;
        string remarks = json.remarks;
        string status = json.status;
        string mode = json.mode;
        string vendorid = json.vendorid;
        string Createdon = json.createdon;
        string createdby = json.createdby;
        string updatedon = json.updatedon;
        string updatedby = json.updatedby;
        string vendortype = json.vendortype;

        List<vendorcontact> recruiter = new List<vendorcontact>();
        for (int i = 0; i < json.recruiter.Count; i++)
        {
            vendorcontact c1 = new vendorcontact();
            c1.mode = json.recruiter[i].mode;
            c1.vencontactid = json.recruiter[i].vencontactid;
            c1.contactname = json.recruiter[i].contactname;
            c1.employermobileno = json.recruiter[i].employermobileno;
            c1.employeremailid = json.recruiter[i].employeremailid;
            c1.employerremarks = json.recruiter[i].employerremarks;
            c1.vendorid = json.recruiter[i].vendorid;
            c1.venConstatus = json.recruiter[i].venConstatus;

            recruiter.Add(c1);
        }



        _json.d = _in.insertvendor(vendorname, website, linkedin, specilization,remarks, address, city, country, recruiter, status,
            mode, vendorid, Createdon, createdby, updatedon, updatedby,vendortype);
        _close = new CloseSQLConnection();
        return _json;
    }
}

public class clientController : ApiController
{
    public jsonData Post(JObject jObject)
    {
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;
        string clientname = json.clientname;
        string website = json.website;
        string linkedin = json.linkedin;
        string specialization = json.specialization;
        string address = json.address;
        string city = json.city;
        string country = json.country;
        string remarks = json.remarks;
        string clienttype = json.clienttype;
        string placeofsupply = json.placeofsupply;
        string status = json.status;
        string mode = json.mode;
        string clientid = json.clientid;
        string Createdon = json.createdon;
        string createdby = json.createdby;
        string updatedon = json.updatedon;
        string updatedby = json.updatedby;

        List<vendorcontact> recruiter = new List<vendorcontact>();
        for (int i = 0; i < json.recruiter.Count; i++)
        {
            vendorcontact c1 = new vendorcontact();
            c1.mode = json.recruiter[i].mode;
            c1.vencontactid = json.recruiter[i].vencontactid;
            c1.contactname = json.recruiter[i].contactname;
            c1.employermobileno = json.recruiter[i].employermobileno;
            c1.employeremailid = json.recruiter[i].employeremailid;
            c1.employerremarks = json.recruiter[i].employerremarks;
            c1.vendorid = json.recruiter[i].vendorid;
            c1.venConstatus = json.recruiter[i].venConstatus;

            recruiter.Add(c1);
        }



        _json.d = _in.insertClient(clientname, website, linkedin, specialization, remarks, address, city, country, recruiter, status,
            placeofsupply, clienttype, mode, clientid, Createdon, createdby, updatedon, updatedby);
        _close = new CloseSQLConnection();
        return _json;
    }
}

public class ClientListController : ApiController
{
    public jsonData Post(JObject jObject)
    {
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;

        _json.d = _in.getclientdetails();

        _close = new CloseSQLConnection();
        return _json;
    }
}

public class viewClientListController : ApiController
{
    public jsonData Post(JObject jObject)
    {
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;
        string Clientid = json.clientid;

        _json.d = _in.getviewClientDetails(Clientid);

        _close = new CloseSQLConnection();
        return _json;
    }
}

//public class vendorsearchController : ApiController
//{
//    public jsonData Post(JObject jObject)
//    {
//        CloseSQLConnection _close = new CloseSQLConnection();
//        Cls_login _in = new Cls_login();
//        jsonData _json = new jsonData();
//        dynamic json = jObject;
//        string specilization = json.specilization;
//        string city = json.city;
//        string country = json.country;



//        _json.d = _in.searchvendor(specilization, city, country);
//        _close = new CloseSQLConnection();
//        return _json;
//    }
//}

public class VendorListController : ApiController
{
    public jsonData Post(JObject jObject)
    {
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;
        string TWE_Id = json.TWE_Id;
        string stDate = json.Startdate;
        string enDate = json.Enddate;

        _json.d = _in.getvendordetails(TWE_Id, stDate, enDate);

        _close = new CloseSQLConnection();
        return _json;
    }
}

public class viewVendorListController : ApiController
{
    public jsonData Post(JObject jObject)
    {
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;
        string Vendorid = json.Vendorid;

        _json.d = _in.getviewVendorDetails(Vendorid);

        _close = new CloseSQLConnection();
        return _json;
    }
}

public class CandidateCountController : ApiController
{
    public jsonData Post(JObject jObject)
    {
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;      

        _json.d = _in.getcandidatecount();

        _close = new CloseSQLConnection();
        return _json;
    }
}


public class VendorSearchController : ApiController
{
    public jsonData Post(JObject jObject)
    {
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;
        string TWE_Id = json.TWE_Id;
        string specialization = json.specialization;
        string city = json.city;
        string location = json.location;

        _json.d = _in.getvendorsearch(TWE_Id, specialization, city, location);

        _close = new CloseSQLConnection();
        return _json;
    }
}

public class VendorEmailController : ApiController
{
    public jsonData Post(JObject jObject)
    {
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;
        List<vendorsearch> lstVenid = new List<vendorsearch>();
        for (int i = 0; i < json.lstVen.Count; i++)
        {
            vendorsearch obj = new vendorsearch();
            obj.vendorid = json.lstVen[i].vendorid;

            lstVenid.Add(obj);
        }
            

        _json.d = _in.getvendormailid(lstVenid);

        _close = new CloseSQLConnection();
        return _json;
    }
}

public class CandidateSearchController : ApiController
{
    public jsonData Post(JObject jObject)
    {
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;
        string skill = json.skill;
        string yrsofexp = json.yrsofexp;
        string visastatus = json.visastatus;
        string location = json.location;
        string rating = json.rating;
        string Candidatemail = json.Candidatemail;
        string TWE_Id = json.TWE_Id;

        _json.d = _in.getcandidatesearch(skill, location, yrsofexp, visastatus,rating, Candidatemail, TWE_Id);

        _close = new CloseSQLConnection();
        return _json;
    }
}

public class CandidateSearchIndiaController : ApiController
{
    public jsonData Post(JObject jObject)
    {
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;
        string skill = json.skill;
        string yrsofexp = json.yrsofexp;
        string Candidatename = json.Candidatename;
        string rating = json.rating;
        string Candidatemail = json.Candidatemail;
        string TWE_Id = json.TWE_Id;

        _json.d = _in.getcandidatesearchIndia(skill, Candidatename, yrsofexp,rating, Candidatemail, TWE_Id);

        _close = new CloseSQLConnection();
        return _json;
    }
}


public class CandidateCountIndiaController : ApiController
{
    public jsonData Post(JObject jObject)
    {
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;

        _json.d = _in.getcandidatecountIndia();

        _close = new CloseSQLConnection();
        return _json;
    }
}


public class InsertUserProfileController : ApiController
{
    public jsonData Post(JObject jObject)
    {
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;
        string Firstname = json.Firstname;
        string Lastname = json.Lastname;
        string Gender = json.Gender;
        string DOB = json.DOB;
        string Emailid = json.Emailid;
        string Confirmationemailid = json.Confirmationemailid;
        string Location = json.Location;
        string Phoneno = json.Phoneno;
        string Language = json.Language;
        string Designation = json.Designation;
        string Region = json.Region;
        string Monsterusername = json.Monsterusername;
        string Monsterpassword = json.Monsterpassword;
        string Textnow = json.Textnow;
        string Username = json.Username;
        string Password = json.Password;
        string Reportingmanager = json.Reportingmanager;
        string ReportingTL = json.ReportingTL;
        string Status = json.Status;
        string Userid = json.Userid;
        string Submission_Daily = json.Submissiondaily;
        string SubmissiontoTL_Daily = json.SubmissiontoTLdaily;
        string SubmissiontoBP_Daily = json.SubmissiontoBPdaily;
        string Closure_Daily = json.Closuredaily;
        string Vendor_Daily = json.Vendorsdaily;
        string Submission_Monthly = json.Submissionmonthly;
        string SubmissiontoTL_Monthly = json.SubmissiontoTLmonthly;
        string SubmissiontoBP_Monthly = json.SubmissiontoBPmonthly;
        string Closure_Monthly = json.Closuremonthly;
        string Vendor_Monthly = json.Vendorsmonthly;
        string Submission_Weekly = json.Submissionweekly;
        string SubmissiontoTL_Weekly = json.SubmissiontoTLweekly;
        string SubmissiontoBP_Weekly = json.SubmissiontoBPweekly;
        string Closure_Weekly = json.Closureweekly;
        string Vendor_Weekly = json.Vendorsweekly;
        string Role = json.Role;
        string Level= json.Level;
        string jobMenu = json.jobMenu;
        string jobCreation = json.jobCreation;
        string jobEdit = json.jobEdit;
        string jobView = json.jobView;
        string jobFeedback = json.jobFeedback;
        string candidateMenu = json.candidateMenu;
        string candidateCreation = json.candidateCreation;
        string candidateEdit = json.candidateEdit;
        string candidateView = json.candidateView;
        string vendorMenu = json.vendorMenu;
        string vendorCreation = json.vendorCreation;
        string vendorEdit = json.vendorEdit;
        string vendorView = json.vendorView;
        string reportMenu = json.reportMenu;

        _json.d = _in.insertusercreation(Firstname, Lastname, Gender, DOB, Emailid, Confirmationemailid,
                                            Location, Phoneno, Language, Designation, Region, Monsterusername, Monsterpassword, Textnow,
                                            Username, Password, Reportingmanager, ReportingTL, Status, Userid, Submission_Daily,
                                            SubmissiontoTL_Daily, SubmissiontoBP_Daily, Closure_Daily, Vendor_Daily, Submission_Monthly,
                                            SubmissiontoTL_Monthly, SubmissiontoBP_Monthly, Closure_Monthly, Vendor_Monthly,
                                            Submission_Weekly, SubmissiontoTL_Weekly, SubmissiontoBP_Weekly, Closure_Weekly, Vendor_Weekly,
                                            Role, Level, jobMenu, jobCreation, jobEdit, jobView,
                                            jobFeedback, candidateMenu, candidateCreation, candidateEdit, candidateView, vendorMenu, vendorCreation,
                                            vendorEdit, vendorView, reportMenu);
        _close = new CloseSQLConnection();
        return _json;
    }
}

public class ProfilepasswordupdateController : ApiController
{
    public jsonData Post(JObject jObject)
    {
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;
        string Password = json.Password;
        string Userid = json.Userid;



        _json.d = _in.updatepassword(Password, Userid);
        _close = new CloseSQLConnection();
        return _json;
    }
}

public class ViewUserProfileController : ApiController
{
    public jsonData Post(JObject jObject)
    {
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;

        string Userid = json.Userid;



        _json.d = _in.getUserprofile(Userid);
        _close = new CloseSQLConnection();
        return _json;
    }
}

public class MenuacsessController : ApiController
{
    public jsonData Post(JObject jObject)
    {
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;

        string Userid = json.Userid;
        string designationid = json.designation;


        _json.d = _in.getMenuaccess(Userid, designationid);
        _close = new CloseSQLConnection();
        return _json;
    }
}

public class DeleteAccountController : ApiController
{
    public jsonData Post(JObject jObject)
    {
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;

        string Userid = json.Userid;
        string status = json.status;


        _json.d = _in.accountdeactive(Userid, status);
        _close = new CloseSQLConnection();
        return _json;
    }
}


public class DrplistController : ApiController
{
    public jsonData Post(JObject jObject)
    {
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;

        //string Userid = json.Userid;



        _json.d = _in.DrpList();
        _close = new CloseSQLConnection();
        return _json;
    }
}

public class DrpManagerlistController : ApiController
{
    public jsonData Post(JObject jObject)
    {
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;

        _json.d = _in.getManagerdetails();
        _close = new CloseSQLConnection();
        return _json;
    }
}

public class TargetfixingController : ApiController
{
    public jsonData Post(JObject jObject)
    {
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;

        string roletype = json.roletype;
        string leveltype = json.leveltype;
        string region = json.region;


        _json.d = _in.getTargetdetails(roletype, leveltype, region);
        _close = new CloseSQLConnection();
        return _json;
    }
}


public class ManagerJobListIndiaController : ApiController
{
    public jsonData Post(JObject jObject)
    {
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;
        string TWE_Id = json.TWE_Id;
        string tiletype = json.tiletype;
        string filtertype = json.filtertype;

        _json.d = _in.getManagerJobdetailsIndia(TWE_Id, tiletype, filtertype);

        _close = new CloseSQLConnection();
        return _json;
    }
}


public class ManagerJobListController : ApiController
{
    public jsonData Post(JObject jObject)
    {
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;
        string TWE_Id = json.TWE_Id;
        string tiletype = json.tiletype;
        string filtertype = json.filtertype;

        _json.d = _in.getManagerJobdetails(TWE_Id, tiletype, filtertype);

        _close = new CloseSQLConnection();
        return _json;
    }
}


//public class DownloadAPIController : ApiController
//{
//    [HttpGet]
//    [Route("api/FileAPI/GetFile")]
//    public HttpResponseMessage GetFile()
//    {

//        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
//        //string fileName = "Koshy-ABAP WM-INV00134-072021.pdf";
//        //string sPath = HttpContext.Current.Server.MapPath("~/Candidate/Resume/" + fileName);
//        System.Collections.Specialized.NameValueCollection s1 = System.Web.HttpContext.Current.Request.Form;

//        string[] str = s1.AllKeys;

//        var sPath = "";

//        //sPath = System.Web.Hosting.HostingEnvironment.MapPath("~/Candidate/" + str[1] + "/" + str[0] + "/");

//        sPath = "G:\\PleskVhosts\\techwaukee.com\\hunTcreW.Testing.techwaukee.com\\Candidate\\Resume_India\\Jagriti Kukreti_Resume.pdf";



//        if (!File.Exists(sPath))
//        {
//            //Throw 404 (Not Found) exception if File not found.
//            response.StatusCode = HttpStatusCode.NotFound;
//            response.ReasonPhrase = string.Format("File not found: {0} .", sPath);
//            throw new HttpResponseException(response);

//        }


//        response = new HttpResponseMessage(HttpStatusCode.OK);
//        response.Content = new StreamContent(new FileStream(sPath, FileMode.Open, FileAccess.Read));
//        response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
//        response.Content.Headers.ContentDisposition.FileName = str[0];
//        response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");

//        return response;



//        ////Read the File into a Byte Array.
//        //byte[] bytes = File.ReadAllBytes(sPath);

//        ////Set the Response Content.
//        //response.Content = new ByteArrayContent(bytes);

//        ////Set the Response Content Length.
//        //response.Content.Headers.ContentLength = bytes.LongLength;

//        ////Set the Content Disposition Header Value and FileName.
//        //response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
//        //response.Content.Headers.ContentDisposition.FileName = str[0];

//        ////Set the File Content Type.
//        //response.Content.Headers.ContentType = new MediaTypeHeaderValue(MimeMapping.GetMimeMapping(str[0]));
//        //return response;

//        //var spath=HttpContext.Current.Server.MapPath("~/Candidate/Resume/" + spath);
//        //var target = System.Web.Hosting.HostingEnvironment.MapPath("~/Candidate/Resume/" + spath);
//        //var memory = new MemoryStream();
//        //using (var stream = new FileStream(target, FileMode.Open))
//        //{
//        //    stream.CopyToAsync(memory);
//        //}

//        //memory.Position = 0;

//        //return File(memory, ".pdf",Path.GetFileName(target));

//    }
//}



public class FileAPIController : ApiController
{
    [HttpGet]
    [Route("api/FileAPI/GetFile")]
    public HttpResponseMessage GetFile(string fileName)
    {
        //Create HTTP Response.
        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);

        //Set the File Path.
        //string filePath = "G:\\PleskVhosts\\techwaukee.com\\hunTcreW.Testing.techwaukee.com\\Candidate\\Resume_India\\Jagriti Kukreti_Resume.pdf";

        fileName = fileName.Replace("%20", " ");
        string filePath = HttpContext.Current.Server.MapPath("~/Candidate/" + fileName);
        //Check whether File exists.
        if (!File.Exists(filePath))
        {
            //Throw 404 (Not Found) exception if File not found.
            response.StatusCode = HttpStatusCode.NotFound;
            response.ReasonPhrase = string.Format("File not found: {0} .", filePath);
            throw new HttpResponseException(response);
        }


        //Read the File into a Byte Array.
        byte[] bytes = File.ReadAllBytes(filePath);

        //Set the Response Content.
        response.Content = new ByteArrayContent(bytes);

        //Set the Response Content Length.
        response.Content.Headers.ContentLength = bytes.LongLength;

        //Set the Content Disposition Header Value and FileName.
        response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
        response.Content.Headers.ContentDisposition.FileName = fileName;

        //Set the File Content Type.
        response.Content.Headers.ContentType = new MediaTypeHeaderValue(MimeMapping.GetMimeMapping(fileName));
        return response;
    }
}
    


public class DownloadFilesController : ApiController
{
    public jsonData Post(JObject jObject)
    {
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;
        string spath = json.spath;


        _json.d = _in.downloadfiles(spath);
        _close = new CloseSQLConnection();
        return _json;
    }
}

public class ForgotPasswordController : ApiController
{
    public jsonData Post(JObject jObject)
    {
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;
        string emailid = json.emailid;
        string TWE_Id = json.TWE_Id;

        _json.d = _in.sendForgotPasswordMail(emailid, TWE_Id);
        _close = new CloseSQLConnection();
        return _json;
    }
}


public class SuperAdminTargetfixingController : ApiController
{
    public object Post(JObject jObject)
    {
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;
        targetfixingMstr objtf = new targetfixingMstr();
        objtf.TargetfixingId = json.targetfixingid;
        objtf.RoleType = json.RoleType;
        objtf.LevelType = json.LevelType;
        objtf.RegionType = json.RegionType;
        objtf.Submission_Daily = json.Submissiondaily;
        objtf.SubmissiontoTL_Daily = json.SubmissiontoTLdaily;
        objtf.SubmissiontoBP_Daily = json.SubmissiontoBPdaily;
        objtf.Closure_Daily = json.Closuredaily;
        objtf.Vendor_Daily = json.Vendorsdaily;
        objtf.Submission_Monthly = json.Submissionmonthly;
        objtf.SubmissiontoTL_Monthly = json.SubmissiontoTLmonthly;
        objtf.SubmissiontoBP_Monthly = json.SubmissiontoBPmonthly;
        objtf.Closure_Monthly = json.Closuremonthly;
        objtf.Vendor_Monthly = json.Vendorsmonthly;
        objtf.Submission_Weekly = json.Submissionweekly;
        objtf.SubmissiontoTL_Weekly = json.SubmissiontoTLweekly;
        objtf.SubmissiontoBP_Weekly = json.SubmissiontoBPweekly;
        objtf.Closure_Weekly = json.Closureweekly;
        objtf.Vendor_Weekly = json.Vendorsweekly;

        _json.d = _in.insertTargetfixing(objtf);

        _close = new CloseSQLConnection();
        return _json;
    }
}

public class SuperAdminMenuMasterController : ApiController
{
    public object Post(JObject jObject)
    {
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;
        menuaccesspermision objmap = new menuaccesspermision();
        objmap.menuaccessid = json.menuaccessid;
        objmap.roleid = json.roleid;
        objmap.regionid = json.regionid;
        objmap.jobAccess = json.jobaccess;
        objmap.jobCreation = json.jobcreation;
        objmap.jobEdit = json.jobedit;
        objmap.jobView = json.jobview;
        objmap.jobFeedback = json.jobfeedback;
        objmap.candidateAccess = json.candidateaccess;
        objmap.candidateCreation = json.candidatecreation;
        objmap.candidateView = json.candidateview;
        objmap.candidateEdit = json.candidateedit;
        objmap.vendorAccess = json.vendoraccess;
        objmap.vendorCreation = json.vendorcreation;
        objmap.vendorView = json.vendorview;
        objmap.vendorEdit = json.vendoredit;
        objmap.reportAccess = json.reportaccess;
        objmap.Status = json.status;


        _json.d = _in.insertMenumaster(objmap);

        _close = new CloseSQLConnection();
        return _json;
    }
}

public class SuperAdminImageMasterController : ApiController
{
    public object Post(JObject jObject)
    {
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;
        Imagemaster objim = new Imagemaster();

        objim.imageid = json.imageid;
        objim.technologyname = json.technologyname;
        objim.path = json.path;
        objim.status = json.status;

        _json.d = _in.insertImagemaster(objim);

        _close = new CloseSQLConnection();
        return _json;
    }
}

public class getTargetfixingidController : ApiController
{
    public object Post(JObject jObject)
    {
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;
        string Targetfixingid = json.targetfixingid;

        _json.d = _in.gettargetfixing(Targetfixingid);

        _close = new CloseSQLConnection();
        return _json;
    }
}

public class getMenuAccessController : ApiController
{
    public object Post(JObject jObject)
    {
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;
        string menuaccessId = json.menuaccessId;

        _json.d = _in.getmenuaccess(menuaccessId);

        _close = new CloseSQLConnection();
        return _json;
    }
}

public class getImagemasterController : ApiController
{
    public object Post(JObject jObject)
    {
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;

        _json.d = _in.getImagemaster();

        _close = new CloseSQLConnection();
        return _json;
    }
}

public class TargetFormController : ApiController
{
    public jsonData Post(JObject jObject)
    {
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;

        _json.d = _in.getTargetFormdetails();

        _close = new CloseSQLConnection();
        return _json;
    }
}

public class TeamPerfomanceFeedbackIndiaController : ApiController
{
    public object Post(JObject jObject)
    {
        DateTime dateTime_Indian = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;
        TeamPerfomanceFeedback objtpf = new TeamPerfomanceFeedback();

        objtpf.Teamperfomanceid = json.Teamperfomanceid;      
        
        objtpf.OverallRating = json.OverallRating;
        objtpf.Remarks = json.Remarks;
        objtpf.status = json.status;
        objtpf.TWEID = json.TWEID;
        objtpf.Weekinfo = json.Weekinfo;
        objtpf.Feedback_givenon = dateTime_Indian.ToString("yyyy-MM-dd");
        objtpf.Feedback_givenby = json.Feedback_givenby;
        objtpf.Feedback_updatedon = dateTime_Indian.ToString("yyyy-MM-dd");
        objtpf.Feedback_updatedby = json.Feedback_updatedby;
        string tablename = json.Type;

        _json.d = _in.insertTeamfeedbackIndia(objtpf,tablename);

        _close = new CloseSQLConnection();
        return _json;
    }
}

public class TeamPerfomanceFeedbackController : ApiController
{
    public object Post(JObject jObject)
    {
        DateTime dateTime_Eastern = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;
        TeamPerfomanceFeedback objtpf = new TeamPerfomanceFeedback();

        objtpf.Teamperfomanceid = json.Teamperfomanceid;

        objtpf.OverallRating = json.OverallRating;
        objtpf.Remarks = json.Remarks;
        objtpf.status = json.status;
        objtpf.TWEID = json.TWEID;
        objtpf.Weekinfo = json.Weekinfo;
        objtpf.Feedback_givenon = dateTime_Eastern.ToString("yyyy-MM-dd");
        objtpf.Feedback_givenby = json.Feedback_givenby;
        objtpf.Feedback_updatedon = dateTime_Eastern.ToString("yyyy-MM-dd");
        objtpf.Feedback_updatedby = json.Feedback_updatedby;
        string tablename = json.Type;

        _json.d = _in.insertTeamfeedback(objtpf, tablename);

        _close = new CloseSQLConnection();
        return _json;
    }
}


public class getReportingTeamListController : ApiController
{
    public object Post(JObject jObject)
    {
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;
        string userid = json.userid;

        _json.d = _in.getTeamList(userid);

        _close = new CloseSQLConnection();
        return _json;
    }
}

public class ManagerdashboardIndiaController : ApiController
{
    public jsonData Post(JObject jObject)
    {
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;
        string TWE_Id = json.TWE_Id;
        string stDate = json.Startdate;
        string enDate = json.Enddate;
        string strType = json.strType;

        _json.d = _in.getTeammemberdashboarddetailsIndia(TWE_Id, stDate, enDate, strType);

        _close = new CloseSQLConnection();
        return _json;
    }
}

public class ManagerdashboardController : ApiController
{
    public jsonData Post(JObject jObject)
    {
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;
        string TWE_Id = json.TWE_Id;
        string stDate = json.Startdate;
        string enDate = json.Enddate;
        string strType = json.strType;

        _json.d = _in.getTeammemberdashboarddetails(TWE_Id, stDate, enDate, strType);

        _close = new CloseSQLConnection();
        return _json;
    }
}

public class RoleMenuController : ApiController
{
    public jsonData Post(JObject jObject)
    {
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;
        string RoleId = json.roletype;
                     
        _json.d = _in.getRolemenu(RoleId);
        _close = new CloseSQLConnection();
        return _json;
    }
}

public class SuperadmindashboardController : ApiController
{
    public jsonData Post(JObject jObject)
    {
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;
        
        _json.d = _in.getSuperAdmindashboarddetails();

        _close = new CloseSQLConnection();
        return _json;
    }
}

public class RecruiterDetailsListIndiaController : ApiController
{
    public jsonData Post(JObject jObject)
    {
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;
        string TWE_Id = json.TWE_Id;
        string stDate = json.Startdate;
        string enDate = json.Enddate;
        string tiletype = json.tiletype;

        _json.d = _in.getRecruiterdetailsIndia(TWE_Id, stDate, enDate, tiletype);

        _close = new CloseSQLConnection();
        return _json;
    }
}

public class RecruiterDetailsListController : ApiController
{
    public jsonData Post(JObject jObject)
    {
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;
        string TWE_Id = json.TWE_Id;
        string stDate = json.Startdate;
        string enDate = json.Enddate;
        string tiletype = json.tiletype;

        _json.d = _in.getRecruiterdetailsUSA(TWE_Id, stDate, enDate, tiletype);

        _close = new CloseSQLConnection();
        return _json;
    }
}


public class RecruiterJobListIndiaController : ApiController
{
    public jsonData Post(JObject jObject)
    {
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;
        string TWE_Id = json.TWE_Id;
        string stDate = json.Startdate;
        string enDate = json.Enddate;

        _json.d = _in.getRecruiterJobdetailsIndia(TWE_Id, stDate, enDate);

        _close = new CloseSQLConnection();
        return _json;
    }
}



public class RecruiterJobListController : ApiController
{
    public jsonData Post(JObject jObject)
    {
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;
        string TWE_Id = json.TWE_Id;
        string stDate = json.Startdate;
        string enDate = json.Enddate;

        _json.d = _in.getRecruiterJobdetailsUSA(TWE_Id, stDate, enDate);

        _close = new CloseSQLConnection();
        return _json;
    }
}


public class TeamMemberTargetIndiaController : ApiController
{
    public jsonData Post(JObject jObject)
    {
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;
        string TWE_Id = json.TWE_Id;
        string Weekinfo = json.Weekinfo;
        string fromdate = json.fromdate;
        string todate = json.todate;
        string strtype = json.strtype;
        string prevfromdate = json.prevfromdate;
        string prevtodate = json.prevtodate;
        string tablename = json.tablename;

        _json.d = _in.getTeammemberTargetdetailsIndia(TWE_Id, Weekinfo,fromdate,todate,strtype, prevfromdate, prevtodate,tablename);

        _close = new CloseSQLConnection();
        return _json;
    }
}

public class TeamMemberTargetController : ApiController
{
    public jsonData Post(JObject jObject)
    {
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;
        string TWE_Id = json.TWE_Id;
        string Weekinfo = json.Weekinfo;
        string fromdate = json.fromdate;
        string todate = json.todate;
        string strtype = json.strtype;
        string prevfromdate = json.prevfromdate;
        string prevtodate = json.prevtodate;
        string tablename = json.tablename;

        _json.d = _in.getTeammemberTargetdetails(TWE_Id, Weekinfo, fromdate, todate, strtype, prevfromdate, prevtodate, tablename);

        _close = new CloseSQLConnection();
        return _json;
    }
}

public class TeamMemberFeedbackIndiaController : ApiController
{
    public jsonData Post(JObject jObject)
    {
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;
        string TWE_Id = json.TWE_Id;
        string stdate = json.stdate;
        string etdate = json.etdate;
        string type = json.type;

        List<string> Weekinfo = new List<string>();
        try
        {
            for (int i = 0; i < json.Weekinfo.Count; i++)
            {
                string s1 = json.Weekinfo[i];
                Weekinfo.Add(s1.ToString());
            }
            
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex);
        }

        _json.d = _in.getTeammemberFeedbackgivendetailsIndia(TWE_Id, Weekinfo, stdate, etdate,type);

        _close = new CloseSQLConnection();
        return _json;
    }
}

public class TeamMemberFeedbackController : ApiController
{
    public jsonData Post(JObject jObject)
    {
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;
        string TWE_Id = json.TWE_Id;
        string stdate = json.stdate;
        string etdate = json.etdate;
        string type = json.type;

        List<string> Weekinfo = new List<string>();
        try
        {
            for (int i = 0; i < json.Weekinfo.Count; i++)
            {
                string s1 = json.Weekinfo[i];
                Weekinfo.Add(s1.ToString());
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }

        _json.d = _in.getTeammemberFeedbackgivendetails(TWE_Id, Weekinfo, stdate, etdate, type);

        _close = new CloseSQLConnection();
        return _json;
    }
}

public class EmailIDCheckController : ApiController
{
    public jsonData Post(JObject jObject)
    {
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;
        string emailid = json.emailid;

        _json.d = _in.checkEmaildata(emailid);

        _close = new CloseSQLConnection();
        return _json;
    }
}

public class updatePasswordController : ApiController
{
    public jsonData Post(JObject jObject)
    {
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;
        string TWE_ID = json.TWE_ID;
        string Newpsw = json.newpsw;

        _json.d = _in.updatePassword(TWE_ID, Newpsw);
        _close = new CloseSQLConnection();
        return _json;
    }

}

public class CandidateClosureListController : ApiController
{
    public jsonData Post(JObject jObject)
    {
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;
        string TWE_Id = json.TWE_Id;
        _json.d = _in.getCandidateClosureListDetails(TWE_Id);

        _close = new CloseSQLConnection();
        return _json;
    }

}


public class CandidateClosureListIndiaController : ApiController
{
    public jsonData Post(JObject jObject)
    {
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;
        string TWE_Id = json.TWE_Id;
        _json.d = _in.getCandidateClosureListIndiaDetails(TWE_Id);

        _close = new CloseSQLConnection();
        return _json;
    }


}


public class QuestionHeadingController : ApiController
{
    public jsonData post(JObject jObject)
    {
       
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;
        questionheading objques = new questionheading();
        objques.QuestionHeadingid = json.question.QuestionHeadingid;
        objques.QuestionHeadingname = json.question.QuestionHeadingname;
        objques.OutofMark = json.question.OutofMark;
        objques.Regionid = json.question.Regionid;
        objques.Status = json.question.Status;

        _json.d = _in.insertQuestionheadingmaster(objques);

        _close = new CloseSQLConnection();
        return _json;
    }
}

public class QuestionHeadingdetailsController : ApiController
{
    public jsonData Post(JObject jObject)
    {
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;

        string id = json.id;

        _json.d = _in.getQuestionHeadingdetails(id);
        _close = new CloseSQLConnection();
        return _json;
    }
}

public class QuestiondetailsController : ApiController
{
    public jsonData Post(JObject jObject)
    {
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;

        string id = json.id;

        _json.d = _in.getQuestiondetails(id);
        _close = new CloseSQLConnection();
        return _json;
    }
}

public class GenuinityQuestiondetailsController : ApiController
{
    public jsonData Post(JObject jObject)
    {
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;

        string regionid = json.regionid;

        _json.d = _in.getGenuinityQuestionlistdetails(regionid);
        _close = new CloseSQLConnection();
        return _json;
    }
}

public class SuperAdminQueHeadingMasterController : ApiController
{
    public object Post(JObject jObject)
    {
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;
        question objque = new question();
        objque.Questionid = json.question.Questionid;
        objque.QuestionHeadingid = json.question.QuestionHeadingid;
        objque.Question = json.question.Question;
        objque.Answer = json.question.Answer;
        objque.Mark = json.question.Mark;
        objque.Status = json.question.Status;


        _json.d = _in.insertQuestionmaster(objque);

        _close = new CloseSQLConnection();
        return _json;
    }
}

public class SuperAdminTotalCalculationController : ApiController
{
    public object Post(JObject jObject)
    {
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;
        string QuestionHeadingid = json.QuestionHeadingid;


        _json.d = _in.getTotalMarks(QuestionHeadingid);

        _close = new CloseSQLConnection();
        return _json;
    }
}

public class saveGenuinityCheckController : ApiController
{
    public object Post(JObject jObject)
    {
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;
        candidateGenuinityCheck objque = new candidateGenuinityCheck();
        GenuinityCheckRating genuinityCheck = new GenuinityCheckRating();
        objque.genuinityChecks = new List<GenuinityCheckQuestion>();
        objque.mode = json.mode;
        objque.mailid = json.mailid;


        for (int i = 0; i < json.GenuinityArr.Count; i++)
        {
            GenuinityCheckQuestion genuinity = new GenuinityCheckQuestion();
            genuinity.QuestionHeadingid = json.GenuinityArr[i].QuestionHeadingId;
            genuinity.Questionid = json.GenuinityArr[i].Questionid;
            genuinity.Answer = json.GenuinityArr[i].Answer;
            genuinity.Comments = json.GenuinityArr[i].Comments;
            objque.genuinityChecks.Add(genuinity);
        }
               
        genuinityCheck.LinkedInrating = json.objRating.LinkedInrating;
        genuinityCheck.Visarating = json.objRating.Visarating;
        genuinityCheck.Educationrating = json.objRating.Educationrating;
        genuinityCheck.Overallsystemrating = json.objRating.Overallsystemrating;
        genuinityCheck.Overallrecruiterrating = json.objRating.Overallrecruiterrating;
        genuinityCheck.Remarks = json.objRating.Remarks;

        objque.genuinityCheckRating = genuinityCheck;

        _json.d = _in.insertGenuinityCheck(objque);

        _close = new CloseSQLConnection();
        return _json;
    }
}

public class getCandidateGenuinityQuestionController : ApiController
{
    public jsonData Post(JObject jObject)
    {
        CloseSQLConnection _close = new CloseSQLConnection();
        Cls_login _in = new Cls_login();
        jsonData _json = new jsonData();
        dynamic json = jObject;

        string candidateid = json.candidateid;

        _json.d = _in.getGenuinityCandidatedetails(candidateid);
        _close = new CloseSQLConnection();
        return _json;
    }
}