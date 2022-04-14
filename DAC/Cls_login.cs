using Recruiting_API.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace Recruiting_API.DAC
{
    public class Cls_login
    {

        TSql _sql = null;
        public Cls_login()
        {
            _sql = new TSql();
        }


        //public jsonArray getUserdetails(string Usernmae, string Password)
        //{
        //    int status = 1;
        //    string EncryptPSW = Encrypt(Password);
        //    dashboard _db = new dashboard();
        //    string strquery = @"select TWE_ID,UP_firstName+' '+UP_lastName EmpName,UP_MT_region,UP_mailid,UP_MT_designation from Userprofile where UP_userName='" + Usernmae + "' and UP_Password='" + EncryptPSW + "' ";

        //    SqlDataReader _read = _sql.doRead(strquery);
        //    while (_read.Read())
        //    {
        //        _db.TWE_ID = _read[0].ToString();
        //        _db.name = _read[1].ToString();
        //        _db.region = _read[2].ToString();
        //        _db.emailid = _read[3].ToString();
        //        _db.designation = _read[4].ToString();
        //    }

        //    jsonArray _json = new jsonArray();
        //    if (status == 0)
        //    {

        //        _json.status = "0";
        //        _json.message = "SQL QUERY EXECUTION FAILED";
        //        _json.data = new object();
        //    }
        //    else
        //    {
        //        _json = new jsonArray();
        //        _json.status = "1";
        //        _json.message = "SQL QUERY EXECUTED";
        //        _json.data = _db;
        //    }


        //    return _json;
        //}

        /**User permission**/
        public jsonArray getUserdetails(string Username, string Password)
        {
            int status = 1;
            string EncryptPSW = Encrypt(Password);
            string psw="";
           
            dashboard _db = new dashboard();
            string strquery = @"select TWE_ID,firstname +' '+lastName EmpName,region,emailid,role,
                                jobaccess,jobCreation,jobEdit,jobView,jobFeedback,
                                candidateAccess,candidateCreation,candidateEdit,candidateView,
                                vendorAccess,vendorCreation,vendorEdit,vendorView,Rolename
                                from Userprofilecreation up
                                join UserAccessPower ua on up.TWE_ID=ua.userid
                                join RoleMaster rol on rol.Roleid=up.role
                                and up.status=1 where accountusername='" + Username + "' and accountpassword='" + EncryptPSW + "' ";

            SqlDataReader _read = _sql.doRead(strquery);
            while (_read.Read())
            {
                _db.TWE_ID = _read[0].ToString();
                _db.name = _read[1].ToString();
                _db.region = _read[2].ToString();
                _db.emailid = _read[3].ToString();
                _db.designation = _read[4].ToString();
                _db.jobAccess = _read[5].ToString();
                _db.jobCreation = _read[6].ToString();
                _db.jobEdit = _read[7].ToString();
                _db.jobView = _read[8].ToString();
                _db.jobFeedback = _read[9].ToString();
                _db.candidateAccess = _read[10].ToString();
                _db.candCreation = _read[11].ToString();
                _db.candEdit = _read[12].ToString();
                _db.candView = _read[13].ToString();
                _db.vendorAccess = _read[14].ToString();
                _db.vendCreation = _read[15].ToString();
                _db.vendEdit = _read[16].ToString();
                _db.vendView = _read[17].ToString();
                _db.rolename = _read[18].ToString();
            }
            _read.Close();

            strquery = @"select accountpassword from Userprofilecreation where TWE_ID='" + Username + "'";


            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                psw = _read[0].ToString();
            }


            var psw1 = Decrypt(psw);

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
                _json.data = _db;
            }


            return _json;
        }


        public string Decrypt(string cipherText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            if (cipherText != null)
            {
                byte[] cipherBytes = Convert.FromBase64String(cipherText);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.Close();
                        }
                        cipherText = Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
            }

            return cipherText;
        }

        public string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
        public jsonArray getTimezonedetails()
        {
            dashboardTimer _db = new dashboardTimer();
            _db.Timezonelist = new List<RecruitingTimeZone>();

            int status = 1;
            DateTime dateTime_Eastern = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));
            DateTime dateTime_Indian = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));

            var timeInEST = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));
            var timeInEasternAsString = timeInEST.ToString("hh:mm tt", CultureInfo.InvariantCulture);

            var timeInCST = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time"));
            var timeInCentralAsString = timeInCST.ToString("hh:mm tt", CultureInfo.InvariantCulture);

            var timeInMST = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Mountain Standard Time"));
            var timeInMountainAsString = timeInMST.ToString("hh:mm tt", CultureInfo.InvariantCulture);

            var timeInPST = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time"));
            var timeInPacificAsString = timeInPST.ToString("hh:mm tt", CultureInfo.InvariantCulture);


            var timeInHST = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Hawaiian Standard Time"));
            var timeInHawaiiAsString = timeInHST.ToString("hh:mm tt", CultureInfo.InvariantCulture);

            var timeInAST = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Alaskan Standard Time"));
            var timeInAlaskaAsString = timeInAST.ToString("hh:mm tt", CultureInfo.InvariantCulture);


            var timeInIndia = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
            var timeInIndiaAsString = timeInIndia.ToString("hh:mm tt", CultureInfo.InvariantCulture);

            RecruitingTimeZone objTime = new RecruitingTimeZone();


            objTime.TimeZoneName = "Eastern";
            objTime.TimeZoneDay = dateTime_Eastern.DayOfWeek.ToString();
            objTime.TimeZoneDate = dateTime_Eastern.ToString("dd MMM yyyy");
            objTime.TimeZoneTime = timeInEasternAsString;
            _db.Timezonelist.Add(objTime);

            objTime = new RecruitingTimeZone();
            objTime.TimeZoneName = "Central";
            objTime.TimeZoneDay = dateTime_Eastern.DayOfWeek.ToString();
            objTime.TimeZoneDate = dateTime_Eastern.ToString("dd MMM yyyy");
            objTime.TimeZoneTime = timeInCentralAsString;
            _db.Timezonelist.Add(objTime);

            objTime = new RecruitingTimeZone();
            objTime.TimeZoneName = "Pacific";
            objTime.TimeZoneDay = dateTime_Eastern.DayOfWeek.ToString();
            objTime.TimeZoneDate = dateTime_Eastern.ToString("dd MMM yyyy");
            objTime.TimeZoneTime = timeInPacificAsString;
            _db.Timezonelist.Add(objTime);

            objTime = new RecruitingTimeZone();
            objTime.TimeZoneName = "Mountain";
            objTime.TimeZoneDay = dateTime_Eastern.DayOfWeek.ToString();
            objTime.TimeZoneDate = dateTime_Eastern.ToString("dd MMM yyyy");
            objTime.TimeZoneTime = timeInMountainAsString;
            _db.Timezonelist.Add(objTime);

            objTime = new RecruitingTimeZone();
            objTime.TimeZoneName = "Alaska";
            objTime.TimeZoneDay = dateTime_Eastern.DayOfWeek.ToString();
            objTime.TimeZoneDate = dateTime_Eastern.ToString("dd MMM yyyy");
            objTime.TimeZoneTime = timeInAlaskaAsString;
            _db.Timezonelist.Add(objTime);

            objTime = new RecruitingTimeZone();
            objTime.TimeZoneName = "Hawaii";
            objTime.TimeZoneDay = dateTime_Eastern.DayOfWeek.ToString();
            objTime.TimeZoneDate = dateTime_Eastern.ToString("dd MMM yyyy");
            objTime.TimeZoneTime = timeInHawaiiAsString;
            _db.Timezonelist.Add(objTime);

            objTime = new RecruitingTimeZone();
            objTime.TimeZoneName = "India";
            objTime.TimeZoneDay = dateTime_Indian.DayOfWeek.ToString();
            objTime.TimeZoneDate = dateTime_Indian.ToString("dd MMM yyyy");
            objTime.TimeZoneTime = timeInIndiaAsString;
            _db.Timezonelist.Add(objTime);


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
                _json.data = _db;
            }

            return _json;
        }
        //public jsonArray getJobdetails(string TWE_Id, string fromdate, string todate, string tiletype)
        //{
        //    int status = 1;

        //    JobMaster _db = new JobMaster();
        //    _db.lstJob = new List<JobcodeList>();
        //    _db.lsttiles = new List<tiles>();

        //    string strquery = @"select * from
        //                    (select count(*) open_jobs from Job_Master_USA
        //                    where Assigned_To like '%" + TWE_Id + "%' " +
        //                    " and Jobstatus='10200'" +
        //                    ") tb1,(" +
        //                    "select count(*) pipeline_jobs from Job_Master_USA job" +
        //                    " join CandidateJob canjob on canjob.Jobcode=job.Jobcode	" +
        //                    "join CandidateDetails can on canjob.CandidateId = can.candidateid" +
        //                    " where Assigned_To like '%" + TWE_Id + "%' " +
        //                    "and can.Created_On between '" + fromdate + "' and '" + todate + "'" +
        //                    " and Cand_Status='102'" +
        //                    ") tb2,(" +
        //                    "select count(*) High_jobs from Job_Master_USA job" +
        //                    " where Assigned_To like '%" + TWE_Id + "%' " +
        //                    "and Created_On between '" + fromdate + "' and '" + todate + "'" +
        //                    " and Prioritylevel='10300'" +
        //                    ") tb3,(" +
        //                    "select count(*) Nosubmission_jobs from CandidateJob can" +
        //                    " where jobcode not in (select Jobcode from Job_Master_USA where Assigned_To like '%" + TWE_Id + "%' and Jobstatus='10200'" +
        //                    " and Created_On between '" + fromdate + "' and '" + todate + "')" +
        //                    " and Created_By like '%" + TWE_Id + "%' " +
        //                    " and Created_On between '" + fromdate + "' and '" + todate + "'" +
        //                    ") tb4,(" +
        //                    "select count(*) interview_jobs from Job_Master_USA job" +
        //                    " join CandidateJob canjob on canjob.Jobcode=job.Jobcode" +
        //                    " join CandidateDetails can on canjob.CandidateId = can.candidateid" +
        //                    " where Assigned_To like '%" + TWE_Id + "%' " +
        //                    " and can.Created_On between '" + fromdate + "' and '" + todate + "'" +
        //                    " and Cand_Status in ('110','111')" +
        //                    ") tb5,(" +
        //                    "select count(*) closure_jobs from Job_Master_USA job" +
        //                    " join CandidateJob canjob on canjob.Jobcode=job.Jobcode" +
        //                    " join CandidateDetails can on canjob.CandidateId = can.candidateid" +
        //                    " where Assigned_To like '%" + TWE_Id + "%' " +
        //                    " and can.Created_On between '" + fromdate + "' and '" + todate + "'" +
        //                    " and Cand_Status in ('109')" +
        //                     ") tb6," +
        //                    "(select count(*) total_jobs from Job_Master_USA" +
        //                    " where Assigned_To like '%" + TWE_Id + "%' " +
        //                    " and Created_On between '" + fromdate + "' and '" + todate + "'" +
        //                    ") tb7";


        //    SqlDataReader _read = _sql.doRead(strquery);

        //    while (_read.Read())
        //    {
        //        tiles objTile1 = new tiles();
        //        objTile1.TileTitle = "Open Jobs";
        //        objTile1.TotalCount = _read[0].ToString();
        //        _db.lsttiles.Add(objTile1);

        //        tiles objTile2 = new tiles();
        //        objTile2.TileTitle = "Pipeline";
        //        objTile2.TotalCount = _read[1].ToString();
        //        _db.lsttiles.Add(objTile2);

        //        tiles objTile3 = new tiles();
        //        objTile3.TileTitle = "High Priority";
        //        objTile3.TotalCount = _read[2].ToString();
        //        _db.lsttiles.Add(objTile3);

        //        tiles objTile4 = new tiles();
        //        objTile4.TileTitle = "No Submission";
        //        objTile4.TotalCount = _read[3].ToString();
        //        _db.lsttiles.Add(objTile4);

        //        tiles objTile5 = new tiles();
        //        objTile5.TileTitle = "Interview";
        //        objTile5.TotalCount = _read[4].ToString();
        //        _db.lsttiles.Add(objTile5);

        //        tiles objTile6 = new tiles();
        //        objTile6.TileTitle = "Closure";
        //        objTile6.TotalCount = _read[5].ToString();
        //        _db.lsttiles.Add(objTile6);

        //        tiles objTile7 = new tiles();
        //        objTile7.TileTitle = "Total Jobs";
        //        objTile7.TotalCount = _read[6].ToString();
        //        _db.lsttiles.Add(objTile7);

        //    }

        //    _read.Close();

        //    List<Jobcode> lstJob = new List<Jobcode>();

        //    strquery = @"select Jobcode from Job_Master_USA where Assigned_To like '%" + TWE_Id + "%' and Jobstatus='10200'";


        //    _read = _sql.doRead(strquery);

        //    while (_read.Read())
        //    {
        //        Jobcode obj = new Jobcode();
        //        obj.Jobcodename = _read[0].ToString();
        //        lstJob.Add(obj);
        //    }

        //    _read.Close();

        //    string strVar = "";

        //    if (lstJob.Count != 0)
        //    {
        //        for (int i = 0; i < lstJob.Count; i++)
        //        {
        //            strVar += "'" + lstJob[i].Jobcodename + "',";
        //        }

        //        strVar = strVar.Substring(0, strVar.Length - 1);

        //        strquery = @"select count(distinct Jobcode) Nosubmission_jobs from CandidateJob can where jobcode in (" + strVar + ")";

        //        _read = _sql.doRead(strquery);


        //        while (_read.Read())
        //        {
        //            tiles objTile4 = new tiles();
        //            objTile4.TileTitle = "Nil Submissions";
        //            objTile4.TotalCount = (lstJob.Count - Convert.ToInt32(_read[0])).ToString();
        //            _db.lsttiles.Add(objTile4);

        //        }
        //        _read.Close();
        //    }

        //    else
        //    {
        //        tiles objTile4 = new tiles();
        //        objTile4.TileTitle = "Nil Submissions";
        //        objTile4.TotalCount = "0";
        //        _db.lsttiles.Add(objTile4);
        //    }

        //    if (tiletype == "Open")
        //    {
        //        strquery = @"select Jobcode,JobTitle,Duration,empl.EmpTypeName,City,State,
        //                        stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
        //                        convert(varchar,job.Created_On,106) Created_On,Jobimage from Job_Master_USA job
        //                        join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
        //                        join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
        //                        join ClientMaster cli on cli.ClientID=job.Clientname
        //                        join Client_Contact_Person con on con.ClientContactID =job.Contactname
        //                        where Assigned_To like '%" + TWE_Id + "%'" + " and Jobstatus='10200' order by job.Created_On desc";
        //    }

        //    else if (tiletype == "Pipeline")
        //    {
        //        strquery = @"select job.Jobcode,JobTitle,Duration,empl.EmpTypeName,City,State,
        //                        stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
        //                        convert(varchar, job.Created_On, 106) Created_On,Jobimage from Job_Master_USA job
        //                        join EmploymentType_Master empl on empl.EmpTypeID = job.EmplType
        //                        join Jobstatus_Master stat on stat.JobstatusID = job.Jobstatus
        //                        join ClientMaster cli on cli.ClientID = job.Clientname
        //                        join Client_Contact_Person con on con.ClientContactID =job.Contactname                
        //                        join CandidateJob canjob on job.Jobcode=canjob.Jobcode                  
        //                        join CandidateDetails can on can.candidateid = canjob.CandidateId
        //                        where Assigned_To like '%" + TWE_Id + "%' and can.Created_On between '" + fromdate + "' and '" + todate + "'" +
        //                        " and Cand_Status = '102' order by job.Created_On desc";
        //    }

        //    else if (tiletype == "High Priority")
        //    {
        //        strquery = @"select Jobcode,JobTitle,Duration,empl.EmpTypeName,City,State,
        //                        stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
        //                        convert(varchar,job.Created_On,106) Created_On,Jobimage from Job_Master_USA job
        //                        join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
        //                        join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
        //                        join ClientMaster cli on cli.ClientID=job.Clientname
        //                        join Client_Contact_Person con on con.ClientContactID =job.Contactname
        //                        where Assigned_To like '%" + TWE_Id + "%' and job.Created_On between '" + fromdate + "' and '" + todate + "'" +
        //                        " and Prioritylevel='10300' order by job.Created_On desc";
        //    }

        //    else if (tiletype == "No Submission")
        //    {
        //        strquery = @"select job.Jobcode,JobTitle,Duration,empl.EmpTypeName,City,State,
        //                    stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
        //                    convert(varchar,job.Created_On,106) Created_On,Jobimage from Job_Master_USA job
        //                    left join CandidateJob canjob on job.Jobcode=canjob.Jobcode                  
        //                    left join CandidateDetails can on can.candidateid = canjob.CandidateId
        //                    join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
        //                    join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
        //                    join ClientMaster cli on cli.ClientID=job.Clientname
        //                    join Client_Contact_Person con on con.ClientContactID =job.Contactname
        //                    group by job.Jobcode,Assigned_To,job.Created_on,JobTitle,Duration,empl.EmpTypeName,City,State,
        //                    stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,Jobimage
        //                    having Assigned_To like '%" + TWE_Id + "%' and " +
        //                    //"job.Created_on between '" + fromdate + "' and '" + todate + "' and " +
        //                    "count(canjob.candidateid)=0  order by job.Created_On desc";
        //    }

        //    else if (tiletype == "Interview")
        //    {
        //        strquery = @"select job.Jobcode,JobTitle,Duration,empl.EmpTypeName,City,State,
        //                        stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
        //                        convert(varchar,job.Created_On,106) Created_On,Jobimage from Job_Master_USA job
        //                        join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
        //                        join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
        //                        join ClientMaster cli on cli.ClientID=job.Clientname
        //                        join Client_Contact_Person con on con.ClientContactID =job.Contactname
        //                        join CandidateJob canjob on job.Jobcode=canjob.Jobcode                  
        //                        join CandidateDetails can on can.candidateid = canjob.CandidateId
        //                        where Assigned_To like '%" + TWE_Id + "%' and can.Created_On between '" + fromdate + "' and '" + todate + "'" +
        //                        " and Cand_Status in ('110','111') order by job.Created_On desc";
        //    }
        //    else if (tiletype == "Follow Up")
        //    {
        //        strquery = @"select job.Jobcode,JobTitle,Duration,empl.EmpTypeName,City,State,
        //                        stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
        //                        convert(varchar,job.Created_On,106) Created_On,Jobimage from Job_Master_USA job
        //                        join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
        //                        join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
        //                        join ClientMaster cli on cli.ClientID=job.Clientname
        //                        join Client_Contact_Person con on con.ClientContactID =job.Contactname
        //                        join CandidateJob canjob on job.Jobcode=canjob.Jobcode                  
        //                        join CandidateDetails can on can.candidateid = canjob.CandidateId
        //                        where Assigned_To like '%" + TWE_Id + "%' and can.Created_On between '" + fromdate + "' and '" + todate + "'" +
        //                        " and  Cand_Status in ('103','105','107','110','111') and Jobstatus not in ('10201') order by job.Created_On desc";
        //    }
        //    else if (tiletype == "Total")
        //    {
        //        strquery = @"select Jobcode,JobTitle,Duration,empl.EmpTypeName,City,State,
        //                        stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
        //                        convert(varchar,job.Created_On,106) Created_On,Jobimage from Job_Master_USA job
        //                        join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
        //                        join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
        //                        join ClientMaster cli on cli.ClientID=job.Clientname
        //                        join Client_Contact_Person con on con.ClientContactID =job.Contactname
        //                        where Assigned_To like '%" + TWE_Id + "%' and job.Created_On between '" + fromdate + "' and '" + todate + "' order by job.Created_On desc";
        //    }
        //    else if (tiletype == "Feedback")
        //    {
        //        strquery = @"select distinct job.Jobcode,JobTitle,Duration,empl.EmpTypeName,City,State,
        //                        stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
        //                        convert(varchar,job.Created_On,106) Created_On,Jobimage from Job_Master_USA job
        //                        join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
        //                        join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
        //                        join ClientMaster cli on cli.ClientID=job.Clientname
        //                        join Client_Contact_Person con on con.ClientContactID =job.Contactname
        //                        join CandidateJob canjob on job.Jobcode=canjob.Jobcode                  
        //                        join CandidateDetails can on can.candidateid = canjob.CandidateId
        //                        where job.Created_By like '%" + TWE_Id + "%'" +
        //                        "--and can.Created_On between '" + fromdate + "' and '" + todate + "'" +
        //                        " and  Cand_Status in ('103','105','107','110','111') and Jobstatus not in ('10201') order by job.Created_On desc";
        //    }

        //    _read = _sql.doRead(strquery);

        //    while (_read.Read())
        //    {
        //        JobcodeList objJob = new JobcodeList();

        //        objJob.Jobcode = _read[0].ToString();
        //        objJob.JobTitle = _read[1].ToString();
        //        objJob.JobDuration = _read[2].ToString();
        //        objJob.JobType = _read[3].ToString();
        //        objJob.JobCity = _read[4].ToString();
        //        objJob.JobState = _read[5].ToString();
        //        objJob.JobStatus = _read[6].ToString();
        //        objJob.JobClient = _read[7].ToString();
        //        objJob.JobContact = _read[8].ToString();
        //        objJob.CreatedOn = _read[9].ToString();
        //        objJob.JobMediaPath = _read[10].ToString();
        //        _db.lstJob.Add(objJob);
        //    }

        //    _read.Close();


        //    jsonArray _json = new jsonArray();
        //    if (status == 0)
        //    {
        //        _json.status = "0";
        //        _json.message = "SQL QUERY EXECUTION FAILED";
        //        _json.data = new object();
        //    }
        //    else
        //    {
        //        _json = new jsonArray();
        //        _json.status = "1";
        //        _json.message = "SQL QUERY EXECUTED";
        //        _json.data = _db;
        //    }

        //    return _json;
        //}

        public jsonArray getRecrutingdashboarddetails(string TWE_id, string fromdate, string todate, string strType)
        {
            Recrutingdashboard _rd = new Recrutingdashboard();
            List<tiles> _lsttls = new List<tiles>();
            List<holdresumetiles> _lsthrt = new List<holdresumetiles>();
            List<statuscount> _lststc = new List<statuscount>();
            List<performanceoverview> _lstpov = new List<performanceoverview>();
            List<recruitmenttable> _lstrt = new List<recruitmenttable>();
            List<barchartlist> _lstbar = new List<barchartlist>();
            List<linechartlist> _lstline = new List<linechartlist>();

            int status = 1;
            string strquery = "";
            string strtype = strType;
            _rd.TWE_id = TWE_id;
            //strquery = @"select UP_firstName,''mediapath from Userprofile where TWE_ID='" + TWE_id + "'";

            strquery = @"select firstName,role,''mediapath from Userprofilecreation where TWE_ID='" + TWE_id + "'";

            SqlDataReader _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                _rd.UserName = _read[0].ToString();
                _rd.Roleid = _read[1].ToString();
                _rd.UserProfile = _read[2].ToString();
            }
            _read.Close();


            _rd.DateRange = "03 june 2021 to 10 june 2021";

            strquery = @"select tb1.t1,tb1.tt1,tb1.Total_jobs,tb2.tt2,tb2.Active_jobs from
                        (select '1't1,'Total Jobs'tt1, count(*) Total_jobs from Job_Master_USA where Created_On between '" + fromdate + "' and '" + todate + "' and Assigned_To like '%" + TWE_id + "%') tb1," +
                        "(select 'Active' tt2,count(*) Active_jobs from Job_Master_USA where Created_On between '" + fromdate + "' and '" + todate + "' and Jobstatus='10200'  and Assigned_To like '%" + TWE_id + "%') tb2 union select tb3.t2,tb3.tt3,tb3.Active_vendors,tb8.tt4,tb8.New_vendors " +
                        "from(select '2't2,'Vendors'tt3,count(distinct empl.employerid) Active_vendors from EmployerDetails empl" +
                        " join employercontactperson con on empl.employerid = con.VendorID where empl.Created_On between '" + fromdate + "' and '" + todate + "'  and empl.Created_By like '%" + TWE_id + "%') tb3,(select 'Active'tt4,count(distinct empl.employerid) New_vendors from EmployerDetails empl" +
                        " join employercontactperson con on empl.employerid = con.VendorID  " +
                        " where empl.Created_On between '" + fromdate + "' and '" + todate + "' and Status='1' and empl.Created_By like '%" + TWE_id + "%') tb8  union select tb4.t3,tb4.tt5,tb4.Resumeinprocess,tb5.tt6,tb5.EC_Selected from(select '3't3,'Candidates'tt5,count(*) Resumeinprocess from CandidateDetails can" +
                        " join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                        " left join Job_Master_USA job on job.Jobcode=canjob.Jobcode" +
                        " where can.Created_On between '" + fromdate + "' and '" + todate + "' and can.Created_By like '%" + TWE_id + "%')tb4,(select 'Client'tt6,count(*) EC_Selected from CandidateDetails can join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                        " join Job_Master_USA job on job.Jobcode=canjob.Jobcode where Cand_Status in ('107','108','111') and can.Created_On between '" + fromdate + "' and '" + todate + "'and can.Created_By like '%" + TWE_id + "%')tb5 union select tb6.t4,tb6.tt7,tb6.Onboarded,tb7.tt8,tb7.ResumesinHold  from(select '4't4,'Made Closure'tt7,count(*) Onboarded from CandidateDetails can join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                        " join Job_Master_USA job on job.Jobcode=canjob.Jobcode where Cand_Status in ('109') and can.Created_On between '" + fromdate + "' and '" + todate + "' and can.Created_By like '%" + TWE_id + "%')tb6,(select 'On Live'tt8,'0' ResumesinHold)tb7";


            //" join Job_Master_USA job on job.Jobcode=canjob.Jobcode where Cand_Status in ('109') and can.Created_On between '" + fromdate + "' and '" + todate + "' and can.Created_By like '%" + TWE_id + "%')tb6,(select 'On Live'tt8,'0' ResumesinHold from CandidateDetails can join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
            //            " join Job_Master_USA job on job.Jobcode=canjob.Jobcode where Cand_Status in ('105' ,'107','110') and can.Created_On between '" + fromdate + "' and '" + todate + "'and can.Created_By like '%" + TWE_id + "%')tb7";

            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                tiles _tls = new tiles();
                _tls.TileTitle = _read[1].ToString();
                _tls.TotalCount = _read[2].ToString();
                _tls.Name = _read[3].ToString();
                _tls.AchiveCount = _read[4].ToString();
                _lsttls.Add(_tls);
            }

            _read.Close();
            _rd.Tiles = _lsttls;          

            if (_rd.Roleid=="4001")
            {
                strquery = @"select count(*) Feedbackcount from CandidateDetails can join CandidateJob canjob on can.candidateid=canjob.CandidateId
                            join Job_Master_USA job on job.Jobcode=canjob.Jobcode where Cand_Status  in ('103','105' ,'107','110','111') and can.Created_On between '" + 
                            fromdate + "' and '" + todate + "' and  can.Created_By like '%" + TWE_id + "%' and Jobstatus != 10201";

                _read = _sql.doRead(strquery);

                while (_read.Read())
                {
                    holdresumetiles _hrt = new holdresumetiles();
                    _hrt.FirstHeading = "Resumes On Hold";
                    _hrt.SecondHeading = "Get Feedback Now";
                    _hrt.ThirdHeading = "Making follow-ups will give successful closures.";
                    _hrt.Count = _read[0].ToString();
                    _lsthrt.Add(_hrt);
                }
                _read.Close();
            }
            else if (_rd.Roleid == "4000" || _rd.Roleid == "4002" || _rd.Roleid == "4004")
            {

                strquery = @"select count(*) Feedbackcount from CandidateDetails can join CandidateJob canjob on can.candidateid=canjob.CandidateId
                            join Job_Master_USA job on job.Jobcode=canjob.Jobcode where Cand_Status  in ('103','105' ,'107','110','111') and can.Created_On between '" +
                           fromdate + "' and '" + todate + "' and  can.Created_By like '%" + TWE_id + "%' and Jobstatus != 10201";

                _read = _sql.doRead(strquery);

                while (_read.Read())
                {
                    holdresumetiles _hrt = new holdresumetiles();
                    _hrt.FirstHeading = "Resumes On Hold";
                    _hrt.SecondHeading = "Get Feedback Now";
                    _hrt.ThirdHeading = "Making follow-ups will give successful closures.";
                    _hrt.Count = _read[0].ToString();
                    _lsthrt.Add(_hrt);
                }
                _read.Close();

                

                strquery = @"select count(*) Feedbackcount from CandidateDetails can join CandidateJob canjob on can.candidateid=canjob.CandidateId
                            join Job_Master_USA job on job.Jobcode=canjob.Jobcode where Cand_Status  in ('103','105' ,'107','110','111') and can.Created_On between '" + 
                            fromdate + "' and '" + todate + "' and  ( job.Created_By like '%" + TWE_id + "%' or job.Assigned_To like '%" + TWE_id + "%') and Jobstatus != 10201";

                _read = _sql.doRead(strquery);

                while (_read.Read())
                {
                    holdresumetiles _hrt = new holdresumetiles();
                    _hrt.FirstHeading = "Resumes On Hold";
                    _hrt.SecondHeading = "Give Feedback Now";
                    _hrt.ThirdHeading = "Making follow-ups will give successful closures.";
                    _hrt.Count = _read[0].ToString();
                    _lsthrt.Add(_hrt);
                }
                _read.Close();
            }           
                     

            _rd.HoldResumeTiles = _lsthrt;

            string[] lstSub = new string[5];
            strquery = @"select tb1.Submitted_Mon,tb3.Submitted_Tue,
                                tb5.Submitted_Wed,tb7.Submitted_Thu,tb9.Submitted_Fri from
                                (select count(*) Submitted_Mon from CandidateDetails can join CandidateJob canjob on can.candidateid=canjob.CandidateId
                                join Job_Master_USA job on job.Jobcode=canjob.Jobcode where Cand_Status in ('103') and can.Created_By='" + TWE_id + "' and can.Created_On between '" + fromdate + "' and '" + todate + "') tb1," +
                                "(select count(*) Submitted_Tue from CandidateDetails can join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                                " join Job_Master_USA job on job.Jobcode = canjob.Jobcode where Cand_Status in ('103') and can.Created_By='" + TWE_id + "' and can.Created_On between '" + fromdate + "' and '" + todate + "') tb3," +
                                "(select count(*) Submitted_Wed from CandidateDetails can join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                                " join Job_Master_USA job on job.Jobcode = canjob.Jobcode where Cand_Status in ('103') and can.Created_By='" + TWE_id + "' and can.Created_On between '" + fromdate + "' and '" + todate + "') tb5," +
                                "(select count(*) Submitted_Thu from CandidateDetails can join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                                " join Job_Master_USA job on job.Jobcode = canjob.Jobcode where Cand_Status in ('103') and can.Created_By='" + TWE_id + "' and can.Created_On between '" + fromdate + "' and '" + todate + "') tb7," +
                                "(select count(*) Submitted_Fri from CandidateDetails can join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                                " join Job_Master_USA job on job.Jobcode = canjob.Jobcode where Cand_Status in ('103') and can.Created_By='" + TWE_id + "' and can.Created_On between '" + fromdate + "' and '" + todate + "') tb9";
            _read = _sql.doRead(strquery);
            while (_read.Read())
            {
                lstSub[0] = _read[0].ToString();
                lstSub[1] = _read[1].ToString();
                lstSub[2] = _read[2].ToString();
                lstSub[3] = _read[3].ToString();
                lstSub[4] = _read[4].ToString();
            }
            _read.Close();

            //Bar Chart Query
            if (strtype == "Monthly")
            {
                strquery = @"select count(*) CandCount,Substring(Datename(mm,(can.Created_On)),0,4) MonName from CandidateDetails can
                                        join CandidateJob canjob on can.candidateid=canjob.CandidateId
                                        join Job_Master_USA job on job.Jobcode=canjob.Jobcode
                                        where Cand_Status in ('103')
                                        and can.Created_By='" + TWE_id + "' and can.Created_On between '" + fromdate + "' and '" + todate +
                                        "' group by Datename(mm,(can.Created_On))";
            }
            else if (strtype == "Daily")
            {
                strquery = @"select count(*) CandCount,Substring(Datename(Weekday,can.Created_On),0,4) dyName from CandidateDetails can
                                        join CandidateJob canjob on can.candidateid=canjob.CandidateId
                                        join Job_Master_USA job on job.Jobcode=canjob.Jobcode
                                        where Cand_Status in ('103')
                                        and can.Created_By='" + TWE_id + "' and can.Created_On between '" + fromdate + "' and '" + todate +
                                        "' group by  Datename(Weekday,can.Created_On)";
            }
            else if (strtype == "Weekly")
            {
                strquery = @"select count(*) CandCount, 'Week '+ Convert(varchar,DATEPART(week,can.Created_On)) WkName from CandidateDetails can
                                        join CandidateJob canjob on can.candidateid=canjob.CandidateId
                                        join Job_Master_USA job on job.Jobcode=canjob.Jobcode
                                        where Cand_Status in ('103')
                                        and can.Created_By='" + TWE_id + "' and can.Created_On between '" + fromdate + "' and '" + todate
                                        + "' group by DATEPART(week,can.Created_On)";
            }
            _read = _sql.doRead(strquery);
            while (_read.Read())
            {
                barchartlist _bcl = new barchartlist();
                _bcl.candCount = _read[0].ToString();
                _bcl.itemName = _read[1].ToString();
                _lstbar.Add(_bcl);

            }
            _read.Close();
            string data1 = "";
            if (_lstbar.Count != 0)
            {
                for (int i = 0; i < _lstbar.Count; i++)
                {
                    data1 += _lstbar[i].candCount + ",";
                }
                data1 = data1.Substring(0, data1.Length - 1);
            }

            string data2 = "";
            if (_lstbar.Count != 0)
            {
                for (int i = 0; i < _lstbar.Count; i++)
                {
                    data2 += "'" + _lstbar[i].itemName + "',";
                }
                data2 = data2.Substring(0, data2.Length - 1);
            }

            _rd.Barchart = "<canvas id='chart-bars' class='chart-canvas' height='170px'></canvas>  <script> " +
                        "var ctx = document.getElementById('chart-bars').getContext('2d'); " +
                        "new Chart(ctx, {" +
                        "type: 'bar'," +
                        "data: {" +
                        "labels: [" + data2 + "]," +
                        "datasets: [{" +
                        "label: 'Submissions'," +
                        "tension: 0.4," +
                        "borderWidth: 0," +
                        "pointRadius: 0," +
                        "backgroundColor: '#fff'," +
                        "data: [" + data1 + "]," +
                        "maxBarThickness: 6" +
                        "},]," +
                        "}," +
                        "options:" +
                        "{" +
                        "responsive: true," +
                        "maintainAspectRatio: false," +
                        "legend:" +
                        "{" +
                        "display: false," +
                        "}," +
                        "tooltips:" +
                        "{" +
                        "enabled: true," +
                        "mode: 'index'," +
                        "intersect: false," +
                        "}," +
                        "scales: " +
                        "{" +
                        "yAxes: [{" +
                        "gridLines:" +
                        "{" +
                        "display: false," +
                        "}," +
                        "ticks: " +
                        "{" +
                        "suggestedMin: 0," +
                        "suggestedMax: 5," +
                        "beginAtZero: true," +
                        "padding: 0," +
                        "fontSize: 14," +
                        "lineHeight: 3," +
                        "fontColor: '#fff'," +
                        "fontStyle: 'normal'," +
                        "fontFamily: 'Open Sans'," +
                        "}," +
                        "},]," +
                        "xAxes: [{" +
                        "gridLines: " +
                        "{" +
                        "display: false," +
                        "}," +
                        "ticks: " +
                        "{" +
                        "display: false," +
                        "padding: 20," +
                        "}," +
                        "},]," +
                        "}," +
                        "}," +
                        "}); </script>";
            _rd.BarTitle = "Active Candidates";
            _rd.BarDuration = "Duration for the Week of ";

            strquery = @"select '1't1,'SB'sp,count(*) EC_Selected from CandidateDetails can
                                        join CandidateJob canjob on can.candidateid=canjob.CandidateId
                                        join Job_Master_USA job on job.Jobcode=canjob.Jobcode where Cand_Status in ('101','102') and can.Created_By like '%" + TWE_id + "%' and can.Created_On between '" + fromdate + "' and '" + todate + "'" +
                                        " union " +
                                        "select '2't2,'TL'tl,count(*) EC_Selected from CandidateDetails can" +
                                                " join CandidateJob canjob on can.candidateid = canjob.CandidateId" +
                                                " join Job_Master_USA job on job.Jobcode = canjob.Jobcode where Cand_Status in ('103') and can.Created_By like '%" + TWE_id + "%' and can.Created_On between '" + fromdate + "' and '" + todate + "'" +
                                        " union " +
                                        " select '3't3,'BP'bp,count(*) EC_Selected from CandidateDetails can" +
                                                " join CandidateJob canjob on can.candidateid = canjob.CandidateId" +
                                                " join Job_Master_USA job on job.Jobcode = canjob.Jobcode where Cand_Status in ('105') and can.Created_By like '%" + TWE_id + "%' and can.Created_On between '" + fromdate + "' and '" + todate + "'" +
                                        " union " +
                                        " select '4't4,'EC'ec,count(*) EC_Selected from CandidateDetails can" +
                                                " join CandidateJob canjob on can.candidateid = canjob.CandidateId" +
                                                " join Job_Master_USA job on job.Jobcode = canjob.Jobcode where Cand_Status in ('107') and can.Created_By like '%" + TWE_id + "%' and can.Created_On between '" + fromdate + "' and '" + todate + "'";

            _read = _sql.doRead(strquery);
            while (_read.Read())
            {
                statuscount _sc = new statuscount();
                _sc.StatusTitle = _read[1].ToString();
                _sc.StatusValue = _read[2].ToString();
                _lststc.Add(_sc);

            }
            _rd.StatusCount = _lststc;
            _read.Close();


            if (strtype == "Monthly")
            {
                strquery = @"select 'SB'colname, count(*) Submitted,month(can.Created_On) Monname  from CandidateDetails can" +
                                       " join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                                       " join Job_Master_USA job on job.Jobcode = canjob.Jobcode" +
                                       " where Cand_Status in ('101','102','103','104','105','106','107','108','109','110','111')  and can.Created_By like '%" + TWE_id + "%' " +
                                       " and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                                       " group by month(can.Created_On) " +
                                       " union " +
                                       " select 'TL'colname,count(*) TL_Selected,month(can.Created_On) Monname from CandidateDetails can" +
                                       " join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                                       " join Job_Master_USA job on job.Jobcode = canjob.Jobcode" +
                                       " where Cand_Status>= 103 and can.Created_By like '%" + TWE_id + "%' " +
                                       " and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                                       " group by month(can.Created_On) " +
                                       " union " +
                                       " select 'BP'colname,count(*) BP_Selected,month(can.Created_On) Monname  from CandidateDetails can" +
                                       " join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                                       " join Job_Master_USA job on job.Jobcode = canjob.Jobcode where " +
                                       " Cand_Status>=103 and Cand_Status!=104 and can.Created_By like '%" + TWE_id + "%' " +
                                       " and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                                       " group by month(can.Created_On) " +
                                       " union " +
                                       " select 'EC'colname,count(*) EC_Selected,month(can.Created_On) Monname from CandidateDetails can" +
                                       " join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                                       " join Job_Master_USA job on job.Jobcode = canjob.Jobcode where " +
                                       " Cand_Status>=103 and Cand_Status not in (104,106) and can.Created_By like '%" + TWE_id + "%' " +
                                       " and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                                       " group by month(can.Created_On)";
            }
            else if (strtype == "Weekly")
            {
                strquery = @"select 'SB'colname, count(*) Submitted,DATEPART(week,can.Created_On) Wkname  from CandidateDetails can" +
                            " join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                            " join Job_Master_USA job on job.Jobcode = canjob.Jobcode" +
                            " where Cand_Status in ('101','102') and can.Created_By like '%" + TWE_id + "%' " +
                            " and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                            " group by DATEPART(week,can.Created_On) " +
                            " union " +
                            " select 'TL'colname,count(*) TL_Selected,DATEPART(week,can.Created_On) Wkname from CandidateDetails can" +
                            " join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                            " join Job_Master_USA job on job.Jobcode = canjob.Jobcode" +
                            " where Cand_Status in ('103') and can.Created_By like '%" + TWE_id + "%' " +
                            " and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                            " group by DATEPART(week,can.Created_On) " +
                            " union " +
                            " select 'BP'colname,count(*) BP_Selected,DATEPART(week,can.Created_On) Wkname  from CandidateDetails can" +
                            " join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                            " join Job_Master_USA job on job.Jobcode = canjob.Jobcode" +
                            " where Cand_Status in ('105') and can.Created_By like '%" + TWE_id + "%' " +
                            " and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                            " group by DATEPART(week,can.Created_On) " +
                            " union " +
                            " select 'EC'colname,count(*) EC_Selected,DATEPART(week,can.Created_On) Wkname from CandidateDetails can" +
                            " join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                            " join Job_Master_USA job on job.Jobcode = canjob.Jobcode" +
                            " where Cand_Status in ('107') and can.Created_By like '%" + TWE_id + "%' " +
                            " and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                            " group by DATEPART(week,can.Created_On)";
            }
            else if (strtype == "Daily")
            {
                strquery = @"select 'SB'colname, count(*) Submitted,substring(datename(dw,can.Created_On),0,4) dyname  from CandidateDetails can" +
                                   " join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                                   " join Job_Master_USA job on job.Jobcode = canjob.Jobcode" +
                                   " where Cand_Status in ('101','102') and can.Created_By like '%" + TWE_id + "%' " +
                                   " and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                                   " group by datename(dw,can.Created_On) " +
                                   " union " +
                                   " select 'TL'colname,count(*) TL_Selected,substring(datename(dw,can.Created_On),0,4) dyname from CandidateDetails can" +
                                   " join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                                   " join Job_Master_USA job on job.Jobcode = canjob.Jobcode" +
                                   " where Cand_Status in ('103') and can.Created_By like '%" + TWE_id + "%' " +
                                   " and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                                   " group by datename(dw,can.Created_On) " +
                                   " union " +
                                   " select 'BP'colname,count(*) BP_Selected,substring(datename(dw,can.Created_On),0,4) dyname  from CandidateDetails can" +
                                   " join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                                   " join Job_Master_USA job on job.Jobcode = canjob.Jobcode where " +
                                   " Cand_Status in ('105') and can.Created_By like '%" + TWE_id + "%' " +
                                   " and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                                   " group by datename(dw,can.Created_On) " +
                                   " union " +
                                   " select 'EC'colname,count(*) EC_Selected,substring(datename(dw,can.Created_On),0,4) dyname from CandidateDetails can" +
                                   " join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                                   " join Job_Master_USA job on job.Jobcode = canjob.Jobcode where " +
                                   " Cand_Status in ('107') and can.Created_By like '%" + TWE_id + "%' " +
                                   " and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                                   " group by datename(dw,can.Created_On) ";
            }
            _read = _sql.doRead(strquery);
            while (_read.Read())
            {
                linechartlist _lcl = new linechartlist();
                _lcl.colName = _read[0].ToString();
                _lcl.submitted = _read[1].ToString();
                _lcl.itemName = _read[2].ToString();
                _lstline.Add(_lcl);

            }
            _read.Close();

            string strData = "";

            int timeVal = 0;
            if (strtype == "Monthly")
            {
                timeVal = 12;
                strData = "'Jan','Feb','Mar','Apr','May','Jun','Jul','Aug','Sep','Oct','Nov','Dec'";
            }
            else if (strtype == "Weekly")
            {
                timeVal = 53;
                strData = "'Wk1','Wk2','Wk3','Wk4','Wk5','Wk6','Wk7','Wk8','Wk9','Wk10','Wk11','Wk12','Wk13','Wk14','Wk15','Wk16','Wk17','Wk18','Wk19','Wk20','Wk21','Wk22','Wk23','Wk24','Wk25','Wk26','Wk27','Wk28','Wk29','Wk30','Wk31','Wk32','Wk33','Wk34','Wk35','Wk36','Wk37','Wk38','Wk39','Wk40','Wk41','Wk42','Wk43','Wk44','Wk45','Wk46','Wk47','Wk48','Wk49','Wk50','Wk51','Wk52','Wk53'";
            }
            else if (strtype == "Daily")
            {
                timeVal = 7;
                strData = "'Sun','Mon','Tue','Wed','Thu','Fri','Sat'";
            }
            string[] stageArr = { "SB", "TL", "BP", "EC" };



            List<linechartlist> lstchartSub = new List<linechartlist>();

            List<linechartlist> lstDt0 = _lstline.OrderBy(x => x.itemName).ThenBy(y => y.colName).ToList<linechartlist>();

            for (int i = 0; i < stageArr.Length; i++)
            {

                string countval = "";
                for (int j = 1; j <= timeVal; j++)
                {

                    List<linechartlist> lstResult = _lstline.Where(x => (x.itemName == j.ToString()) && (x.colName == stageArr[i])).ToList<linechartlist>();
                    if (lstResult.Count == 0)
                    {
                        countval = countval + "0" + ",";
                    }
                    else
                    {
                        countval = countval + lstResult[0].submitted.ToString() + ",";
                    }

                }

                lstchartSub.Add(new linechartlist() { colName = stageArr[i], submitted = countval.Substring(0, countval.Length - 1) });
                countval = "";

            }


            _rd.Linechart = "<canvas id='chart-line' class='chart-canvas' height='300px'></canvas> <script> " +
                      "var ctx2 = document.getElementById('chart-line').getContext('2d');" +
                      "var gradientStroke1 = ctx2.createLinearGradient(0, 230, 0, 50);" +

                "gradientStroke1.addColorStop(1, 'rgba(203,12,159,0.2)');" +
                "gradientStroke1.addColorStop(0.2, 'rgba(72,72,176,0.0)'); " +
                "gradientStroke1.addColorStop(0, 'rgba(203,12,159,0)'); " + //purple colors

                "var gradientStroke2 = ctx2.createLinearGradient(0, 230, 0, 50); " +

                "gradientStroke2.addColorStop(1, 'rgba(20,23,39,0.2)'); " +
                "gradientStroke2.addColorStop(0.2, 'rgba(72,72,176,0.0)'); " +
                "gradientStroke2.addColorStop(0, 'rgba(20,23,39,0)');" + //purple colors

                "var gradientStroke3 = ctx2.createLinearGradient(0, 230, 0, 50);" +

                "gradientStroke3.addColorStop(1, 'rgba(203,0,159,0.2)');" +
                "gradientStroke3.addColorStop(0.2, 'rgba(72,72,72,0.0)'); " +
                "gradientStroke3.addColorStop(0, 'rgba(203,12,120,0)'); " + //purple colors

                "var gradientStroke4 = ctx2.createLinearGradient(0, 230, 0, 50); " +

                "gradientStroke4.addColorStop(1, 'rgba(20,180,139,0.2)'); " +
                "gradientStroke4.addColorStop(0.2, 'rgba(0,72,176,0.0)'); " +
                "gradientStroke4.addColorStop(0, 'rgba(120,123,39,0)');" + //purple colors


                "new Chart(ctx2, {" +
                "type: 'line'," +
                "data: " +
                "{" +
                "labels: [" + strData + "]," +
                "datasets: [{" +
                "label: 'SB Candidates'," +
                "tension: 0.4," +
                "borderWidth: 0," +
                "pointRadius: 0," +
                "borderColor: '#42eff5'," +
                "borderWidth: 3," +
                "backgroundColor: '#42eff5'," +
                "data: [" + lstchartSub[0].submitted + "]," +
                "maxBarThickness: 6,fill:false" +

                "}," +
                "{" +
                "label: 'TL Candidates'," +
                "tension: 0.4," +
                "borderWidth: 0," +
                "pointRadius: 0," +
                "borderColor: '#f58742'," +
                "borderWidth: 3," +
                "backgroundColor: '#f58742'," +
                "data: [" + lstchartSub[1].submitted + "]," +
                "maxBarThickness: 6,fill:false" +

                "}," +
                 "{" +
                "label: 'BP Candidates'," +
                "tension: 0.4," +
                "borderWidth: 0," +
                "pointRadius: 0," +
                "borderColor: '#e642f5'," +
                "borderWidth: 3," +
                "backgroundColor: '#e642f5'," +
                "data: [" + lstchartSub[2].submitted + "]," +
                "maxBarThickness: 6,fill:false" +

                "}," +
                 "{" +
                "label: 'EC Candidates'," +
                "tension: 0.4," +
                "borderWidth: 0," +
                "pointRadius: 0," +
                "borderColor: 'green'," +
                "borderWidth: 3," +
                "backgroundColor: 'green'," +
                "data: [" + lstchartSub[3].submitted + "]," +
                "maxBarThickness: 6,fill:false" +

                "}," +

                "]," +
                "}," +
                "options: " +
                "{" +
                "responsive: true," +
                "maintainAspectRatio: false," +
                "legend: " +
                "{" +
                "display: false," +
                "}," +
                "tooltips: " +
                "{" +
                "enabled: true," +
                "mode: 'index'," +
                "intersect: false," +
                "}," +
                "scales: " +
                "{" +
                "yAxes: [{" +
                "gridLines: " +
                "{" +
                "borderDash: [2]," +
                "borderDashOffset: [2]," +
                "color: '#dee2e6'," +
                "zeroLineColor: '#dee2e6'," +
                "zeroLineWidth: 1," +
                "zeroLineBorderDash: [2]," +
                "drawBorder: false," +
                "}," +
                "ticks: " +
                "{" +
                "suggestedMin: 0," +
                "suggestedMax: 10," +
                "beginAtZero: true," +
                "padding: 10," +
                "fontSize: 11," +
                "fontColor: '#adb5bd'," +
                "lineHeight: 3," +
                "fontStyle: 'normal'," +
                "fontFamily: 'Open Sans'," +
                "}," +
                "},]," +
                "xAxes: [{" +
                "gridLines: " +
                "{" +
                "zeroLineColor: 'rgba(0,0,0,0)'," +
                "display: false," +
                "}," +
                "ticks: " +
                "{" +
                "padding: 10," +
                "fontSize: 11," +
                "fontColor: '#adb5bd'," +
                "lineHeight: 3," +
                "fontStyle: 'normal'," +
                "fontFamily: 'Open Sans'," +
                "}," +
                "},]," +
                "}," +
                "}," +
                "});" +
                "</script>";


            _rd.LinechartTitle = "Submission overview";
            _rd.LineDuration = "Duration for the Week of ";
            _rd.RecentRecuitmentTitle = "Recent recruitment";



            //     strquery = @"select job.jobcode,job.JobTitle,job.Jobimage,Duration,empl.EmpTypeName,City,State,cli.ClientCompanyName,count(*) Candidates,Assigned_To from  Job_Master_USA job
            //                     join CandidateDetails can on job.jobcode=can.JobCode 
            //join ClientMaster cli on cli.ClientID=job.Clientname
            //join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType and Assigned_To like '%" + TWE_id + "%' and job.Created_on between '" + fromdate + "' and '" + todate + "'" +
            //                     " group by job.jobcode,job.Jobimage,job.JobTitle,Duration,ClientCompanyName,empl.EmpTypeName,City,State,Jobopendate,Assigned_To order by Jobopendate desc";


            strquery = @"select top 5 * from (select distinct job.jobcode,job.JobTitle,job.Jobimage,Duration,empl.EmpTypeName,job.City,State,cli.ClientCompanyName,job.Created_By,job.Created_Time from  Job_Master_USA job
                            left join CandidateJob canjob on canjob.Jobcode=job.Jobcode			
                            left join CandidateDetails can on canjob.CandidateId = can.candidateid
							join ClientMaster cli on cli.ClientID=job.Clientname
							join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType 
							where Assigned_To like '%" + TWE_id + "%' and " +
                            "job.Created_on between '" + fromdate + "' and '" + todate + "'" +
                            " )tb1 order by Created_By desc,Created_Time desc";

            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                recruitmenttable _rt = new recruitmenttable();
                _rt.RecruitmentId = _read[0].ToString();
                _rt.JobName = _read[1].ToString();
                _rt.JobMediaPath = _read[2].ToString();
                _rt.JobDuration = _read[3].ToString();
                _rt.JobType = _read[4].ToString();
                _rt.JobCity = _read[5].ToString();
                _rt.JobState = _read[6].ToString();
                _rt.JobClient = _read[7].ToString();
                _lstrt.Add(_rt);
            }
            _read.Close();


            List<recruitmenttable> _lstRecruitTable = new List<recruitmenttable>();

            foreach (var item in _lstrt)
            {
                if (!_lstRecruitTable.Where(x => x.RecruitmentId == item.RecruitmentId).Any())
                {
                    _lstRecruitTable.Add(item);
                }

            }

            _lstrt = _lstRecruitTable;


            strquery = @"select job.Jobcode,count(can.candidateid) candidates from Job_Master_USA job
                        left join CandidateJob canjob on canjob.Jobcode=job.Jobcode			
                        left join CandidateDetails can on canjob.CandidateId = can.candidateid
                        group by job.Jobcode,Assigned_To,job.Created_on,Jobopendate 
                        having Assigned_To like '%" + TWE_id + "%' and " +
                        "job.Created_on between '" + fromdate + "' and '" + todate + "'" +
                        " order by Jobopendate desc";

            _read = _sql.doRead(strquery);

            while (_read.Read())
            {

                for (int i = 0; i < _lstrt.Count; i++)
                {
                    if (_lstrt[i].RecruitmentId == _read[0].ToString())
                    {
                        _lstrt[i].JobSubmission = _read[1].ToString();
                    }


                }

            }
            _read.Close();

            //_rd.RecentRecuitmentCount = _lstrt.Count.ToString() + " Active Jobs for the duration of";
            //_rd.RecuitmentTable = _lstrt;

            strquery = @"select count(*) Total_jobs from Job_Master_USA 
                        where Assigned_To like '%" + TWE_id + "%' and " +
                       "Created_on between '" + fromdate + "' and '" + todate + "'" +
                       " and Jobstatus='10200'";

            _read = _sql.doRead(strquery);



            while (_read.Read())
            {
                _rd.RecentRecuitmentCount = _read[0].ToString() + " Active Jobs for the duration of";
            }

            //_rd.RecentRecuitmentCount = _lstrt.Count.ToString() + " Active Jobs for the duration of";
            _rd.RecuitmentTable = _lstrt;

            _read.Close();

            strquery = @"select 
                        (
                        select cast(candcount as float)/cast(TargetValue as float) from
                        (
                        select count(*) candcount from CandidateDetails can
                         where Created_By like '%" + TWE_id + "%' and " +
                        "can.Created_on between '" + fromdate + "' and '" + todate + "' ) tb1," +
                        "(select TargetValue from TargetMaster_USA where TargetType='Candidates') tb2" +
                        ") candcount,(" +
                        "select cast(vencount as float)/cast(TargetValue as float) from" +
                        "(" +
                        "select count(*) vencount from EmployerDetails where Created_By like '%" + TWE_id + "%'" +
                        " and Created_On between '" + fromdate + "' and '" + todate + "') tb3," +
                        " (select TargetValue from TargetMaster_USA where TargetType='Vendors') tb4" +
                        " ) vencount," +
                        "(" +
                        "select cast(candcount as float)/cast(TargetValue as float) from" +
                        "(" +
                        "select count(*) candcount from CandidateDetails can" +
                        " join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                        " join Job_Master_USA job on job.Jobcode = canjob.Jobcode" +
                        " where can.Created_By like '%" + TWE_id + "%' and Cand_Status in ('103')" +
                        " and can.Created_on between '" + fromdate + "' and '" + todate + "' ) tb5, " +
                        "(select TargetValue from TargetMaster_USA where TargetType='Submission to TL') tb6" +
                        ")subcount," +
                            "(select cast(candcount as float) / cast(TargetValue as float) from" +
                            "(" +
                            "select count(*) candcount from CandidateDetails can" +
                            " join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                            " join Job_Master_USA job on job.Jobcode = canjob.Jobcode" +
                            " where can.Created_By like '%" + TWE_id + "%' and Cand_Status > 103" +
                            "and can.Created_on between '" + fromdate + "' and '" + todate + "') tb7," +
                            "(select TargetValue from TargetMaster_USA where TargetType = 'TL Approval') tb8" +
                            ")TLAppcount," +
                            "(" +
                            "select cast(candcount as float) / cast(TargetValue as float) from" +
                            "(" +
                            "select count(*) candcount from CandidateDetails can" +
                            " join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                            " join Job_Master_USA job on job.Jobcode = canjob.Jobcode" +
                            " where can.Created_By like '%" + TWE_id + "%' and Cand_Status >= 105" +
                            "and can.Created_on between '" + fromdate + "' and '" + todate + "') tb7," +
                            "(select TargetValue from TargetMaster_USA where TargetType = 'BP Approval') tb8" +
                            ")BPAppcount," +
                            "(" +
                            "select cast(candcount as float) / cast(TargetValue as float) from" +
                            "(" +
                            "select count(*) candcount from CandidateDetails can" +
                            " join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                            " join Job_Master_USA job on job.Jobcode = canjob.Jobcode" +
                            " where can.Created_By like '%" + TWE_id + "%' and Cand_Status >= 107" +
                            "and can.Created_on between '" + fromdate + "' and '" + todate + "') tb7," +
                            "(select TargetValue from TargetMaster_USA where TargetType = 'EC Approval') tb8" +
                            ")ECAppcount";


            _read = _sql.doRead(strquery);
            while (_read.Read())
            {
                _rd.OverViewPercentage = Math.Round(((Convert.ToDouble(_read[1]) + Convert.ToDouble(_read[1]) + Convert.ToDouble(_read[2]) + Convert.ToDouble(_read[3]) + Convert.ToDouble(_read[4]) + Convert.ToDouble(_read[5])) / 6), 2).ToString() + " % for the duration of ";

            }
            _read.Close();

            _rd.OverviewTitle = "Performance overview";
            //_rd.OverViewPercentage = "4% this month";


            strquery = @"select 'End Client-Closure't1,count(distinct candidateemailid) Onboarded from CandidateDetails can join CandidateJob canjob on can.candidateid=canjob.CandidateId
                        join Job_Master_USA job on job.Jobcode=canjob.Jobcode where Cand_Status in ('109') and can.Created_By='" + TWE_id + "' and can.Created_On between '" + fromdate + "' and '" + todate + "'" +
                        " union " +
                        " select 'Business Partner Selected't2,count(distinct candidateemailid) BPSelected from CandidateDetails can join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                        " join Job_Master_USA job on job.Jobcode = canjob.Jobcode where Cand_Status in ('105') and can.Created_By='" + TWE_id + "' and can.Created_On between '" + fromdate + "' and '" + todate + "'" +
                        " union " +
                        " select 'Team Lead Approved't3,count(distinct candidateemailid) TLApproved from CandidateDetails can join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                        " join Job_Master_USA job on job.Jobcode = canjob.Jobcode where Cand_Status in ('105','106','107','108') and can.Created_By='" + TWE_id + "' and can.Created_On between '" + fromdate + "' and '" + todate + "'" +
                        " union " +
                        " select 'Submitted't4,count(distinct candidateemailid) SubmittedTL from CandidateDetails can join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                        " join Job_Master_USA job on job.Jobcode = canjob.Jobcode where Cand_Status in ('103') and can.Created_By='" + TWE_id + "' and can.Created_On between '" + fromdate + "' and '" + todate + "'" +
                        " union " +
                        " select 'Vendors't5,count(*) Vendors from EmployerDetails where Status='1'  and Created_By like '" + TWE_id + "' and Created_On between '" + fromdate + "' and '" + todate + "'" +
                        " union " +
                        " select 'Candidates't6,count(distinct candidateemailid) SubmitCand from CandidateDetails can join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                        " left join Job_Master_USA job on job.Jobcode = canjob.Jobcode where Cand_Status in ('101','102','103') and can.Created_By='" + TWE_id + "'and can.Created_On between '" + fromdate + "' and '" + todate + "'" +
                        " --union " +
                        " --select ''t7,count(*) BackupCand from BackupCandidateDetails where Created_By='" + TWE_id + "' and Created_On between '" + fromdate + "' and '" + todate + "'";
            _read = _sql.doRead(strquery);
            while (_read.Read())
            {
                performanceoverview _pov = new performanceoverview();
                _pov.PerformanceName = _read[0].ToString();
                _pov.PerformanceCount = _read[1].ToString();
                _lstpov.Add(_pov);
            }
            _read.Close();
            _rd.PerformaceOverView = _lstpov;

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
                _json.data = _rd;
            }

            return _json;

        }

        public jsonArray getSuperAdmindashboarddetails()
        {
            int status = 1;
            

            tiles objTile = new tiles();
            string strquery = @"select * from
                        (select count(*) activeusers from Userprofilecreation where status=1) tb1,
                        (select count(*) inactiveusers from Userprofilecreation where status!=1) tb2,

                        (select count(*) activeclients from ClientMaster where status=1) tb3,
                        (select count(*) inactiveclients from ClientMaster where status!=1) tb4";

            SqlDataReader _read = _sql.doRead(strquery);

            while (_read.Read())
            {

                objTile.AchiveCount = _read[0].ToString();
                objTile.TotalCount = _read[1].ToString();
                objTile.Name = _read[2].ToString();
                objTile.TileTitle = _read[3].ToString();
            }

            _read.Close();

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
                _json.data = objTile;
            }

            return _json;
        }

        public jsonArray getEmployeedetails(string region)
        {
            int status = 1;
            listarray _db = new listarray();

            _db.lstEmployee = new List<dropDownTemplate>();

            
            string strquery = @"select TWE_ID,UP_firstName+' ' + UP_lastName EmpName from Userprofile where TWE_ID!= 'TWEI0000' and UP_MT_region in ("+region+",2002)";

            SqlDataReader _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                _db.lstEmployee.Add(new dropDownTemplate
                {
                    ID = _read["TWE_ID"].ToString(),
                    Name = _read["EmpName"].ToString()
                });
            }

            _read.Close();

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
                _json.data = _db;
            }

            return _json;
        }

        public jsonArray getFormdetails()
        {
            int status = 1;

            listarray _db = new listarray();
            _db.lstClient = new List<dropDownTemplate>();
            _db.lstPriority = new List<dropDownTemplate>();
            _db.lstCurrency = new List<dropDownTemplate>();
            _db.lstJobstatus = new List<dropDownTemplate>();
            _db.lstEmployee = new List<dropDownTemplate>();
            _db.lstEmploymentType = new List<dropDownTemplate>();
            _db.lstType = new List<dropDownTemplate>();
            _db.lstLocation = new List<dropDownTemplate>();
            _db.lstTechnology = new List<dropDownTemplate>();
            _db.lstSkill = new List<dropDownTemplate>();

            string strquery = "select max(substring(Jobcode,7,len(Jobcode)+1)) from Job_Master_USA";
            SqlDataReader _read = _sql.doRead(strquery);
            int i = 0;
            while (_read.Read())
            {
                i = Convert.ToInt16(_read[0]);
            }

            if (i >= 0 && i < 9)
            {
                i++;
                _db.Jobcodename = "TWEUSA" + "000" + i;
            }
            else if (i >= 9 && i < 99)

            {
                i++;
                _db.Jobcodename = "TWEUSA" + "00" + i;
            }
            else if (i >= 99 && i < 999)
            {
                i++;
                _db.Jobcodename = "TWEUSA" + "0" + i;
            }
            else
            {
                i++;
                _db.Jobcodename = "TWEUSA" + i;
            }


            _read.Close();
            strquery = @"SELECT[ClientID],[ClientCompanyName] FROM [ClientMaster] where Status=1";

            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                _db.lstClient.Add(new dropDownTemplate
                {
                    ID = _read["ClientID"].ToString(),
                    Name = _read["ClientCompanyName"].ToString()
                });
            }

            _read.Close();

            strquery = @"SELECT [PriorityID],[PriorityName] FROM [Priority_Master] where Status=1";

            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                _db.lstPriority.Add(new dropDownTemplate
                {
                    ID = _read["PriorityID"].ToString(),
                    Name = _read["PriorityName"].ToString()
                });
            }


            _read.Close();

            strquery = @"SELECT [CurrencyID],[CurrencyName] FROM [Currency_Master] where Status=1";

            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                _db.lstCurrency.Add(new dropDownTemplate
                {
                    ID = _read["CurrencyID"].ToString(),
                    Name = _read["CurrencyName"].ToString()
                });
            }

            _read.Close();

            strquery = @"SELECT [JobstatusID],[JobstatusName] FROM [Jobstatus_Master] where Status=1";

            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                _db.lstJobstatus.Add(new dropDownTemplate
                {
                    ID = _read["JobstatusID"].ToString(),
                    Name = _read["JobstatusName"].ToString()
                });
            }

            _read.Close();

            //strquery = @"  select TWE_ID,UP_firstName+' ' + UP_lastName EmpName from Userprofile up
            //              join Region reg on up.UP_MT_region = reg.regionid"+
            //              " and UP_MT_designation= '4001' and TWE_ID!= 'TWEI0000'";

            strquery = @"select TWE_ID,UP_firstName+' ' + UP_lastName EmpName from Userprofile where TWE_ID!= 'TWEI0000' and UP_MT_region in (2001,2002)";

            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                _db.lstEmployee.Add(new dropDownTemplate
                {
                    ID = _read["TWE_ID"].ToString(),
                    Name = _read["EmpName"].ToString()
                });
            }

            _read.Close();

            strquery = @"SELECT [TypeID],[TypeName] FROM [Type_Master] where Status=1";

            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                _db.lstType.Add(new dropDownTemplate
                {
                    ID = _read["TypeID"].ToString(),
                    Name = _read["TypeName"].ToString()
                });
            }

            _read.Close();

            strquery = @"SELECT [EmpTypeID],[EmpTypeName] FROM [EmploymentType_Master] where Status=1";

            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                _db.lstEmploymentType.Add(new dropDownTemplate
                {
                    ID = _read["EmpTypeID"].ToString(),
                    Name = _read["EmpTypeName"].ToString()
                });
            }

            _read.Close();

            strquery = @"SELECT [LocationID],[LocationName] FROM [Location_Master] where Status=1";

            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                _db.lstLocation.Add(new dropDownTemplate
                {
                    ID = _read["LocationID"].ToString(),
                    Name = _read["LocationName"].ToString()
                });
            }

            _read.Close();

            strquery = @"SELECT [TechnologyName],[ImageURL] FROM [Image_Master] where Status=1";

            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                _db.lstTechnology.Add(new dropDownTemplate
                {
                    ID = _read["ImageURL"].ToString(),
                    Name = _read["TechnologyName"].ToString()
                });
            }

            _read.Close();

            strquery = @"SELECT [SkillName],[SkillID] FROM [Skill_Master] where Status=1";

            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                _db.lstSkill.Add(new dropDownTemplate
                {
                    ID = _read["SkillID"].ToString(),
                    Name = _read["SkillName"].ToString()
                });
            }


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
                _json.data = _db;
            }

            return _json;
        }

        public jsonArray getFormdetailsIndia()
        {
            int status = 1;

            listarray _db = new listarray();
            _db.lstClient = new List<dropDownTemplate>();
            _db.lstPriority = new List<dropDownTemplate>();
            _db.lstCurrency = new List<dropDownTemplate>();
            _db.lstJobstatus = new List<dropDownTemplate>();
            _db.lstEmployee = new List<dropDownTemplate>();
            _db.lstEmploymentType = new List<dropDownTemplate>();
            _db.lstType = new List<dropDownTemplate>();
            _db.lstLocation = new List<dropDownTemplate>();
            _db.lstTechnology = new List<dropDownTemplate>();
            _db.lstSkill = new List<dropDownTemplate>();
            _db.lstrateType = new List<dropDownTemplate>();

            string strquery = "select max(substring(Jobcode,7,len(Jobcode)+1)) from Job_Master_IND";
            SqlDataReader _read = _sql.doRead(strquery);
            int i = 0;
            while (_read.Read())
            {
                i = Convert.ToInt16(_read[0]);
            }

            if (i >= 0 && i < 9)
            {
                i++;
                _db.Jobcodename = "TWEIND" + "000" + i;
            }
            else if (i >= 9 && i < 99)

            {
                i++;
                _db.Jobcodename = "TWEIND" + "00" + i;
            }
            else if (i >= 99 && i < 999)
            {
                i++;
                _db.Jobcodename = "TWEIND" + "0" + i;
            }
            else
            {
                i++;
                _db.Jobcodename = "TWEIND" + i;
            }


            _read.Close();
            strquery = @"SELECT[ClientID],[ClientCompanyName] FROM [ClientMaster] where Status=1";

            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                _db.lstClient.Add(new dropDownTemplate
                {
                    ID = _read["ClientID"].ToString(),
                    Name = _read["ClientCompanyName"].ToString()
                });
            }

            _read.Close();

            strquery = @"SELECT [PriorityID],[PriorityName] FROM [Priority_Master] where Status=1";

            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                _db.lstPriority.Add(new dropDownTemplate
                {
                    ID = _read["PriorityID"].ToString(),
                    Name = _read["PriorityName"].ToString()
                });
            }


            _read.Close();

            strquery = @"SELECT [CurrencyID],[CurrencyName] FROM [Currency_Master] where Status=1";

            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                _db.lstCurrency.Add(new dropDownTemplate
                {
                    ID = _read["CurrencyID"].ToString(),
                    Name = _read["CurrencyName"].ToString()
                });
            }

            _read.Close();

            strquery = @"SELECT [JobstatusID],[JobstatusName] FROM [Jobstatus_Master] where Status=1";

            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                _db.lstJobstatus.Add(new dropDownTemplate
                {
                    ID = _read["JobstatusID"].ToString(),
                    Name = _read["JobstatusName"].ToString()
                });
            }

            _read.Close();

            //strquery = @"  select TWE_ID,UP_firstName+' ' + UP_lastName EmpName from Userprofile up
            //              join Region reg on up.UP_MT_region = reg.regionid"+
            //              " and UP_MT_designation= '4001' and TWE_ID!= 'TWEI0000'";

            strquery = @"select TWE_ID,UP_firstName+' ' + UP_lastName EmpName from Userprofile where TWE_ID!= 'TWEI0000' and UP_MT_region in (2000,2002)";

            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                _db.lstEmployee.Add(new dropDownTemplate
                {
                    ID = _read["TWE_ID"].ToString(),
                    Name = _read["EmpName"].ToString()
                });
            }

            _read.Close();

            strquery = @"SELECT [TypeID],[TypeName] FROM [Type_Master] where Status=1";

            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                _db.lstType.Add(new dropDownTemplate
                {
                    ID = _read["TypeID"].ToString(),
                    Name = _read["TypeName"].ToString()
                });
            }

            _read.Close();

            strquery = @"SELECT [EmpTypeID],[EmpTypeName] FROM [EmploymentType_Master] where Status=1";

            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                _db.lstEmploymentType.Add(new dropDownTemplate
                {
                    ID = _read["EmpTypeID"].ToString(),
                    Name = _read["EmpTypeName"].ToString()
                });
            }

            _read.Close();

            strquery = @"SELECT [LocationID],[LocationName] FROM [Location_Master] where Status=1";

            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                _db.lstLocation.Add(new dropDownTemplate
                {
                    ID = _read["LocationID"].ToString(),
                    Name = _read["LocationName"].ToString()
                });
            }

            _read.Close();

            strquery = @"SELECT [TechnologyName],[ImageURL] FROM [Image_Master] where Status=1";

            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                _db.lstTechnology.Add(new dropDownTemplate
                {
                    ID = _read["ImageURL"].ToString(),
                    Name = _read["TechnologyName"].ToString()
                });
            }

            _read.Close();

            strquery = @"SELECT [SkillName],[SkillID] FROM [Skill_Master] where Status=1";

            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                _db.lstSkill.Add(new dropDownTemplate
                {
                    ID = _read["SkillID"].ToString(),
                    Name = _read["SkillName"].ToString()
                });
            }

            _read.Close();
            strquery = @"SELECT [TypeName],[TypeID] FROM [RateType_Master] where Status=1";

            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                _db.lstrateType.Add(new dropDownTemplate
                {
                    ID = _read["TypeID"].ToString(),
                    Name = _read["TypeName"].ToString()
                });
            }
            _read.Close();


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
                _json.data = _db;
            }

            return _json;
        }

        public jsonArray getClientContactdetails(string ClientID)
        {
            int status = 1;

            listarray _db = new listarray();
            _db.lstClicontact = new List<dropDownTemplate>();

            string strquery = @"select ClientContactID, ContactPerson from Client_Contact_Person where ClientID = '" + ClientID + "'";

            SqlDataReader _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                _db.lstClicontact.Add(new dropDownTemplate
                {
                    ID = _read["ClientContactID"].ToString(),
                    Name = _read["ContactPerson"].ToString()
                });
            }

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
                _json.data = _db;
            }

            return _json;
        }
        public jsonArray insertJobInfo(Jobcode job)
        {
            DateTime dateTime_Eastern = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));
            var timeInEST = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));
            var timeInEasternAsString = timeInEST.ToString("hh:mm tt", CultureInfo.InvariantCulture);
            int status = 1;
            string query = "";
            if (job.Mode == "insert")
            {
                query = @"INSERT INTO [Job_Master_USA]
                                    ([Jobcode],[JobTitle],[Duration]
                                    ,[EmplType],[Location],[City]
                                    ,[State],[Country],[Clientname]
                                    ,[Contactname],[Description],[Assigned_To]
                                    ,[Prioritylevel],[Jobstatus],[WorkType1]
                                    ,[Rate1],[Currency1],[WorkType2]
                                    ,[Rate2],[Currency2],[Skill]
                                    ,[Jobopendate],[OpenComments],[Jobimage]
                                    ,[Created_By],[Created_On],[Created_Time],Publish_Web)
                                    VALUES" +
                                    "('" + job.Jobcodename + "','" + job.JobTitle + "','" + job.Duration + "','" +
                                    job.EmplType + "','" + job.Location + "','" + job.City + "','" +
                                    job.State + "','" + job.Country + "','" + job.Clientname + "','" +
                                    job.Contactname + "','" + job.Description + "','" + job.AssignedTo + "','" +
                                    job.Prioritylevel + "','" + job.Jobstatus + "','" + job.WorkType1 + "','" +
                                    job.Rate1 + "','" + job.Currency1 + "','" + job.WorkType2 + "','" +
                                    job.Rate2 + "','" + job.Currency2 + "','" + job.Skill + "','" +
                                    job.Jobopendate + "','" + job.OpenComments + "','" + job.Jobimage + "','" +
                                    job.Created_By + "','" + dateTime_Eastern.ToString("yyyy-MM-dd") + "','" + timeInEasternAsString + "','" + job.Publish_Web + "')";
            }
            else if (job.Mode == "update")
            {
                query = @"update [Job_Master_USA] set JobTitle='" + job.JobTitle + "',Duration='" + job.Duration + "',EmplType='" + job.EmplType + "',Location='" +
                        job.Location + "',City='" + job.City + "',State='" + job.State + "',Country='" + job.Country + "',Clientname='" + job.Clientname + "',Contactname='" +
                        job.Contactname + "',Description='" + job.Description + "',Assigned_To='" + job.AssignedTo + "',Prioritylevel='" + job.Prioritylevel + "',Jobstatus='" +
                        job.Jobstatus + "',WorkType1='" + job.WorkType1 + "',Rate1='" + job.Rate1 + "',Currency1='" + job.Currency1 + "',WorkType2='" + job.WorkType2 + "',Rate2='" +
                        job.Rate2 + "',Currency2='" + job.Currency2 + "',Skill='" + job.Skill + "',Jobopendate='" + job.Jobopendate + "',OpenComments='" + job.OpenComments + "',Jobimage='" +
                        job.Jobimage + "',CloseComments='" + job.CloseComments + "',Last_Updated_By='" + job.Updated_By + "',Publish_Web='" + job.Publish_Web + "',Last_Updated_On='" +
                        dateTime_Eastern.ToString("yyyy-MM-dd") + "',Updated_Time='" + timeInEasternAsString + "' where Jobcode='" + job.Jobcodename + "'";

            }


            _sql.doInsert(query);


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
                _json.data = "";
            }

            return _json;

        }
        public jsonArray getJobSearch(string TWE_Id, string fromdate, string todate, string searchkey)
        {
            int status = 1;

            string[] strsplit = new string[4];
            strsplit[0] = "";
            strsplit[1] = "";
            strsplit[2] = "";
            strsplit[3] = "";
            string[] strsplit2 = searchkey.Split(' ');


            if (strsplit2.Length == 1)
            {
                strsplit[0] = strsplit2[0];
                strsplit[1] = strsplit2[0];
                strsplit[2] = strsplit2[0];
                strsplit[3] = strsplit2[0];
            }
            else
            {
                for (int i = 0; i < strsplit2.Length; i++)
                {
                    strsplit[i] = strsplit2[i];

                }
            }



            JobMaster _db = new JobMaster();
            _db.lstJob = new List<JobcodeList>();

            string strquery = "";

            if (strsplit2.Length == 1)
            {
                strquery = @"select Jobcode,JobTitle,Duration,empl.EmpTypeName,City,State,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage from Job_Master_USA job
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientID=job.Clientname
                                where Assigned_To like '%" + TWE_Id + "%' and job.Created_On between '" + fromdate + "' and '" + todate + "'" +
                               "and JobTitle like '" + strsplit[0] + "%' or cli.ClientCompanyName like'" + strsplit[1] + "%' or stat.JobstatusName like'" + strsplit[2] + "%'" +
                               "and convert(varchar, job.Created_On,106) like '" + strsplit[3] + "%'";

            }
            else
            {

                strquery = @"select Jobcode,JobTitle,Duration,empl.EmpTypeName,City,State,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage from Job_Master_USA job
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientID=job.Clientname
                                where Assigned_To like '%" + TWE_Id + "%' and job.Created_On between '" + fromdate + "' and '" + todate + "'" +
                                    "and JobTitle like '" + strsplit[0] + "%' and cli.ClientCompanyName like'" + strsplit[1] + "%' and stat.JobstatusName like'" + strsplit[2] + "%'" +
                                    "and convert(varchar, job.Created_On,106) like '" + strsplit[3] + "%'";
            }

            SqlDataReader _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                JobcodeList objJob = new JobcodeList();

                objJob.Jobcode = _read[0].ToString();
                objJob.JobTitle = _read[1].ToString();
                objJob.JobDuration = _read[2].ToString();
                objJob.JobType = _read[3].ToString();
                objJob.JobCity = _read[4].ToString();
                objJob.JobState = _read[5].ToString();
                objJob.JobStatus = _read[6].ToString();
                objJob.JobClient = _read[7].ToString();
                objJob.JobContact = _read[8].ToString();
                objJob.CreatedOn = _read[9].ToString();
                objJob.JobMediaPath = _read[10].ToString();
                _db.lstJob.Add(objJob);
            }

            _read.Close();


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
                _json.data = _db;
            }

            return _json;
        }
        public jsonArray getJobDetails(string jobid)
        {
            int status = 1;
            string query = "";
            Jobcode _jc = new Jobcode();
            query = @"SELECT [Jobcode],[JobTitle],[Duration],[EmplType],[Location],[City],[State],[Country],[Clientname],[Contactname],[Description]
                              ,[Assigned_To],[Prioritylevel],[Jobstatus],[WorkType1],[Rate1],[Currency1],[WorkType2],[Rate2],[Currency2],[Skill],[Jobopendate]
                              ,[Jobclosedate],[OpenComments],[CloseComments],[Jobimage],up.UP_firstName+' '+up.UP_lastName Created_By,[Created_On],up1.UP_firstName+' '+up1.UP_lastName Last_Updated_By,[Last_Updated_On],up1.TWE_ID UpdatedBy,[Publish_Web]
                              FROM [Job_Master_USA] job
							  join Userprofile up on up.TWE_ID=job.Created_By
							  left join Userprofile up1 on up1.TWE_ID=job.Last_Updated_By
                              where Jobcode='" + jobid + "'";


            SqlDataReader _read = _sql.doRead(query);
            while (_read.Read())
            {
                _jc.Jobcodename = _read[0].ToString();
                _jc.JobTitle = _read[1].ToString();
                _jc.Duration = _read[2].ToString();
                _jc.EmplType = _read[3].ToString();
                _jc.Location = _read[4].ToString();
                _jc.City = _read[5].ToString();
                _jc.State = _read[6].ToString();
                _jc.Country = _read[7].ToString();
                _jc.Clientname = _read[8].ToString();
                _jc.Contactname = _read[9].ToString();
                _jc.Description = _read[10].ToString();
                _jc.AssignedTo = _read[11].ToString();
                _jc.Prioritylevel = _read[12].ToString();
                _jc.Jobstatus = _read[13].ToString();
                _jc.WorkType1 = _read[14].ToString();
                _jc.Rate1 = _read[15].ToString();
                _jc.Currency1 = _read[16].ToString();
                _jc.WorkType2 = _read[17].ToString();
                _jc.Rate2 = _read[18].ToString();
                _jc.Currency2 = _read[19].ToString();
                _jc.Skill = _read[20].ToString();
                _jc.Jobopendate = _read[21].ToString();
                _jc.Jobclosedate = _read[22].ToString();
                _jc.OpenComments = _read[23].ToString();
                _jc.CloseComments = _read[24].ToString();
                _jc.Jobimage = _read[25].ToString();
                _jc.Created_By = _read[26].ToString();
                _jc.Created_On = Convert.ToDateTime(_read[27]).ToString("yyyy-MM-dd");
                if (!(_read[28].Equals(System.DBNull.Value)))
                {
                    _jc.Updated_By = _read[28].ToString();
                }
                else
                {
                    _jc.Updated_By = "";
                }

                if (!(_read[29].Equals(System.DBNull.Value)))
                {
                    _jc.Updated_On = Convert.ToDateTime(_read[29]).ToString("yyyy-MM-dd");
                }
                else
                {
                    _jc.Updated_On = "";
                }
                if (!(_read[30].Equals(System.DBNull.Value)))
                {
                    _jc.Updated_By_ID = _read[30].ToString();
                }
                else
                {
                    _jc.Updated_By_ID = "";
                }
                _jc.Publish_Web = _read[31].ToString();
            }


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
                _json.data = _jc;
            }

            return _json;

        }
        public jsonArray getFollowupDetails(string jobid, string type,string createdBy)
        {
            int status = 1;
            string query = "";
            candidatelistDetails _jc = new candidatelistDetails();
            List<candidatelist> _lstcandi = new List<candidatelist>();

            query = @"SELECT [Jobcode],[JobTitle],[Duration],[EmpTypeName],job.City,[State],job.Country,[Description]
                    ,[Assigned_To],[PriorityName],[JobstatusName],typ.[TypeName],[Rate1],cur1.[CurrencySymbol] CurrencySymbol1,
                    isnull(typ2.[TypeName],'') TypeName2,[Rate2],isnull(cur2.[CurrencySymbol],'') CurrencySymbol2,[Skill],[Jobimage],
                    up.UP_firstName+' '+up.UP_lastName Created_By,Convert(varchar,job.Created_On,106) [Created_On],[Created_Time],up1.UP_firstName+' '+up1.UP_lastName Last_Updated_By,Convert(varchar
                    ,[Last_Updated_On],106) [Last_Updated_On],[Updated_Time],loc.LocationName,cli.ClientCompanyName,con.ContactPerson,CloseComments
                    FROM [Job_Master_USA] job
                    join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                    join Priority_Master pri on pri.PriorityID=job.Prioritylevel
                    join Type_Master typ on typ.TypeID=job.WorkType1
                    left join Type_Master typ2 on typ2.TypeID=job.WorkType2
                    join Jobstatus_Master sta on sta.JobstatusID=job.Jobstatus
                    join Currency_Master cur1 on cur1.CurrencyID=job.Currency1
                    left join Currency_Master cur2 on cur2.CurrencyID=job.Currency2
                    join Location_Master loc on loc.LocationID=job.Location 
                    join Userprofile up on up.TWE_ID=job.Created_By
                    left join Userprofile up1 on up1.TWE_ID=job.Last_Updated_By
                    join ClientMaster cli on cli.ClientID=job.Clientname
					join Client_Contact_Person con on job.Contactname=con.ClientContactID
                    where jobcode='" + jobid + "'";


            SqlDataReader _read = _sql.doRead(query);
            while (_read.Read())
            {
                _jc.Jobcodename = _read[0].ToString();
                _jc.JobTitle = _read[1].ToString();
                _jc.Duration = _read[2].ToString();
                _jc.EmplType = _read[3].ToString();
                _jc.City = _read[4].ToString();
                _jc.State = _read[5].ToString();
                _jc.Country = _read[6].ToString();
                _jc.Description = _read[7].ToString();
                _jc.AssignedTo = _read[8].ToString();
                _jc.Prioritylevel = _read[9].ToString();
                _jc.Jobstatus = _read[10].ToString();
                _jc.WorkType1 = _read[11].ToString();
                _jc.Rate1 = _read[12].ToString();
                _jc.Currency1 = _read[13].ToString();
                _jc.WorkType2 = _read[14].ToString();
                _jc.Rate2 = _read[15].ToString();
                _jc.Currency2 = _read[16].ToString();
                _jc.Skill = _read[17].ToString();
                _jc.Jobimage = _read[18].ToString();
                _jc.Created_By = _read[19].ToString();
                _jc.Created_On = _read[20].ToString();
                _jc.Created_Time = _read[21].ToString();

                if (!(_read[22].Equals(System.DBNull.Value)))
                {
                    _jc.Updated_By = _read[22].ToString();
                }
                else
                {
                    _jc.Updated_By = "";
                }

                if (!(_read[23].Equals(System.DBNull.Value)))
                {
                    _jc.Updated_On = _read[23].ToString();
                }
                else
                {
                    _jc.Updated_On = "";
                }

                if (!(_read[24].Equals(System.DBNull.Value)))
                {
                    _jc.Updated_Time = _read[24].ToString();
                }
                else
                {
                    _jc.Updated_Time = "";
                }

                _jc.Location = _read[25].ToString();
                _jc.Clientname = _read[26].ToString();
                _jc.Contactname = _read[27].ToString();
                _jc.CloseComments = _read[28].ToString();

            }
            _read.Close();

            if (_jc.Skill != "")
            {

                query = "select SkillName from Skill_Master where SkillID in (" + _jc.Skill + ")";
                _read = _sql.doRead(query);

                _jc.Skill = "";
                while (_read.Read())
                {
                    _jc.Skill += _read[0].ToString() + "|";
                }

                _jc.Skill = _jc.Skill.Substring(0, _jc.Skill.Length - 1);
                _read.Close();

            }



            if (_jc.AssignedTo.Contains(','))
            {
                string[] strEmp = _jc.AssignedTo.Split(',');
                string empName = "";
                for (int i = 0; i < strEmp.Length; i++)
                {
                    query = @"select UP_firstName+' '+UP_lastName EmpName from Userprofile where TWE_ID='" + strEmp[i] + "'";
                    _read = _sql.doRead(query);
                    while (_read.Read())
                    {
                        empName += _read[0].ToString() + ", ";
                    }
                    _read.Close();
                }

                _jc.AssignedTo = empName.Substring(0, empName.Length - 1);
            }
            else
            {
                query = @"select UP_firstName+' '+UP_lastName EmpName from Userprofile where TWE_ID='" + _jc.AssignedTo + "'";
                _read = _sql.doRead(query);
                while (_read.Read())
                {
                    _jc.AssignedTo = _read[0].ToString();
                }
                _read.Close();
            }


            //query = @"SELECT [candidateid],[jobcode],[candidateemailid],[candidatemobileno],[candidatename],[ratePerHr],[type],[employermailid]
            //            ,[employeename],[corporationname],sta.CandidateStatusName [Cand_Status],[Submitted_To],up.UP_firstName+' '+UP_lastName [Created_By],
            //            Convert(varchar,[Created_On],106) [Created_On],[linkedinURL],[CreatedTime] FROM [CandidateDetails] can
            //            join CandidateStatus_Master sta on sta.CandidateStatusID=can.Cand_Status
            //            join Userprofile up on up.TWE_ID=can.Created_By
            //            where Jobcode='" + jobid + "'";

            if (type == "Feedback")
            {
                if (createdBy == "")
                {
                    query = @"SELECT can.candidateid,job.jobcode,[candidateemailid],[candidatemobileno],[candidatename],[ratePerHr],typ.TypeName,empc.MailId
                        ,empc.ContactPerson,empl.employercorporationaname,sta.CandidateStatusName [Cand_Status],[Submitted_To],up.UP_firstName+' '+UP_lastName [Created_By],
                        Convert(varchar,can.Created_On,106) [Created_On],[linkedinURL],[CreatedTime] FROM [CandidateDetails] can                        
                        join CandidateJob canjob on canjob.CandidateId=can.candidateid	
                        join CandidateStatus_Master sta on sta.CandidateStatusID=canjob.Cand_Status
						join Job_Master_USA job on job.Jobcode=canjob.Jobcode		                                                                    				
                        join EmployerDetails empl on empl.employerid=can.employerid
                        join EmployerContactPerson empc on empc.VendorID=empl.employerid
                        join Userprofile up on up.TWE_ID=can.Created_By
                        join Type_Master typ on typ.TypeID=can.type
                        where job.Jobcode='" + jobid + "' and Cand_Status not in ('101','102','104','106','108','109')  order by can.created_on desc,CreatedTime desc";
                }
                else
                {
                    query = @"SELECT can.candidateid,job.jobcode,[candidateemailid],[candidatemobileno],[candidatename],[ratePerHr],typ.TypeName,empc.MailId
                        ,empc.ContactPerson,empl.employercorporationaname,sta.CandidateStatusName [Cand_Status],[Submitted_To],up.UP_firstName+' '+UP_lastName [Created_By],
                        Convert(varchar,can.Created_On,106) [Created_On],[linkedinURL],[CreatedTime] FROM [CandidateDetails] can                        
                        join CandidateJob canjob on canjob.CandidateId=can.candidateid	
                        join CandidateStatus_Master sta on sta.CandidateStatusID=canjob.Cand_Status
						join Job_Master_USA job on job.Jobcode=canjob.Jobcode		                                                                    				
                        join EmployerDetails empl on empl.employerid=can.employerid
                        join EmployerContactPerson empc on empc.VendorID=empl.employerid
                        join Userprofile up on up.TWE_ID=can.Created_By
                        join Type_Master typ on typ.TypeID=can.type 
                        where job.Jobcode='" + jobid + "' and Cand_Status not in ('101','102','104','106','108','109')  and  can.Created_By='" + createdBy + "' order by can.created_on desc,CreatedTime desc";
                }
            }
            else
            {
                query = @"SELECT can.candidateid,job.jobcode,[candidateemailid],[candidatemobileno],[candidatename],[ratePerHr],typ.TypeName,empc.MailId
                        ,empc.ContactPerson,empl.employercorporationaname,sta.CandidateStatusName [Cand_Status],[Submitted_To],up.UP_firstName+' '+UP_lastName [Created_By],
                        Convert(varchar,can.Created_On,106) [Created_On],[linkedinURL],[CreatedTime] FROM [CandidateDetails] can                        
                        join CandidateJob canjob on canjob.CandidateId=can.candidateid	
                        join CandidateStatus_Master sta on sta.CandidateStatusID=canjob.Cand_Status
						join Job_Master_USA job on job.Jobcode=canjob.Jobcode		                                                                    				
                        join EmployerDetails empl on empl.employerid=can.employerid
                        join EmployerContactPerson empc on empc.VendorID=empl.employerid
                        join Userprofile up on up.TWE_ID=can.Created_By
                        join Type_Master typ on typ.TypeID=can.type 
                        where job.Jobcode='" + jobid + "'  order by can.created_on desc,CreatedTime desc";
            }

            _read = _sql.doRead(query);
            while (_read.Read())
            {
                candidatelist candilst = new candidatelist();
                candilst.candidateid = _read[0].ToString();
                candilst.candidatemediapath = "";
                candilst.candidateemailid = _read[2].ToString();
                candilst.candidatemobno = _read[3].ToString();
                candilst.candidatename = _read[4].ToString();
                candilst.ratePerHr = _read[5].ToString();
                candilst.type = _read[6].ToString();
                candilst.vendoremailid = _read[7].ToString();
                candilst.vendorname = _read[8].ToString();
                candilst.candidatestatus = _read[10].ToString();
                candilst.submittedby = _read[12].ToString();
                candilst.submitteddate = _read[13].ToString();
                candilst.submittedtime = _read[15].ToString();
                candilst.linkedinURL = _read[14].ToString();
                _lstcandi.Add(candilst);
            }

            _read.Close();
            _jc.candidatelistinfo = _lstcandi;
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
                _json.data = _jc;
            }

            return _json;

        }

        public jsonArray getFollowupDetailsIndia(string jobid, string type,string createdBy)
        {
            int status = 1;
            string query = "";
            candidatelistDetailsIndia _jc = new candidatelistDetailsIndia();
            List<candidatelist> _lstcandi = new List<candidatelist>();

            query = @"SELECT [Jobcode],[JobTitle],[Duration],[EmpTypeName],job.Country,[Description]
                    ,[Assigned_To],[PriorityName],[JobstatusName],Ratetype,[Minrate],[Maxrate],Currency,
                    [Skill],[Jobimage],
                    up.UP_firstName+' '+up.UP_lastName Created_By,Convert(varchar,job.Created_On,106) [Created_On],[Created_Time],up1.UP_firstName+' '+up1.UP_lastName Last_Updated_By,Convert(varchar
                    ,[Last_Updated_On],106) [Last_Updated_On],[Updated_Time],loc.LocationName,cli.ClientCompanyName,con.ContactPerson
                    ,[Startdate],[Noofopening],[ShiftTiming],[TurnAroundtime],CloseComments
                    FROM [Job_Master_IND] job
                    join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                    join Priority_Master pri on pri.PriorityID=job.Prioritylevel
                    join Jobstatus_Master sta on sta.JobstatusID=job.Jobstatus
                    join Location_Master loc on loc.LocationID=job.Location
                    join Userprofile up on up.TWE_ID=job.Created_By
                    left join Userprofile up1 on up1.TWE_ID=job.Last_Updated_By
                    join ClientMaster cli on cli.ClientID=job.Clientname
                    join Client_Contact_Person con on job.Contactname=con.ClientContactID
                    where jobcode='" + jobid + "'";


            SqlDataReader _read = _sql.doRead(query);
            while (_read.Read())
            {
                _jc.Jobcodename = _read[0].ToString();
                _jc.JobTitle = _read[1].ToString();
                _jc.Duration = _read[2].ToString();
                _jc.EmplType = _read[3].ToString();
                _jc.Country = _read[4].ToString();
                _jc.Description = _read[5].ToString();
                _jc.AssignedTo = _read[6].ToString();
                _jc.Prioritylevel = _read[7].ToString();
                _jc.Jobstatus = _read[8].ToString();
                _jc.Ratetype = _read[9].ToString();
                _jc.Minrate = _read[10].ToString();
                _jc.Maxrate = _read[11].ToString();
                _jc.Currency = _read[12].ToString();
                _jc.Skill = _read[13].ToString();
                _jc.Jobimage = _read[14].ToString();
                _jc.Created_By = _read[15].ToString();
                _jc.Created_On = _read[16].ToString();
                _jc.Created_Time = _read[17].ToString();

                if (!(_read[18].Equals(System.DBNull.Value)))
                {
                    _jc.Updated_By = _read[18].ToString();
                }
                else
                {
                    _jc.Updated_By = "";
                }

                if (!(_read[19].Equals(System.DBNull.Value)))
                {
                    _jc.Updated_On = _read[19].ToString();
                }
                else
                {
                    _jc.Updated_On = "";
                }

                if (!(_read[20].Equals(System.DBNull.Value)))
                {
                    _jc.Updated_Time = _read[20].ToString();
                }
                else
                {
                    _jc.Updated_Time = "";
                }

                _jc.Location = _read[21].ToString();
                _jc.Clientname = _read[22].ToString();
                _jc.Contactname = _read[23].ToString();
                _jc.Startdate = _read[24].ToString();
                _jc.Noofopening = _read[25].ToString();
                _jc.ShiftTiming = _read[26].ToString();
                _jc.TurnAroundtime = _read[27].ToString();
                _jc.CloseComments = _read[28].ToString();

            }
            _read.Close();


            if (_jc.Skill != "")
            {

                query = "select SkillName from Skill_Master where SkillID in (" + _jc.Skill + ")";
                _read = _sql.doRead(query);

                _jc.Skill = "";
                while (_read.Read())
                {
                    _jc.Skill += _read[0].ToString() + "|";
                }

                _jc.Skill = _jc.Skill.Substring(0, _jc.Skill.Length - 1);
                _read.Close();

            }



            if (_jc.AssignedTo.Contains(','))
            {
                string[] strEmp = _jc.AssignedTo.Split(',');
                string empName = "";
                for (int i = 0; i < strEmp.Length; i++)
                {
                    query = @"select UP_firstName+' '+UP_lastName EmpName from Userprofile where TWE_ID='" + strEmp[i] + "'";
                    _read = _sql.doRead(query);
                    while (_read.Read())
                    {
                        empName += _read[0].ToString() + ", ";
                    }
                    _read.Close();
                }

                _jc.AssignedTo = empName.Substring(0, empName.Length - 1);
            }
            else
            {
                query = @"select UP_firstName+' '+UP_lastName EmpName from Userprofile where TWE_ID='" + _jc.AssignedTo + "'";
                _read = _sql.doRead(query);
                while (_read.Read())
                {
                    _jc.AssignedTo = _read[0].ToString();
                }
                _read.Close();
            }


            //query = @"SELECT [candidateid],[jobcode],[candidateemailid],[candidatemobileno],[candidatename],[ratePerHr],[type],[employermailid]
            //            ,[employeename],[corporationname],sta.CandidateStatusName [Cand_Status],[Submitted_To],up.UP_firstName+' '+UP_lastName [Created_By],
            //            Convert(varchar,[Created_On],106) [Created_On],[linkedinURL],[CreatedTime] FROM [CandidateDetails] can
            //            join CandidateStatus_Master sta on sta.CandidateStatusID=can.Cand_Status
            //            join Userprofile up on up.TWE_ID=can.Created_By
            //            where Jobcode='" + jobid + "'";

            if (type == "Feedback")
            {
                if (createdBy=="")
                {
                    query = @"SELECT can.candidateid,job.jobcode,[candidateemailid],[candidatemobileno],[candidatename],[ratePerHr],typ.TypeName,empl.employeremailid
                        ,empl.employername,empl.employercorporationaname,sta.CandidateStatusName [Cand_Status],[Submitted_To],up.UP_firstName+' '+UP_lastName [Created_By],
                        Convert(varchar,can.Created_On,106) [Created_On],[linkedinURL],[CreatedTime],currentLocation,TotYearsofExp FROM [CandidateDetailsIndia] can                        
                        join CandidateJobIndia canjob on canjob.CandidateId=can.candidateid	
                        join CandidateStatus_Master sta on sta.CandidateStatusID=canjob.Cand_Status
						join Job_Master_IND job on job.Jobcode=canjob.Jobcode		                                                                    				
                        left join EmployerDetailsIndia empl on empl.employerid=can.employerid
                        join Userprofile up on up.TWE_ID=can.Created_By
                        join RateType_Master typ on typ.TypeID=can.type
                        where job.Jobcode='" + jobid + "' and Cand_Status not in ('104','106','108','109') order by can.created_on desc,CreatedTime desc";
                }

                else
                {
                    query = @"SELECT can.candidateid,job.jobcode,[candidateemailid],[candidatemobileno],[candidatename],[ratePerHr],typ.TypeName,empl.employeremailid
                        ,empl.employername,empl.employercorporationaname,sta.CandidateStatusName [Cand_Status],[Submitted_To],up.UP_firstName+' '+UP_lastName [Created_By],
                        Convert(varchar,can.Created_On,106) [Created_On],[linkedinURL],[CreatedTime],currentLocation,TotYearsofExp FROM [CandidateDetailsIndia] can                        
                        join CandidateJobIndia canjob on canjob.CandidateId=can.candidateid	
                        join CandidateStatus_Master sta on sta.CandidateStatusID=canjob.Cand_Status
						join Job_Master_IND job on job.Jobcode=canjob.Jobcode		                                                                    				
                        left join EmployerDetailsIndia empl on empl.employerid=can.employerid
                        join Userprofile up on up.TWE_ID=can.Created_By
                        join RateType_Master typ on typ.TypeID=can.type
                        where job.Jobcode='" + jobid + "' and Cand_Status not in ('104','106','108','109') and  can.Created_By='"+createdBy+ "' order by can.created_on desc,CreatedTime desc";
                }
                
            }
            else
            {
                query = @"SELECT can.candidateid,job.jobcode,[candidateemailid],[candidatemobileno],[candidatename],[ratePerHr],typ.TypeName,empl.employeremailid
                        ,empl.employername,empl.employercorporationaname,sta.CandidateStatusName [Cand_Status],[Submitted_To],up.UP_firstName+' '+UP_lastName [Created_By],
                        Convert(varchar,can.Created_On,106) [Created_On],[linkedinURL],[CreatedTime],currentLocation,TotYearsofExp FROM [CandidateDetailsIndia] can                        
                        join CandidateJobIndia canjob on canjob.CandidateId=can.candidateid	
                        join CandidateStatus_Master sta on sta.CandidateStatusID=canjob.Cand_Status
						join Job_Master_IND job on job.Jobcode=canjob.Jobcode		                                                                    				
                        left join EmployerDetailsIndia empl on empl.employerid=can.employerid
                        join Userprofile up on up.TWE_ID=can.Created_By
                        join RateType_Master typ on typ.TypeID=can.type
                        where job.Jobcode='" + jobid + "' order by can.created_on desc,CreatedTime desc";
            }

            _read = _sql.doRead(query);
            while (_read.Read())
            {
                candidatelist candilst = new candidatelist();
                candilst.candidateid = _read[0].ToString();
                candilst.candidatemediapath = "";
                candilst.candidateemailid = _read[2].ToString();
                candilst.candidatemobno = _read[3].ToString();
                candilst.candidatename = _read[4].ToString();
                candilst.ratePerHr = _read[5].ToString();
                candilst.type = _read[6].ToString();
                candilst.vendoremailid = _read[7].ToString();
                candilst.vendorname = _read[8].ToString();
                candilst.candidatestatus = _read[10].ToString();
                candilst.submittedby = _read[12].ToString();
                candilst.submitteddate = _read[13].ToString();
                candilst.submittedtime = _read[15].ToString();
                candilst.linkedinURL = _read[14].ToString();
                candilst.currLocation = _read[16].ToString();
                candilst.totYrsExp = _read[17].ToString();
                _lstcandi.Add(candilst);
            }

            _read.Close();
            _jc.candidatelistinfo = _lstcandi;
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
                _json.data = _jc;
            }

            return _json;

        }
        public jsonArray getFollowupSearch(string jobid, string fromdate, string todate, string searchkey)
        {
            int status = 1;
            string query = "";
            string[] strsplit = new string[4];
            strsplit[0] = "";
            strsplit[1] = "";
            strsplit[2] = "";
            strsplit[3] = "";
            string[] strsplit2 = searchkey.Split(' ');
            for (int i = 0; i < strsplit2.Length; i++)
            {
                strsplit[i] = strsplit2[i];

            }
            if (strsplit2.Length == 1)
            {
                strsplit[0] = strsplit2[0];
                strsplit[1] = strsplit2[0];
                strsplit[2] = strsplit2[0];
                strsplit[3] = strsplit2[0];
            }



            List<candidatelist> _lstcandilist = new List<candidatelist>();
            if (strsplit2.Length > 1)
            {

                //query = @"SELECT [candidateid],[jobcode],[candidateemailid],[candidatemobileno],[candidatename],[ratePerHr],[type],[employermailid]
                //              ,[employeename],[corporationname],cand.CandidateStatusName [Cand_Status],[Submitted_To],[Created_By],
                //              Convert(varchar,[Created_On],106) [Created_On] FROM [CandidateDetails] can join CandidateStatus_Master cand on can.Cand_Status=cand.CandidateStatusID where Jobcode='" + jobid + "' and candidatename like '" + strsplit[0] + "%' and" +
                //              " employeename like '" + strsplit[1] + "%' and cand.CandidateStatusName like '" + strsplit[2] + "%' and Created_On like '" + strsplit[3] + "%'";


                query = @"SELECT can.candidateid,[jobcode],[candidateemailid],[candidatemobileno],[candidatename],[ratePerHr],[type],empc.MailId,empc.ContactPerson,
                               [employercorporationaname],cand.CandidateStatusName [Cand_Status],[Submitted_To], up.UP_firstName+' ' +up.UP_lastName Created_By,
                              Convert(varchar,can.Created_On,106) [Created_On] FROM [CandidateDetails] can 
							  join CandidateStatus_Master cand on can.Cand_Status=cand.CandidateStatusID 
                              join CandidateJob canjob on canjob.Jobcode=job.Jobcode	
							  join EmployerDetails empl on empl.employerid=can.employerid
                              join EmployerContactPerson empc on empc.VendorID=empl.employerid
                              join Userprofile up on up.TWE_ID=can.Created_By
							  where Jobcode='" + jobid + "' and candidatename like '" + strsplit[0] + "%' and employername like '" + strsplit[1] +
                                  "%' and cand.CandidateStatusName like '" + strsplit[2] + "%' and can.Created_On like '" + strsplit[3] + "%'";
            }
            else if (strsplit2.Length == 1)
            {

                query = @"SELECT can.candidateid,[jobcode],[candidateemailid],[candidatemobileno],[candidatename],[ratePerHr],[type],empc.MailId,empc.ContactPerson,
                              [employercorporationaname],cand.CandidateStatusName [Cand_Status],[Submitted_To],up.UP_firstName+' ' +up.UP_lastName Created_By,
                              Convert(varchar,can.Created_On,106) [Created_On] FROM [CandidateDetails] can 
							  join CandidateStatus_Master cand on can.Cand_Status=cand.CandidateStatusID 
                              join CandidateJob canjob on canjob.Jobcode=job.Jobcode	
							  join EmployerDetails empl on empl.employerid=can.employerid
                              join EmployerContactPerson empc on empc.VendorID=empl.employerid
                              join Userprofile up on up.TWE_ID=can.Created_By
							  where Jobcode='" + jobid + "' and candidatename like '" + strsplit[0] + "%' or employername like '" + strsplit[1] +
                              "%' or cand.CandidateStatusName like '" + strsplit[2] + "%' or can.Created_On like '" + strsplit[3] + "%'";

                //query = @"SELECT [candidateid],[jobcode],[candidateemailid],[candidatemobileno],[candidatename],[ratePerHr],[type],[employermailid]
                //              ,[employeename],[corporationname],cand.CandidateStatusName [Cand_Status],[Submitted_To],[Created_By],
                //              Convert(varchar,[Created_On],106) [Created_On] FROM [CandidateDetails] can join CandidateStatus_Master cand on can.Cand_Status=cand.CandidateStatusID where Jobcode='" + jobid + "' and candidatename like '" + strsplit[0] + "%' or" +
                //              " employeename like '" + strsplit[1] + "%' or cand.CandidateStatusName like '" + strsplit[2] + "%' or Created_On like '" + strsplit[3] + "%'";

            }
            SqlDataReader _read = _sql.doRead(query);
            while (_read.Read())
            {
                candidatelist candilst = new candidatelist();
                candilst.candidateid = _read[0].ToString();
                candilst.candidatemediapath = "";
                candilst.candidateemailid = _read[2].ToString();
                candilst.candidatemobno = _read[3].ToString();
                candilst.candidatename = _read[4].ToString();
                candilst.ratePerHr = _read[5].ToString();
                candilst.type = _read[6].ToString();
                candilst.vendoremailid = _read[7].ToString();
                candilst.vendorname = _read[8].ToString();
                candilst.candidatestatus = _read[10].ToString();
                candilst.submittedby = _read[12].ToString();
                candilst.submitteddate = _read[13].ToString();
                candilst.submittedtime = "";
                _lstcandilist.Add(candilst);
            }
            _read.Close();


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
                _json.data = _lstcandilist;
            }

            return _json;
        }
        public jsonArray insertCandidatedetails(Candidatedetails candi)
        {

            int status = 1;
            string query = "";
            DateTime dateTime_Eastern = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));
            var timeInEST = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));
            var timeInEasternAsString = timeInEST.ToString("hh:mm tt", CultureInfo.InvariantCulture);
            if (candi.mode == "insert" && candi.employerid == "")
            {
                query = @"INSERT INTO [EmployerDetails]" +
                        "([employercorporationaname],[employerspecialization]" +
                        ",[employeradditionalinfo],[Created_By],[Created_On],[Status]) VALUES(" +
                        "'" + candi.corporationname + "','" + candi.employerspecialization + "','" + candi.employeradderinformation + "','" +
                        candi.createdBy + "','" + dateTime_Eastern.ToString("yyyy-MM-dd") + "',1)";

                _sql.doInsert(query);

                string strquery = @"select max(employerid) employerid from EmployerDetails";

                SqlDataReader _read = _sql.doRead(strquery);
                while (_read.Read())
                {
                    candi.employerid = _read[0].ToString();
                }

                _read.Close();

                query = @"insert into EmployerContactPerson (" +
                            "ContactPerson,ContactNo,MailId,VendorID,VenConStatus,[Created_By],[Created_On]) values('" +
                             candi.employeename + "','" + candi.employerContactno + "','" + candi.employermailid + "'," + candi.employerid +
                             ",1,'" + candi.createdBy + "','" + dateTime_Eastern.ToString("yyyy-MM-dd") + "')";

                _sql.doInsert(query);

               
            }

            else if (candi.mode == "update")
            {
                query = @"update EmployerDetails set employeremailid='" + candi.employermailid + "',employermobileno='" + candi.employerContactno
                    + "',employername='" + candi.employeename + "',employerspecialization='" + candi.employerspecialization +
                    "',employeradditionalinfo='" + candi.employeradderinformation + "',employercorporationaname='" + candi.corporationname
                    + "',Updated_By='" + candi.lastupdatedBy + "',Updated_On='" + dateTime_Eastern.ToString("yyyy-MM-dd")
                    + "' where employerid='" + candi.employerid + "'";

                _sql.doInsert(query);


            }


            if (candi.mode == "insert")
            {
                query = @"insert into CandidateDetails ([candidateemailid]
                                                      ,[candidatemobileno]
                                                      ,[candidatename]
                                                      ,[currentLocation]
                                                      ,[VisaStatus]
                                                      ,[YearsofExp]
                                                      ,[ratecoverage]
                                                      ,[relocate]
                                                      ,[ratePerHr]
                                                      ,[type]
                                                      ,[skillsandCertif]
                                                      ,[linkedinURL]
                                                      ,[noticePeriod]
                                                      ,[availableforinterview]
                                                      ,[employerid]                                                      
                                                      ,[Created_By]
                                                      ,[Created_On]
                                                      ,[CreatedTime]) values('" +
                                                      candi.candidateemailid + "','" + candi.candidatemobileno + "','" + candi.candidatename + "','" +
                                                      candi.currentLocation + "','" + candi.visastatus + "','" + candi.yrsofexp + "','" + candi.ratecoverage + "','" +
                                                      candi.relocate + "','" + candi.ratePerHr + "','" +
                                                      candi.type + "','" + candi.skillsandCertif + "','" + candi.linkedinURL + "','" + candi.noticePeriod + "','" +
                                                      candi.availableforinterview + "','" + candi.employerid + "','" +
                                                      candi.createdBy + "','" + dateTime_Eastern.ToString("yyyy-MM-dd") + "','" + timeInEasternAsString + "')";

                _sql.doInsert(query);

                if (candi.candidateid == "")
                {
                    string strquery = @"select max(candidateid) candidateid from CandidateDetails";

                    SqlDataReader _read = _sql.doRead(strquery);
                    while (_read.Read())
                    {
                        candi.candidateid = _read[0].ToString();
                    }

                    _read.Close();
                }

                query = @"insert CandidateJob(CandidateId,Jobcode,Created_By,Created_On,candidateRemark,RecruiterRating,Cand_Status) values (" + candi.candidateid + ",'" + candi.jobcode + "','" + candi.createdBy + "','" + dateTime_Eastern.ToString("yyyy-MM-dd") + "','" + candi.candidateRemark + "','" + candi.recruiterrating + "','" + candi.candStatus + "')";

                _sql.doInsert(query);
            }
            else if (candi.mode == "update")
            {
                query = @"update CandidateDetails set candidateemailid='" + candi.candidateemailid + "',candidatemobileno='" +
                    candi.candidatemobileno + "',candidatename='" + candi.candidatename + "',currentLocation='" + candi.currentLocation + "',VisaStatus='" +
                    candi.visastatus + "',YearsofExp='" + candi.yrsofexp + "',ratecoverage='" + candi.ratecoverage + "',relocate='" + candi.relocate +
                    "',ratePerHr='" + candi.ratePerHr + "',type='" + candi.type + "',skillsandCertif='" +
                    candi.skillsandCertif + "',linkedinURL='" + candi.linkedinURL + "',noticePeriod='" + candi.noticePeriod + "',availableforinterview='" +
                    candi.availableforinterview + "',employerid='" + candi.employerid + "',Last_Updated_By='" + candi.lastupdatedBy + "',Last_Updated_On='" +
                    dateTime_Eastern.ToString("yyyy-MM-dd") + "',UpdatedTime='" + timeInEasternAsString + "' where candidateid='" + candi.candidateid + "'";

                _sql.doInsert(query);

                string strquery = @"select Jobcode from CandidateJob where CandidateId='" + candi.candidateid + "'";

                string jobExists = "";
                SqlDataReader _read = _sql.doRead(strquery);

                while (_read.Read())
                {
                    jobExists = _read[0].ToString();
                }

                _read.Close();
                if (jobExists != "")
                {
                    strquery = @"select Jobcode from CandidateJob where CandidateId='" + candi.candidateid + "' and Jobcode='" + candi.jobcode + "'";

                    _read = _sql.doRead(strquery);
                    int ifExists = 0;
                    while (_read.Read())
                    {
                        ifExists = 1;
                    }

                    _read.Close();

                    if (ifExists == 0)
                    {
                        query = @"insert CandidateJob(CandidateId,Jobcode,Created_By,Created_On,candidateRemark,RecruiterRating,Cand_Status,Created_time) values (" + candi.candidateid + ",'" + candi.jobcode + "','" + candi.createdBy + "','" + dateTime_Eastern.ToString("yyyy-MM-dd") + "','" + candi.candidateRemark + "','" + candi.recruiterrating + "','" + candi.candStatus + "','" + timeInEasternAsString + "')";

                    }
                    else
                    {
                        query = @"update CandidateJob set candidateRemark='" + candi.candidateRemark + "',RecruiterRating='" + candi.recruiterrating + "',Cand_Status='" + candi.candStatus + "',Updated_On='" +
                            dateTime_Eastern.ToString("yyyy-MM-dd") + "',Updated_time='" + timeInEasternAsString + "',Updated_By='" + candi.lastupdatedBy + "' where CandidateId='" + candi.candidateid + "' and Jobcode='" + candi.jobcode + "'";

                    }


                    _sql.doInsert(query);
                }

                else
                {
                    query = @"update CandidateJob set candidateRemark='" + candi.candidateRemark + "',Jobcode='" + candi.jobcode + "',RecruiterRating='" + candi.recruiterrating + "',Cand_Status='" + candi.candStatus + "',Updated_On='" +
                            dateTime_Eastern.ToString("yyyy-MM-dd") + "',Updated_time='" + timeInEasternAsString + "',Updated_By='" + candi.lastupdatedBy + "' where CandidateId='" + candi.candidateid + "'";

                    _sql.doInsert(query);
                }

            }



            if (candi.mode == "insert")
            {
                string strquery = @"select max(candidateid) candidateid from CandidateDetails";

                SqlDataReader _read = _sql.doRead(strquery);
                while (_read.Read())
                {
                    candi.candidateid = _read[0].ToString();
                }
                _read.Close();
            }

            for (int i = 0; i < candi.lstCandProof.Count; i++)
            {
                if (candi.lstCandProof[i].mode == "insert")
                {
                    query = @"insert into candproofdetails (" +
                        "candidateid,documenttype,idNo,idfilename) values('" +
                        candi.candidateid + "','" + candi.lstCandProof[i].documenttype + "','" +
                        candi.lstCandProof[i].idNo + "','" + candi.lstCandProof[i].idfilename + "')";


                }
                else if (candi.lstCandProof[i].mode == "update")
                {
                    query = @"update candproofdetails set " +
                        "documenttype='" + candi.lstCandProof[i].documenttype + "',idNo='" +
                        candi.lstCandProof[i].idNo + "',idfilename='" + candi.lstCandProof[i].idfilename +
                        "' where candproofid='" + candi.lstCandProof[i].candproofid + "'";


                }
                _sql.doInsert(query);
            }

            if (candi.mode == "update" && candi.candStatus == "103")
            {
                sendSubmissionMail(candi);
            }
            jsonArray _json = new jsonArray();
            if (status == 0)
            {
                _json.status = "0";
                _json.message = "Candidate SQL QUERY EXECUTION FAILED";
                _json.data = new object();
            }
            else
            {
                _json = new jsonArray();
                _json.status = "1";
                _json.message = "Candidate SQL QUERY EXECUTED";
                _json.data = "";
            }

            return _json;
        }
        public jsonArray getCandidateViewdata(string Candidateid)
        {
            int status = 1;
            string query = "";
            Candidatedetails _cd = new Candidatedetails();
            query = @"SELECT job.jobcode,[candidateemailid],[candidatemobileno],[candidatename],[currentLocation],[VisaStatus],[YearsofExp],
                            [ratecoverage],[relocate],[ratePerHr],[type],[skillsandCertif],[linkedinURL],[noticePeriod],
                            [availableforinterview],[MailId],[ContactNo],[ContactPerson],[employercorporationaname],[employeradditionalinfo],[employerspecialization],
                            [candidateRemark],cand.Created_By,cand.Created_On,cand.Last_Updated_By,cand.Last_Updated_On,[Cand_Status],[RTRemailstatus],empl.employerid,[RecruiterRating] FROM [CandidateDetails] cand
							join EmployerDetails empl on cand.employerid=empl.employerid
                            join EmployerContactPerson empc on empc.VendorID=empl.employerid
                            join CandidateJob canjob on canjob.CandidateId=cand.candidateid 
                            left join Job_Master_USA job on job.Jobcode=canjob.Jobcode 
							left join RTRConfirmation rtr on rtr.candidateemaildid=cand.candidateemailid
                            where cand.candidateid='" + Candidateid + "'";


            SqlDataReader _read = _sql.doRead(query);

            while (_read.Read())
            {
                _cd.jobcode = _read[0].ToString();
                _cd.candidateemailid = _read[1].ToString();
                _cd.candidatemobileno = _read[2].ToString();
                _cd.candidatename = _read[3].ToString();
                _cd.currentLocation = _read[4].ToString();
                _cd.visastatus = _read[5].ToString();
                _cd.yrsofexp = _read[6].ToString();
                _cd.ratecoverage = _read[7].ToString();
                _cd.relocate = _read[8].ToString();
                _cd.ratePerHr = _read[9].ToString();
                _cd.type = _read[10].ToString();
                _cd.skillsandCertif = _read[11].ToString();
                _cd.linkedinURL = _read[12].ToString();
                _cd.noticePeriod = _read[13].ToString();
                _cd.availableforinterview = _read[14].ToString();
                _cd.employermailid = _read[15].ToString();
                _cd.employerContactno = _read[16].ToString();
                _cd.employeename = _read[17].ToString();
                _cd.corporationname = _read[18].ToString();
                _cd.employeradderinformation = _read[19].ToString();
                _cd.employerspecialization = _read[20].ToString();
                _cd.candidateRemark = _read[21].ToString();
                _cd.createdBy = _read[22].ToString();
                _cd.createdOn = _read[23].ToString();
                _cd.lastupdatedBy = _read[24].ToString();
                _cd.lastupdatedOn = _read[25].ToString();
                _cd.candStatus = _read[26].ToString();
                _cd.rtrStatus = _read[27].ToString();
                _cd.employerid = _read[28].ToString();
                _cd.recruiterrating = _read[29].ToString();
            }

            _read.Close();

            _cd.lstCandProof = new List<candidateProof>();

            query = @"select candproofid,documenttype,idNo,idfilename from candproofdetails" +
                            " where candidateid='" + Candidateid + "'";


            _read = _sql.doRead(query);
            while (_read.Read())
            {
                candidateProof objProof = new candidateProof();
                objProof.candproofid = _read[0].ToString();
                objProof.documenttype = _read[1].ToString();
                objProof.idNo = _read[2].ToString();
                objProof.idfilename = _read[3].ToString();
                _cd.lstCandProof.Add(objProof);
            }


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
                _json.data = _cd;
            }

            return _json;

        }
        public jsonArray getCandidateInfodata(string Candidateid, string jobid)
        {
            int status = 1;
            string query = "";
            

            Candidatedetails _cd = new Candidatedetails();
            _cd.genuinityStatus = "false";

            query = "select * from CandidateJob where Jobcode='" + jobid + "' and CandidateId='" + Candidateid + "'";
            string isExists = "";
            SqlDataReader _read = _sql.doRead(query);

            while (_read.Read())
            {
                isExists = _read[0].ToString();
            }

            _read.Close();

            if (isExists != "")
            {
                query = @"SELECT canjob.jobcode,[candidateemailid],[candidatemobileno],[candidatename],[currentLocation],[VisaStatus],[YearsofExp],
                            [ratecoverage],[relocate],[ratePerHr],[type],[skillsandCertif],[linkedinURL],[noticePeriod],
                            [availableforinterview],[MailId],[ContactNo],[ContactPerson],[employercorporationaname],[employeradditionalinfo],[employerspecialization],
                            empl.employerid,RecruiterRating,candidateRemark,Cand_Status,RTRemailstatus FROM [CandidateDetails] cand
							join EmployerDetails empl on cand.employerid=empl.employerid
                            join EmployerContactPerson empc on empc.VendorID=empl.employerid
                            join CandidateJob canjob on canjob.CandidateId=cand.candidateid
							join Job_Master_USA job on job.Jobcode=canjob.Jobcode		
                            left join RTRConfirmation rtr on rtr.candidateemaildid=cand.candidateemailid and rtr.jobcode=canjob.Jobcode
                            where cand.candidateid='" + Candidateid + "' and job.Jobcode='" + jobid + "'";
            }

            else
            {
                query = @"SELECT canjob.jobcode,[candidateemailid],[candidatemobileno],[candidatename],[currentLocation],[VisaStatus],[YearsofExp],
                            [ratecoverage],[relocate],[ratePerHr],[type],[skillsandCertif],[linkedinURL],[noticePeriod],
                            [availableforinterview],[MailId],[ContactNo],[ContactPerson],[employercorporationaname],[employeradditionalinfo],[employerspecialization],
                            empl.employerid,'' RecruiterRating,''candidateRemark,''Cand_Status,''RTRemailstatus FROM [CandidateDetails] cand
							join EmployerDetails empl on cand.employerid=empl.employerid
                            join EmployerContactPerson empc on empc.VendorID=empl.employerid
                            join CandidateJob canjob on canjob.CandidateId=cand.candidateid
							left join Job_Master_USA job on job.Jobcode=canjob.Jobcode		
                            left join RTRConfirmation rtr on rtr.candidateemaildid=cand.candidateemailid and rtr.jobcode=canjob.Jobcode
                            where cand.candidateid='" + Candidateid + "'";
            }




            _read = _sql.doRead(query);

            while (_read.Read())
            {
                _cd.jobcode = _read[0].ToString();
                _cd.candidateemailid = _read[1].ToString();
                _cd.candidatemobileno = _read[2].ToString();
                _cd.candidatename = _read[3].ToString();
                _cd.currentLocation = _read[4].ToString();
                _cd.visastatus = _read[5].ToString();
                _cd.yrsofexp = _read[6].ToString();
                _cd.ratecoverage = _read[7].ToString();
                _cd.relocate = _read[8].ToString();
                _cd.ratePerHr = _read[9].ToString();
                _cd.type = _read[10].ToString();
                _cd.skillsandCertif = _read[11].ToString();
                _cd.linkedinURL = _read[12].ToString();
                _cd.noticePeriod = _read[13].ToString();
                _cd.availableforinterview = _read[14].ToString();
                _cd.employermailid = _read[15].ToString();
                _cd.employerContactno = _read[16].ToString();
                _cd.employeename = _read[17].ToString();
                _cd.corporationname = _read[18].ToString();
                _cd.employeradderinformation = _read[19].ToString();
                _cd.employerspecialization = _read[20].ToString();
                _cd.employerid = _read[21].ToString();
                _cd.recruiterrating = _read[22].ToString();
                _cd.candidateRemark = _read[23].ToString();
                _cd.candStatus = _read[24].ToString();
                _cd.rtrStatus = _read[25].ToString();
            }

            _read.Close();

            query = @"select Jobcode,JobTitle,Jobimage,Duration,empl.EmpTypeName,loc.LocationName from 
                        Job_Master_USA job 
                        join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                        join Location_Master loc on loc.LocationID=job.Location
                        where Jobcode='" + jobid + "'";


            _read = _sql.doRead(query);

            while (_read.Read())
            {
                _cd.jobcode = _read[0].ToString();
                _cd.jobtitle = _read[1].ToString();
                _cd.jobimage = _read[2].ToString();
                _cd.jobduration = _read[3].ToString();
                _cd.jobempltype = _read[4].ToString();
                _cd.joblocation = _read[5].ToString();
            }

            _read.Close();

            _cd.lstCandProof = new List<candidateProof>();

            query = @"select candproofid,documenttype,idNo,idfilename from candproofdetails" +
                            " where candidateid='" + Candidateid + "'";


            _read = _sql.doRead(query);
            while (_read.Read())
            {
                candidateProof objProof = new candidateProof();
                objProof.candproofid = _read[0].ToString();
                objProof.documenttype = _read[1].ToString();
                objProof.idNo = _read[2].ToString();
                objProof.idfilename = _read[3].ToString();
                _cd.lstCandProof.Add(objProof);
            }

            _read.Close();

            query = @"select * from [GenuinityCheckRating] where [candidateid]=" + Candidateid;
            _read = _sql.doRead(query);

            while (_read.Read())
            {
                _cd.genuinityStatus = "true";
            }

            _read.Close();


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
                _json.data = _cd;
            }

            return _json;

        }
        public jsonArray checkCandidatedata(string emailid, string mobileno)
        {
            int status = 1;
            string query = "";
            Candidatedetails _cd = new Candidatedetails();
            string candiid = "";
            _cd.genuinityStatus = "false";

            query = @"select candidateid from [CandidateDetails] where candidateemailid='" + emailid + "' or candidatemobileno='" + mobileno + "'";
            SqlDataReader _read = _sql.doRead(query);
            while (_read.Read())
            {
                candiid = _read[0].ToString();
            }
            _read.Close();

            if (candiid != "")
            {
                query = @"SELECT [candidateemailid],[candidatemobileno],[candidatename],[currentLocation],[VisaStatus],[YearsofExp],
                            [ratecoverage],[relocate],[ratePerHr],[type],[skillsandCertif],[linkedinURL],[noticePeriod],
                            [availableforinterview],[MailId],[ContactNo],[ContactPerson],[employercorporationaname],[employeradditionalinfo],
                            cand.Created_By,cand.Created_On,cand.Last_Updated_By,cand.Last_Updated_On,[candidateemailid],employerspecialization FROM [CandidateDetails] cand
                            join EmployerDetails empl on cand.employerid=empl.employerid
                            join EmployerContactPerson empc on empc.VendorID=empl.employerid
							join CandidateJob canjob on cand.candidateid=canjob.CandidateId
                            where cand.candidateid='" + candiid + "'";


                _read = _sql.doRead(query);
                while (_read.Read())
                {
                    _cd.jobcode = "";
                    _cd.candidateemailid = _read[0].ToString();
                    _cd.candidatemobileno = _read[1].ToString();
                    _cd.candidatename = _read[2].ToString();
                    _cd.currentLocation = _read[3].ToString();
                    _cd.visastatus = _read[4].ToString();
                    _cd.yrsofexp = _read[5].ToString();
                    _cd.ratecoverage = _read[6].ToString();
                    _cd.relocate = _read[7].ToString();
                    _cd.ratePerHr = _read[8].ToString();
                    _cd.type = _read[9].ToString();
                    _cd.skillsandCertif = _read[10].ToString();
                    _cd.linkedinURL = _read[11].ToString();
                    _cd.noticePeriod = _read[12].ToString();
                    _cd.availableforinterview = _read[13].ToString();
                    _cd.employermailid = _read[14].ToString();
                    _cd.employerContactno = _read[15].ToString();
                    _cd.employeename = _read[16].ToString();
                    _cd.corporationname = _read[17].ToString();
                    _cd.employeradderinformation = _read[18].ToString();
                    _cd.createdBy = _read[19].ToString();
                    _cd.createdOn = _read[20].ToString();
                    _cd.lastupdatedBy = _read[21].ToString();
                    _cd.lastupdatedOn = _read[22].ToString();
                    _cd.candidateemailid = _read[23].ToString();
                    _cd.employerspecialization = _read[24].ToString();

                }
                _read.Close();

                query = @"select * from [GenuinityCheckRating] where [candidateid]=" + candiid;
                _read = _sql.doRead(query);

                while (_read.Read())
                {
                    _cd.genuinityStatus = "true";
                }

                _read.Close();
            }

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
                _json.data = _cd;
            }

            return _json;

        }
        public jsonArray checkEmployerdata(string emailid, string mobileno)
        {
            int status = 1;
            string query = "";
            Employerdetails _cd = new Employerdetails();
            //string emplid = "";

            //query = @"select employerid from [EmployerDetails] where employeremailid='" + emailid + "' or employermobileno='" + mobileno + "'";
            //SqlDataReader _read = _sql.doRead(query);
            //while (_read.Read())
            //{
            //    emplid = _read[0].ToString();
            //}
            //_read.Close();

            //if (emplid != "")
            //{
            query = @"SELECT [employerid],MailId,ContactNo
                        ,[ContactPerson],[employerspecialization],[employeradditionalinfo],[employercorporationaname]
                        FROM [EmployerDetails] empl
                        join EmployerContactPerson con on empl.employerid=con.VendorID where MailId='" + emailid + "' or ContactNo='" + mobileno + "'";


            SqlDataReader _read = _sql.doRead(query);
            while (_read.Read())
            {
                _cd.employerid = _read[0].ToString();
                _cd.employeremailid = _read[1].ToString();
                _cd.employermobileno = _read[2].ToString();
                _cd.employername = _read[3].ToString();
                _cd.employerspecialization = _read[4].ToString();
                _cd.employeradditionalinfo = _read[5].ToString();
                _cd.employercorporationname = _read[6].ToString();
            }
            _read.Close();
            //}

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
                _json.data = _cd;
            }

            return _json;
        }
        public jsonArray sendMail(mailInfo objMail)
        {
            int status = 1;

            try
            {
                MailMessage mail = new MailMessage();

                //mail.From = new MailAddress("admin@techwaukee.co.in");
                //SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                //mail.From = new MailAddress("tamilsenthil.23@gmail.com");

                //SmtpClient SmtpServer = new SmtpClient("smtp.zoho.com");
                mail.From = new MailAddress("tamilarasi.s@techwaukee.com");
                if (objMail.toAddr != "")
                {
                    if (objMail.toAddr.Contains(','))
                    {
                        string[] ToList = objMail.toAddr.Split(',');
                        for (int i = 0; i < ToList.Length; i++)
                        {
                            mail.To.Add(new MailAddress(ToList[i]));
                        }
                    }
                    else
                    {
                        mail.To.Add(objMail.toAddr);
                    }

                }

                if (objMail.ccAddr != "")
                {
                    if (objMail.ccAddr.Contains(','))
                    {
                        string[] CCList = objMail.ccAddr.Split(',');
                        for (int i = 0; i < CCList.Length; i++)
                        {
                            mail.CC.Add(new MailAddress(CCList[i]));
                        }
                    }
                    else
                    {
                        mail.CC.Add(objMail.ccAddr);
                    }
                }
                mail.Subject = objMail.subject;
                mail.IsBodyHtml = true;
                mail.Body = objMail.Description;
                //SmtpClient SmtpServer = new SmtpClient("smtp.zoho.com");
                //SmtpServer.Port = 465;
                //SmtpServer.Port = 587;
                //SmtpClient SmtpServer = new SmtpClient("relay-hosting.secureserver.net");
                //SmtpServer.Port = 25;
                //SmtpServer.EnableSsl = true;
                //SmtpServer.UseDefaultCredentials = false;
                //SmtpServer.Credentials = new System.Net.NetworkCredential("tamilarasi.s@techwaukee.com", "nCbfER53HWfi");
                //

                //SmtpServer.Port = 587;

                //SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;

                //SmtpServer.Credentials = new System.Net.NetworkCredential("admin@techwaukee.co.in", "Techwaukee@2016");
                //SmtpServer.Credentials = new System.Net.NetworkCredential("tamilsenthil.23@gmail.com", "sreenethraa");


                /*Zoho Mail*/
                //SmtpClient SmtpServer = new SmtpClient("smtp.zoho.com");
                //SmtpServer.Port = 587;
                //SmtpServer.EnableSsl = true;
                //SmtpServer.UseDefaultCredentials = false;
                //SmtpServer.Credentials = new System.Net.NetworkCredential("tamilarasi.s@techwaukee.com", "nCbfER53HWfi");



                //SmtpClient smtpClient = new SmtpClient("relay-hosting.secureserver.net", 25);  
                //smtpClient.UseDefaultCredentials = false;
                //SmtpServer.Credentials = new System.Net.NetworkCredential("admin@techwaukee.co.in", "Techwaukee@2016");

                SmtpClient SmtpServer = new SmtpClient("relay-hosting.secureserver.net", 25);
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("admin@techwaukee.co.in", "Techwaukee@2016");


                //SmtpServer.Send(mail);

            }
            catch (Exception ex)
            {
                status = 0;
            }


            string query = @"INSERT INTO [RTRConfirmation](candidateemaildid,employeremaildid,
                               jobcode,RTRemailstatus,mailsenton,senttime) values ('" +
                               objMail.candidateemailid + "','" + objMail.employeremaildid + "','" +
                               objMail.jobcode + "','" + status + "','" +
                               DateTime.Now.ToString("yyyy-MM-dd") + "','" + DateTime.Now.ToString("hh:mm tt", System.Globalization.DateTimeFormatInfo.InvariantInfo) + "')";

            _sql.doInsert(query);

            jsonArray _json = new jsonArray();
            if (status == 0)
            {
                _json.status = "0";
                _json.message = "MAIL SENT FAILED";
                _json.data = new object();
            }
            else
            {
                _json.status = "1";
                _json.message = "MAIL SENT SUCCESSFULLY";
                _json.data = new object();
            }

            return _json;

        }

        public jsonArray sendMailIndia(mailInfo objMail)
        {
            int status = 1;

            try
            {
                MailMessage mail = new MailMessage();

                //mail.From = new MailAddress("admin@techwaukee.co.in");
                //SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                //mail.From = new MailAddress("tamilsenthil.23@gmail.com");

                //SmtpClient SmtpServer = new SmtpClient("smtp.zoho.com");
                mail.From = new MailAddress("tamilarasi.s@techwaukee.com");
                if (objMail.toAddr != "")
                {
                    if (objMail.toAddr.Contains(','))
                    {
                        string[] ToList = objMail.toAddr.Split(',');
                        for (int i = 0; i < ToList.Length; i++)
                        {
                            mail.To.Add(new MailAddress(ToList[i]));
                        }
                    }
                    else
                    {
                        mail.To.Add(objMail.toAddr);
                    }

                }

                if (objMail.ccAddr != "")
                {
                    if (objMail.ccAddr.Contains(','))
                    {
                        string[] CCList = objMail.ccAddr.Split(',');
                        for (int i = 0; i < CCList.Length; i++)
                        {
                            mail.CC.Add(new MailAddress(CCList[i]));
                        }
                    }
                    else
                    {
                        mail.CC.Add(objMail.ccAddr);
                    }
                }
                mail.Subject = objMail.subject;
                mail.IsBodyHtml = true;
                mail.Body = objMail.Description;
                //SmtpClient SmtpServer = new SmtpClient("smtp.zoho.com");
                //SmtpServer.Port = 465;
                //SmtpServer.Port = 587;
                //SmtpClient SmtpServer = new SmtpClient("relay-hosting.secureserver.net");
                //SmtpServer.Port = 25;
                //SmtpServer.EnableSsl = true;
                //SmtpServer.UseDefaultCredentials = false;
                //SmtpServer.Credentials = new System.Net.NetworkCredential("tamilarasi.s@techwaukee.com", "nCbfER53HWfi");
                //

                //SmtpServer.Port = 587;

                //SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;

                //SmtpServer.Credentials = new System.Net.NetworkCredential("admin@techwaukee.co.in", "Techwaukee@2016");
                //SmtpServer.Credentials = new System.Net.NetworkCredential("tamilsenthil.23@gmail.com", "sreenethraa");


                /*Zoho Mail*/
                //SmtpClient SmtpServer = new SmtpClient("smtp.zoho.com");
                //SmtpServer.Port = 587;
                //SmtpServer.EnableSsl = true;
                //SmtpServer.UseDefaultCredentials = false;
                //SmtpServer.Credentials = new System.Net.NetworkCredential("tamilarasi.s@techwaukee.com", "nCbfER53HWfi");



                //SmtpClient smtpClient = new SmtpClient("relay-hosting.secureserver.net", 25);  
                //smtpClient.UseDefaultCredentials = false;
                //SmtpServer.Credentials = new System.Net.NetworkCredential("admin@techwaukee.co.in", "Techwaukee@2016");

                SmtpClient SmtpServer = new SmtpClient("relay-hosting.secureserver.net", 25);
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("admin@techwaukee.co.in", "Techwaukee@2016");


                //SmtpServer.Send(mail);

            }
            catch (Exception ex)
            {
                status = 0;
            }


            DateTime dateTime_Indian = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));

            //dateTime_Indian.ToString("yyyy-MM-dd");

            string query = @"INSERT INTO [RTRConfirmationIndia](candidateemaildid,employeremaildid,
                               jobcode,RTRemailstatus,mailsenton,senttime) values ('" +
                               objMail.candidateemailid + "','" + objMail.employeremaildid + "','" +
                               objMail.jobcode + "','" + status + "','" +
                               dateTime_Indian.ToString("yyyy-MM-dd") + "','" + dateTime_Indian.ToString("hh:mm tt", System.Globalization.DateTimeFormatInfo.InvariantInfo) + "')";

            _sql.doInsert(query);

            jsonArray _json = new jsonArray();
            if (status == 0)
            {
                _json.status = "0";
                _json.message = "MAIL SENT FAILED";
                _json.data = new object();
            }
            else
            {
                _json.status = "1";
                _json.message = "MAIL SENT SUCCESSFULLY";
                _json.data = new object();
            }

            return _json;

        }
        public int sendSubmissionMail(Candidatedetails candi)
        {
            int status = 1;
            List<candidateProof> lstproof = new List<candidateProof>();

            string query = @"select documenttype,idfilename from candproofdetails" +
                            " where candidateid='" + candi.candidateid + "'";

            SqlDataReader _read = _sql.doRead(query);

            //_read = _sql.doRead(query);
            while (_read.Read())
            {
                candidateProof objProof = new candidateProof();
                objProof.documenttype = _read[0].ToString();
                objProof.idfilename = _read[1].ToString();
                lstproof.Add(objProof);
            }

            _read.Close();
            try
            {
                MailMessage mail = new MailMessage();
                //SmtpClient SmtpServer = new SmtpClient("relay-hosting.secureserver.net");
                //mail.From = new MailAddress("admin@techwaukee.co.in");
                //SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                //mail.From = new MailAddress("tamilsenthil.23@gmail.com");

                string Description = "Hi Team,<br/>" +
                    "Please find the attached resume of " + candi.candidatename + " for " + candi.jobtitle + ".Please let me know if you have any questions or need any additional information.<br/><br/>";
                Description += @"<table style='font-family: Verdana,Arial,Helvetica,sans-serif; font-size: 13.3333px; font-style: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; background-color: rgb(255, 255, 255); border-collapse: collapse; width: 506pt;' class='' border='1' cellpadding='0' cellspacing='0' width='675'>" +
                "<colgroup class=''>" +
                "<col style='width: 177pt;' class='' width='236'>" +
                "<col style='width: 329pt;' class='' width='439'>" +
                "</colgroup>" +
                "<tbody class=''>" +
                "<tr style='height: 15pt;' class='' height='20'>" +
                "<td style='font-family: inherit; height: 15pt; width: 177pt; color: windowtext; text-align: left; vertical-align: middle; border: 0.5pt solid windowtext; background: white; white-space: normal;' height='20' class='x_2012675028xl67' width='236'><span class='x_1276292371font' style='font-family: Calibri,  Verdana,  Arial,  sans-serif,  sans-serif;'><span class='x_1276292371size' style='font-size: 16px;'>&nbsp;</span></span><br>" +
            "</td>" +
                "<td style='font-family: inherit; border: 0.5pt solid windowtext; width: 329pt; color: windowtext; text-align: left; background: white;' class='x_2012675028xl69' width='439'><span class='x_1276292371font' style='font-family: Calibri,  Verdana,  Arial,  sans-serif,  sans-serif;'><span class='x_1276292371size' style='font-size: 16px;'>&nbsp;</span></span><br>" +
                "</td>" +
                "</tr>" +
                "<tr style='height: 15pt;' class='' height='20'>" +
                "<td style='font-family: inherit; height: 28px; width: 506pt; color: windowtext; font-weight: 700; text-align: left; vertical-align: middle; border: 0.5pt solid windowtext; background: rgb(237, 125, 49); white-space: normal;' colspan='2' height='20' class='x_2012675028xl73' width='675'><span class='x_1276292371font' style='font-family: Calibri,  Verdana,  Arial,  sans-serif,  sans-serif;'><span class='x_1276292371size' style='font-size: 16px;'>Submission</span></span><br>" +
                "</td>" +
                "</tr>" +
            "<tr style='height: 15pt;' class='' height='20'>" +
                "<td style='font-family: inherit; height: 15pt; border: 0.5pt solid windowtext; width: 177pt; color: windowtext; font-weight: 700; text-align: left; vertical-align: middle; background: rgb(141, 179, 226); white-space: normal;' height='20' class='x_2012675028xl70' width='236'><span class='x_1276292371font' style='font-family: Calibri,  Verdana,  Arial,  sans-serif,  sans-serif;'><span class='x_1276292371size' style='font-size: 16px;'>Details</span></span><br>" +
                "</td>" +
                "<td style='font-family: inherit; border: 0.5pt solid windowtext; width: 329pt; color: windowtext; font-weight: 700; text-align: left; vertical-align: middle; background: rgb(141, 179, 226); white-space: normal;' class='x_2012675028xl70' width='439'><span class='x_1276292371font' style='font-family: Calibri,  Verdana,  Arial,  sans-serif,  sans-serif;'><span class='x_1276292371size' style='font-size: 16px;'>Input</span></span><br>" +
                "</td>" +
                "</tr>" +
                "<tr style='height: 15pt;' class='' height='20'>" +
                "<td style='font-family: inherit; height: 15pt; border: 0.5pt solid windowtext; width: 177pt; color: windowtext; font-weight: 700; text-align: left; vertical-align: middle; background: white; white-space: normal;' height='20' class='x_2012675028xl65' width='236'><span class='x_1276292371font' style='font-family: Calibri,  Verdana,  Arial,  sans-serif,  sans-serif;'><span class='x_1276292371size' style='font-size: 16px;'>Candidate Full Name</span></span><br>" +
                "</td>" +
                "<td style='font-family: inherit; border: 0.5pt solid windowtext; font-weight: 700; text-align: left;' class='x_2012675028xl72'><span class='x_1276292371colour' style='color: rgb(37, 49, 60);'><span class='x_1276292371font' style='font-family: Calibri,  sans-serif;'><span class='x_1276292371size' style='font-size: 16pt;'><span class='x_1276292371size' style='font-size: 13.3333px;'><span class='x_1276292371font' style='font-family: verdana,  sans-serif;'><b><span class='x_1276292371font' style='font-family: Calibri,  sans-serif;'><span class='x_1276292371size' style='font-size: 11pt; line-height: 15.6933px;'>" + candi.candidatename + "</span></span></b></span></span></span></span></span><br>" +
                "</td>" +
                "</tr>" +
                "<tr style='height: 15pt;' class='' height='20'>" +
                "<td style='font-family: inherit; height: 25px; border: 0.5pt solid windowtext; width: 177pt; color: windowtext; font-weight: 700; text-align: left; vertical-align: middle; background: white; white-space: normal;' height='20' class='x_2012675028xl65' width='236'><span class='x_1276292371font' style='font-family: Calibri,  Verdana,  Arial,  sans-serif,  sans-serif;'><span class='x_1276292371size' style='font-size: 16px;'>Email ID</span></span><br>" +
                "</td>" +
                "<td style='font-family: inherit; border: 0.5pt solid windowtext; color: rgb(5, 99, 193); text-decoration: underline;' class='x_2012675028xl74'>" +
                "<div style='margin: 0px;' class=''><span><a style='color: rgb(89, 143, 222); cursor: pointer;' href='mailto:bhavani9910@gmail.com' target='_blank'><b><span class='x_1276292371colour' style='color: windowtext;'><span class='x_1276292371size' style='font-size: 11pt; text-decoration: none;'><span class='x_1276292371size' style='font-size: 13.3333px;'>" + candi.candidateemailid + "</span></span></span></b></a></span><br>" +
                 "</div>" +
                 "</td>" +
                 "</tr>" +
                 "<tr style='height: 15pt;' class='' height='20'>" +
                 "<td style='font-family: inherit; height: 15pt; border: 0.5pt solid windowtext; width: 177pt; color: windowtext; font-weight: 700; text-align: left; vertical-align: middle; background: white; white-space: normal;' height='20' class='x_2012675028xl65' width='236'><span class='x_1276292371font' style='font-family: Calibri,  Verdana,  Arial,  sans-serif,  sans-serif;'><span class='x_1276292371size' style='font-size: 16px;'>Contact Number</span></span><br>" +
                 "</td>" +
                 "<td style='font-family: inherit; border: 0.5pt solid windowtext;' class='x_2012675028xl75'>" +
             "<div style='text-align: justify; margin: 0px;' class=''><span class='x_1276292371font' style='font-family: Calibri,  sans-serif;'><span class='x_1276292371size' style='font-size: 11pt;'><b><span class='x_1276292371font' style='font-family: Calibri,  sans-serif;'><span class='x_1276292371size' style='font-size: 11pt; line-height: 15.6933px;'>" + candi.candidatemobileno + "</span></span></b></span></span><br>" +
                 "</div>" +
                 "</td>" +
                 "</tr>" +
                 "<tr style='height: 15pt;' class='' height='20'>" +
                 "<td style='font-family: inherit; height: 15pt; border: 0.5pt solid windowtext; width: 177pt; color: windowtext; font-weight: 700; text-align: left; vertical-align: middle; background: white; white-space: normal;' height='20' class='x_2012675028xl65' width='236'><span class='x_1276292371font' style='font-family: Calibri,  Verdana,  Arial,  sans-serif,  sans-serif;'><span class='x_1276292371size' style='font-size: 16px;'>Current Location</span></span><br>" +
                 "</td>" +
                 "<td style='font-family: inherit; border: 0.5pt solid windowtext; text-align: left;' class='x_2012675028xl71'><span class='x_1276292371highlight' style='background-color: rgb(255, 255, 255);'><span class='x_1276292371font' style='font-family: &quot; lato 2&quot; ,  sans-serif;'><span class='x_1276292371size' style='font-size: 14px; font-style: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; float: none; display: inline;'><span class='x_1276292371highlight' style='background-color: rgb(255, 255, 255);'><span class='x_1276292371font' style='font-family: -apple-system,  system-ui,  BlinkMacSystemFont,  &quot; segoe ui&quot; ,  roboto,  &quot; helvetica neue&quot; ,  &quot; fira sans&quot; ,  ubuntu,  oxygen,  &quot; oxygen sans&quot; ,  cantarell,  &quot; droid sans&quot; ,  &quot; apple color emoji&quot; ,  &quot; segoe ui emoji&quot; ,  &quot; segoe ui symbol&quot; ,  &quot; lucida grande&quot; ,  helvetica,  arial,  sans-serif;'><span class='x_1276292371size' style='font-size: 10.5px; font-style: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; float: none; display: inline;'><span class='x_1276292371colour' style='color: rgb(0, 0, 0);'><span class='x_1276292371font' style='font-family: verdana,  sans-serif;'><span class='x_1276292371size' style='font-size: 13.3333px;'>" + candi.currentLocation + "</span></span></span></span></span></span></span></span></span><br>" +
                 "</td>" +
                 "</tr>" +
                 "<tr style='height: 15pt;' class='' height='20'>" +
                 "<td style='font-family: inherit; height: 15pt; border: 0.5pt solid windowtext; width: 177pt; color: windowtext; font-weight: 700; text-align: left; vertical-align: middle; background: white; white-space: normal;' height='20' class='x_2012675028xl65' width='236'><span class='x_1276292371font' style='font-family: Calibri,  Verdana,  Arial,  sans-serif,  sans-serif;'><span class='x_1276292371size' style='font-size: 16px;'>Visa Status</span></span><br>" +
                 "</td>" +
                 "<td style='font-family: inherit; border: 0.5pt solid windowtext; width: 329pt; color: windowtext; text-align: left; vertical-align: middle; background: white; white-space: normal;' class='x_2012675028xl67' width='439'>" + candi.visastatus + "<br>" +
             "</td>" +
                 "</tr>" +
                 "<tr style='height: 15pt;' class='' height='20'>" +
                 "<td style='font-family: inherit; height: 15pt; border: 0.5pt solid windowtext; width: 177pt; color: windowtext; font-weight: 700; text-align: left; vertical-align: middle; background: white; white-space: normal;' height='20' class='x_2012675028xl65' width='236'><span class='x_1276292371font' style='font-family: Calibri,  Verdana,  Arial,  sans-serif,  sans-serif;'><span class='x_1276292371size' style='font-size: 16px;'>Rate/Salary</span></span><br>" +
                 "</td>" +
                 "<td style='font-family: inherit; border: 0.5pt solid windowtext; color: windowtext; text-align: left;' class='x_2012675028xl66'><span class='x_1276292371font' style='font-family: Calibri,  Verdana,  Arial,  sans-serif,  sans-serif;'><span class='x_1276292371size' style='font-size: 16px;'>$" + candi.ratePerHr + "/hr all inclusive on Corp to Corp (Employer Rate)</span></span><br>" +
                 "</td>" +
                 "</tr>" +
                 "<tr style='height: 15pt;' class='' height='20'>" +
                 "<td style='font-family: inherit; height: 15pt; border: 0.5pt solid windowtext; width: 177pt; color: windowtext; font-weight: 700; text-align: left; vertical-align: middle; background: white; white-space: normal;' height='20' class='x_2012675028xl65' width='236'><span class='x_1276292371font' style='font-family: Calibri,  Verdana,  Arial,  sans-serif,  sans-serif;'><span class='x_1276292371size' style='font-size: 16px;'>Willing to relocate (Yes/No)</span></span><br>" +
                 "</td>" +
                 "<td style='font-family: inherit; border: 0.5pt solid windowtext; width: 329pt; color: windowtext; text-align: left; vertical-align: middle; background: white; white-space: normal;' class='x_2012675028xl67' width='439'>" + candi.relocate +
                 "<br>" +
                 "</td>" +
                 "</tr>" +
                 "<tr style='height: 15pt;' class='' height='20'>" +
                 "<td style='font-family: inherit; height: 15pt; border: 0.5pt solid windowtext; width: 177pt; color: windowtext; font-weight: 700; text-align: left; vertical-align: middle; background: white; white-space: normal;' height='20' class='x_2012675028xl65' width='236'><span class='x_1276292371font' style='font-family: Calibri,  Verdana,  Arial,  sans-serif,  sans-serif;'><span class='x_1276292371size' style='font-size: 16px;'>Total years of experience</span></span><br>" +
                 "</td>" +
                 "<td style='font-family: inherit; border: 0.5pt solid windowtext; color: windowtext; text-align: left;' class='x_2012675028xl66'><span class='x_1276292371font' style='font-family: Calibri,  Verdana,  Arial,  sans-serif,  sans-serif;'><span class='x_1276292371size' style='font-size: 16px;'>" + candi.yrsofexp + "</span></span><br>" +
                 "</td>" +
                 "</tr>" +
                 "<tr style='height: 15pt;' class='' height='20'>" +
                 "<td style='font-family: inherit; height: 15pt; border: 0.5pt solid windowtext; width: 177pt; color: windowtext; font-weight: 700; text-align: left; vertical-align: middle; background: white; white-space: normal;' height='20' class='x_2012675028xl65' width='236'><span class='x_1276292371font' style='font-family: Calibri,  Verdana,  Arial,  sans-serif,  sans-serif;'><span class='x_1276292371size' style='font-size: 16px;'>" + candi.skillsandCertif + "</span></span><br>" +
                 "</td>" +
                 "<td style='font-family: inherit; border: 0.5pt solid windowtext; color: windowtext; text-align: left;' class='x_2012675028xl66'><span class='x_1276292371font' style='font-family: Calibri,  Verdana,  Arial,  sans-serif,  sans-serif;'><span class='x_1276292371size' style='font-size: 16px;'>7 Years as a Talend developer</span></span><br>" +
                 "</td>" +
                 "</tr>" +
                 "<tr style='height: 15pt;' class='' height='20'>" +
                 "<td style='font-family: inherit; height: 15pt; border: 0.5pt solid windowtext; width: 177pt; color: windowtext; font-weight: 700; text-align: left; vertical-align: middle; background: white; white-space: normal;' height='20' class='x_2012675028xl65' width='236'><span class='x_1276292371font' style='font-family: Calibri,  Verdana,  Arial,  sans-serif,  sans-serif;'><span class='x_1276292371size' style='font-size: 16px;'>LinkedIn</span></span><br>" +
                 "</td>" +
                 "<td style='font-family: inherit; border: 0.5pt solid windowtext; color: windowtext; text-decoration: underline; text-align: left;' class='x_2012675028xl68'><a style='color: rgb(89, 143, 222); cursor: pointer;' href='" + candi.linkedinURL + "' target='_blank'>" + candi.linkedinURL + "</a><br>" +
                 "</td>" +
                 "</tr>" +
                 "<tr style='height: 15pt;' class='' height='20'>" +
                 "<td style='font-family: inherit; height: 15pt; border: 0.5pt solid windowtext; width: 177pt; color: windowtext; font-weight: 700; text-align: left; vertical-align: middle; background: white; white-space: normal;' height='20' class='x_2012675028xl65' width='236'><span class='x_1276292371font' style='font-family: Calibri,  Verdana,  Arial,  sans-serif,  sans-serif;'><span class='x_1276292371size' style='font-size: 16px;'>Notice Period</span></span><br>" +
                 "</td>" +
                 "<td style='font-family: inherit; border: 0.5pt solid windowtext; width: 329pt; color: windowtext; text-align: left; vertical-align: middle; background: white; white-space: normal;' class='x_2012675028xl67' width='439'><span class='x_1276292371font' style='font-family: Calibri,  Verdana,  Arial,  sans-serif,  sans-serif;'><span class='x_1276292371size' style='font-size: 16px;'>" + candi.noticePeriod + "</span></span><br>" +
                 "</td>" +
                 "</tr>" +
                 "<tr style='height: 15pt;' class='' height='20'>" +
                 "<td style='font-family: inherit; height: 15pt; border: 0.5pt solid windowtext; width: 177pt; color: windowtext; font-weight: 700; text-align: left; vertical-align: middle; background: white; white-space: normal;' height='20' class='x_2012675028xl65' width='236'><span class='x_1276292371font' style='font-family: Calibri,  Verdana,  Arial,  sans-serif,  sans-serif;'><span class='x_1276292371size' style='font-size: 16px;'>Available for the interview</span></span><br>" +
                 "</td>" +
                 "<td style='font-family: inherit; border: 0.5pt solid windowtext; width: 329pt; color: windowtext; text-align: left; vertical-align: middle; background: white; white-space: normal;' class='x_2012675028xl67' width='439'><span class='x_1276292371font' style='font-family: Calibri,  Verdana,  Arial,  sans-serif,  sans-serif;'><span class='x_1276292371size' style='font-size: 16px;'>" + candi.availableforinterview + "</span></span><br>" +
                 "</td>" +
                 "</tr>" +
                 "</tbody>" +
                 "</table>";

                //SmtpClient SmtpServer = new SmtpClient("smtp.zoho.com");
                SmtpClient SmtpServer = new SmtpClient("relay-hosting.secureserver.net");
                mail.From = new MailAddress("tamilarasi.s@techwaukee.com");
                mail.To.Add("tamilsenthil.23@gmail.com");

                for (int i = 0; i < lstproof.Count; i++)
                {
                    if (lstproof[i].documenttype == "Resume")
                    {
                        string path = System.Web.HttpContext.Current.Server.MapPath("\\Candidate\\Resume\\");
                        mail.Attachments.Add(new Attachment(path + lstproof[i].idfilename));
                    }

                }

                //if (objMail.toAddr != "")
                //{
                //    if (objMail.toAddr.Contains(','))
                //    {
                //        string[] ToList = objMail.toAddr.Split(',');
                //        for (int i = 0; i < ToList.Length; i++)
                //        {
                //            mail.To.Add(new MailAddress(ToList[i]));
                //        }
                //    }
                //    else
                //    {
                //        mail.To.Add(objMail.toAddr);
                //    }

                //}

                //if (objMail.ccAddr != "")
                //{
                //    if (objMail.ccAddr.Contains(','))
                //    {
                //        string[] CCList = objMail.ccAddr.Split(',');
                //        for (int i = 0; i < CCList.Length; i++)
                //        {
                //            mail.CC.Add(new MailAddress(CCList[i]));
                //        }
                //    }
                //    else
                //    {
                //        mail.CC.Add(objMail.ccAddr);
                //    }
                //}
                mail.Subject = "Submission-" + candi.candidatename + "-" + candi.jobtitle;
                mail.IsBodyHtml = true;
                mail.Body = Description;
                //SmtpServer.Port = 25;
                //SmtpServer.Port = 587;

                SmtpServer.Port = 587;
                SmtpServer.EnableSsl = true;
                //SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                SmtpServer.UseDefaultCredentials = false;
                //SmtpServer.Credentials = new System.Net.NetworkCredential("admin@techwaukee.co.in", "Techwaukee@2016");
                //SmtpServer.Credentials = new System.Net.NetworkCredential("tamilsenthil.23@gmail.com", "sreenethraa");
                SmtpServer.Credentials = new System.Net.NetworkCredential("tamilarasi.s@techwaukee.com", "D84eavNcZ6AA");

                //SmtpServer.Send(mail);

            }
            catch (Exception ex)
            {
                status = 0;
            }


            return status;
        }
        public jsonArray getJobFormdetails()
        {
            int status = 1;

            listarray _db = new listarray();
            _db.lstClient = new List<dropDownTemplate>();
            _db.lstPriority = new List<dropDownTemplate>();
            _db.lstJobstatus = new List<dropDownTemplate>();
            _db.lstEmployee = new List<dropDownTemplate>();
            _db.lstEmploymentType = new List<dropDownTemplate>();
            _db.lstLocation = new List<dropDownTemplate>();
            _db.lstTechnology = new List<dropDownTemplate>();
            _db.lstSkill = new List<dropDownTemplate>();

            string strquery = "select max(substring(Jobcode,7,len(Jobcode)+1)) from Job_Master_IND";
            SqlDataReader _read = _sql.doRead(strquery);
            int i = 0;
            while (_read.Read())
            {
                i = Convert.ToInt16(_read[0]);
            }

            if (i >= 0 && i < 9)
            {
                i++;
                _db.Jobcodename = "TWEIND" + "000" + i;
            }
            else if (i >= 9 && i < 99)

            {
                i++;
                _db.Jobcodename = "TWEUSA" + "00" + i;
            }
            else if (i >= 99 && i < 999)
            {
                i++;
                _db.Jobcodename = "TWEIND" + "0" + i;
            }
            else
            {
                i++;
                _db.Jobcodename = "TWEIND" + i;
            }


            _read.Close();
            strquery = @"SELECT[ClientID],[ClientCompanyName] FROM [ClientMaster] where Status=1";

            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                _db.lstClient.Add(new dropDownTemplate
                {
                    ID = _read["ClientID"].ToString(),
                    Name = _read["ClientCompanyName"].ToString()
                });
            }

            _read.Close();

            strquery = @"SELECT [PriorityID],[PriorityName] FROM [Priority_Master] where Status=1";

            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                _db.lstPriority.Add(new dropDownTemplate
                {
                    ID = _read["PriorityID"].ToString(),
                    Name = _read["PriorityName"].ToString()
                });
            }


            _read.Close();

            strquery = @"SELECT [JobstatusID],[JobstatusName] FROM [Jobstatus_Master] where Status=1";

            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                _db.lstJobstatus.Add(new dropDownTemplate
                {
                    ID = _read["JobstatusID"].ToString(),
                    Name = _read["JobstatusName"].ToString()
                });
            }

            _read.Close();

            //strquery = @"  select TWE_ID,UP_firstName+' ' + UP_lastName EmpName from Userprofile up
            //              join Region reg on up.UP_MT_region = reg.regionid
            //              where reg.regiontype = 'USA' or reg.regiontype = 'Global'" +
            //              " and UP_MT_designation= '4001' and TWE_ID!= 'TWEI0000'";

            strquery = @"  select TWE_ID,UP_firstName+' ' + UP_lastName EmpName from Userprofile up where TWE_ID!= 'TWEI0000'";

            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                _db.lstEmployee.Add(new dropDownTemplate
                {
                    ID = _read["TWE_ID"].ToString(),
                    Name = _read["EmpName"].ToString()
                });
            }

            _read.Close();



            strquery = @"SELECT [EmpTypeID],[EmpTypeName] FROM [EmploymentType_Master] where Status=1";

            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                _db.lstEmploymentType.Add(new dropDownTemplate
                {
                    ID = _read["EmpTypeID"].ToString(),
                    Name = _read["EmpTypeName"].ToString()
                });
            }

            _read.Close();

            strquery = @"SELECT [LocationID],[LocationName] FROM [Location_Master] where Status=1";

            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                _db.lstLocation.Add(new dropDownTemplate
                {
                    ID = _read["LocationID"].ToString(),
                    Name = _read["LocationName"].ToString()
                });
            }

            _read.Close();

            strquery = @"SELECT [TechnologyName],[ImageURL] FROM [Image_Master] where Status=1";

            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                _db.lstTechnology.Add(new dropDownTemplate
                {
                    ID = _read["ImageURL"].ToString(),
                    Name = _read["TechnologyName"].ToString()
                });
            }

            _read.Close();

            strquery = @"SELECT [SkillName],[SkillID] FROM [Skill_Master] where Status=1";

            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                _db.lstSkill.Add(new dropDownTemplate
                {
                    ID = _read["SkillID"].ToString(),
                    Name = _read["SkillName"].ToString()
                });
            }


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
                _json.data = _db;
            }

            return _json;
        }


        /**India**/
        public jsonArray insertJobIndiaInfo(JobcodeIndia job)
        {
            int status = 1;
            string query = "";
            DateTime dateTime_India = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
            var timeInIST = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
            var timeInIndiaAsString = timeInIST.ToString("hh:mm tt", CultureInfo.InvariantCulture);            

            if (job.Mode == "insert")
            {
                query = @"INSERT INTO [Job_Master_IND]
                                    ([Jobcode],[JobTitle],[Duration]
                                    ,[EmplType],[Location],[Country],
                                     [Startdate],[Noofopening],[ShiftTiming] 
                                    ,[TurnAroundtime],[Clientname]
                                    ,[Contactname],[Description],[Assigned_To]
                                    ,[Prioritylevel],[Jobstatus],[Minrate]
                                    ,[Maxrate],[Ratetype],[Currency]
                                    ,[Skill],[Jobopendate],[OpenComments],[Jobimage]
                                    ,[Created_By],[Created_On],[Created_Time],Publish_Web)
                                    VALUES" +
                                    "('" + job.Jobcodename + "','" + job.JobTitle + "','" + job.Duration + "','" +
                                    job.EmplType + "','" + job.Location + "','" + job.Country + "','" +
                                    job.Startdate + "','" + job.Noofopening + "','" + job.ShiftTiming + "','" +
                                    job.TurnAroundtime + "','" + job.Clientname + "','" +
                                    job.Contactname + "','" + job.Description + "','" + job.AssignedTo + "','" +
                                    job.Prioritylevel + "','" + job.Jobstatus + "','" + job.Minrate + "','" +
                                    job.Maxrate + "','" + job.Ratetype + "','" + job.Currency + "','" + job.Skill + "','" +
                                    job.Jobopendate + "','" + job.OpenComments + "','" + job.Jobimage + "','" +
                                    job.Created_By + "','" + dateTime_India.ToString("yyyy-MM-dd") + "','" + timeInIndiaAsString + "','" + job.Publish_Web + "')";
            }
            else if (job.Mode == "update")
            {
                query = @"update [Job_Master_IND] set JobTitle='" + job.JobTitle + "',Duration='" + job.Duration + "',EmplType='" + job.EmplType + "',Location='" +
                        job.Location + "',Startdate='" + job.Startdate + "',Noofopening='" + job.Noofopening +
                        "',ShiftTiming='" + job.ShiftTiming + "',TurnAroundtime='" + job.TurnAroundtime +
                        "',Clientname='" + job.Clientname + "',Contactname='" +
                        job.Contactname + "',Description='" + job.Description + "',Assigned_To='" + job.AssignedTo + "',Prioritylevel='" + job.Prioritylevel + "',Jobstatus='" +
                        job.Jobstatus + "',Minrate='" + job.Minrate + "',Maxrate='" + job.Maxrate + "',Ratetype='" + job.Ratetype + "',Currency='" + job.Currency + "',Skill='" + job.Skill + "',Jobopendate='" + job.Jobopendate + "',OpenComments='" + job.OpenComments + "',Jobimage='" +
                        job.Jobimage + "',Last_Updated_By='" + job.Updated_By + "',Last_Updated_On='" + dateTime_India.ToString("yyyy-MM-dd") + "',Publish_Web='" + job.Publish_Web
                        + "',Updated_Time='" + timeInIndiaAsString + "' where Jobcode='" + job.Jobcodename + "'";
            }

            _sql.doInsert(query);


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
                _json.data = "";
            }

            return _json;

        }
        public jsonArray getClientContactIndiadetails(string ClientID)
        {
            int status = 1;

            listarray _db = new listarray();
            _db.lstClicontact = new List<dropDownTemplate>();

            string strquery = @"select ClientContactID, ContactPerson from Client_Contact_Person where ClientID = '" + ClientID + "'";

            SqlDataReader _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                _db.lstClicontact.Add(new dropDownTemplate
                {
                    ID = _read["ClientContactID"].ToString(),
                    Name = _read["ContactPerson"].ToString()
                });
            }

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
                _json.data = _db;
            }

            return _json;
        }
        public jsonArray getJobdetailsIndia(string TWE_Id, string fromdate, string todate, string tiletype)
        {
            int status = 1;

            JobMaster _db = new JobMaster();
            _db.lstJob = new List<JobcodeList>();
            _db.lsttiles = new List<tiles>();
            string jobCreation = "";
            string jobEdit = "";
            string jobView = "";
            string jobFeedback = "";
            string strquery = @"SELECT [jobCreation],[jobEdit],[jobView],[jobFeedback] FROM [UserAccessPower] where userId='" + TWE_Id + "' ";
            SqlDataReader _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                jobCreation = _read[0].ToString();
                jobEdit = _read[1].ToString();
                jobView = _read[2].ToString();
                jobFeedback = _read[3].ToString();

            }
            _read.Close();

            if (jobEdit == "2" || jobView == "2")
            {
                strquery = @"select * from
                            (select count(*) open_jobs from Job_Master_IND
                             where Jobstatus='10200'" +
                            ") tb1,(" +
                            "select count(distinct job.Jobcode) pipeline_jobs from Job_Master_IND job" +
                            " join CandidateJobIndia canjob on canjob.Jobcode=job.Jobcode	" +
                            " join CandidateDetailsIndia can on canjob.CandidateId = can.candidateid" +
                            " where Cand_Status='102'" +
                            ") tb2,(" +
                           "select count(*) High_jobs from Job_Master_IND job" +
                            " where Prioritylevel='10300'" +
                            ") tb3,(" +
                            "select count(*) Nosubmission_jobs from CandidateJobIndia can" +
                            " where jobcode not in (select Jobcode from Job_Master_IND where Jobstatus='10200')" +
                            //" and Created_On between '" + fromdate + "' and '" + todate + "'" +
                            ") tb4,(" +
                            "select count(distinct job.Jobcode) interview_jobs from Job_Master_IND job" +
                            " join CandidateJobIndia canjob on canjob.Jobcode=job.Jobcode	" +
                            " join CandidateDetailsIndia can on canjob.CandidateId = can.candidateid" +
                            " where Cand_Status in ('110','111')" +
                            ") tb5,(" +
                            "select count(distinct job.Jobcode) closure_jobs from Job_Master_IND job" +
                            " join CandidateJobIndia canjob on canjob.Jobcode=job.Jobcode	" +
                            " join CandidateDetailsIndia can on canjob.CandidateId = can.candidateid" +
                            " where Cand_Status in ('109')" +
                            ") tb6," +
                            "(select count(*) open_jobs from Job_Master_IND" +
                            //" and Created_On between '" + fromdate + "' and '" + todate + "'" +
                            ") tb7";
            }
            else
            {

                strquery = @"select * from
                            (select count(*) open_jobs from Job_Master_IND
                             where Assigned_To like '%" + TWE_Id + "%' " +
                            //" and Created_On between '" + fromdate + "' and '" + todate + "'" +
                            " and Jobstatus='10200'" +
                            ") tb1,(" +
                            "select count(distinct job.Jobcode) pipeline_jobs from Job_Master_IND job" +
                            " join CandidateJobIndia canjob on canjob.Jobcode=job.Jobcode	" +
                            " join CandidateDetailsIndia can on canjob.CandidateId = can.candidateid" +
                            " where Assigned_To like '%" + TWE_Id + "%' " +
                            //" and can.Created_On between '" + fromdate + "' and '" + todate + "'" +
                            " and Cand_Status='102'" +
                            ") tb2,(" +
                           "select count(*) High_jobs from Job_Master_IND job" +
                            " where Assigned_To like '%" + TWE_Id + "%' " +
                            //"and Created_On between '" + fromdate + "' and '" + todate + "'" +
                            " and Prioritylevel='10300'" +
                            ") tb3,(" +
                            "select count(*) Nosubmission_jobs from CandidateJobIndia can" +
                            " where jobcode not in (select Jobcode from Job_Master_IND where Assigned_To like '%" + TWE_Id + "%' and Jobstatus='10200'" +
                            " and Created_On between '" + fromdate + "' and '" + todate + "')" +
                            " and Created_By like '%" + TWE_Id + "%' " +
                            //" and Created_On between '" + fromdate + "' and '" + todate + "'" +
                            ") tb4,(" +
                            "select count(distinct job.Jobcode) interview_jobs from Job_Master_IND job" +
                            " join CandidateJobIndia canjob on canjob.Jobcode=job.Jobcode	" +
                            " join CandidateDetailsIndia can on canjob.CandidateId = can.candidateid" +
                            " where Assigned_To like '%" + TWE_Id + "%' " +
                            //" and can.Created_On between '" + fromdate + "' and '" + todate + "'" +
                            " and Cand_Status in ('110','111')" +
                            ") tb5,(" +
                            "select count(distinct job.Jobcode) closure_jobs from Job_Master_IND job" +
                            " join CandidateJobIndia canjob on canjob.Jobcode=job.Jobcode	" +
                            " join CandidateDetailsIndia can on canjob.CandidateId = can.candidateid" +
                            " where Assigned_To like '%" + TWE_Id + "%' " +
                            //" and can.Created_On between '" + fromdate + "' and '" + todate + "'" +
                            " and Cand_Status in ('109')" +
                            ") tb6," +
                            "(select count(*) open_jobs from Job_Master_IND" +
                            " where Assigned_To like '%" + TWE_Id + "%' " +
                            //" and Created_On between '" + fromdate + "' and '" + todate + "'" +
                            ") tb7";
            }


            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                tiles objTile1 = new tiles();
                objTile1.TileTitle = "Open Jobs";
                objTile1.TotalCount = _read[0].ToString();
                _db.lsttiles.Add(objTile1);

                tiles objTile2 = new tiles();
                objTile2.TileTitle = "Pipeline";
                objTile2.TotalCount = _read[1].ToString();
                _db.lsttiles.Add(objTile2);

                tiles objTile3 = new tiles();
                objTile3.TileTitle = "High Priority";
                objTile3.TotalCount = _read[2].ToString();
                _db.lsttiles.Add(objTile3);

                //tiles objTile4 = new tiles();
                //objTile4.TileTitle = "No Submission";
                //objTile4.TotalCount = _read[3].ToString();
                //_db.lsttiles.Add(objTile4);

                tiles objTile5 = new tiles();
                objTile5.TileTitle = "Interview";
                objTile5.TotalCount = _read[4].ToString();
                _db.lsttiles.Add(objTile5);

                tiles objTile6 = new tiles();
                objTile6.TileTitle = "Closure";
                objTile6.TotalCount = _read[5].ToString();
                _db.lsttiles.Add(objTile6);

                tiles objTile7 = new tiles();
                objTile7.TileTitle = "Assigned Jobs";
                objTile7.TotalCount = _read[6].ToString();
                _db.lsttiles.Add(objTile7);

            }

            _read.Close();

            List<Jobcode> lstJob = new List<Jobcode>();

            strquery = @"select Jobcode from Job_Master_IND where Assigned_To like '%" + TWE_Id + "%' and Jobstatus='10200'";


            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                Jobcode obj = new Jobcode();
                obj.Jobcodename = _read[0].ToString();
                lstJob.Add(obj);
            }

            _read.Close();

            List<Jobcode> lstSubJob = new List<Jobcode>();

            strquery = @"select distinct job.jobcode from CandidateJobIndia can
                            join Job_Master_IND job on job.Jobcode=can.Jobcode 
                            where Assigned_To like '%" + TWE_Id + "%' and Jobstatus='10200'";

            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                Jobcode obj = new Jobcode();
                obj.Jobcodename = _read[0].ToString();
                lstSubJob.Add(obj);
            }

            _read.Close();

            int nonsubCount = 0;
            string nonsubJob = "";

            for (int i = 0; i < lstJob.Count; i++)
            {

                for (int j = 0; j < lstSubJob.Count; j++)
                {
                    if (lstSubJob[j].Jobcodename == lstJob[i].Jobcodename)
                    {
                        nonsubCount++;
                        nonsubJob += "'" + lstSubJob[j].Jobcodename + "',";
                    }

                }

            }

            int noSub = lstJob.Count - nonsubCount;

            tiles objTile4 = new tiles();
            objTile4.TileTitle = "Nil Submissions";
            objTile4.TotalCount = noSub.ToString();
            _db.lsttiles.Add(objTile4);


            if (nonsubJob.Length != 0)
            {
                nonsubJob = nonsubJob.Substring(0, nonsubJob.Length - 1);
            }

            //string strVar = "";

            //if (lstJob.Count != 0)
            //{
            //    for (int i = 0; i < lstJob.Count; i++)
            //    {
            //        strVar += "'" + lstJob[i].Jobcodename + "',";
            //    }

            //    strVar = strVar.Substring(0, strVar.Length - 1);

            //    strquery = @"select count(*) Nosubmission_jobs from CandidateJobIndia can where jobcode in (" + strVar + ")";

            //    _read = _sql.doRead(strquery);


            //    while (_read.Read())
            //    {
            //        tiles objTile4 = new tiles();
            //        objTile4.TileTitle = "No Submission";
            //        objTile4.TotalCount = (lstJob.Count - Convert.ToInt32(_read[0])).ToString();
            //        _db.lsttiles.Add(objTile4);

            //    }
            //    _read.Close();
            //}

            //else
            //{
            //    tiles objTile4 = new tiles();
            //    objTile4.TileTitle = "No Submission";
            //    objTile4.TotalCount = "0";
            //    _db.lsttiles.Add(objTile4);
            //}


            if (tiletype == "Open")
            {
                if (jobEdit == "2" || jobView == "2")
                {
                    strquery = @"select * from (select distinct Jobcode,JobTitle,Duration,empl.EmpTypeName,loc.LocationName,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage,Assigned_To,job.Created_On as Datecreated from Job_Master_IND job
                                join Location_Master loc on job.Location=loc.LocationID
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientContactID=job.Contactname
                                where JobstatusName='Open' ) tb1 order by Datecreated desc";
                }
                else
                {
                    strquery = @"select * from (select distinct Jobcode,JobTitle,Duration,empl.EmpTypeName,loc.LocationName,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage,Assigned_To,job.Created_On as Datecreated from Job_Master_IND job
                                join Location_Master loc on job.Location=loc.LocationID
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientContactID=job.Contactname
                                where Assigned_To like '%" + TWE_Id + "%'" + " and JobstatusName='Open' ) tb1 order by Datecreated desc";
                }
            }

            else if (tiletype == "Pipeline")
            {
                if (jobEdit == "2" || jobView == "2")
                {
                    strquery = @"select job.Jobcode,JobTitle,Duration,empl.EmpTypeName,loc.LocationName,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar, job.Created_On, 106) Created_On,Jobimage,Assigned_To from Job_Master_IND job
                                join Location_Master loc on job.Location=loc.LocationID
                                join EmploymentType_Master empl on empl.EmpTypeID = job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID = job.Jobstatus
                                join ClientMaster cli on cli.ClientID = job.Clientname
                                join Client_Contact_Person con on con.ClientContactID=job.Contactname
                                join CandidateJobIndia canjob on job.Jobcode=canjob.Jobcode  
                                join CandidateDetailsIndia can on can.candidateid = canjob.CandidateId
                                where Cand_Status = '102' order by job.Created_On desc";
                }
                else
                {
                    strquery = @"select job.Jobcode,JobTitle,Duration,empl.EmpTypeName,loc.LocationName,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar, job.Created_On, 106) Created_On,Jobimage,Assigned_To from Job_Master_IND job
                                join Location_Master loc on job.Location=loc.LocationID
                                join EmploymentType_Master empl on empl.EmpTypeID = job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID = job.Jobstatus
                                join ClientMaster cli on cli.ClientID = job.Clientname
                                join Client_Contact_Person con on con.ClientContactID=job.Contactname
                                join CandidateJobIndia canjob on job.Jobcode=canjob.Jobcode  
                                join CandidateDetailsIndia can on can.candidateid = canjob.CandidateId
                                where Assigned_To like '%" + TWE_Id + "%'" +
                               " and Cand_Status = '102' order by job.Created_On desc";
                }
            }

            else if (tiletype == "High Priority")
            {
                if (jobEdit == "2" || jobView == "2")
                {
                    strquery = @"select * from(select distinct Jobcode,JobTitle,Duration,empl.EmpTypeName,loc.LocationName,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage,Assigned_To,job.Created_On as Datecreated from Job_Master_IND job
                                join Location_Master loc on job.Location=loc.LocationID
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientContactID=job.Contactname
                                where Prioritylevel='10300') tb1 order by Datecreated desc";
                }
                else
                {                   

                    strquery = @"select * from (select distinct Jobcode,JobTitle,Duration,empl.EmpTypeName,loc.LocationName,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage,Assigned_To,job.Created_On as Datecreated from Job_Master_IND job
                                join Location_Master loc on job.Location=loc.LocationID
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientContactID=job.Contactname
                                where Assigned_To like '%" + TWE_Id + "%'" +
                                " and Prioritylevel='10300' ) tb1 order by Datecreated desc";

                }
            }

            else if (tiletype == "No Submission")
            {
                if (nonsubJob != "")
                {
                    if (jobEdit == "2" || jobView == "2")
                    {
                        strquery = @"select distinct job.Jobcode,JobTitle,Duration,empl.EmpTypeName,loc.LocationName,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage,Assigned_To from Job_Master_IND job
                                left join CandidateJobIndia canjob on job.Jobcode=canjob.Jobcode  
                                left join CandidateDetailsIndia can on can.candidateid = canjob.CandidateId
                                join Location_Master loc on job.Location=loc.LocationID
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientContactID=job.Contactname  
                                where job.Jobcode not in
                                (" + nonsubJob + ") and JobstatusName='Open' ";
                    }
                    else
                    {
                        strquery = @"select distinct job.Jobcode,JobTitle,Duration,empl.EmpTypeName,loc.LocationName,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage,Assigned_To from Job_Master_IND job
                                left join CandidateJobIndia canjob on job.Jobcode=canjob.Jobcode  
                                left join CandidateDetailsIndia can on can.candidateid = canjob.CandidateId
                                join Location_Master loc on job.Location=loc.LocationID
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientContactID=job.Contactname  
                                where job.Jobcode not in
                                (" + nonsubJob + ") and Assigned_To like '%" + TWE_Id + "%'" + " and JobstatusName='Open' ";
                    }
                }

            }

            else if (tiletype == "Interview")
            {
                if (jobEdit == "2" || jobView == "2")
                {
                    strquery = @"select job.Jobcode,JobTitle,Duration,empl.EmpTypeName,loc.LocationName,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage,Assigned_To from Job_Master_IND job
                                join Location_Master loc on job.Location=loc.LocationID
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientContactID=job.Contactname
                                join CandidateJobIndia canjob on job.Jobcode=canjob.Jobcode  
                                join CandidateDetailsIndia can on can.candidateid = canjob.CandidateId
                                where Cand_Status in ('110','111') order by job.Created_On desc";
                }
                else
                {
                    strquery = @"select job.Jobcode,JobTitle,Duration,empl.EmpTypeName,loc.LocationName,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage,Assigned_To from Job_Master_IND job
                                join Location_Master loc on job.Location=loc.LocationID
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientContactID=job.Contactname
                                join CandidateJobIndia canjob on job.Jobcode=canjob.Jobcode  
                                join CandidateDetailsIndia can on can.candidateid = canjob.CandidateId
                                where Assigned_To like '%" + TWE_Id + "%'" +
                                " and Cand_Status in ('110','111') order by job.Created_On desc";
                }
            }
            else if (tiletype == "Follow Up")
            {
                if (jobEdit == "2" || jobView == "2")
                {
                    strquery = @"select distinct job.Jobcode,JobTitle,Duration,empl.EmpTypeName,loc.LocationName,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage,Assigned_To from Job_Master_IND job
                                join Location_Master loc on job.Location=loc.LocationID
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientContactID=job.Contactname
                                join CandidateJobIndia canjob on job.Jobcode=canjob.Jobcode  
                                join CandidateDetailsIndia can on can.candidateid = canjob.CandidateId
                                where Cand_Status in ('103','105','107','110','111') and JobstatusName not in ('Close') --order by job.Created_On desc";
                }
                else
                {
                    strquery = @"select distinct job.Jobcode,JobTitle,Duration,empl.EmpTypeName,loc.LocationName,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage,Assigned_To from Job_Master_IND job
                                join Location_Master loc on job.Location=loc.LocationID
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientContactID=job.Contactname
                                join CandidateJobIndia canjob on job.Jobcode=canjob.Jobcode  
                                join CandidateDetailsIndia can on can.candidateid = canjob.CandidateId
                                where Assigned_To like '%" + TWE_Id + "%'" +
                                " and  Cand_Status in ('103','105','107','110','111') and JobstatusName not in ('Close') --order by job.Created_On desc";
                }
            }
            else if (tiletype == "Total")
            {
                if (jobEdit == "2" || jobView == "2")
                {
                    strquery = @"select * from(select distinct Jobcode,JobTitle,Duration,empl.EmpTypeName,loc.LocationName,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage,Assigned_To,job.Created_On as Datecreated from Job_Master_IND job
                                join Location_Master loc on job.Location=loc.LocationID
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientContactID=job.Contactname
                                ) tb1 order by Datecreated desc";
                }
                else
                {
                    strquery = @"select * from(select distinct Jobcode,JobTitle,Duration,empl.EmpTypeName,loc.LocationName,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage,Assigned_To,job.Created_On as Datecreated from Job_Master_IND job
                                join Location_Master loc on job.Location=loc.LocationID
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientContactID=job.Contactname
                                where Assigned_To like '%" + TWE_Id + "%' ) tb1 order by Datecreated desc";
                }
            }

            else if (tiletype == "Closure")
            {
                if (jobEdit == "2" || jobView == "2" )
                {
                    strquery = @"select job.Jobcode,JobTitle,Duration,empl.EmpTypeName,loc.LocationName,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage,Assigned_To from Job_Master_IND job
                                join Location_Master loc on job.Location=loc.LocationID
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientContactID=job.Contactname
                                join CandidateJobIndia canjob on job.Jobcode=canjob.Jobcode  
                                join CandidateDetailsIndia can on can.candidateid = canjob.CandidateId
                                where Cand_Status in ('109') order by job.Created_On desc";
                }
                else
                {
                    strquery = @"select job.Jobcode,JobTitle,Duration,empl.EmpTypeName,loc.LocationName,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage,Assigned_To from Job_Master_IND job
                                join Location_Master loc on job.Location=loc.LocationID
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientContactID=job.Contactname
                                join CandidateJobIndia canjob on job.Jobcode=canjob.Jobcode  
                                join CandidateDetailsIndia can on can.candidateid = canjob.CandidateId
                                where Assigned_To like '%" + TWE_Id + "%'" +
                               " and Cand_Status in ('109') order by job.Created_On desc";
                }
            }


            //else if (tiletype == "Feedback")
            //{
            //    strquery = @"select distinct job.Jobcode,JobTitle,Duration,empl.EmpTypeName,loc.LocationName,
            //                    stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
            //                    convert(varchar,job.Created_On,106) Created_On,Jobimage from Job_Master_IND job
            //                    join Location_Master loc on job.Location=loc.LocationID
            //                    join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
            //                    join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
            //                    join ClientMaster cli on cli.ClientID=job.Clientname
            //                    join Client_Contact_Person con on con.ClientContactID=job.Contactname
            //                    join CandidateJobIndia canjob on job.Jobcode=canjob.Jobcode   
            //                    join CandidateDetailsIndia can on can.candidateid = canjob.CandidateId
            //                    where job.Created_By like '%" + TWE_Id + "%' and job.Created_On between '" + fromdate + "' and '" + todate + "'" +
            //                    " and  Cand_Status in ('103','105','107','110','111') and Jobstatus not in ('10201') --order by job.Created_On desc";
            //}

            //else if (tiletype == "MyJobs")
            //{
            //    strquery = @"select Jobcode,JobTitle,Duration,empl.EmpTypeName,loc.LocationName,
            //                    stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
            //                    convert(varchar,job.Created_On,106) Created_On,Jobimage from Job_Master_IND job
            //                    join Location_Master loc on job.Location=loc.LocationID
            //                    join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
            //                    join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
            //                    join ClientMaster cli on cli.ClientID=job.Clientname
            //                    join Client_Contact_Person con on con.ClientContactID=job.Contactname
            //                    where job.Created_By like '%" + TWE_Id + "%'" + " order by job.Created_On desc";
            //}



            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                JobcodeList objJob = new JobcodeList();

                objJob.Jobcode = _read[0].ToString();
                objJob.JobTitle = _read[1].ToString();
                objJob.JobDuration = _read[2].ToString();
                objJob.JobType = _read[3].ToString();
                objJob.JobState = _read[4].ToString();
                objJob.JobStatus = _read[5].ToString();
                objJob.JobClient = _read[6].ToString();
                objJob.JobContact = _read[7].ToString();
                objJob.CreatedOn = _read[8].ToString();
                objJob.JobMediaPath = _read[9].ToString();
                objJob.Assigned_To = _read[10].ToString();
                _db.lstJob.Add(objJob);
            }

            _read.Close();


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
                _json.data = _db;
            }

            return _json;
        }
        public jsonArray insertCandidatedetailsIndia(CandidatedetailsIndia candi)
        {

            int status = 1;
            string query = "";
            DateTime dateTime_India = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
            var timeInIST = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
            var timeInIndiaAsString = timeInIST.ToString("hh:mm tt", CultureInfo.InvariantCulture);

            if (candi.mode == "insert" && candi.employerid == "" && candi.employermailid != "")
            {
                query = @"INSERT INTO [EmployerDetailsIndia]" +
                       "([employeremailid],[employermobileno],[employername],[employerspecialization]" +
                       ",[employeradditionalinfo],[employercorporationaname],[Created_By],[Created_On],[Status]) VALUES(" +
                       "'" + candi.employermailid + "','" + candi.employerContactno + "','" + candi.employeename + "','" + candi.employerspecialization +
                       "','" + candi.employeradderinformation + "','" + candi.corporationname + "','" + candi.createdBy
                       + "','" + dateTime_India.ToString("yyyy-MM-dd") + "','" + '1' + "')";

                _sql.doInsert(query);

                string strquery = @"select max(employerid) employerid from EmployerDetailsIndia";

                SqlDataReader _read = _sql.doRead(strquery);
                while (_read.Read())
                {
                    candi.employerid = _read[0].ToString();
                }

                _read.Close();
            }

            else if (candi.mode == "update")
            {
                query = @"update EmployerDetailsIndia set employeremailid='" + candi.employermailid + "',employermobileno='" + candi.employerContactno
                    + "',employername='" + candi.employeename + "',employerspecialization='" + candi.employerspecialization +
                    "',employeradditionalinfo='" + candi.employeradderinformation + "',employercorporationaname='" + candi.corporationname
                    + "',Updated_By='" + candi.lastupdatedBy + "',Updated_On='" + dateTime_India.ToString("yyyy-MM-dd")
                    + "' where employerid='" + candi.employerid + "'";

                _sql.doInsert(query);


            }


            if (candi.mode == "insert")
            {
                query = @"insert into CandidateDetailsIndia ([candidateemailid]
                                                      ,[candidatemobileno]
                                                      ,[candidatename]
                                                      ,[currentLocation]
                                                      ,[TotYearsofExp]
                                                      ,[YearsofExp]
                                                      ,[currcompany]
                                                      ,[startdate]
                                                      ,[enddate]
                                                      ,[ratePerHr]
                                                      ,[type]
                                                      ,[skillsandCertif]
                                                      ,[linkedinURL]
                                                      ,[noticePeriod]
                                                      ,[availableforinterview]
                                                      ,[employerid]                                                      
                                                      ,[Created_By]
                                                      ,[Created_On]
                                                      ,[CreatedTime]) values('" +
                                                      candi.candidateemailid + "','" + candi.candidatemobileno + "','" + candi.candidatename + "','" +
                                                      candi.currentLocation + "','" + candi.TotYearsofExp + "','" + candi.yrsofexp + "','" + candi.currcompany + "','" +
                                                      candi.startdate + "','" + candi.enddate + "','" + candi.ratePerHr + "','" +
                                                      candi.type + "','" + candi.skillsandCertif + "','" + candi.linkedinURL + "','" + candi.noticePeriod + "','" +
                                                      candi.availableforinterview + "','" + candi.employerid + "','" + candi.createdBy + "','" + dateTime_India.ToString("yyyy-MM-dd") + "','" + timeInIndiaAsString + "')";

                _sql.doInsert(query);

                if (candi.candidateid == "")
                {
                    string strquery = @"select max(candidateid) candidateid from CandidateDetailsIndia";

                    SqlDataReader _read = _sql.doRead(strquery);
                    while (_read.Read())
                    {
                        candi.candidateid = _read[0].ToString();
                    }

                    _read.Close();
                }

                query = @"insert CandidateJobIndia(CandidateId,Jobcode,Created_By,Created_On,candidateRemark,RecruiterRating,Cand_Status) values (" + candi.candidateid + ",'" + candi.jobcode + "','" + candi.createdBy + "','" + dateTime_India.ToString("yyyy-MM-dd") + "','" + candi.candidateRemark + "','" + candi.recruiterrating + "','" + candi.candStatus + "')";

                _sql.doInsert(query);

            }
            else if (candi.mode == "update")
            {
                query = @"update CandidateDetailsIndia set candidateemailid='" + candi.candidateemailid + "',candidatemobileno='" +
                    candi.candidatemobileno + "',candidatename='" + candi.candidatename + "',currentLocation='" + candi.currentLocation + "',TotYearsofExp='" +
                    candi.TotYearsofExp + "',YearsofExp='" + candi.yrsofexp + "',currcompany='" + candi.currcompany + "',startdate='" + candi.startdate +
                    "',enddate='" + candi.enddate + "',ratePerHr='" + candi.ratePerHr + "',type='" + candi.type + "',skillsandCertif='" +
                    candi.skillsandCertif + "',linkedinURL='" + candi.linkedinURL + "',noticePeriod='" + candi.noticePeriod + "',availableforinterview='" +
                    candi.availableforinterview + "',employerid='" + candi.employerid + "',Last_Updated_By='" + candi.lastupdatedBy + "',Last_Updated_On='" + dateTime_India.ToString("yyyy-MM-dd") + "',UpdatedTime='" + timeInIndiaAsString + "' where candidateid='" + candi.candidateid + "'";

                _sql.doInsert(query);


                string strquery = @"select Jobcode from CandidateJobIndia where CandidateId='" + candi.candidateid + "' and Jobcode='" + candi.jobcode + "'";

                SqlDataReader _read = _sql.doRead(strquery);
                int ifExists = 0;
                while (_read.Read())
                {
                    ifExists = 1;
                }

                _read.Close();

                if (ifExists == 0)
                {
                    query = @"insert CandidateJobIndia(CandidateId,Jobcode,Created_By,Created_On,candidateRemark,RecruiterRating,Cand_Status,Created_time) values (" + candi.candidateid + ",'" + candi.jobcode + "','" + candi.createdBy + "','" + dateTime_India.ToString("yyyy-MM-dd") + "','" + candi.candidateRemark + "','" + candi.recruiterrating + "','" + candi.candStatus + "','" + timeInIndiaAsString + "')";

                }
                else
                {
                    query = @"update CandidateJobIndia set candidateRemark='" + candi.candidateRemark + "',RecruiterRating='" + candi.recruiterrating + "',Cand_Status='" + candi.candStatus + "',Updated_On='" +
                        dateTime_India.ToString("yyyy-MM-dd") + "',Updated_time='" + timeInIndiaAsString + "',Updated_By='" + candi.lastupdatedBy + "' where CandidateId='" + candi.candidateid + "' and Jobcode='" + candi.jobcode + "'";

                }

                _sql.doInsert(query);
            }



            if (candi.mode == "insert")
            {
                string strquery = @"select max(candidateid) candidateid from CandidateDetailsIndia";

                SqlDataReader _read = _sql.doRead(strquery);
                while (_read.Read())
                {
                    candi.candidateid = _read[0].ToString();
                }
                _read.Close();
            }

            for (int i = 0; i < candi.lstCandProof.Count; i++)
            {
                if (candi.lstCandProof[i].mode == "insert")
                {
                    query = @"insert into candproofdetailsIndia (" +
                        "candidateid,documenttype,idNo,idfilename) values('" +
                        candi.candidateid + "','" + candi.lstCandProof[i].documenttype + "','" +
                        candi.lstCandProof[i].idNo + "','" + candi.lstCandProof[i].idfilename + "')";


                }
                else if (candi.lstCandProof[i].mode == "update")
                {
                    query = @"update candproofdetailsIndia set " +
                        "documenttype='" + candi.lstCandProof[i].documenttype + "',idNo='" +
                        candi.lstCandProof[i].idNo + "',idfilename='" + candi.lstCandProof[i].idfilename +
                        "' where candproofid='" + candi.lstCandProof[i].candproofid + "'";


                }
                _sql.doInsert(query);
            }

            if (candi.mode == "update" && candi.candStatus == "103")
            {
                //sendSubmissionMail(candi);
            }
            jsonArray _json = new jsonArray();
            if (status == 0)
            {
                _json.status = "0";
                _json.message = "Candidate SQL QUERY EXECUTION FAILED";
                _json.data = new object();
            }
            else
            {
                _json = new jsonArray();
                _json.status = "1";
                _json.message = "Candidate SQL QUERY EXECUTED";
                _json.data = "";
            }

            return _json;
        }
        public jsonArray checkCandidatedataIndia(string emailid, string mobileno)
        {
            int status = 1;
            string query = "";
            CandidatedetailsIndia _cd = new CandidatedetailsIndia();
            string candiid = "";

            query = @"select candidateid from [CandidateDetailsIndia] where candidateemailid='" + emailid + "' or candidatemobileno='" + mobileno + "'";
            SqlDataReader _read = _sql.doRead(query);
            while (_read.Read())
            {
                candiid = _read[0].ToString();
            }
            _read.Close();

            if (candiid != "")
            {
                query = @"SELECT Jobcode,[candidateemailid],[candidatemobileno],[candidatename],[currentLocation],[TotYearsofExp],[YearsofExp],
                            [currcompany],[startdate],[enddate],[ratePerHr],[type],[skillsandCertif],[linkedinURL],[noticePeriod],
                            [availableforinterview],[employeremailid],[employermobileno],[employername],[employercorporationaname],[employeradditionalinfo],
                            cand.Created_By,cand.Created_On,cand.Last_Updated_By,cand.Last_Updated_On,employerspecialization,Cand_Status
                            FROM [CandidateDetailsIndia] cand
                            join CandidateJobIndia canjob on cand.candidateid=canjob.CandidateId
                            left join EmployerDetailsIndia empl on cand.employerid=empl.employerid                            
                            where cand.candidateid='" + candiid + "'";


                _read = _sql.doRead(query);
                while (_read.Read())
                {
                    _cd.jobcode = _read[0].ToString();
                    _cd.candidateemailid = _read[1].ToString();
                    _cd.candidatemobileno = _read[2].ToString();
                    _cd.candidatename = _read[3].ToString();
                    _cd.currentLocation = _read[4].ToString();
                    _cd.TotYearsofExp = _read[5].ToString();
                    _cd.yrsofexp = _read[6].ToString();
                    _cd.currcompany = _read[7].ToString();
                    _cd.startdate = _read[8].ToString();
                    _cd.enddate = _read[9].ToString();
                    _cd.ratePerHr = _read[10].ToString();
                    _cd.type = _read[11].ToString();
                    _cd.skillsandCertif = _read[12].ToString();
                    _cd.linkedinURL = _read[13].ToString();
                    _cd.noticePeriod = _read[14].ToString();
                    _cd.availableforinterview = _read[15].ToString();
                    _cd.employermailid = _read[16].ToString();
                    _cd.employerContactno = _read[17].ToString();
                    _cd.employeename = _read[18].ToString();
                    _cd.corporationname = _read[19].ToString();
                    _cd.employeradderinformation = _read[20].ToString();
                    //_cd.candidateRemark = _read[21].ToString();
                    _cd.createdBy = _read[21].ToString();
                    _cd.createdOn = _read[22].ToString();
                    _cd.lastupdatedBy = _read[23].ToString();
                    _cd.lastupdatedOn = _read[24].ToString();
                    _cd.employerspecialization = _read[25].ToString();
                    _cd.candStatus = _read[26].ToString();

                }
                _read.Close();
            }

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
                _json.data = _cd;
            }

            return _json;

        }
        public jsonArray getFollowupDetailsIndia(string jobid)
        {
            int status = 1;
            string query = "";
            candidatelistDetailsIndia _jc = new candidatelistDetailsIndia();
            List<candidatelistIndia> _lstcandi = new List<candidatelistIndia>();

            query = @"SELECT [Jobcode],[JobTitle],[Duration],[EmpTypeName],job.Country,[Description]
                    ,[Assigned_To],[PriorityName],[JobstatusName],Ratetype,[Minrate],[Maxrate],Currency,
                    [Skill],[Jobimage],
                    up.UP_firstName+' '+up.UP_lastName Created_By,Convert(varchar,job.Created_On,106) [Created_On],[Created_Time],up1.UP_firstName+' '+up1.UP_lastName Last_Updated_By,Convert(varchar
                    ,[Last_Updated_On],106) [Last_Updated_On],[Updated_Time],loc.LocationName,cli.ClientCompanyName,con.ContactPerson
                    ,[Startdate],[Noofopening],[ShiftTiming],[TurnAroundtime]
                    FROM [Job_Master_IND] job
                    join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                    join Priority_Master pri on pri.PriorityID=job.Prioritylevel
                    join Jobstatus_Master sta on sta.JobstatusID=job.Jobstatus
                    join Location_Master loc on loc.LocationID=job.Location
                    join Userprofile up on up.TWE_ID=job.Created_By
                    left join Userprofile up1 on up1.TWE_ID=job.Last_Updated_By
                    join ClientMaster cli on cli.ClientID=job.Clientname
                    join Client_Contact_Person con on job.Contactname=con.ClientContactID
                    where jobcode='" + jobid + "'";


            SqlDataReader _read = _sql.doRead(query);
            while (_read.Read())
            {
                _jc.Jobcodename = _read[0].ToString();
                _jc.JobTitle = _read[1].ToString();
                _jc.Duration = _read[2].ToString();
                _jc.EmplType = _read[3].ToString();
                _jc.Country = _read[4].ToString();
                _jc.Description = _read[5].ToString();
                _jc.AssignedTo = _read[6].ToString();
                _jc.Prioritylevel = _read[7].ToString();
                _jc.Jobstatus = _read[8].ToString();
                _jc.Ratetype = _read[9].ToString();
                _jc.Minrate = _read[10].ToString();
                _jc.Maxrate = _read[11].ToString();
                _jc.Currency = _read[12].ToString();
                _jc.Skill = _read[13].ToString();
                _jc.Jobimage = _read[14].ToString();
                _jc.Created_By = _read[15].ToString();
                _jc.Created_On = _read[16].ToString();
                _jc.Created_Time = _read[17].ToString();

                if (!(_read[18].Equals(System.DBNull.Value)))
                {
                    _jc.Updated_By = _read[18].ToString();
                }
                else
                {
                    _jc.Updated_By = "";
                }

                if (!(_read[19].Equals(System.DBNull.Value)))
                {
                    _jc.Updated_On = _read[19].ToString();
                }
                else
                {
                    _jc.Updated_On = "";
                }

                if (!(_read[20].Equals(System.DBNull.Value)))
                {
                    _jc.Updated_Time = _read[20].ToString();
                }
                else
                {
                    _jc.Updated_Time = "";
                }

                _jc.Location = _read[21].ToString();
                _jc.Clientname = _read[22].ToString();
                _jc.Contactname = _read[23].ToString();
                _jc.Startdate = _read[24].ToString();
                _jc.Noofopening = _read[25].ToString();
                _jc.ShiftTiming = _read[26].ToString();
                _jc.TurnAroundtime = _read[27].ToString();

            }
            _read.Close();

            if (_jc.Skill != "")
            {

                query = "select SkillName from Skill_Master where SkillID in (" + _jc.Skill + ")";
                _read = _sql.doRead(query);

                _jc.Skill = "";
                while (_read.Read())
                {
                    _jc.Skill += _read[0].ToString() + "|";
                }

                _jc.Skill = _jc.Skill.Substring(0, _jc.Skill.Length - 1);
                _read.Close();

            }

            if (_jc.AssignedTo.Contains(','))
            {
                string[] strEmp = _jc.AssignedTo.Split(',');
                string empName = "";
                for (int i = 0; i < strEmp.Length; i++)
                {
                    query = @"select UP_firstName+' '+UP_lastName EmpName from Userprofile where TWE_ID='" + strEmp[i] + "'";
                    _read = _sql.doRead(query);
                    while (_read.Read())
                    {
                        empName += _read[0].ToString() + ", ";
                    }
                    _read.Close();
                }

                _jc.AssignedTo = empName.Substring(0, empName.Length - 1);
            }
            else
            {
                query = @"select UP_firstName+' '+UP_lastName EmpName from Userprofile where TWE_ID='" + _jc.AssignedTo + "'";
                _read = _sql.doRead(query);
                while (_read.Read())
                {
                    _jc.AssignedTo = _read[0].ToString();
                }
                _read.Close();
            }


            //query = @"SELECT [candidateid],[jobcode],[candidateemailid],[candidatemobileno],[candidatename],[ratePerHr],[type],[employermailid]
            //            ,[employeename],[corporationname],sta.CandidateStatusName [Cand_Status],[Submitted_To],up.UP_firstName+' '+UP_lastName [Created_By],
            //            Convert(varchar,[Created_On],106) [Created_On],[linkedinURL],[CreatedTime] FROM [CandidateDetails] can
            //            join CandidateStatus_Master sta on sta.CandidateStatusID=can.Cand_Status
            //            join Userprofile up on up.TWE_ID=can.Created_By
            //            where Jobcode='" + jobid + "'";

            query = @"SELECT can.candidateid,job.jobcode,[candidateemailid],[candidatemobileno],[candidatename],[ratePerHr],typ.TypeName,empl.employeremailid
                        ,empl.employername,empl.employercorporationaname,sta.CandidateStatusName [Cand_Status],[Submitted_To],up.UP_firstName+' '+UP_lastName [Created_By],
                        Convert(varchar,can.Created_On,106) [Created_On],[linkedinURL],[CreatedTime],[currentLocation]
                        ,[TotYearsofExp] FROM [CandidateDetailsIndia] can
                        join CandidateJobIndia canjob on canjob.CandidateId=can.candidateid	
                        join CandidateStatus_Master sta on sta.CandidateStatusID=canjob.Cand_Status
						join Job_Master_IND job on job.Jobcode=canjob.Jobcode		  
                        left join EmployerDetailsIndia empl on empl.employerid=can.employerid
                        join Type_Master typ on typ.TypeID=can.type
                        join Userprofile up on up.TWE_ID=can.Created_By
                        where job.Jobcode='" + jobid + "'";

            _read = _sql.doRead(query);
            while (_read.Read())
            {
                candidatelistIndia candilst = new candidatelistIndia();
                candilst.candidateid = _read[0].ToString();
                candilst.candidatemediapath = "";
                candilst.candidateemailid = _read[2].ToString();
                candilst.candidatemobno = _read[3].ToString();
                candilst.candidatename = _read[4].ToString();
                candilst.ratePerHr = _read[5].ToString();
                candilst.type = _read[6].ToString();
                candilst.vendoremailid = _read[7].ToString();
                candilst.vendorname = _read[8].ToString();
                candilst.candidatestatus = _read[10].ToString();
                candilst.submittedby = _read[12].ToString();
                candilst.submitteddate = _read[13].ToString();
                candilst.submittedtime = _read[15].ToString();
                candilst.linkedinURL = _read[14].ToString();
                candilst.currentLocation = _read[16].ToString();
                candilst.TotYearsofExp = _read[17].ToString();
                _lstcandi.Add(candilst);
            }

            _read.Close();
            _jc.candidatelistinfo = _lstcandi;
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
                _json.data = _jc;
            }

            return _json;

        }
        public jsonArray getCandidateViewdataIndia(string Candidateid)
        {
            int status = 1;
            string query = "";
            CandidatedetailsIndia _cd = new CandidatedetailsIndia();
            query = @"SELECT job.jobcode,[candidateemailid],[candidatemobileno],[candidatename],[currentLocation],[TotYearsofExp],[YearsofExp],
                            [currcompany],cand.startdate,[enddate],[ratePerHr],[type],[skillsandCertif],[linkedinURL],[noticePeriod],
                            [availableforinterview],[employeremailid],[employermobileno],[employername],[employercorporationaname],[employeradditionalinfo],[employerspecialization],
                            [candidateRemark],cand.Created_By,cand.Created_On,cand.Last_Updated_By,cand.Last_Updated_On,[Cand_Status],[RTRemailstatus],empl.employerid,RecruiterRating FROM [CandidateDetailsIndia] cand
                            left join EmployerDetailsIndia empl on cand.employerid=empl.employerid
                            join CandidateJobIndia canjob on canjob.CandidateId=cand.candidateid 
                            left join Job_Master_IND job on job.Jobcode=canjob.Jobcode 
                            left join RTRConfirmationIndia rtr on rtr.candidateemaildid=cand.candidateemailid
                            where cand.candidateid='" + Candidateid + "'";


            SqlDataReader _read = _sql.doRead(query);

            while (_read.Read())
            {
                _cd.jobcode = _read[0].ToString();
                _cd.candidateemailid = _read[1].ToString();
                _cd.candidatemobileno = _read[2].ToString();
                _cd.candidatename = _read[3].ToString();
                _cd.currentLocation = _read[4].ToString();
                _cd.TotYearsofExp = _read[5].ToString();
                _cd.yrsofexp = _read[6].ToString();
                _cd.currcompany = _read[7].ToString();
                _cd.startdate = _read[8].ToString();
                _cd.enddate = _read[9].ToString();
                _cd.ratePerHr = _read[10].ToString();
                _cd.type = _read[11].ToString();
                _cd.skillsandCertif = _read[12].ToString();
                _cd.linkedinURL = _read[13].ToString();
                _cd.noticePeriod = _read[14].ToString();
                _cd.availableforinterview = _read[15].ToString();
                _cd.employermailid = _read[16].ToString();
                _cd.employerContactno = _read[17].ToString();
                _cd.employeename = _read[18].ToString();
                _cd.corporationname = _read[19].ToString();
                _cd.employeradderinformation = _read[20].ToString();
                _cd.employerspecialization = _read[21].ToString();
                _cd.candidateRemark = _read[22].ToString();
                _cd.createdBy = _read[23].ToString();
                _cd.createdOn = _read[24].ToString();
                _cd.lastupdatedBy = _read[25].ToString();
                _cd.lastupdatedOn = _read[26].ToString();
                _cd.candStatus = _read[27].ToString();
                _cd.rtrStatus = _read[28].ToString();
                _cd.employerid = _read[29].ToString();
                _cd.recruiterrating = _read[30].ToString();
            }

            _read.Close();

            _cd.lstCandProof = new List<candidateProof>();

            query = @"select candproofid,documenttype,idNo,idfilename from candproofdetailsIndia" +
                            " where candidateid='" + Candidateid + "'";


            _read = _sql.doRead(query);
            while (_read.Read())
            {
                candidateProof objProof = new candidateProof();
                objProof.candproofid = _read[0].ToString();
                objProof.documenttype = _read[1].ToString();
                objProof.idNo = _read[2].ToString();
                objProof.idfilename = _read[3].ToString();
                _cd.lstCandProof.Add(objProof);
            }


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
                _json.data = _cd;
            }

            return _json;

        }
        public jsonArray getJobDetailsIndia(string jobid)
        {
            int status = 1;
            string query = "";
            JobcodeIndia _jc = new JobcodeIndia();
            query = @"SELECT [Jobcode],[JobTitle],[Duration],[EmplType],[Location],[Country],[Clientname],[Contactname],[Description]
                              ,[Assigned_To],[Prioritylevel],[Jobstatus],[Startdate],[Noofopening],[ShiftTiming],[TurnAroundtime],[Minrate],[Maxrate],[Ratetype],[Currency],[Skill],[Jobopendate]
                              ,[Jobclosedate],[OpenComments],[CloseComments],[Jobimage],up.UP_firstName+' '+up.UP_lastName Created_By,[Created_On],up1.UP_firstName+' '+up1.UP_lastName Last_Updated_By,[Last_Updated_On],up1.TWE_ID UpdatedBy,[Publish_Web]
                              FROM [Job_Master_IND] job
							  join Userprofile up on up.TWE_ID=job.Created_By
							  left join Userprofile up1 on up1.TWE_ID=job.Last_Updated_By
                              where Jobcode='" + jobid + "'";


            SqlDataReader _read = _sql.doRead(query);
            while (_read.Read())
            {
                _jc.Jobcodename = _read[0].ToString();
                _jc.JobTitle = _read[1].ToString();
                _jc.Duration = _read[2].ToString();
                _jc.EmplType = _read[3].ToString();
                _jc.Location = _read[4].ToString();
                _jc.Country = _read[5].ToString();
                _jc.Clientname = _read[6].ToString();
                _jc.Contactname = _read[7].ToString();
                _jc.Description = _read[8].ToString();
                _jc.AssignedTo = _read[9].ToString();
                _jc.Prioritylevel = _read[10].ToString();
                _jc.Jobstatus = _read[11].ToString();
                _jc.Startdate = _read[12].ToString();
                _jc.Noofopening = _read[13].ToString();
                _jc.ShiftTiming = _read[14].ToString();
                _jc.TurnAroundtime = _read[15].ToString();
                _jc.Minrate = _read[16].ToString();
                _jc.Maxrate = _read[17].ToString();
                _jc.Ratetype = _read[18].ToString();
                _jc.Currency = _read[19].ToString();
                _jc.Skill = _read[20].ToString();
                _jc.Jobopendate = _read[21].ToString();
                _jc.Jobclosedate = _read[22].ToString();
                _jc.OpenComments = _read[23].ToString();
                _jc.CloseComments = _read[24].ToString();
                _jc.Jobimage = _read[25].ToString();
                _jc.Created_By = _read[26].ToString();
                _jc.Created_On = Convert.ToDateTime(_read[27]).ToString("yyyy-MM-dd");
                if (!(_read[28].Equals(System.DBNull.Value)))
                {
                    _jc.Updated_By = _read[28].ToString();
                }
                else
                {
                    _jc.Updated_By = "";
                }

                if (!(_read[29].Equals(System.DBNull.Value)))
                {
                    _jc.Updated_On = Convert.ToDateTime(_read[29]).ToString("yyyy-MM-dd");
                }
                else
                {
                    _jc.Updated_On = "";
                }
                if (!(_read[30].Equals(System.DBNull.Value)))
                {
                    _jc.Updated_By_ID = _read[30].ToString();
                }
                else
                {
                    _jc.Updated_By_ID = "";
                }

                _jc.Publish_Web = _read[31].ToString();
            }


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
                _json.data = _jc;
            }

            return _json;

        }
        public jsonArray getRecrutingdashboarddetailsIndia(string TWE_id, string fromdate, string todate, string strType)
        {
            Recrutingdashboard _rd = new Recrutingdashboard();
            List<tiles> _lsttls = new List<tiles>();
            List<holdresumetiles> _lsthrt = new List<holdresumetiles>();
            List<statuscount> _lststc = new List<statuscount>();
            List<performanceoverview> _lstpov = new List<performanceoverview>();
            List<recruitmenttable> _lstrt = new List<recruitmenttable>();
            List<barchartlist> _lstbar = new List<barchartlist>();
            List<linechartlist> _lstline = new List<linechartlist>();

            int status = 1;
            string strquery = "";
            string strtype = strType;
            _rd.TWE_id = TWE_id;

            strquery = @"select firstName,role,''mediapath from Userprofilecreation where TWE_ID='" + TWE_id + "'";

            SqlDataReader _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                _rd.UserName = _read[0].ToString();
                _rd.Roleid = _read[1].ToString();
                _rd.UserProfile = _read[2].ToString();
            }
            _read.Close();


            _rd.DateRange = "03 june 2021 to 10 june 2021";

            strquery = @"select tb1.t1,tb1.tt1,tb1.Total_jobs,tb2.tt2,tb2.Active_jobs from
                            (select '1't1,'Total Jobs'tt1, count(*) Total_jobs from Job_Master_IND where Created_On between '" + fromdate + "' and '" + todate + "' and Assigned_To like '%" + TWE_id + "%') tb1," +
                        "(select 'Active' tt2,count(*) Active_jobs from Job_Master_IND where Created_On between '" + fromdate + "' and '" + todate + "' and Jobstatus='10200'  and Assigned_To like '%" + TWE_id + "%') tb2" +
                        " union " +
                        "select tb3.t2,tb3.tt3,tb3.Active_vendors,tb8.tt4,tb8.New_vendors from" +
                        "(select '2't2,'Vendors'tt3,count(*) Active_vendors from EmployerDetailsIndia where Created_On between '" + fromdate + "' and '" + todate + "'  and Created_By like '%" + TWE_id + "%') tb3," +
                        "(select 'Active'tt4,count(*) New_vendors from EmployerDetailsIndia where Created_On between '" + fromdate + "' and '" + todate + "' and Status='1'  and Created_By like '%" + TWE_id + "%') tb8 " +
                        " union " +
                        "select tb4.t3,tb4.tt5,tb4.Resumeinprocess,tb5.tt6,tb5.EC_Selected from" +
                        "(select '3't3,'Candidates'tt5,count(distinct candidateemailid) Resumeinprocess from CandidateDetailsIndia can" +
                        " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                        " left join Job_Master_IND job on job.Jobcode=canjob.Jobcode" +
                        " where can.Created_On between '" + fromdate + "' and '" + todate + "' and can.Created_By like '%" + TWE_id + "%')tb4,(select 'Client'tt6,count(distinct candidateemailid) EC_Selected from CandidateDetailsIndia can join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                        " join Job_Master_IND job on job.Jobcode=canjob.Jobcode where Cand_Status in ('107','108','111') and can.Created_On between '" + fromdate + "' and '" + todate + "'and can.Created_By like '%" + TWE_id + "%')tb5 union select tb6.t4,tb6.tt7,tb6.Onboarded,tb7.tt8,tb7.ResumesinHold  from(select '4't4,'Made Closure'tt7,count(distinct can.candidateid) Onboarded from CandidateDetailsIndia can join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                        " join Job_Master_IND job on job.Jobcode=canjob.Jobcode where Cand_Status in ('109') and can.Created_On between '" + fromdate + "' and '" + todate + "' and can.Created_By like '%" + TWE_id + "%')tb6,(select 'On Live'tt8,'0' ResumesinHold)tb7";


            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                tiles _tls = new tiles();
                _tls.TileTitle = _read[1].ToString();
                _tls.TotalCount = _read[2].ToString();
                _tls.Name = _read[3].ToString();
                _tls.AchiveCount = _read[4].ToString();
                _lsttls.Add(_tls);


            }
            _read.Close();
            _rd.Tiles = _lsttls;

            strquery = @"select count(distinct candidateemailid) EC_Selected from CandidateDetailsIndia can join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId
                        join Job_Master_IND job on job.Jobcode=canjob.Jobcode where Cand_Status  in ('103','105' ,'107','110','111') and Jobstatus != 10201 and can.Created_On between '" + fromdate + "' and '" + todate + "' and  can.Created_By like '%" + TWE_id + "%'";
            _read = _sql.doRead(strquery);
            while (_read.Read())
            {
                holdresumetiles _hrt = new holdresumetiles();
                _hrt.FirstHeading = "Resumes On Hold";
                _hrt.SecondHeading = "Get Feedback Now";
                _hrt.ThirdHeading = "Making follow-ups will give successful closures.";
                _hrt.Count = _read[0].ToString();
                _lsthrt.Add(_hrt);
            }
            _read.Close();
            _rd.HoldResumeTiles = _lsthrt;
            string[] lstSub = new string[5];
            strquery = @"select tb1.Submitted_Mon,tb3.Submitted_Tue,
                                tb5.Submitted_Wed,tb7.Submitted_Thu,tb9.Submitted_Fri from
                                (select count(*) Submitted_Mon from CandidateDetailsIndia can join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId
                                join Job_Master_IND job on job.Jobcode=canjob.Jobcode where Cand_Status in ('103') and can.Created_By='" + TWE_id + "' and can.Created_On between '" + fromdate + "' and '" + todate + "') tb1," +
                               "(select count(*) Submitted_Tue from CandidateDetailsIndia can join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                               " join Job_Master_IND job on job.Jobcode = canjob.Jobcode where Cand_Status in ('103') and can.Created_By='" + TWE_id + "' and can.Created_On between '" + fromdate + "' and '" + todate + "') tb3," +
                               "(select count(*) Submitted_Wed from CandidateDetailsIndia can join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                               " join Job_Master_IND job on job.Jobcode = canjob.Jobcode where Cand_Status in ('103') and can.Created_By='" + TWE_id + "' and can.Created_On between '" + fromdate + "' and '" + todate + "') tb5," +
                               "(select count(*) Submitted_Thu from CandidateDetailsIndia can join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                               " join Job_Master_IND job on job.Jobcode = canjob.Jobcode where Cand_Status in ('103') and can.Created_By='" + TWE_id + "' and can.Created_On between '" + fromdate + "' and '" + todate + "') tb7," +
                               "(select count(*) Submitted_Fri from CandidateDetailsIndia can join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                               " join Job_Master_IND job on job.Jobcode = canjob.Jobcode where Cand_Status in ('103') and can.Created_By='" + TWE_id + "' and can.Created_On between '" + fromdate + "' and '" + todate + "') tb9";
            _read = _sql.doRead(strquery);
            while (_read.Read())
            {
                lstSub[0] = _read[0].ToString();
                lstSub[1] = _read[1].ToString();
                lstSub[2] = _read[2].ToString();
                lstSub[3] = _read[3].ToString();
                lstSub[4] = _read[4].ToString();
            }
            _read.Close();

            //Bar Chart Query
            if (strtype == "Monthly")
            {
                strquery = @"select count(*) CandCount,Substring(Datename(mm,(can.Created_On)),0,4) MonName from CandidateDetailsIndia can
                                        join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId
                                        join Job_Master_IND job on job.Jobcode=canjob.Jobcode
                                        where Cand_Status>=103
                                        and can.Created_By='" + TWE_id + "' and can.Created_On between '" + fromdate + "' and '" + todate +
                                        "' group by Datename(mm,(can.Created_On))";
            }
            else if (strtype == "Daily")
            {
                strquery = @"select count(*) CandCount,Substring(Datename(Weekday,can.Created_On),0,4) dyName from CandidateDetailsIndia can
                                        join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId
                                        join Job_Master_IND job on job.Jobcode=canjob.Jobcode
                                        where Cand_Status>=103
                                        and can.Created_By='" + TWE_id + "' and can.Created_On between '" + fromdate + "' and '" + todate +
                                        "' group by  Datename(Weekday,can.Created_On)";
            }
            else if (strtype == "Weekly")
            {
                strquery = @"select count(*) CandCount, 'Week '+ Convert(varchar,DATEPART(week,can.Created_On)) WkName from CandidateDetailsIndia can
                                        join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId
                                        join Job_Master_IND job on job.Jobcode=canjob.Jobcode
                                        where Cand_Status>=103
                                        and can.Created_By='" + TWE_id + "' and can.Created_On between '" + fromdate + "' and '" + todate
                                        + "' group by DATEPART(week,can.Created_On)";
            }
            _read = _sql.doRead(strquery);
            while (_read.Read())
            {
                barchartlist _bcl = new barchartlist();
                _bcl.candCount = _read[0].ToString();
                _bcl.itemName = _read[1].ToString();
                _lstbar.Add(_bcl);

            }
            _read.Close();
            string data1 = "";
            if (_lstbar.Count != 0)
            {
                for (int i = 0; i < _lstbar.Count; i++)
                {
                    data1 += _lstbar[i].candCount + ",";
                }
                data1 = data1.Substring(0, data1.Length - 1);
            }

            string data2 = "";
            if (_lstbar.Count != 0)
            {
                for (int i = 0; i < _lstbar.Count; i++)
                {
                    data2 += "'" + _lstbar[i].itemName + "',";
                }
                data2 = data2.Substring(0, data2.Length - 1);
            }

            _rd.Barchart = "<canvas id='chart-bars' class='chart-canvas' height='170px'></canvas>  <script> " +
                        "var ctx = document.getElementById('chart-bars').getContext('2d'); " +
                        "new Chart(ctx, {" +
                        "type: 'bar'," +
                        "data: {" +
                        "labels: [" + data2 + "]," +
                        "datasets: [{" +
                        "label: 'Submissions'," +
                        "tension: 0.4," +
                        "borderWidth: 0," +
                        "pointRadius: 0," +
                        "backgroundColor: '#fff'," +
                        "data: [" + data1 + "]," +
                        "maxBarThickness: 6" +
                        "},]," +
                        "}," +
                        "options:" +
                        "{" +
                        "responsive: true," +
                        "maintainAspectRatio: false," +
                        "legend:" +
                        "{" +
                        "display: false," +
                        "}," +
                        "tooltips:" +
                        "{" +
                        "enabled: true," +
                        "mode: 'index'," +
                        "intersect: false," +
                        "}," +
                        "scales: " +
                        "{" +
                        "yAxes: [{" +
                        "gridLines:" +
                        "{" +
                        "display: false," +
                        "}," +
                        "ticks: " +
                        "{" +
                        "suggestedMin: 0," +
                        "suggestedMax: 5," +
                        "beginAtZero: true," +
                        "padding: 0," +
                        "fontSize: 14," +
                        "lineHeight: 3," +
                        "fontColor: '#fff'," +
                        "fontStyle: 'normal'," +
                        "fontFamily: 'Open Sans'," +
                        "}," +
                        "},]," +
                        "xAxes: [{" +
                        "gridLines: " +
                        "{" +
                        "display: false," +
                        "}," +
                        "ticks: " +
                        "{" +
                        "display: false," +
                        "padding: 20," +
                        "}," +
                        "},]," +
                        "}," +
                        "}," +
                        "}); </script>";
            _rd.BarTitle = "Active Candidates";
            _rd.BarDuration = "Duration for the Week of ";

            strquery = @"select '1't1,'SB'sp,count(*) EC_Selected from CandidateDetailsIndia can
                                        join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId
                                        join Job_Master_IND job on job.Jobcode=canjob.Jobcode where Cand_Status in ('101','102') and can.Created_By like '%" + TWE_id + "%' and can.Created_On between '" + fromdate + "' and '" + todate + "'" +
                                       " union " +
                                       "select '2't2,'TL'tl,count(*) EC_Selected from CandidateDetailsIndia can" +
                                               " join CandidateJobIndia canjob on can.candidateid = canjob.CandidateId" +
                                               " join Job_Master_IND job on job.Jobcode = canjob.Jobcode where Cand_Status in ('103') and can.Created_By like '%" + TWE_id + "%' and can.Created_On between '" + fromdate + "' and '" + todate + "'" +
                                       " union " +
                                       " select '3't3,'BP'bp,count(*) EC_Selected from CandidateDetailsIndia can" +
                                               " join CandidateJobIndia canjob on can.candidateid = canjob.CandidateId" +
                                               " join Job_Master_IND job on job.Jobcode = canjob.Jobcode where Cand_Status in ('105') and can.Created_By like '%" + TWE_id + "%' and can.Created_On between '" + fromdate + "' and '" + todate + "'" +
                                       " union " +
                                       " select '4't4,'EC'ec,count(*) EC_Selected from CandidateDetailsIndia can" +
                                               " join CandidateJobIndia canjob on can.candidateid = canjob.CandidateId" +
                                               " join Job_Master_IND job on job.Jobcode = canjob.Jobcode where Cand_Status in ('107') and can.Created_By like '%" + TWE_id + "%' and can.Created_On between '" + fromdate + "' and '" + todate + "'";

            _read = _sql.doRead(strquery);
            while (_read.Read())
            {
                statuscount _sc = new statuscount();
                _sc.StatusTitle = _read[1].ToString();
                _sc.StatusValue = _read[2].ToString();
                _lststc.Add(_sc);

            }
            _rd.StatusCount = _lststc;
            _read.Close();


            if (strtype == "Monthly")
            {
                strquery = @"select 'SB'colname, count(*) Submitted,month(can.Created_On) Monname  from CandidateDetailsIndia can" +
                                       " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                                       " join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
                                       " where Cand_Status in ('101','102','103','104','105','106','107','108','109','110','111') and can.Created_By like '%" + TWE_id + "%' " +
                                       " and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                                       " group by month(can.Created_On) " +
                                       " union " +
                                       " select 'TL'colname,count(*) TL_Selected,month(can.Created_On) Monname from CandidateDetailsIndia can" +
                                       " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                                       " join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
                                       " where Cand_Status>103 and can.Created_By like '%" + TWE_id + "%' " +
                                       " and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                                       " group by month(can.Created_On) " +
                                       " union " +
                                       " select 'BP'colname,count(*) BP_Selected,month(can.Created_On) Monname  from CandidateDetailsIndia can" +
                                       " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                                       " join Job_Master_IND job on job.Jobcode = canjob.Jobcode where " +
                                       " Cand_Status in ('103','105') and can.Created_By like '%" + TWE_id + "%' " +
                                       " and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                                       " group by month(can.Created_On) " +
                                       " union " +
                                       " select 'EC'colname,count(*) EC_Selected,month(can.Created_On) Monname from CandidateDetailsIndia can" +
                                       " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                                       " join Job_Master_IND job on job.Jobcode = canjob.Jobcode where " +
                                       " Cand_Status in ('107') and can.Created_By like '%" + TWE_id + "%' " +
                                       " and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                                       " group by month(can.Created_On)";
            }
            else if (strtype == "Weekly")
            {
                strquery = @"select 'SB'colname, count(*) Submitted,DATEPART(week,can.Created_On) Wkname  from CandidateDetailsIndia can" +
                            " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                            " join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
                            " where Cand_Status in ('101','102') and can.Created_By like '%" + TWE_id + "%' " +
                            " and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                            " group by DATEPART(week,can.Created_On) " +
                            " union " +
                            " select 'TL'colname,count(*) TL_Selected,DATEPART(week,can.Created_On) Wkname from CandidateDetailsIndia can" +
                            " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                            " join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
                            " where Cand_Status in ('103') and can.Created_By like '%" + TWE_id + "%' " +
                            " and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                            " group by DATEPART(week,can.Created_On) " +
                            " union " +
                            " select 'BP'colname,count(*) BP_Selected,DATEPART(week,can.Created_On) Wkname  from CandidateDetailsIndia can" +
                            " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                            " join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
                            " where Cand_Status in ('105') and can.Created_By like '%" + TWE_id + "%' " +
                            " and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                            " group by DATEPART(week,can.Created_On) " +
                            " union " +
                            " select 'EC'colname,count(*) EC_Selected,DATEPART(week,can.Created_On) Wkname from CandidateDetailsIndia can" +
                            " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                            " join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
                            " where Cand_Status in ('107') and can.Created_By like '%" + TWE_id + "%' " +
                            " and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                            " group by DATEPART(week,can.Created_On)";
            }
            else if (strtype == "Daily")
            {
                strquery = @"select 'SB'colname, count(*) Submitted,substring(datename(dw,can.Created_On),0,4) dyname  from CandidateDetailsIndia can" +
                                   " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                                   " join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
                                   " where Cand_Status in ('101','102') and can.Created_By like '%" + TWE_id + "%' " +
                                   " and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                                   " group by datename(dw,can.Created_On) " +
                                   " union " +
                                   " select 'TL'colname,count(*) TL_Selected,substring(datename(dw,can.Created_On),0,4) dyname from CandidateDetailsIndia can" +
                                   " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                                   " join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
                                   " where Cand_Status in ('103') and can.Created_By like '%" + TWE_id + "%' " +
                                   " and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                                   " group by datename(dw,can.Created_On) " +
                                   " union " +
                                   " select 'BP'colname,count(*) BP_Selected,substring(datename(dw,can.Created_On),0,4) dyname  from CandidateDetailsIndia can" +
                                   " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                                   " join Job_Master_IND job on job.Jobcode = canjob.Jobcode where " +
                                   " Cand_Status in ('105') and can.Created_By like '%" + TWE_id + "%' " +
                                   " and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                                   " group by datename(dw,can.Created_On) " +
                                   " union " +
                                   " select 'EC'colname,count(*) EC_Selected,substring(datename(dw,can.Created_On),0,4) dyname from CandidateDetailsIndia can" +
                                   " join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                                   " join Job_Master_IND job on job.Jobcode = canjob.Jobcode where " +
                                   " Cand_Status in ('107') and can.Created_By like '%" + TWE_id + "%' " +
                                   " and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                                   " group by datename(dw,can.Created_On) ";
            }
            _read = _sql.doRead(strquery);
            while (_read.Read())
            {
                linechartlist _lcl = new linechartlist();
                _lcl.colName = _read[0].ToString();
                _lcl.submitted = _read[1].ToString();
                _lcl.itemName = _read[2].ToString();
                _lstline.Add(_lcl);

            }
            _read.Close();

            string strData = "";

            int timeVal = 0;
            if (strtype == "Monthly")
            {
                timeVal = 12;
                strData = "'Jan','Feb','Mar','Apr','May','Jun','Jul','Aug','Sep','Oct','Nov','Dec'";
            }
            else if (strtype == "Weekly")
            {
                timeVal = 53;
                strData = "'Wk1','Wk2','Wk3','Wk4','Wk5','Wk6','Wk7','Wk8','Wk9','Wk10','Wk11','Wk12','Wk13','Wk14','Wk15','Wk16','Wk17','Wk18','Wk19','Wk20','Wk21','Wk22','Wk23','Wk24','Wk25','Wk26','Wk27','Wk28','Wk29','Wk30','Wk31','Wk32','Wk33','Wk34','Wk35','Wk36','Wk37','Wk38','Wk39','Wk40','Wk41','Wk42','Wk43','Wk44','Wk45','Wk46','Wk47','Wk48','Wk49','Wk50','Wk51','Wk52','Wk53'";
            }
            else if (strtype == "Daily")
            {
                timeVal = 7;
                strData = "'Sun','Mon','Tue','Wed','Thu','Fri','Sat'";
            }
            string[] stageArr = { "SB", "TL", "BP", "EC" };



            List<linechartlist> lstchartSub = new List<linechartlist>();

            List<linechartlist> lstDt0 = _lstline.OrderBy(x => x.itemName).ThenBy(y => y.colName).ToList<linechartlist>();

            for (int i = 0; i < stageArr.Length; i++)
            {

                string countval = "";
                for (int j = 1; j <= timeVal; j++)
                {

                    List<linechartlist> lstResult = _lstline.Where(x => (x.itemName == j.ToString()) && (x.colName == stageArr[i])).ToList<linechartlist>();
                    if (lstResult.Count == 0)
                    {
                        countval = countval + "0" + ",";
                    }
                    else
                    {
                        countval = countval + lstResult[0].submitted.ToString() + ",";
                    }

                }

                lstchartSub.Add(new linechartlist() { colName = stageArr[i], submitted = countval.Substring(0, countval.Length - 1) });
                countval = "";

            }


            _rd.Linechart = "<canvas id='chart-line' class='chart-canvas' height='300px'></canvas> <script> " +
                      "var ctx2 = document.getElementById('chart-line').getContext('2d');" +
                      "var gradientStroke1 = ctx2.createLinearGradient(0, 230, 0, 50);" +

                "gradientStroke1.addColorStop(1, 'rgba(203,12,159,0.2)');" +
                "gradientStroke1.addColorStop(0.2, 'rgba(72,72,176,0.0)'); " +
                "gradientStroke1.addColorStop(0, 'rgba(203,12,159,0)'); " + //purple colors

                "var gradientStroke2 = ctx2.createLinearGradient(0, 230, 0, 50); " +

                "gradientStroke2.addColorStop(1, 'rgba(20,23,39,0.2)'); " +
                "gradientStroke2.addColorStop(0.2, 'rgba(72,72,176,0.0)'); " +
                "gradientStroke2.addColorStop(0, 'rgba(20,23,39,0)');" + //purple colors

                "var gradientStroke3 = ctx2.createLinearGradient(0, 230, 0, 50);" +

                "gradientStroke3.addColorStop(1, 'rgba(203,0,159,0.2)');" +
                "gradientStroke3.addColorStop(0.2, 'rgba(72,72,72,0.0)'); " +
                "gradientStroke3.addColorStop(0, 'rgba(203,12,120,0)'); " + //purple colors

                "var gradientStroke4 = ctx2.createLinearGradient(0, 230, 0, 50); " +

                "gradientStroke4.addColorStop(1, 'rgba(20,180,139,0.2)'); " +
                "gradientStroke4.addColorStop(0.2, 'rgba(0,72,176,0.0)'); " +
                "gradientStroke4.addColorStop(0, 'rgba(120,123,39,0)');" + //purple colors


                "new Chart(ctx2, {" +
                "type: 'line'," +
                "data: " +
                "{" +
                "labels: [" + strData + "]," +
                "datasets: [{" +
                "label: 'SB Candidates'," +
                "tension: 0.4," +
                "borderWidth: 0," +
                "pointRadius: 0," +
                "borderColor: '#42eff5'," +
                "borderWidth: 3," +
                "backgroundColor: '#42eff5'," +
                "data: [" + lstchartSub[0].submitted + "]," +
                "maxBarThickness: 6,fill:false" +

                "}," +
                "{" +
                "label: 'TL Candidates'," +
                "tension: 0.4," +
                "borderWidth: 0," +
                "pointRadius: 0," +
                "borderColor: '#f58742'," +
                "borderWidth: 3," +
                "backgroundColor: '#f58742'," +
                "data: [" + lstchartSub[1].submitted + "]," +
                "maxBarThickness: 6,fill:false" +

                "}," +
                 "{" +
                "label: 'BP Candidates'," +
                "tension: 0.4," +
                "borderWidth: 0," +
                "pointRadius: 0," +
                "borderColor: '#e642f5'," +
                "borderWidth: 3," +
                "backgroundColor: '#e642f5'," +
                "data: [" + lstchartSub[2].submitted + "]," +
                "maxBarThickness: 6,fill:false" +

                "}," +
                 "{" +
                "label: 'EC Candidates'," +
                "tension: 0.4," +
                "borderWidth: 0," +
                "pointRadius: 0," +
                "borderColor: 'green'," +
                "borderWidth: 3," +
                "backgroundColor: 'green'," +
                "data: [" + lstchartSub[3].submitted + "]," +
                "maxBarThickness: 6,fill:false" +

                "}," +

                "]," +
                "}," +
                "options: " +
                "{" +
                "responsive: true," +
                "maintainAspectRatio: false," +
                "legend: " +
                "{" +
                "display: false," +
                "}," +
                "tooltips: " +
                "{" +
                "enabled: true," +
                "mode: 'index'," +
                "intersect: false," +
                "}," +
                "scales: " +
                "{" +
                "yAxes: [{" +
                "gridLines: " +
                "{" +
                "borderDash: [2]," +
                "borderDashOffset: [2]," +
                "color: '#dee2e6'," +
                "zeroLineColor: '#dee2e6'," +
                "zeroLineWidth: 1," +
                "zeroLineBorderDash: [2]," +
                "drawBorder: false," +
                "}," +
                "ticks: " +
                "{" +
                "suggestedMin: 0," +
                "suggestedMax: 10," +
                "beginAtZero: true," +
                "padding: 10," +
                "fontSize: 11," +
                "fontColor: '#adb5bd'," +
                "lineHeight: 3," +
                "fontStyle: 'normal'," +
                "fontFamily: 'Open Sans'," +
                "}," +
                "},]," +
                "xAxes: [{" +
                "gridLines: " +
                "{" +
                "zeroLineColor: 'rgba(0,0,0,0)'," +
                "display: false," +
                "}," +
                "ticks: " +
                "{" +
                "padding: 10," +
                "fontSize: 11," +
                "fontColor: '#adb5bd'," +
                "lineHeight: 3," +
                "fontStyle: 'normal'," +
                "fontFamily: 'Open Sans'," +
                "}," +
                "},]," +
                "}," +
                "}," +
                "});" +
                "</script>";


            _rd.LinechartTitle = "Submission overview";
            _rd.LineDuration = "Duration for the Week of ";
            _rd.RecentRecuitmentTitle = "Recent recruitment";


            //     strquery = @"select job.jobcode,job.JobTitle,job.Jobimage,Duration,empl.EmpTypeName,cli.ClientCompanyName,count(*) Candidates,Assigned_To,LocationName from  Job_Master_IND job
            //                     join CandidateDetailsIndia can on job.jobcode=can.JobCode 
            //join ClientMaster cli on cli.ClientID=job.Clientname
            //                     join Location_Master loc on loc.LocationID=job.Location
            //join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType and Assigned_To like '%" + TWE_id + "%' and job.Created_on between '" + fromdate + "' and '" + todate + "'" +
            //                     " group by job.jobcode,job.Jobimage,job.JobTitle,Duration,ClientCompanyName,empl.EmpTypeName,Jobopendate,Assigned_To,LocationName order by Jobopendate desc";


            strquery = @"select top 5 * from (select distinct job.jobcode,job.JobTitle,job.Jobimage,Duration,empl.EmpTypeName,cli.ClientCompanyName,LocationName,job.Created_By,job.Created_Time from  Job_Master_IND job
                            left join CandidateJobIndia canjob on canjob.Jobcode=job.Jobcode	
                            left join CandidateDetailsIndia can on canjob.CandidateId = can.candidateid
							join ClientMaster cli on cli.ClientID=job.Clientname
                            join Location_Master loc on loc.LocationID=job.Location
							join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType 
							where Assigned_To like '%" + TWE_id + "%' and " +
                            "job.Created_on between '" + fromdate + "' and '" + todate + "' and Jobstatus='10200'" +
                            " )tb1 order by Created_By desc, Created_Time desc";

            _read = _sql.doRead(strquery);
            while (_read.Read())
            {
                recruitmenttable _rt = new recruitmenttable();
                _rt.RecruitmentId = _read[0].ToString();
                _rt.JobName = _read[1].ToString();
                _rt.JobMediaPath = _read[2].ToString();
                _rt.JobDuration = _read[3].ToString();
                _rt.JobType = _read[4].ToString();
                _rt.JobClient = _read[5].ToString();
                _rt.JobState = _read[6].ToString();
                _lstrt.Add(_rt);
            }
            _read.Close();

            List<recruitmenttable> _lstRecruitTable = new List<recruitmenttable>();

            foreach (var item in _lstrt)
            {
                if (!_lstRecruitTable.Where(x => x.RecruitmentId == item.RecruitmentId).Any())
                {
                    _lstRecruitTable.Add(item);
                }

            }

            _lstrt = _lstRecruitTable;


            strquery = @"select job.Jobcode,count(can.candidateid) candidates from Job_Master_IND job
                        left join CandidateJobIndia canjob on canjob.Jobcode=job.Jobcode	
                        left join CandidateDetailsIndia can on canjob.CandidateId = can.candidateid
                        group by job.Jobcode,Assigned_To,job.Created_on,Jobopendate 
                        having Assigned_To like '%" + TWE_id + "%' and " +
                        "job.Created_on between '" + fromdate + "' and '" + todate + "'" +
                        " order by Jobopendate desc";

            _read = _sql.doRead(strquery);

            while (_read.Read())
            {

                for (int i = 0; i < _lstrt.Count; i++)
                {
                    if (_lstrt[i].RecruitmentId == _read[0].ToString())
                    {
                        _lstrt[i].JobSubmission = _read[1].ToString();
                    }


                }

            }
            _read.Close();

            strquery = @"select count(*) Total_jobs from Job_Master_IND 
                        where Assigned_To like '%" + TWE_id + "%' and " +
                       "Created_on between '" + fromdate + "' and '" + todate + "'" +
                       " and Jobstatus='10200'";

            _read = _sql.doRead(strquery);

            

            while (_read.Read())
            {
                _rd.RecentRecuitmentCount= _read[0].ToString() + " Active Jobs for the duration of";
            }

            //_rd.RecentRecuitmentCount = _lstrt.Count.ToString() + " Active Jobs for the duration of";
            _rd.RecuitmentTable = _lstrt;

            _read.Close();

            strquery = @"select 
                        (
                        select cast(candcount as float)/cast(TargetValue as float) from
                        (
                        select count(*) candcount from CandidateDetailsIndia can
                         where can.Created_By like '%" + TWE_id + "%' and " +
                        "can.Created_on between '" + fromdate + "' and '" + todate + "' ) tb1," +
                        "(select TargetValue from TargetMaster_IND where TargetType='Candidates') tb2" +
                        ") candcount,(" +
                        "select cast(candcount as float)/cast(TargetValue as float) from" +
                        "(" +
                        "select count(*) candcount from CandidateDetailsIndia can" +
                         " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                         " join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
                        " where can.Created_By like '%" + TWE_id + "%' and Cand_Status in ('103')" +
                        " and can.Created_on between '" + fromdate + "' and '" + todate + "' ) tb5, " +
                        "(select TargetValue from TargetMaster_IND where TargetType='Submission to TL') tb6" +
                        ")subcount," +
                            "(select cast(candcount as float) / cast(TargetValue as float) from" +
                            "(" +
                            "select count(*) candcount from CandidateDetailsIndia can" +
                             " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                             " join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
                            " where can.Created_By like '%" + TWE_id + "%' and Cand_Status > 103" +
                            "and can.Created_on between '" + fromdate + "' and '" + todate + "') tb7," +
                            "(select TargetValue from TargetMaster_IND where TargetType = 'TL Approval') tb8" +
                            ")TLAppcount," +
                            "(" +
                            "select cast(candcount as float) / cast(TargetValue as float) from" +
                            "(" +
                            "select count(*) candcount from CandidateDetailsIndia can" +
                            " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                            " join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
                            " where can.Created_By like '%" + TWE_id + "%' and Cand_Status >= 105" +
                            "and can.Created_on between '" + fromdate + "' and '" + todate + "') tb7," +
                            "(select TargetValue from TargetMaster_IND where TargetType = 'BP Approval') tb8" +
                            ")BPAppcount," +
                            "(" +
                            "select cast(candcount as float) / cast(TargetValue as float) from" +
                            "(" +
                            "select count(*) candcount from CandidateDetailsIndia can" +
                            " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                            " join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
                            " where can.Created_By like '%" + TWE_id + "%' and Cand_Status >= 107" +
                            "and can.Created_on between '" + fromdate + "' and '" + todate + "') tb7," +
                            "(select TargetValue from TargetMaster_IND where TargetType = 'EC Approval') tb8" +
                            ")ECAppcount";


            _read = _sql.doRead(strquery);
            while (_read.Read())
            {
                _rd.OverViewPercentage = Math.Round(((Convert.ToDouble(_read[0]) + Convert.ToDouble(_read[1]) + Convert.ToDouble(_read[2]) + Convert.ToDouble(_read[3]) + Convert.ToDouble(_read[4])) / 5), 2).ToString() + " % for the duration of ";

            }
            _read.Close();


            _rd.OverviewTitle = "Performance overview";
            //_rd.OverViewPercentage = "4% this month";

            strquery = @"select 'End Client-Closure't1,count(distinct candidateemailid) Onboarded from CandidateDetailsIndia can join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId
                        join Job_Master_IND job on job.Jobcode=canjob.Jobcode where Cand_Status in ('109') and can.Created_By='" + TWE_id + "' and can.Created_On between '" + fromdate + "' and '" + todate + "'" +
                        " union " +
                        " select 'Business Partner Selected't2,count(distinct candidateemailid) BPSelected from CandidateDetailsIndia can join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                        " join Job_Master_IND job on job.Jobcode = canjob.Jobcode where Cand_Status in ('105') and can.Created_By='" + TWE_id + "' and can.Created_On between '" + fromdate + "' and '" + todate + "'" +
                        " union " +
                        " select 'Team Lead Approved't3,count(distinct candidateemailid) TLApproved from CandidateDetailsIndia can join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                        " join Job_Master_IND job on job.Jobcode = canjob.Jobcode where Cand_Status in ('105','106','107','108') and can.Created_By='" + TWE_id + "' and can.Created_On between '" + fromdate + "' and '" + todate + "'" +
                        " union " +
                        " select 'Submitted't4,count(distinct candidateemailid) SubmittedTL from CandidateDetailsIndia can join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                        " join Job_Master_IND job on job.Jobcode = canjob.Jobcode where Cand_Status in ('103') and can.Created_By='" + TWE_id + "' and can.Created_On between '" + fromdate + "' and '" + todate + "'" +
                        " union " +
                        " select 'Vendors't5,count(*) Vendors from EmployerDetailsIndia where Status='1'  and Created_By like '" + TWE_id + "' and Created_On between '" + fromdate + "' and '" + todate + "'" +
                        " union " +
                        " select 'Candidates't6,count(distinct candidateemailid) SubmitCand from CandidateDetailsIndia can join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                        " left join Job_Master_IND job on job.Jobcode = canjob.Jobcode where Cand_Status in ('101','102','103') and can.Created_By='" + TWE_id + "'and can.Created_On between '" + fromdate + "' and '" + todate + "'" +
                        " --union " +
                        " --select ''t7,count(*) BackupCand from BackupCandidateDetails where Created_By='" + TWE_id + "' and Created_On between '" + fromdate + "' and '" + todate + "'";
            _read = _sql.doRead(strquery);
            while (_read.Read())
            {
                performanceoverview _pov = new performanceoverview();
                _pov.PerformanceName = _read[0].ToString();
                _pov.PerformanceCount = _read[1].ToString();
                _lstpov.Add(_pov);
            }
            _read.Close();
            _rd.PerformaceOverView = _lstpov;

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
                _json.data = _rd;
            }

            return _json;

        }
        public jsonArray getSkilldetails()
        {
            int status = 1;
            listarray _db = new listarray();

            _db.lstSkill = new List<dropDownTemplate>();

            _db.lstType = new List<dropDownTemplate>();

            _db.lstEmploymentType = new List<dropDownTemplate>();
            _db.lstPriority = new List<dropDownTemplate>();
            _db.lstrateType = new List<dropDownTemplate>();

            string strquery = @"SELECT [SkillName],[SkillID] FROM [Skill_Master] where Status=1";

            SqlDataReader _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                _db.lstSkill.Add(new dropDownTemplate
                {
                    ID = _read["SkillID"].ToString(),
                    Name = _read["SkillName"].ToString()
                });
            }

            _read.Close();


            strquery = @"SELECT [TypeName],[TypeID] FROM [Type_Master] where Status=1";

            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                _db.lstType.Add(new dropDownTemplate
                {
                    ID = _read["TypeID"].ToString(),
                    Name = _read["TypeName"].ToString()
                });
            }
            _read.Close();

            strquery = @"SELECT [VisaName],[VisaID] FROM [Visa_Master] where Status=1";

            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                _db.lstEmploymentType.Add(new dropDownTemplate
                {
                    ID = _read["VisaID"].ToString(),
                    Name = _read["VisaName"].ToString()
                });
            }
            _read.Close();

            strquery = @"SELECT [SpecilaizationName],[SpecilaizationID] FROM [Specialization_Master] where Status=1";

            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                _db.lstPriority.Add(new dropDownTemplate
                {
                    ID = _read["SpecilaizationID"].ToString(),
                    Name = _read["SpecilaizationName"].ToString()
                });
            }
            _read.Close();

            strquery = @"SELECT [TypeName],[TypeID] FROM [RateType_Master] where Status=1";

            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                _db.lstrateType.Add(new dropDownTemplate
                {
                    ID = _read["TypeID"].ToString(),
                    Name = _read["TypeName"].ToString()
                });
            }
            _read.Close();



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
                _json.data = _db;
            }

            return _json;
        }
        public jsonArray insertSkillInfo(string skillname)
        {
            int status = 1;
            string skillID = "";
            string query = "";

            query = @"select SkillID from [Skill_Master] where SkillName like '" + skillname + "'";
            SqlDataReader _read = _sql.doRead(query);
            while (_read.Read())
            {
                skillID = _read[0].ToString() + "," + "Old";

            }
            _read.Close();

            if (skillID == "")
            {

                query = @"INSERT INTO [Skill_Master] (SkillName,Status) VALUES('" + skillname + "',1)";


                _sql.doInsert(query);

                query = @"select SkillID from [Skill_Master] where SkillName like '" + skillname + "'";

                _read = _sql.doRead(query);
                while (_read.Read())
                {
                    skillID = _read[0].ToString();
                }
                skillID += "," + "New";
                _read.Close();
            }




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
                _json.data = skillID;
            }

            return _json;

        }
        public jsonArray getCandidateoverviewDetails(string fromdate, string todate, string TWE_Id, string filter)
        {
            int status = 1;
            string query = "";
            candidateOverview objCand = new candidateOverview();


            objCand._lstTile = new List<tiles>();
            objCand._lstcandilist = new List<candidatelist>();
            objCand._lstJob = new List<JobcodeList>();

            query = "select * from" +
                    "(" +
                    "select count(*) pipeline_jobs from candidateDetails can" +
                    " join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                    " join Job_Master_USA job on job.Jobcode = canjob.Jobcode" +
                    " where can.Created_By like '%" + TWE_Id + "%' and " +
                    " can.Created_On between '" + fromdate + "' and '" + todate + "'" +
                    " and Cand_Status = '102'" +
                    ") tb1," +
                    "(" +
                    "select count(*) interview_jobs from candidateDetails can" +
                    " join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                    " join Job_Master_USA job on job.Jobcode = canjob.Jobcode" +
                    " where can.Created_By like '%" + TWE_Id + "%' and" +
                    " can.Created_On between '" + fromdate + "' and '" + todate + "'" +
                    " and Cand_Status in ('110', '111')" +
                    ") tb2," +
                    "(" +
                    "select Candidate_adding from Userprofilecreation where TWE_ID='" + TWE_Id + "'" +
                    ")tb3," +
                    "(" +
                    "select count(*) candcount from candidateDetails can" +
                    " join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                    " left join Job_Master_USA job on job.Jobcode = canjob.Jobcode" +
                    " where can.Created_By like '%" + TWE_Id + "%' and" +
                    " can.Created_On between '" + fromdate + "' and '" + todate + "'" +
                    " and Cand_Status in ('101', '102', '103')" +
                    ")tb4," +
                    "(" +
                    "select Submittion from Userprofilecreation where TWE_ID='" + TWE_Id + "'" +
                    ")tb5," +
                    "(" +
                    "select count(*) TLcandcount from candidateDetails can" +
                    " join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                    " join Job_Master_USA job on job.Jobcode = canjob.Jobcode" +
                    " where can.Created_By like '%" + TWE_Id + "%' and" +
                    " can.Created_On between '" + fromdate + "' and '" + todate + "'" +
                    " and Cand_Status in ('103')" +
                    ")tb6";


            SqlDataReader _read = _sql.doRead(query);
            while (_read.Read())
            {
                tiles objTile1 = new tiles();
                objTile1.TileTitle = "Pipeline";
                objTile1.TotalCount = _read[0].ToString();
                objCand._lstTile.Add(objTile1);

                tiles objTile2 = new tiles();
                objTile2.TileTitle = "Interview";
                objTile2.TotalCount = _read[1].ToString();
                objCand._lstTile.Add(objTile2);

                tiles objTile3 = new tiles();
                objTile3.TileTitle = "Add Candidates";
                objTile3.TotalCount = _read[2].ToString();
                objCand._lstTile.Add(objTile3);

                tiles objTile4 = new tiles();
                objTile4.TileTitle = "Candidates Added";

                if (Convert.ToInt32(_read[2]) <= Convert.ToInt32(_read[3]))
                {
                    objTile4.TotalCount = (Convert.ToInt32(_read[3]) - Convert.ToInt32(_read[2])).ToString();
                }

                else
                {
                    objTile4.TotalCount = (Convert.ToInt32(_read[2]) - Convert.ToInt32(_read[3])).ToString();
                }
                
                objCand._lstTile.Add(objTile4);

                tiles objTile5 = new tiles();
                objTile5.TileTitle = "SB Candidates";
                objTile5.TotalCount = _read[4].ToString();
                objCand._lstTile.Add(objTile5);

                tiles objTile6 = new tiles();
                objTile6.TileTitle = "SB Candidates Added";
                objTile6.TotalCount = _read[5].ToString();
                objCand._lstTile.Add(objTile6);

                tiles objTile41 = new tiles();
                objTile41.TileTitle = " more candidates to achieve";
                if (Convert.ToInt32(_read[2]) <= Convert.ToInt32(_read[3]))
                {
                    objTile41.TileTitle = " more candidates were achieved";
                }
                else
                {
                    objTile41.TileTitle = " more candidates to achieve";                    
                }
                objCand._lstTile.Add(objTile41);
            }

            _read.Close();

            if (filter == "All")
            {
                query = @"select can.candidateid,candidatename,candidateemailid,candidatemobileno,ratePerHr,
                        typ.TypeName,ContactPerson,MailId,CandidateStatusName Cand_Status,
                        up.UP_firstName+' '+up.UP_lastName Empname,
                        convert(varchar,can.Created_On,106) CreatedOn,CreatedTime,linkedinURL,job.Jobcode,job.JobTitle
                        from CandidateDetails can
                        join EmployerDetails emp on can.employerid=emp.employerid
                        join EmployerContactPerson empc on empc.VendorID=emp.employerid
                        join CandidateJob canjob on can.candidateid=canjob.CandidateId
                        join CandidateStatus_Master sta on sta.CandidateStatusID=canjob.Cand_Status
                        join Userprofile up on can.Created_By=up.TWE_ID
                        join Type_Master typ on typ.TypeID=can.type
                        left join Job_Master_USA job on job.Jobcode=canjob.Jobcode
                        where can.Created_By like '%" + TWE_Id + "%' and " +
                        "can.Created_On between '" + fromdate + "' and '" + todate + "' ";
            }

            else if (filter == "Pipeline")
            {
                query = @"select can.candidateid,candidatename,candidateemailid,candidatemobileno,ratePerHr,
                        typ.TypeName,ContactPerson,MailId,CandidateStatusName Cand_Status,
                        up.UP_firstName+' '+up.UP_lastName Empname,
                        convert(varchar,can.Created_On,106) CreatedOn,CreatedTime,linkedinURL,job.Jobcode,job.JobTitle
                        from CandidateDetails can
                        join EmployerDetails emp on can.employerid=emp.employerid
                        join EmployerContactPerson empc on empc.VendorID=emp.employerid
                        join CandidateJob canjob on can.candidateid=canjob.CandidateId
                        join CandidateStatus_Master sta on sta.CandidateStatusID=canjob.Cand_Status
                        join Userprofile up on can.Created_By=up.TWE_ID
                        join Type_Master typ on typ.TypeID=can.type
                        join Job_Master_USA job on job.Jobcode=canjob.Jobcode
                        where can.Created_By like '%" + TWE_Id + "%' and " +
                    "can.Created_On between '" + fromdate + "' and '" + todate + "' and Cand_Status='102'";
            }

            else if (filter == "Interview")
            {
                query = @"select can.candidateid,candidatename,candidateemailid,candidatemobileno,ratePerHr,
                        typ.TypeName,ContactPerson,MailId,CandidateStatusName Cand_Status,
                        up.UP_firstName+' '+up.UP_lastName Empname,
                        convert(varchar,can.Created_On,106) CreatedOn,CreatedTime,linkedinURL,job.Jobcode,job.JobTitle
                        from CandidateDetails can
                        join EmployerDetails emp on can.employerid=emp.employerid
                        join EmployerContactPerson empc on empc.VendorID=emp.employerid
                        join CandidateJob canjob on can.candidateid=canjob.CandidateId
                        join CandidateStatus_Master sta on sta.CandidateStatusID=canjob.Cand_Status
                        join Userprofile up on can.Created_By=up.TWE_ID
                        join Type_Master typ on typ.TypeID=can.type
                        join Job_Master_USA job on job.Jobcode=canjob.Jobcode
                        where can.Created_By like '%" + TWE_Id + "%' and " +
                        "can.Created_On between '" + fromdate + "' and '" + todate + "' and Cand_Status in ('110','111')";
            }


            _read = _sql.doRead(query);
            while (_read.Read())
            {
                candidatelist candilst = new candidatelist();
                candilst.candidateid = _read[0].ToString();
                candilst.candidatemediapath = "";
                candilst.candidatename = _read[1].ToString();
                candilst.candidateemailid = _read[2].ToString();
                candilst.candidatemobno = _read[3].ToString();
                candilst.ratePerHr = _read[4].ToString();
                candilst.type = _read[5].ToString();
                candilst.vendorname = _read[6].ToString();
                candilst.vendoremailid = _read[7].ToString();
                candilst.candidatestatus = _read[8].ToString();
                candilst.submittedby = _read[9].ToString();
                candilst.submitteddate = _read[10].ToString();
                candilst.submittedtime = _read[11].ToString();
                candilst.linkedinURL = _read[12].ToString();
                candilst.jobcode = _read[13].ToString();
                candilst.jobTitle = _read[14].ToString();
                objCand._lstcandilist.Add(candilst);
            }
            _read.Close();

            query = @"select Jobcode,JobTitle,Duration,EmpTypeName,City,State,Country from Job_Master_USA job
                        join EmploymentType_Master empl on job.EmplType=empl.EmpTypeID
                        where Assigned_To like '%" + TWE_Id + "%'  and Jobstatus='10200' ";

            _read = _sql.doRead(query);
            while (_read.Read())
            {
                JobcodeList objJob = new JobcodeList();
                objJob.Jobcode = _read[0].ToString();
                objJob.JobTitle = _read[1].ToString();
                objJob.JobDuration = _read[2].ToString();
                objJob.JobType = _read[3].ToString();
                objJob.JobCity = _read[4].ToString();
                objJob.JobState = _read[5].ToString();
                objJob.JobCountry = _read[6].ToString();

                objCand._lstJob.Add(objJob);
            }

            _read.Close();


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
                _json.data = objCand;
            }

            return _json;
        }



        public jsonArray getCandidateoverviewListDetails(string fromdate, string todate, string TWE_Id, string filter)
        {
            int status = 1;
            string query = "";
            candidateOverview objCand = new candidateOverview();

            objCand._lstTile = new List<tiles>();
            objCand._lstcandilist = new List<candidatelist>();

            string candidateCreation = "";
            string candidateEdit = "";
            string candidateView = "";
            string strquery = @"SELECT [candidateCreation],[candidateEdit],[candidateView] FROM [UserAccessPower] where userId='" + TWE_Id + "' ";
            SqlDataReader _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                candidateCreation = _read[0].ToString();
                candidateEdit = _read[1].ToString();
                candidateView = _read[2].ToString();

            }
            _read.Close();

            if (candidateEdit == "2" || candidateView == "2")
            {
                query = "select * from" +
                        "(" +
                        "select count(distinct can.CandidateId) totalcand from candidateDetails can" +
                        " join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                        //" and can.Created_On between '" + fromdate + "' and '" + todate + "'" +
                        ") t1," +
                        "(" +
                        "select count(*) SBcand from candidateDetails can" +
                        " join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                        " join Job_Master_USA job on job.Jobcode = canjob.Jobcode" +
                        //" and can.Created_On between '" + fromdate + "' and '" + todate + "'" +
                        " and Cand_Status in ('103')" +
                        ") tb2," +
                        "(" +
                        "select count(*) BPcand from candidateDetails can" +
                        " join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                        " join Job_Master_USA job on job.Jobcode = canjob.Jobcode" +
                        //" and can.Created_On between '" + fromdate + "' and '" + todate + "'" +
                        " and Cand_Status in ('105')" +
                        ")tb3," +
                        "(" +
                        "select count(*) ECcand from candidateDetails can" +
                        " join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                        " join Job_Master_USA job on job.Jobcode = canjob.Jobcode" +
                        //" and can.Created_On between '" + fromdate + "' and '" + todate + "'" +
                        " and Cand_Status in ('107')" +
                        ")tb4," +
                        "(" +
                        "select count(*) candDetails from CandidateDetails" +
                        ")tb5," +
                        "(" +
                        "select count(*) jobDetails from Job_Master_USA where Jobcode!='TWEUSA0000'" +
                        ")tb6," +
                        "(select (sum(convert(float,RecruiterRating))/sum(5))*100 Positiverating from CandidateDetails can" +
                        " join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                        " join Job_Master_USA job on job.Jobcode = canjob.Jobcode" +
                        "  where RecruiterRating>3)tb7," +
                        "(select (sum(convert(float,RecruiterRating))/sum(5))*100 Negativerating from CandidateDetails can " +
                        " join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                        " join Job_Master_USA job on job.Jobcode = canjob.Jobcode" +
                        " where RecruiterRating<=3)tb8";
            }

            else
            {

                query = "select * from" +
                        "(" +
                        "select count(distinct can.CandidateId) totalcand from candidateDetails can" +
                        " join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                        " where can.Created_By like '%" + TWE_Id + "%' " +
                        //" and can.Created_On between '" + fromdate + "' and '" + todate + "'" +
                        ") t1," +
                        "(" +
                        "select count(*) SBcand from candidateDetails can" +
                        " join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                        " join Job_Master_USA job on job.Jobcode = canjob.Jobcode" +
                        " where can.Created_By like '%" + TWE_Id + "%' " +
                        //" and can.Created_On between '" + fromdate + "' and '" + todate + "'" +
                        " and Cand_Status in ('103')" +
                        ") tb2," +
                        "(" +
                        "select count(*) BPcand from candidateDetails can" +
                        " join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                        " join Job_Master_USA job on job.Jobcode = canjob.Jobcode" +
                        " where can.Created_By like '%" + TWE_Id + "%' " +
                        //" and can.Created_On between '" + fromdate + "' and '" + todate + "'" +
                        " and Cand_Status in ('105')" +
                        ")tb3," +
                        "(" +
                        "select count(*) ECcand from candidateDetails can" +
                        " join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                        " join Job_Master_USA job on job.Jobcode = canjob.Jobcode" +
                        " where can.Created_By like '%" + TWE_Id + "%' " +
                        //" and can.Created_On between '" + fromdate + "' and '" + todate + "'" +
                        " and Cand_Status in ('107')" +
                        ")tb4," +
                        "(" +
                        "select count(*) candDetails from CandidateDetails" +
                        ")tb5," +
                        "(" +
                        "select count(*) jobDetails from Job_Master_USA where Jobcode!='TWEUSA0000'" +
                        ")tb6," +
                        "(select (sum(convert(float,RecruiterRating))/sum(5))*100 Positiverating from CandidateDetails can" +
                        " join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                        " join Job_Master_USA job on job.Jobcode = canjob.Jobcode" +
                        "  where RecruiterRating>3)tb7," +
                        "(select (sum(convert(float,RecruiterRating))/sum(5))*100 Negativerating from CandidateDetails can " +
                        " join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                        " join Job_Master_USA job on job.Jobcode = canjob.Jobcode" +
                        " where RecruiterRating<=3)tb8";
            }


            _read = _sql.doRead(query);
            while (_read.Read())
            {
                tiles objTile1 = new tiles();
                objTile1.TileTitle = "Total Candidates";
                objTile1.TotalCount = _read[0].ToString();
                objCand._lstTile.Add(objTile1);

                tiles objTile2 = new tiles();
                objTile2.TileTitle = "Submitted to TL";
                objTile2.TotalCount = _read[1].ToString();
                objCand._lstTile.Add(objTile2);

                tiles objTile3 = new tiles();
                objTile3.TileTitle = "Submitted to BP";
                objTile3.TotalCount = _read[2].ToString();
                objCand._lstTile.Add(objTile3);

                tiles objTile4 = new tiles();
                objTile4.TileTitle = "Submitted to EC";
                objTile4.TotalCount = _read[3].ToString();
                objCand._lstTile.Add(objTile4);

                tiles objTile5 = new tiles();
                objTile5.TileTitle = "Candidate Count";
                objTile5.TotalCount = _read[4].ToString();
                objCand._lstTile.Add(objTile5);

                tiles objTile6 = new tiles();
                objTile6.TileTitle = "Job Count";
                objTile6.TotalCount = _read[5].ToString();
                objCand._lstTile.Add(objTile6);

                tiles objTile7 = new tiles();
                objTile7.TileTitle = "Positive Rating";
                objTile7.TotalCount = Math.Round(Convert.ToDouble(_read[6])).ToString();
                objCand._lstTile.Add(objTile7);

                tiles objTile8 = new tiles();
                objTile8.TileTitle = "Negative Rating";
                objTile8.TotalCount = Math.Round(Convert.ToDouble(_read[7])).ToString();
                objCand._lstTile.Add(objTile8);
            }

            _read.Close();

            if (filter == "All")
            {
                if (candidateEdit == "2" || candidateView == "2")
                {
                    query = @"select distinct can.candidateid,candidatename,candidateemailid,candidatemobileno,ratePerHr,
                        typ.TypeName,ContactPerson,MailId,sta.CandidateStatusName Cand_Status,
                        up.UP_firstName+' '+up.UP_lastName Empname,
                        convert(varchar,can.Created_On,106) CreatedOn,CreatedTime,linkedinURL,job.Jobcode,job.JobTitle
                        from CandidateDetails can
                        join EmployerDetails emp on can.employerid=emp.employerid
                        join EmployerContactPerson empc on empc.VendorID=emp.employerid
                        join Userprofile up on can.Created_By=up.TWE_ID
                        join CandidateJob canjob on can.candidateid=canjob.CandidateId
                        join CandidateStatus_Master sta on sta.CandidateStatusID=canjob.Cand_Status
                        left join Type_Master typ on typ.TypeID=can.type 
                        left join Job_Master_USA job on job.Jobcode=canjob.Jobcode";
                    //"and can.Created_On between '" + fromdate + "' and '" + todate + "' ";
                }
                else
                {
                    query = @"select distinct can.candidateid,candidatename,candidateemailid,candidatemobileno,ratePerHr,
                        typ.TypeName,ContactPerson,MailId,sta.CandidateStatusName Cand_Status,
                        up.UP_firstName+' '+up.UP_lastName Empname,
                        convert(varchar,can.Created_On,106) CreatedOn,CreatedTime,linkedinURL,job.Jobcode,job.JobTitle
                        from CandidateDetails can
                        join EmployerDetails emp on can.employerid=emp.employerid
                        join EmployerContactPerson empc on empc.VendorID=emp.employerid
                        join Userprofile up on can.Created_By=up.TWE_ID
                        join CandidateJob canjob on can.candidateid=canjob.CandidateId
                        join CandidateStatus_Master sta on sta.CandidateStatusID=canjob.Cand_Status
                        left join Type_Master typ on typ.TypeID=can.type 
                        left join Job_Master_USA job on job.Jobcode=canjob.Jobcode
                        where can.Created_By like '%" + TWE_Id + "%'";
                    //"and can.Created_On between '" + fromdate + "' and '" + todate + "' ";
                }
            }

            else if (filter == "Follow")
            {
                if (candidateEdit == "2" || candidateView == "2")
                {
                    query = @"select can.candidateid,candidatename,candidateemailid,candidatemobileno,ratePerHr,
                        typ.TypeName,ContactPerson,MailId,sta.CandidateStatusName Cand_Status,
                        up.UP_firstName+' '+up.UP_lastName Empname,
                        convert(varchar,can.Created_On,106) CreatedOn,CreatedTime,linkedinURL,job.Jobcode,job.JobTitle
                        from CandidateDetails can
                        join EmployerDetails emp on can.employerid=emp.employerid
                        join EmployerContactPerson empc on empc.VendorID=emp.employerid
                        join Userprofile up on can.Created_By=up.TWE_ID
                        join CandidateJob canjob on can.candidateid=canjob.CandidateId
                        join CandidateStatus_Master sta on sta.CandidateStatusID=canjob.Cand_Status
                        join Job_Master_USA job on job.Jobcode=canjob.jobcode
                        join Type_Master typ on typ.TypeID=can.type 
                        where Cand_Status in ('103','105','107','110','111')";
                }
                else
                {
                    query = @"select can.candidateid,candidatename,candidateemailid,candidatemobileno,ratePerHr,
                        typ.TypeName,ContactPerson,MailId,sta.CandidateStatusName Cand_Status,
                        up.UP_firstName+' '+up.UP_lastName Empname,
                        convert(varchar,can.Created_On,106) CreatedOn,CreatedTime,linkedinURL,job.Jobcode,job.JobTitle
                        from CandidateDetails can
                        join EmployerDetails emp on can.employerid=emp.employerid
                        join EmployerContactPerson empc on empc.VendorID=emp.employerid
                        join Userprofile up on can.Created_By=up.TWE_ID
                        join CandidateJob canjob on can.candidateid=canjob.CandidateId
                        join CandidateStatus_Master sta on sta.CandidateStatusID=canjob.Cand_Status
                        join Job_Master_USA job on job.Jobcode=canjob.jobcode
                        join Type_Master typ on typ.TypeID=can.type 
                        where can.Created_By like '%" + TWE_Id + "%' " +
                        //"and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                        "and Cand_Status in ('103','105','107','110','111')";
                }
            }

            else if (filter == "Draft")
            {
                if (candidateEdit == "2" || candidateView == "2")
                {
                    query = @"select distinct can.candidateid,candidatename,candidateemailid,candidatemobileno,ratePerHr,
                        typ.TypeName,ContactPerson,MailId,sta.CandidateStatusName Cand_Status,
                        up.UP_firstName+' '+up.UP_lastName Empname,
                        convert(varchar,can.Created_On,106) CreatedOn,CreatedTime,linkedinURL,job.Jobcode,job.JobTitle
                        from CandidateDetails can
                        join EmployerDetails emp on can.employerid=emp.employerid
                        join EmployerContactPerson empc on empc.VendorID=emp.employerid
                        join Userprofile up on can.Created_By=up.TWE_ID
                        join CandidateJob canjob on can.candidateid=canjob.CandidateId
                        join CandidateStatus_Master sta on sta.CandidateStatusID=canjob.Cand_Status
                        join Type_Master typ on typ.TypeID=can.type
                        left join Job_Master_USA job on job.Jobcode=canjob.Jobcode
                        where Cand_Status in ('101')";
                }
                else
                {
                    query = @"select distinct can.candidateid,candidatename,candidateemailid,candidatemobileno,ratePerHr,
                        typ.TypeName,ContactPerson,MailId,sta.CandidateStatusName Cand_Status,
                        up.UP_firstName+' '+up.UP_lastName Empname,
                        convert(varchar,can.Created_On,106) CreatedOn,CreatedTime,linkedinURL,job.Jobcode,job.JobTitle
                        from CandidateDetails can
                        join EmployerDetails emp on can.employerid=emp.employerid
                        join EmployerContactPerson empc on empc.VendorID=emp.employerid
                        join Userprofile up on can.Created_By=up.TWE_ID
                        join CandidateJob canjob on can.candidateid=canjob.CandidateId
                        join CandidateStatus_Master sta on sta.CandidateStatusID=canjob.Cand_Status
                        join Type_Master typ on typ.TypeID=can.type 
                        left join Job_Master_USA job on job.Jobcode=canjob.Jobcode
                        where can.Created_By like '%" + TWE_Id + "%' " +
                        "and Cand_Status in ('101')";
                }
            }

            else if (filter == "TLSubmitted")
            {
                if (candidateEdit == "2" || candidateView == "2")
                {
                    query = @"select can.candidateid,candidatename,candidateemailid,candidatemobileno,ratePerHr,
                        typ.TypeName,ContactPerson,MailId,sta.CandidateStatusName Cand_Status,
                        up.UP_firstName+' '+up.UP_lastName Empname,
                        convert(varchar,can.Created_On,106) CreatedOn,CreatedTime,linkedinURL,job.Jobcode,job.JobTitle
                        from CandidateDetails can
                        join EmployerDetails emp on can.employerid=emp.employerid
                        join EmployerContactPerson empc on empc.VendorID=emp.employerid
                        join Userprofile up on can.Created_By=up.TWE_ID
                        join CandidateJob canjob on can.candidateid=canjob.CandidateId
                        join CandidateStatus_Master sta on sta.CandidateStatusID=canjob.Cand_Status
                        join Type_Master typ on typ.TypeID=can.type 
                        join Job_Master_USA job on job.Jobcode=canjob.Jobcode" +
                        " and Cand_Status in ('103')";
                }
                else
                {
                    query = @"select can.candidateid,candidatename,candidateemailid,candidatemobileno,ratePerHr,
                        typ.TypeName,ContactPerson,MailId,sta.CandidateStatusName Cand_Status,
                        up.UP_firstName+' '+up.UP_lastName Empname,
                        convert(varchar,can.Created_On,106) CreatedOn,CreatedTime,linkedinURL,job.Jobcode,job.JobTitle
                        from CandidateDetails can
                        join EmployerDetails emp on can.employerid=emp.employerid
                        join EmployerContactPerson empc on empc.VendorID=emp.employerid
                        join Userprofile up on can.Created_By=up.TWE_ID
                        join CandidateJob canjob on can.candidateid=canjob.CandidateId
                        join CandidateStatus_Master sta on sta.CandidateStatusID=canjob.Cand_Status
                        join Type_Master typ on typ.TypeID=can.type 
                        join Job_Master_USA job on job.Jobcode=canjob.Jobcode
                        where can.Created_By like '%" + TWE_Id + "%' " +
                        //"and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                        "and Cand_Status in ('103')";
                }
            }

            else if (filter == "BPSubmitted")
            {
                if (candidateEdit == "2" || candidateView == "2")
                {
                    query = @"select can.candidateid,candidatename,candidateemailid,candidatemobileno,ratePerHr,
                        typ.TypeName,ContactPerson,MailId,sta.CandidateStatusName Cand_Status,
                        up.UP_firstName+' '+up.UP_lastName Empname,
                        convert(varchar,can.Created_On,106) CreatedOn,CreatedTime,linkedinURL,job.Jobcode,job.JobTitle
                        from CandidateDetails can
                        join EmployerDetails emp on can.employerid=emp.employerid
                        join EmployerContactPerson empc on empc.VendorID=emp.employerid
                        join Userprofile up on can.Created_By=up.TWE_ID
                        join CandidateJob canjob on can.candidateid=canjob.CandidateId
                        join CandidateStatus_Master sta on sta.CandidateStatusID=canjob.Cand_Status
                        join Type_Master typ on typ.TypeID=can.type 
                        join Job_Master_USA job on job.Jobcode=canjob.Jobcode" +
                        " and Cand_Status in ('105')";
                }
                else
                {
                    query = @"select can.candidateid,candidatename,candidateemailid,candidatemobileno,ratePerHr,
                        typ.TypeName,ContactPerson,MailId,sta.CandidateStatusName Cand_Status,
                        up.UP_firstName+' '+up.UP_lastName Empname,
                        convert(varchar,can.Created_On,106) CreatedOn,CreatedTime,linkedinURL,job.Jobcode,job.JobTitle
                        from CandidateDetails can
                        join EmployerDetails emp on can.employerid=emp.employerid
                        join EmployerContactPerson empc on empc.VendorID=emp.employerid
                        join Userprofile up on can.Created_By=up.TWE_ID
                        join CandidateJob canjob on can.candidateid=canjob.CandidateId
                        join CandidateStatus_Master sta on sta.CandidateStatusID=canjob.Cand_Status
                        join Type_Master typ on typ.TypeID=can.type 
                        join Job_Master_USA job on job.Jobcode=canjob.Jobcode
                        where can.Created_By like '%" + TWE_Id + "%' " +
                        //"and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                        "and Cand_Status in ('105')";
                }
            }

            else if (filter == "ECSubmitted")
            {
                if (candidateEdit == "2" || candidateView == "2")
                {
                    query = @"select can.candidateid,candidatename,candidateemailid,candidatemobileno,ratePerHr,
                        typ.TypeName,ContactPerson,MailId,sta.CandidateStatusName Cand_Status,
                        up.UP_firstName+' '+up.UP_lastName Empname,
                        convert(varchar,can.Created_On,106) CreatedOn,CreatedTime,linkedinURL,job.Jobcode,job.JobTitle
                        from CandidateDetails can
                        join EmployerDetails emp on can.employerid=emp.employerid
                        join EmployerContactPerson empc on empc.VendorID=emp.employerid
                        join Userprofile up on can.Created_By=up.TWE_ID
                        join CandidateJob canjob on can.candidateid=canjob.CandidateId
                        join CandidateStatus_Master sta on sta.CandidateStatusID=canjob.Cand_Status
                        join Type_Master typ on typ.TypeID=can.type 
                        join Job_Master_USA job on job.Jobcode=canjob.Jobcode " +
                        "and Cand_Status in ('107')";
                }
                else
                {
                    query = @"select can.candidateid,candidatename,candidateemailid,candidatemobileno,ratePerHr,
                        typ.TypeName,ContactPerson,MailId,sta.CandidateStatusName Cand_Status,
                        up.UP_firstName+' '+up.UP_lastName Empname,
                        convert(varchar,can.Created_On,106) CreatedOn,CreatedTime,linkedinURL,job.Jobcode,job.JobTitle
                        from CandidateDetails can
                        join EmployerDetails emp on can.employerid=emp.employerid
                        join EmployerContactPerson empc on empc.VendorID=emp.employerid
                        join Userprofile up on can.Created_By=up.TWE_ID
                        join CandidateJob canjob on can.candidateid=canjob.CandidateId
                        join CandidateStatus_Master sta on sta.CandidateStatusID=canjob.Cand_Status
                        join Type_Master typ on typ.TypeID=can.type 
                        join Job_Master_USA job on job.Jobcode=canjob.Jobcode
                        where can.Created_By like '%" + TWE_Id + "%' " +
                        //"and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                        "and Cand_Status in ('107')";
                }
            }


            _read = _sql.doRead(query);
            while (_read.Read())
            {
                candidatelist candilst = new candidatelist();
                candilst.candidateid = _read[0].ToString();
                candilst.candidatemediapath = "";
                candilst.candidatename = _read[1].ToString();
                candilst.candidateemailid = _read[2].ToString();
                candilst.candidatemobno = _read[3].ToString();
                candilst.ratePerHr = _read[4].ToString();
                candilst.type = _read[5].ToString();
                candilst.vendorname = _read[6].ToString();
                candilst.vendoremailid = _read[7].ToString();
                candilst.candidatestatus = _read[8].ToString();
                candilst.submittedby = _read[9].ToString();
                candilst.submitteddate = _read[10].ToString();
                candilst.submittedtime = _read[11].ToString();
                candilst.linkedinURL = _read[12].ToString();
                candilst.jobcode = _read[13].ToString();
                candilst.jobTitle = _read[14].ToString();
                //if (filter == "Follow")
                //{
                //    candilst.jobcode = _read[13].ToString();
                //}

                objCand._lstcandilist.Add(candilst);
            }
            _read.Close();

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
                _json.data = objCand;
            }

            return _json;
        }


        public jsonArray getCandidateProfile(string Candidateid, string TWE_Id)
        {
            int status = 1;
            string query = "";
            candidateProfileview _cd = new candidateProfileview();
            _cd.candDetail = new Candidatedetails();
            _cd._lstJob = new List<JobcodeList>();
            _cd._lstMatchJob = new List<JobcodeList>();
            _cd._lstAssignedJob = new List<JobcodeList>();
            _cd._lstFeedback = new List<candidateComments>();
            _cd._lstdrpJob = new List<dropDownTemplate>();


            query = @"select can.candidateid,candidatename,
                            candidatemobileno,candidateemailid,
                            currentLocation,vis.VisaName VisaStatus,linkedinURL,
                            skillsandCertif,empl.employerid,ContactPerson,ContactNo,
                            MailId,employercorporationaname,employerspecialization,
                            Cand_Status,
                            convert(varchar,can.Created_On,106) CreatedOn,can.Created_By,CreatedTime,job.jobcode,employeradditionalinfo,RecruiterRating
                            from CandidateDetails can
                            join EmployerDetails empl on can.employerid=empl.employerid
                            join EmployerContactPerson empc on empc.VendorID=empl.employerid
							join CandidateJob canjob on canjob.CandidateId=can.candidateid
							left join Job_Master_USA job on job.Jobcode=canjob.Jobcode	
                            join Visa_Master vis on vis.VisaID=can.VisaStatus
                            where can.candidateid='" + Candidateid + "'";


            SqlDataReader _read = _sql.doRead(query);

            while (_read.Read())
            {
                _cd.candDetail.candidateid = _read[0].ToString();
                _cd.candDetail.candidatename = _read[1].ToString();
                _cd.candDetail.candidatemobileno = _read[2].ToString();
                _cd.candDetail.candidateemailid = _read[3].ToString();
                _cd.candDetail.currentLocation = _read[4].ToString();
                _cd.candDetail.visastatus = _read[5].ToString();
                _cd.candDetail.linkedinURL = _read[6].ToString();
                _cd.candDetail.skillsandCertif = _read[7].ToString();
                _cd.candDetail.employerid = _read[8].ToString();
                _cd.candDetail.employeename = _read[9].ToString();
                _cd.candDetail.employerContactno = _read[10].ToString();
                _cd.candDetail.employermailid = _read[11].ToString();
                _cd.candDetail.corporationname = _read[12].ToString();
                _cd.candDetail.employerspecialization = _read[13].ToString();
                _cd.candDetail.candStatus = _read[14].ToString();
                _cd.candDetail.createdOn = _read[15].ToString();
                _cd.candDetail.createdBy = _read[16].ToString();
                _cd.candDetail.createdTime = _read[17].ToString();
                _cd.candDetail.jobcode = _read[18].ToString();
                _cd.candDetail.employeradderinformation = _read[19].ToString();
                _cd.candDetail.recruiterrating = _read[20].ToString();
            }

            _read.Close();


            query = @"select Jobcode,JobTitle,Duration from Job_Master_USA where Jobstatus='10200' and Jobcode!='" + _cd.candDetail.jobcode + "'";


            _read = _sql.doRead(query);
            while (_read.Read())
            {
                dropDownTemplate objJob = new dropDownTemplate();
                objJob.ID = _read[0].ToString();
                objJob.Name = _read[1].ToString() + "/" + _read[0].ToString() + "/" + _read[2].ToString();
                _cd._lstdrpJob.Add(objJob);
            }

            _read.Close();


            string[] skillArr = _cd.candDetail.skillsandCertif.Split(',');
            string skillVal = "";

            for (int i = 0; i < skillArr.Length; i++)
            {
                skillVal = skillVal + "'" + skillArr[i] + "',";
            }

            skillVal = skillVal.Substring(0, skillVal.Length - 1);


            query = "select SkillName from Skill_Master where SkillID in (" + skillVal + ")";
            _read = _sql.doRead(query);
            _cd.candDetail.skillsandCertif = "";

            while (_read.Read())
            {
                _cd.candDetail.skillsandCertif += _read[0].ToString() + "|";
            }

            _cd.candDetail.skillsandCertif = _cd.candDetail.skillsandCertif.Substring(0, _cd.candDetail.skillsandCertif.Length - 1);

            _read.Close();


            string[] specialArr = _cd.candDetail.employerspecialization.Split(',');
            string specialVal = "";

            for (int i = 0; i < specialArr.Length; i++)
            {
                specialVal = specialVal + "'" + specialArr[i] + "',";
            }

            specialVal = specialVal.Substring(0, specialVal.Length - 1);


            query = "select SpecilaizationName from Specialization_Master where SpecilaizationID in (" + specialVal + ")";
            _read = _sql.doRead(query);
            _cd.candDetail.employerspecialization = "";

            while (_read.Read())
            {
                _cd.candDetail.employerspecialization += _read[0].ToString() + "|";
            }

            _cd.candDetail.employerspecialization = _cd.candDetail.employerspecialization.Substring(0, _cd.candDetail.employerspecialization.Length - 1);

            _read.Close();


            query = @"select * from
                    (
                    select(sum(convert(float, RecruiterRating)) / sum(5)) * 100 negativerating from CandidateDetails can
                    join CandidateJob candjob on can.candidateid = candjob.CandidateId
                    where can.candidateid = '" + Candidateid + "'and RecruiterRating <= 3)tb1," +
                    "(select(sum(convert(float, RecruiterRating)) /sum(5)) * 100 positiverating from CandidateDetails can" +
                    " join CandidateJob candjob on can.candidateid = candjob.CandidateId" +
                    " where can.candidateid = '" + Candidateid + "'and RecruiterRating> 3)tb2";


            _read = _sql.doRead(query);


            while (_read.Read())
            {
                _cd.negativerating = _read[0].ToString();
                _cd.positiverating = _read[1].ToString();
            }

            _read.Close();

            query = @"select distinct job.Jobcode,Jobimage,JobTitle,Duration,EmpTypeName,City,State,job.Rate1,typ.TypeName
                    from Job_Master_USA job
                    join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType                    
					join CandidateJob canjob on canjob.Jobcode=job.Jobcode
					join CandidateDetails can on can.candidateid=canjob.CandidateId
                    join Type_Master typ on typ.TypeID=can.type          
                    where job.Assigned_To like '%" + TWE_Id + "%' and job.Jobcode in" +
                    "(select jobcode from CandidateJob where candidateid='" + Candidateid + "')";


            _read = _sql.doRead(query);
            while (_read.Read())
            {
                JobcodeList objJob = new JobcodeList();
                objJob.Jobcode = _read[0].ToString();
                objJob.JobMediaPath = _read[1].ToString();
                objJob.JobTitle = _read[2].ToString();
                objJob.JobDuration = _read[3].ToString();
                objJob.JobContact = _read[4].ToString();
                objJob.JobCity = _read[5].ToString();
                objJob.JobState = _read[6].ToString();
                objJob.JobRate = _read[7].ToString();
                objJob.JobType = _read[8].ToString();
                _cd._lstJob.Add(objJob);
            }

            _read.Close();


            string jobSkill = "";

            query = @"select Skill from Job_Master_USA where Jobstatus='10200' and Jobcode !='" + _cd.candDetail.jobcode + "'";

            _read = _sql.doRead(query);
            while (_read.Read())
            {
                jobSkill += _read[0].ToString() + ",";
            }

            _read.Close();

            if (jobSkill != "")
            {

                jobSkill = jobSkill.Substring(0, jobSkill.Length - 1);

                string[] totSkill = jobSkill.Split(',');

                for (int i = 0; i < skillArr.Length; i++)
                {
                    for (int j = 0; j < totSkill.Length; j++)
                    {
                        if (skillArr[i] == totSkill[j])
                        {
                            query = @"select distinct job.Jobcode,Jobimage,JobTitle,Duration,
                                EmpTypeName,City,State from Job_Master_USA job
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                where Skill like '%" + totSkill[j] + "%' and Jobcode!='" + _cd.candDetail.jobcode + "'";

                            _read = _sql.doRead(query);
                            while (_read.Read())
                            {
                                JobcodeList objJob = new JobcodeList();
                                objJob.Jobcode = _read[0].ToString();
                                objJob.JobMediaPath = _read[1].ToString();
                                objJob.JobTitle = _read[2].ToString();
                                objJob.JobDuration = _read[3].ToString();
                                objJob.JobType = _read[4].ToString();
                                objJob.JobCity = _read[5].ToString();
                                objJob.JobState = _read[6].ToString();
                                _cd._lstMatchJob.Add(objJob);
                            }
                            _read.Close();
                        }
                    }
                }



                List<JobcodeList> _lstMatchJob1 = new List<JobcodeList>();

                foreach (var item in _cd._lstMatchJob)
                {
                    if (!_lstMatchJob1.Where(x => x.Jobcode == item.Jobcode).Any())
                    {
                        _lstMatchJob1.Add(item);
                    }
                }


                _cd._lstMatchJob = _lstMatchJob1;
            }

            _cd._lstCandProof = new List<candidateProof>();

            query = @"select candproofid,documenttype,idNo,idfilename from candproofdetails" +
                            " where candidateid='" + Candidateid + "'";


            _read = _sql.doRead(query);
            while (_read.Read())
            {
                candidateProof objProof = new candidateProof();
                objProof.candproofid = _read[0].ToString();
                objProof.documenttype = _read[1].ToString();
                objProof.idNo = _read[2].ToString();
                objProof.idfilename = _read[3].ToString();
                _cd._lstCandProof.Add(objProof);
            }
            _read.Close();


            query = @"select Jobcode,JobTitle,Jobimage from Job_Master_USA
                        where Jobcode in
                        (select can.jobcode from CandidateJob can where candidateid='" + Candidateid + "' and jobcode in" +
                        "(select Jobcode from Job_Master_USA) and Cand_Status not in(101,102))";


            _read = _sql.doRead(query);
            while (_read.Read())
            {
                JobcodeList objJob = new JobcodeList();
                objJob.Jobcode = _read[0].ToString();
                objJob.JobTitle = _read[1].ToString();
                objJob.JobMediaPath = _read[2].ToString();
                _cd._lstAssignedJob.Add(objJob);
            }

            _read.Close();

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
                _json.data = _cd;
            }

            return _json;

        }


        public jsonArray getCandidateoverviewIndiaDetails(string fromdate, string todate, string TWE_Id, string filter)
        {
            int status = 1;
            string query = "";
            candidateOverview objCand = new candidateOverview();


            objCand._lstTile = new List<tiles>();
            objCand._lstcandilist = new List<candidatelist>();
            objCand._lstJob = new List<JobcodeList>();

            query = "select * from" +
                    "(" +
                    "select count(*) pipeline_jobs from CandidateDetailsIndia can" +
                     " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                    " join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
                    " where can.Created_By like '%" + TWE_Id + "%' and " +
                    " can.Created_On between '" + fromdate + "' and '" + todate + "'" +
                    " and Cand_Status = '102'" +
                    ") tb1," +
                    "(" +
                    "select count(*) interview_jobs from CandidateDetailsIndia can" +
                    " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                    " join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
                    " where can.Created_By like '%" + TWE_Id + "%' and " +
                    " can.Created_On between '" + fromdate + "' and '" + todate + "'" +
                    " and Cand_Status in ('110', '111')" +
                    ") tb2," +
                    "(" +
                    "select Candidate_adding from Userprofilecreation where TWE_ID='" + TWE_Id + "'" +
                    ")tb3," +
                    "(" +
                    "select count(*) candcount from CandidateDetailsIndia can" +
                    " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                    " join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
                    " where can.Created_By like '%" + TWE_Id + "%' and " +
                    " can.Created_On between '" + fromdate + "' and '" + todate + "'" +
                    " and Cand_Status in ('101', '102', '103')" +
                    ")tb4," +
                    "(" +
                    "select Submittion from Userprofilecreation where TWE_ID='" + TWE_Id + "'" +
                    ")tb5," +
                    "(" +
                    "select count(*) TLcandcount from CandidateDetailsIndia can" +
                    " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                    " join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
                    " where can.Created_By like '%" + TWE_Id + "%' and " +
                    " can.Created_On between '" + fromdate + "' and '" + todate + "'" +
                    " and Cand_Status in ('103')" +
                    ")tb6";


            SqlDataReader _read = _sql.doRead(query);
            while (_read.Read())
            {
                tiles objTile1 = new tiles();
                objTile1.TileTitle = "Pipeline";
                objTile1.TotalCount = _read[0].ToString();
                objCand._lstTile.Add(objTile1);

                tiles objTile2 = new tiles();
                objTile2.TileTitle = "Interview";
                objTile2.TotalCount = _read[1].ToString();
                objCand._lstTile.Add(objTile2);

                tiles objTile3 = new tiles();
                objTile3.TileTitle = "Add Candidates";
                objTile3.TotalCount = _read[2].ToString();
                objCand._lstTile.Add(objTile3);

                tiles objTile4 = new tiles();
                objTile4.TileTitle = "Candidates Added";
                if (Convert.ToInt32(_read[2]) <= Convert.ToInt32(_read[3]))
                {
                    objTile4.TotalCount = (Convert.ToInt32(_read[3]) - Convert.ToInt32(_read[2])).ToString();
                }
                else
                {
                    objTile4.TotalCount = (Convert.ToInt32(_read[2]) - Convert.ToInt32(_read[3])).ToString();
                }
                objCand._lstTile.Add(objTile4);

                tiles objTile5 = new tiles();
                objTile5.TileTitle = "SB Candidates";
                objTile5.TotalCount = _read[4].ToString();
                objCand._lstTile.Add(objTile5);

                tiles objTile6 = new tiles();
                objTile6.TileTitle = "SB Candidates Added";
                objTile6.TotalCount = _read[5].ToString();
                objCand._lstTile.Add(objTile6);

                tiles objTile41 = new tiles();
                objTile41.TileTitle = " more candidates to achieve";
                if (Convert.ToInt32(_read[2]) <= Convert.ToInt32(_read[3]))
                {
                    objTile41.TileTitle = " more candidates were achieved";
                }
                else
                {
                    objTile41.TileTitle = " more candidates to achieve";
                }
                objCand._lstTile.Add(objTile41);
            }

            _read.Close();

            if (filter == "All")
            {
                query = @"select can.candidateid,candidatename,candidateemailid,candidatemobileno,ratePerHr,
                        employername,employeremailid,CandidateStatusName Cand_Status,
                        up.UP_firstName+' '+up.UP_lastName Empname,
                        convert(varchar,can.Created_On,106) CreatedOn,CreatedTime
                        from CandidateDetailsIndia can
                        join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId
                        join CandidateStatus_Master sta on sta.CandidateStatusID=canjob.Cand_Status
                        left join EmployerDetailsIndia emp on can.employerid=emp.employerid
                        join Userprofile up on can.Created_By=up.TWE_ID
                        where can.Created_By like '%" + TWE_Id + "%' and " +
                        "can.Created_On between '" + fromdate + "' and '" + todate + "' ";
            }

            else if (filter == "Pipeline")
            {
                query = @"select can.candidateid,candidatename,candidateemailid,candidatemobileno,ratePerHr,
                        employername,employeremailid,CandidateStatusName Cand_Status,
                        up.UP_firstName+' '+up.UP_lastName Empname,
                        convert(varchar,can.Created_On,106) CreatedOn,CreatedTime
                        from CandidateDetailsIndia can
                        join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId
                        join CandidateStatus_Master sta on sta.CandidateStatusID=canjob.Cand_Status
                        left join EmployerDetailsIndia emp on can.employerid=emp.employerid
                        join Userprofile up on can.Created_By=up.TWE_ID
                        where can.Created_By like '%" + TWE_Id + "%' and " +
                        "can.Created_On between '" + fromdate + "' and '" + todate + "'  and Cand_Status='102' ";
            }

            else if (filter == "Interview")
            {
                query = @"select can.candidateid,candidatename,candidateemailid,candidatemobileno,ratePerHr,
                        employername,employeremailid,CandidateStatusName Cand_Status,
                        up.UP_firstName+' '+up.UP_lastName Empname,
                        convert(varchar,can.Created_On,106) CreatedOn,CreatedTime
                        from CandidateDetailsIndia can
                        join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId
                        join CandidateStatus_Master sta on sta.CandidateStatusID=canjob.Cand_Status
                        left join EmployerDetailsIndia emp on can.employerid=emp.employerid
                        join Userprofile up on can.Created_By=up.TWE_ID
                        where can.Created_By like '%" + TWE_Id + "%' and " +
                        "can.Created_On between '" + fromdate + "' and '" + todate + "'  and Cand_Status in ('110','111') ";
            }

            _read = _sql.doRead(query);
            while (_read.Read())
            {
                candidatelist candilst = new candidatelist();
                candilst.candidateid = _read[0].ToString();
                candilst.candidatemediapath = "";
                candilst.candidatename = _read[1].ToString();
                candilst.candidateemailid = _read[2].ToString();
                candilst.candidatemobno = _read[3].ToString();
                candilst.ratePerHr = _read[4].ToString();
                candilst.vendorname = _read[5].ToString();
                candilst.vendoremailid = _read[6].ToString();
                candilst.candidatestatus = _read[7].ToString();
                candilst.submittedby = _read[8].ToString();
                candilst.submitteddate = _read[9].ToString();
                candilst.submittedtime = _read[10].ToString();
                objCand._lstcandilist.Add(candilst);
            }
            _read.Close();

            query = @"select top(5) Jobcode,JobTitle,Duration,EmpTypeName,Country,LocationName from Job_Master_IND job
                        join EmploymentType_Master empl on job.EmplType=empl.EmpTypeID
                        join Location_Master loc on loc.LocationID=job.Location
                        where Assigned_To like '%" + TWE_Id + "%'  and Jobstatus='10200' ";

            _read = _sql.doRead(query);
            while (_read.Read())
            {
                JobcodeList objJob = new JobcodeList();
                objJob.Jobcode = _read[0].ToString();
                objJob.JobTitle = _read[1].ToString();
                objJob.JobDuration = _read[2].ToString();
                objJob.JobType = _read[3].ToString();
                objJob.JobCountry = _read[4].ToString();
                objJob.JobState = _read[5].ToString();
                objCand._lstJob.Add(objJob);
            }

            _read.Close();


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
                _json.data = objCand;
            }

            return _json;
        }


        public jsonArray getCandidateoverviewListIndiaDetails(string fromdate, string todate, string TWE_Id, string filter)
        {
            int status = 1;
            string query = "";
            candidateOverview objCand = new candidateOverview();

            objCand._lstTile = new List<tiles>();
            objCand._lstcandilist = new List<candidatelist>();


            string candidateCreation = "";
            string candidateEdit = "";
            string candidateView = "";
            string strquery = @"SELECT [candidateCreation],[candidateEdit],[candidateView] FROM [UserAccessPower] where userId='" + TWE_Id + "' ";
            SqlDataReader _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                candidateCreation = _read[0].ToString();
                candidateEdit = _read[1].ToString();
                candidateView = _read[2].ToString();

            }
            _read.Close();



            List<candidatelist> lstCand= new List<candidatelist>();

            if (candidateEdit == "2" || candidateView == "2")
            {
                query = "select * from" +
                        "(" +
                        "select count(*) totalcand from candidateDetailsIndia can" +
                        " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                        " join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
                        " where Cand_Status !=''" +
                        //" can.Created_On between '" + fromdate + "' and '" + todate + "'" +
                        ") t1," +
                        "(" +
                        "select count(*) SBcand from candidateDetailsIndia can" +
                        " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                        " join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
                        " where Cand_Status!=''" +
                        //" can.Created_On between '" + fromdate + "' and '" + todate + "'" +
                        " and Cand_Status in ('103')" +
                        ") tb2," +
                        "(" +
                        "select count(*) BPcand from candidateDetailsIndia can" +
                        " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                        " join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
                        " where Cand_Status!=''" +
                        //" can.Created_On between '" + fromdate + "' and '" + todate + "'" +
                        " and Cand_Status in ('105')" +
                        ")tb3," +
                        "(" +
                        "select count(*) ECcand from candidateDetailsIndia can" +
                        " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                        " join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
                        " where Cand_Status!=''" +
                        // " can.Created_On between '" + fromdate + "' and '" + todate + "'" +
                        " and Cand_Status in ('107')" +
                        ")tb4," +
                        "(" +
                        "select count(*) candDetails from candidateDetailsIndia " +
                        ")tb5," +
                        "(" +
                        "select count(*) jobDetails from Job_Master_IND where Jobcode!='TWEIND0000'" +
                        ")tb6," +
                        "(select (sum(convert(float,RecruiterRating))/sum(5))*100 Positiverating from candidateDetailsIndia can" +
                        " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                        " join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
                        "  where RecruiterRating>3)tb7," +
                        "(select (sum(convert(float,RecruiterRating))/sum(5))*100 Negativerating from candidateDetailsIndia can " +
                        " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                        " join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
                        " where RecruiterRating<=3)tb8";
            }

            else
            {
                query = "select * from" +
                        "(" +
                        "select count(*) totalcand from candidateDetailsIndia can" +
                        " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                        " join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
                        " where can.Created_By like '%" + TWE_Id + "%'  and Cand_Status !=''" +
                        //" can.Created_On between '" + fromdate + "' and '" + todate + "'" +
                        ") t1," +
                        "(" +
                        "select count(*) SBcand from candidateDetailsIndia can" +
                        " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                        " join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
                        " where can.Created_By like '%" + TWE_Id + "%'  and Cand_Status!=''" +
                        //" can.Created_On between '" + fromdate + "' and '" + todate + "'" +
                        " and Cand_Status in ('103')" +
                        ") tb2," +
                        "(" +
                        "select count(*) BPcand from candidateDetailsIndia can" +
                        " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                        " join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
                        " where can.Created_By like '%" + TWE_Id + "%'  and Cand_Status!=''" +
                        //" can.Created_On between '" + fromdate + "' and '" + todate + "'" +
                        " and Cand_Status in ('105')" +
                        ")tb3," +
                        "(" +
                        "select count(*) ECcand from candidateDetailsIndia can" +
                        " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                        " join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
                        " where can.Created_By like '%" + TWE_Id + "%'  and Cand_Status!=''" +
                        // " can.Created_On between '" + fromdate + "' and '" + todate + "'" +
                        " and Cand_Status in ('107')" +
                        ")tb4," +
                        "(" +
                        "select count(*) candDetails from candidateDetailsIndia " +
                        ")tb5," +
                        "(" +
                        "select count(*) jobDetails from Job_Master_IND where Jobcode!='TWEIND0000'" +
                        ")tb6," +
                        "(select (sum(convert(float,RecruiterRating))/sum(5))*100 Positiverating from candidateDetailsIndia can" +
                        " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                        " join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
                        "  where RecruiterRating>3)tb7," +
                        "(select (sum(convert(float,RecruiterRating))/sum(5))*100 Negativerating from candidateDetailsIndia can " +
                        " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                        " join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
                        " where RecruiterRating<=3)tb8";
            }

            _read = _sql.doRead(query);
            while (_read.Read())
            {
                tiles objTile1 = new tiles();
                objTile1.TileTitle = "Total Candidates";
                objTile1.TotalCount = _read[0].ToString();
                objCand._lstTile.Add(objTile1);

                tiles objTile2 = new tiles();
                objTile2.TileTitle = "Submitted to TL";
                objTile2.TotalCount = _read[1].ToString();
                objCand._lstTile.Add(objTile2);

                tiles objTile3 = new tiles();
                objTile3.TileTitle = "Submitted to BP";
                objTile3.TotalCount = _read[2].ToString();
                objCand._lstTile.Add(objTile3);

                tiles objTile4 = new tiles();
                objTile4.TileTitle = "Submitted to EC";
                objTile4.TotalCount = _read[3].ToString();
                objCand._lstTile.Add(objTile4);

                tiles objTile5 = new tiles();
                objTile5.TileTitle = "Candidate Count";
                objTile5.TotalCount = _read[4].ToString();
                objCand._lstTile.Add(objTile5);

                tiles objTile6 = new tiles();
                objTile6.TileTitle = "Job Count";
                objTile6.TotalCount = _read[5].ToString();
                objCand._lstTile.Add(objTile6);


                tiles objTile7 = new tiles();
                objTile7.TileTitle = "Positive Rating";
                objTile7.TotalCount = Convert.ToInt16(_read[6]).ToString();
                objCand._lstTile.Add(objTile7);

                tiles objTile8 = new tiles();
                objTile8.TileTitle = "Negative Rating";
                objTile8.TotalCount = Convert.ToInt16(_read[7]).ToString();
                objCand._lstTile.Add(objTile8);
            }

            _read.Close();

            if (filter == "All")
            {
                if (candidateEdit == "2" || candidateView == "2")
                {
                    query = @"select can.candidateid,candidatename,candidateemailid,candidatemobileno,ratePerHr,
                        employername,employeremailid,sta.CandidateStatusName Cand_Status,
                        up.UP_firstName+' '+up.UP_lastName Empname,
                        convert(varchar,can.Created_On,106) CreatedOn,CreatedTime,linkedinURL,job.Jobcode,job.JobTitle
                        from CandidateDetailsIndia can
                        left join EmployerDetailsIndia emp on can.employerid=emp.employerid
                        join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId
                        join CandidateStatus_Master sta on sta.CandidateStatusID=canjob.Cand_Status
                        join Userprofile up on can.Created_By=up.TWE_ID
                        join Job_Master_IND job on job.Jobcode=canjob.Jobcode
                        where Cand_Status!='' order by can.Created_On desc";
                    //"can.Created_On between '" + fromdate + "' and '" + todate + "' ";
                }
                else
                {
                    query = @"select can.candidateid,candidatename,candidateemailid,candidatemobileno,ratePerHr,
                        employername,employeremailid,sta.CandidateStatusName Cand_Status,
                        up.UP_firstName+' '+up.UP_lastName Empname,
                        convert(varchar,can.Created_On,106) CreatedOn,CreatedTime,linkedinURL,job.Jobcode,job.JobTitle
                        from CandidateDetailsIndia can
                        left join EmployerDetailsIndia emp on can.employerid=emp.employerid
                        join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId
                        join CandidateStatus_Master sta on sta.CandidateStatusID=canjob.Cand_Status
                        join Userprofile up on can.Created_By=up.TWE_ID
                        join Job_Master_IND job on job.Jobcode=canjob.Jobcode
                        where can.Created_By like '%" + TWE_Id + "%' and Cand_Status!='' order by can.Created_On desc";
                    //"can.Created_On between '" + fromdate + "' and '" + todate + "' ";
                }
            }

            else if (filter == "Follow")
            {
                if (candidateEdit == "2" || candidateView == "2")
                {
                    query = @"select can.candidateid,candidatename,candidateemailid,candidatemobileno,ratePerHr,
                        employername,employeremailid,sta.CandidateStatusName Cand_Status,
                        up.UP_firstName+' '+up.UP_lastName Empname,
                        convert(varchar,can.Created_On,106) CreatedOn,CreatedTime,linkedinURL,job.Jobcode,job.JobTitle
                        from CandidateDetailsIndia can
                        left join EmployerDetailsIndia emp on can.employerid=emp.employerid
                        join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId
                        join CandidateStatus_Master sta on sta.CandidateStatusID=canjob.Cand_Status
                        join Userprofile up on can.Created_By=up.TWE_ID
                        join Job_Master_IND job on job.Jobcode=canjob.Jobcode
                        where " +
                        // "can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                        "Cand_Status in ('103','105','107','110','111')  and Cand_Status!='' order by can.Created_On desc";
                }

                else
                {
                    query = @"select can.candidateid,candidatename,candidateemailid,candidatemobileno,ratePerHr,
                        employername,employeremailid,sta.CandidateStatusName Cand_Status,
                        up.UP_firstName+' '+up.UP_lastName Empname,
                        convert(varchar,can.Created_On,106) CreatedOn,CreatedTime,linkedinURL,job.Jobcode,job.JobTitle
                        from CandidateDetailsIndia can
                        left join EmployerDetailsIndia emp on can.employerid=emp.employerid
                        join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId
                        join CandidateStatus_Master sta on sta.CandidateStatusID=canjob.Cand_Status
                        join Userprofile up on can.Created_By=up.TWE_ID
                        join Job_Master_IND job on job.Jobcode=canjob.Jobcode
                        where can.Created_By like '%" + TWE_Id + "%' and " +
                       // "can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                       "Cand_Status in ('103','105','107','110','111')  and Cand_Status!='' order by can.Created_On desc";
                }
            }

            else if (filter == "Draft")
            {
                if (candidateEdit == "2" || candidateView == "2")
                {
                    query = @"select can.candidateid,candidatename,candidateemailid,candidatemobileno,ratePerHr,
                        employername,employeremailid,sta.CandidateStatusName Cand_Status,
                        up.UP_firstName+' '+up.UP_lastName Empname,
                        convert(varchar,can.Created_On,106) CreatedOn,CreatedTime,linkedinURL,job.Jobcode,job.JobTitle
                        from CandidateDetailsIndia can
                        left join EmployerDetailsIndia emp on can.employerid=emp.employerid
                        join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId
                        join CandidateStatus_Master sta on sta.CandidateStatusID=canjob.Cand_Status
                        join Userprofile up on can.Created_By=up.TWE_ID
                        left join Job_Master_IND job on job.Jobcode=canjob.Jobcode
                        where Cand_Status in ('101') and Cand_Status!='' order by can.Created_On desc";
                }
                else
                {
                    query = @"select can.candidateid,candidatename,candidateemailid,candidatemobileno,ratePerHr,
                        employername,employeremailid,sta.CandidateStatusName Cand_Status,
                        up.UP_firstName+' '+up.UP_lastName Empname,
                        convert(varchar,can.Created_On,106) CreatedOn,CreatedTime,linkedinURL,job.Jobcode,job.JobTitle
                        from CandidateDetailsIndia can
                        left join EmployerDetailsIndia emp on can.employerid=emp.employerid
                        join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId
                        join CandidateStatus_Master sta on sta.CandidateStatusID=canjob.Cand_Status
                        join Userprofile up on can.Created_By=up.TWE_ID
                        left join Job_Master_IND job on job.Jobcode=canjob.Jobcode
                        where can.Created_By like '%" + TWE_Id + "%' and " +
                        //"can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                        "Cand_Status in ('101') and Cand_Status!='' order by can.Created_On desc";
                }
            }


            else if (filter == "TLSubmitted")
            {
                if (candidateEdit == "2" || candidateView == "2")
                {
                    query = @"select can.candidateid,candidatename,candidateemailid,candidatemobileno,ratePerHr,
                        employername,employeremailid,sta.CandidateStatusName Cand_Status,
                        up.UP_firstName+' '+up.UP_lastName Empname,
                        convert(varchar,can.Created_On,106) CreatedOn,CreatedTime,linkedinURL,job.Jobcode,job.JobTitle
                        from CandidateDetailsIndia can
                        left join EmployerDetailsIndia emp on can.employerid=emp.employerid
                        join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId
                        join CandidateStatus_Master sta on sta.CandidateStatusID=canjob.Cand_Status
                        join Userprofile up on can.Created_By=up.TWE_ID
                        join Job_Master_IND job on job.Jobcode=canjob.Jobcode
                        where Cand_Status in ('103') and Cand_Status!='' order by can.Created_On desc";
                }
                else
                {
                    query = @"select can.candidateid,candidatename,candidateemailid,candidatemobileno,ratePerHr,
                        employername,employeremailid,sta.CandidateStatusName Cand_Status,
                        up.UP_firstName+' '+up.UP_lastName Empname,
                        convert(varchar,can.Created_On,106) CreatedOn,CreatedTime,linkedinURL,job.Jobcode,job.JobTitle
                        from CandidateDetailsIndia can
                        left join EmployerDetailsIndia emp on can.employerid=emp.employerid
                        join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId
                        join CandidateStatus_Master sta on sta.CandidateStatusID=canjob.Cand_Status
                        join Userprofile up on can.Created_By=up.TWE_ID
                        join Job_Master_IND job on job.Jobcode=canjob.Jobcode
                        where can.Created_By like '%" + TWE_Id + "%' and " +
                       //"can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                       " Cand_Status in ('103') and Cand_Status!='' order by can.Created_On desc";
                }
            }

            else if (filter == "BPSubmitted")
            {
                if (candidateEdit == "2" || candidateView == "2")
                {
                    query = @"select can.candidateid,candidatename,candidateemailid,candidatemobileno,ratePerHr,
                        employername,employeremailid,sta.CandidateStatusName Cand_Status,
                        up.UP_firstName+' '+up.UP_lastName Empname,
                        convert(varchar,can.Created_On,106) CreatedOn,CreatedTime,linkedinURL,job.Jobcode,job.JobTitle
                        from CandidateDetailsIndia can
                        left join EmployerDetailsIndia emp on can.employerid=emp.employerid
                        join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId
                        join CandidateStatus_Master sta on sta.CandidateStatusID=canjob.Cand_Status
                        join Userprofile up on can.Created_By=up.TWE_ID
                        join Job_Master_IND job on job.Jobcode=canjob.Jobcode
                        where Cand_Status in ('105')  and Cand_Status!='' order by can.Created_On desc";
                }
                else
                {
                    query = @"select can.candidateid,candidatename,candidateemailid,candidatemobileno,ratePerHr,
                        employername,employeremailid,sta.CandidateStatusName Cand_Status,
                        up.UP_firstName+' '+up.UP_lastName Empname,
                        convert(varchar,can.Created_On,106) CreatedOn,CreatedTime,linkedinURL,job.Jobcode,job.JobTitle
                        from CandidateDetailsIndia can
                        left join EmployerDetailsIndia emp on can.employerid=emp.employerid
                        join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId
                        join CandidateStatus_Master sta on sta.CandidateStatusID=canjob.Cand_Status
                        join Userprofile up on can.Created_By=up.TWE_ID
                        join Job_Master_IND job on job.Jobcode=canjob.Jobcode
                        where can.Created_By like '%" + TWE_Id + "%' and " +
                        //"can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                        " Cand_Status in ('105')  and Cand_Status!='' order by can.Created_On desc";

                }
            }

            else if (filter == "ECSubmitted")
            {
                if (candidateEdit == "2" || candidateView == "2")
                {
                    query = @"select can.candidateid,candidatename,candidateemailid,candidatemobileno,ratePerHr,
                        employername,employeremailid,sta.CandidateStatusName Cand_Status,
                        up.UP_firstName+' '+up.UP_lastName Empname,
                        convert(varchar,can.Created_On,106) CreatedOn,CreatedTime,linkedinURL,job.Jobcode,job.JobTitle
                        from CandidateDetailsIndia can
                        left join EmployerDetailsIndia emp on can.employerid=emp.employerid
                         join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId
                        join CandidateStatus_Master sta on sta.CandidateStatusID=canjob.Cand_Status
                        join Userprofile up on can.Created_By=up.TWE_ID
                        join Job_Master_IND job on job.Jobcode=canjob.Jobcode
                        where Cand_Status in ('107') and Cand_Status!='' order by can.Created_On desc";
                }
                else
                {
                    query = @"select can.candidateid,candidatename,candidateemailid,candidatemobileno,ratePerHr,
                        employername,employeremailid,sta.CandidateStatusName Cand_Status,
                        up.UP_firstName+' '+up.UP_lastName Empname,
                        convert(varchar,can.Created_On,106) CreatedOn,CreatedTime,linkedinURL,job.Jobcode,job.JobTitle
                        from CandidateDetailsIndia can
                        left join EmployerDetailsIndia emp on can.employerid=emp.employerid
                         join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId
                        join CandidateStatus_Master sta on sta.CandidateStatusID=canjob.Cand_Status
                        join Userprofile up on can.Created_By=up.TWE_ID
                        join Job_Master_IND job on job.Jobcode=canjob.Jobcode
                        where can.Created_By like '%" + TWE_Id + "%' and " +
                        //"can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                        "Cand_Status in ('107') and Cand_Status!='' order by can.Created_On desc";
                }
            }


            _read = _sql.doRead(query);
            while (_read.Read())
            {
                candidatelist candilst = new candidatelist();
                candilst.candidateid = _read[0].ToString();
                candilst.candidatemediapath = "";
                candilst.candidatename = _read[1].ToString();
                candilst.candidateemailid = _read[2].ToString();
                candilst.candidatemobno = _read[3].ToString();
                candilst.ratePerHr = _read[4].ToString();
                candilst.vendorname = _read[5].ToString();
                candilst.vendoremailid = _read[6].ToString();
                candilst.candidatestatus = _read[7].ToString();
                candilst.submittedby = _read[8].ToString();
                candilst.submitteddate = _read[9].ToString();
                candilst.submittedtime = _read[10].ToString();
                candilst.linkedinURL = _read[11].ToString();
                candilst.jobcode = _read[12].ToString();
                candilst.jobTitle = _read[13].ToString();
                // if (filter == "Follow")
                // {
                //candilst.jobcode = _read[12].ToString();
                // }

                lstCand.Add(candilst);
                
            }
            _read.Close();


            objCand._lstcandilist = lstCand;

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
                _json.data = objCand;
            }

            return _json;
        }


        public jsonArray getCandidateProfileIndia(string Candidateid, string TWE_Id)
        {
            int status = 1;
            string query = "";
            candidateProfileview _cd = new candidateProfileview();
            _cd.candDetail = new Candidatedetails();
            _cd._lstJob = new List<JobcodeList>();
            _cd._lstMatchJob = new List<JobcodeList>();
            _cd._lstAssignedJob = new List<JobcodeList>();
            _cd._lstdrpJob = new List<dropDownTemplate>();



            query = @"select can.candidateid,candidatename,
                            candidatemobileno,candidateemailid,
                            currentLocation,linkedinURL,
                            skillsandCertif,emp.employerid,employername,employermobileno,
                            employeremailid,employercorporationaname,employerspecialization,
                            Cand_Status,
                            convert(varchar,can.Created_On,106) CreatedOn,can.Created_By,CreatedTime,job.jobcode,employeradditionalinfo,RecruiterRating
                            from CandidateDetailsIndia can
                            left join EmployerDetailsIndia emp on can.employerid=emp.employerid
                            join CandidateJobIndia canjob on canjob.CandidateId=can.candidateid
							left join Job_Master_IND job on job.Jobcode=canjob.Jobcode	
                            where can.candidateid='" + Candidateid + "'";


            SqlDataReader _read = _sql.doRead(query);

            while (_read.Read())
            {
                _cd.candDetail.candidateid = _read[0].ToString();
                _cd.candDetail.candidatename = _read[1].ToString();
                _cd.candDetail.candidatemobileno = _read[2].ToString();
                _cd.candDetail.candidateemailid = _read[3].ToString();
                _cd.candDetail.currentLocation = _read[4].ToString();
                _cd.candDetail.linkedinURL = _read[5].ToString();
                _cd.candDetail.skillsandCertif = _read[6].ToString();
                _cd.candDetail.employerid = _read[7].ToString();
                _cd.candDetail.employeename = _read[8].ToString();
                _cd.candDetail.employerContactno = _read[9].ToString();
                _cd.candDetail.employermailid = _read[10].ToString();
                _cd.candDetail.corporationname = _read[11].ToString();
                _cd.candDetail.employerspecialization = _read[12].ToString();
                _cd.candDetail.candStatus = _read[13].ToString();
                _cd.candDetail.createdOn = _read[14].ToString();
                _cd.candDetail.createdBy = _read[15].ToString();
                _cd.candDetail.createdTime = _read[16].ToString();
                _cd.candDetail.jobcode = _read[17].ToString();
                _cd.candDetail.employeradderinformation = _read[18].ToString();
                _cd.candDetail.recruiterrating = _read[19].ToString();
            }

            _read.Close();


            query = @"select Jobcode,JobTitle,Duration from Job_Master_IND where Jobstatus='10200' and Jobcode!='" + _cd.candDetail.jobcode + "'";


            _read = _sql.doRead(query);
            while (_read.Read())
            {
                dropDownTemplate objJob = new dropDownTemplate();
                objJob.ID = _read[0].ToString();
                objJob.Name = _read[1].ToString() + "/" + _read[0].ToString() + "/" + _read[2].ToString();
                _cd._lstdrpJob.Add(objJob);
            }

            _read.Close();

            string[] skillArr = _cd.candDetail.skillsandCertif.Split(',');
            string skillVal = "";

            for (int i = 0; i < skillArr.Length; i++)
            {
                skillVal = skillVal + "'" + skillArr[i] + "',";
            }

            skillVal = skillVal.Substring(0, skillVal.Length - 1);


            query = "select SkillName from Skill_Master where SkillID in (" + skillVal + ")";
            _read = _sql.doRead(query);
            _cd.candDetail.skillsandCertif = "";

            while (_read.Read())
            {
                _cd.candDetail.skillsandCertif += _read[0].ToString() + "|";
            }

            _cd.candDetail.skillsandCertif = _cd.candDetail.skillsandCertif.Substring(0, _cd.candDetail.skillsandCertif.Length - 1);

            _read.Close();

            if (_cd.candDetail.employerspecialization != "")
            {


                string[] specialArr = _cd.candDetail.employerspecialization.Split(',');
                string specialVal = "";

                for (int i = 0; i < specialArr.Length; i++)
                {
                    specialVal = specialVal + "'" + specialArr[i] + "',";
                }

                specialVal = specialVal.Substring(0, specialVal.Length - 1);


                query = "select SpecilaizationName from Specialization_Master where SpecilaizationID in (" + specialVal + ")";
                _read = _sql.doRead(query);
                _cd.candDetail.employerspecialization = "";

                while (_read.Read())
                {
                    _cd.candDetail.employerspecialization += _read[0].ToString() + "|";
                }

                _cd.candDetail.employerspecialization = _cd.candDetail.employerspecialization.Substring(0, _cd.candDetail.employerspecialization.Length - 1);

                _read.Close();
            }



            query = @"select * from
                    (
                    select(sum(convert(float, RecruiterRating)) / sum(5)) * 100 negativerating from CandidateDetailsIndia can
                    join CandidateJobIndia candjob on can.candidateid = candjob.CandidateId
                    where can.candidateid = '" + Candidateid + "'and RecruiterRating <= 3)tb1," +
                    "(select(sum(convert(float, RecruiterRating)) /sum(5)) * 100 positiverating from CandidateDetailsIndia can" +
                    " join CandidateJobIndia candjob on can.candidateid = candjob.CandidateId" +
                    " where can.candidateid = '" + Candidateid + "'and RecruiterRating> 3)tb2";

            _read = _sql.doRead(query);


            while (_read.Read())
            {
                _cd.negativerating = _read[0].ToString();
                _cd.positiverating = _read[1].ToString();
            }

            _read.Close();

            //query = @"select distinct job.Jobcode,Jobimage,JobTitle,Duration,EmpTypeName,job.Minrate+'-'+job.Maxrate rate,LocationName
            //        from Job_Master_IND job
            //        join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
            //        join Location_Master loc on loc.LocationID=job.Location
            //        join CandidateJobIndia canjob on canjob.Jobcode=job.Jobcode
            //        join CandidateDetailsIndia can on can.candidateid=canjob.candidateid
            //        join RateType_Master typ on typ.TypeID=can.type
            //        where job.Assigned_To like '%" + TWE_Id + "%' and job.Jobcode in" +
            //       "(select jobcode from CandidateJobIndia where candidateid='" + Candidateid + "')";

            query = @"select distinct job.Jobcode,Jobimage,JobTitle,Duration,EmpTypeName,job.Minrate+'-'+job.Maxrate rate,LocationName
                    from Job_Master_IND job
                    join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                    join Location_Master loc on loc.LocationID=job.Location
                    join CandidateJobIndia canjob on canjob.Jobcode=job.Jobcode
                    join CandidateDetailsIndia can on can.candidateid=canjob.candidateid
                    join RateType_Master typ on typ.TypeID=can.type
                    where job.Jobcode in" +
                   "(select jobcode from CandidateJobIndia where candidateid='" + Candidateid + "')";


            _read = _sql.doRead(query);
            while (_read.Read())
            {
                JobcodeList objJob = new JobcodeList();
                objJob.Jobcode = _read[0].ToString();
                objJob.JobMediaPath = _read[1].ToString();
                objJob.JobTitle = _read[2].ToString();
                objJob.JobDuration = _read[3].ToString();
                objJob.JobType = _read[4].ToString();
                objJob.JobRate = _read[5].ToString();
                objJob.JobState = _read[6].ToString();
                _cd._lstJob.Add(objJob);
            }

            _read.Close();


            string jobSkill = "";

            query = @"select Skill from Job_Master_IND where Jobstatus='10200' and Jobcode !='" + _cd.candDetail.jobcode + "'";

            _read = _sql.doRead(query);
            while (_read.Read())
            {
                jobSkill += _read[0].ToString() + ",";
            }

            _read.Close();


            if (jobSkill.Length > 0)
            {


                jobSkill = jobSkill.Substring(0, jobSkill.Length - 1);

                string[] totSkill = jobSkill.Split(',');

                for (int i = 0; i < skillArr.Length; i++)
                {
                    for (int j = 0; j < totSkill.Length; j++)
                    {
                        if (skillArr[i] == totSkill[j])
                        {
                            query = @"select distinct job.Jobcode,Jobimage,JobTitle,Duration,
                                EmpTypeName,LocationName from Job_Master_IND job
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Location_Master loc on loc.LocationID=job.Location
                                where Skill like '%" + totSkill[j] + "%'";

                            _read = _sql.doRead(query);
                            while (_read.Read())
                            {
                                JobcodeList objJob = new JobcodeList();
                                objJob.Jobcode = _read[0].ToString();
                                objJob.JobMediaPath = _read[1].ToString();
                                objJob.JobTitle = _read[2].ToString();
                                objJob.JobDuration = _read[3].ToString();
                                objJob.JobType = _read[4].ToString();
                                objJob.JobState = _read[5].ToString();

                                _cd._lstMatchJob.Add(objJob);
                            }
                            _read.Close();
                        }
                    }
                }

                List<JobcodeList> _lstMatchJob1 = new List<JobcodeList>();

                foreach (var item in _cd._lstMatchJob)
                {
                    if (!_lstMatchJob1.Where(x => x.Jobcode == item.Jobcode).Any())
                    {
                        _lstMatchJob1.Add(item);
                    }

                }


                _cd._lstMatchJob = _lstMatchJob1;
            }


            _cd._lstCandProof = new List<candidateProof>();

            query = @"select candproofid,documenttype,idNo,idfilename from candproofdetailsIndia" +
                            " where candidateid='" + Candidateid + "'";


            _read = _sql.doRead(query);
            while (_read.Read())
            {
                candidateProof objProof = new candidateProof();
                objProof.candproofid = _read[0].ToString();
                objProof.documenttype = _read[1].ToString();
                objProof.idNo = _read[2].ToString();
                objProof.idfilename = _read[3].ToString();
                _cd._lstCandProof.Add(objProof);
            }
            _read.Close();


            query = @"select Jobcode,JobTitle,Jobimage from Job_Master_IND
                        where Jobcode in
                        (select can.jobcode from CandidateJobIndia can where candidateid='" + Candidateid + "' and jobcode in" +
                        "(select Jobcode from Job_Master_IND))";


            _read = _sql.doRead(query);
            while (_read.Read())
            {
                JobcodeList objJob = new JobcodeList();
                objJob.Jobcode = _read[0].ToString();
                objJob.JobTitle = _read[1].ToString();
                objJob.JobMediaPath = _read[2].ToString();
                _cd._lstAssignedJob.Add(objJob);
            }

            _read.Close();

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
                _json.data = _cd;
            }

            return _json;

        }

        public jsonArray getFeedbackIndia(string jobid, string candid)
        {
            string query = "";

            //candidateProfileview _cd = new candidateProfileview();

            //_cd._lstFeedback = new List<candidateComments>();

            //      query = @"select can.candidateid,candidatename,JobTitle,empl.EmpTypeName,
            //                  loc.LocationName,up.UP_firstName+' '+up.UP_lastName Empname,
            //                  availableforinterview,ratePerHr,Cand_Status,typ.TypeName,
            //                  convert(varchar,can.Created_On,106) Created_On,job.Created_Time,
            //                  comm.TLComments,comm.TLcomgivenby,comm.TLcomgivenon,comm.TLcomgiventime,
            //                  comm.BPComments,comm.BPcomgivenby,comm.BPcomgivenon,comm.BPcomgiventime,
            //                  comm.ECComments,comm.ECcomgivenby,comm.ECcomgivenon,comm.ECcomgiventime,
            //                  Duration,Jobstatus,Jobimage,candidateRemark
            //                  from CandidateDetails can
            //                  join CandidateJob canjob on canjob.CandidateId=can.candidateid
            //join Job_Master_USA job on canjob.jobcode=job.Jobcode
            //                  join EmploymentType_Master empl on job.EmplType=empl.EmpTypeID
            //                  join Location_Master loc on loc.LocationID=job.Location
            //                  join Type_Master typ on typ.TypeID=can.type
            //                  join Userprofile up on up.TWE_ID=job.Created_By
            //                  left join candComments comm on can.candidateid=comm.candidateid
            //                  where job.Jobcode='" + jobid+ "'";


            //SqlDataReader _read = _sql.doRead(query);
            //while (_read.Read())
            //{
            //    candidateComments objComm = new candidateComments();
            //    objComm.candidateid = _read[0].ToString();
            //    objComm.candidatename = _read[1].ToString();
            //    objComm.jobtitle = _read[2].ToString();
            //    objComm.emplType = _read[3].ToString();
            //    objComm.currentLocation = _read[4].ToString();
            //    objComm.createdBy = _read[5].ToString();

            //    objComm.availableforinterview = _read[6].ToString();
            //    objComm.ratePerHr = _read[7].ToString();
            //    objComm.candStatus = _read[8].ToString();

            //    objComm.type = _read[9].ToString();
            //    objComm.createdOn = _read[10].ToString();
            //    objComm.createdTime = _read[11].ToString();
            //    objComm.TLComments = _read[12].ToString();
            //    objComm.TLcomgivenby = _read[13].ToString();
            //    objComm.TLcomgivenon = _read[14].ToString();
            //    objComm.TLcomgiventime = _read[15].ToString();
            //    objComm.BPComments = _read[16].ToString();
            //    objComm.BPcomgivenby = _read[17].ToString();
            //    objComm.BPcomgivenon = _read[18].ToString();
            //    objComm.BPcomgiventime = _read[19].ToString();
            //    objComm.ECComments = _read[20].ToString();
            //    objComm.ECcomgivenby = _read[21].ToString();
            //    objComm.ECcomgivenon = _read[22].ToString();
            //    objComm.ECcomgiventime = _read[23].ToString();
            //    objComm.duration = _read[24].ToString();
            //    objComm.jobstatus = _read[25].ToString();
            //    objComm.jobimage = _read[26].ToString();
            //    objComm.RecruiterComments = _read[27].ToString();

            //    _cd._lstFeedback.Add(objComm);
            //}




            candidateComments objComm = new candidateComments();

            query = @"select JobTitle,Duration,empl.EmpTypeName,
                    loc.LocationName,up.UP_firstName+' '+up.UP_lastName Empname, Convert(varchar,job.Created_On,106) Created_On,job.Created_Time,
                    availableforinterview,ratePerHr,JobstatusName,typ.TypeName,Jobimage
                    from CandidateDetailsIndia can
                    join CandidateJobIndia canjob on canjob.CandidateId=can.candidateid
                    join Job_Master_IND job on canjob.jobcode=job.Jobcode
                    join EmploymentType_Master empl on job.EmplType=empl.EmpTypeID
                    join Location_Master loc on loc.LocationID=job.Location
                    join RateType_Master typ on typ.TypeID=can.type
                    join Userprofile up on up.TWE_ID=job.Created_By
                    join Jobstatus_Master sta on sta.JobstatusID=job.Jobstatus" +
                    " where canjob.Jobcode='" + jobid + "' and can.candidateid='" + candid + "'";

            SqlDataReader _read = _sql.doRead(query);
            while (_read.Read())
            {

                objComm.jobtitle = _read[0].ToString();
                objComm.jobduration = _read[1].ToString();
                objComm.emplType = _read[2].ToString();
                objComm.joblocation = _read[3].ToString();
                objComm.jobcreatedBy = _read[4].ToString();
                objComm.jobcreatedOn = _read[5].ToString();
                objComm.jobcreatedTime = _read[6].ToString();
                objComm.availableforinterview = _read[7].ToString();
                objComm.ratePerHr = _read[8].ToString();
                objComm.jobstatus = _read[9].ToString();
                objComm.type = _read[10].ToString();
                objComm.jobimage = _read[11].ToString();
            }

            _read.Close();


            query = @"select candcommentid,canjob.candidateRemark,sta.CandidateStatusName,
                        up.UP_firstName+' '+up.UP_lastName RecCommcreby,
                        Convert(varchar,can.Created_On,106) Created_On,CreatedTime,
                        up1.UP_firstName+' ' +up1.UP_lastName RecCommupdby,
                        Convert(varchar,can.Last_Updated_On,106) Last_Updated_On,RecruiterRating,
                        cancom.TLComments,up2.UP_firstName+' '+up2.UP_lastName TLCommcreby,
                        Convert(varchar,TLcomgivenon,106) TLcomgivenon,TLcomgiventime,
                        up21.UP_firstName+' '+up21.UP_lastName TLCommupdby,
                        Convert(varchar,cancom.TLupdategivenon,106) TLupdategivenon,TLupdategiventime,cancom.TLRating,
                        BPIstartdate,BPItime,up6.UP_firstName+' '+up6.UP_lastName BPICommcreby,
                        Convert(varchar,BPIcomgivenon,106) BPIcomgivenon,BPIcomgiventime,
                        up61.UP_firstName+' '+up61.UP_lastName BPICommupdby,
                        Convert(varchar,cancom.BPIupdategivenon,106) BPIupdategivenon,BPIupdategiventime,
                        cancom.BPComments,up3.UP_firstName+' '+up3.UP_lastName BPCommcreby,
                        Convert(varchar,BPcomgivenon,106) BPcomgivenon,BPcomgiventime,
                        up31.UP_firstName+' '+up31.UP_lastName BPCommupdby,
                        Convert(varchar,cancom.BPupdategivenon,106) BPupdategivenon,BPupdategiventime,
                        ECIstartdate,ECItime,up7.UP_firstName+' '+up7.UP_lastName ECICommcreby,
                        Convert(varchar,ECIcomgivenon,106) ECIcomgivenon,ECIcomgiventime,
                        up71.UP_firstName+' '+up71.UP_lastName ECICommupdby,
                        Convert(varchar,cancom.ECIupdategivenon,106) ECIupdategivenon,ECIupdategiventime,
                        cancom.ECComments,up4.UP_firstName+' '+up4.UP_lastName ECCommcreby,
                        Convert(varchar,ECcomgivenon,106) ECcomgivenon,ECcomgiventime,
                        up41.UP_firstName+' '+up41.UP_lastName ECCommupdby,
                        Convert(varchar,cancom.ECupdategivenon,106) ECupdategivenon,ECupdategiventime,Cand_Status
                        --cancom.CLComments,up5.UP_firstName+' '+up5.UP_lastName CLCommcreby,
                        --Convert(varchar,CLcomgivenon,106) CLcomgivenon,CLcomgiventime,
                        --up51.UP_firstName+' '+up51.UP_lastName CLCommupdby,
                        --Convert(varchar,cancom.CLupdategivenon,106) CLupdategivenon,CLupdategiventime,						
                        from  CandidateDetailsIndia can 
                        join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId
                        left join candCommentsIndia cancom on can.candidateid=cancom.candidateid and canjob.jobcode=cancom.jobcode
                        join Userprofile up on up.TWE_ID=can.Created_By
                        join Userprofile up1 on up1.TWE_ID=can.Last_Updated_By
                        left join Userprofile up2 on up2.TWE_ID=cancom.TLcomgivenby
                        left join Userprofile up21 on up21.TWE_ID=cancom.TLupdategivenby
                        left join Userprofile up3 on up3.TWE_ID=cancom.BPcomgivenby
                        left join Userprofile up31 on up31.TWE_ID=cancom.BPupdategivenby
                        left join Userprofile up4 on up4.TWE_ID=cancom.ECcomgivenby
                        left join Userprofile up41 on up41.TWE_ID=cancom.ECupdategivenby
                        --left join Userprofile up5 on up5.TWE_ID=cancom.CLcomgivenby
                        --left join Userprofile up51 on up51.TWE_ID=cancom.CLupdategivenby
                        left join Userprofile up6 on up6.TWE_ID=cancom.BPIcomgivenby
                        left join Userprofile up61 on up61.TWE_ID=cancom.BPIupdategivenby
                        left join Userprofile up7 on up7.TWE_ID=cancom.ECIcomgivenby
                        left join Userprofile up71 on up71.TWE_ID=cancom.ECIupdategivenby
                        join CandidateStatus_Master sta on canjob.Cand_Status=sta.CandidateStatusID " +
                        " where canjob.Jobcode='" + jobid + "' and can.candidateid='" + candid + "'";


            _read = _sql.doRead(query);
            while (_read.Read())
            {

                objComm.candcommentid = _read[0].ToString();
                objComm.RecruiterComments = _read[1].ToString();
                objComm.candStatus = _read[2].ToString();
                objComm.createdBy = _read[3].ToString();
                objComm.createdOn = _read[4].ToString();
                objComm.createdTime = _read[5].ToString();
                objComm.lastupdatedBy = _read[6].ToString();
                objComm.lastupdatedOn = _read[7].ToString();
                objComm.recruiterrating = _read[8].ToString();
                objComm.TLComments = _read[9].ToString();
                objComm.TLcomgivenby = _read[10].ToString();
                objComm.TLcomgivenon = _read[11].ToString();
                objComm.TLcomgiventime = _read[12].ToString();
                objComm.TLcomupdatedby = _read[13].ToString();
                objComm.TLcomupdatedon = _read[14].ToString();
                objComm.TLcomupdatedtime = _read[15].ToString();
                objComm.TLRating = _read[16].ToString();
                if (!(_read[17].Equals(System.DBNull.Value)))
                {
                    objComm.BPIstartdate = Convert.ToDateTime(_read[17]).ToString("yyyy-MM-dd");
                }

                objComm.BPITime = _read[18].ToString();
                objComm.BPIcomgivenby = _read[19].ToString();
                objComm.BPIcomgivenon = _read[20].ToString();
                objComm.BPIcomgiventime = _read[21].ToString();
                objComm.BPIcomupdatedby = _read[22].ToString();
                objComm.BPIcomupdatedon = _read[23].ToString();
                objComm.BPIcomupdatedtime = _read[24].ToString();
                objComm.BPComments = _read[25].ToString();
                objComm.BPcomgivenby = _read[26].ToString();
                objComm.BPcomgivenon = _read[27].ToString();
                objComm.BPcomgiventime = _read[28].ToString();
                objComm.BPcomupdatedby = _read[29].ToString();
                objComm.BPcomupdatedon = _read[30].ToString();
                objComm.BPcomupdatedtime = _read[31].ToString();
                if (!(_read[32].Equals(System.DBNull.Value)))
                {
                    objComm.ECIstartdate = Convert.ToDateTime(_read[32]).ToString("yyyy-MM-dd");
                }

                objComm.ECITime = _read[33].ToString();
                objComm.ECIcomgivenby = _read[34].ToString();
                objComm.ECIcomgivenon = _read[35].ToString();
                objComm.ECIcomgiventime = _read[36].ToString();
                objComm.ECIcomupdatedby = _read[37].ToString();
                objComm.ECIcomupdatedon = _read[38].ToString();
                objComm.ECIcomupdatedtime = _read[39].ToString();
                objComm.ECComments = _read[40].ToString();
                objComm.ECcomgivenby = _read[41].ToString();
                objComm.ECcomgivenon = _read[42].ToString();
                objComm.ECcomgiventime = _read[43].ToString();
                objComm.ECcomupdatedby = _read[44].ToString();
                objComm.ECcomupdatedon = _read[45].ToString();
                objComm.ECcomupdatedtime = _read[46].ToString();
                //objComm.CLComments = _read[47].ToString();
                //objComm.CLcomgivenby = _read[48].ToString();
                //objComm.CLcomgivenon = _read[49].ToString();
                //objComm.CLcomgiventime = _read[50].ToString();
                //objComm.CLcomupdatedby = _read[51].ToString();
                //objComm.CLcomupdatedon = _read[52].ToString();
                //objComm.CLcomupdatedtime = _read[53].ToString();
                objComm.candstatusid = _read[47].ToString();
                //_cd._lstFeedback.Add(objComm);
            }



            _read.Close();


            jsonArray _json = new jsonArray();
            int status = 1;
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
                _json.data = objComm;
            }

            return _json;
        }

        public jsonArray getFeedback(string jobid, string candid)
        {
            string query = "";

            //candidateProfileview _cd = new candidateProfileview();

            //_cd._lstFeedback = new List<candidateComments>();

            //      query = @"select can.candidateid,candidatename,JobTitle,empl.EmpTypeName,
            //                  loc.LocationName,up.UP_firstName+' '+up.UP_lastName Empname,
            //                  availableforinterview,ratePerHr,Cand_Status,typ.TypeName,
            //                  convert(varchar,can.Created_On,106) Created_On,job.Created_Time,
            //                  comm.TLComments,comm.TLcomgivenby,comm.TLcomgivenon,comm.TLcomgiventime,
            //                  comm.BPComments,comm.BPcomgivenby,comm.BPcomgivenon,comm.BPcomgiventime,
            //                  comm.ECComments,comm.ECcomgivenby,comm.ECcomgivenon,comm.ECcomgiventime,
            //                  Duration,Jobstatus,Jobimage,candidateRemark
            //                  from CandidateDetails can
            //                  join CandidateJob canjob on canjob.CandidateId=can.candidateid
            //join Job_Master_USA job on canjob.jobcode=job.Jobcode
            //                  join EmploymentType_Master empl on job.EmplType=empl.EmpTypeID
            //                  join Location_Master loc on loc.LocationID=job.Location
            //                  join Type_Master typ on typ.TypeID=can.type
            //                  join Userprofile up on up.TWE_ID=job.Created_By
            //                  left join candComments comm on can.candidateid=comm.candidateid
            //                  where job.Jobcode='" + jobid+ "'";


            //SqlDataReader _read = _sql.doRead(query);
            //while (_read.Read())
            //{
            //    candidateComments objComm = new candidateComments();
            //    objComm.candidateid = _read[0].ToString();
            //    objComm.candidatename = _read[1].ToString();
            //    objComm.jobtitle = _read[2].ToString();
            //    objComm.emplType = _read[3].ToString();
            //    objComm.currentLocation = _read[4].ToString();
            //    objComm.createdBy = _read[5].ToString();

            //    objComm.availableforinterview = _read[6].ToString();
            //    objComm.ratePerHr = _read[7].ToString();
            //    objComm.candStatus = _read[8].ToString();

            //    objComm.type = _read[9].ToString();
            //    objComm.createdOn = _read[10].ToString();
            //    objComm.createdTime = _read[11].ToString();
            //    objComm.TLComments = _read[12].ToString();
            //    objComm.TLcomgivenby = _read[13].ToString();
            //    objComm.TLcomgivenon = _read[14].ToString();
            //    objComm.TLcomgiventime = _read[15].ToString();
            //    objComm.BPComments = _read[16].ToString();
            //    objComm.BPcomgivenby = _read[17].ToString();
            //    objComm.BPcomgivenon = _read[18].ToString();
            //    objComm.BPcomgiventime = _read[19].ToString();
            //    objComm.ECComments = _read[20].ToString();
            //    objComm.ECcomgivenby = _read[21].ToString();
            //    objComm.ECcomgivenon = _read[22].ToString();
            //    objComm.ECcomgiventime = _read[23].ToString();
            //    objComm.duration = _read[24].ToString();
            //    objComm.jobstatus = _read[25].ToString();
            //    objComm.jobimage = _read[26].ToString();
            //    objComm.RecruiterComments = _read[27].ToString();

            //    _cd._lstFeedback.Add(objComm);
            //}




            candidateComments objComm = new candidateComments();

            query = @"select JobTitle,Duration,empl.EmpTypeName,
                    loc.LocationName,up.UP_firstName+' '+up.UP_lastName Empname, Convert(varchar,job.Created_On,106) Created_On,job.Created_Time,
                    availableforinterview,ratePerHr,JobstatusName,typ.TypeName,Jobimage
                    from CandidateDetails can
                    join CandidateJob canjob on canjob.CandidateId=can.candidateid
                    join Job_Master_USA job on canjob.jobcode=job.Jobcode
                    join EmploymentType_Master empl on job.EmplType=empl.EmpTypeID
                    join Location_Master loc on loc.LocationID=job.Location
                    join Type_Master typ on typ.TypeID=can.type
                    join Userprofile up on up.TWE_ID=job.Created_By
                    join Jobstatus_Master sta on sta.JobstatusID=job.Jobstatus" +
                    " where canjob.Jobcode='" + jobid + "' and can.candidateid='" + candid + "'";

            SqlDataReader _read = _sql.doRead(query);
            while (_read.Read())
            {

                objComm.jobtitle = _read[0].ToString();
                objComm.jobduration = _read[1].ToString();
                objComm.emplType = _read[2].ToString();
                objComm.joblocation = _read[3].ToString();
                objComm.jobcreatedBy = _read[4].ToString();
                objComm.jobcreatedOn = _read[5].ToString();
                objComm.jobcreatedTime = _read[6].ToString();
                objComm.availableforinterview = _read[7].ToString();
                objComm.ratePerHr = _read[8].ToString();
                objComm.jobstatus = _read[9].ToString();
                objComm.type = _read[10].ToString();
                objComm.jobimage = _read[11].ToString();
            }

            _read.Close();


            query = @"select candcommentid,canjob.candidateRemark,sta.CandidateStatusName,
                        up.UP_firstName+' '+up.UP_lastName RecCommcreby,
                        Convert(varchar,can.Created_On,106) Created_On,CreatedTime,
                        up1.UP_firstName+' ' +up1.UP_lastName RecCommupdby,
                        Convert(varchar,can.Last_Updated_On,106) Last_Updated_On,RecruiterRating,
                        cancom.TLComments,up2.UP_firstName+' '+up2.UP_lastName TLCommcreby,
                        Convert(varchar,TLcomgivenon,106) TLcomgivenon,TLcomgiventime,
                        up21.UP_firstName+' '+up21.UP_lastName TLCommupdby,
                        Convert(varchar,cancom.TLupdategivenon,106) TLupdategivenon,TLupdategiventime,cancom.TLRating,
                        BPIstartdate,BPItime,up6.UP_firstName+' '+up6.UP_lastName BPICommcreby,
                        Convert(varchar,BPIcomgivenon,106) BPIcomgivenon,BPIcomgiventime,
                        up61.UP_firstName+' '+up61.UP_lastName BPICommupdby,
                        Convert(varchar,cancom.BPIupdategivenon,106) BPIupdategivenon,BPIupdategiventime,
                        cancom.BPComments,up3.UP_firstName+' '+up3.UP_lastName BPCommcreby,
                        Convert(varchar,BPcomgivenon,106) BPcomgivenon,BPcomgiventime,
                        up31.UP_firstName+' '+up31.UP_lastName BPCommupdby,
                        Convert(varchar,cancom.BPupdategivenon,106) BPupdategivenon,BPupdategiventime,
                        ECIstartdate,ECItime,up7.UP_firstName+' '+up7.UP_lastName ECICommcreby,
                        Convert(varchar,ECIcomgivenon,106) ECIcomgivenon,ECIcomgiventime,
                        up71.UP_firstName+' '+up71.UP_lastName ECICommupdby,
                        Convert(varchar,cancom.ECIupdategivenon,106) ECIupdategivenon,ECIupdategiventime,
                        cancom.ECComments,up4.UP_firstName+' '+up4.UP_lastName ECCommcreby,
                        Convert(varchar,ECcomgivenon,106) ECcomgivenon,ECcomgiventime,
                        up41.UP_firstName+' '+up41.UP_lastName ECCommupdby,
                        Convert(varchar,cancom.ECupdategivenon,106) ECupdategivenon,ECupdategiventime,Cand_Status
                        --cancom.CLComments,up5.UP_firstName+' '+up5.UP_lastName CLCommcreby,
                        --Convert(varchar,CLcomgivenon,106) CLcomgivenon,CLcomgiventime,
                        --up51.UP_firstName+' '+up51.UP_lastName CLCommupdby,
                        --Convert(varchar,cancom.CLupdategivenon,106) CLupdategivenon,CLupdategiventime,						
                        from  CandidateDetails can 
                        join CandidateJob canjob on can.candidateid=canjob.CandidateId
                        left join candComments cancom on can.candidateid=cancom.candidateid and canjob.jobcode=cancom.jobcode
                        join Userprofile up on up.TWE_ID=can.Created_By
                        join Userprofile up1 on up1.TWE_ID=can.Last_Updated_By
                        left join Userprofile up2 on up2.TWE_ID=cancom.TLcomgivenby
                        left join Userprofile up21 on up21.TWE_ID=cancom.TLupdategivenby
                        left join Userprofile up3 on up3.TWE_ID=cancom.BPcomgivenby
                        left join Userprofile up31 on up31.TWE_ID=cancom.BPupdategivenby
                        left join Userprofile up4 on up4.TWE_ID=cancom.ECcomgivenby
                        left join Userprofile up41 on up41.TWE_ID=cancom.ECupdategivenby
                        --left join Userprofile up5 on up5.TWE_ID=cancom.CLcomgivenby
                        --left join Userprofile up51 on up51.TWE_ID=cancom.CLupdategivenby
                        left join Userprofile up6 on up6.TWE_ID=cancom.BPIcomgivenby
                        left join Userprofile up61 on up61.TWE_ID=cancom.BPIupdategivenby
                        left join Userprofile up7 on up7.TWE_ID=cancom.ECIcomgivenby
                        left join Userprofile up71 on up71.TWE_ID=cancom.ECIupdategivenby
                        join CandidateStatus_Master sta on canjob.Cand_Status=sta.CandidateStatusID " +
                        " where canjob.Jobcode='" + jobid + "' and can.candidateid='" + candid + "'";


            _read = _sql.doRead(query);
            while (_read.Read())
            {

                objComm.candcommentid = _read[0].ToString();
                objComm.RecruiterComments = _read[1].ToString();
                objComm.candStatus = _read[2].ToString();
                objComm.createdBy = _read[3].ToString();
                objComm.createdOn = _read[4].ToString();
                objComm.createdTime = _read[5].ToString();
                objComm.lastupdatedBy = _read[6].ToString();
                objComm.lastupdatedOn = _read[7].ToString();
                objComm.recruiterrating = _read[8].ToString();
                objComm.TLComments = _read[9].ToString();
                objComm.TLcomgivenby = _read[10].ToString();
                objComm.TLcomgivenon = _read[11].ToString();
                objComm.TLcomgiventime = _read[12].ToString();
                objComm.TLcomupdatedby = _read[13].ToString();
                objComm.TLcomupdatedon = _read[14].ToString();
                objComm.TLcomupdatedtime = _read[15].ToString();
                objComm.TLRating = _read[16].ToString();
                if (!(_read[17].Equals(System.DBNull.Value)))
                {
                    objComm.BPIstartdate = Convert.ToDateTime(_read[17]).ToString("yyyy-MM-dd");
                }

                objComm.BPITime = _read[18].ToString();
                objComm.BPIcomgivenby = _read[19].ToString();
                objComm.BPIcomgivenon = _read[20].ToString();
                objComm.BPIcomgiventime = _read[21].ToString();
                objComm.BPIcomupdatedby = _read[22].ToString();
                objComm.BPIcomupdatedon = _read[23].ToString();
                objComm.BPIcomupdatedtime = _read[24].ToString();
                objComm.BPComments = _read[25].ToString();
                objComm.BPcomgivenby = _read[26].ToString();
                objComm.BPcomgivenon = _read[27].ToString();
                objComm.BPcomgiventime = _read[28].ToString();
                objComm.BPcomupdatedby = _read[29].ToString();
                objComm.BPcomupdatedon = _read[30].ToString();
                objComm.BPcomupdatedtime = _read[31].ToString();
                if (!(_read[32].Equals(System.DBNull.Value)))
                {
                    objComm.ECIstartdate = Convert.ToDateTime(_read[32]).ToString("yyyy-MM-dd");
                }

                objComm.ECITime = _read[33].ToString();
                objComm.ECIcomgivenby = _read[34].ToString();
                objComm.ECIcomgivenon = _read[35].ToString();
                objComm.ECIcomgiventime = _read[36].ToString();
                objComm.ECIcomupdatedby = _read[37].ToString();
                objComm.ECIcomupdatedon = _read[38].ToString();
                objComm.ECIcomupdatedtime = _read[39].ToString();
                objComm.ECComments = _read[40].ToString();
                objComm.ECcomgivenby = _read[41].ToString();
                objComm.ECcomgivenon = _read[42].ToString();
                objComm.ECcomgiventime = _read[43].ToString();
                objComm.ECcomupdatedby = _read[44].ToString();
                objComm.ECcomupdatedon = _read[45].ToString();
                objComm.ECcomupdatedtime = _read[46].ToString();                
                objComm.candstatusid = _read[47].ToString();
                //_cd._lstFeedback.Add(objComm);
            }



            _read.Close();


            jsonArray _json = new jsonArray();
            int status = 1;
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
                _json.data = objComm;
            }

            return _json;
        }

        public jsonArray getCandidateInfodataIndia(string Candidateid, string jobid)
        {
            int status = 1;
            string query = "";
            CandidatedetailsIndia _cd = new CandidatedetailsIndia();

            query = "select * from CandidateJobIndia where Jobcode='" + jobid + "' and CandidateId='" + Candidateid + "'";
            string isExists = "";
            SqlDataReader _read = _sql.doRead(query);

            while (_read.Read())
            {
                isExists = _read[0].ToString();
            }

            _read.Close();

            if (isExists != "")
            {
                query = @"SELECT job.jobcode,[candidateemailid],[candidatemobileno],[candidatename],[currentLocation],[YearsofExp],
                            [ratePerHr],[type],[skillsandCertif],[linkedinURL],[noticePeriod],
                            [availableforinterview],[employeremailid],[employermobileno],[employername],
                            [employercorporationaname],[employeradditionalinfo],[employerspecialization],
                            empl.employerid,TotYearsofExp,currcompany,cand.startdate,enddate,
                            RecruiterRating,candidateRemark,Cand_Status,RTRemailstatus
                            FROM [CandidateDetailsIndia] cand
                            join CandidateJobIndia canjob on canjob.CandidateId=cand.candidateid
							join Job_Master_IND job on job.Jobcode=canjob.Jobcode	
							left join EmployerDetailsIndia empl on cand.employerid=empl.employerid
                            left join RTRConfirmationIndia rtr on rtr.candidateemaildid=cand.candidateemailid and rtr.jobcode=canjob.Jobcode
                            where cand.candidateid='" + Candidateid + "' and job.Jobcode='" + jobid + "'";
            }

            else
            {
                query = @"SELECT job.jobcode,[candidateemailid],[candidatemobileno],[candidatename],[currentLocation],[YearsofExp],
                            [ratePerHr],[type],[skillsandCertif],[linkedinURL],[noticePeriod],
                            [availableforinterview],[employeremailid],[employermobileno],[employername],
                            [employercorporationaname],[employeradditionalinfo],[employerspecialization],
                            empl.employerid,TotYearsofExp,currcompany,cand.startdate,enddate,
                            RecruiterRating,candidateRemark,Cand_Status,RTRemailstatus
                            FROM [CandidateDetailsIndia] cand
                            join CandidateJobIndia canjob on canjob.CandidateId=cand.candidateid
							left join Job_Master_IND job on job.Jobcode=canjob.Jobcode	
							left join EmployerDetailsIndia empl on cand.employerid=empl.employerid
                            left join RTRConfirmationIndia rtr on rtr.candidateemaildid=cand.candidateemailid and rtr.jobcode=canjob.Jobcode
                            where cand.candidateid='" + Candidateid + "'";
            }


            _read = _sql.doRead(query);

            while (_read.Read())
            {
                _cd.jobcode = _read[0].ToString();
                _cd.candidateemailid = _read[1].ToString();
                _cd.candidatemobileno = _read[2].ToString();
                _cd.candidatename = _read[3].ToString();
                _cd.currentLocation = _read[4].ToString();
                _cd.yrsofexp = _read[5].ToString();
                _cd.ratePerHr = _read[6].ToString();
                _cd.type = _read[7].ToString();
                _cd.skillsandCertif = _read[8].ToString();
                _cd.linkedinURL = _read[9].ToString();
                _cd.noticePeriod = _read[10].ToString();
                _cd.availableforinterview = _read[11].ToString();
                _cd.employermailid = _read[12].ToString();
                _cd.employerContactno = _read[13].ToString();
                _cd.employeename = _read[14].ToString();
                _cd.corporationname = _read[15].ToString();
                _cd.employeradderinformation = _read[16].ToString();
                _cd.employerspecialization = _read[17].ToString();
                _cd.employerid = _read[18].ToString();
                _cd.TotYearsofExp = _read[19].ToString();
                _cd.currcompany = _read[20].ToString();
                _cd.startdate = _read[21].ToString();
                _cd.enddate = _read[22].ToString();
                _cd.recruiterrating = _read[23].ToString();
                _cd.candidateRemark = _read[24].ToString();
                _cd.candStatus = _read[25].ToString();
                _cd.RTRemailstatus = _read[26].ToString();
            }

            _read.Close();

            query = @"select Jobcode,JobTitle,Jobimage,Duration,empl.EmpTypeName,loc.LocationName,ShiftTiming from 
                        Job_Master_IND job 
                        join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                        join Location_Master loc on loc.LocationID=job.Location
                        where Jobcode='" + jobid + "'";


            _read = _sql.doRead(query);

            while (_read.Read())
            {
                _cd.jobcode = _read[0].ToString();
                _cd.jobtitle = _read[1].ToString();
                _cd.jobimage = _read[2].ToString();
                _cd.jobduration = _read[3].ToString();
                _cd.jobempltype = _read[4].ToString();
                _cd.joblocation = _read[5].ToString();
                _cd.shiftTime = _read[6].ToString();
            }

            _read.Close();

            _cd.lstCandProof = new List<candidateProof>();

            query = @"select candproofid,documenttype,idNo,idfilename from candproofdetailsIndia" +
                            " where candidateid='" + Candidateid + "'";


            _read = _sql.doRead(query);
            while (_read.Read())
            {
                candidateProof objProof = new candidateProof();
                objProof.candproofid = _read[0].ToString();
                objProof.documenttype = _read[1].ToString();
                objProof.idNo = _read[2].ToString();
                objProof.idfilename = _read[3].ToString();
                _cd.lstCandProof.Add(objProof);
            }


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
                _json.data = _cd;
            }

            return _json;

        }

        public jsonArray getfeedbackload(string Candid, string Jobid)
        {
            int status = 1;
            feedbackmaster _fbm = new feedbackmaster();
            List<assignedJob> _lstprj = new List<assignedJob>();
            feedbackdetails _fbd = new feedbackdetails();

            string strquery = "";
            strquery = @"select can.candidateid,candidatename,currentLocation,rateperhr,typ.TypeName
                        from CandidateDetails can
                        join CandidateJob canjob on can.candidateid=canjob.CandidateId
                        join Type_Master typ on typ.TypeID=can.type where jobcode='" + Jobid + "' and can.candidateid='" + Candid + "'";

            SqlDataReader _read = _sql.doRead(strquery);
            while (_read.Read())
            {

                _fbm.profilepic = "";
                _fbm.id = _read[0].ToString();
                _fbm.name = _read[1].ToString();
                _fbm.location = _read[2].ToString();
                _fbd.rateperhr = _read[3].ToString();
                _fbd.type = _read[4].ToString();


            }
            _read.Close();

            strquery = @"select * from (
                            select (sum(convert(float, RecruiterRating)) / sum(5)) * 100  Neg_Feedback
                            from CandidateDetails can join CandidateJob canjob on can.candidateid=canjob.CandidateId where can.candidateid='" + Candid + "' and RecruiterRating<=3) tb1," +
                            "(select (sum(convert(float, RecruiterRating)) / sum(5)) * 100  Pos_Feedback" +
                            " from CandidateDetails can join CandidateJob canjob on can.candidateid=canjob.CandidateId where can.candidateid='" + Candid + "' and RecruiterRating>3)tb2";

            _read = _sql.doRead(strquery);
            while (_read.Read())
            {
                range _r = new range();
                _r.negativepercentage = _read[0].ToString();
                _r.positivepercentage = _read[1].ToString();
                _fbm.range = _r;
            }

            _read.Close();

            strquery = @"select Jobcode,JobTitle,Jobimage from Job_Master_USA
                        where Jobcode in
                        (select can.jobcode from CandidateJob can where candidateid='" + Candid + "' and Cand_Status not in (101,102) and jobcode in" +
                       "(select Jobcode from Job_Master_USA))";


            _read = _sql.doRead(strquery);
            while (_read.Read())
            {
                assignedJob _prj = new assignedJob();
                _prj.name = _read[1].ToString();
                _prj.logo = _read[2].ToString();
                _prj.jobid = _read[0].ToString();
                _lstprj.Add(_prj);

            }
            _fbm.projects = _lstprj;

            _read.Close();

            //strquery = @"select Jobimage,JobTitle,Duration,EmplType,Location,Created_By,Created_On from Job_Master_USA where Jobcode='" + Prjid + "' and Assigned_To like '%" + Userid + "%'";

            //_read = _sql.doRead(strquery);
            //while (_read.Read())
            //{

            //    _fbd.logo = _read[0].ToString();
            //    _fbd.prjname = _read[1].ToString();
            //    _fbd.duration = _read[2].ToString();
            //    _fbd.type = _read[3].ToString();
            //    _fbd.worktype = _read[4].ToString();
            //    _fbd.createdby = _read[6].ToString();
            //    _fbd.createddate = _read[7].ToString();


            //}

            //_read.Close();

            //strquery = @"";

            //_read = _sql.doRead(strquery);
            //while (_read.Read())
            //{
            //    _fbd.trackprofile = "";
            //    _fbd.feedback = "";
            //    _fbd.interview = "";



            //}
            //_fbm.feedbackdetails = _fbd;

            //_read.Close();


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
                _json.data = _fbm;
            }


            return _json;
        }

        public jsonArray insertfeedback(string Userid, string Prjid, string rowid, string CLComments, string CLcomgivenby,
            string CLcomgivenon, string CLcomgiventime, string CLupdategivenby, string CLupdategivenon, string CLupdategiventime,
            string TLComments, string TLRating, string TLcomgivenby, string TLcomgivenon, string TLcomgiventime, string TLupdategivenby, string TLupdategivenon,
            string TLupdategiventime, string BPComments, string BPcomgivenby, string BPcomgivenon, string BPcomgiventime, string BPupdategivenby,
            string BPupdategivenon, string BPupdategiventime, string BPIstartdate, string BPItime, string BPIcomgivenby, string BPIcomgivenon,
            string BPIcomgiventime, string BPIupdategivenby, string BPIupdategivenon, string BPIupdategiventime, string ECComments,
            string ECcomgivenby, string ECcomgivenon, string ECcomgiventime, string ECupdategivenby, string ECupdategivenon, string ECupdategiventime,
            string ECIstartdate, string ECItime, string ECIcomgivenby, string ECIcomgivenon, string ECIcomgiventime, string ECIupdategivenby,
            string ECIupdategivenon, string ECIupdategiventime, string Candstatus)
        {
            DateTime dateTime_Eastern = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));

            var timeInEST = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));
            var timeInEasternAsString = timeInEST.ToString("hh:mm tt", CultureInfo.InvariantCulture);

            SqlDateTime sqldatenull;
            sqldatenull = SqlDateTime.Null;
            int mode = 1;
            string query = "";
            //if (BPIstartdate == "")
            //{
            //    BPIstartdate = sqldatenull.ToString();
            //}
            //if (ECIstartdate == "")
            //{
            //    ECIstartdate = sqldatenull.ToString();
            //}
            if (rowid == "")
            {
                query = @"INSERT INTO [dbo].[candComments]
           ([candidateid]
           ,[jobcode]           
           ,[TLComments]
           ,[TLRating]
           ,[TLcomgivenby]
           ,[TLcomgivenon]
           ,[TLcomgiventime]
           ,[TLupdategivenby]
           ,[TLupdategivenon]
           ,[TLupdategiventime]
           ,[BPComments]
           ,[BPcomgivenby]
           ,[BPcomgivenon]
           ,[BPcomgiventime]
           ,[BPupdategivenby]
           ,[BPupdategivenon]
           ,[BPupdategiventime]
           ,[BPIstartdate]
           ,[BPItime]
           ,[BPIcomgivenby]
           ,[BPIcomgivenon]
           ,[BPIcomgiventime]
           ,[BPIupdategivenby]
           ,[BPIupdategivenon]
           ,[BPIupdategiventime]
           ,[ECComments]
           ,[ECcomgivenby]
           ,[ECcomgivenon]
           ,[ECcomgiventime]
           ,[ECupdategivenby]
           ,[ECupdategivenon]
           ,[ECupdategiventime]
           ,[ECIstartdate]
           ,[ECItime]
           ,[ECIcomgivenby]
           ,[ECIcomgivenon]
           ,[ECIcomgiventime]
           ,[ECIupdategivenby]
           ,[ECIupdategivenon]
           ,[ECIupdategiventime])
     VALUES
           ('" + Userid
                   + "','" + Prjid
                    + "','" + TLComments
                    + "','" + TLRating
                    + "','" + TLcomgivenby
                    + "','" + dateTime_Eastern.ToString("yyyy-MM-dd")
                    + "','" + timeInEasternAsString
                    + "','" + TLupdategivenby
                    + "','" + dateTime_Eastern.ToString("yyyy-MM-dd")
                    + "','" + timeInEasternAsString
                    + "','" + BPComments
                    + "','" + BPcomgivenby
                    + "','" + dateTime_Eastern.ToString("yyyy-MM-dd")
                    + "','" + timeInEasternAsString
                    + "','" + BPupdategivenby
                    + "','" + dateTime_Eastern.ToString("yyyy-MM-dd")
                    + "','" + timeInEasternAsString
                    + "','" + BPIstartdate
                    + "','" + BPItime
                    + "','" + BPIcomgivenby
                    + "','" + dateTime_Eastern.ToString("yyyy-MM-dd")
                    + "','" + timeInEasternAsString
                    + "','" + BPIupdategivenby
                    + "','" + dateTime_Eastern.ToString("yyyy-MM-dd")
                    + "','" + timeInEasternAsString
                    + "','" + ECComments
                    + "','" + ECcomgivenby
                    + "','" + dateTime_Eastern.ToString("yyyy-MM-dd")
                    + "','" + timeInEasternAsString
                    + "','" + ECupdategivenby
                    + "','" + dateTime_Eastern.ToString("yyyy-MM-dd")
                    + "','" + timeInEasternAsString
                    + "','" + ECIstartdate
                    + "','" + ECItime
                    + "','" + ECIcomgivenby
                    + "','" + dateTime_Eastern.ToString("yyyy-MM-dd")
                    + "','" + timeInEasternAsString
                    + "','" + ECIupdategivenby
                    + "','" + dateTime_Eastern.ToString("yyyy-MM-dd")
                    + "','" + timeInEasternAsString + "')";
            }
            else
            {
                query = @"UPDATE [dbo].[candComments]
                           SET [TLComments] = '" + TLComments
                              + "',[TLRating] = '" + TLRating
                              + "',[TLcomgivenby] = '" + TLcomgivenby
                              + "',[TLcomgivenon] = '" + dateTime_Eastern.ToString("yyyy-MM-dd")
                              + "',[TLcomgiventime] = '" + timeInEasternAsString
                              + "',[TLupdategivenby] = '" + TLupdategivenby
                              + "',[TLupdategivenon] = '" + dateTime_Eastern.ToString("yyyy-MM-dd")
                              + "',[TLupdategiventime] = '" + TLupdategiventime
                              + "',[BPComments] = '" + BPComments
                              + "',[BPcomgivenby] = '" + BPcomgivenby
                              + "',[BPcomgivenon] = '" + dateTime_Eastern.ToString("yyyy-MM-dd")
                              + "',[BPcomgiventime] = '" + timeInEasternAsString
                              + "',[BPupdategivenby] = '" + BPupdategivenby
                              + "',[BPupdategivenon] = '" + dateTime_Eastern.ToString("yyyy-MM-dd")
                              + "',[BPupdategiventime] = '" + timeInEasternAsString
                              + "',[BPIstartdate] = '" + BPIstartdate
                              + "',[BPItime] = '" + BPItime
                              + "',[BPIcomgivenby] = '" + BPIcomgivenby
                              + "',[BPIcomgivenon] = '" + dateTime_Eastern.ToString("yyyy-MM-dd")
                              + "',[BPIcomgiventime] = '" + timeInEasternAsString
                              + "',[BPIupdategivenby] = '" + BPIupdategivenby
                              + "',[BPIupdategivenon] = '" + dateTime_Eastern.ToString("yyyy-MM-dd")
                              + "',[BPIupdategiventime] = '" + timeInEasternAsString
                              + "',[ECComments] = '" + ECComments
                              + "',[ECcomgivenby] = '" + ECcomgivenby
                              + "',[ECcomgivenon] = '" + dateTime_Eastern.ToString("yyyy-MM-dd")
                              + "',[ECcomgiventime] = '" + timeInEasternAsString
                              + "',[ECupdategivenby] = '" + ECupdategivenby
                              + "',[ECupdategivenon] = '" + dateTime_Eastern.ToString("yyyy-MM-dd")
                              + "',[ECupdategiventime] = '" + timeInEasternAsString
                              + "',[ECIstartdate] = '" + ECIstartdate
                              + "',[ECItime] = '" + ECItime
                              + "',[ECIcomgivenby] = '" + ECIcomgivenby
                              + "',[ECIcomgivenon] = '" + dateTime_Eastern.ToString("yyyy-MM-dd")
                              + "',[ECIcomgiventime] = '" + timeInEasternAsString
                              + "',[ECIupdategivenby] = '" + ECIupdategivenby
                              + "',[ECIupdategivenon] = '" + dateTime_Eastern.ToString("yyyy-MM-dd")
                              + "',[ECIupdategiventime] = '" + timeInEasternAsString
                             + "' WHERE candidateid='" + Userid + "' and jobcode='" + Prjid + "'";
            }

            _sql.doInsert(query);

            query = "update CandidateJob set Cand_Status='" + Candstatus + "' where candidateid='" + Userid + "' and jobcode='" + Prjid + "'";
            _sql.doInsert(query);

            jsonArray _json = new jsonArray();
            if (mode == 0)
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
                _json.data = "Saved";
            }

            return _json;

        }

        public jsonArray getCandfeedback(string jobId, string candid)
        {
            string query = "";

            candidateComments objComm = new candidateComments();

            query = @"select JobTitle,Duration,empl.EmpTypeName,
                    loc.LocationName,up.UP_firstName+' '+up.UP_lastName Empname, Convert(varchar,job.Created_On,106) Created_On,job.Created_Time,
                    availableforinterview,ratePerHr,JobstatusName,typ.TypeName,Jobimage
                    from CandidateDetails can
                    join CandidateJob canjob on canjob.CandidateId=can.candidateid
                    join Job_Master_USA job on canjob.jobcode=job.Jobcode
                    join EmploymentType_Master empl on job.EmplType=empl.EmpTypeID
                    join Location_Master loc on loc.LocationID=job.Location
                    join Type_Master typ on typ.TypeID=can.type
                    join Userprofile up on up.TWE_ID=job.Created_By
                    join Jobstatus_Master sta on sta.JobstatusID=job.Jobstatus" +
                    " where canjob.Jobcode='" + jobId + "' and can.candidateid='" + candid + "'";

            SqlDataReader _read = _sql.doRead(query);
            while (_read.Read())
            {

                objComm.jobtitle = _read[0].ToString();
                objComm.jobduration = _read[1].ToString();
                objComm.emplType = _read[2].ToString();
                objComm.joblocation = _read[3].ToString();
                objComm.jobcreatedBy = _read[4].ToString();
                objComm.jobcreatedOn = _read[5].ToString();
                objComm.jobcreatedTime = _read[6].ToString();
                objComm.availableforinterview = _read[7].ToString();
                objComm.ratePerHr = _read[8].ToString();
                objComm.jobstatus = _read[9].ToString();
                objComm.type = _read[10].ToString();
                objComm.jobimage = _read[11].ToString();
            }

            _read.Close();

            query = @"select candcommentid,canjob.candidateRemark,sta.CandidateStatusName,
                        up.UP_firstName+' '+up.UP_lastName RecCommcreby,
                        Convert(varchar,can.Created_On,106) Created_On,CreatedTime,
                        up1.UP_firstName+' ' +up1.UP_lastName RecCommupdby,
                        Convert(varchar,can.Last_Updated_On,106) Last_Updated_On,RecruiterRating,
                        cancom.TLComments,up2.UP_firstName+' '+up2.UP_lastName TLCommcreby,
                        Convert(varchar,TLcomgivenon,106) TLcomgivenon,TLcomgiventime,
                        up21.UP_firstName+' '+up21.UP_lastName TLCommupdby,
                        Convert(varchar,cancom.TLupdategivenon,106) TLupdategivenon,TLupdategiventime,cancom.TLRating,
                        BPIstartdate,BPItime,up6.UP_firstName+' '+up6.UP_lastName BPICommcreby,
                        Convert(varchar,BPIcomgivenon,106) BPIcomgivenon,BPIcomgiventime,
                        up61.UP_firstName+' '+up61.UP_lastName BPICommupdby,
                        Convert(varchar,cancom.BPIupdategivenon,106) BPIupdategivenon,BPIupdategiventime,
                        cancom.BPComments,up3.UP_firstName+' '+up3.UP_lastName BPCommcreby,
                        Convert(varchar,BPcomgivenon,106) BPcomgivenon,BPcomgiventime,
                        up31.UP_firstName+' '+up31.UP_lastName BPCommupdby,
                        Convert(varchar,cancom.BPupdategivenon,106) BPupdategivenon,BPupdategiventime,
                        ECIstartdate,ECItime,up7.UP_firstName+' '+up7.UP_lastName ECICommcreby,
                        Convert(varchar,ECIcomgivenon,106) ECIcomgivenon,ECIcomgiventime,
                        up71.UP_firstName+' '+up71.UP_lastName ECICommupdby,
                        Convert(varchar,cancom.ECIupdategivenon,106) ECIupdategivenon,ECIupdategiventime,
                        cancom.ECComments,up4.UP_firstName+' '+up4.UP_lastName ECCommcreby,
                        Convert(varchar,ECcomgivenon,106) ECcomgivenon,ECcomgiventime,
                        up41.UP_firstName+' '+up41.UP_lastName ECCommupdby,
                        Convert(varchar,cancom.ECupdategivenon,106) ECupdategivenon,ECupdategiventime,Cand_Status	
                        --cancom.CLComments,up5.UP_firstName+' '+up5.UP_lastName CLCommcreby,
                        --Convert(varchar,CLcomgivenon,106) CLcomgivenon,CLcomgiventime,
                        --up51.UP_firstName+' '+up51.UP_lastName CLCommupdby,
                        --Convert(varchar,cancom.CLupdategivenon,106) CLupdategivenon,CLupdategiventime,					
                        from  CandidateDetails can 
                        join CandidateJob canjob on can.candidateid=canjob.CandidateId
                        left join candComments cancom on can.candidateid=cancom.candidateid and canjob.jobcode=cancom.jobcode
                        join Userprofile up on up.TWE_ID=can.Created_By
                        join Userprofile up1 on up1.TWE_ID=can.Last_Updated_By
                        left join Userprofile up2 on up2.TWE_ID=cancom.TLcomgivenby
                        left join Userprofile up21 on up21.TWE_ID=cancom.TLupdategivenby
                        left join Userprofile up3 on up3.TWE_ID=cancom.BPcomgivenby
                        left join Userprofile up31 on up31.TWE_ID=cancom.BPupdategivenby
                        left join Userprofile up4 on up4.TWE_ID=cancom.ECcomgivenby
                        left join Userprofile up41 on up41.TWE_ID=cancom.ECupdategivenby
                        --left join Userprofile up5 on up5.TWE_ID=cancom.CLcomgivenby
                        --left join Userprofile up51 on up51.TWE_ID=cancom.CLupdategivenby
                        left join Userprofile up6 on up6.TWE_ID=cancom.BPIcomgivenby
                        left join Userprofile up61 on up61.TWE_ID=cancom.BPIupdategivenby
                        left join Userprofile up7 on up7.TWE_ID=cancom.ECIcomgivenby
                        left join Userprofile up71 on up71.TWE_ID=cancom.ECIupdategivenby
                        join CandidateStatus_Master sta on canjob.Cand_Status=sta.CandidateStatusID " +
                        " where canjob.Jobcode='" + jobId + "' and can.candidateid='" + candid + "'";


            _read = _sql.doRead(query);
            while (_read.Read())
            {

                objComm.candcommentid = _read[0].ToString();
                objComm.RecruiterComments = _read[1].ToString();
                objComm.candStatus = _read[2].ToString();
                objComm.createdBy = _read[3].ToString();
                objComm.createdOn = _read[4].ToString();
                objComm.createdTime = _read[5].ToString();
                objComm.lastupdatedBy = _read[6].ToString();
                objComm.lastupdatedOn = _read[7].ToString();
                objComm.recruiterrating = _read[8].ToString();
                objComm.TLComments = _read[9].ToString();
                objComm.TLcomgivenby = _read[10].ToString();
                objComm.TLcomgivenon = _read[11].ToString();
                objComm.TLcomgiventime = _read[12].ToString();
                objComm.TLcomupdatedby = _read[13].ToString();
                objComm.TLcomupdatedon = _read[14].ToString();
                objComm.TLcomupdatedtime = _read[15].ToString();
                objComm.TLRating = _read[16].ToString();
                if (!(_read[17].Equals(System.DBNull.Value)))
                {
                    objComm.BPIstartdate = Convert.ToDateTime(_read[17]).ToString("yyyy-MM-dd");
                }

                objComm.BPITime = _read[18].ToString();
                objComm.BPIcomgivenby = _read[19].ToString();
                objComm.BPIcomgivenon = _read[20].ToString();
                objComm.BPIcomgiventime = _read[21].ToString();
                objComm.BPIcomupdatedby = _read[22].ToString();
                objComm.BPIcomupdatedon = _read[23].ToString();
                objComm.BPIcomupdatedtime = _read[24].ToString();
                objComm.BPComments = _read[25].ToString();
                objComm.BPcomgivenby = _read[26].ToString();
                objComm.BPcomgivenon = _read[27].ToString();
                objComm.BPcomgiventime = _read[28].ToString();
                objComm.BPcomupdatedby = _read[29].ToString();
                objComm.BPcomupdatedon = _read[30].ToString();
                objComm.BPcomupdatedtime = _read[31].ToString();
                if (!(_read[32].Equals(System.DBNull.Value)))
                {
                    objComm.ECIstartdate = Convert.ToDateTime(_read[32]).ToString("yyyy-MM-dd");
                }

                objComm.ECITime = _read[33].ToString();
                objComm.ECIcomgivenby = _read[34].ToString();
                objComm.ECIcomgivenon = _read[35].ToString();
                objComm.ECIcomgiventime = _read[36].ToString();
                objComm.ECIcomupdatedby = _read[37].ToString();
                objComm.ECIcomupdatedon = _read[38].ToString();
                objComm.ECIcomupdatedtime = _read[39].ToString();
                objComm.ECComments = _read[40].ToString();
                objComm.ECcomgivenby = _read[41].ToString();
                objComm.ECcomgivenon = _read[42].ToString();
                objComm.ECcomgiventime = _read[43].ToString();
                objComm.ECcomupdatedby = _read[44].ToString();
                objComm.ECcomupdatedon = _read[45].ToString();
                objComm.ECcomupdatedtime = _read[46].ToString();
                //objComm.CLComments = _read[47].ToString();
                //objComm.CLcomgivenby = _read[48].ToString();
                //objComm.CLcomgivenon = _read[49].ToString();
                //objComm.CLcomgiventime = _read[50].ToString();
                //objComm.CLcomupdatedby = _read[51].ToString();
                //objComm.CLcomupdatedon = _read[52].ToString();
                //objComm.CLcomupdatedtime = _read[53].ToString();
                objComm.candstatusid = _read[47].ToString();

            }
            _read.Close();


            jsonArray _json = new jsonArray();
            int status = 1;
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
                _json.data = objComm;
            }

            return _json;
        }

        public jsonArray getfeedbackloadIndia(string Candid, string Jobid)
        {
            int status = 1;
            feedbackmaster _fbm = new feedbackmaster();
            List<assignedJob> _lstprj = new List<assignedJob>();
            feedbackdetails _fbd = new feedbackdetails();

            string strquery = "";
            strquery = @"select can.candidateid,candidatename,currentLocation,rateperhr,typ.TypeName
                        from CandidateDetailsIndia can
                        join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId
                        join RateType_Master typ on typ.TypeID=can.type where jobcode='" + Jobid + "' and can.candidateid='" + Candid + "'";

            SqlDataReader _read = _sql.doRead(strquery);
            while (_read.Read())
            {

                _fbm.profilepic = "";
                _fbm.id = _read[0].ToString();
                _fbm.name = _read[1].ToString();
                _fbm.location = _read[2].ToString();
                _fbd.rateperhr = _read[3].ToString();
                _fbd.type = _read[4].ToString();


            }
            _read.Close();

            strquery = @"select * from (
                            select (sum(convert(float, RecruiterRating)) / sum(5)) * 100  Neg_Feedback
                            from CandidateDetailsIndia can join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId where can.candidateid='" + Candid + "' and RecruiterRating<=3) tb1," +
                            "(select (sum(convert(float, RecruiterRating)) / sum(5)) * 100  Pos_Feedback" +
                            " from CandidateDetailsIndia can join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId where can.candidateid='" + Candid + "' and RecruiterRating>3)tb2";

            _read = _sql.doRead(strquery);
            while (_read.Read())
            {
                range _r = new range();
                _r.negativepercentage = _read[0].ToString();
                _r.positivepercentage = _read[1].ToString();
                _fbm.range = _r;
            }

            _read.Close();

            strquery = @"select Jobcode,JobTitle,Jobimage from Job_Master_IND
                        where Jobcode in
                        (select can.jobcode from CandidateJobIndia can where candidateid='" + Candid + "' and Cand_Status not in (101,102) and jobcode in" +
                       "(select Jobcode from Job_Master_IND))";


            _read = _sql.doRead(strquery);
            while (_read.Read())
            {
                assignedJob _prj = new assignedJob();
                _prj.name = _read[1].ToString();
                _prj.logo = _read[2].ToString();
                _prj.jobid = _read[0].ToString();
                _lstprj.Add(_prj);

            }
            _fbm.projects = _lstprj;

            _read.Close();

            //strquery = @"select Jobimage,JobTitle,Duration,EmplType,Location,Created_By,Created_On from Job_Master_USA where Jobcode='" + Prjid + "' and Assigned_To like '%" + Userid + "%'";

            //_read = _sql.doRead(strquery);
            //while (_read.Read())
            //{

            //    _fbd.logo = _read[0].ToString();
            //    _fbd.prjname = _read[1].ToString();
            //    _fbd.duration = _read[2].ToString();
            //    _fbd.type = _read[3].ToString();
            //    _fbd.worktype = _read[4].ToString();
            //    _fbd.createdby = _read[6].ToString();
            //    _fbd.createddate = _read[7].ToString();


            //}

            //_read.Close();

            //strquery = @"";

            //_read = _sql.doRead(strquery);
            //while (_read.Read())
            //{
            //    _fbd.trackprofile = "";
            //    _fbd.feedback = "";
            //    _fbd.interview = "";



            //}
            //_fbm.feedbackdetails = _fbd;

            //_read.Close();


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
                _json.data = _fbm;
            }


            return _json;
        }

        public jsonArray insertfeedbackIndia(string Userid, string Prjid, string rowid, string CLComments, string CLcomgivenby,
            string CLcomgivenon, string CLcomgiventime, string CLupdategivenby, string CLupdategivenon, string CLupdategiventime,
            string TLComments, string TLRating, string TLcomgivenby, string TLcomgivenon, string TLcomgiventime, string TLupdategivenby, string TLupdategivenon,
            string TLupdategiventime, string BPComments, string BPcomgivenby, string BPcomgivenon, string BPcomgiventime, string BPupdategivenby,
            string BPupdategivenon, string BPupdategiventime, string BPIstartdate, string BPItime, string BPIcomgivenby, string BPIcomgivenon,
            string BPIcomgiventime, string BPIupdategivenby, string BPIupdategivenon, string BPIupdategiventime, string ECComments,
            string ECcomgivenby, string ECcomgivenon, string ECcomgiventime, string ECupdategivenby, string ECupdategivenon, string ECupdategiventime,
            string ECIstartdate, string ECItime, string ECIcomgivenby, string ECIcomgivenon, string ECIcomgiventime, string ECIupdategivenby,
            string ECIupdategivenon, string ECIupdategiventime, string Candstatus)
        {
            SqlDateTime sqldatenull;
            sqldatenull = SqlDateTime.Null;
            int mode = 1;
            string query = "";
            //if (BPIstartdate=="")
            //{
            //    BPIstartdate = sqldatenull.ToString();
            //}
            //if (ECIstartdate == "")
            //{
            //    ECIstartdate = sqldatenull.ToString();
            //}

            //if (BPIstartdate!="")
            //{
            //    BPIstartdate = Convert.ToDateTime(BPIstartdate).ToString("yyyy-MM-dd");
            //}

            //if (ECIstartdate != "")
            //{
            //    ECIstartdate=Convert.ToDateTime(ECIstartdate).ToString("yyyy-MM-dd");
            //}

            DateTime dateTime_Indian = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));

            if (rowid == "")
            {

                query = @"INSERT INTO [dbo].[candCommentsIndia]
           ([candidateid]
           ,[jobcode]
           ,[TLComments]
           ,[TLRating]
           ,[TLcomgivenby]
           ,[TLcomgivenon]
           ,[TLcomgiventime]
           ,[TLupdategivenby]
           ,[TLupdategivenon]
           ,[TLupdategiventime]
           ,[BPComments]
           ,[BPcomgivenby]
           ,[BPcomgivenon]
           ,[BPcomgiventime]
           ,[BPupdategivenby]
           ,[BPupdategivenon]
           ,[BPupdategiventime]
           ,[BPIstartdate]
           ,[BPItime]
           ,[BPIcomgivenby]
           ,[BPIcomgivenon]
           ,[BPIcomgiventime]
           ,[BPIupdategivenby]
           ,[BPIupdategivenon]
           ,[BPIupdategiventime]
           ,[ECComments]
           ,[ECcomgivenby]
           ,[ECcomgivenon]
           ,[ECcomgiventime]
           ,[ECupdategivenby]
           ,[ECupdategivenon]
           ,[ECupdategiventime]
           ,[ECIstartdate]
           ,[ECItime]
           ,[ECIcomgivenby]
           ,[ECIcomgivenon]
           ,[ECIcomgiventime]
           ,[ECIupdategivenby]
           ,[ECIupdategivenon]
           ,[ECIupdategiventime])
     VALUES
           ('" + Userid
                   + "','" + Prjid
                    + "','" + TLComments
                    + "','" + TLRating
                    + "','" + TLcomgivenby
                    + "','" + dateTime_Indian.ToString("yyyy-MM-dd")
                    + "','" + dateTime_Indian.ToString("hh:mm tt", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                    + "','" + TLupdategivenby
                    + "','" + dateTime_Indian.ToString("yyyy-MM-dd")
                    + "','" + dateTime_Indian.ToString("hh:mm tt", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                    + "','" + BPComments
                    + "','" + BPcomgivenby
                    + "','" + dateTime_Indian.ToString("yyyy-MM-dd")
                    + "','" + dateTime_Indian.ToString("hh:mm tt", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                    + "','" + BPupdategivenby
                    + "','" + dateTime_Indian.ToString("yyyy-MM-dd")
                    + "','" + dateTime_Indian.ToString("hh:mm tt", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                    + "','" + BPIstartdate
                    + "','" + BPItime
                    + "','" + BPIcomgivenby
                    + "','" + dateTime_Indian.ToString("yyyy-MM-dd")
                    + "','" + dateTime_Indian.ToString("hh:mm tt", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                    + "','" + BPIupdategivenby
                    + "','" + dateTime_Indian.ToString("yyyy-MM-dd")
                    + "','" + dateTime_Indian.ToString("hh:mm tt", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                    + "','" + ECComments
                    + "','" + ECcomgivenby
                    + "','" + dateTime_Indian.ToString("yyyy-MM-dd")
                    + "','" + dateTime_Indian.ToString("hh:mm tt", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                    + "','" + ECupdategivenby
                    + "','" + dateTime_Indian.ToString("yyyy-MM-dd")
                    + "','" + dateTime_Indian.ToString("hh:mm tt", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                    + "','" + ECIstartdate
                    + "','" + ECItime
                    + "','" + ECIcomgivenby
                    + "','" + dateTime_Indian.ToString("yyyy-MM-dd")
                    + "','" + dateTime_Indian.ToString("hh:mm tt", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                    + "','" + ECIupdategivenby
                    + "','" + dateTime_Indian.ToString("yyyy-MM-dd")
                    + "','" + dateTime_Indian.ToString("hh:mm tt", System.Globalization.DateTimeFormatInfo.InvariantInfo) + "')";
            }
            else
            {
                query = @"UPDATE [dbo].[candCommentsIndia]
                           SET [TLComments] = '" + TLComments
                              + "',[TLRating] = '" + TLRating
                              + "',[TLcomgivenby] = '" + TLcomgivenby
                              + "',[TLcomgivenon] = '" + dateTime_Indian.ToString("yyyy-MM-dd")
                              + "',[TLcomgiventime] = '" + dateTime_Indian.ToString("hh:mm tt", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                              + "',[TLupdategivenby] = '" + TLupdategivenby
                              + "',[TLupdategivenon] = '" + dateTime_Indian.ToString("yyyy-MM-dd")
                              + "',[TLupdategiventime] = '" + TLupdategiventime
                              + "',[BPComments] = '" + BPComments
                              + "',[BPcomgivenby] = '" + BPcomgivenby
                              + "',[BPcomgivenon] = '" + dateTime_Indian.ToString("yyyy-MM-dd")
                              + "',[BPcomgiventime] = '" + dateTime_Indian.ToString("hh:mm tt", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                              + "',[BPupdategivenby] = '" + BPupdategivenby
                              + "',[BPupdategivenon] = '" + dateTime_Indian.ToString("yyyy-MM-dd")
                              + "',[BPupdategiventime] = '" + dateTime_Indian.ToString("hh:mm tt", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                              + "',[BPIstartdate] = '" + Convert.ToDateTime(BPIstartdate).ToString("yyyy-MM-dd")
                              + "',[BPItime] = '" + BPItime
                              + "',[BPIcomgivenby] = '" + BPIcomgivenby
                              + "',[BPIcomgivenon] = '" + dateTime_Indian.ToString("yyyy-MM-dd")
                              + "',[BPIcomgiventime] = '" + dateTime_Indian.ToString("hh:mm tt", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                              + "',[BPIupdategivenby] = '" + BPIupdategivenby
                              + "',[BPIupdategivenon] = '" + dateTime_Indian.ToString("yyyy-MM-dd")
                              + "',[BPIupdategiventime] = '" + dateTime_Indian.ToString("hh:mm tt", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                              + "',[ECComments] = '" + ECComments
                              + "',[ECcomgivenby] = '" + ECcomgivenby
                              + "',[ECcomgivenon] = '" + dateTime_Indian.ToString("yyyy-MM-dd")
                              + "',[ECcomgiventime] = '" + dateTime_Indian.ToString("hh:mm tt", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                              + "',[ECupdategivenby] = '" + ECupdategivenby
                              + "',[ECupdategivenon] = '" + dateTime_Indian.ToString("yyyy-MM-dd")
                              + "',[ECupdategiventime] = '" + dateTime_Indian.ToString("hh:mm tt", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                              + "',[ECIstartdate] = '" + Convert.ToDateTime(ECIstartdate).ToString("yyyy-MM-dd")
                              + "',[ECItime] = '" + ECItime
                              + "',[ECIcomgivenby] = '" + ECIcomgivenby
                              + "',[ECIcomgivenon] = '" + dateTime_Indian.ToString("yyyy-MM-dd")
                              + "',[ECIcomgiventime] = '" + dateTime_Indian.ToString("hh:mm tt", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                              + "',[ECIupdategivenby] = '" + ECIupdategivenby
                              + "',[ECIupdategivenon] = '" + dateTime_Indian.ToString("yyyy-MM-dd")
                              + "',[ECIupdategiventime] = '" + dateTime_Indian.ToString("hh:mm tt", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                             + "' WHERE candidateid='" + Userid + "' and jobcode='" + Prjid + "'";
            }

            _sql.doInsert(query);

            query = "update CandidateJobIndia set Cand_Status='" + Candstatus + "' where candidateid='" + Userid + "' and jobcode='" + Prjid + "'";
            _sql.doInsert(query);

            jsonArray _json = new jsonArray();
            if (mode == 0)
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
                _json.data = "Saved";
            }

            return _json;

        }

        public jsonArray getCandfeedbackIndia(string jobId, string candid)
        {
            string query = "";

            candidateComments objComm = new candidateComments();

            query = @"select JobTitle,Duration,empl.EmpTypeName,
                    loc.LocationName,up.UP_firstName+' '+up.UP_lastName Empname, Convert(varchar,job.Created_On,106) Created_On,job.Created_Time,
                    availableforinterview,ratePerHr,JobstatusName,typ.TypeName,Jobimage
                    from CandidateDetailsIndia can
                    join CandidateJobIndia canjob on canjob.CandidateId=can.candidateid
                    join Job_Master_IND job on canjob.jobcode=job.Jobcode
                    join EmploymentType_Master empl on job.EmplType=empl.EmpTypeID
                    join Location_Master loc on loc.LocationID=job.Location
                    join RateType_Master typ on typ.TypeID=can.type
                    join Userprofile up on up.TWE_ID=job.Created_By
                    join Jobstatus_Master sta on sta.JobstatusID=job.Jobstatus" +
                    " where canjob.Jobcode='" + jobId + "' and can.candidateid='" + candid + "'";

            SqlDataReader _read = _sql.doRead(query);
            while (_read.Read())
            {

                objComm.jobtitle = _read[0].ToString();
                objComm.jobduration = _read[1].ToString();
                objComm.emplType = _read[2].ToString();
                objComm.joblocation = _read[3].ToString();
                objComm.jobcreatedBy = _read[4].ToString();
                objComm.jobcreatedOn = _read[5].ToString();
                objComm.jobcreatedTime = _read[6].ToString();
                objComm.availableforinterview = _read[7].ToString();
                objComm.ratePerHr = _read[8].ToString();
                objComm.jobstatus = _read[9].ToString();
                objComm.type = _read[10].ToString();
                objComm.jobimage = _read[11].ToString();
            }

            _read.Close();

            query = @"select candcommentid,canjob.candidateRemark,sta.CandidateStatusName,
                        up.UP_firstName+' '+up.UP_lastName RecCommcreby,
                        Convert(varchar,can.Created_On,106) Created_On,CreatedTime,
                        up1.UP_firstName+' ' +up1.UP_lastName RecCommupdby,
                        Convert(varchar,can.Last_Updated_On,106) Last_Updated_On,RecruiterRating,
                        cancom.TLComments,up2.UP_firstName+' '+up2.UP_lastName TLCommcreby,
                        Convert(varchar,TLcomgivenon,106) TLcomgivenon,TLcomgiventime,
                        up21.UP_firstName+' '+up21.UP_lastName TLCommupdby,
                        Convert(varchar,cancom.TLupdategivenon,106) TLupdategivenon,TLupdategiventime,cancom.TLRating,
                        BPIstartdate,BPItime,up6.UP_firstName+' '+up6.UP_lastName BPICommcreby,
                        Convert(varchar,BPIcomgivenon,106) BPIcomgivenon,BPIcomgiventime,
                        up61.UP_firstName+' '+up61.UP_lastName BPICommupdby,
                        Convert(varchar,cancom.BPIupdategivenon,106) BPIupdategivenon,BPIupdategiventime,
                        cancom.BPComments,up3.UP_firstName+' '+up3.UP_lastName BPCommcreby,
                        Convert(varchar,BPcomgivenon,106) BPcomgivenon,BPcomgiventime,
                        up31.UP_firstName+' '+up31.UP_lastName BPCommupdby,
                        Convert(varchar,cancom.BPupdategivenon,106) BPupdategivenon,BPupdategiventime,
                        ECIstartdate,ECItime,up7.UP_firstName+' '+up7.UP_lastName ECICommcreby,
                        Convert(varchar,ECIcomgivenon,106) ECIcomgivenon,ECIcomgiventime,
                        up71.UP_firstName+' '+up71.UP_lastName ECICommupdby,
                        Convert(varchar,cancom.ECIupdategivenon,106) ECIupdategivenon,ECIupdategiventime,
                        cancom.ECComments,up4.UP_firstName+' '+up4.UP_lastName ECCommcreby,
                        Convert(varchar,ECcomgivenon,106) ECcomgivenon,ECcomgiventime,
                        up41.UP_firstName+' '+up41.UP_lastName ECCommupdby,
                        Convert(varchar,cancom.ECupdategivenon,106) ECupdategivenon,ECupdategiventime,Cand_Status						
                        from  CandidateDetailsIndia can 
                        join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId
                        left join candCommentsIndia cancom on can.candidateid=cancom.candidateid and canjob.jobcode=cancom.jobcode
                        join Userprofile up on up.TWE_ID=can.Created_By
                        join Userprofile up1 on up1.TWE_ID=can.Last_Updated_By
                        left join Userprofile up2 on up2.TWE_ID=cancom.TLcomgivenby
                        left join Userprofile up21 on up21.TWE_ID=cancom.TLupdategivenby
                        left join Userprofile up3 on up3.TWE_ID=cancom.BPcomgivenby
                        left join Userprofile up31 on up31.TWE_ID=cancom.BPupdategivenby
                        left join Userprofile up4 on up4.TWE_ID=cancom.ECcomgivenby
                        left join Userprofile up41 on up41.TWE_ID=cancom.ECupdategivenby
                        left join Userprofile up6 on up6.TWE_ID=cancom.BPIcomgivenby
                        left join Userprofile up61 on up61.TWE_ID=cancom.BPIupdategivenby
                        left join Userprofile up7 on up7.TWE_ID=cancom.ECIcomgivenby
                        left join Userprofile up71 on up71.TWE_ID=cancom.ECIupdategivenby
                        join CandidateStatus_Master sta on canjob.Cand_Status=sta.CandidateStatusID " +
                        " where canjob.Jobcode='" + jobId + "' and can.candidateid='" + candid + "'";


            _read = _sql.doRead(query);
            while (_read.Read())
            {

                objComm.candcommentid = _read[0].ToString();
                objComm.RecruiterComments = _read[1].ToString();
                objComm.candStatus = _read[2].ToString();
                objComm.createdBy = _read[3].ToString();
                objComm.createdOn = _read[4].ToString();
                objComm.createdTime = _read[5].ToString();
                objComm.lastupdatedBy = _read[6].ToString();
                objComm.lastupdatedOn = _read[7].ToString();
                objComm.recruiterrating = _read[8].ToString();
                objComm.TLComments = _read[9].ToString();
                objComm.TLcomgivenby = _read[10].ToString();
                objComm.TLcomgivenon = _read[11].ToString();
                objComm.TLcomgiventime = _read[12].ToString();
                objComm.TLcomupdatedby = _read[13].ToString();
                objComm.TLcomupdatedon = _read[14].ToString();
                objComm.TLcomupdatedtime = _read[15].ToString();
                objComm.TLRating = _read[16].ToString();
                if (!(_read[17].Equals(System.DBNull.Value)))
                {
                    objComm.BPIstartdate = Convert.ToDateTime(_read[17]).ToString("yyyy-MM-dd");
                }

                objComm.BPITime = _read[18].ToString();
                objComm.BPIcomgivenby = _read[19].ToString();
                objComm.BPIcomgivenon = _read[20].ToString();
                objComm.BPIcomgiventime = _read[21].ToString();
                objComm.BPIcomupdatedby = _read[22].ToString();
                objComm.BPIcomupdatedon = _read[23].ToString();
                objComm.BPIcomupdatedtime = _read[24].ToString();
                objComm.BPComments = _read[25].ToString();
                objComm.BPcomgivenby = _read[26].ToString();
                objComm.BPcomgivenon = _read[27].ToString();
                objComm.BPcomgiventime = _read[28].ToString();
                objComm.BPcomupdatedby = _read[29].ToString();
                objComm.BPcomupdatedon = _read[30].ToString();
                objComm.BPcomupdatedtime = _read[31].ToString();
                if (!(_read[32].Equals(System.DBNull.Value)))
                {
                    objComm.ECIstartdate = Convert.ToDateTime(_read[32]).ToString("yyyy-MM-dd");
                }

                objComm.ECITime = _read[33].ToString();
                objComm.ECIcomgivenby = _read[34].ToString();
                objComm.ECIcomgivenon = _read[35].ToString();
                objComm.ECIcomgiventime = _read[36].ToString();
                objComm.ECIcomupdatedby = _read[37].ToString();
                objComm.ECIcomupdatedon = _read[38].ToString();
                objComm.ECIcomupdatedtime = _read[39].ToString();
                objComm.ECComments = _read[40].ToString();
                objComm.ECcomgivenby = _read[41].ToString();
                objComm.ECcomgivenon = _read[42].ToString();
                objComm.ECcomgiventime = _read[43].ToString();
                objComm.ECcomupdatedby = _read[44].ToString();
                objComm.ECcomupdatedon = _read[45].ToString();
                objComm.ECcomupdatedtime = _read[46].ToString();
                //objComm.CLComments = _read[47].ToString();
                //objComm.CLcomgivenby = _read[48].ToString();
                //objComm.CLcomgivenon = _read[49].ToString();
                //objComm.CLcomgiventime = _read[50].ToString();
                //objComm.CLcomupdatedby = _read[51].ToString();
                //objComm.CLcomupdatedon = _read[52].ToString();
                //objComm.CLcomupdatedtime = _read[53].ToString();
                objComm.candstatusid = _read[47].ToString();

            }
            _read.Close();


            jsonArray _json = new jsonArray();
            int status = 1;
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
                _json.data = objComm;
            }

            return _json;
        }


        //public jsonArray getDownloadfeedback(string fileName)
        //{
        //    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);

        //    //Set the File Path.
        //    string filePath = HttpContext.Current.Server.MapPath("~/Files/") + fileName;

        //    //Check whether File exists.
        //    if (!File.Exists(filePath))
        //    {
        //        //Throw 404 (Not Found) exception if File not found.
        //        response.StatusCode = HttpStatusCode.NotFound;
        //        response.ReasonPhrase = string.Format("File not found: {0} .", fileName);
        //        throw new HttpResponseException(response);
        //    }

        //    //Read the File into a Byte Array.
        //    byte[] bytes = File.ReadAllBytes(filePath);

        //    //Set the Response Content.
        //    response.Content = new ByteArrayContent(bytes);

        //    //Set the Response Content Length.
        //    response.Content.Headers.ContentLength = bytes.LongLength;

        //    //Set the Content Disposition Header Value and FileName.
        //    response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
        //    response.Content.Headers.ContentDisposition.FileName = fileName;

        //    //Set the File Content Type.
        //    response.Content.Headers.ContentType = new MediaTypeHeaderValue(MimeMapping.GetMimeMapping(fileName));
        //    return response;
        //}

        /**Config Table**/

        public jsonArray insertmaster(string Fieldname, string Status, string Mastertype, string mode, string rowid)
        {

            int status = 1;
            string str = "";

            string strquery = "";
            if (mode == "I")
            {
                if (Mastertype == "Currency")
                    strquery = @"insert into Currency_Master (CurrencyName,Status) values('" + Fieldname + "'," + Status + ")";
                else if (Mastertype == "Role")
                    strquery = @"insert into RoleMaster (Rolename,Status) values('" + Fieldname + "'," + Status + ")";
                else if (Mastertype == "Employmenttype")
                    strquery = @"insert into EmploymentType_Master (EmpTypeName,Status) values('" + Fieldname + "'," + Status + ")";
                else if (Mastertype == "Image")
                    strquery = @"insert into Image_mstr (Image_name,Image_path,status) values('','" + Fieldname + "'," + Status + ")";
                else if (Mastertype == "Jobstatus")
                    strquery = @"insert into Jobstatus_Master (JobstatusName,Status) values('" + Fieldname + "'," + Status + ")";
                else if (Mastertype == "Level")
                    strquery = @"insert into Level_Master (Levelname,Status) values('" + Fieldname + "'," + Status + ")";
                else if (Mastertype == "Location")
                    strquery = @"insert into Location_Master (LocationName,Status) values('" + Fieldname + "'," + Status + ")";
                else if (Mastertype == "Mail")
                    strquery = @"insert into Mailid_Master (mail_key,mail_id,Status) values('Admin','" + Fieldname + "'," + Status + ")";
                else if (Mastertype == "Skill")
                    strquery = @"insert into Skill_Master (SkillName,Status) values('" + Fieldname + "'," + Status + ")";
                else if (Mastertype == "Priority")
                    strquery = @"insert into Priority_Master (PriorityName,status) values('" + Fieldname + "'," + Status + ")";
                else if (Mastertype == "Region")
                    strquery = @"insert into Region_Master (Regionname,Status) values('" + Fieldname + "'," + Status + ")";
                else if (Mastertype == "Designation")
                    strquery = @"insert into Designation_Master (Designationname,Status) values('" + Fieldname + "'," + Status + ")";
                else if (Mastertype == "Specialization")
                    strquery = @"insert into Specialization_Master (SpecilaizationName,Status) values('" + Fieldname + "'," + Status + ")";
                else if (Mastertype == "Worktype")
                    strquery = @"insert into Type_Master (TypeName,Status) values('" + Fieldname + "'," + Status + ")";
                else if (Mastertype == "Candidatestatus")
                    strquery = @"insert into CandidateStatus_Master (CandidateStatusName,Status) values('" + Fieldname + "'," + Status + ")";               

                str = Mastertype + "  Insert";
            }
            else if (mode == "U")
            {
                if (Mastertype == "Currency")
                    strquery = @"update Currency_Master set CurrencyName='" + Fieldname + "',Status='" + Status + "' where CurrencyID='" + rowid + "'";
                else if (Mastertype == "Role")
                    strquery = @"update RoleMaster set Rolename='" + Fieldname + "',Status='" + Status + "' where Roleid='" + rowid + "'";
                else if (Mastertype == "Employmenttype")
                    strquery = @"update EmploymentType_Master set EmpTypeName='" + Fieldname + "',Status='" + Status + "' where EmpTypeID='" + rowid + "'";
                else if (Mastertype == "Image")
                    strquery = @"update Image_mstr set Image_name='',Image_path='" + Fieldname + "',status='" + Status + "' where Image_id='" + rowid + "'";
                else if (Mastertype == "Jobstatus")
                    strquery = @"update Jobstatus_Master set JobstatusName='" + Fieldname + "',status='" + Status + "' where JobstatusID='" + rowid + "'";
                else if (Mastertype == "Level")
                    strquery = @"update Level_Master set Levelname='" + Fieldname + "',Status='" + Status + "' where Levelid='" + rowid + "'";
                else if (Mastertype == "Location")
                    strquery = @"update Location_Master set LocationName='" + Fieldname + "',Status='" + Status + "' where LocationID='" + rowid + "'";
                else if (Mastertype == "Mail")
                    strquery = @"update Mailid_Master set mail_id='" + Fieldname + "',Status='" + Status + "' where mailmstr_id=" + rowid + "";
                else if (Mastertype == "Skill")
                    strquery = @"update Skill_Master set SkillName='" + Fieldname + "',Status='" + Status + "' where SkillID='" + rowid + "'";
                else if (Mastertype == "Priority")
                    strquery = @"update Priority_Master set PriorityName='" + Fieldname + "',Status='" + Status + "' where PriorityID='" + rowid + "'";
                else if (Mastertype == "Region")
                    strquery = @"update Region_Master set Regionname='" + Fieldname + "',Status='" + Status + "' where Regionid='" + rowid + "'";
                else if (Mastertype == "Designation")
                    strquery = @"update Designation_Master set Designationname='" + Fieldname + "',Status='" + Status + "' where Designationid='" + rowid + "'";
                else if (Mastertype == "Specialization")
                    strquery = @"update Specialization_Master set SpecilaizationName='" + Fieldname + "',status='" + Status + "' where SpecilaizationID='" + rowid + "'";
                else if (Mastertype == "Worktype")
                    strquery = @"update Type_Master set TypeName='" + Fieldname + "',Status='" + Status + "' where TypeID='" + rowid + "'";
                else if (Mastertype == "Candidatestatus")
                    strquery = @"update CandidateStatus_Master set CandidateStatusName='" + Fieldname + "',Status='" + Status + "' where CandidateStatusID='" + rowid + "'";

                str = Mastertype + "  Updated";
            }
            else if (mode == "D")
            {
                if (Mastertype == "Currency")
                    strquery = @"update Currency_Master set Status='" + Status + "' where CurrencyID='" + rowid + "'";
                else if (Mastertype == "Role")
                    strquery = @"update RoleMaster set Status='" + Status + "' where Roleid='" + rowid + "'";
                else if (Mastertype == "Employmenttype")
                    strquery = @"update EmploymentType_Master set Status='" + Status + "' where EmpTypeID='" + rowid + "'";
                else if (Mastertype == "Image")
                    strquery = @"update Image_mstr status='" + Status + "' where Image_id='" + rowid + "'";
                else if (Mastertype == "Jobstatus")
                    strquery = @"update Jobstatus_Master set Status='" + Status + "' where JobstatusID='" + rowid + "'";
                else if (Mastertype == "Level")
                    strquery = @"update Level_Master set Status='" + Status + "' where Levelid='" + rowid + "'";
                else if (Mastertype == "Location")
                    strquery = @"update Location_Master set Status='" + Status + "' where LocationID='" + rowid + "'";
                else if (Mastertype == "Mail")
                    strquery = @"update Mailid_Master set Status='" + Status + "' where mailmstr_id='" + rowid + "'";
                else if (Mastertype == "Skill")
                    strquery = @"update Skill_Master set Status='" + Status + "' where SkillID='" + rowid + "'";
                else if (Mastertype == "Priority")
                    strquery = @"update Priority_Master set Status='" + Status + "' where PriorityID='" + rowid + "'";
                else if (Mastertype == "Region")
                    strquery = @"update Region_Master set Status='" + Status + "' where Regionid='" + rowid + "'";
                else if (Mastertype == "Designation")
                    strquery = @"update Designation_Master set Status='" + Status + "' where Designationid='" + rowid + "'";
                else if (Mastertype == "Specialization")
                    strquery = @"update Specialization_Master set Status='" + Status + "' where SpecilaizationID='" + rowid + "'";
                else if (Mastertype == "Worktype")
                    strquery = @"update Type_Master set Status='" + Status + "' where TypeID='" + rowid + "'";
                else if (Mastertype == "Candidatestatus")
                    strquery = @"update CandidateStatus_Master set Status='" + Status + "' where CandidateStatusID='" + rowid + "'";

                str = Mastertype + "  Deleted";
            }
            status = _sql.doInsert(strquery);

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
                _json.message = str;
                _json.data = "Success";
            }


            return _json;
        }

        public jsonArray viewmaster(string Mastertype)
        {
            int status = 1;

            List<master> lstMst = new List<master>();

            string strquery = "";
            if (Mastertype == "Currency")
                strquery = @"select CurrencyID,CurrencyName,Status from Currency_Master where Status!=2";
            else if (Mastertype == "Role")
                strquery = @"select Roleid,Rolename,Status from RoleMaster where Status!=2";
            else if (Mastertype == "Employmenttype")
                strquery = @"select EmpTypeID,EmpTypeName,Status from EmploymentType_Master where Status!=2";
            else if (Mastertype == "Image")
                strquery = @"select Image_id,Image_name,Image_path,status from Image_mstr where status!=2";
            else if (Mastertype == "Jobstatus")
                strquery = @"select JobstatusID,JobstatusName,Status from Jobstatus_Master where Status!=2";
            else if (Mastertype == "Level")
                strquery = @"select Levelid,Levelname,Status from Level_Master where Status!=2";
            else if (Mastertype == "Location")
                strquery = @"select LocationID,LocationName,Status from Location_Master where Status!=2";
            else if (Mastertype == "Mail")
                strquery = @"select mailmstr_id,mail_id,Status from Mailid_Master where Status!=2";
            else if (Mastertype == "Skill")
                strquery = @"select SkillID,SkillName,Status from Skill_Master where Status!=2";
            else if (Mastertype == "Priority")
                strquery = @"select PriorityID,PriorityName,Status from Priority_Master where Status!=2";
            else if (Mastertype == "Region")
                strquery = @"select Regionid,Regionname,Status from Region_Master where Status!=2";
            else if (Mastertype == "Designation")
                strquery = @"select Designationid,Designationname,Status from Designation_Master where Status!=2";
            else if (Mastertype == "Specialization")
                strquery = @"select SpecilaizationID,SpecilaizationName,status from Specialization_Master where Status!=2";
            else if (Mastertype == "Worktype")
                strquery = @"select TypeID,TypeName,Status from Type_Master where Status!=2";
            else if (Mastertype == "Candidatestatus")
                strquery = @"select CandidateStatusID,CandidateStatusName,Status from CandidateStatus_Master where Status!=2";


            SqlDataReader _read = _sql.doRead(strquery);
            while (_read.Read())
            {
                master _mt = new master();
                if (Mastertype == "Mail" || Mastertype == "Image")
                {
                    _mt.masterid = _read[0].ToString();
                    _mt.mastername = _read[1].ToString();
                    _mt.masterdetaila = "";
                    _mt.masterstatus = _read[2].ToString();
                }
                else
                {
                    _mt.masterid = _read[0].ToString();
                    _mt.mastername = _read[1].ToString();
                    _mt.masterdetaila = "";
                    _mt.masterstatus = _read[2].ToString();
                }
                lstMst.Add(_mt);

            }
            _read.Close();

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
                _json.data = lstMst;
            }


            return _json;
        }


        public jsonArray insertaccessmenu(string userid, string menuid, string jobcreate, string jobedit, string jobview, string jobdelete,
           string vendorcreate, string vendoredit, string vendorview, string vendordelete, string candidatecreate, string candidateedit,
           string candidateview, string candidatedelete, string rowstatus, string mode)
        {

            int status = 1;
            string str = "";

            string strquery = "";
            if (mode == "I")
            {
                for (int i = 0; i < 3; i++)
                {
                    if (i == 0)
                    {
                        strquery = @"insert into Usermenuacess (userid,menutype,addprofile,viewprofile,editprofile,deleteprofile,status) values('" + userid + "','" + menuid + "','" + jobcreate + "','" + jobview + "','" + jobedit + "','" + jobdelete + "','" + rowstatus + "')";

                    }
                    else if (i == 1)
                    {
                        strquery = @"insert into Usermenuacess (userid,menutype,addprofile,viewprofile,editprofile,deleteprofile,status) values('" + userid + "','" + menuid + "','" + vendorcreate + "','" + vendorview + "','" + vendoredit + "','" + vendordelete + "','" + rowstatus + "')";

                    }
                    else if (i == 2)
                    {
                        strquery = @"insert into Usermenuacess (userid,menutype,addprofile,viewprofile,editprofile,deleteprofile,status) values('" + userid + "','" + menuid + "','" + candidatecreate + "','" + candidateview + "','" + candidateedit + "','" + candidatedelete + "','" + rowstatus + "')";

                    }

                    status = _sql.doInsert(strquery);
                }
                str = "Query Insert";
            }
            else if (mode == "U")
            {


                for (int i = 0; i < 3; i++)
                {
                    if (i == 0)
                    {
                        strquery = @"update Usermenuacess set addprofile='" + jobcreate + "',viewprofile='" + jobview + "',editprofile='" + jobedit + "',deleteprofile='" + jobdelete + "',status='" + rowstatus + "' where userid='" + userid + "'and menutype='" + menuid + "'";

                    }
                    else if (i == 1)
                    {
                        strquery = @"update Usermenuacess set addprofile='" + vendorcreate + "',viewprofile='" + vendorview + "',editprofile='" + vendoredit + "',deleteprofile='" + vendordelete + "',status='" + rowstatus + "' where userid='" + userid + "'and menutype='" + menuid + "'";

                    }
                    else if (i == 2)
                    {
                        strquery = @"update Usermenuacess set addprofile='" + candidatecreate + "',viewprofile='" + candidateview + "',editprofile='" + candidateedit + "',deleteprofile='" + candidatedelete + "',status='" + rowstatus + "' where userid='" + userid + "'and menutype='" + menuid + "'";

                    }

                    status = _sql.doInsert(strquery);
                }
                str = " Query Updated";
            }



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
                _json.message = str;
                _json.data = "SQL QUERY EXECUTED";
            }


            return _json;
        }

        public jsonArray insertvendor(string vendorname, string website, string linkedin, string specilization,string remarks, string address, string city,
                                      string country, List<vendorcontact> recruiter, string rowstatus, string mode, string vendorid, string createdon,
                                      string createdby, string updatedon, string updatedby,string vendortype)
        {

            int status = 1;
            string str = "";

            DateTime dateTime_Eastern = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));
            //var timeInEST = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));
            //var timeInEasternAsString = timeInEST.ToString("hh:mm tt", CultureInfo.InvariantCulture);

            string strquery = "";

            if (mode == "I")
            {
                strquery = @"insert into EmployerDetails(employercorporationaname,website,linkedin,employerspecialization,employeradditionalinfo,address,city,country,Created_On,Created_By,Status,vendortype) values('" + vendorname + "','" + website + "','" + linkedin + "','" + specilization + "','" + remarks + "','" + address + "','" + city + "','" + country + "','" + dateTime_Eastern.ToString("yyyy-MM-dd") + "','" + createdby + "'," + rowstatus + ",'" + vendortype + "')";

                status = _sql.doInsert(strquery);

                strquery = @"select max(employerid) employerid from EmployerDetails";

                SqlDataReader _read = _sql.doRead(strquery);
                while (_read.Read())
                {
                    vendorid = _read[0].ToString();
                }
                _read.Close();

                for (int i = 0; i < recruiter.Count; i++)
                {
                    if (recruiter[i].mode == "")
                    {
                        strquery = @"insert into EmployerContactPerson (" +
                                    "ContactPerson,ContactNo,MailId,Designation,VendorID,VenConStatus) values('" +
                                    recruiter[i].contactname + "','" + recruiter[i].employermobileno + "','" +
                                    recruiter[i].employeremailid + "','" + recruiter[i].employerremarks + "'," + vendorid + ",'1')";
                    }
                    
                    _sql.doInsert(strquery);
                }
                str = "Query Insert";
            }
            else if (mode == "U")
            {
                strquery = @"update EmployerDetails set employercorporationaname='" + vendorname + "',website='" +
                                website + "',linkedin='" + linkedin + "',employerspecialization='" + specilization +"',employeradditionalinfo='" + remarks +
                                "',address='" + address + "',city='" + city + "',vendortype='" + vendortype+ "',country='" + country + "',Updated_On='"
                                + dateTime_Eastern.ToString("yyyy-MM-dd") + "',Updated_By='" + updatedby + "',status='" + status + "' where employerid='" + vendorid + "'";

                status = _sql.doInsert(strquery); 

                for (int i = 0; i < recruiter.Count; i++)
                {
                    if (recruiter[i].mode == "I")
                    {
                        strquery = @"insert into EmployerContactPerson (" +
                                    "ContactPerson,ContactNo,MailId,Designation,VendorID,VenConStatus) values('" +
                                    recruiter[i].contactname + "','" + recruiter[i].employermobileno + "','" +
                                    recruiter[i].employeremailid + "','" + recruiter[i].employerremarks + "'," + vendorid + ",'1')";
                    }
                    else if (recruiter[i].mode == "U")
                    {
                        strquery = @"update EmployerContactPerson set " +
                                     "ContactPerson='" + recruiter[i].contactname +
                                     "',ContactNo='" + recruiter[i].employermobileno +
                                     "',MailId='" + recruiter[i].employeremailid +
                                     "',Designation='" + recruiter[i].employerremarks +
                                     "',VenConStatus='" + recruiter[i].venConstatus +
                                     "' where VendorContactID=" + recruiter[i].vencontactid;

                    }
                    _sql.doInsert(strquery);
                }

                str = " Query Updated"; 
            }

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
                _json.message = str;
                _json.data = "SQL QUERY EXECUTED";
            }


            return _json;
        }


        public jsonArray insertClient(string clientname, string website, string linkedin, string specialization, string remarks, string address, string city,
                                      string country, List<vendorcontact> recruiter, string rowstatus, string placeofsupply, string clienttype, string mode, string clientid, string createdon,
                                      string createdby, string updatedon, string updatedby)
        {

            int status = 1;
            string str = "";

            DateTime dateTime_Indian = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));

            string strquery = "";

            if (mode == "I")
            {
                strquery = @"insert into ClientMaster(ClientCompanyName,Company_Website,Company_Linkedin,Client_Specialization,additionalinfo,address,city,country,Placeofsupply,clienttype,Created_On,Created_By,Status) values('" + clientname + "','" + website + "','" + linkedin + "','" + specialization + "','" + remarks + "','" + address + "','" + city + "','" + country + "','" + placeofsupply + "','" + clienttype + "','" + dateTime_Indian.ToString("yyyy-MM-dd") + "','" + createdby + "'," + rowstatus + ")";

                status = _sql.doInsert(strquery);

                strquery = @"select max(ClientID) employerid from ClientMaster";

                SqlDataReader _read = _sql.doRead(strquery);
                while (_read.Read())
                {
                    clientid = _read[0].ToString();
                }
                _read.Close();

                for (int i = 0; i < recruiter.Count; i++)
                {
                    if (recruiter[i].mode == "")
                    {
                        strquery = @"insert into Client_Contact_Person (" +
                                    "ContactPerson,ContactNo,MailId,Designation,ClientID,ClientConStatus,Created_On,Created_By) values('" +
                                    recruiter[i].contactname + "','" + recruiter[i].employermobileno + "','" +
                                    recruiter[i].employeremailid + "','" + recruiter[i].employerremarks + "'," + clientid + ",'1','"+ dateTime_Indian.ToString("yyyy-MM-dd") + "','" + createdby+"')";
                    }
                   
                    _sql.doInsert(strquery);
                }
                str = "Query Insert";
            }
            else if (mode == "U")
            {
                strquery = @"update ClientMaster set ClientCompanyName='" + clientname + "',Company_Website='" +
                                website + "',Company_Linkedin='" + linkedin + "',Client_Specialization='" + specialization + "',additionalinfo='"+ remarks+
                                "',address='" + address + "',Placeofsupply='"+placeofsupply + "',city='" + city + "',country='" + country + "',updatedon='"
                                + dateTime_Indian.ToString("yyyy-MM-dd") + "',updatedby='" + updatedby + "',Status='" + status + "' where ClientID='" + clientid + "'";

                status = _sql.doInsert(strquery);

                for (int i = 0; i < recruiter.Count; i++)
                {
                    if (recruiter[i].mode == "I")
                    {
                        strquery = @"insert into Client_Contact_Person (" +
                                    "ContactPerson,ContactNo,MailId,Designation,ClientID,ClientConStatus,Created_On,Created_By) values('" +
                                    recruiter[i].contactname + "','" + recruiter[i].employermobileno + "','" +
                                    recruiter[i].employeremailid + "','" + recruiter[i].employerremarks + "'," + clientid + ",'1','" + dateTime_Indian.ToString("yyyy-MM-dd") + "','" + createdby + "')";
                    }
                    else if (recruiter[i].mode == "U")
                    {
                        strquery = @"update Client_Contact_Person set " +
                                     "ContactPerson='" + recruiter[i].contactname +
                                     "',ContactNo='" + recruiter[i].employermobileno +
                                     "',MailId='" + recruiter[i].employeremailid +
                                     "',Designation='" + recruiter[i].employerremarks +
                                     "',ClientConStatus='" + recruiter[i].venConstatus +
                                     "',Updatedon='" + dateTime_Indian.ToString("yyyy-MM-dd") +
                                     "',Updatedby='" + updatedby +
                                     "' where ClientContactID=" + recruiter[i].vencontactid;

                    }
                    _sql.doInsert(strquery);
                }

                str = " Query Updated";
            }

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
                _json.message = str;
                _json.data = "SQL QUERY EXECUTED";
            }


            return _json;
        }


        public jsonArray getSpecializationdetails()
        {
            int status = 1;
            listarray _db = new listarray();

            _db.lstSkill = new List<dropDownTemplate>();
            _db.lstrateType = new List<dropDownTemplate>();

            string strquery = @"SELECT [SpecilaizationName],[SpecilaizationID] FROM [Specialization_Master] where Status=1";

            SqlDataReader _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                _db.lstSkill.Add(new dropDownTemplate
                {
                    ID = _read["SpecilaizationID"].ToString(),
                    Name = _read["SpecilaizationName"].ToString()
                });
            }
            _read.Close();


            strquery = @"SELECT[Regionid],[Regionname] FROM [Region_Master] where Status=1";

            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                _db.lstrateType.Add(new dropDownTemplate
                {
                    ID = _read["Regionid"].ToString(),
                    Name = _read["Regionname"].ToString()
                });
            }
            _read.Close();

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
                _json.data = _db;
            }

            return _json;
        }

        public jsonArray getvendordetails(string TWE_Id, string fromdate, string todate)
        {
            int status = 1;

            vendorlist _db = new vendorlist();

            _db.lstVen = new List<vendorlist>();

            string vendCreation = "";
            string vendEdit = "";
            string vendView = "";
            string strquery = @"SELECT [vendorCreation],[vendorEdit],[vendorView] FROM [UserAccessPower] where userId='" + TWE_Id + "' ";
            SqlDataReader _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                vendCreation = _read[0].ToString();
                vendEdit = _read[1].ToString();
                vendView = _read[2].ToString();
            }
            _read.Close();

            if (vendEdit == "2" || vendView == "2")
            {
                strquery = @"select employerid,employercorporationaname,count(VendorContactID) recruitercount,
                                sta.statusname Status,up.UP_firstName +' '+up.UP_lastName submittedby
                                from EmployerDetails emp
                                join EmployerContactPerson econ on emp.employerid=econ.VendorID
                                join Userprofile up on up.TWE_ID=emp.Created_By 
                                join Status_Master sta on sta.statusid=emp.Status
                                group by employerid,employercorporationaname,statusname,UP_firstName,UP_lastName,emp.Created_By
                                having statusname='Active'";

            }

            else
            {
                strquery = @"select employerid,employercorporationaname,count(VendorContactID) recruitercount,
                                sta.statusname Status,up.UP_firstName +' '+up.UP_lastName submittedby
                                from EmployerDetails emp
                                join EmployerContactPerson econ on emp.employerid=econ.VendorID
                                join Userprofile up on up.TWE_ID=emp.Created_By 
                                join Status_Master sta on sta.statusid=emp.Status
                                group by employerid,employercorporationaname,statusname,UP_firstName,UP_lastName,emp.Created_By
                                having emp.Created_By='" + TWE_Id + "' and statusname='Active'";
            }


                 


            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                vendorlist objven = new vendorlist();
                objven.vendorid = _read[0].ToString();
                objven.vendorname = _read[1].ToString();
                objven.noofrecruiter = _read[2].ToString();
                objven.status = _read[3].ToString();
                objven.submittedby = _read[4].ToString();

                _db.lstVen.Add(objven);

            }

            _read.Close();

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
                _json.data = _db;
            }

            return _json;
        }


        public jsonArray getvendorsearch(string TWE_Id, string specialization, string city, string location)
        {
            int status = 1;

            vendorsearch _db = new vendorsearch();

            _db.lstContact = new List<vendorsearch>();

            string vendorCreation = "";
            string vendorEdit = "";
            string vendorView = "";
            string strquery = @"SELECT [vendorCreation],[vendorEdit],[vendorView] FROM [UserAccessPower] where userId='" + TWE_Id + "' ";
            SqlDataReader _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                vendorCreation = _read[0].ToString();
                vendorEdit = _read[1].ToString();
                vendorView = _read[2].ToString();

            }
            _read.Close();


            string serParam = "";

            if (specialization == "")
            {
                serParam += "";
            }
            else
            {
                serParam += " and employerspecialization like ('%" + specialization + "%')";
            }


            if (city == "")
            {
                serParam += "";
            }
            else
            {
                serParam += " and city like '" + city + "%'";
            }

            if (location == "")
            {
                serParam += "";
            }
            else
            {
                serParam += " and employercorporationaname like '" + location + "%'";
            }

            if (vendorEdit == "2" || vendorView == "2")
            {
                strquery = @"select employerid,employercorporationaname,employerspecialization,count(VendorContactID) recruitercount,
                               city,country,emp.Created_By from EmployerDetails emp
                                join EmployerContactPerson econ on emp.employerid=econ.VendorID
                                group by employerid,employercorporationaname,employerspecialization,status,emp.Created_By,city,country
                                having status=1" + serParam;
            }
            else
            {
                strquery = @"select employerid,employercorporationaname,employerspecialization,count(VendorContactID) recruitercount,
                               city,country,emp.Created_By  from EmployerDetails emp
                                join EmployerContactPerson econ on emp.employerid=econ.VendorID
                                group by employerid,employercorporationaname,employerspecialization,status,emp.Created_By,city,country
                                having Created_By='" + TWE_Id + "' and status=1" + serParam;
            }

            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                vendorsearch objven = new vendorsearch();
                objven.vendorid = _read[0].ToString();
                objven.vendorname = _read[1].ToString();
                objven.specilization = _read[2].ToString();
                objven.noofrecruiter = _read[3].ToString();
                objven.city = _read[4].ToString();
                objven.country = _read[5].ToString();
                objven.createdby=_read[6].ToString();

                _db.lstContact.Add(objven);

            }

            _read.Close();
            string specialVal;
            for (int i = 0; i < _db.lstContact.Count; i++)
            {
                string[] specialArr = _db.lstContact[i].specilization.Split(',');
                specialVal = "";
                for (int j = 0; j < specialArr.Length; j++)
                {
                    specialVal = specialVal + "'" + specialArr[j] + "',";
                }

                specialVal = specialVal.Substring(0, specialVal.Length - 1);


                strquery = "select SpecilaizationName from Specialization_Master where SpecilaizationID in (" + specialVal + ")";
                _read = _sql.doRead(strquery);

                _db.lstContact[i].specilization = "";

                while (_read.Read())
                {
                    _db.lstContact[i].specilization += _read[0].ToString() + ",";
                }

                _db.lstContact[i].specilization = _db.lstContact[i].specilization.Substring(0, _db.lstContact[i].specilization.Length - 1);
                _read.Close();
            }


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
                _json.data = _db;
            }

            return _json;
        }

        public jsonArray getvendormailid(List<vendorsearch> lstvenId)
        {
            int status = 1;

            vendorsearch _db = new vendorsearch();
            _db.lstContact = new List<vendorsearch>();

            string mailID="";

            for (int i = 0; i < lstvenId.Count; i++)
            {
                mailID += lstvenId[i].vendorid + ",";
            }

            mailID = mailID.Substring(0, mailID.Length - 1);

            
            string strquery = @"select MailId from EmployerContactPerson where VendorID in (" + mailID + ") and VenConStatus=1";
            SqlDataReader _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                vendorsearch objven = new vendorsearch();
                objven.vendormailid = _read[0].ToString();
                _db.lstContact.Add(objven);
            }

            _read.Close();
            


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
                _json.data = _db;
            }

            return _json;
        }

        public jsonArray getcandidatecount()
        {
            int status = 1;

            Candidatedetails _db = new Candidatedetails();

            string strquery = @"select count(*) from CandidateDetails";

            SqlDataReader _read = _sql.doRead(strquery);

            while (_read.Read())
            {

                _db.candidateid = _read[0].ToString();
            }

            _read.Close();

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
                _json.data = _db;
            }

            return _json;

        }

        public jsonArray getcandidatesearch(string skill, string location, string yrsofexp, string visastatus, string rating, string Candidatemail, string TWE_Id)
        {
            int status = 1;

            Candidatedetails _db = new Candidatedetails();

            List<Candidatedetails> lstCand = new List<Candidatedetails>();

            string candidateCreation = "";
            string candidateEdit = "";
            string candidateView = "";
            string strquery = @"SELECT [candidateCreation],[candidateEdit],[candidateView] FROM [UserAccessPower] where userId='" + TWE_Id + "' ";
            SqlDataReader _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                candidateCreation = _read[0].ToString();
                candidateEdit = _read[1].ToString();
                candidateView = _read[2].ToString();

            }
            _read.Close();


            string serParam = "";

            string serParam1 = " where ";

            if (skill == "")
            {
                serParam += "";
            }
            else
            {
                var search = skill.Split(',');
                serParam += "(";
                for (int i = 0; i < search.Length; i++)
                {
                    serParam += " skillsandCertif like ('%" + search[i] + "%') or ";
                }

                serParam = serParam.Substring(0, serParam.Length - 3);
                serParam += ")";
            }


            if (location == "")
            {
                serParam += "";
            }
            else
            {
                if (serParam != "")
                {
                    serParam += " and currentLocation like '%" + location + "%'";
                }

                else
                {
                    serParam += " currentLocation like '%" + location + "%'";
                }

            }

            if (yrsofexp == "")
            {
                serParam += "";
            }
            else
            {
                if (serParam != "")
                {
                    serParam += " and YearsofExp='" + yrsofexp + "'";
                }
                else
                {
                    serParam += " YearsofExp='" + yrsofexp + "'";
                }
            }

            if (visastatus == "")
            {
                serParam += "";
            }
            else
            {
                if (serParam != "")
                {
                    serParam += " and VisaStatus='" + visastatus + "'";
                }
                else
                {
                    serParam += " VisaStatus='" + visastatus + "'";
                }
            }

            if (Candidatemail == "")
            {
                serParam += "";
            }
            else
            {
                if (serParam != "")
                {
                    serParam += " and candidateemailid like '%" + Candidatemail + "%'";
                }

                else
                {
                    serParam += " candidateemailid like '%" + Candidatemail + "%'";
                }

            }

            if (rating == "-1")
            {
                serParam += "";
            }
            else
            {
                if (serParam != "")
                {
                    serParam += " and RecruiterRating='" + rating + "'";
                }
                else
                {
                    serParam += " RecruiterRating='" + rating + "'";
                }
            }

            if (candidateEdit == "2" || candidateView == "2")
            {

                strquery = @"select can.candidateid,candidatename,candidateemailid,skillsandCertif,
                                currentLocation,YearsofExp,can.Created_By from CandidateDetails can
                                join CandidateJob canjob on can.candidateid=canjob.CandidateId " + serParam1 + serParam;
            }

            else
            {
                serParam += " and can.Created_By like '%" + TWE_Id + "%'";
                strquery = @"select can.candidateid,candidatename,candidateemailid,skillsandCertif,
                                currentLocation,YearsofExp,can.Created_By from CandidateDetails can
                                join CandidateJob canjob on can.candidateid=canjob.CandidateId " + serParam1 + serParam;
            }

            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                Candidatedetails objven = new Candidatedetails();
                objven.candidateid = _read[0].ToString();
                objven.candidatename = _read[1].ToString();
                objven.candidateemailid = _read[2].ToString();
                objven.skillsandCertif = _read[3].ToString();
                objven.currentLocation = _read[4].ToString();
                objven.yrsofexp = _read[5].ToString();
                objven.createdBy = _read[6].ToString();
                lstCand.Add(objven);

            }

            _read.Close();
            string specialVal;
            for (int i = 0; i < lstCand.Count; i++)
            {
                string[] specialArr = lstCand[i].skillsandCertif.Split(',');
                specialVal = "";
                for (int j = 0; j < specialArr.Length; j++)
                {
                    specialVal = specialVal + "'" + specialArr[j] + "',";
                }

                specialVal = specialVal.Substring(0, specialVal.Length - 1);


                strquery = "select SkillName from Skill_Master where SkillID in (" + specialVal + ")";
                _read = _sql.doRead(strquery);

                lstCand[i].skillsandCertif = "";

                while (_read.Read())
                {
                    lstCand[i].skillsandCertif += _read[0].ToString() + ", ";
                }

                lstCand[i].skillsandCertif = lstCand[i].skillsandCertif.Substring(0, lstCand[i].skillsandCertif.Length - 2);
                _read.Close();
            }


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
                _json.data = lstCand;
            }

            return _json;
        }

        public jsonArray getcandidatesearchIndia(string skill, string Candidatename, string yrsofexp,string rating, string Candidatemail,string TWE_Id)
        {
            int status = 1;

            Candidatedetails _db = new Candidatedetails();

            List<Candidatedetails> lstCand = new List<Candidatedetails>();

            string candidateCreation = "";
            string candidateEdit = "";
            string candidateView = "";
            string strquery = @"SELECT [candidateCreation],[candidateEdit],[candidateView] FROM [UserAccessPower] where userId='" + TWE_Id + "' ";
            SqlDataReader _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                candidateCreation = _read[0].ToString();
                candidateEdit = _read[1].ToString();
                candidateView = _read[2].ToString();

            }
            _read.Close();           

            string serParam = "";

            string serParam1 = " where ";

            if (skill == "")
            {
                serParam += "";
            }
            else
            {
                var search = skill.Split(',');
                serParam += "(";
                for (int i = 0; i < search.Length; i++)
                {
                    serParam += " skillsandCertif like ('%" + search[i] + "%') or ";
                }

                serParam = serParam.Substring(0, serParam.Length - 3);
                serParam += ")";
            }


            if (Candidatename == "")
            {
                serParam += "";
            }
            else
            {
                if (serParam != "")
                {
                    serParam += " and candidatename like '%" + Candidatename + "%'";
                }

                else
                {
                    serParam += " candidatename like '%" + Candidatename + "%'";
                }

            }

            if (yrsofexp == "-1")
            {
                serParam += "";
            }
            else
            {
                if (serParam != "")
                {
                    serParam += " and YearsofExp='" + yrsofexp + "'";
                }
                else
                {
                    serParam += " YearsofExp='" + yrsofexp + "'";
                }
            }

            if (Candidatemail == "")
            {
                serParam += "";
            }
            else
            {
                if (serParam != "")
                {
                    serParam += " and candidateemailid like '%" + Candidatemail + "%'";
                }

                else
                {
                    serParam += " candidateemailid like '%" + Candidatemail + "%'";
                }

            }

            if (rating == "-1")
            {
                serParam += "";
            }
            else
            {
                if (serParam != "")
                {
                    serParam += " and RecruiterRating='" + rating + "'";
                }
                else
                {
                    serParam += " RecruiterRating='" + rating + "'";
                }
            }

            if (candidateEdit == "2" || candidateView == "2")
            {
                
                strquery = @"select can.candidateid,candidatename,candidateemailid,skillsandCertif,
                                currentLocation,YearsofExp,can.Created_By from CandidateDetailsIndia can
                                join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId " + serParam1 + serParam;
            }
            else
            {
                serParam += " and can.Created_By like '%" + TWE_Id + "%'";
                strquery = @"select can.candidateid,candidatename,candidateemailid,skillsandCertif,
                                currentLocation,YearsofExp,can.Created_By from CandidateDetailsIndia can
                                join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId " + serParam1 + serParam;
            }

            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                Candidatedetails objven = new Candidatedetails();
                objven.candidateid = _read[0].ToString();
                objven.candidatename = _read[1].ToString();
                objven.candidateemailid = _read[2].ToString();
                objven.skillsandCertif = _read[3].ToString();
                objven.currentLocation = _read[4].ToString();
                objven.yrsofexp = _read[5].ToString();
                objven.createdBy = _read[6].ToString();
                lstCand.Add(objven);

            }

            _read.Close();
            string specialVal;
            for (int i = 0; i < lstCand.Count; i++)
            {
                string[] specialArr = lstCand[i].skillsandCertif.Split(',');
                specialVal = "";
                for (int j = 0; j < specialArr.Length; j++)
                {
                    specialVal = specialVal + "'" + specialArr[j] + "',";
                }

                specialVal = specialVal.Substring(0, specialVal.Length - 1);


                strquery = "select SkillName from Skill_Master where SkillID in (" + specialVal + ")";
                _read = _sql.doRead(strquery);

                lstCand[i].skillsandCertif = "";

                while (_read.Read())
                {
                    lstCand[i].skillsandCertif += _read[0].ToString() + ", ";
                }

                lstCand[i].skillsandCertif = lstCand[i].skillsandCertif.Substring(0, lstCand[i].skillsandCertif.Length - 2);
                _read.Close();
            }


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
                _json.data = lstCand;
            }

            return _json;
        }

        public jsonArray getcandidatecountIndia()
        {
            int status = 1;

            Candidatedetails _db = new Candidatedetails();

            string strquery = @"select count(*) from CandidateDetailsIndia";

            SqlDataReader _read = _sql.doRead(strquery);

            while (_read.Read())
            {

                _db.candidateid = _read[0].ToString();
            }

            _read.Close();

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
                _json.data = _db;
            }

            return _json;

        }


        public jsonArray insertusercreation(string Firstname, string Lastname, string Gender, string DOB, string Emailid, string Confirmationemailid,
           string Location, string Phoneno, string Language, string Designation, string Region, string Monsterusername, string Monsterpassword, string Textnow,
           string Username, string Password, string Reportingmanager, string ReportingTL, string Status, string Userid, 
           string Submission_Daily, string SubmissiontoTL_Daily, string SubmissiontoBP_Daily, string Closure_Daily, string Vendor_Daily, string Submission_Monthly, 
           string SubmissiontoTL_Monthly,string SubmissiontoBP_Monthly,string Closure_Monthly, string Vendor_Monthly,string Submission_Weekly,
           string SubmissiontoTL_Weekly,string SubmissiontoBP_Weekly,string Closure_Weekly,string Vendor_Weekly,
           string Role,string Level,string jobMenu, string jobCreation, string jobEdit, string jobView, string jobFeedback,
           string candidateMenu, string candidateCreation, string candidateEdit, string candidateView, string vendorMenu, string vendorCreation, string vendorEdit,
           string vendorView, string reportMenu)
        {

            int status = 1;
            string EmpId = "";
            string regionval = "";
            string TweId = "";

            DateTime dateTime_Indian = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));

            string strquery = "";
            if (Userid == "")
            {
                string EncryptPSW = Encrypt(Password);

                strquery = @"INSERT INTO [dbo].[Userprofilecreation]
           ([firstname]
           ,[lastname]
           ,[dob]
           ,[emailid]
           ,[confirmationemailid]
           ,[location]
           ,[phoneno]
           ,[language]
           ,[designation]
           ,[region]
           ,[monsterusername]
           ,[monsterpsw]
           ,[textnow]
           ,[reportingmanager]
           ,[reportingTL]
           ,[accountusername]
           ,[accountpassword]
           ,[status]
           ,[gender]
           ,[role]
           ,[level]
           ,[insertdate]
           ,Candidate_adding
           ,Vendor_creation
           ,Submittion
           ,TLApproval, BPApproval, ECApproval)
           VALUES
           ('" + Firstname + "','" + Lastname + "','" + DOB + "','" + Emailid + "','" + Confirmationemailid + "','" + Location + "','" + Phoneno + "','" + Language
              + "','" + Designation + "','" + Region + "','" + Monsterusername + "','" + Monsterpassword + "','" + Textnow + "','" + Reportingmanager
              + "','" + ReportingTL + "','" + Username + "','" + EncryptPSW + "','" + Status + "','" + Gender + "','" + Role + "','" + Level+ "','" + dateTime_Indian.ToString("yyyy-MM-dd") +
              "')";
            }
            else if (Userid != "")
            {
                strquery = @"UPDATE [dbo].[Userprofilecreation]
                                          SET [firstname] = '" + Firstname
                                          + "',[lastname] = '" + Lastname
                                          + "',[dob] = '" + DOB
                                          + "',[emailid] = '" + Emailid
                                          + "' ,[confirmationemailid] = '" + Confirmationemailid
                                          + "',[location] = '" + Location
                                          + "',[phoneno] = '" + Phoneno
                                          + "',[language] = '" + Language
                                          + "',[designation] ='" + Designation
                                          + "',[region] = '" + Region
                                          + "',[monsterusername] ='" + Monsterusername
                                          + "',[monsterpsw] = '" + Monsterpassword
                                          + "' ,[textnow] = '" + Textnow
                                          + "',[reportingmanager] = '" + Reportingmanager
                                          + "',[reportingTL] = '" + ReportingTL
                                          + "',[gender] = '" + Gender
                                          + "',[role] = '" + Role
                                          + "',[level] = '" + Level
                                         + "',[updateddate] = '" + dateTime_Indian.ToString("yyyy-MM-dd")                                         
                                          + "' WHERE TWE_ID= '" + Userid + "'";
            }
            //status = _sql.doInsert(strquery);
            if (Userid == "")
            {

                strquery = @"select top 1 userid,region from Userprofilecreation order by userid desc ";

                SqlDataReader _read = _sql.doRead(strquery);
                int i = 0;
                while (_read.Read())
                {
                    EmpId = _read[0].ToString();
                    i = Convert.ToInt16(_read[0]);
                    regionval = _read[1].ToString();
                }
                _read.Close();
                if (regionval == "2000")
                {

                    if (i >= 0 && i < 9)
                    {

                        TweId = "TWEI" + "000" + i;
                    }
                    else if (i >= 9 && i < 99)

                    {

                        TweId = "TWEI" + "00" + i;
                    }
                    else if (i >= 99 && i < 999)
                    {

                        TweId = "TWEI" + "0" + i;
                    }
                    else
                    {
                        TweId = "TWEI" + i;
                    }

                }
                else if (regionval == "2001")
                {
                    TweId = "TWEU";

                    if (i >= 0 && i < 9)
                    {
                        TweId = "TWEU" + "000" + i;
                    }
                    else if (i >= 9 && i < 99)

                    {
                        TweId = "TWEU" + "00" + i;
                    }
                    else if (i >= 99 && i < 999)
                    {
                        TweId = "TWEU" + "0" + i;
                    }
                    else
                    {
                        TweId = "TWEU" + i;
                    }
                }

                strquery = @"UPDATE [dbo].[Userprofilecreation]
                         SET [accountusername] = '" + TweId + "',TWE_ID='" + TweId + "' WHERE userid= '" + EmpId + "'";

                //status = _sql.doInsert(strquery);
            }

            if (Userid == "")
            {
                strquery = @"INSERT INTO [UserAccessPower]
                            ([userId]
                            ,[jobaccess]
                            ,[jobCreation]
                            ,[jobEdit]
                            ,[jobView]
                            ,[jobFeedback]
                            ,[candidateAccess]
                            ,[candidateCreation]
                            ,[candidateView]
                            ,[candidateEdit]
                            ,[vendorAccess]
                            ,[vendorCreation]
                            ,[vendorEdit]
                            ,[vendorView]
                            ,[Status])
                            VALUES
                            ('" + TweId
                            + "','" + jobMenu
                            + "','" + jobCreation
                            + "','" + jobEdit
                            + "','" + jobView
                            + "','" + jobFeedback
                            + "','" + candidateMenu
                            + "','" + candidateCreation
                            + "','" + candidateView
                            + "','" + candidateEdit
                            + "','" + vendorMenu
                            + "','" + vendorCreation
                            + "','" + vendorEdit
                            + "','" + vendorView
                            + "','" + status + "')";
            }
            else if (Userid != "")
            {
                strquery = @"UPDATE [UserAccessPower]
                            SET [jobaccess] = '" + jobMenu
                            + "',[jobCreation] = '" + jobCreation
                            + "',[jobEdit] = '" + jobEdit
                            + "',[jobView] = '" + jobView
                            + "',[jobFeedback] = '" + jobFeedback
                            + "',[candidateAccess] = '" + candidateMenu
                            + "',[candidateCreation] = '" + candidateCreation
                            + "',[candidateView] = '" + candidateView
                            + "',[candidateEdit] = '" + candidateEdit
                            + "',[vendorAccess] = '" + vendorMenu
                            + "',[vendorCreation] = '" + vendorCreation
                            + "',[vendorEdit] = '" + vendorEdit
                            + "',[vendorView] = '" + vendorView
                            + "',[Status] = '" + status
                            + "' WHERE [userId] ='" + Userid+"'";
            }

            //status = _sql.doInsert(strquery);

            if (Userid == "")
            {
                strquery = @"insert into UserTargetMaster 
                            (TWEID
                            ,SubmissiontoTL_Daily
                            ,Submission_Daily
                            ,SubmissiontoBP_Daily
                            ,Closure_Daily
                            ,Vendor_Daily
                            ,Submission_Monthly
                            ,SubmissiontoTL_Monthly
                            ,SubmissiontoBP_Monthly
                            ,Closure_Monthly
                            ,Vendor_Monthly
                            ,Submission_Weekly
                            ,SubmissiontoTL_Weekly
                            ,SubmissiontoBP_Weekly
                            ,Closure_Weekly
                            ,Vendor_Weekly)
                            values
                            ('" + TweId
                            +"','" + SubmissiontoTL_Daily
                            + "','" + Submission_Daily
                            + "','" + SubmissiontoBP_Daily
                            + "','" + Closure_Daily
                            + "','" + Vendor_Daily
                            + "','" + Submission_Monthly
                            + "','" + SubmissiontoTL_Monthly
                            + "','" + SubmissiontoBP_Monthly
                            + "','" + Closure_Monthly
                            + "','" + Vendor_Monthly
                            + "','" + Submission_Weekly
                            + "','" + SubmissiontoTL_Weekly
                            + "','" + SubmissiontoBP_Weekly
                            + "','" + Closure_Weekly
                            + "','" + Vendor_Weekly + "')";
            }
            else if (Userid != "")
            {
                strquery = @"UPDATE [UserTargetMaster]
                            SET [SubmissiontoTL_Daily] = '" + SubmissiontoTL_Daily
                            + "',[Submission_Daily] = '" + Submission_Daily
                            + "',[SubmissiontoBP_Daily] = '" + SubmissiontoBP_Daily
                            + "',[Closure_Daily] = '" + Closure_Daily
                            + "',[Vendor_Daily] = '" + Vendor_Daily
                            + "',[Submission_Monthly] = '" + Submission_Monthly
                            + "',[SubmissiontoTL_Monthly] = '" + SubmissiontoTL_Monthly
                            + "',[SubmissiontoBP_Monthly] = '" + SubmissiontoBP_Monthly
                            + "',[Closure_Monthly] = '" + Closure_Monthly
                            + "',[Vendor_Monthly] = '" + Vendor_Monthly
                            + "',[Submission_Weekly] = '" + Submission_Weekly
                            + "',[SubmissiontoTL_Weekly] = '" + SubmissiontoTL_Weekly
                            + "',[SubmissiontoBP_Weekly] = '" + SubmissiontoBP_Weekly
                            + "',[Closure_Weekly] = '" + Closure_Weekly
                            + "',[Vendor_Weekly] = '" + Vendor_Weekly
                            + "' WHERE [TWEID] ='" + Userid + "'";
            }

            status = _sql.doInsert(strquery);



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
                _json.message = "CREATED";
                _json.data = "Success";
            }


            return _json;
        }

        public jsonArray updatepassword(string Password, string userid)
        {

            int status = 1;
            string EncryptPSW = Encrypt(Password);
            string strquery = @"update Userprofilecreation set accountpassword='" + EncryptPSW + "' where userid='" + userid + "'";
            status = _sql.doInsert(strquery);

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
                _json.message = "Password Updated";
                _json.data = "Success";
            }


            return _json;
        }
        
        public jsonArray getUserprofile(string Userid)
       {
            int status = 1;
            Userprofilecreaton _upc = new Userprofilecreaton();
            _upc.LstbasicInfo = new List<BasiInfo>();
            string TWEId="";
            string strquery;
            if (Userid == "")
            {
                strquery = @"SELECT  [userid]
                ,[firstname]
                ,[lastname]
                ,[regionname]
                ,[rolename]
                ,[levelname],TWE_ID  FROM [Userprofilecreation] up 
				join Region_Master re on re.Regionid=up.region
				join RoleMaster ro on ro.Roleid=up.role
				join Level_Master le on le.Levelid=up.level";
            }
            else
            {

                strquery = @"SELECT [userid]
      ,[firstname]
      ,[lastname]
      ,[dob]
      ,[emailid]
      ,[confirmationemailid]
      ,[location]
      ,[phoneno]
      ,[language]
      ,[designation]
      ,[region]
      ,[monsterusername]
      ,[monsterpsw]
      ,[textnow]
      ,[reportingmanager]
      ,[reportingTL]
      ,[status]
      ,[gender]
      ,[role]
      ,[level]
      ,TWE_ID
  FROM [Userprofilecreation] where TWE_ID='" + Userid+"'";
            }

            SqlDataReader _read = _sql.doRead(strquery);
            BasiInfo _bi = new BasiInfo();
            SupportAccess _sa = new SupportAccess();
            Account _ac = new Account();
            RoleAccess _ra = new RoleAccess();
            targetfixingMstr _tf = new targetfixingMstr();
            while (_read.Read())
            {               

                    if (Userid == "")
                    {
                        BasiInfo _basic = new BasiInfo();
                        _basic.userid = _read[0].ToString();
                        _basic.firstname = _read[1].ToString();
                        _basic.lastname = _read[2].ToString();
                        _basic.region = _read[3].ToString();
                        _basic.role = _read[4].ToString();
                        _basic.level = _read[5].ToString();
                        _basic.TWE_ID = _read[6].ToString();
                        _upc.LstbasicInfo.Add(_basic);
                    }
                    else
                    {
                        _bi.userid = _read[0].ToString();
                        _bi.firstname = _read[1].ToString();
                        _bi.lastname = _read[2].ToString();
                        _bi.gender = _read[17].ToString();
                        _bi.dob = Convert.ToDateTime(_read[3]).ToString("yyyy-MM-dd");
                        _bi.email = _read[4].ToString();
                        _bi.confirmationemail = _read[5].ToString();
                        _bi.location = _read[6].ToString();
                        _bi.phoneno = _read[7].ToString();
                        _bi.language = _read[8].ToString();
                        _bi.designation = _read[9].ToString();
                        _sa.region = _read[10].ToString();
                        _sa.monster = _read[11].ToString() + "|" + _read[12].ToString();
                        _sa.textnow = _read[13].ToString();
                        _ac.reportingmanager = _read[14].ToString();
                        _ac.reportingTL = _read[15].ToString();
                        _bi.role = _read[18].ToString();
                        _bi.level = _read[19].ToString();
                        _bi.TWE_ID = _read[20].ToString();

                        _upc.basicinfo = _bi;
                        _upc.supportaccess = _sa;
                        _upc.account = _ac;

                         TWEId = _bi.TWE_ID;
                    }
            }

            _read.Close();
            if (Userid != "")
            {
                strquery = @"SELECT [jobaccess]
                              ,[jobCreation]
                              ,[jobEdit]
                              ,[jobView]
                              ,[jobFeedback]
                              ,[candidateAccess]
                              ,[candidateCreation]
                              ,[candidateView]
                              ,[candidateEdit]
                              ,[vendorAccess]
                              ,[vendorCreation]
                              ,[vendorEdit]
                              ,[vendorView]
                          FROM [UserAccessPower] where userId='" + TWEId+"'";

                _read = _sql.doRead(strquery);

                _upc.MenuAccess = new RoleMenu();

                while (_read.Read())
                {
                    _upc.MenuAccess.jobAccess = _read[0].ToString();
                    _upc.MenuAccess.jobCreation = _read[1].ToString();
                    _upc.MenuAccess.jobEdit = _read[2].ToString();
                    _upc.MenuAccess.jobView = _read[3].ToString();
                    _upc.MenuAccess.jobFeedback = _read[4].ToString();
                    _upc.MenuAccess.candidateAccess = _read[5].ToString();
                    _upc.MenuAccess.candidateCreation = _read[6].ToString();
                    _upc.MenuAccess.candidateView = _read[7].ToString();
                    _upc.MenuAccess.candidateEdit = _read[8].ToString();
                    _upc.MenuAccess.vendorAccess = _read[9].ToString();
                    _upc.MenuAccess.vendorCreation = _read[10].ToString();
                    _upc.MenuAccess.vendorView = _read[12].ToString();
                    _upc.MenuAccess.vendorEdit = _read[11].ToString();
                }

                _read.Close();

            }
            if (Userid != "")
            {
                strquery = @"SELECT SubmissiontoTL_Daily
                                    ,Submission_Daily
                                    ,SubmissiontoBP_Daily
                                    ,Closure_Daily
                                    ,Vendor_Daily
                                    ,Submission_Monthly
                                    ,SubmissiontoTL_Monthly
                                    ,SubmissiontoBP_Monthly
                                    ,Closure_Monthly
                                    ,Vendor_Monthly
                                    ,Submission_Weekly
                                    ,SubmissiontoTL_Weekly
                                    ,SubmissiontoBP_Weekly
                                    ,Closure_Weekly
                                    ,Vendor_Weekly from UserTargetMaster where TWEID='" + TWEId + "'";

                _read = _sql.doRead(strquery);
                targetfixingMstr _tfm = new targetfixingMstr();

                while (_read.Read())
                {
                    _tfm.SubmissiontoTL_Daily = _read[0].ToString();
                    _tfm.Submission_Daily = _read[1].ToString();
                    _tfm.SubmissiontoBP_Daily = _read[2].ToString();
                    _tfm.Closure_Daily = _read[3].ToString();
                    _tfm.Vendor_Daily = _read[4].ToString();
                    _tfm.Submission_Monthly = _read[5].ToString();
                    _tfm.SubmissiontoTL_Monthly = _read[6].ToString();
                    _tfm.SubmissiontoBP_Monthly = _read[7].ToString();
                    _tfm.Closure_Monthly = _read[8].ToString();
                    _tfm.Vendor_Monthly = _read[9].ToString();
                    _tfm.Submission_Weekly = _read[10].ToString();
                    _tfm.SubmissiontoTL_Weekly = _read[11].ToString();
                    _tfm.SubmissiontoBP_Weekly = _read[12].ToString();
                    _tfm.Closure_Weekly = _read[13].ToString();
                    _tfm.Vendor_Weekly = _read[14].ToString();
                }


                _upc.targetfixingMstr = _tfm;
                _read.Close();
            }


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
                _json.data = _upc;
            }


            return _json;
        }

        public jsonArray getMenuaccess(string Userid, string designation)
        {
            int status = 1;
            menuaccess _ma = new menuaccess();

            string strquery = @"select designation,menutype,menuadd,menuedit,menuview,menudelete from Menuaccesspermission where designation='" + designation + "' and status=1";

            SqlDataReader _read = _sql.doRead(strquery);
            while (_read.Read())
            {
                _ma.designationid = _read[0].ToString();
                _ma.menutype = _read[1].ToString();
                _ma.menuadd = _read[2].ToString();
                _ma.menuedit = _read[3].ToString();
                _ma.menuview = _read[4].ToString();
                _ma.menudelete = _read[5].ToString();
            }

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
                _json.data = _ma;
            }


            return _json;
        }

        public jsonArray accountdeactive(string userid, string status)
        {
            int mode = 1;
            string query = "";

            query = @"update Userprofilecreation set status='" + status + "' where userid='" + userid + "'";

            _sql.doInsert(query);


            jsonArray _json = new jsonArray();
            if (mode == 0)
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
                _json.data = "";
            }

            return _json;

        }

        public jsonArray DrpList()
        {
            int mode = 1;
            int status = 1;
            string query = "";

            dropdownlist _drplist = new dropdownlist();

            _drplist.Designation = new List<dropdowndata>();
            _drplist.Gender = new List<dropdowndata>();
            _drplist.Role = new List<dropdowndata>();
            _drplist.Level = new List<dropdowndata>();
            _drplist.Language = new List<dropdowndata>();

            query = @"select [Designationid],[Designationname] from Designation_Master where Status=1";

            SqlDataReader _read = _sql.doRead(query);
            while (_read.Read())
            {
                dropdowndata _drpdesignation = new dropdowndata();

                _drpdesignation.drpid = _read[0].ToString();
                _drpdesignation.drpname = _read[1].ToString();

                _drplist.Designation.Add(_drpdesignation);
            }
            _read.Close();

            query = @"select [Genderid],[Gendername] FROM [Gender_Master] where [Status]=1";

            _read = _sql.doRead(query);
            while (_read.Read())
            {
                dropdowndata _drpgender = new dropdowndata();

                _drpgender.drpid = _read[0].ToString();
                _drpgender.drpname = _read[1].ToString();

                _drplist.Gender.Add(_drpgender);
            }
            _read.Close();

            //query = @"select distinct '',reportingmanager from Userprofilecreation where status=1";

            //_read = _sql.doRead(query);
            //while (_read.Read())
            //{
            //    dropdowndata _drpreportingmanager = new dropdowndata();

            //    _drpreportingmanager.drpid = _read[0].ToString();
            //    _drpreportingmanager.drpname = _read[1].ToString();

            //    _drplist.Reportingmanager = _drpreportingmanager;
            //}
            //_read.Close();

            //query = @"select distinct '',reportingTL from Userprofilecreation where status=1";

            //_read = _sql.doRead(query);
            //while (_read.Read())
            //{
            //    dropdowndata _drpreportingTL = new dropdowndata();

            //    _drpreportingTL.drpid = _read[0].ToString();
            //    _drpreportingTL.drpname = _read[1].ToString();

            //    _drplist.ReporingTL = _drpreportingTL;
            //}
            //_read.Close();


            query = @"select [Roleid],[Rolename] from [RoleMaster] where Status=1";

            _read = _sql.doRead(query);
            while (_read.Read())
            {
                dropdowndata _drprole = new dropdowndata();

                _drprole.drpid = _read[0].ToString();
                _drprole.drpname = _read[1].ToString();

                _drplist.Role.Add(_drprole);
            }
            _read.Close();

            query = @"select [Levelid],[Levelname] from Level_Master where [Status]=1";

            _read = _sql.doRead(query);
            while (_read.Read())
            {
                dropdowndata _drplvl = new dropdowndata();

                _drplvl.drpid = _read[0].ToString();
                _drplvl.drpname = _read[1].ToString();

                _drplist.Level.Add(_drplvl);
            }
            _read.Close();

            query = @"select [Languageid],[Languagename] FROM Language_Master where [Status]=1";

            _read = _sql.doRead(query);
            while (_read.Read())
            {
                dropdowndata _drplanguage = new dropdowndata();

                _drplanguage.drpid = _read[0].ToString();
                _drplanguage.drpname = _read[1].ToString();

                _drplist.Language.Add(_drplanguage);
            }
            _read.Close();


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
                _json.data = _drplist;
            }

            return _json;

        }

        public jsonArray targetfixing(string Userid, string key)
        {
            int status = 1;
            targetfixing _target = new targetfixing();

            string strquery = @"select [targetfixingid],[Candidate_adding],[Vendor_creation],[Submittion] from targetfixing where [status]=1 and keys ='" + key + "'";

            SqlDataReader _read = _sql.doRead(strquery);
            while (_read.Read())
            {
                _target.targetfixingid = _read[0].ToString();
                _target.candidateadding = _read[1].ToString();
                _target.vendorcreation = _read[2].ToString();
                _target.submission = _read[3].ToString();

            }

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
                _json.data = _target;
            }


            return _json;
        }

        public jsonArray getManagerdetails()
        {
            int status = 1;
            listarray _db = new listarray();

            _db.lstManager = new List<dropDownTemplate>();

            _db.lstTeamlead = new List<dropDownTemplate>();

            string strquery = @"select TWE_ID,UP_firstName+' '+UP_lastName Empname from Userprofile where UP_MT_Role=4002 or UP_MT_Role=4004";

            SqlDataReader _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                _db.lstManager.Add(new dropDownTemplate
                {
                    ID = _read["TWE_ID"].ToString(),
                    Name = _read["Empname"].ToString()
                });
            }

            _read.Close();

            strquery = @"select TWE_ID,UP_firstName+' '+UP_lastName Empname from Userprofile where UP_MT_Role=4000";

            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                _db.lstTeamlead.Add(new dropDownTemplate
                {
                    ID = _read["TWE_ID"].ToString(),
                    Name = _read["Empname"].ToString()
                });
            }

            _read.Close();

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
                _json.data = _db;
            }

            return _json;
        }

        public jsonArray getTargetdetails(string roletype, string leveltype, string region)
        {
            int status = 1;

            targetfixingMstr _tfm = new targetfixingMstr();

            string strquery = "";

            strquery = @"SELECT TargetID
                                    ,RoleType
                                    ,LevelType
                                    ,RegionType
                                    ,SubmissiontoTL_Daily
                                    ,Submission_Daily
                                    ,SubmissiontoBP_Daily
                                    ,Closure_Daily
                                    ,Vendor_Daily
                                    ,Submission_Monthly
                                    ,SubmissiontoTL_Monthly
                                    ,SubmissiontoBP_Monthly
                                    ,Closure_Monthly
                                    ,Vendor_Monthly
                                    ,Submission_Weekly
                                    ,SubmissiontoTL_Weekly
                                    ,SubmissiontoBP_Weekly
                                    ,Closure_Weekly
                                    ,Vendor_Weekly from TargetMaster where RoleType=" + roletype + " and LevelType=" + leveltype + " and RegionType=" + region;

            SqlDataReader _read = _sql.doRead(strquery);

            while (_read.Read())
            {

                _tfm.TargetfixingId = _read[0].ToString();
                _tfm.RoleType = _read[1].ToString();
                _tfm.LevelType = _read[2].ToString();
                _tfm.RegionType = _read[3].ToString();
                _tfm.SubmissiontoTL_Daily = _read[4].ToString();
                _tfm.Submission_Daily = _read[5].ToString();
                _tfm.SubmissiontoBP_Daily = _read[6].ToString();
                _tfm.Closure_Daily = _read[7].ToString();
                _tfm.Vendor_Daily = _read[8].ToString();
                _tfm.Submission_Monthly = _read[9].ToString();
                _tfm.SubmissiontoTL_Monthly = _read[10].ToString();
                _tfm.SubmissiontoBP_Monthly = _read[11].ToString();
                _tfm.Closure_Monthly = _read[12].ToString();
                _tfm.Vendor_Monthly = _read[13].ToString();
                _tfm.Submission_Weekly = _read[14].ToString();
                _tfm.SubmissiontoTL_Weekly = _read[15].ToString();
                _tfm.SubmissiontoBP_Weekly = _read[16].ToString();
                _tfm.Closure_Weekly = _read[17].ToString();
                _tfm.Vendor_Weekly = _read[18].ToString();
            }

            _read.Close();

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
                _json.data = _tfm;
            }

            return _json;
        }

        public jsonArray getManagerJobdetailsIndia(string TWE_Id, string tiletype,string filtertype)
        {
            int status = 1;

            JobMaster _db = new JobMaster();
            _db.lstJob = new List<JobcodeList>();
            _db.lsttiles = new List<tiles>();

            string jobCreation = "";
            string jobEdit = "";
            string jobView = "";
            string jobFeedback = "";
            string strquery = @"SELECT [jobCreation],[jobEdit],[jobView],[jobFeedback] FROM [UserAccessPower] where userId='" + TWE_Id + "' ";
            SqlDataReader _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                jobCreation = _read[0].ToString();
                jobEdit = _read[1].ToString();
                jobView = _read[2].ToString();
                jobFeedback = _read[3].ToString();

            }
            _read.Close();

            if (jobEdit == "2" || jobView == "2" || jobFeedback=="2")
            {
                strquery = @"select * from
                                (select count(*) open_jobs from Job_Master_IND
                                where Jobstatus='10200') tb1," +
                                "(select count(distinct job.Jobcode) feedback_jobs from Job_Master_IND job" +
                                " join CandidateJobIndia " +
                                " canjob on canjob.Jobcode=job.Jobcode" +
                                " join CandidateDetailsIndia can on canjob.CandidateId = can.candidateid " +
                                " where Cand_Status in (103,105,107,110,111) and Jobstatus='10200') tb2," +
                                "(select count(distinct job.Jobcode) TLSubmitted_jobs from Job_Master_IND job" +
                                " join CandidateJobIndia " +
                                " canjob on canjob.Jobcode=job.Jobcode" +
                                " join CandidateDetailsIndia can on canjob.CandidateId = can.candidateid" +
                                " where Cand_Status=103) tb3," +
                                " (select count(distinct Jobcode) Nosubmission_jobs from CandidateJobIndia can " +
                                " where jobcode not in (select Jobcode from Job_Master_IND " +
                                " where Jobstatus='10200'" +
                                " ))" +
                                " tb4,(select count(distinct job.Jobcode) interview_jobs from Job_Master_IND job" +
                                " join CandidateJobIndia canjob on canjob.Jobcode=job.Jobcode" +
                                " join CandidateDetailsIndia can on canjob.CandidateId = can.candidateid" +
                                " where Cand_Status in ('110','111') and Jobstatus=10200) tb5," +
                                " (select count(distinct job.Jobcode) closure_jobs from Job_Master_IND job join" +
                                " CandidateJobIndia canjob on canjob.Jobcode=job.Jobcode" +
                                " join CandidateDetailsIndia can on canjob.CandidateId = can.candidateid" +
                                " where Cand_Status in ('109')) tb6,(" +
                                " select count(*) overall_jobs from Job_Master_IND where Jobcode!='TWEIND0000' ) tb7";
            }

            else
            {
                strquery = @"select * from
                                (select count(*) open_jobs from Job_Master_IND
                                where Created_By like '%" + TWE_Id + "%'  and Jobstatus='10200') tb1," +
                                "(select count(distinct job.Jobcode) feedback_jobs from Job_Master_IND job" +
                                " join CandidateJobIndia " +
                                " canjob on canjob.Jobcode=job.Jobcode" +
                                " join CandidateDetailsIndia can on canjob.CandidateId = can.candidateid " +
                                " where job.Created_By like '%" + TWE_Id + "%' and Cand_Status in (103,105,107,110,111) and Jobstatus=10200) tb2," +
                                "(select count(distinct job.Jobcode) TLSubmitted_jobs from Job_Master_IND job" +
                                " join CandidateJobIndia " +
                                " canjob on canjob.Jobcode=job.Jobcode" +
                                " join CandidateDetailsIndia can on canjob.CandidateId = can.candidateid" +
                                " where job.Created_By like '%" + TWE_Id + "%' and Cand_Status=103) tb3," +
                                " (select count(*) Nosubmission_jobs from CandidateJobIndia can " +
                                " where jobcode not in (select Jobcode from Job_Master_IND " +
                                " where Created_By like '%" + TWE_Id + "%' and Jobstatus='10200'" +
                                " ) and Created_By like '%" + TWE_Id + "%')" +
                                " tb4,(select count(distinct job.Jobcode) interview_jobs from Job_Master_IND job" +
                                " join CandidateJobIndia canjob on canjob.Jobcode=job.Jobcode" +
                                " join CandidateDetailsIndia can on canjob.CandidateId = can.candidateid" +
                                " where job.Created_By like '%" + TWE_Id + "%' and Cand_Status in ('110','111') and Jobstatus=10200) tb5," +
                                " (select count(distinct job.Jobcode) closure_jobs from Job_Master_IND job join" +
                                " CandidateJobIndia canjob on canjob.Jobcode=job.Jobcode" +
                                " join CandidateDetailsIndia can on canjob.CandidateId = can.candidateid" +
                                " where job.Created_By like '%" + TWE_Id + "%'  and Cand_Status in ('109')) tb6,(" +
                                " select count(*) overall_jobs from Job_Master_IND where Jobcode!='TWEIND0000' ) tb7";
            }

            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                tiles objTile1 = new tiles();
                objTile1.TileTitle = "Open Jobs";
                objTile1.TotalCount = _read[0].ToString();
                _db.lsttiles.Add(objTile1);

                tiles objTile2 = new tiles();
                objTile2.TileTitle = "Feedback";
                objTile2.TotalCount = _read[1].ToString();
                _db.lsttiles.Add(objTile2);

                tiles objTile3 = new tiles();
                objTile3.TileTitle = "TL Submitted";
                objTile3.TotalCount = _read[2].ToString();
                _db.lsttiles.Add(objTile3);

                //tiles objTile4 = new tiles();
                //objTile4.TileTitle = "No Submission";
                //objTile4.TotalCount = _read[3].ToString();
                //_db.lsttiles.Add(objTile4);

                tiles objTile5 = new tiles();
                objTile5.TileTitle = "Interview";
                objTile5.TotalCount = _read[4].ToString();
                _db.lsttiles.Add(objTile5);

                tiles objTile6 = new tiles();
                objTile6.TileTitle = "Closure";
                objTile6.TotalCount = _read[5].ToString();
                _db.lsttiles.Add(objTile6);

                tiles objTile7 = new tiles();
                objTile7.TileTitle = "Overall Jobs";
                objTile7.TotalCount = _read[6].ToString();
                _db.lsttiles.Add(objTile7);

            }

            _read.Close();

            List<Jobcode> lstJob = new List<Jobcode>();

            strquery = @"select Jobcode from Job_Master_IND where Created_By like '%" + TWE_Id + "%' and Jobstatus='10200'";


            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                Jobcode obj = new Jobcode();
                obj.Jobcodename = _read[0].ToString();
                lstJob.Add(obj);
            }

            _read.Close();

            List<Jobcode> lstSubJob = new List<Jobcode>();

            strquery = @"select distinct job.jobcode from CandidateJobIndia can
                            join Job_Master_IND job on job.Jobcode=can.Jobcode 
                            where job.Created_By like '%" + TWE_Id + "%' and Jobstatus='10200'";

            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                Jobcode obj = new Jobcode();
                obj.Jobcodename = _read[0].ToString();
                lstSubJob.Add(obj);
            }

            _read.Close();

            int nonsubCount = 0;
            string nonsubJob = "";

            for (int i = 0; i < lstJob.Count; i++)
            {

                for (int j = 0; j < lstSubJob.Count; j++)
                {
                    if (lstSubJob[j].Jobcodename == lstJob[i].Jobcodename)
                    {
                        nonsubCount++;
                        nonsubJob += "'" + lstSubJob[j].Jobcodename + "',";
                    }

                }

            }

            int noSub = lstJob.Count - nonsubCount;

            tiles objTile4 = new tiles();
            objTile4.TileTitle = "Nil Submissions";
            objTile4.TotalCount = noSub.ToString();
            _db.lsttiles.Add(objTile4);

            if (nonsubJob.Length != 0)
            {
                nonsubJob = nonsubJob.Substring(0, nonsubJob.Length - 1);
            }

            if (tiletype == "Open")
            {
                if (jobEdit == "2" || jobView == "2" || jobFeedback == "2")
                {
                    strquery = @"select Jobcode,JobTitle,Duration,empl.EmpTypeName,loc.LocationName,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage,job.Created_By from Job_Master_IND job
                                join Location_Master loc on job.Location=loc.LocationID
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientContactID=job.Contactname
                                where Jobstatus='10200' order by job.Created_On desc,job.Created_Time desc";
                }
                else
                {
                    strquery = @"select Jobcode,JobTitle,Duration,empl.EmpTypeName,loc.LocationName,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage,job.Created_By from Job_Master_IND job
                                join Location_Master loc on job.Location=loc.LocationID
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientContactID=job.Contactname
                                where job.Created_By like '%" + TWE_Id + "%'" + " and Jobstatus='10200' order by job.Created_On desc,job.Created_Time desc";
                }
            }
            else if (tiletype == "Feedback")
            {
                if (filtertype == "All")
                {
                    if (jobEdit == "2" || jobView == "2" || jobFeedback == "2")
                    { 
                        strquery = @"select * from (select distinct job.Jobcode,JobTitle,Duration,empl.EmpTypeName,loc.LocationName,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage,job.Created_Time,job.Created_On as Datecreated,job.Created_By from Job_Master_IND job
                                join Location_Master loc on job.Location=loc.LocationID
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientContactID=job.Contactname
                                join CandidateJobIndia canjob on job.Jobcode=canjob.Jobcode   
                                join CandidateDetailsIndia can on can.candidateid = canjob.CandidateId
                                where Cand_Status in ('103','105','107','110','111') and Jobstatus=10200) tb1 order by Datecreated desc,Created_Time desc --and Jobstatus not in ('10201') --order by job.Created_On desc";
                    }
                    else
                    {
                        strquery = @"select * from (select distinct job.Jobcode,JobTitle,Duration,empl.EmpTypeName,loc.LocationName,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage,job.Created_Time,job.Created_On as Datecreated,job.Created_By from Job_Master_IND job
                                join Location_Master loc on job.Location=loc.LocationID
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientContactID=job.Contactname
                                join CandidateJobIndia canjob on job.Jobcode=canjob.Jobcode   
                                join CandidateDetailsIndia can on can.candidateid = canjob.CandidateId
                                where job.Created_By like '%" + TWE_Id + "%'" +
                                " and  Cand_Status in ('103','105','107','110','111') and Jobstatus=10200) tb1 order by Datecreated desc,Created_Time desc --and Jobstatus not in ('10201') --order by job.Created_On desc";
                    }
                }

                else
                {
                    if (jobEdit == "2" || jobView == "2" || jobFeedback == "2")
                    {
                        strquery = @"select * from (select distinct job.Jobcode,JobTitle,Duration,empl.EmpTypeName,loc.LocationName,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage,job.Created_Time,job.Created_On as Datecreated,job.Created_By from Job_Master_IND job
                                join Location_Master loc on job.Location=loc.LocationID
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientContactID=job.Contactname
                                join CandidateJobIndia canjob on job.Jobcode=canjob.Jobcode   
                                join CandidateDetailsIndia can on can.candidateid = canjob.CandidateId
                                where can.Created_By like '%" + filtertype + "%'" +
                                " and  Cand_Status in ('103','105','107','110','111')) tb1 order by Datecreated desc,Created_Time desc --and Jobstatus not in ('10201') --order by job.Created_On desc";
                    }
                    else
                    {
                        strquery = @"select * from (select distinct job.Jobcode,JobTitle,Duration,empl.EmpTypeName,loc.LocationName,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage,job.Created_Time,job.Created_On as Datecreated,job.Created_By from Job_Master_IND job
                                join Location_Master loc on job.Location=loc.LocationID
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientContactID=job.Contactname
                                join CandidateJobIndia canjob on job.Jobcode=canjob.Jobcode   
                                join CandidateDetailsIndia can on can.candidateid = canjob.CandidateId
                                where job.Created_By like '%" + TWE_Id + "%' and can.Created_By like '%" + filtertype + "%'" +
                                " and  Cand_Status in ('103','105','107','110','111')) tb1 order by Datecreated desc,Created_Time desc --and Jobstatus not in ('10201') --order by job.Created_On desc";
                    }
                }

                
            }


            else if (tiletype == "TL Submitted")
            {
                if (jobEdit == "2" || jobView == "2" || jobFeedback == "2")
                {
                    strquery = @"select * from (select distinct job.Jobcode,JobTitle,Duration,empl.EmpTypeName,loc.LocationName,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage,job.Created_Time,job.Created_On as Datecreated,job.Created_By from Job_Master_IND job
                                join Location_Master loc on job.Location=loc.LocationID
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientContactID=job.Contactname
                                join CandidateJobIndia canjob on job.Jobcode=canjob.Jobcode   
                                join CandidateDetailsIndia can on can.candidateid = canjob.CandidateId
                                where Cand_Status in ('103')) tb1 order by Datecreated desc,Created_Time desc";
                }
                else
                {
                    strquery = @"select * from (select distinct job.Jobcode,JobTitle,Duration,empl.EmpTypeName,loc.LocationName,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage,job.Created_Time,job.Created_On as Datecreated,job.Created_By from Job_Master_IND job
                                join Location_Master loc on job.Location=loc.LocationID
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientContactID=job.Contactname
                                join CandidateJobIndia canjob on job.Jobcode=canjob.Jobcode   
                                join CandidateDetailsIndia can on can.candidateid = canjob.CandidateId
                                where job.Created_By like '%" + TWE_Id + "%'" +
                                " and  Cand_Status in ('103')) tb1 order by Datecreated desc,Created_Time desc";
                }
            }

           

            else if (tiletype == "No Submission")
            {
                //strquery = @"select job.Jobcode,JobTitle,Duration,empl.EmpTypeName,loc.LocationName,
                //                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                //                convert(varchar,job.Created_On,106) Created_On,Jobimage from Job_Master_IND job
                //                left join CandidateJobIndia canjob on job.Jobcode=canjob.Jobcode  
                //                left join CandidateDetailsIndia can on can.candidateid = canjob.CandidateId
                //                join Location_Master loc on job.Location=loc.LocationID
                //                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                //                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                //                join ClientMaster cli on cli.ClientID=job.Clientname
                //                join Client_Contact_Person con on con.ClientContactID=job.Contactname                           
                //                where Assigned_To like '%" + TWE_Id + "%' and job.Created_On between '" + fromdate + "' and '" + todate + "'" +
                //                " and Cand_Status='103' order by job.Created_On desc";
                if (nonsubJob != "")
                {
                    if (jobEdit == "2" || jobView == "2" || jobFeedback == "2")
                    {
                        strquery = @"select * from ( select distinct job.Jobcode,JobTitle,Duration,empl.EmpTypeName,loc.LocationName,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage,job.Created_Time,job.Created_On as Datecreated,job.Created_By from Job_Master_IND job
                                left join CandidateJobIndia canjob on job.Jobcode=canjob.Jobcode  
                                left join CandidateDetailsIndia can on can.candidateid = canjob.CandidateId
                                join Location_Master loc on job.Location=loc.LocationID
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientContactID=job.Contactname  
                                where job.Jobcode not in
                                (" + nonsubJob + ") and Jobstatus='10200' ) tb1 order by Datecreated desc,Created_Time desc ";
                    }
                    else
                    {
                        strquery = @"select * from ( select distinct job.Jobcode,JobTitle,Duration,empl.EmpTypeName,loc.LocationName,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage,job.Created_Time,job.Created_On as Datecreated,job.Created_By from Job_Master_IND job
                                left join CandidateJobIndia canjob on job.Jobcode=canjob.Jobcode  
                                left join CandidateDetailsIndia can on can.candidateid = canjob.CandidateId
                                join Location_Master loc on job.Location=loc.LocationID
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientContactID=job.Contactname  
                                where job.Jobcode not in
                                (" + nonsubJob + ") and job.Created_By like '%" + TWE_Id + "%'" + " and Jobstatus='10200' ) tb1 order by Datecreated desc,Created_Time desc ";
                    }
                }

            }

            else if (tiletype == "Interview")
            {
                if (jobEdit == "2" || jobView == "2" || jobFeedback == "2")
                {
                    strquery = @"select * from (
                                select distinct job.Jobcode,JobTitle,Duration,empl.EmpTypeName,loc.LocationName,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage,job.Created_Time,job.Created_On as Datecreated,job.Created_By from Job_Master_IND job
                                join Location_Master loc on job.Location=loc.LocationID
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientContactID=job.Contactname
                                join CandidateJobIndia canjob on job.Jobcode=canjob.Jobcode  
                                join CandidateDetailsIndia can on can.candidateid = canjob.CandidateId
                                where Cand_Status in ('110','111') and Jobstatus=10200 ) tb1 order by Datecreated desc,Created_Time desc";
                }
                else
                {
                    strquery = @"select * from (
                                select distinct job.Jobcode,JobTitle,Duration,empl.EmpTypeName,loc.LocationName,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage,job.Created_Time,job.Created_On as Datecreated,job.Created_By from Job_Master_IND job
                                join Location_Master loc on job.Location=loc.LocationID
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientContactID=job.Contactname
                                join CandidateJobIndia canjob on job.Jobcode=canjob.Jobcode  
                                join CandidateDetailsIndia can on can.candidateid = canjob.CandidateId
                                where job.Created_By like '%" + TWE_Id + "%'" +
                                " and Cand_Status in ('110','111') and Jobstatus=10200 ) tb1 order by Datecreated desc,Created_Time desc";
                }
            }
            
            else if (tiletype == "Overall")
            {

                strquery = @"select Jobcode,JobTitle,Duration,empl.EmpTypeName,loc.LocationName,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage,'' from Job_Master_IND job
                                join Location_Master loc on job.Location=loc.LocationID
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientContactID=job.Contactname
                                order by job.Created_On desc";
            }

            else if (tiletype == "Closure")
            {
                if (jobEdit == "2" || jobView == "2" || jobFeedback == "2")
                {
                    strquery = @"select * from (select distinct job.Jobcode,JobTitle,Duration,empl.EmpTypeName,loc.LocationName,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage,job.Created_By,job.Created_On as Datecreated,job.Created_Time from Job_Master_IND job
                                join Location_Master loc on job.Location=loc.LocationID
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientContactID=job.Contactname
                                join CandidateJobIndia canjob on job.Jobcode=canjob.Jobcode  
                                join CandidateDetailsIndia can on can.candidateid = canjob.CandidateId
                                where Cand_Status in ('109')) tb1 order by Datecreated desc,Created_Time desc ";
                }
                else
                {
                    strquery = @"select * from (select distinct job.Jobcode,JobTitle,Duration,empl.EmpTypeName,loc.LocationName,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage,job.Created_By,job.Created_On as Datecreated,job.Created_Time from Job_Master_IND job
                                join Location_Master loc on job.Location=loc.LocationID
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientContactID=job.Contactname
                                join CandidateJobIndia canjob on job.Jobcode=canjob.Jobcode  
                                join CandidateDetailsIndia can on can.candidateid = canjob.CandidateId
                                where job.Created_By like '%" + TWE_Id + "%'" +
                                " and Cand_Status in ('109')) tb1 order by Datecreated desc,Created_Time desc ";
                }
            }


            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                JobcodeList objJob = new JobcodeList();

                objJob.Jobcode = _read[0].ToString();
                objJob.JobTitle = _read[1].ToString();
                objJob.JobDuration = _read[2].ToString();
                objJob.JobType = _read[3].ToString();
                objJob.JobState = _read[4].ToString();
                objJob.JobStatus = _read[5].ToString();
                objJob.JobClient = _read[6].ToString();
                objJob.JobContact = _read[7].ToString();
                objJob.CreatedOn = _read[8].ToString();
                objJob.JobMediaPath = _read[9].ToString();
                objJob.Assigned_To = _read[10].ToString();
                _db.lstJob.Add(objJob);
            }

            _read.Close();


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
                _json.data = _db;
            }

            return _json;
        }


        public jsonArray getManagerJobdetails(string TWE_Id, string tiletype, string filtertype)
        {
            int status = 1;

            JobMaster _db = new JobMaster();
            _db.lstJob = new List<JobcodeList>();
            _db.lsttiles = new List<tiles>();
            
            string jobCreation = "";
            string jobEdit = "";
            string jobView = "";
            string jobFeedback = "";
            string strquery = @"SELECT [jobCreation],[jobEdit],[jobView],[jobFeedback] FROM [UserAccessPower] where userId='" + TWE_Id + "' ";
            SqlDataReader _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                jobCreation = _read[0].ToString();
                jobEdit = _read[1].ToString();
                jobView = _read[2].ToString();
                jobFeedback = _read[3].ToString();

            }
            _read.Close();

            if (jobEdit == "2" || jobView == "2" || jobFeedback == "2")
            {

                strquery = @"select * from
                                (select count(*) open_jobs from Job_Master_USA
                                where Jobstatus='10200') tb1," +
                                "(select count(distinct job.Jobcode) feedback_jobs from Job_Master_USA job" +
                                " join CandidateJob " +
                                " canjob on canjob.Jobcode=job.Jobcode" +
                                " join CandidateDetails can on canjob.CandidateId = can.candidateid " +
                                " where Cand_Status in (103,105,107,110,111) and Jobstatus=10200) tb2," +
                                "(select count(distinct job.Jobcode) TLSubmitted_jobs from Job_Master_USA job" +
                                " join CandidateJob " +
                                " canjob on canjob.Jobcode=job.Jobcode" +
                                " join CandidateDetails can on canjob.CandidateId = can.candidateid" +
                                " where Cand_Status=103 and Jobstatus=10200) tb3," +
                                " (select count(*) Nosubmission_jobs from CandidateJob can " +
                                " where jobcode not in (select Jobcode from Job_Master_USA " +
                                " where Jobstatus='10200'" +
                                " ))" +
                                " tb4,(select count(distinct job.Jobcode) interview_jobs from Job_Master_USA job" +
                                " join CandidateJob canjob on canjob.Jobcode=job.Jobcode" +
                                " join CandidateDetails can on canjob.CandidateId = can.candidateid" +
                                " where Cand_Status in ('110','111') and Jobstatus=10200) tb5," +
                                " (select count(distinct job.Jobcode) closure_jobs from Job_Master_USA job join" +
                                " CandidateJob canjob on canjob.Jobcode=job.Jobcode" +
                                " join CandidateDetails can on canjob.CandidateId = can.candidateid" +
                                " where Cand_Status in ('109')) tb6,(" +
                                " select count(*) overall_jobs from Job_Master_USA where Jobcode!='TWEUSA0000') tb7";
            }

            else
            {
                strquery = @"select * from
                                (select count(*) open_jobs from Job_Master_USA
                                where Created_By like '%" + TWE_Id + "%'  and Jobstatus='10200') tb1," +
                                "(select count(distinct job.Jobcode) feedback_jobs from Job_Master_USA job" +
                                " join CandidateJob " +
                                " canjob on canjob.Jobcode=job.Jobcode" +
                                " join CandidateDetails can on canjob.CandidateId = can.candidateid " +
                                " where job.Created_By like '%" + TWE_Id + "%' and Cand_Status in (103,105,107,110,111) and Jobstatus=10200) tb2," +
                                "(select count(distinct job.Jobcode) TLSubmitted_jobs from Job_Master_USA job" +
                                " join CandidateJob " +
                                " canjob on canjob.Jobcode=job.Jobcode" +
                                " join CandidateDetails can on canjob.CandidateId = can.candidateid" +
                                " where job.Created_By like '%" + TWE_Id + "%' and Cand_Status=103 and Jobstatus=10200) tb3," +
                                " (select count(*) Nosubmission_jobs from CandidateJob can " +
                                " where jobcode not in (select Jobcode from Job_Master_USA " +
                                " where Created_By like '%" + TWE_Id + "%' and Jobstatus='10200'" +
                                " ) and Created_By like '%" + TWE_Id + "%')" +
                                " tb4,(select count(distinct job.Jobcode) interview_jobs from Job_Master_USA job" +
                                " join CandidateJob canjob on canjob.Jobcode=job.Jobcode" +
                                " join CandidateDetails can on canjob.CandidateId = can.candidateid" +
                                " where job.Created_By like '%" + TWE_Id + "%' and Cand_Status in ('110','111') and Jobstatus=10200) tb5," +
                                " (select count(distinct job.Jobcode) closure_jobs from Job_Master_USA job join" +
                                " CandidateJob canjob on canjob.Jobcode=job.Jobcode" +
                                " join CandidateDetails can on canjob.CandidateId = can.candidateid" +
                                " where job.Created_By like '%" + TWE_Id + "%'  and Cand_Status in ('109')) tb6,(" +
                                " select count(*) overall_jobs from Job_Master_USA where Jobcode!='TWEUSA0000') tb7";
            }

            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                tiles objTile1 = new tiles();
                objTile1.TileTitle = "Open Jobs";
                objTile1.TotalCount = _read[0].ToString();
                _db.lsttiles.Add(objTile1);

                tiles objTile2 = new tiles();
                objTile2.TileTitle = "Feedback";
                objTile2.TotalCount = _read[1].ToString();
                _db.lsttiles.Add(objTile2);

                tiles objTile3 = new tiles();
                objTile3.TileTitle = "TL Submitted";
                objTile3.TotalCount = _read[2].ToString();
                _db.lsttiles.Add(objTile3);

                //tiles objTile4 = new tiles();
                //objTile4.TileTitle = "No Submission";
                //objTile4.TotalCount = _read[3].ToString();
                //_db.lsttiles.Add(objTile4);

                tiles objTile5 = new tiles();
                objTile5.TileTitle = "Interview";
                objTile5.TotalCount = _read[4].ToString();
                _db.lsttiles.Add(objTile5);

                tiles objTile6 = new tiles();
                objTile6.TileTitle = "Closure";
                objTile6.TotalCount = _read[5].ToString();
                _db.lsttiles.Add(objTile6);

                tiles objTile7 = new tiles();
                objTile7.TileTitle = "Overall Jobs";
                objTile7.TotalCount = _read[6].ToString();
                _db.lsttiles.Add(objTile7);

            }

            _read.Close();

            List<Jobcode> lstJob = new List<Jobcode>();

            strquery = @"select Jobcode from Job_Master_USA where Created_By like '%" + TWE_Id + "%' and Jobstatus='10200'";


            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                Jobcode obj = new Jobcode();
                obj.Jobcodename = _read[0].ToString();
                lstJob.Add(obj);
            }

            _read.Close();

            List<Jobcode> lstSubJob = new List<Jobcode>();

            strquery = @"select distinct job.jobcode from CandidateJob can
                            join Job_Master_USA job on job.Jobcode=can.Jobcode 
                            where job.Created_By like '%" + TWE_Id + "%' and Jobstatus='10200'";

            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                Jobcode obj = new Jobcode();
                obj.Jobcodename = _read[0].ToString();
                lstSubJob.Add(obj);
            }

            _read.Close();

            int nonsubCount = 0;
            string nonsubJob = "";

            for (int i = 0; i < lstJob.Count; i++)
            {

                for (int j = 0; j < lstSubJob.Count; j++)
                {
                    if (lstSubJob[j].Jobcodename == lstJob[i].Jobcodename)
                    {
                        nonsubCount++;
                        nonsubJob += "'" + lstSubJob[j].Jobcodename + "',";
                    }

                }

            }

            int noSub = lstJob.Count - nonsubCount;

            tiles objTile4 = new tiles();
            objTile4.TileTitle = "Nil Submissions";
            objTile4.TotalCount = noSub.ToString();
            _db.lsttiles.Add(objTile4);

            if (nonsubJob.Length!=0)
            {
                nonsubJob = nonsubJob.Substring(0, nonsubJob.Length - 1);
            }
           

            if (tiletype == "Open")
            {
                if (jobEdit == "2" || jobView == "2" || jobFeedback == "2")
                {
                    strquery = @"select Jobcode,JobTitle,Duration,empl.EmpTypeName,loc.LocationName,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage,job.Created_By from Job_Master_USA job
                                join Location_Master loc on job.Location=loc.LocationID
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientContactID=job.Contactname
                                where Jobstatus='10200' order by job.Created_On desc";
                }
                else
                {
                    strquery = @"select Jobcode,JobTitle,Duration,empl.EmpTypeName,loc.LocationName,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage,job.Created_By from Job_Master_USA job
                                join Location_Master loc on job.Location=loc.LocationID
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientContactID=job.Contactname
                                where job.Created_By like '%" + TWE_Id + "%'" + " and Jobstatus='10200' order by job.Created_On desc";
                }

            }
            else if (tiletype == "Feedback")
            {
                if (filtertype == "All")
                {
                    if (jobEdit == "2" || jobView == "2" || jobFeedback == "2")
                    {
                        strquery = @"select * from (select distinct job.Jobcode,JobTitle,Duration,empl.EmpTypeName,loc.LocationName,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage,job.Created_By ,job.Created_Time,job.Created_On as Datecreated from Job_Master_USA job
                                join Location_Master loc on job.Location=loc.LocationID
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientContactID=job.Contactname
                                join CandidateJob canjob on job.Jobcode=canjob.Jobcode   
                                join CandidateDetails can on can.candidateid = canjob.CandidateId
                                where Cand_Status in ('103','105','107','110','111') and Jobstatus=10200) tb1 order by Datecreated desc,Created_Time desc --and Jobstatus not in ('10201') --order by job.Created_On desc";
                    }
                    else
                    {
                        strquery = @"select * from (select distinct job.Jobcode,JobTitle,Duration,empl.EmpTypeName,loc.LocationName,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage,job.Created_By ,job.Created_Time,job.Created_On as Datecreated from Job_Master_USA job
                                join Location_Master loc on job.Location=loc.LocationID
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientContactID=job.Contactname
                                join CandidateJob canjob on job.Jobcode=canjob.Jobcode   
                                join CandidateDetails can on can.candidateid = canjob.CandidateId
                                where job.Created_By like '%" + TWE_Id + "%'" +
                                " and  Cand_Status in ('103','105','107','110','111') and Jobstatus=10200) tb1 order by Datecreated desc,Created_Time desc --and Jobstatus not in ('10201') --order by job.Created_On desc";
                    }
                }
                else
                {
                    if (jobEdit == "2" || jobView == "2" || jobFeedback == "2")
                    {
                        strquery = @"select * from (select distinct job.Jobcode,JobTitle,Duration,empl.EmpTypeName,loc.LocationName,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage,job.Created_By,job.Created_Time,job.Created_On as Datecreated from Job_Master_USA job
                                join Location_Master loc on job.Location=loc.LocationID
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientContactID=job.Contactname
                                join CandidateJob canjob on job.Jobcode=canjob.Jobcode   
                                join CandidateDetails can on can.candidateid = canjob.CandidateId
                                where can.Created_By like '%" + filtertype + "%'" +
                                " and  Cand_Status in ('103','105','107','110','111')) tb1 order by Datecreated desc,Created_Time desc --and Jobstatus not in ('10201') --order by job.Created_On desc";
                    }
                    else
                    {
                        strquery = @"select * from (select distinct job.Jobcode,JobTitle,Duration,empl.EmpTypeName,loc.LocationName,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage,job.Created_By,job.Created_Time,job.Created_On as Datecreated from Job_Master_USA job
                                join Location_Master loc on job.Location=loc.LocationID
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientContactID=job.Contactname
                                join CandidateJob canjob on job.Jobcode=canjob.Jobcode   
                                join CandidateDetails can on can.candidateid = canjob.CandidateId
                                where job.Created_By like '%" + TWE_Id + "%' and can.Created_By like '%" + filtertype + "%'" +
                                " and  Cand_Status in ('103','105','107','110','111')) tb1 order by Datecreated desc,Created_Time desc --and Jobstatus not in ('10201') --order by job.Created_On desc";
                    }
                }
            }


            else if (tiletype == "TL Submitted")
            {
                if (jobEdit == "2" || jobView == "2" || jobFeedback == "2")
                {
                    strquery = @"select * from (select distinct job.Jobcode,JobTitle,Duration,empl.EmpTypeName,loc.LocationName,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage,job.Created_By ,job.Created_Time,job.Created_On as Datecreated from Job_Master_USA job
                                join Location_Master loc on job.Location=loc.LocationID
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientContactID=job.Contactname
                                join CandidateJob canjob on job.Jobcode=canjob.Jobcode   
                                join CandidateDetails can on can.candidateid = canjob.CandidateId
                                where Cand_Status in ('103') and Jobstatus not in ('10201')) tb1 order by Datecreated desc,Created_Time desc";
                }

                else
                {
                    strquery = @"select * from (select distinct job.Jobcode,JobTitle,Duration,empl.EmpTypeName,loc.LocationName,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage,job.Created_By,job.Created_Time,job.Created_On as Datecreated from Job_Master_USA job
                                join Location_Master loc on job.Location=loc.LocationID
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientContactID=job.Contactname
                                join CandidateJob canjob on job.Jobcode=canjob.Jobcode   
                                join CandidateDetails can on can.candidateid = canjob.CandidateId
                                where job.Created_By like '%" + TWE_Id + "%'" +
                                " and  Cand_Status in ('103') and Jobstatus not in ('10201')) tb1 order by Datecreated desc,Created_Time desc";
                }
            }



            else if (tiletype == "No Submission")
            {
                //strquery = @"select job.Jobcode,JobTitle,Duration,empl.EmpTypeName,loc.LocationName,
                //                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                //                convert(varchar,job.Created_On,106) Created_On,Jobimage from Job_Master_USA job
                //                left join CandidateJob canjob on job.Jobcode=canjob.Jobcode  
                //                left join CandidateDetails can on can.candidateid = canjob.CandidateId
                //                join Location_Master loc on job.Location=loc.LocationID
                //                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                //                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                //                join ClientMaster cli on cli.ClientID=job.Clientname
                //                join Client_Contact_Person con on con.ClientContactID=job.Contactname                           
                //                where Assigned_To like '%" + TWE_Id + "%' and job.Created_On between '" + fromdate + "' and '" + todate + "'" +
                //                " and Cand_Status='103' order by job.Created_On desc";
                if (nonsubJob != "")
                {
                    if (jobEdit == "2" || jobView == "2" || jobFeedback == "2")
                    {
                        strquery = @"select * from ( select distinct job.Jobcode,JobTitle,Duration,empl.EmpTypeName,loc.LocationName,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage,job.Created_By,job.Created_Time,job.Created_On as Datecreated from Job_Master_USA job
                                left join CandidateJob canjob on job.Jobcode=canjob.Jobcode  
                                left join CandidateDetails can on can.candidateid = canjob.CandidateId
                                join Location_Master loc on job.Location=loc.LocationID
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientContactID=job.Contactname  
                                where job.Jobcode not in
                                (" + nonsubJob + ") and Jobstatus='10200') tb1 order by Datecreated desc,Created_Time desc ";
                    }
                    else
                    {
                        strquery = @"select * from ( select distinct job.Jobcode,JobTitle,Duration,empl.EmpTypeName,loc.LocationName,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage,job.Created_By,job.Created_Time,job.Created_On as Datecreated from Job_Master_USA job
                                left join CandidateJob canjob on job.Jobcode=canjob.Jobcode  
                                left join CandidateDetails can on can.candidateid = canjob.CandidateId
                                join Location_Master loc on job.Location=loc.LocationID
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientContactID=job.Contactname  
                                where job.Jobcode not in
                                (" + nonsubJob + ") and job.Created_By like '%" + TWE_Id + "%'" + " and Jobstatus='10200') tb1 order by Datecreated desc,Created_Time desc ";
                    }
                }

            }

            else if (tiletype == "Interview")
            {
                if (jobEdit == "2" || jobView == "2" || jobFeedback == "2")
                {
                    strquery = @"select * from (
                                select job.Jobcode,JobTitle,Duration,empl.EmpTypeName,loc.LocationName,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage,job.Created_By,job.Created_Time,job.Created_On as Datecreated from Job_Master_USA job
                                join Location_Master loc on job.Location=loc.LocationID
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientContactID=job.Contactname
                                join CandidateJob canjob on job.Jobcode=canjob.Jobcode  
                                join CandidateDetails can on can.candidateid = canjob.CandidateId
                                where Cand_Status in ('110','111') and Jobstatus=10200) tb1 order by Datecreated desc,Created_Time desc";
                }
                else
                {
                    strquery = @"select * from (
                                select job.Jobcode,JobTitle,Duration,empl.EmpTypeName,loc.LocationName,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage,job.Created_By,job.Created_Time,job.Created_On as Datecreated from Job_Master_USA job
                                join Location_Master loc on job.Location=loc.LocationID
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientContactID=job.Contactname
                                join CandidateJob canjob on job.Jobcode=canjob.Jobcode  
                                join CandidateDetails can on can.candidateid = canjob.CandidateId
                                where Assigned_To like '%" + TWE_Id + "%'" +
                                " and Cand_Status in ('110','111') and Jobstatus=10200) tb1 order by Datecreated desc,Created_Time desc";
                }
            }

            else if (tiletype == "Overall")
            {
                strquery = @"select Jobcode,JobTitle,Duration,empl.EmpTypeName,loc.LocationName,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage,job.Created_By from Job_Master_USA job
                                join Location_Master loc on job.Location=loc.LocationID
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientContactID=job.Contactname
                                order by job.Created_On desc";
            }

            else if (tiletype == "Closure")
            {
                if (jobEdit == "2" || jobView == "2" || jobFeedback == "2")
                {
                    strquery = @"select * from (
                                select distinct job.Jobcode,JobTitle,Duration,empl.EmpTypeName,loc.LocationName,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage,job.Created_By,job.Created_Time,job.Created_On as Datecreated from Job_Master_USA job
                                join Location_Master loc on job.Location=loc.LocationID
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientContactID=job.Contactname
                                join CandidateJob canjob on job.Jobcode=canjob.Jobcode  
                                join CandidateDetails can on can.candidateid = canjob.CandidateId
                                where Cand_Status in ('109')) tb1 order by Datecreated desc,Created_Time desc";
                }
                else
                {
                    strquery = @"select * from (
                                select distinct job.Jobcode,JobTitle,Duration,empl.EmpTypeName,loc.LocationName,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage,job.Created_By,job.Created_Time,job.Created_On as Datecreated from Job_Master_USA job
                                join Location_Master loc on job.Location=loc.LocationID
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientContactID=job.Contactname
                                join CandidateJob canjob on job.Jobcode=canjob.Jobcode  
                                join CandidateDetails can on can.candidateid = canjob.CandidateId
                                where Assigned_To like '%" + TWE_Id + "%'" +
                                " and Cand_Status in ('109')) tb1 order by Datecreated desc,Created_Time desc";

                }
               
            }


            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                JobcodeList objJob = new JobcodeList();

                objJob.Jobcode = _read[0].ToString();
                objJob.JobTitle = _read[1].ToString();
                objJob.JobDuration = _read[2].ToString();
                objJob.JobType = _read[3].ToString();
                objJob.JobState = _read[4].ToString();
                objJob.JobStatus = _read[5].ToString();
                objJob.JobClient = _read[6].ToString();
                objJob.JobContact = _read[7].ToString();
                objJob.CreatedOn = _read[8].ToString();
                objJob.JobMediaPath = _read[9].ToString();
                objJob.Assigned_To = _read[10].ToString();
                _db.lstJob.Add(objJob);
            }

            _read.Close();


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
                _json.data = _db;
            }

            return _json;
        }


        public jsonArray getJobdetails(string TWE_Id, string fromdate, string todate, string tiletype)
        {
            int status = 1;

            JobMaster _db = new JobMaster();
            _db.lstJob = new List<JobcodeList>();
            _db.lsttiles = new List<tiles>();

            string jobCreation = "";
            string jobEdit = "";
            string jobView = "";
            string jobFeedback = "";
            string strquery = @"SELECT [jobCreation],[jobEdit],[jobView],[jobFeedback] FROM [UserAccessPower] where userId='" + TWE_Id + "' ";
            SqlDataReader _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                jobCreation = _read[0].ToString();
                jobEdit = _read[1].ToString();
                jobView = _read[2].ToString();
                jobFeedback = _read[3].ToString();

            }
            _read.Close();

            if (jobEdit == "2" || jobView == "2")
            {
                strquery = @"select * from
                            (select count(*) open_jobs from Job_Master_USA
                            where Jobstatus='10200'" +
                            ") tb1,(" +
                            "select count(*) pipeline_jobs from Job_Master_USA job" +
                            " join CandidateJob canjob on canjob.Jobcode=job.Jobcode " +
                            "join CandidateDetails can on canjob.CandidateId = can.candidateid" +
                            " where Cand_Status='102'" +
                            ") tb2,(" +
                            "select count(*) High_jobs from Job_Master_USA job" +
                            " where Prioritylevel='10300'" +
                            ") tb3,(" +
                            "select count(*) Nosubmission_jobs from CandidateJob can" +
                            " where jobcode not in (select Jobcode from Job_Master_USA where Assigned_To like '%" + TWE_Id + "%' and Jobstatus='10200'" +
                            ")" +
                            " and Created_By like '%" + TWE_Id + "%' " +

                            ") tb4,(" +
                            "select count(*) interview_jobs from Job_Master_USA job" +
                            " join CandidateJob canjob on canjob.Jobcode=job.Jobcode" +
                            " join CandidateDetails can on canjob.CandidateId = can.candidateid" +
                            " where Cand_Status in ('110','111')" +
                            ") tb5,(" +
                            "select count(*) closure_jobs from Job_Master_USA job" +
                            " join CandidateJob canjob on canjob.Jobcode=job.Jobcode" +
                            " join CandidateDetails can on canjob.CandidateId = can.candidateid" +
                            " where Cand_Status in ('109')" +
                             ") tb6," +
                            "(select count(*) total_jobs from Job_Master_USA" +
                            ") tb7";
            }

            else
            {
                strquery = @"select * from
                            (select count(*) open_jobs from Job_Master_USA
                            where Assigned_To like '%" + TWE_Id + "%' " +
                            " and Jobstatus='10200'" +
                            ") tb1,(" +
                            "select count(*) pipeline_jobs from Job_Master_USA job" +
                            " join CandidateJob canjob on canjob.Jobcode=job.Jobcode " +
                            "join CandidateDetails can on canjob.CandidateId = can.candidateid" +
                            " where Assigned_To like '%" + TWE_Id + "%' " +

                            " and Cand_Status='102'" +
                            ") tb2,(" +
                            "select count(*) High_jobs from Job_Master_USA job" +
                            " where Assigned_To like '%" + TWE_Id + "%' " +

                            " and Prioritylevel='10300'" +
                            ") tb3,(" +
                            "select count(*) Nosubmission_jobs from CandidateJob can" +
                            " where jobcode not in (select Jobcode from Job_Master_USA where Assigned_To like '%" + TWE_Id + "%' and Jobstatus='10200'" +
                            ")" +
                            " and Created_By like '%" + TWE_Id + "%' " +

                            ") tb4,(" +
                            "select count(*) interview_jobs from Job_Master_USA job" +
                            " join CandidateJob canjob on canjob.Jobcode=job.Jobcode" +
                            " join CandidateDetails can on canjob.CandidateId = can.candidateid" +
                            " where Assigned_To like '%" + TWE_Id + "%' " +

                            " and Cand_Status in ('110','111')" +
                            ") tb5,(" +
                            "select count(*) closure_jobs from Job_Master_USA job" +
                            " join CandidateJob canjob on canjob.Jobcode=job.Jobcode" +
                            " join CandidateDetails can on canjob.CandidateId = can.candidateid" +
                            " where Assigned_To like '%" + TWE_Id + "%' " +

                            " and Cand_Status in ('109')" +
                             ") tb6," +
                            "(select count(*) total_jobs from Job_Master_USA" +
                            " where Assigned_To like '%" + TWE_Id + "%' " +

                            ") tb7";

            }


            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                tiles objTile1 = new tiles();
                objTile1.TileTitle = "Open Jobs";
                objTile1.TotalCount = _read[0].ToString();
                _db.lsttiles.Add(objTile1);

                tiles objTile2 = new tiles();
                objTile2.TileTitle = "Pipeline";
                objTile2.TotalCount = _read[1].ToString();
                _db.lsttiles.Add(objTile2);

                tiles objTile3 = new tiles();
                objTile3.TileTitle = "High Priority";
                objTile3.TotalCount = _read[2].ToString();
                _db.lsttiles.Add(objTile3);

                //tiles objTile4 = new tiles();
                //objTile4.TileTitle = "No Submission";
                //objTile4.TotalCount = _read[3].ToString();
                //_db.lsttiles.Add(objTile4);

                tiles objTile5 = new tiles();
                objTile5.TileTitle = "Interview";
                objTile5.TotalCount = _read[4].ToString();
                _db.lsttiles.Add(objTile5);

                tiles objTile6 = new tiles();
                objTile6.TileTitle = "Closure";
                objTile6.TotalCount = _read[5].ToString();
                _db.lsttiles.Add(objTile6);

                tiles objTile7 = new tiles();
                objTile7.TileTitle = "Assigned Jobs";
                objTile7.TotalCount = _read[6].ToString();
                _db.lsttiles.Add(objTile7);

            }

            _read.Close();

            //List<Jobcode> lstJob = new List<Jobcode>();

            //strquery = @"select Jobcode from Job_Master_USA where Assigned_To like '%" + TWE_Id + "%' and Jobstatus='10200'";


            //_read = _sql.doRead(strquery);

            //while (_read.Read())
            //{
            //    Jobcode obj = new Jobcode();
            //    obj.Jobcodename = _read[0].ToString();
            //    lstJob.Add(obj);
            //}

            //_read.Close();

            //string strVar = "";

            //if (lstJob.Count != 0)
            //{
            //    for (int i = 0; i < lstJob.Count; i++)
            //    {
            //        strVar += "'" + lstJob[i].Jobcodename + "',";
            //    }

            //    strVar = strVar.Substring(0, strVar.Length - 1);

            //    strquery = @"select count(distinct Jobcode) Nosubmission_jobs from CandidateJob can where jobcode in (" + strVar + ")";

            //    _read = _sql.doRead(strquery);


            //    while (_read.Read())
            //    {
            //        tiles objTile4 = new tiles();
            //        objTile4.TileTitle = "Nil Submissions";
            //        objTile4.TotalCount = (lstJob.Count - Convert.ToInt32(_read[0])).ToString();
            //        _db.lsttiles.Add(objTile4);

            //    }
            //    _read.Close();
            //}

            //else
            //{
            //    tiles objTile4 = new tiles();
            //    objTile4.TileTitle = "Nil Submissions";
            //    objTile4.TotalCount = "0";
            //    _db.lsttiles.Add(objTile4);
            //}

            List<Jobcode> lstJob = new List<Jobcode>();

            strquery = @"select Jobcode from Job_Master_USA where Assigned_To like '%" + TWE_Id + "%' and Jobstatus='10200'";


            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                Jobcode obj = new Jobcode();
                obj.Jobcodename = _read[0].ToString();
                lstJob.Add(obj);
            }

            _read.Close();

            List<Jobcode> lstSubJob = new List<Jobcode>();

            strquery = @"select distinct job.jobcode from CandidateJob can
                            join Job_Master_USA job on job.Jobcode=can.Jobcode
                            where Assigned_To like '%" + TWE_Id + "%' and Jobstatus='10200'";

            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                Jobcode obj = new Jobcode();
                obj.Jobcodename = _read[0].ToString();
                lstSubJob.Add(obj);
            }

            _read.Close();

            int nonsubCount = 0;
            string nonsubJob = "";

            for (int i = 0; i < lstJob.Count; i++)
            {

                for (int j = 0; j < lstSubJob.Count; j++)
                {
                    if (lstSubJob[j].Jobcodename == lstJob[i].Jobcodename)
                    {
                        nonsubCount++;
                        nonsubJob += "'" + lstSubJob[j].Jobcodename + "',";
                    }

                }

            }

            int noSub = lstJob.Count - nonsubCount;

            tiles objTile4 = new tiles();
            objTile4.TileTitle = "Nil Submissions";
            objTile4.TotalCount = noSub.ToString();
            _db.lsttiles.Add(objTile4);
            if (nonsubJob.Length != 0)
            {
                nonsubJob = nonsubJob.Substring(0, nonsubJob.Length - 1);
            }

            if (tiletype == "Open")
            {
                if (jobEdit == "2" || jobView == "2")
                {
                    strquery = @"select Jobcode,JobTitle,Duration,empl.EmpTypeName,job.City,State,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage,Assigned_To from Job_Master_USA job
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientContactID =job.Contactname
                                where Jobstatus='10200' order by job.Created_On desc";
                }
                else
                {
                    strquery = @"select Jobcode,JobTitle,Duration,empl.EmpTypeName,job.City,State,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage,Assigned_To from Job_Master_USA job
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientContactID =job.Contactname
                                where Assigned_To like '%" + TWE_Id + "%'" + " and Jobstatus='10200' order by job.Created_On desc";
                }
            }

            else if (tiletype == "Pipeline")
            {
                if (jobEdit == "2" || jobView == "2")
                {
                    strquery = @"select job.Jobcode,JobTitle,Duration,empl.EmpTypeName,job.City,State,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar, job.Created_On, 106) Created_On,Jobimage,Assigned_To from Job_Master_USA job
                                join EmploymentType_Master empl on empl.EmpTypeID = job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID = job.Jobstatus
                                join ClientMaster cli on cli.ClientID = job.Clientname
                                join Client_Contact_Person con on con.ClientContactID =job.Contactname                
                                join CandidateJob canjob on job.Jobcode=canjob.Jobcode                  
                                join CandidateDetails can on can.candidateid = canjob.CandidateId
                                where Cand_Status = '102' order by job.Created_On desc";
                }
                else
                {
                    strquery = @"select job.Jobcode,JobTitle,Duration,empl.EmpTypeName,job.City,State,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar, job.Created_On, 106) Created_On,Jobimage,Assigned_To from Job_Master_USA job
                                join EmploymentType_Master empl on empl.EmpTypeID = job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID = job.Jobstatus
                                join ClientMaster cli on cli.ClientID = job.Clientname
                                join Client_Contact_Person con on con.ClientContactID =job.Contactname                
                                join CandidateJob canjob on job.Jobcode=canjob.Jobcode                  
                                join CandidateDetails can on can.candidateid = canjob.CandidateId
                                where Assigned_To like '%" + TWE_Id + "%'" +
                                " and Cand_Status = '102' order by job.Created_On desc";
                }
            }

            else if (tiletype == "High Priority")
            {
                if (jobEdit == "2" || jobView == "2")
                {
                    strquery = @"select Jobcode,JobTitle,Duration,empl.EmpTypeName,job.City,State,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage,Assigned_To from Job_Master_USA job
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientContactID =job.Contactname
                                where Prioritylevel='10300' order by job.Created_On desc";
                }
                else
                {
                    strquery = @"select Jobcode,JobTitle,Duration,empl.EmpTypeName,job.City,State,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage,Assigned_To from Job_Master_USA job
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientContactID =job.Contactname
                                where Assigned_To like '%" + TWE_Id + "%'" +
                                " and Prioritylevel='10300' order by job.Created_On desc";
                }
            }

            else if (tiletype == "No Submission")
            {
                if (jobEdit == "2" || jobView == "2")
                {
                    strquery = @"select job.Jobcode,JobTitle,Duration,empl.EmpTypeName,job.City,State,
                            stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                            convert(varchar,job.Created_On,106) Created_On,Jobimage,Assigned_To from Job_Master_USA job
                            left join CandidateJob canjob on job.Jobcode=canjob.Jobcode                  
                            left join CandidateDetails can on can.candidateid = canjob.CandidateId
                            join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                            join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                            join ClientMaster cli on cli.ClientID=job.Clientname
                            join Client_Contact_Person con on con.ClientContactID =job.Contactname
                            group by job.Jobcode,Assigned_To,job.Created_on,JobTitle,Duration,empl.EmpTypeName,job.City,State,
                            stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,Jobimage
                            having " +
                            //"job.Created_on between '" + fromdate + "' and '" + todate + "' and " +
                            "count(canjob.candidateid)=0  order by job.Created_On desc";
                }
                else
                {
                    strquery = @"select job.Jobcode,JobTitle,Duration,empl.EmpTypeName,job.City,State,
                            stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                            convert(varchar,job.Created_On,106) Created_On,Jobimage,Assigned_To from Job_Master_USA job
                            left join CandidateJob canjob on job.Jobcode=canjob.Jobcode                  
                            left join CandidateDetails can on can.candidateid = canjob.CandidateId
                            join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                            join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                            join ClientMaster cli on cli.ClientID=job.Clientname
                            join Client_Contact_Person con on con.ClientContactID =job.Contactname
                            group by job.Jobcode,Assigned_To,job.Created_on,JobTitle,Duration,empl.EmpTypeName,job.City,State,
                            stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,Jobimage
                            having Assigned_To like '%" + TWE_Id + "%' and " +
                            //"job.Created_on between '" + fromdate + "' and '" + todate + "' and " +
                            "count(canjob.candidateid)=0  order by job.Created_On desc";

                }
            }

            else if (tiletype == "Interview")
            {
                if (jobEdit == "2" || jobView == "2")
                {
                    strquery = @"select job.Jobcode,JobTitle,Duration,empl.EmpTypeName,job.City,State,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage,Assigned_To from Job_Master_USA job
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientContactID =job.Contactname
                                join CandidateJob canjob on job.Jobcode=canjob.Jobcode                  
                                join CandidateDetails can on can.candidateid = canjob.CandidateId
                                where Cand_Status in ('110','111') order by job.Created_On desc";
                }
                else
                {
                    strquery = @"select job.Jobcode,JobTitle,Duration,empl.EmpTypeName,job.City,State,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage,Assigned_To from Job_Master_USA job
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientContactID =job.Contactname
                                join CandidateJob canjob on job.Jobcode=canjob.Jobcode                  
                                join CandidateDetails can on can.candidateid = canjob.CandidateId
                                where Assigned_To like '%" + TWE_Id + "%'" +
                                " and Cand_Status in ('110','111') order by job.Created_On desc";
                }
            }
            else if (tiletype == "Follow Up")
            {
                if (jobEdit == "2" || jobView == "2")
                {
                    strquery = @"select * from (select distinct job.Jobcode,JobTitle,Duration,empl.EmpTypeName,job.City,State,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage,Assigned_To from Job_Master_USA job
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientContactID =job.Contactname
                                join CandidateJob canjob on job.Jobcode=canjob.Jobcode                  
                                join CandidateDetails can on can.candidateid = canjob.CandidateId
                                where Cand_Status in ('103','105','107','110','111') and Jobstatus not in ('10201')) tb1 order by Created_On desc";
                }
                else
                {
                    strquery = @"select * from (select distinct job.Jobcode,JobTitle,Duration,empl.EmpTypeName,job.City,State,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage,Assigned_To from Job_Master_USA job
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientContactID =job.Contactname
                                join CandidateJob canjob on job.Jobcode=canjob.Jobcode                  
                                join CandidateDetails can on can.candidateid = canjob.CandidateId
                                where Assigned_To like '%" + TWE_Id + "%'" +
                               " and  Cand_Status in ('103','105','107','110','111') and Jobstatus not in ('10201')) tb1 order by Created_On desc";

                }
            }
            else if (tiletype == "Total")
            {
                if (jobEdit == "2" || jobView == "2")
                {
                    strquery = @"select Jobcode,JobTitle,Duration,empl.EmpTypeName,job.City,State,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage,Assigned_To from Job_Master_USA job
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientContactID =job.Contactname
                                order by job.Created_On desc";
                }
                else
                {
                    strquery = @"select Jobcode,JobTitle,Duration,empl.EmpTypeName,job.City,State,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage,Assigned_To from Job_Master_USA job
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientContactID =job.Contactname
                                where Assigned_To like '%" + TWE_Id + "%' order by job.Created_On desc";
                }
            }
            else if (tiletype == "Closure")
            {
                if (jobEdit == "2" || jobView == "2")
                {
                    strquery = @"select job.Jobcode,JobTitle,Duration,empl.EmpTypeName,job.City,State,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage,Assigned_To from Job_Master_USA job
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientContactID =job.Contactname
                                join CandidateJob canjob on job.Jobcode=canjob.Jobcode                  
                                join CandidateDetails can on can.candidateid = canjob.CandidateId
                                where Cand_Status in ('109') order by job.Created_On desc";
                }
                else
                {
                    strquery = @"select job.Jobcode,JobTitle,Duration,empl.EmpTypeName,job.City,State,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage,Assigned_To from Job_Master_USA job
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientContactID =job.Contactname
                                join CandidateJob canjob on job.Jobcode=canjob.Jobcode                  
                                join CandidateDetails can on can.candidateid = canjob.CandidateId
                                where Assigned_To like '%" + TWE_Id + "%'" +
                                " and Cand_Status in ('109') order by job.Created_On desc";
                }
            }

            //else if (tiletype == "Feedback")
            //{
            //    strquery = @"select distinct job.Jobcode,JobTitle,Duration,empl.EmpTypeName,City,State,
            //                    stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
            //                    convert(varchar,job.Created_On,106) Created_On,Jobimage from Job_Master_USA job
            //                    join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
            //                    join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
            //                    join ClientMaster cli on cli.ClientID=job.Clientname
            //                    join Client_Contact_Person con on con.ClientContactID =job.Contactname
            //                    join CandidateJob canjob on job.Jobcode=canjob.Jobcode                  
            //                    join CandidateDetails can on can.candidateid = canjob.CandidateId
            //                    where job.Created_By like '%" + TWE_Id + "%'" +
            //                    "--and can.Created_On between '" + fromdate + "' and '" + todate + "'" +
            //                    " and  Cand_Status in ('103','105','107','110','111') and Jobstatus not in ('10201') order by job.Created_On desc";
            //}

            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                JobcodeList objJob = new JobcodeList();

                objJob.Jobcode = _read[0].ToString();
                objJob.JobTitle = _read[1].ToString();
                objJob.JobDuration = _read[2].ToString();
                objJob.JobType = _read[3].ToString();
                objJob.JobCity = _read[4].ToString();
                objJob.JobState = _read[5].ToString();
                objJob.JobStatus = _read[6].ToString();
                objJob.JobClient = _read[7].ToString();
                objJob.JobContact = _read[8].ToString();
                objJob.CreatedOn = _read[9].ToString();
                objJob.JobMediaPath = _read[10].ToString();
                objJob.Assigned_To = _read[11].ToString();
                _db.lstJob.Add(objJob);
            }

            _read.Close();


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
                _json.data = _db;
            }

            return _json;
        }

        public jsonArray downloadfiles(string spath)
        {
            int status = 1;
            Jobcode obj = new Jobcode();
            string files="";
            //string remoteUri = HttpContext.Current.Server.MapPath("~/Candidate/Resume/"); ;
            //string pathUser = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            //string pathDownload = Path.Combine(pathUser, @"Downloads\\");

            //var destFile = pathDownload + spath;
            //string fileName = spath, myStringWebResource = null;
            //obj.Jobimage = destFile;
            //obj.JobTitle = pathUser;
            //// Create a new WebClient instance.
            //WebClient myWebClient = new WebClient();
            //// Concatenate the domain with the Web resource filename.
            //myStringWebResource = remoteUri + fileName;
            ////Console.WriteLine("Downloading File \"{0}\" from \"{1}\" .......\n\n", fileName, myStringWebResource);
            //// Download the Web resource and save it into the current filesystem folder.
            //try
            //{
            //    myWebClient.DownloadFileAsync(new Uri(myStringWebResource), destFile);
            //}
            //catch (Exception ex)
            //{
            //    var path = HttpContext.Current.Server.MapPath("~/error"); ;

            //    string text = ex.InnerException.ToString();
            //    byte[] data = Encoding.ASCII.GetBytes(text);
            //    string newFileName = Guid.NewGuid() + ".txt";
            //    File.WriteAllBytes(Path.Combine(path, newFileName), data);
            //}

            string path = HttpContext.Current.Server.MapPath("~/Candidate/Resume/");

            //Read the File as Byte Array.
            byte[] bytes = File.ReadAllBytes(path + spath);

            //Convert File to Base64 string and send to Client.
            files= Convert.ToBase64String(bytes, 0, bytes.Length);




            //HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            //string fileName = "Koshy-ABAP WM-INV00134-072021.pdf";
            //string sPath = HttpContext.Current.Server.MapPath("~/Candidate/Resume/" + fileName);
            ////System.Collections.Specialized.NameValueCollection s1 = System.Web.HttpContext.Current.Request.Form;

            ////string[] str = s1.AllKeys;

            ////sPath = System.Web.Hosting.HostingEnvironment.MapPath("~/Candidate/Resume_India/" + str[0] + "/");


            ////Set the File Path.
            ////string filePath = System.Web.HttpContext.Current.Server.MapPath("~/Candidate/") + sPath;

            ////Check whether File exists.
            //if (!File.Exists(sPath))
            //{
            //    //Throw 404 (Not Found) exception if File not found.
            //    response.StatusCode = HttpStatusCode.NotFound;
            //    response.ReasonPhrase = string.Format("File not found: {0} .", fileName);
            //    throw new HttpResponseException(response);
            //}

            ////Read the File into a Byte Array.
            //byte[] bytes = File.ReadAllBytes(sPath);

            ////Set the Response Content.
            //response.Content = new ByteArrayContent(bytes);

            ////Set the Response Content Length.
            //response.Content.Headers.ContentLength = bytes.LongLength;

            ////Set the Content Disposition Header Value and FileName.
            //response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            //response.Content.Headers.ContentDisposition.FileName = fileName;

            ////Set the File Content Type.
            //response.Content.Headers.ContentType = new MediaTypeHeaderValue(MimeMapping.GetMimeMapping(fileName));
            //return response;

            //int status = 1;

            //Jobcode obj = new Jobcode();

            //string pdfFiles = Path.GetFileName(spath);
            //var sourceFile = "";
            //try
            //{

            //    //sourceFile = HttpContext.Current.Server.MapPath("~/Candidate/Resume/" + spath);
            //    //sourceFile = "techwaukee.com/hunTcreW.Testing.techwaukee.com/Candidate/Resume/SAP_job.png";

            //    obj.JobTitle = sourceFile;
            //}

            //catch(Exception ex)
            //{
            //    var path = HttpContext.Current.Server.MapPath("~/error"); ;

            //    string text = ex.Message.ToString();
            //    byte[] data = Encoding.ASCII.GetBytes(text);
            //    string newFileName = Guid.NewGuid() + ".txt";
            //    File.WriteAllBytes(Path.Combine(path, newFileName), data);
            //}

            //var target = "";

            //target= System.Web.Hosting.HostingEnvironment.MapPath("~/Candidate/Resume/" + spath);
            //obj.Jobimage = target;

            //try
            //{
            //    //string pathUser = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            //    //string pathDownload = Path.Combine(pathUser, "Downloads\\");

            //    //var destFile = pathDownload + pdfFiles;


            //    //byte[] bytes = File.ReadAllBytes(target);
            //    //System.IO.File.WriteAllBytes(destFile, bytes);

            //    var memory = new MemoryStream();
            //    using (var stream = new FileStream(target, FileMode.Open))
            //    {
            //        stream.CopyToAsync(memory);
            //    }

            //    memory.Position = 0;

            //}
            //catch (Exception ex)
            //{
            //    var path = HttpContext.Current.Server.MapPath("~/error"); ;

            //    string text = ex.Message.ToString();
            //    byte[] data = Encoding.ASCII.GetBytes(text);
            //    string newFileName = Guid.NewGuid() + ".txt";
            //    File.WriteAllBytes(Path.Combine(path, newFileName), data);
            //}
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
                _json.data = files;
            }

            return _json;
        }


        public jsonArray getSkills()
        {
            int status = 1;
            listarray _db = new listarray();

            _db.lstSkill = new List<dropDownTemplate>();

            string strquery = @"SELECT [SkillName],[SkillID] FROM [Skill_Master]";

            SqlDataReader _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                _db.lstSkill.Add(new dropDownTemplate
                {
                    ID = _read["SkillID"].ToString(),
                    Name = _read["SkillName"].ToString()
                });
            }

            _read.Close();

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
                _json.data = _db;
            }

            return _json;
        }

        public jsonArray sendForgotPasswordMail(string emailid,string TWE_ID)
        {
            int status = 1;
            
            string strquery = @"select accountusername,accountpassword,firstname+' '+lastname from userprofilecreation where emailid='" + emailid + "' and TWE_ID='" + TWE_ID + "' ";
            string username = "";
            string password = "";
            string empName = "";
            string successMsg = "";
            SqlDataReader _read = _sql.doRead(strquery);

            //_read = _sql.doRead(query);
            while (_read.Read())
            {
                username = _read[0].ToString();
                password = _read[1].ToString();
                empName = _read[2].ToString();
            }

            _read.Close();

            if (username != "")
            {                               
                MailMessage mail = new MailMessage();

                string Description = "Dear " + empName + ",<br /> <br /> Your User Name is : " + username + "<br />Password is : " + Decrypt(password);

                //SmtpClient SmtpServer = new SmtpClient("smtp.zoho.com");
                SmtpClient SmtpServer = new SmtpClient("relay-hosting.secureserver.net", 25);
                mail.From = new MailAddress("sender@techwaukee.com");
                mail.To.Add(emailid);

                mail.Subject = "hunT CreW- Credentials";
                mail.IsBodyHtml = true;
                mail.Body = Description;

                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("sender@techwaukee.com", "Techwaukee@2016");

                try
                {
                    SmtpServer.Send(mail);
                    successMsg = "Valid User";
                }
                catch (Exception ex1)
                {
                    status = 0;
                    var path = HttpContext.Current.Server.MapPath("~/error"); ;

                    string text = ex1.InnerException.ToString();
                    byte[] data = Encoding.ASCII.GetBytes(text);
                    string newFileName = Guid.NewGuid() + ".txt";
                    File.WriteAllBytes(Path.Combine(path, newFileName), data);
                    successMsg = "Mail Failed";
                }

            }
            else
            {
                successMsg = "Invalid Credentials";
            }

            jsonArray _json = new jsonArray();
            if (status == 0)
            {
                _json.status = "0";
                _json.message = "MAIL SENT FAILED";
                _json.data = successMsg;
            }
            else
            {
                _json.status = "1";
                _json.message = "MAIL SENT SUCCESSFULLY";
                _json.data = successMsg;
            }

            return _json;
        }

        public jsonArray getviewVendorDetails(string vendorid)
        {
            int status = 1;
            vendor objVendor = new vendor();
            string strquery = @"SELECT employercorporationaname,website,linkedin,employerspecialization,
                            employeradditionalinfo,address,city,country,Created_On,up.UP_firstName+' '+up.UP_lastName Created_By,Status
                            ,Updated_On,up1.UP_firstName+' '+up1.UP_lastName Updated_By,vendortype,
                            Convert(varchar,Created_On,106) createdOn,
                            Convert(varchar,Updated_On,106) updatedOn
                            FROM EmployerDetails emp
                            join Userprofile up on emp.Created_By=up.TWE_ID
                            left join Userprofile up1 on emp.Updated_By=up1.TWE_ID
                            where employerid=" + vendorid;

            SqlDataReader _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                objVendor.employercorporationaname = _read[0].ToString();
                objVendor.website = _read[1].ToString();
                objVendor.linkedin = _read[2].ToString();
                objVendor.employerspecialization = _read[3].ToString();
                objVendor.employeradditionalinfo = _read[4].ToString();
                objVendor.address = _read[5].ToString();
                objVendor.city = _read[6].ToString();
                objVendor.country = _read[7].ToString();
                objVendor.Created_On = _read[8].ToString();
                objVendor.Created_By = _read[9].ToString();
                objVendor.Status = _read[10].ToString();
                objVendor.Updated_On = _read[11].ToString();
                objVendor.Updated_By = _read[12].ToString();
                objVendor.vendortype = _read[13].ToString();
                objVendor.CreatedOn = _read[14].ToString();
                objVendor.UpdatedOn = _read[15].ToString();
                
            }

            _read.Close();

            objVendor.lstVencontact = new List<vendorcontact>();

            strquery = @"SELECT [VendorContactID],[ContactPerson],[ContactNo],[MailId],[Designation],[VenConStatus] FROM [EmployerContactPerson] where VendorID='" + vendorid + "'";

            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                vendorcontact objCon = new vendorcontact();
                objCon.vencontactid = _read[0].ToString();
                objCon.contactname = _read[1].ToString();
                objCon.employermobileno = _read[2].ToString();
                objCon.employeremailid = _read[3].ToString();
                objCon.employerremarks = _read[4].ToString();
                objCon.venConstatus = _read[5].ToString();

                objVendor.lstVencontact.Add(objCon);
            }

            _read.Close();

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
                _json.data = objVendor;
            }

            return _json;

        }

        public jsonArray getclientdetails()
        {
            int status = 1;

            vendorlist _db = new vendorlist();

            _db.lstVen = new List<vendorlist>();

            string strquery = @"select emp.ClientID,ClientCompanyName,count(ClientContactID) recruitercount,
                                sta.statusname Status,Regionname
                                from ClientMaster emp
                                join Client_Contact_Person econ on emp.ClientID=econ.ClientID
                                join Status_Master sta on sta.statusid=emp.Status
                                join Region_Master rm on rm.Regionid=emp.Placeofsupply
                                group by emp.ClientID,ClientCompanyName,statusname,Regionname
                                having statusname='Active'";


            SqlDataReader _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                vendorlist objven = new vendorlist();
                objven.vendorid = _read[0].ToString();
                objven.vendorname = _read[1].ToString();
                objven.noofrecruiter = _read[2].ToString();
                objven.status = _read[3].ToString();
                objven.submittedby = _read[4].ToString();

                _db.lstVen.Add(objven);

            }

            _read.Close();

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
                _json.data = _db;
            }

            return _json;
        }

        public jsonArray getviewClientDetails(string clientid)
        {
            int status = 1;
            vendor objVendor = new vendor();
            string strquery = @"SELECT ClientCompanyName,Company_Website,Company_Linkedin,Client_Specialization,
                            additionalinfo,address,city,country,Created_On,up.UP_firstName+' '+up.UP_lastName Created_By,Status
                            ,Updatedon,up1.UP_firstName+' '+up1.UP_lastName Updated_By,clienttype,
                            Convert(varchar,Created_On,106) createdOn,
                            Convert(varchar,Updatedon,106) updatedOn,Placeofsupply
                            FROM ClientMaster emp
                            join Userprofile up on emp.Created_By=up.TWE_ID
                            left join Userprofile up1 on emp.Updatedby=up1.TWE_ID
                            where ClientID=" + clientid;

            SqlDataReader _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                objVendor.employercorporationaname = _read[0].ToString();
                objVendor.website = _read[1].ToString();
                objVendor.linkedin = _read[2].ToString();
                objVendor.employerspecialization = _read[3].ToString();
                objVendor.employeradditionalinfo = _read[4].ToString();
                objVendor.address = _read[5].ToString();
                objVendor.city = _read[6].ToString();
                objVendor.country = _read[7].ToString();
                objVendor.Created_On = _read[8].ToString();
                objVendor.Created_By = _read[9].ToString();
                objVendor.Status = _read[10].ToString();
                objVendor.Updated_On = _read[11].ToString();
                objVendor.Updated_By = _read[12].ToString();
                objVendor.vendortype = _read[13].ToString();
                objVendor.CreatedOn = _read[14].ToString();
                objVendor.UpdatedOn = _read[15].ToString();
                objVendor.placeofsupply = _read[16].ToString();
                
            }

            _read.Close();

            objVendor.lstVencontact = new List<vendorcontact>();

            strquery = @"SELECT [ClientContactID],[ContactPerson],[ContactNo],[MailId],[Designation],[ClientConStatus] FROM [Client_Contact_Person] where ClientID='" + clientid + "'";

            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                vendorcontact objCon = new vendorcontact();
                objCon.vencontactid = _read[0].ToString();
                objCon.contactname = _read[1].ToString();
                objCon.employermobileno = _read[2].ToString();
                objCon.employeremailid = _read[3].ToString();
                objCon.employerremarks = _read[4].ToString();
                objCon.venConstatus = _read[5].ToString();

                objVendor.lstVencontact.Add(objCon);
            }

            _read.Close();

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
                _json.data = objVendor;
            }

            return _json;

        }


        public jsonArray insertTargetfixing(targetfixingMstr Tf)
        {
            int status = 1;
            string query = "";
            if (Tf.TargetfixingId == "")
            {
                query = @"INSERT INTO [TargetMaster]
            ([RoleType]
            ,[LevelType]
            ,[RegionType]            
            ,[Submission_Daily]
            ,[SubmissiontoTL_Daily]
            ,[SubmissiontoBP_Daily]
            ,[Closure_Daily]
            ,[Vendor_Daily]
            ,[Submission_Monthly]
            ,[SubmissiontoTL_Monthly]
            ,[SubmissiontoBP_Monthly]
            ,[Closure_Monthly]
            ,[Vendor_Monthly]
            ,[Submission_Weekly]
            ,[SubmissiontoTL_Weekly]
            ,[SubmissiontoBP_Weekly]
            ,[Closure_Weekly]
            ,[Vendor_Weekly]
            )
        VALUES
           ('" + Tf.RoleType + "','" + Tf.LevelType + "','" + Tf.RegionType + "','" + 
                Tf.Submission_Daily + "','" + Tf.SubmissiontoTL_Daily + "','" + Tf.SubmissiontoBP_Daily + 
                "','" + Tf.Closure_Daily + "','" + Tf.Vendor_Daily + "','" + Tf.Submission_Monthly +
                "','" + Tf.SubmissiontoTL_Monthly + "','" + Tf.SubmissiontoBP_Monthly + "','" + Tf.Closure_Monthly +
                "','" + Tf.Vendor_Monthly + "','" + Tf.Submission_Weekly + "','" + Tf.SubmissiontoTL_Weekly +
                "','" + Tf.SubmissiontoBP_Weekly + "','" + Tf.Closure_Weekly + "','" + Tf.Vendor_Weekly + "')";
            }
            else if (Tf.TargetfixingId != "")
            {
                query = @"UPDATE [TargetMaster]
                  SET [RoleType] = '" + Tf.RoleType +
                      "',[LevelType] = '" + Tf.LevelType +
                      "',[RegionType] = '" + Tf.RegionType +
                      "',[Submission_Daily] = '" + Tf.Submission_Daily +
                      "',[SubmissiontoTL_Daily] = '" + Tf.SubmissiontoTL_Daily +
                      "',[SubmissiontoBP_Daily] = '" + Tf.SubmissiontoBP_Daily +
                      "',[Closure_Daily] = '" + Tf.Closure_Daily +
                      "',[Vendor_Daily] = '" + Tf.Vendor_Daily +
                      "',[Submission_Monthly] = '" + Tf.Submission_Monthly +
                      "',[SubmissiontoTL_Monthly] = '" + Tf.SubmissiontoTL_Monthly +
                      "',[SubmissiontoBP_Monthly] = '" + Tf.SubmissiontoBP_Monthly +
                      "',[Closure_Monthly] = '" + Tf.Closure_Monthly +
                      "',[Vendor_Monthly] = '" + Tf.Vendor_Monthly +
                      "',[Submission_Weekly] = '" + Tf.Submission_Weekly +
                      "',[SubmissiontoTL_Weekly] = '" + Tf.SubmissiontoTL_Weekly +
                      "',[SubmissiontoBP_Weekly] = '" + Tf.SubmissiontoBP_Weekly +
                      "',[Closure_Weekly] = '" + Tf.Closure_Weekly +
                      "',[Vendor_Weekly] = '" + Tf.Vendor_Weekly +
                      "' WHERE TargetID='" + Tf.TargetfixingId + "' ";

            }


            _sql.doInsert(query);


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
                _json.data = "";
            }

            return _json;

        }

        public jsonArray insertMenumaster(menuaccesspermision map)
        {
            int status = 1;
            string query = "";
            if (map.menuaccessid == "")
            {
                query = @"INSERT INTO [MenuAccessPermission]
           ([roleId]
           ,[regionid]
           ,[jobAccess]
           ,[jobCreation]
           ,[jobEdit]
           ,[jobView]
           ,[jobFeedback]
           ,[candidateAccess]
           ,[candidateCreation]
           ,[candidateView]
           ,[candidateEdit]
           ,[vendorAccess]
           ,[vendorCreation]
           ,[vendorEdit]
           ,[vendorView]
           --,[reportAccess]
           ,[Status])
     VALUES
           ('" + map.roleid +
           "','" + map.regionid +
           "','" + map.jobAccess +
           "','" + map.jobCreation +
           "','" + map.jobEdit +
           "','" + map.jobView +
           "','" + map.jobFeedback +
           "','" + map.candidateAccess +
           "','" + map.candidateCreation +
           "','" + map.candidateView +
           "','" + map.candidateEdit +
           "','" + map.vendorAccess +
           "','" + map.vendorCreation +
           "','" + map.vendorEdit +
           "','" + map.vendorView +
           //"','" + map.reportAccess +
           "','" + map.Status + "')";
            }
            else if (map.menuaccessid != "")
            {
                query = @"UPDATE [MenuAccessPermission]
                           SET [roleId] = '" + map.roleid+
                              "',[regionid] = '" + map.regionid +
                              "',[jobaccess] = '" + map.jobAccess +
                              "',[jobCreation] = '" + map.jobCreation +
                              "',[jobEdit] = '" + map.jobView +
                              "',[jobView] = '" + map.jobEdit +
                              "',[jobFeedback] = '" + map.jobFeedback +
                              "',[candidateAccess] = '" + map.candidateAccess +
                              "',[candidateCreation] = '" + map.candidateCreation +
                              "',[candidateView] = '" + map.candidateView +
                              "',[candidateEdit] = '" + map.candidateEdit +
                              "',[vendorAccess] = '" + map.vendorAccess +
                              "',[vendorCreation] = '" + map.vendorCreation +
                              "',[vendorEdit] = '" + map.vendorEdit +
                              "',[vendorView] = '" + map.vendorView +
                              //"',[reportAccess] = '" + map.reportAccess +
                              "',[Status] = '" + map.Status +
                              "' WHERE menuaccessId ='" + map.menuaccessid + "'";

            }
            _sql.doInsert(query);


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
                _json.data = "";
            }

            return _json;

        }

        public jsonArray insertImagemaster(Imagemaster im)
        {
            int status = 1;
            string query = "";
            if (im.imageid == "")
            {
                query = @"INSERT INTO [Image_Master]
           ([TechnologyName]
           ,[ImageURL]
           ,[Status])
           VALUES
           ('" + im.technologyname +
           "','" + im.path +
           "','" + im.status + "')";
            }
            else if (im.imageid != "")
            {
                query = @"UPDATE [Image_Master]
                           SET [TechnologyName] = '" + im.technologyname +
                              "',[ImageURL] = '" + im.path +
                              "',[Status] = '" + im.status +
                              "' WHERE Imageid='" + im.imageid + "'";

            }
            _sql.doInsert(query);


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
                _json.data = "";
            }

            return _json;

        }

        public jsonArray gettargetfixing(string Targetfixingid)
        {
            int status = 1;

            
            List<targetfixingMstr> _lsttfm = new List<targetfixingMstr>();
            string strquery = "";
            if (Targetfixingid == "")
            {
                strquery = @"SELECT [TargetID]
                            ,rom.Rolename
                            ,lm.Levelname
                            ,rm.regionname
                            FROM [TargetMaster] tm
                            join region_master rm on tm.RegionType=rm.regionid
                            join RoleMaster rom on rom.Roleid=tm.roletype
                            join Level_Master lm on lm.Levelid=tm.LevelType";
            }
            else if (Targetfixingid != "")
            {
                strquery = @"SELECT TargetID
                                    ,RoleType
                                    ,LevelType
                                    ,RegionType
                                    ,SubmissiontoTL_Daily
                                    ,Submission_Daily
                                    ,SubmissiontoBP_Daily
                                    ,Closure_Daily
                                    ,Vendor_Daily
                                    ,Submission_Monthly
                                    ,SubmissiontoTL_Monthly
                                    ,SubmissiontoBP_Monthly
                                    ,Closure_Monthly
                                    ,Vendor_Monthly
                                    ,Submission_Weekly
                                    ,SubmissiontoTL_Weekly
                                    ,SubmissiontoBP_Weekly
                                    ,Closure_Weekly
                                    ,Vendor_Weekly
                                    FROM [TargetMaster] where TargetID='" + Targetfixingid + "'";
            }

            SqlDataReader _read = _sql.doRead(strquery);

            if (Targetfixingid == "")
            {
                while (_read.Read())
                {
                    targetfixingMstr _tfm = new targetfixingMstr();
                    _tfm.TargetfixingId = _read[0].ToString();
                    _tfm.RoleType = _read[1].ToString();
                    _tfm.LevelType = _read[2].ToString();
                    _tfm.RegionType = _read[3].ToString();
                    _lsttfm.Add(_tfm);
                }
            }

            else if (Targetfixingid != "")
            {
                while (_read.Read())
                {
                    targetfixingMstr _tfm = new targetfixingMstr();
                    _tfm.TargetfixingId = _read[0].ToString();
                    _tfm.RoleType = _read[1].ToString();
                    _tfm.LevelType = _read[2].ToString();
                    _tfm.RegionType = _read[3].ToString();
                    _tfm.SubmissiontoTL_Daily = _read[4].ToString();
                    _tfm.Submission_Daily = _read[5].ToString();
                    _tfm.SubmissiontoBP_Daily = _read[6].ToString();
                    _tfm.Closure_Daily = _read[7].ToString();
                    _tfm.Vendor_Daily = _read[8].ToString();
                    _tfm.Submission_Monthly = _read[9].ToString();
                    _tfm.SubmissiontoTL_Monthly = _read[10].ToString();
                    _tfm.SubmissiontoBP_Monthly = _read[11].ToString();
                    _tfm.Closure_Monthly = _read[12].ToString();
                    _tfm.Vendor_Monthly = _read[13].ToString();
                    _tfm.Submission_Weekly = _read[14].ToString();
                    _tfm.SubmissiontoTL_Weekly = _read[15].ToString();
                    _tfm.SubmissiontoBP_Weekly = _read[16].ToString();
                    _tfm.Closure_Weekly = _read[17].ToString();
                    _tfm.Vendor_Weekly = _read[18].ToString();

                    _lsttfm.Add(_tfm);
                }
            }

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
                _json.data = _lsttfm;
            }

            return _json;
        }

        public jsonArray getmenuaccess(string menuaccessId)
        {
            int status = 1;

           
            List<menuaccesspermision> _lstmap = new List<menuaccesspermision>();
            string strquery = "";
            if (menuaccessId == "")
            {
                strquery = @"SELECT [menuaccessid]
                            ,rom.Rolename
                            ,rm.regionname
                            FROM Menuaccesspermission mnu
                            join region_master rm on mnu.regionid=rm.regionid
                            join RoleMaster rom on rom.Roleid=mnu.roleid";
            }
            else if (menuaccessId != "")
            {
                strquery = @"SELECT [menuaccessId]
                          ,[roleId]
                          ,[jobaccess]
                          ,[jobCreation]
                          ,[jobEdit]
                          ,[jobView]
                          ,[jobFeedback]
                          ,[candidateAccess]
                          ,[candidateCreation]
                          ,[candidateView]
                          ,[candidateEdit]
                          ,[vendorAccess]
                          ,[vendorCreation]
                          ,[vendorEdit]
                          ,[vendorView]
                          --,[reportAccess]
                          ,[Status]
                          ,regionid
                      FROM [MenuAccessPermission] where menuaccessId='" + menuaccessId + "'";
            }

            SqlDataReader _read = _sql.doRead(strquery);

            if (menuaccessId == "")
            {
                while (_read.Read())
                {
                     menuaccesspermision _map = new menuaccesspermision();
                    _map.menuaccessid = _read[0].ToString();
                    _map.roleid = _read[1].ToString();
                    _map.regionid = _read[2].ToString();
                    _lstmap.Add(_map);
                }
            }
            else if (menuaccessId != "")
            {
                while (_read.Read())
                {
                     menuaccesspermision _map = new menuaccesspermision();
                    _map.menuaccessid = _read[0].ToString();
                    _map.roleid = _read[1].ToString();
                    _map.jobAccess = _read[2].ToString();
                    _map.jobCreation = _read[3].ToString();
                    _map.jobEdit = _read[4].ToString();
                    _map.jobView = _read[5].ToString();
                    _map.jobFeedback = _read[6].ToString();
                    _map.candidateAccess = _read[7].ToString();
                    _map.candidateCreation = _read[8].ToString();
                    _map.candidateView = _read[9].ToString();
                    _map.candidateEdit = _read[10].ToString();
                    _map.vendorAccess = _read[11].ToString();
                    _map.vendorCreation = _read[12].ToString();
                    _map.vendorEdit = _read[13].ToString();
                    _map.vendorView = _read[14].ToString();
                    //_map.reportAccess = _read[15].ToString();
                    _map.Status = _read[15].ToString();
                    _map.regionid = _read[16].ToString();
                    _lstmap.Add(_map);
                }
            }

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
                _json.data = _lstmap;
            }

            return _json;
        }

        public jsonArray getImagemaster()
        {
            int status = 1;

            
            List<Imagemaster> _lstim = new List<Imagemaster>();
            string strquery = "";
            //if (imageid == "")
            //{
                strquery = @"SELECT [ImageID]
                          ,[TechnologyName]
                          ,[ImageURL]
                          ,[Status]
                      FROM [Image_Master]";
            //}
            //else if (imageid != "")
            //{
            //    strquery = @"SELECT [Imageid]
            //              ,[TechnologyName]
            //              ,[Path]
            //              ,[Status]
            //          FROM [RecruitingApp_DB].[dbo].[ImageMasterTable] where Imageid='" + imageid + "'";
            //}

            SqlDataReader _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                Imagemaster _im = new Imagemaster();
                _im.imageid = _read[0].ToString();
                _im.technologyname = _read[1].ToString();
                _im.path = _read[2].ToString();
                _im.status = _read[3].ToString();

                _lstim.Add(_im);
            }

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
                _json.data = _lstim;
            }

            return _json;
        }

        public jsonArray getTargetFormdetails()
        {
            int status = 1;

            listarray _db = new listarray();
            _db.lstClient = new List<dropDownTemplate>();
            _db.lstPriority = new List<dropDownTemplate>();
            _db.lstCurrency = new List<dropDownTemplate>();
            
            string strquery = @"SELECT[Regionid],[Regionname] FROM [Region_Master] where Status=1";

            SqlDataReader _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                _db.lstClient.Add(new dropDownTemplate
                {
                    ID = _read["Regionid"].ToString(),
                    Name = _read["Regionname"].ToString()
                });
            }

            _read.Close();

            strquery = @"SELECT [Roleid],[Rolename] FROM [RoleMaster] where Status=1";

            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                _db.lstPriority.Add(new dropDownTemplate
                {
                    ID = _read["Roleid"].ToString(),
                    Name = _read["Rolename"].ToString()
                });
            }


            _read.Close();

            strquery = @"SELECT [Levelid],[Levelname] FROM [Level_Master] where Status=1";

            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                _db.lstCurrency.Add(new dropDownTemplate
                {
                    ID = _read["Levelid"].ToString(),
                    Name = _read["Levelname"].ToString()
                });
            }

            _read.Close();


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
                _json.data = _db;
            }

            return _json;
        }

        public jsonArray insertTeamfeedbackIndia(TeamPerfomanceFeedback tpf,string tblName)
        {
            int status = 1;
            string query = "";
            var tableName = "";
            var colName = "";

            if (tblName=="Weekly")
            {
                tableName = "TeamPerfomanceIndia_Weekly";
                colName = "Weekinfo";
            }
            else 
            {
                tableName = "TeamPerfomanceIndia_Monthly";
                colName = "Monthinfo";
            }

            if (tpf.Teamperfomanceid == "")
            {
                query = "INSERT INTO "+ tableName + 
                @"([OverAllRating]
                ,[Remarks]
                ,[TWEID]
                ,"+colName+
                ",[Feedback_givenby]"+
                ",[Feedback_givenon])"+
                "VALUES"+
                "('" + tpf.OverallRating +
                "','" + tpf.Remarks +
                "','" + tpf.TWEID +
                "','" + tpf.Weekinfo +
                "','" + tpf.Feedback_givenby +
                "','" + tpf.Feedback_givenon +
                "')";    
            }
            else if (tpf.Teamperfomanceid != "")
            {
                query = @"UPDATE "+tableName+
                " SET [OverAllRating] = '" + tpf.OverallRating +
                "',[Remarks] = '" + tpf.Remarks +
                "' WHERE Teamperfomanceid='" + tpf.Teamperfomanceid + "'";

            }
            _sql.doInsert(query);
            
            


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
                _json.data = "";
            }

            return _json;

        }

        public jsonArray insertTeamfeedback(TeamPerfomanceFeedback tpf, string tblName)
        {
            int status = 1;
            string query = "";
            var tableName = "";
            var colName = "";

            if (tblName == "Weekly")
            {
                tableName = "TeamPerfomance_Weekly";
                colName = "Weekinfo";
            }
            else
            {
                tableName = "TeamPerfomance_Monthly";
                colName = "Monthinfo";
            }

            if (tpf.Teamperfomanceid == "")
            {
                query = "INSERT INTO " + tableName +
                @"([OverAllRating]
                ,[Remarks]
                ,[TWEID]
                ," + colName +
                ",[Feedback_givenby]" +
                ",[Feedback_givenon])" +
                "VALUES" +
                "('" + tpf.OverallRating +
                "','" + tpf.Remarks +
                "','" + tpf.TWEID +
                "','" + tpf.Weekinfo +
                "','" + tpf.Feedback_givenby +
                "','" + tpf.Feedback_givenon +
                "')";
            }
            else if (tpf.Teamperfomanceid != "")
            {
                query = @"UPDATE " + tableName +
                " SET [OverAllRating] = '" + tpf.OverallRating +
                "',[Remarks] = '" + tpf.Remarks +
                "' WHERE Teamperfomanceid='" + tpf.Teamperfomanceid + "'";

            }
            _sql.doInsert(query);




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
                _json.data = "";
            }

            return _json;

        }



        public jsonArray getTeamList(string userid)
        {
            int status = 1;

            
            List<teamlist> _lsttl = new List<teamlist>();
            string strquery = "";
            if (userid != "")
            {
                if (userid == "TWEU0001")
                {
                    strquery = @"select  firstname+' '+lastname Name,Rolename,TWE_ID,Roleid,profileimage from Userprofilecreation up
                             join RoleMaster rol on  rol.Roleid=up.role where (reportingTL='TWEU0001' or reportingmanager='TWEU0001') 
							 and TWE_ID not like '%TWEU0001%' and up.status=1 union							 
                            select  firstname+' '+lastname Name,Rolename,TWE_ID,Roleid,profileimage from Userprofilecreation up
                            join RoleMaster rol on  rol.Roleid=up.role where (reportingTL='TWEU0026' or reportingmanager='TWEU0026') and 
                            TWE_ID not like '%TWEU0026%' and up.status=1 union select firstname+' '+lastname Name,Rolename,TWE_ID,Roleid,
                            profileimage from Userprofilecreation up join RoleMaster rol on  rol.Roleid = up.role where TWE_ID in
                            ( (select reportingmanager from Userprofilecreation where TWE_ID like '%TWEU0026%' and status = 1))";

                }

                else if (userid.StartsWith("TWEU"))
                {
                    strquery = @"select  firstname+' '+lastname Name,Rolename,TWE_ID,Roleid,profileimage from Userprofilecreation up
                                join RoleMaster rol on  rol.Roleid=up.role where (reportingTL='TWEU0001' or reportingmanager='TWEU0001') and up.status=1 union select  firstname+' '+lastname Name,Rolename,TWE_ID,Roleid,profileimage from Userprofilecreation up
                                join RoleMaster rol on  rol.Roleid=up.role where (reportingTL='" + userid + "' or reportingmanager='" + userid + "') and TWE_ID not like '%" + userid + "%' and up.status=1" +
                                 " union " +
                                 "select firstname+' '+lastname Name,Rolename,TWE_ID,Roleid,profileimage from Userprofilecreation up" +
                                 " join RoleMaster rol on  rol.Roleid = up.role where TWE_ID in(" +
                                 " (select reportingmanager from Userprofilecreation where TWE_ID like '%" + userid + "%' and status = 1))";
                }
                else
                {
                    strquery = @"select  firstname+' '+lastname Name,Rolename,TWE_ID,Roleid,profileimage from Userprofilecreation up
                             join RoleMaster rol on  rol.Roleid=up.role where (reportingTL='" + userid + "' or reportingmanager='" + userid + "') and TWE_ID not like '%" + userid + "%' and up.status=1" +

                                 " union " +
                                 "select firstname+' '+lastname Name,Rolename,TWE_ID,Roleid,profileimage from Userprofilecreation up" +
                                 " join RoleMaster rol on  rol.Roleid = up.role where TWE_ID in(" +
                                 " (select reportingmanager from Userprofilecreation where TWE_ID like '%" + userid + "%' and status = 1))";
                }
            }
            else
            {
                status = 0;
            }


            SqlDataReader _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                 teamlist _tl = new teamlist();
                _tl.Username = _read[0].ToString();
                _tl.Role = _read[1].ToString();
                _tl.Userid = _read[2].ToString();
                _tl.Roleid = _read[3].ToString();
                _tl.Profileimg = _read[4].ToString();

                _lsttl.Add(_tl);
            }

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
                _json.data = _lsttl;
            }

            return _json;
        }

        public jsonArray getTeammemberdashboarddetailsIndia(string TWE_id, string fromdate, string todate, string strType)
        {
            Recrutingdashboard _rd = new Recrutingdashboard();
            List<tiles> _lsttls = new List<tiles>();
            List<statuscount> _lststc = new List<statuscount>();
            List<performanceoverview> _lstpov = new List<performanceoverview>();
            List<recruitmenttable> _lstrt = new List<recruitmenttable>();
            List<barchartlist> _lstbar = new List<barchartlist>();
            List<linechartlist> _lstline = new List<linechartlist>();

            _rd.lstJob = new List<JobcodeList>();

            int status = 1;
            string strquery = "";
            string strtype = strType;
            _rd.TWE_id = TWE_id;

            strquery = @"select firstname+' '+lastname Empname from Userprofilecreation where TWE_ID='" + TWE_id + "'";

            SqlDataReader _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                _rd.UserName = _read[0].ToString();
            }

            _read.Close();


                strquery = @"select * from
                            (select 'Total jobs Worked' Title,count(distinct job.Jobcode) Total_Jbs_Worked from Job_Master_IND job
                            join CandidateJobIndia canjob on canjob.Jobcode=job.Jobcode
                            join CandidateDetailsIndia cand on cand.candidateid=canjob.CandidateId" +
                            " where canjob.Created_by like '%" + TWE_id + "%' and canjob.Created_On between '" + fromdate + "' and '" + todate + "'" +
                            ") tb1," +

                            "(select 'Interview Candidates' Title,count(distinct cand.candidateid) Interview_Count from Job_Master_IND job " +
                            "join CandidateJobIndia canjob on canjob.Jobcode=job.Jobcode " +
                            "join CandidateDetailsIndia cand on cand.candidateid=canjob.CandidateId" +
                            " where cand.Created_By like '%" + TWE_id + "%' and Cand_Status in ('110','111') and canjob.Created_On between '" + fromdate + "' and '" + todate + "'" +
                            ") tb2," +
                            "(" +
                            "select 'Candidates Added' Title,count(distinct cand.candidateid) Candidate_Count from CandidateJobIndia canjob  " +
                            "join CandidateDetailsIndia cand on cand.candidateid=canjob.CandidateId" +
                            " where cand.Created_By like '%" + TWE_id + "%' and cand.Created_On between '" + fromdate + "' and '" + todate + "'" +
                            ") tb3," +
                            "(select 'Closure Candidates' Title,count(distinct cand.candidateid) Closure_Count from Job_Master_IND job " +
                            " join CandidateJobIndia canjob on canjob.Jobcode=job.Jobcode " +
                            " join CandidateDetailsIndia cand on cand.candidateid=canjob.CandidateId" +
                            " where canjob.Created_By like '%" + TWE_id + "%' and Cand_Status in ('109') and canjob.Created_On between '" + fromdate + "' and '" + todate + "'" +
                            " ) tb4";


            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                tiles _tls1 = new tiles();
                _tls1.TileTitle = _read[0].ToString();
                _tls1.TotalCount = _read[1].ToString();

                _lsttls.Add(_tls1);

                tiles _tls2 = new tiles();
                _tls2.TileTitle = _read[2].ToString();
                _tls2.TotalCount = _read[3].ToString();

                _lsttls.Add(_tls2);

                tiles _tls3 = new tiles();
                _tls3.TileTitle = _read[4].ToString();
                _tls3.TotalCount = _read[5].ToString();

                _lsttls.Add(_tls3);

                tiles _tls4 = new tiles();
                _tls4.TileTitle = _read[6].ToString();
                _tls4.TotalCount = _read[7].ToString();

                _lsttls.Add(_tls4);


            }
            _read.Close();
            _rd.Tiles = _lsttls;



            //Bar Chart Query
            if (strtype == "Monthly")
            {
                strquery = @"select count(*) CandCount,Substring(Datename(mm,(can.Created_On)),0,4) MonName from CandidateDetailsIndia can
                                        join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId
                                        join Job_Master_IND job on job.Jobcode=canjob.Jobcode
                                        where Cand_Status >=103
                                        and can.Created_By='" + TWE_id + "' and can.Created_On between '" + fromdate + "' and '" + todate +
                                        "' group by Datename(mm,(can.Created_On))";
            }
            else if (strtype == "Daily")
            {
                strquery = @"select count(*) CandCount,datepart(dw,can.Created_On) dyName from CandidateDetailsIndia can
                                        join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId
                                        join Job_Master_IND job on job.Jobcode=canjob.Jobcode
                                        where Cand_Status >=103
                                        and can.Created_By='" + TWE_id + "' and can.Created_On between '" + fromdate + "' and '" + todate +
                                        "' group by  datepart(dw,can.Created_On)";
            }
            else if (strtype == "Weekly")
            {
                strquery = @"select count(*) CandCount, 'Week '+ Convert(varchar,DATEPART(week,can.Created_On)) WkName from CandidateDetailsIndia can
                                        join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId
                                        join Job_Master_IND job on job.Jobcode=canjob.Jobcode
                                        where Cand_Status >=103
                                        and can.Created_By='" + TWE_id + "' and can.Created_On between '" + fromdate + "' and '" + todate
                                        + "' group by DATEPART(week,can.Created_On)";
            }
            _read = _sql.doRead(strquery);
            while (_read.Read())
            {
                barchartlist _bcl = new barchartlist();
                _bcl.candCount = _read[0].ToString();
                _bcl.itemName = _read[1].ToString();
                _lstbar.Add(_bcl);

            }
            _read.Close();
            string data1 = "";
            if (_lstbar.Count != 0)
            {
                for (int i = 0; i < _lstbar.Count; i++)
                {
                    data1 += _lstbar[i].candCount + ",";
                }
                data1 = data1.Substring(0, data1.Length - 1);
            }

            string data2 = "";
            if (_lstbar.Count != 0)
            {
                for (int i = 0; i < _lstbar.Count; i++)
                {
                    data2 += "'" + _lstbar[i].itemName + "',";
                }
                data2 = data2.Substring(0, data2.Length - 1);
            }

            _rd.Barchart = "<canvas id='chart-bars' class='chart-canvas' height='170px'></canvas>  <script> " +
                        "var ctx = document.getElementById('chart-bars').getContext('2d'); " +
                        "new Chart(ctx, {" +
                        "type: 'bar'," +
                        "data: {" +
                        "labels: [" + data2 + "]," +
                        "datasets: [{" +
                        "label: 'Submissions'," +
                        "tension: 0.4," +
                        "borderWidth: 0," +
                        "pointRadius: 0," +
                        "backgroundColor: '#fff'," +
                        "data: [" + data1 + "]," +
                        "maxBarThickness: 6" +
                        "},]," +
                        "}," +
                        "options:" +
                        "{" +
                        "responsive: true," +
                        "maintainAspectRatio: false," +
                        "legend:" +
                        "{" +
                        "display: false," +
                        "}," +
                        "tooltips:" +
                        "{" +
                        "enabled: true," +
                        "mode: 'index'," +
                        "intersect: false," +
                        "}," +
                        "scales: " +
                        "{" +
                        "yAxes: [{" +
                        "gridLines:" +
                        "{" +
                        "display: false," +
                        "}," +
                        "ticks: " +
                        "{" +
                        "suggestedMin: 0," +
                        "suggestedMax: 5," +
                        "beginAtZero: true," +
                        "padding: 0," +
                        "fontSize: 14," +
                        "lineHeight: 3," +
                        "fontColor: '#fff'," +
                        "fontStyle: 'normal'," +
                        "fontFamily: 'Open Sans'," +
                        "}," +
                        "},]," +
                        "xAxes: [{" +
                        "gridLines: " +
                        "{" +
                        "display: false," +
                        "}," +
                        "ticks: " +
                        "{" +
                        "display: false," +
                        "padding: 20," +
                        "}," +
                        "},]," +
                        "}," +
                        "}," +
                        "}); </script>";
            _rd.BarTitle = "Active Candidates";
            _rd.BarDuration = "Duration for the Week of ";

            strquery = @"select '1't1,'SB'sp,count(*) EC_Selected from CandidateDetailsIndia can
                                        join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId
                                        left join Job_Master_IND job on job.Jobcode=canjob.Jobcode where Cand_Status in ('101','102') and can.Created_By like '%" + TWE_id + "%' and can.Created_On between '" + fromdate + "' and '" + todate + "'" +
                                       " union " +
                                       "select '2't2,'TL'tl,count(*) TL_Selected from CandidateDetailsIndia can" +
                                               " join CandidateJobIndia canjob on can.candidateid = canjob.CandidateId" +
                                               " join Job_Master_IND job on job.Jobcode = canjob.Jobcode where Cand_Status >=103 and can.Created_By like '%" + TWE_id + "%' and can.Created_On between '" + fromdate + "' and '" + todate + "'" +
                                       " union " +
                                       " select '3't3,'BP'bp,count(*) BP_Selected from CandidateDetailsIndia can" +
                                               " join CandidateJobIndia canjob on can.candidateid = canjob.CandidateId" +
                                               " join Job_Master_IND job on job.Jobcode = canjob.Jobcode where Cand_Status in ('105') and can.Created_By like '%" + TWE_id + "%' and can.Created_On between '" + fromdate + "' and '" + todate + "'" +
                                       " union " +
                                       " select '4't4,'EC'ec,count(*) EC_Selected from CandidateDetailsIndia can" +
                                               " join CandidateJobIndia canjob on can.candidateid = canjob.CandidateId" +
                                               " join Job_Master_IND job on job.Jobcode = canjob.Jobcode where Cand_Status in ('107') and can.Created_By like '%" + TWE_id + "%' and can.Created_On between '" + fromdate + "' and '" + todate + "'";

            _read = _sql.doRead(strquery);
            while (_read.Read())
            {
                statuscount _sc = new statuscount();
                _sc.StatusTitle = _read[1].ToString();
                _sc.StatusValue = _read[2].ToString();
                _lststc.Add(_sc);

            }
            _rd.StatusCount = _lststc;
            _read.Close();


            //if (strtype == "Monthly")
            //{
            //    strquery = @"select 'SB'colname, count(*) Submitted,month(can.Created_On) Monname  from CandidateDetailsIndia can" +
            //                           " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
            //                           " left join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
            //                           " where Cand_Status in ('101','102') and can.Created_By like '%" + TWE_id + "%' " +
            //                           " and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
            //                           " group by month(can.Created_On) " +
            //                           " union " +
            //                           " select 'TL'colname,count(*) TL_Selected,month(can.Created_On) Monname from CandidateDetailsIndia can" +
            //                           " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
            //                           " join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
            //                           " where Cand_Status in ('103') and can.Created_By like '%" + TWE_id + "%' " +
            //                           " and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
            //                           " group by month(can.Created_On) " +
            //                           " union " +
            //                           " select 'BP'colname,count(*) BP_Selected,month(can.Created_On) Monname  from CandidateDetailsIndia can" +
            //                           " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
            //                           " join Job_Master_IND job on job.Jobcode = canjob.Jobcode where " +
            //                           " Cand_Status in ('105') and can.Created_By like '%" + TWE_id + "%' " +
            //                           " and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
            //                           " group by month(can.Created_On) " +
            //                           " union " +
            //                           " select 'EC'colname,count(*) EC_Selected,month(can.Created_On) Monname from CandidateDetailsIndia can" +
            //                           " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
            //                           " join Job_Master_IND job on job.Jobcode = canjob.Jobcode where " +
            //                           " Cand_Status in ('107') and can.Created_By like '%" + TWE_id + "%' " +
            //                           " and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
            //                           " group by month(can.Created_On)";
            //}
            //else if (strtype == "Weekly")
            //{
            //    strquery = @"select 'SB'colname, count(*) Submitted,DATEPART(week,can.Created_On) Wkname  from CandidateDetailsIndia can" +
            //                " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
            //                " left join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
            //                " where Cand_Status in ('101','102') and can.Created_By like '%" + TWE_id + "%' " +
            //                " and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
            //                " group by DATEPART(week,can.Created_On) " +
            //                " union " +
            //                " select 'TL'colname,count(*) TL_Selected,DATEPART(week,can.Created_On) Wkname from CandidateDetailsIndia can" +
            //                " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
            //                " join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
            //                " where Cand_Status in ('103') and can.Created_By like '%" + TWE_id + "%' " +
            //                " and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
            //                " group by DATEPART(week,can.Created_On) " +
            //                " union " +
            //                " select 'BP'colname,count(*) BP_Selected,DATEPART(week,can.Created_On) Wkname  from CandidateDetailsIndia can" +
            //                " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
            //                " join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
            //                " where Cand_Status in ('105') and can.Created_By like '%" + TWE_id + "%' " +
            //                " and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
            //                " group by DATEPART(week,can.Created_On) " +
            //                " union " +
            //                " select 'EC'colname,count(*) EC_Selected,DATEPART(week,can.Created_On) Wkname from CandidateDetailsIndia can" +
            //                " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
            //                " join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
            //                " where Cand_Status in ('107') and can.Created_By like '%" + TWE_id + "%' " +
            //                " and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
            //                " group by DATEPART(week,can.Created_On)";
            //}
            //else if (strtype == "Daily")
            //{
            //    strquery = @"select 'SB'colname, count(*) Submitted,substring(datename(dw,can.Created_On),0,4) dyname  from CandidateDetailsIndia can" +
            //                       " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
            //                       " left join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
            //                       " where Cand_Status in ('101','102') and can.Created_By like '%" + TWE_id + "%' " +
            //                       " and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
            //                       " group by datename(dw,can.Created_On) " +
            //                       " union " +
            //                       " select 'TL'colname,count(*) TL_Selected,substring(datename(dw,can.Created_On),0,4) dyname from CandidateDetailsIndia can" +
            //                       " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
            //                       " join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
            //                       " where Cand_Status > 103 and can.Created_By like '%" + TWE_id + "%' " +
            //                       " and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
            //                       " group by datename(dw,can.Created_On) " +
            //                       " union " +
            //                       " select 'BP'colname,count(*) BP_Selected,substring(datename(dw,can.Created_On),0,4) dyname  from CandidateDetailsIndia can" +
            //                       " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
            //                       " join Job_Master_IND job on job.Jobcode = canjob.Jobcode where " +
            //                       " Cand_Status in ('105') and can.Created_By like '%" + TWE_id + "%' " +
            //                       " and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
            //                       " group by datename(dw,can.Created_On) " +
            //                       " union " +
            //                       " select 'EC'colname,count(*) EC_Selected,substring(datename(dw,can.Created_On),0,4) dyname from CandidateDetailsIndia can" +
            //                       " join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
            //                       " join Job_Master_IND job on job.Jobcode = canjob.Jobcode where " +
            //                       " Cand_Status in ('107') and can.Created_By like '%" + TWE_id + "%' " +
            //                       " and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
            //                       " group by datename(dw,can.Created_On) ";
            //}
            //_read = _sql.doRead(strquery);
            //while (_read.Read())
            //{
            //    linechartlist _lcl = new linechartlist();
            //    _lcl.colName = _read[0].ToString();
            //    _lcl.submitted = _read[1].ToString();
            //    _lcl.itemName = _read[2].ToString();
            //    _lstline.Add(_lcl);

            //}
            //_read.Close();

            _lstline = getSubmissionchartData(TWE_id, fromdate, todate, strtype);

            string strData = "";

            int timeVal = 0;
            if (strtype == "Monthly")
            {
                timeVal = 12;
                strData = "'Jan','Feb','Mar','Apr','May','Jun','Jul','Aug','Sep','Oct','Nov','Dec'";
            }
            else if (strtype == "Weekly")
            {
                timeVal = 53;
                strData = "'Wk1','Wk2','Wk3','Wk4','Wk5','Wk6','Wk7','Wk8','Wk9','Wk10','Wk11','Wk12','Wk13','Wk14','Wk15','Wk16','Wk17','Wk18','Wk19','Wk20','Wk21','Wk22','Wk23','Wk24','Wk25','Wk26','Wk27','Wk28','Wk29','Wk30','Wk31','Wk32','Wk33','Wk34','Wk35','Wk36','Wk37','Wk38','Wk39','Wk40','Wk41','Wk42','Wk43','Wk44','Wk45','Wk46','Wk47','Wk48','Wk49','Wk50','Wk51','Wk52','Wk53'";
            }
            else if (strtype == "Daily")
            {
                timeVal = 7;
                strData = "'Sun','Mon','Tue','Wed','Thu','Fri','Sat'";
            }
            string[] stageArr = { "SB", "TL", "BP", "EC" };



            List<linechartlist> lstchartSub = new List<linechartlist>();

            List<linechartlist> lstDt0 = _lstline.OrderBy(x => x.itemName).ThenBy(y => y.colName).ToList<linechartlist>();

            for (int i = 0; i < stageArr.Length; i++)
            {

                string countval = "";
                for (int j = 1; j <= timeVal; j++)
                {

                    List<linechartlist> lstResult = _lstline.Where(x => (x.itemName == j.ToString()) && (x.colName == stageArr[i])).ToList<linechartlist>();
                    if (lstResult.Count == 0)
                    {
                        countval = countval + "0" + ",";
                    }
                    else
                    {
                        countval = countval + lstResult[0].submitted.ToString() + ",";
                    }

                }

                lstchartSub.Add(new linechartlist() { colName = stageArr[i], submitted = countval.Substring(0, countval.Length - 1) });
                countval = "";

            }


            _rd.Linechart = "<canvas id='chart-line' class='chart-canvas' height='300px'></canvas> <script> " +
                      "var ctx2 = document.getElementById('chart-line').getContext('2d');" +
                      "var gradientStroke1 = ctx2.createLinearGradient(0, 230, 0, 50);" +

                "gradientStroke1.addColorStop(1, 'rgba(203,12,159,0.2)');" +
                "gradientStroke1.addColorStop(0.2, 'rgba(72,72,176,0.0)'); " +
                "gradientStroke1.addColorStop(0, 'rgba(203,12,159,0)'); " + //purple colors

                "var gradientStroke2 = ctx2.createLinearGradient(0, 230, 0, 50); " +

                "gradientStroke2.addColorStop(1, 'rgba(20,23,39,0.2)'); " +
                "gradientStroke2.addColorStop(0.2, 'rgba(72,72,176,0.0)'); " +
                "gradientStroke2.addColorStop(0, 'rgba(20,23,39,0)');" + //purple colors

                "var gradientStroke3 = ctx2.createLinearGradient(0, 230, 0, 50);" +

                "gradientStroke3.addColorStop(1, 'rgba(203,0,159,0.2)');" +
                "gradientStroke3.addColorStop(0.2, 'rgba(72,72,72,0.0)'); " +
                "gradientStroke3.addColorStop(0, 'rgba(203,12,120,0)'); " + //purple colors

                "var gradientStroke4 = ctx2.createLinearGradient(0, 230, 0, 50); " +

                "gradientStroke4.addColorStop(1, 'rgba(20,180,139,0.2)'); " +
                "gradientStroke4.addColorStop(0.2, 'rgba(0,72,176,0.0)'); " +
                "gradientStroke4.addColorStop(0, 'rgba(120,123,39,0)');" + //purple colors


                "new Chart(ctx2, {" +
                "type: 'line'," +
                "data: " +
                "{" +
                "labels: [" + strData + "]," +
                "datasets: [{" +
                "label: 'SB Candidates'," +
                "tension: 0.4," +
                "borderWidth: 0," +
                "pointRadius: 0," +
                "borderColor: '#42eff5'," +
                "borderWidth: 3," +
                "backgroundColor: '#42eff5'," +
                "data: [" + lstchartSub[0].submitted + "]," +
                "maxBarThickness: 6,fill:false" +

                "}," +
                "{" +
                "label: 'TL Candidates'," +
                "tension: 0.4," +
                "borderWidth: 0," +
                "pointRadius: 0," +
                "borderColor: '#f58742'," +
                "borderWidth: 3," +
                "backgroundColor: '#f58742'," +
                "data: [" + lstchartSub[1].submitted + "]," +
                "maxBarThickness: 6,fill:false" +

                "}," +
                 "{" +
                "label: 'BP Candidates'," +
                "tension: 0.4," +
                "borderWidth: 0," +
                "pointRadius: 0," +
                "borderColor: '#e642f5'," +
                "borderWidth: 3," +
                "backgroundColor: '#e642f5'," +
                "data: [" + lstchartSub[2].submitted + "]," +
                "maxBarThickness: 6,fill:false" +

                "}," +
                 "{" +
                "label: 'EC Candidates'," +
                "tension: 0.4," +
                "borderWidth: 0," +
                "pointRadius: 0," +
                "borderColor: 'green'," +
                "borderWidth: 3," +
                "backgroundColor: 'green'," +
                "data: [" + lstchartSub[3].submitted + "]," +
                "maxBarThickness: 6,fill:false" +

                "}," +

                "]," +
                "}," +
                "options: " +
                "{" +
                "responsive: true," +
                "maintainAspectRatio: false," +
                "legend: " +
                "{" +
                "display: false," +
                "}," +
                "tooltips: " +
                "{" +
                "enabled: true," +
                "mode: 'index'," +
                "intersect: false," +
                "}," +
                "scales: " +
                "{" +
                "yAxes: [{" +
                "gridLines: " +
                "{" +
                "borderDash: [2]," +
                "borderDashOffset: [2]," +
                "color: '#dee2e6'," +
                "zeroLineColor: '#dee2e6'," +
                "zeroLineWidth: 1," +
                "zeroLineBorderDash: [2]," +
                "drawBorder: false," +
                "}," +
                "ticks: " +
                "{" +
                "suggestedMin: 0," +
                "suggestedMax: 10," +
                "beginAtZero: true," +
                "padding: 10," +
                "fontSize: 11," +
                "fontColor: '#adb5bd'," +
                "lineHeight: 3," +
                "fontStyle: 'normal'," +
                "fontFamily: 'Open Sans'," +
                "}," +
                "},]," +
                "xAxes: [{" +
                "gridLines: " +
                "{" +
                "zeroLineColor: 'rgba(0,0,0,0)'," +
                "display: false," +
                "}," +
                "ticks: " +
                "{" +
                "padding: 10," +
                "fontSize: 11," +
                "fontColor: '#adb5bd'," +
                "lineHeight: 3," +
                "fontStyle: 'normal'," +
                "fontFamily: 'Open Sans'," +
                "}," +
                "},]," +
                "}," +
                "}," +
                "});" +
                "</script>";


            _rd.LinechartTitle = "Submission overview";
            _rd.LineDuration = "Duration for the Week of ";
            _rd.RecentRecuitmentTitle = "Recent recruitment";

            _read.Close();

            DateTime startDate = Convert.ToDateTime(fromdate);
            DateTime endDate = Convert.ToDateTime(todate);
            int days = 0;

            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                if (startDate.DayOfWeek != DayOfWeek.Saturday && startDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    days++;
                }
                startDate = startDate.AddDays(1);
            }

            //if (strtype=="Daily"|| strtype == "Weekly")
            //{

            //}

            //strquery = @"select
            //(
            //select cast(candcount as float)/"+days+" * cast(TargetValue as float) from"+
            //"("+
            //"select count(*) candcount from CandidateDetailsIndia can"+
            //" where can.Created_By like '%" + TWE_id + "%' and " +
            //"can.Created_on between '" + fromdate + "' and '" + todate + "' ) tb1," +
            //"(select Candidate_adding as TargetValue from Userprofilecreation where TWE_ID like'%" + TWE_id + "%') tb2" +
            //") candcount,(" +
            //"select cast(candcount as float)/" + days + " *cast(TargetValue as float) from" +
            //"(" +
            //"select count(*) candcount from CandidateDetailsIndia can" +
            //" join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
            //" join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
            //" where can.Created_By like '%" + TWE_id + "%' and Cand_Status in ('103')" +
            //" and can.Created_on between '" + fromdate + "' and '" + todate + "' ) tb5, " +
            //"(select Submittion as TargetValue from Userprofilecreation where TWE_ID like'%" + TWE_id + "%') tb6" +
            //")subcount," +
            //"(select cast(candcount as float)/" + days + " * cast(TargetValue as float) from" +
            //"(" +
            //"select count(*) candcount from CandidateDetailsIndia can" +
            //" join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
            //" join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
            //" where can.Created_By like '%" + TWE_id + "%' and Cand_Status > 103" +
            //"and can.Created_on between '" + fromdate + "' and '" + todate + "') tb7," +
            //"(select TLApproval as TargetValue from Userprofilecreation where TWE_ID like'%" + TWE_id + "%') tb8" +
            //")TLAppcount," +
            //"(" +
            //"select cast(candcount as float)/" + days + " * cast(TargetValue as float) from" +
            //"(" +
            //"select count(*) candcount from CandidateDetailsIndia can" +
            //" join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
            //" join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
            //" where can.Created_By like '%" + TWE_id + "%' and Cand_Status >= 105" +
            //"and can.Created_on between '" + fromdate + "' and '" + todate + "') tb7," +
            //"(select BPApproval as TargetValue from Userprofilecreation where TWE_ID like'%" + TWE_id + "%') tb8" +
            //")BPAppcount," +
            //"(" +
            //"select cast(candcount as float)/" + days + " * cast(TargetValue as float) from" +
            //"(" +
            //"select count(*) candcount from CandidateDetailsIndia can" +
            //" join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
            //" join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
            //" where can.Created_By like '%" + TWE_id + "%' and Cand_Status >= 107" +
            //"and can.Created_on between '" + fromdate + "' and '" + todate + "') tb7," +
            //"(select ECApproval as TargetValue from Userprofilecreation where TWE_ID like'%" + TWE_id + "%') tb8" +
            //")ECAppcount";


            //_read = _sql.doRead(strquery);
            //while (_read.Read())
            //{
            //    _rd.OverViewPercentage = Math.Round(((Convert.ToDouble(_read[0]) + Convert.ToDouble(_read[1]) + Convert.ToDouble(_read[2]) + Convert.ToDouble(_read[3]) + Convert.ToDouble(_read[4])) / 5), 2).ToString() + " % for the duration of ";

            //}
            //_read.Close();


            _rd.OverviewTitle = "Performance overview";
            if (strtype== "Daily")
            {
                _rd.OverViewPercentage = calculatePercentageOverview(TWE_id, fromdate, todate, "Daily");
                _rd.lstTarget = getTarget(TWE_id, fromdate, todate, "Daily");
            }

            else if (strtype == "Weekly")
            {
                _rd.OverViewPercentage = calculatePercentageOverview(TWE_id, fromdate, todate, "Monthly");
                _rd.lstTarget = getTarget(TWE_id, fromdate, todate, "Monthly");
            }

            

            //strquery = @"select 'End Client-Closure't1,count(*) Onboarded from CandidateDetailsIndia can join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId
            //            join Job_Master_IND job on job.Jobcode=canjob.Jobcode where Cand_Status in ('109') and can.Created_By='" + TWE_id + "' and can.Created_On between '" + fromdate + "' and '" + todate + "'" +
            //            " union " +
            //            " select 'Business Partner Selected't2,count(*) BPSelected from CandidateDetailsIndia can join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
            //            " join Job_Master_IND job on job.Jobcode = canjob.Jobcode where Cand_Status in ('105') and can.Created_By='" + TWE_id + "' and can.Created_On between '" + fromdate + "' and '" + todate + "'" +
            //            " union " +
            //            " select 'Team Lead Approved't3,count(*) TLApproved from CandidateDetailsIndia can join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
            //            " join Job_Master_IND job on job.Jobcode = canjob.Jobcode where Cand_Status in ('105','106','107','108') and can.Created_By='" + TWE_id + "' and can.Created_On between '" + fromdate + "' and '" + todate + "'" +
            //            " union " +
            //            " select 'Submitted't4,count(*) SubmittedTL from CandidateDetailsIndia can join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
            //            " join Job_Master_IND job on job.Jobcode = canjob.Jobcode where Cand_Status in ('103') and can.Created_By='" + TWE_id + "' and can.Created_On between '" + fromdate + "' and '" + todate + "'" +
            //            " union " +
            //            " select 'Vendors't5,count(*) Vendors from EmployerDetailsIndia where Status='1'  and Created_By like '" + TWE_id + "' and Created_On between '" + fromdate + "' and '" + todate + "'" +
            //            " union " +
            //            " select 'Candidates't6,count(*) SubmitCand from CandidateDetailsIndia can join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
            //            " join Job_Master_IND job on job.Jobcode = canjob.Jobcode where Cand_Status in ('101','102','103') and can.Created_By='" + TWE_id + "'and can.Created_On between '" + fromdate + "' and '" + todate + "'" +
            //            " --union " +
            //            " --select ''t7,count(*) BackupCand from BackupCandidateDetails where Created_By='" + TWE_id + "' and Created_On between '" + fromdate + "' and '" + todate + "'";
            //_read = _sql.doRead(strquery);
            //while (_read.Read())
            //{
            //    performanceoverview _pov = new performanceoverview();
            //    _pov.PerformanceName = _read[0].ToString();
            //    _pov.PerformanceCount = _read[1].ToString();
            //    _lstpov.Add(_pov);
            //}
            //_read.Close();
            //_rd.PerformaceOverView = _lstpov;

            //_rd.lstTarget = new List<targetfixingMstr>();

            //strquery = @"select * from 
            //            (
            //            select count(*) Onboarded from CandidateDetailsIndia can join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId
            //            join Job_Master_IND job on job.Jobcode=canjob.Jobcode where Cand_Status in ('109') and can.Created_By='" + TWE_id + "' and can.Created_On between '" + fromdate + "' and '" + todate + "') tb1,(" +
            //            " select count(*) BPSelected from CandidateDetailsIndia can join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
            //            " join Job_Master_IND job on job.Jobcode = canjob.Jobcode where Cand_Status in ('105') and can.Created_By='" + TWE_id + "' and can.Created_On between '" + fromdate + "' and '" + todate + "') tb2,(" +
            //            " select count(*) TLApproved from CandidateDetailsIndia can join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
            //            " join Job_Master_IND job on job.Jobcode = canjob.Jobcode where Cand_Status in ('105','106','107','108') and can.Created_By='" + TWE_id + "' and can.Created_On between '" + fromdate + "' and '" + todate + "') tb3,(" +

            //            " select count(*) SubmittedTL from CandidateDetailsIndia can join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
            //            " join Job_Master_IND job on job.Jobcode = canjob.Jobcode where Cand_Status in ('103') and can.Created_By='" + TWE_id + "' and can.Created_On between '" + fromdate + "' and '" + todate + "') tb4,(" +

            //            " select count(*) Vendors from EmployerDetailsIndia where Status='1' and Created_By like '" + TWE_id + "' and Created_On between '" + fromdate + "' and '" + todate + "') tb5,(" +

            //            " select count(*) SubmitCand from CandidateDetailsIndia can join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
            //            " join Job_Master_IND job on job.Jobcode = canjob.Jobcode where Cand_Status in ('101','102','103') and can.Created_By='" + TWE_id + "'and can.Created_On between '" + fromdate + "' and '" + todate + "') tb6";


            //_read = _sql.doRead(strquery);

            //while (_read.Read())
            //{
            //    targetfixingMstr _tfm = new targetfixingMstr();
            //    _tfm.TargetfixingId = _read[0].ToString();
            //    _tfm.RoleType = _read[1].ToString();
            //    _tfm.LevelType = _read[2].ToString();
            //    _tfm.RegionType = _read[3].ToString();
            //    _tfm.SubmissiontoTL_Daily = _read[4].ToString();
            //    _tfm.Submission_Daily = _read[5].ToString();
            //    _tfm.SubmissiontoBP_Daily = _read[6].ToString();
            //    _tfm.Closure_Daily = _read[7].ToString();
            //    _tfm.Vendor_Daily = _read[8].ToString();
            //    _tfm.Submission_Monthly = _read[9].ToString();
            //    _tfm.SubmissiontoTL_Monthly = _read[10].ToString();
            //    _tfm.SubmissiontoBP_Monthly = _read[11].ToString();
            //    _tfm.Closure_Monthly = _read[12].ToString();
            //    _tfm.Vendor_Monthly = _read[13].ToString();
            //    _tfm.Submission_Weekly = _read[14].ToString();
            //    _tfm.SubmissiontoTL_Weekly = _read[15].ToString();
            //    _tfm.SubmissiontoBP_Weekly = _read[16].ToString();
            //    _tfm.Closure_Weekly = _read[17].ToString();
            //    _tfm.Vendor_Weekly = _read[18].ToString();
            //    _rd.lstTarget.Add(_tfm);

            //}
            //_read.Close();

            //strquery = @"SELECT [firstname]
            //          ,[lastname],[Candidate_adding] * " + days + " Candidate_adding" +
            //          ",[Vendor_creation] * " + days + " Vendor_creation,[Submittion] * " + days + " Submittion" +
            //          ",[TLApproval] * " + days + " TLApproval,[BPApproval] * " + days + "BPApproval" +
            //          ",[ECApproval]* " + days + " ECApproval FROM [Userprofilecreation] where [TWE_ID]='" + TWE_id + "'";

            //_read = _sql.doRead(strquery);
            //while (_read.Read())
            //{
            //    targetfixingMstr _tfm = new targetfixingMstr();
            //    _tfm.TargetfixingId = _read[0].ToString();
            //    _tfm.RoleType = _read[1].ToString();
            //    _tfm.LevelType = _read[2].ToString();
            //    _tfm.RegionType = _read[3].ToString();
            //    _tfm.SubmissiontoTL_Daily = _read[4].ToString();
            //    _tfm.Submission_Daily = _read[5].ToString();
            //    _tfm.SubmissiontoBP_Daily = _read[6].ToString();
            //    _tfm.Closure_Daily = _read[7].ToString();
            //    _tfm.Vendor_Daily = _read[8].ToString();
            //    _tfm.Submission_Monthly = _read[9].ToString();
            //    _tfm.SubmissiontoTL_Monthly = _read[10].ToString();
            //    _tfm.SubmissiontoBP_Monthly = _read[11].ToString();
            //    _tfm.Closure_Monthly = _read[12].ToString();
            //    _tfm.Vendor_Monthly = _read[13].ToString();
            //    _tfm.Submission_Weekly = _read[14].ToString();
            //    _tfm.SubmissiontoTL_Weekly = _read[15].ToString();
            //    _tfm.SubmissiontoBP_Weekly = _read[16].ToString();
            //    _tfm.Closure_Weekly = _read[17].ToString();
            //    _tfm.Vendor_Weekly = _read[18].ToString();
            //    _rd.lstTarget.Add(_tfm);

            //}
            //_read.Close();


            JobMaster _db = new JobMaster();
            _db.lstJob = new List<JobcodeList>();

            strquery = @"select * from(select distinct job.Jobcode,JobTitle,Duration,empl.EmpTypeName,loc.LocationName,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage,Assigned_To,job.Created_On as Datecreated from Job_Master_IND job
                                join Location_Master loc on job.Location=loc.LocationID
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientContactID=job.Contactname
                                join CandidateJobIndia canjob on canjob.Jobcode=job.Jobcode
								join CandidateDetailsIndia cand on cand.candidateid=canjob.CandidateId
                                where canjob.Created_by like '%" + TWE_id + "%' and canjob.Created_On between '" + fromdate + "' and '" + todate + "'" +") tb1 order by Datecreated desc";

            _read = _sql.doRead(strquery);
            while (_read.Read())
            {
                JobcodeList objJob = new JobcodeList();

                objJob.Jobcode = _read[0].ToString();
                objJob.JobTitle = _read[1].ToString();
                objJob.JobDuration = _read[2].ToString();
                objJob.JobType = _read[3].ToString();
                objJob.JobState = _read[4].ToString();
                objJob.JobStatus = _read[5].ToString();
                objJob.JobClient = _read[6].ToString();
                objJob.JobContact = _read[7].ToString();
                objJob.CreatedOn = _read[8].ToString();
                objJob.JobMediaPath = _read[9].ToString();
                objJob.Assigned_To = _read[10].ToString();
                _rd.lstJob.Add(objJob);

            }

            _read.Close();

            _rd.lstRemarks = new List<dropDownTemplate>();

            strquery = @"SELECT [RemarksID],[RemarksName] FROM [Remarks_Master] where Status=1";

            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                _rd.lstRemarks.Add(new dropDownTemplate
                {
                    ID = _read["RemarksID"].ToString(),
                    Name = _read["RemarksName"].ToString()
                });
            }

            _read.Close();

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
                _json.data = _rd;
            }

            return _json;

        }

        public jsonArray getTeammemberdashboarddetails(string TWE_id, string fromdate, string todate, string strType)
        {
            Recrutingdashboard _rd = new Recrutingdashboard();
            List<tiles> _lsttls = new List<tiles>();
            List<statuscount> _lststc = new List<statuscount>();
            List<performanceoverview> _lstpov = new List<performanceoverview>();
            List<recruitmenttable> _lstrt = new List<recruitmenttable>();
            List<barchartlist> _lstbar = new List<barchartlist>();
            List<linechartlist> _lstline = new List<linechartlist>();

            _rd.lstJob = new List<JobcodeList>();

            int status = 1;
            string strquery = "";
            string strtype = strType;
            _rd.TWE_id = TWE_id;

            strquery = @"select firstname+' '+lastname Empname from Userprofilecreation where TWE_ID='" + TWE_id + "' and Status=1";

            SqlDataReader _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                _rd.UserName = _read[0].ToString();
            }

            _read.Close();


            strquery = @"select * from
                            (select 'Total jobs Worked' Title,count(distinct job.Jobcode) Total_Jbs_Worked from Job_Master_USA job
                            join CandidateJob canjob on canjob.Jobcode=job.Jobcode
                            join CandidateDetails cand on cand.candidateid=canjob.CandidateId" +
                        " where Assigned_To like '%" + TWE_id + "%' and canjob.Created_On between '" + fromdate + "' and '" + todate + "'" +
                        ") tb1," +

                        "(select 'Interview Candidates' Title,count(distinct cand.candidateid) Interview_Count from Job_Master_USA job " +
                        "join CandidateJob canjob on canjob.Jobcode=job.Jobcode " +
                        "join CandidateDetails cand on cand.candidateid=canjob.CandidateId" +
                        " where cand.Created_By like '%" + TWE_id + "%' and Cand_Status in ('110','111') and canjob.Created_On between '" + fromdate + "' and '" + todate + "'" +
                        ") tb2," +
                        "(" +
                        "select 'Candidates Added' Title,count(distinct cand.candidateid) Candidate_Count from CandidateJob canjob  " +
                        "join CandidateDetails cand on cand.candidateid=canjob.CandidateId" +
                        " where cand.Created_By like '%" + TWE_id + "%' and cand.Created_On between '" + fromdate + "' and '" + todate + "'" +
                        ") tb3," +
                        "(select 'Closure Candidates' Title,count(distinct cand.candidateid) Closure_Count from Job_Master_USA job " +
                        " join CandidateJob canjob on canjob.Jobcode=job.Jobcode " +
                        " join CandidateDetails cand on cand.candidateid=canjob.CandidateId" +
                        " where cand.Created_By like '%" + TWE_id + "%' and Cand_Status in ('109') and canjob.Created_On between '" + fromdate + "' and '" + todate + "'" +
                        " ) tb4";


            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                tiles _tls1 = new tiles();
                _tls1.TileTitle = _read[0].ToString();
                _tls1.TotalCount = _read[1].ToString();

                _lsttls.Add(_tls1);

                tiles _tls2 = new tiles();
                _tls2.TileTitle = _read[2].ToString();
                _tls2.TotalCount = _read[3].ToString();

                _lsttls.Add(_tls2);

                tiles _tls3 = new tiles();
                _tls3.TileTitle = _read[4].ToString();
                _tls3.TotalCount = _read[5].ToString();

                _lsttls.Add(_tls3);

                tiles _tls4 = new tiles();
                _tls4.TileTitle = _read[6].ToString();
                _tls4.TotalCount = _read[7].ToString();

                _lsttls.Add(_tls4);


            }
            _read.Close();
            _rd.Tiles = _lsttls;



            //Bar Chart Query
            if (strtype == "Monthly")
            {
                strquery = @"select count(*) CandCount,Substring(Datename(mm,(can.Created_On)),0,4) MonName from CandidateDetails can
                                        join CandidateJob canjob on can.candidateid=canjob.CandidateId
                                        join Job_Master_USA job on job.Jobcode=canjob.Jobcode
                                        where Cand_Status in ('103')
                                        and can.Created_By='" + TWE_id + "' and can.Created_On between '" + fromdate + "' and '" + todate +
                                        "' group by Datename(mm,(can.Created_On))";
            }
            else if (strtype == "Daily")
            {
                strquery = @"select count(*) CandCount,Substring(Datename(Weekday,can.Created_On),0,4) dyName from CandidateDetails can
                                        join CandidateJob canjob on can.candidateid=canjob.CandidateId
                                        join Job_Master_USA job on job.Jobcode=canjob.Jobcode
                                        where Cand_Status in ('103')
                                        and can.Created_By='" + TWE_id + "' and can.Created_On between '" + fromdate + "' and '" + todate +
                                        "' group by  Datename(Weekday,can.Created_On)";
            }
            else if (strtype == "Weekly")
            {
                strquery = @"select count(*) CandCount, 'Week '+ Convert(varchar,DATEPART(week,can.Created_On)) WkName from CandidateDetails can
                                        join CandidateJob canjob on can.candidateid=canjob.CandidateId
                                        join Job_Master_USA job on job.Jobcode=canjob.Jobcode
                                        where Cand_Status in ('103')
                                        and can.Created_By='" + TWE_id + "' and can.Created_On between '" + fromdate + "' and '" + todate
                                        + "' group by DATEPART(week,can.Created_On)";
            }
            _read = _sql.doRead(strquery);
            while (_read.Read())
            {
                barchartlist _bcl = new barchartlist();
                _bcl.candCount = _read[0].ToString();
                _bcl.itemName = _read[1].ToString();
                _lstbar.Add(_bcl);

            }
            _read.Close();
            string data1 = "";
            if (_lstbar.Count != 0)
            {
                for (int i = 0; i < _lstbar.Count; i++)
                {
                    data1 += _lstbar[i].candCount + ",";
                }
                data1 = data1.Substring(0, data1.Length - 1);
            }

            string data2 = "";
            if (_lstbar.Count != 0)
            {
                for (int i = 0; i < _lstbar.Count; i++)
                {
                    data2 += "'" + _lstbar[i].itemName + "',";
                }
                data2 = data2.Substring(0, data2.Length - 1);
            }

            _rd.Barchart = "<canvas id='chart-bars' class='chart-canvas' height='170px'></canvas>  <script> " +
                        "var ctx = document.getElementById('chart-bars').getContext('2d'); " +
                        "new Chart(ctx, {" +
                        "type: 'bar'," +
                        "data: {" +
                        "labels: [" + data2 + "]," +
                        "datasets: [{" +
                        "label: 'Submissions'," +
                        "tension: 0.4," +
                        "borderWidth: 0," +
                        "pointRadius: 0," +
                        "backgroundColor: '#fff'," +
                        "data: [" + data1 + "]," +
                        "maxBarThickness: 6" +
                        "},]," +
                        "}," +
                        "options:" +
                        "{" +
                        "responsive: true," +
                        "maintainAspectRatio: false," +
                        "legend:" +
                        "{" +
                        "display: false," +
                        "}," +
                        "tooltips:" +
                        "{" +
                        "enabled: true," +
                        "mode: 'index'," +
                        "intersect: false," +
                        "}," +
                        "scales: " +
                        "{" +
                        "yAxes: [{" +
                        "gridLines:" +
                        "{" +
                        "display: false," +
                        "}," +
                        "ticks: " +
                        "{" +
                        "suggestedMin: 0," +
                        "suggestedMax: 5," +
                        "beginAtZero: true," +
                        "padding: 0," +
                        "fontSize: 14," +
                        "lineHeight: 3," +
                        "fontColor: '#fff'," +
                        "fontStyle: 'normal'," +
                        "fontFamily: 'Open Sans'," +
                        "}," +
                        "},]," +
                        "xAxes: [{" +
                        "gridLines: " +
                        "{" +
                        "display: false," +
                        "}," +
                        "ticks: " +
                        "{" +
                        "display: false," +
                        "padding: 20," +
                        "}," +
                        "},]," +
                        "}," +
                        "}," +
                        "}); </script>";
            _rd.BarTitle = "Active Candidates";
            _rd.BarDuration = "Duration for the Week of ";

            strquery = @"select '1't1,'SB'sp,count(*) EC_Selected from CandidateDetails can
                                        join CandidateJob canjob on can.candidateid=canjob.CandidateId
                                        left join Job_Master_USA job on job.Jobcode=canjob.Jobcode where Cand_Status in ('101','102') and can.Created_By like '%" + TWE_id + "%' and can.Created_On between '" + fromdate + "' and '" + todate + "'" +
                                       " union " +
                                       "select '2't2,'TL'tl,count(*) EC_Selected from CandidateDetails can" +
                                               " join CandidateJob canjob on can.candidateid = canjob.CandidateId" +
                                               " join Job_Master_USA job on job.Jobcode = canjob.Jobcode where Cand_Status in ('103') and can.Created_By like '%" + TWE_id + "%' and can.Created_On between '" + fromdate + "' and '" + todate + "'" +
                                       " union " +
                                       " select '3't3,'BP'bp,count(*) EC_Selected from CandidateDetails can" +
                                               " join CandidateJob canjob on can.candidateid = canjob.CandidateId" +
                                               " join Job_Master_USA job on job.Jobcode = canjob.Jobcode where Cand_Status in ('105') and can.Created_By like '%" + TWE_id + "%' and can.Created_On between '" + fromdate + "' and '" + todate + "'" +
                                       " union " +
                                       " select '4't4,'EC'ec,count(*) EC_Selected from CandidateDetails can" +
                                               " join CandidateJob canjob on can.candidateid = canjob.CandidateId" +
                                               " join Job_Master_USA job on job.Jobcode = canjob.Jobcode where Cand_Status in ('107') and can.Created_By like '%" + TWE_id + "%' and can.Created_On between '" + fromdate + "' and '" + todate + "'";

            _read = _sql.doRead(strquery);
            while (_read.Read())
            {
                statuscount _sc = new statuscount();
                _sc.StatusTitle = _read[1].ToString();
                _sc.StatusValue = _read[2].ToString();
                _lststc.Add(_sc);

            }
            _rd.StatusCount = _lststc;
            _read.Close();


            if (strtype == "Monthly")
            {
                strquery = @"select 'SB'colname, count(*) Submitted,month(can.Created_On) Monname  from CandidateDetails can" +
                                       " join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                                       " left join Job_Master_USA job on job.Jobcode = canjob.Jobcode" +
                                       " where Cand_Status in ('101','102') and can.Created_By like '%" + TWE_id + "%' " +
                                       " and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                                       " group by month(can.Created_On) " +
                                       " union " +
                                       " select 'TL'colname,count(*) TL_Selected,month(can.Created_On) Monname from CandidateDetails can" +
                                       " join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                                       " join Job_Master_USA job on job.Jobcode = canjob.Jobcode" +
                                       " where Cand_Status in ('103') and can.Created_By like '%" + TWE_id + "%' " +
                                       " and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                                       " group by month(can.Created_On) " +
                                       " union " +
                                       " select 'BP'colname,count(*) BP_Selected,month(can.Created_On) Monname  from CandidateDetails can" +
                                       " join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                                       " join Job_Master_USA job on job.Jobcode = canjob.Jobcode where " +
                                       " Cand_Status in ('105') and can.Created_By like '%" + TWE_id + "%' " +
                                       " and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                                       " group by month(can.Created_On) " +
                                       " union " +
                                       " select 'EC'colname,count(*) EC_Selected,month(can.Created_On) Monname from CandidateDetails can" +
                                       " join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                                       " join Job_Master_USA job on job.Jobcode = canjob.Jobcode where " +
                                       " Cand_Status in ('107') and can.Created_By like '%" + TWE_id + "%' " +
                                       " and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                                       " group by month(can.Created_On)";
            }
            else if (strtype == "Weekly")
            {
                strquery = @"select 'SB'colname, count(*) Submitted,DATEPART(week,can.Created_On) Wkname  from CandidateDetails can" +
                            " join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                            " left join Job_Master_USA job on job.Jobcode = canjob.Jobcode" +
                            " where Cand_Status in ('101','102') and can.Created_By like '%" + TWE_id + "%' " +
                            " and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                            " group by DATEPART(week,can.Created_On) " +
                            " union " +
                            " select 'TL'colname,count(*) TL_Selected,DATEPART(week,can.Created_On) Wkname from CandidateDetails can" +
                            " join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                            " join Job_Master_USA job on job.Jobcode = canjob.Jobcode" +
                            " where Cand_Status in ('103') and can.Created_By like '%" + TWE_id + "%' " +
                            " and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                            " group by DATEPART(week,can.Created_On) " +
                            " union " +
                            " select 'BP'colname,count(*) BP_Selected,DATEPART(week,can.Created_On) Wkname  from CandidateDetails can" +
                            " join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                            " join Job_Master_USA job on job.Jobcode = canjob.Jobcode" +
                            " where Cand_Status in ('105') and can.Created_By like '%" + TWE_id + "%' " +
                            " and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                            " group by DATEPART(week,can.Created_On) " +
                            " union " +
                            " select 'EC'colname,count(*) EC_Selected,DATEPART(week,can.Created_On) Wkname from CandidateDetails can" +
                            " join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                            " join Job_Master_USA job on job.Jobcode = canjob.Jobcode" +
                            " where Cand_Status in ('107') and can.Created_By like '%" + TWE_id + "%' " +
                            " and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                            " group by DATEPART(week,can.Created_On)";
            }
            else if (strtype == "Daily")
            {
                strquery = @"select 'SB'colname, count(*) Submitted,substring(datename(dw,can.Created_On),0,4) dyname  from CandidateDetails can" +
                                   " join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                                   " left join Job_Master_USA job on job.Jobcode = canjob.Jobcode" +
                                   " where Cand_Status in ('101','102') and can.Created_By like '%" + TWE_id + "%' " +
                                   " and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                                   " group by datename(dw,can.Created_On) " +
                                   " union " +
                                   " select 'TL'colname,count(*) TL_Selected,substring(datename(dw,can.Created_On),0,4) dyname from CandidateDetails can" +
                                   " join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                                   " join Job_Master_USA job on job.Jobcode = canjob.Jobcode" +
                                   " where Cand_Status in ('103') and can.Created_By like '%" + TWE_id + "%' " +
                                   " and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                                   " group by datename(dw,can.Created_On) " +
                                   " union " +
                                   " select 'BP'colname,count(*) BP_Selected,substring(datename(dw,can.Created_On),0,4) dyname  from CandidateDetails can" +
                                   " join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                                   " join Job_Master_USA job on job.Jobcode = canjob.Jobcode where " +
                                   " Cand_Status in ('105') and can.Created_By like '%" + TWE_id + "%' " +
                                   " and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                                   " group by datename(dw,can.Created_On) " +
                                   " union " +
                                   " select 'EC'colname,count(*) EC_Selected,substring(datename(dw,can.Created_On),0,4) dyname from CandidateDetails can" +
                                   " join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                                   " join Job_Master_USA job on job.Jobcode = canjob.Jobcode where " +
                                   " Cand_Status in ('107') and can.Created_By like '%" + TWE_id + "%' " +
                                   " and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                                   " group by datename(dw,can.Created_On) ";
            }
            _read = _sql.doRead(strquery);
            while (_read.Read())
            {
                linechartlist _lcl = new linechartlist();
                _lcl.colName = _read[0].ToString();
                _lcl.submitted = _read[1].ToString();
                _lcl.itemName = _read[2].ToString();
                _lstline.Add(_lcl);

            }
            _read.Close();

            string strData = "";

            int timeVal = 0;
            if (strtype == "Monthly")
            {
                timeVal = 12;
                strData = "'Jan','Feb','Mar','Apr','May','Jun','Jul','Aug','Sep','Oct','Nov','Dec'";
            }
            else if (strtype == "Weekly")
            {
                timeVal = 53;
                strData = "'Wk1','Wk2','Wk3','Wk4','Wk5','Wk6','Wk7','Wk8','Wk9','Wk10','Wk11','Wk12','Wk13','Wk14','Wk15','Wk16','Wk17','Wk18','Wk19','Wk20','Wk21','Wk22','Wk23','Wk24','Wk25','Wk26','Wk27','Wk28','Wk29','Wk30','Wk31','Wk32','Wk33','Wk34','Wk35','Wk36','Wk37','Wk38','Wk39','Wk40','Wk41','Wk42','Wk43','Wk44','Wk45','Wk46','Wk47','Wk48','Wk49','Wk50','Wk51','Wk52','Wk53'";
            }
            else if (strtype == "Daily")
            {
                timeVal = 7;
                strData = "'Sun','Mon','Tue','Wed','Thu','Fri','Sat'";
            }
            string[] stageArr = { "SB", "TL", "BP", "EC" };



            List<linechartlist> lstchartSub = new List<linechartlist>();

            List<linechartlist> lstDt0 = _lstline.OrderBy(x => x.itemName).ThenBy(y => y.colName).ToList<linechartlist>();

            for (int i = 0; i < stageArr.Length; i++)
            {

                string countval = "";
                for (int j = 1; j <= timeVal; j++)
                {

                    List<linechartlist> lstResult = _lstline.Where(x => (x.itemName == j.ToString()) && (x.colName == stageArr[i])).ToList<linechartlist>();
                    if (lstResult.Count == 0)
                    {
                        countval = countval + "0" + ",";
                    }
                    else
                    {
                        countval = countval + lstResult[0].submitted.ToString() + ",";
                    }

                }
                
                lstchartSub.Add(new linechartlist() { colName = stageArr[i], submitted = countval.Substring(0, countval.Length - 1) });
                countval = "";

            }           
            

            _rd.Linechart = "<canvas id='chart-line' class='chart-canvas' height='300px'></canvas> <script> " +
                      "var ctx2 = document.getElementById('chart-line').getContext('2d');" +
                      "var gradientStroke1 = ctx2.createLinearGradient(0, 230, 0, 50);" +

                "gradientStroke1.addColorStop(1, 'rgba(203,12,159,0.2)');" +
                "gradientStroke1.addColorStop(0.2, 'rgba(72,72,176,0.0)'); " +
                "gradientStroke1.addColorStop(0, 'rgba(203,12,159,0)'); " + //purple colors

                "var gradientStroke2 = ctx2.createLinearGradient(0, 230, 0, 50); " +

                "gradientStroke2.addColorStop(1, 'rgba(20,23,39,0.2)'); " +
                "gradientStroke2.addColorStop(0.2, 'rgba(72,72,176,0.0)'); " +
                "gradientStroke2.addColorStop(0, 'rgba(20,23,39,0)');" + //purple colors

                "var gradientStroke3 = ctx2.createLinearGradient(0, 230, 0, 50);" +

                "gradientStroke3.addColorStop(1, 'rgba(203,0,159,0.2)');" +
                "gradientStroke3.addColorStop(0.2, 'rgba(72,72,72,0.0)'); " +
                "gradientStroke3.addColorStop(0, 'rgba(203,12,120,0)'); " + //purple colors

                "var gradientStroke4 = ctx2.createLinearGradient(0, 230, 0, 50); " +

                "gradientStroke4.addColorStop(1, 'rgba(20,180,139,0.2)'); " +
                "gradientStroke4.addColorStop(0.2, 'rgba(0,72,176,0.0)'); " +
                "gradientStroke4.addColorStop(0, 'rgba(120,123,39,0)');" + //purple colors


                "new Chart(ctx2, {" +
                "type: 'line'," +
                "data: " +
                "{" +
                "labels: [" + strData + "]," +
                "datasets: [{" +
                "label: 'SB Candidates'," +
                "tension: 0.4," +
                "borderWidth: 0," +
                "pointRadius: 0," +
                "borderColor: '#42eff5'," +
                "borderWidth: 3," +
                "backgroundColor: '#42eff5'," +
                "data: [" + lstchartSub[0].submitted + "]," +
                "maxBarThickness: 6,fill:false" +

                "}," +
                "{" +
                "label: 'TL Candidates'," +
                "tension: 0.4," +
                "borderWidth: 0," +
                "pointRadius: 0," +
                "borderColor: '#f58742'," +
                "borderWidth: 3," +
                "backgroundColor: '#f58742'," +
                "data: [" + lstchartSub[1].submitted + "]," +
                "maxBarThickness: 6,fill:false" +

                "}," +
                 "{" +
                "label: 'BP Candidates'," +
                "tension: 0.4," +
                "borderWidth: 0," +
                "pointRadius: 0," +
                "borderColor: '#e642f5'," +
                "borderWidth: 3," +
                "backgroundColor: '#e642f5'," +
                "data: [" + lstchartSub[2].submitted + "]," +
                "maxBarThickness: 6,fill:false" +

                "}," +
                 "{" +
                "label: 'EC Candidates'," +
                "tension: 0.4," +
                "borderWidth: 0," +
                "pointRadius: 0," +
                "borderColor: 'green'," +
                "borderWidth: 3," +
                "backgroundColor: 'green'," +
                "data: [" + lstchartSub[3].submitted + "]," +
                "maxBarThickness: 6,fill:false" +

                "}," +

                "]," +
                "}," +
                "options: " +
                "{" +
                "responsive: true," +
                "maintainAspectRatio: false," +
                "legend: " +
                "{" +
                "display: false," +
                "}," +
                "tooltips: " +
                "{" +
                "enabled: true," +
                "mode: 'index'," +
                "intersect: false," +
                "}," +
                "scales: " +
                "{" +
                "yAxes: [{" +
                "gridLines: " +
                "{" +
                "borderDash: [2]," +
                "borderDashOffset: [2]," +
                "color: '#dee2e6'," +
                "zeroLineColor: '#dee2e6'," +
                "zeroLineWidth: 1," +
                "zeroLineBorderDash: [2]," +
                "drawBorder: false," +
                "}," +
                "ticks: " +
                "{" +
                "suggestedMin: 0," +
                "suggestedMax: 10," +
                "beginAtZero: true," +
                "padding: 10," +
                "fontSize: 11," +
                "fontColor: '#adb5bd'," +
                "lineHeight: 3," +
                "fontStyle: 'normal'," +
                "fontFamily: 'Open Sans'," +
                "}," +
                "},]," +
                "xAxes: [{" +
                "gridLines: " +
                "{" +
                "zeroLineColor: 'rgba(0,0,0,0)'," +
                "display: false," +
                "}," +
                "ticks: " +
                "{" +
                "padding: 10," +
                "fontSize: 11," +
                "fontColor: '#adb5bd'," +
                "lineHeight: 3," +
                "fontStyle: 'normal'," +
                "fontFamily: 'Open Sans'," +
                "}," +
                "},]," +
                "}," +
                "}," +
                "});" +
                "</script>";

            _rd.LinechartTitle = "Submission overview";
            _rd.LineDuration = "Duration for the Week of ";
            _rd.RecentRecuitmentTitle = "Recent recruitment";

            _read.Close();           


            DateTime startDate = Convert.ToDateTime(fromdate);
            DateTime endDate = Convert.ToDateTime(todate);
            int days = 0;

            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                if (startDate.DayOfWeek != DayOfWeek.Saturday && startDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    days++;
                }
                startDate = startDate.AddDays(1);
            }

            strquery = @"select
            (
            select cast(candcount as float)/"+ days + "* cast(TargetValue as float) from"+
            "("+
            "select count(*) candcount from CandidateDetails can"+
            " where can.Created_By like '%" + TWE_id + "%' and " +
            "can.Created_on between '" + fromdate + "' and '" + todate + "' ) tb1," +
            "(select Candidate_adding as TargetValue from Userprofilecreation where TWE_ID like'%" + TWE_id + "%') tb2" +
            ") candcount,(" +
            "select cast(vencount as float)/" + days + "* cast(TargetValue as float) from" +
            "(" +
            "select count(*) vencount from EmployerDetails where Created_By like '%" + TWE_id + "%'" +
            " and Created_On between '" + fromdate + "' and '" + todate + "') tb3," +
            " (select TargetValue from TargetMaster_USA where TargetType='Vendors') tb4" +
            " ) vencount," +
            "(" +
            "select cast(candcount as float)/" + days + "* cast(TargetValue as float) from" +
            "(" +
            "select count(*) candcount from CandidateDetails can" +
            " join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
            " join Job_Master_USA job on job.Jobcode = canjob.Jobcode" +
            " where can.Created_By like '%" + TWE_id + "%' and Cand_Status in ('103')" +
            " and can.Created_on between '" + fromdate + "' and '" + todate + "' ) tb5, " +
            "(select Submittion as TargetValue from Userprofilecreation where TWE_ID like'%" + TWE_id + "%') tb6" +
            ")subcount," +
            "(select cast(candcount as float) /" + days + "* cast(TargetValue as float) from" +
            "(" +
            "select count(*) candcount from CandidateDetails can" +
            " join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
            " join Job_Master_USA job on job.Jobcode = canjob.Jobcode" +
            " where can.Created_By like '%" + TWE_id + "%' and Cand_Status > 103" +
            "and can.Created_on between '" + fromdate + "' and '" + todate + "') tb7," +
            "(select TLApproval as TargetValue from Userprofilecreation where TWE_ID like'%" + TWE_id + "%') tb8" +
            ")TLAppcount," +
            "(" +
            "select cast(candcount as float) /" + days + "* cast(TargetValue as float) from" +
            "(" +
            "select count(*) candcount from CandidateDetails can" +
            " join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
            " join Job_Master_USA job on job.Jobcode = canjob.Jobcode" +
            " where can.Created_By like '%" + TWE_id + "%' and Cand_Status >= 105" +
            "and can.Created_on between '" + fromdate + "' and '" + todate + "') tb7," +
            "(select BPApproval as TargetValue from Userprofilecreation where TWE_ID like'%" + TWE_id + "%') tb8" +
            ")BPAppcount," +
            "(" +
            "select cast(candcount as float) /" + days + "*  cast(TargetValue as float) from" +
            "(" +
            "select count(*) candcount from CandidateDetails can" +
            " join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
            " join Job_Master_USA job on job.Jobcode = canjob.Jobcode" +
            " where can.Created_By like '%" + TWE_id + "%' and Cand_Status >= 107" +
            "and can.Created_on between '" + fromdate + "' and '" + todate + "') tb7," +
            "(select ECApproval as TargetValue from Userprofilecreation where TWE_ID like'%" + TWE_id + "%') tb8" +
            ")ECAppcount";


            _read = _sql.doRead(strquery);
            while (_read.Read())
            {
                _rd.OverViewPercentage = Math.Round(((Convert.ToDouble(_read[0]) + Convert.ToDouble(_read[1]) + Convert.ToDouble(_read[2]) + Convert.ToDouble(_read[3]) + Convert.ToDouble(_read[4]) + Convert.ToDouble(_read[5])) / 6), 2).ToString() + " % for the duration of ";

            }
            _read.Close();


            _rd.OverviewTitle = "Performance overview";
            //_rd.OverViewPercentage = "4% this month";

            strquery = @"select 'End Client-Closure't1,count(*) Onboarded from CandidateDetails can join CandidateJob canjob on can.candidateid=canjob.CandidateId
                        join Job_Master_USA job on job.Jobcode=canjob.Jobcode where Cand_Status in ('109') and can.Created_By='" + TWE_id + "' and can.Created_On between '" + fromdate + "' and '" + todate + "'" +
                        " union " +
                        " select 'Business Partner Selected't2,count(*) BPSelected from CandidateDetails can join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                        " join Job_Master_USA job on job.Jobcode = canjob.Jobcode where Cand_Status in ('105') and can.Created_By='" + TWE_id + "' and can.Created_On between '" + fromdate + "' and '" + todate + "'" +
                        " union " +
                        " select 'Team Lead Approved't3,count(*) TLApproved from CandidateDetails can join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                        " join Job_Master_USA job on job.Jobcode = canjob.Jobcode where Cand_Status in ('105','106','107','108') and can.Created_By='" + TWE_id + "' and can.Created_On between '" + fromdate + "' and '" + todate + "'" +
                        " union " +
                        " select 'Submitted't4,count(*) SubmittedTL from CandidateDetails can join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                        " join Job_Master_USA job on job.Jobcode = canjob.Jobcode where Cand_Status in ('103') and can.Created_By='" + TWE_id + "' and can.Created_On between '" + fromdate + "' and '" + todate + "'" +
                        " union " +
                        " select 'Vendors't5,count(*) Vendors from EmployerDetails where Status='1'  and Created_By like '" + TWE_id + "' and Created_On between '" + fromdate + "' and '" + todate + "'" +
                        " union " +
                        " select 'Candidates't6,count(*) SubmitCand from CandidateDetails can join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                        " join Job_Master_USA job on job.Jobcode = canjob.Jobcode where Cand_Status in ('101','102','103') and can.Created_By='" + TWE_id + "'and can.Created_On between '" + fromdate + "' and '" + todate + "'" +
                        " --union " +
                        " --select ''t7,count(*) BackupCand from BackupCandidateDetails where Created_By='" + TWE_id + "' and Created_On between '" + fromdate + "' and '" + todate + "'";
            _read = _sql.doRead(strquery);
            while (_read.Read())
            {
                performanceoverview _pov = new performanceoverview();
                _pov.PerformanceName = _read[0].ToString();
                _pov.PerformanceCount = _read[1].ToString();
                _lstpov.Add(_pov);
            }
            _read.Close();
            _rd.PerformaceOverView = _lstpov;

            _rd.lstTarget = new List<targetfixingMstr>();

            strquery = @"select * from 
                        (
                        select count(*) Onboarded from CandidateDetails can join CandidateJob canjob on can.candidateid=canjob.CandidateId
                        join Job_Master_USA job on job.Jobcode=canjob.Jobcode where Cand_Status in ('109') and can.Created_By='" + TWE_id + "' and can.Created_On between '" + fromdate + "' and '" + todate + "') tb1,(" +
                        " select count(*) BPSelected from CandidateDetails can join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                        " join Job_Master_USA job on job.Jobcode = canjob.Jobcode where Cand_Status in ('105') and can.Created_By='" + TWE_id + "' and can.Created_On between '" + fromdate + "' and '" + todate + "') tb2,(" +
                        " select count(*) TLApproved from CandidateDetails can join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                        " join Job_Master_USA job on job.Jobcode = canjob.Jobcode where Cand_Status in ('105','106','107','108') and can.Created_By='" + TWE_id + "' and can.Created_On between '" + fromdate + "' and '" + todate + "') tb3,(" +

                        " select count(*) SubmittedTL from CandidateDetails can join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                        " join Job_Master_USA job on job.Jobcode = canjob.Jobcode where Cand_Status in ('103') and can.Created_By='" + TWE_id + "' and can.Created_On between '" + fromdate + "' and '" + todate + "') tb4,(" +

                        " select count(*) Vendors from EmployerDetails where Status='1' and Created_By like '" + TWE_id + "' and Created_On between '" + fromdate + "' and '" + todate + "') tb5,(" +

                        " select count(*) SubmitCand from CandidateDetails can join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                        " join Job_Master_USA job on job.Jobcode = canjob.Jobcode where Cand_Status in ('101','102','103') and can.Created_By='" + TWE_id + "'and can.Created_On between '" + fromdate + "' and '" + todate + "') tb6";


            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                targetfixingMstr _tfm = new targetfixingMstr();
                _tfm.TargetfixingId = _read[0].ToString();
                _tfm.RoleType = _read[1].ToString();
                _tfm.LevelType = _read[2].ToString();
                _tfm.RegionType = _read[3].ToString();
                _tfm.SubmissiontoTL_Daily = _read[4].ToString();
                _tfm.Submission_Daily = _read[5].ToString();
                _tfm.SubmissiontoBP_Daily = _read[6].ToString();
                _tfm.Closure_Daily = _read[7].ToString();
                _tfm.Vendor_Daily = _read[8].ToString();
                _tfm.Submission_Monthly = _read[9].ToString();
                _tfm.SubmissiontoTL_Monthly = _read[10].ToString();
                _tfm.SubmissiontoBP_Monthly = _read[11].ToString();
                _tfm.Closure_Monthly = _read[12].ToString();
                _tfm.Vendor_Monthly = _read[13].ToString();
                _tfm.Submission_Weekly = _read[14].ToString();
                _tfm.SubmissiontoTL_Weekly = _read[15].ToString();
                _tfm.SubmissiontoBP_Weekly = _read[16].ToString();
                _tfm.Closure_Weekly = _read[17].ToString();
                _tfm.Vendor_Weekly = _read[18].ToString();
                _rd.lstTarget.Add(_tfm);

            }
            _read.Close();

            strquery = @"SELECT [firstname]
                      ,[lastname],[Candidate_adding] * "+days+" Candidate_adding"+
                      ",[Vendor_creation] * "+days+ " Vendor_creation,[Submittion] * " + days + " Submittion" +
                      ",[TLApproval] * " + days + " TLApproval,[BPApproval] * " + days + "BPApproval" +
                                ",[ECApproval]* " + days + " ECApproval FROM [Userprofilecreation] where [TWE_ID]='" + TWE_id + "'";

            _read = _sql.doRead(strquery);
            while (_read.Read())
            {
                targetfixingMstr _tfm = new targetfixingMstr();
                _tfm.TargetfixingId = _read[0].ToString();
                _tfm.RoleType = _read[1].ToString();
                _tfm.LevelType = _read[2].ToString();
                _tfm.RegionType = _read[3].ToString();
                _tfm.SubmissiontoTL_Daily = _read[4].ToString();
                _tfm.Submission_Daily = _read[5].ToString();
                _tfm.SubmissiontoBP_Daily = _read[6].ToString();
                _tfm.Closure_Daily = _read[7].ToString();
                _tfm.Vendor_Daily = _read[8].ToString();
                _tfm.Submission_Monthly = _read[9].ToString();
                _tfm.SubmissiontoTL_Monthly = _read[10].ToString();
                _tfm.SubmissiontoBP_Monthly = _read[11].ToString();
                _tfm.Closure_Monthly = _read[12].ToString();
                _tfm.Vendor_Monthly = _read[13].ToString();
                _tfm.Submission_Weekly = _read[14].ToString();
                _tfm.SubmissiontoTL_Weekly = _read[15].ToString();
                _tfm.SubmissiontoBP_Weekly = _read[16].ToString();
                _tfm.Closure_Weekly = _read[17].ToString();
                _tfm.Vendor_Weekly = _read[18].ToString();
                _rd.lstTarget.Add(_tfm);

            }
            _read.Close();


            JobMaster _db = new JobMaster();
            _db.lstJob = new List<JobcodeList>();

            strquery = @"select * from(select distinct job.Jobcode,JobTitle,Duration,empl.EmpTypeName,loc.LocationName,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage,Assigned_To,job.Created_On as Datecreated from Job_Master_USA job
                                join Location_Master loc on job.Location=loc.LocationID
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientContactID=job.Contactname
                                join CandidateJob canjob on canjob.Jobcode=job.Jobcode
								join CandidateDetails cand on cand.candidateid=canjob.CandidateId
                                where Assigned_To like '%" + TWE_id + "%' and canjob.Created_On between '" + fromdate + "' and '" + todate + "'" + ") tb1 order by Datecreated desc";

            _read = _sql.doRead(strquery);
            while (_read.Read())
            {
                JobcodeList objJob = new JobcodeList();

                objJob.Jobcode = _read[0].ToString();
                objJob.JobTitle = _read[1].ToString();
                objJob.JobDuration = _read[2].ToString();
                objJob.JobType = _read[3].ToString();
                objJob.JobState = _read[4].ToString();
                objJob.JobStatus = _read[5].ToString();
                objJob.JobClient = _read[6].ToString();
                objJob.JobContact = _read[7].ToString();
                objJob.CreatedOn = _read[8].ToString();
                objJob.JobMediaPath = _read[9].ToString();
                objJob.Assigned_To = _read[10].ToString();
                _rd.lstJob.Add(objJob);

            }

            _read.Close();

            _rd.lstRemarks = new List<dropDownTemplate>();

            strquery = @"SELECT [RemarksID],[RemarksName] FROM [Remarks_Master] where Status=1";

            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                _rd.lstRemarks.Add(new dropDownTemplate
                {
                    ID = _read["RemarksID"].ToString(),
                    Name = _read["RemarksName"].ToString()
                });
            }

            _read.Close();

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
                _json.data = _rd;
            }

            return _json;

        }

        public jsonArray getRolemenu(string RoleId)
        {
            int status = 1;
            RoleMenu _role = new RoleMenu();

            string strquery = @"SELECT [jobaccess]
                              ,[jobCreation]
                              ,[jobEdit]
                              ,[jobView]
                              ,[jobFeedback]
                              ,[candidateAccess]
                              ,[candidateCreation]
                              ,[candidateView]
                              ,[candidateEdit]
                              ,[vendorAccess]
                              ,[vendorCreation]
                              ,[vendorEdit]
                              ,[vendorView]
                              --,[reportAccess]
                              --,[Status]
                             FROM [MenuAccessPermission] where [roleId]='" + RoleId + "'";

            SqlDataReader _read = _sql.doRead(strquery);
            while (_read.Read())
            {
                _role.jobAccess = _read[0].ToString();
                _role.jobCreation = _read[1].ToString();
                _role.jobEdit = _read[2].ToString();
                _role.jobView = _read[3].ToString();
                _role.jobFeedback = _read[4].ToString();
                _role.candidateAccess = _read[5].ToString();
                _role.candidateCreation = _read[6].ToString();
                _role.candidateView = _read[7].ToString();
                _role.candidateEdit = _read[8].ToString();
                _role.vendorAccess = _read[9].ToString();
                _role.vendorCreation = _read[10].ToString();
                _role.vendorEdit = _read[11].ToString();
                _role.vendorView = _read[12].ToString();
                //_role.reportAccess = _read[13].ToString();
                //_role.Status = _read[14].ToString();

            }
            _read.Close();

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
                _json.data = _role;
            }


            return _json;
        }
       
        public jsonArray getRecruiterdetailsUSA(string TWE_Id, string fromdate, string todate, string filter)
        {
            int status = 1;
            string query = "";

            candidateOverview objCand = new candidateOverview();
            objCand._lstcandilist = new List<candidatelist>();



            if (filter == "Submission")
            {
                query = @"select can.candidateid,candidatename,candidateemailid,candidatemobileno,ratePerHr,
                        sta.CandidateStatusName Cand_Status,linkedinURL,job.Jobcode,job.JobTitle
                        from CandidateDetails can
                        left join EmployerDetails emp on can.employerid=emp.employerid
                        join CandidateJob canjob on can.candidateid=canjob.CandidateId
                        join CandidateStatus_Master sta on sta.CandidateStatusID=canjob.Cand_Status
                        join Userprofile up on can.Created_By=up.TWE_ID
                        left join Job_Master_USA job on job.Jobcode=canjob.Jobcode
                        where can.Created_By like '%" + TWE_Id + "%' and " +
                        "can.Created_On between '" + fromdate + "' and '" + todate + "' ";
            }


            else if (filter == "TL Submission")
            {
                query = @"select can.candidateid,candidatename,candidateemailid,candidatemobileno,ratePerHr,
                        sta.CandidateStatusName Cand_Status,linkedinURL,job.Jobcode,job.JobTitle
                        from CandidateDetails can
                        left join EmployerDetails emp on can.employerid=emp.employerid
                        join CandidateJob canjob on can.candidateid=canjob.CandidateId
                        join CandidateStatus_Master sta on sta.CandidateStatusID=canjob.Cand_Status
                        join Userprofile up on can.Created_By=up.TWE_ID
                        join Job_Master_USA job on job.Jobcode=canjob.Jobcode
                        where can.Created_By like '%" + TWE_Id + "%' and " +
                        "can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                        " and Cand_Status >= 103";
            }

            else if (filter == "BP Submission")
            {
                query = @"select can.candidateid,candidatename,candidateemailid,candidatemobileno,ratePerHr,
                        sta.CandidateStatusName Cand_Status,
                        linkedinURL,job.Jobcode,job.JobTitle
                        from CandidateDetails can
                        left join EmployerDetails emp on can.employerid=emp.employerid
                        join CandidateJob canjob on can.candidateid=canjob.CandidateId
                        join CandidateStatus_Master sta on sta.CandidateStatusID=canjob.Cand_Status
                        join Userprofile up on can.Created_By=up.TWE_ID
                        join Job_Master_USA job on job.Jobcode=canjob.Jobcode
                        where can.Created_By like '%" + TWE_Id + "%' and " +
                        "can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                        " and Cand_Status > 103 and Cand_Status!= 104";
            }

            else if (filter == "EC Submission")
            {
                query = @"select can.candidateid,candidatename,candidateemailid,candidatemobileno,ratePerHr,
                        sta.CandidateStatusName Cand_Status,linkedinURL,job.Jobcode,job.JobTitle
                        from CandidateDetails can
                        left join EmployerDetails emp on can.employerid=emp.employerid
                         join CandidateJob canjob on can.candidateid=canjob.CandidateId
                        join CandidateStatus_Master sta on sta.CandidateStatusID=canjob.Cand_Status
                        join Userprofile up on can.Created_By=up.TWE_ID
                        join Job_Master_USA job on job.Jobcode=canjob.Jobcode
                        where can.Created_By like '%" + TWE_Id + "%' and " +
                        "can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                        " and Cand_Status > 103 and Cand_Status!= 104 and Cand_Status!= 106";
            }


            else if (filter == "Closures")

            {
                query = @"select can.candidateid,candidatename,candidateemailid,candidatemobileno,ratePerHr,
                        CandidateStatusName Cand_Status,linkedinURL
                        ,jobTitle,job.jobcode
                        from CandidateDetails can
                        join CandidateJob canjob on can.candidateid=canjob.CandidateId
                        join CandidateStatus_Master sta on sta.CandidateStatusID=canjob.Cand_Status
                        left join EmployerDetails emp on can.employerid=emp.employerid
                        join Job_Master_USA job on canjob.Jobcode=job.Jobcode 
                        join Userprofile up on can.Created_By=up.TWE_ID
                        where canjob.Created_By='" + TWE_Id + "' and Cand_Status in ('109')" +
                        " and canjob.Created_On between '" + fromdate + "' and '" + todate + "'";
            }

            SqlDataReader _read = _sql.doRead(query);

            while (_read.Read())
            {
                candidatelist candilst = new candidatelist();
                candilst.candidateid = _read[0].ToString();
                candilst.candidatemediapath = "";
                candilst.candidatename = _read[1].ToString();
                candilst.candidateemailid = _read[2].ToString();
                candilst.candidatemobno = _read[3].ToString();
                candilst.ratePerHr = _read[4].ToString();
                candilst.candidatestatus = _read[5].ToString();
                candilst.linkedinURL = _read[6].ToString();
                candilst.jobTitle = _read[8].ToString();
                candilst.jobcode = _read[7].ToString();
                objCand._lstcandilist.Add(candilst);
            }


            _read.Close();

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
                _json.data = objCand;
            }

            return _json;
        }


        public jsonArray getRecruiterJobdetailsIndia(string TWE_Id, string fromdate, string todate)
        {
            int status = 1;
            string strquery = "";

            Recrutingdashboard _rd = new Recrutingdashboard();

            _rd.lstJob = new List<JobcodeList>();


            strquery = strquery = @"select * from(select distinct job.Jobcode,JobTitle,Duration,empl.EmpTypeName,loc.LocationName,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage,Assigned_To,job.Created_On as Datecreated from Job_Master_IND job
                                join Location_Master loc on job.Location=loc.LocationID
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientContactID=job.Contactname
                                join CandidateJobIndia canjob on canjob.Jobcode=job.Jobcode
								join CandidateDetailsIndia cand on cand.candidateid=canjob.CandidateId
                                where canjob.Created_by like '%" + TWE_Id + "%' and canjob.Created_On between '" + fromdate + "' and '" + todate + "'" + ") tb1 order by Datecreated desc";

            SqlDataReader _read = _sql.doRead(strquery);
            while (_read.Read())
            {
                    JobcodeList objJob = new JobcodeList();

                    objJob.Jobcode = _read[0].ToString();
                    objJob.JobTitle = _read[1].ToString();
                    objJob.JobDuration = _read[2].ToString();
                    objJob.JobType = _read[3].ToString();
                    objJob.JobState = _read[4].ToString();
                    objJob.JobStatus = _read[5].ToString();
                    objJob.JobClient = _read[6].ToString();
                    objJob.JobContact = _read[7].ToString();
                    objJob.CreatedOn = _read[8].ToString();
                    objJob.JobMediaPath = _read[9].ToString();
                    objJob.Assigned_To = _read[10].ToString();

                    _rd.lstJob.Add(objJob);               


            }


            _read.Close();

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
                _json.data = _rd;
            }

            return _json;

        }

        public jsonArray getRecruiterJobdetailsUSA(string TWE_Id, string fromdate, string todate)
        {
            int status = 1;
            string strquery = "";

            Recrutingdashboard _rd = new Recrutingdashboard();
            _rd.lstJob = new List<JobcodeList>();


            strquery = @"select * from(select distinct job.Jobcode,JobTitle,Duration,empl.EmpTypeName,loc.LocationName,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage,Assigned_To,job.Created_On as Datecreated from Job_Master_USA job
                                join Location_Master loc on job.Location=loc.LocationID
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientContactID=job.Contactname
                                join CandidateJob canjob on canjob.Jobcode=job.Jobcode
								join CandidateDetails cand on cand.candidateid=canjob.CandidateId
                                where Assigned_To like '%" + TWE_Id + "%' and canjob.Created_On between '" + fromdate + "' and '" + todate + "'" + ") tb1 order by Datecreated desc";

            SqlDataReader _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                JobcodeList objJob = new JobcodeList();

                objJob.Jobcode = _read[0].ToString();
                objJob.JobTitle = _read[1].ToString();
                objJob.JobDuration = _read[2].ToString();
                objJob.JobType = _read[3].ToString();
                objJob.JobState = _read[4].ToString();
                objJob.JobStatus = _read[5].ToString();
                objJob.JobClient = _read[6].ToString();
                objJob.JobContact = _read[7].ToString();
                objJob.CreatedOn = _read[8].ToString();
                objJob.JobMediaPath = _read[9].ToString();
                objJob.Assigned_To = _read[10].ToString();
                _rd.lstJob.Add(objJob);
            }


            _read.Close();

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
                _json.data = _rd;
            }

            return _json;

        }


        public jsonArray getRecruiterdetails(string TWE_Id, string fromdate, string todate, string tiletype)
        {
            int status = 1;
            string strquery = "";

            candidateOverview objCand = new candidateOverview();
            objCand._lstcandilist = new List<candidatelist>();



            if (tiletype == "Interview")
            {

                strquery = @"select can.candidateid,candidatename,candidateemailid,candidatemobileno,ratePerHr,
                        employername,employeremailid,CandidateStatusName Cand_Status,
                        up.UP_firstName+' '+up.UP_lastName Empname,
                        convert(varchar,can.Created_On,106) CreatedOn,CreatedTime
                        from CandidateDetailsIndia can
                        join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId
                        join CandidateStatus_Master sta on sta.CandidateStatusID=canjob.Cand_Status
                        left join EmployerDetailsIndia emp on can.employerid=emp.employerid
                        join Userprofile up on can.Created_By=up.TWE_ID
                        where can.Created_By like '%" + TWE_Id + "%' and " +
                        //" and can.Created_On between '" + fromdate + "' and '" + todate +  "'"
                        " Cand_Status in ('110','111') ";
            }


            else if (tiletype == "Candidates")
            {
                strquery = @"select can.candidateid,candidatename,candidateemailid,candidatemobileno,ratePerHr,
                        employername,employeremailid,CandidateStatusName Cand_Status,
                        up.UP_firstName+' '+up.UP_lastName Empname,
                        convert(varchar,can.Created_On,106) CreatedOn,CreatedTime
                        from CandidateDetailsIndia can
                        join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId
                        join CandidateStatus_Master sta on sta.CandidateStatusID=canjob.Cand_Status
                        left join EmployerDetailsIndia emp on can.employerid=emp.employerid
                        join Userprofile up on can.Created_By=up.TWE_ID
                        where can.Created_By like '%" + TWE_Id + "%' ";
                //"and can.Created_On between '" + fromdate + "' and '" + todate + "' ";
            }

            else if (tiletype == "Closures")

            {
                strquery = @"select can.candidateid,candidatename,candidateemailid,candidatemobileno,ratePerHr,
                        employername,employeremailid,CandidateStatusName Cand_Status,
                        up.UP_firstName+' '+up.UP_lastName Empname,
                        convert(varchar,can.Created_On,106) CreatedOn,CreatedTime
                        from CandidateDetailsIndia can
                        join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId
                        join CandidateStatus_Master sta on sta.CandidateStatusID=canjob.Cand_Status
                        left join EmployerDetailsIndia emp on can.employerid=emp.employerid
                        join Userprofile up on can.Created_By=up.TWE_ID
                        where can.Created_By like '%" + TWE_Id + "%' and Cand_Status in ('109')";
                //" and can.Created_On between '" + fromdate + "' and '" + todate + "'  and Cand_Status in ('109') ";
            }

            SqlDataReader _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                candidatelist candilst = new candidatelist();
                candilst.candidateid = _read[0].ToString();
                candilst.candidatemediapath = "";
                candilst.candidatename = _read[1].ToString();
                candilst.candidateemailid = _read[2].ToString();
                candilst.candidatemobno = _read[3].ToString();
                candilst.ratePerHr = _read[4].ToString();
                candilst.vendorname = _read[5].ToString();
                candilst.vendoremailid = _read[6].ToString();
                candilst.candidatestatus = _read[7].ToString();
                candilst.submittedby = _read[8].ToString();
                candilst.submitteddate = _read[9].ToString();
                candilst.submittedtime = _read[10].ToString();
                objCand._lstcandilist.Add(candilst);
            }


            _read.Close();

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
                _json.data = objCand;
            }

            return _json;
        }


        public jsonArray getRecruiterJobdetails(string TWE_Id)
        {
            int status = 1;
            string strquery = "";

            Recrutingdashboard _rd = new Recrutingdashboard();

            JobMaster _db = new JobMaster();
            _db.lstJob = new List<JobcodeList>();

            SqlDataReader _read = _sql.doRead(strquery);

            strquery = @"select * from(select distinct Jobcode,JobTitle,Duration,empl.EmpTypeName,loc.LocationName,
                                stat.JobstatusName,cli.ClientCompanyName,con.ContactPerson,
                                convert(varchar,job.Created_On,106) Created_On,Jobimage,Assigned_To,job.Created_On as Datecreated from Job_Master_IND job
                                join Location_Master loc on job.Location=loc.LocationID
                                join EmploymentType_Master empl on empl.EmpTypeID=job.EmplType
                                join Jobstatus_Master stat on stat.JobstatusID=job.Jobstatus
                                join ClientMaster cli on cli.ClientID=job.Clientname
                                join Client_Contact_Person con on con.ClientContactID=job.Contactname
                                where Assigned_To like '%" + TWE_Id + "%') tb1 order by Datecreated desc";

            _read = _sql.doRead(strquery);
            while (_read.Read())
            {
                JobcodeList objJob = new JobcodeList();

                objJob.Jobcode = _read[0].ToString();
                objJob.JobTitle = _read[1].ToString();
                objJob.JobDuration = _read[2].ToString();
                objJob.JobType = _read[3].ToString();
                objJob.JobState = _read[4].ToString();
                objJob.JobStatus = _read[5].ToString();
                objJob.JobClient = _read[6].ToString();
                objJob.JobContact = _read[7].ToString();
                objJob.CreatedOn = _read[8].ToString();
                objJob.JobMediaPath = _read[9].ToString();
                objJob.Assigned_To = _read[10].ToString();
                _rd.lstJob.Add(objJob);

            }


            _read.Close();

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
                _json.data = _db;
            }

            return _json;

        }


        public jsonArray getTeammemberTargetdetailsIndia(string TWE_id, string Weekinfo,string fromdate,string todate,string strtype,string prevfromdate,string prevtodate,string tblName)
        {
            Recrutingdashboard _rd = new Recrutingdashboard();
            int status = 1;
            string strquery = "";
            //int isExists = 0;
            string str = "";

            _rd.lstRemarks = new List<dropDownTemplate>();
            _rd.lstTarget = new List<targetfixingMstr>();
            _rd.lstprevTarget = new List<targetfixingMstr>();
            
            strquery = @"SELECT [RemarksID],[RemarksName] FROM [Remarks_Master] where Status=1";

            SqlDataReader _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                _rd.lstRemarks.Add(new dropDownTemplate
                {
                    ID = _read["RemarksID"].ToString(),
                    Name = _read["RemarksName"].ToString()
                });
            }

            _read.Close();

            _rd.Feedback = new TeamPerfomanceFeedback();
            strquery = @"SELECT [firstname]+' '+[lastname] FROM [Userprofilecreation] where [TWE_ID]='" + TWE_id + "'";

            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                _rd.Feedback.TWEID = _read[0].ToString();
            }

            _read.Close();

            if (tblName=="Weekly")
            {
                strquery = @"select Teamperfomanceid,[OverAllRating]" +
                            ",[Remarks],Weekinfo from TeamPerfomanceIndia_Weekly where Weekinfo='" + Weekinfo + "' and TWEID='" + TWE_id + "'";
                _read = _sql.doRead(strquery);
                while (_read.Read())
                {

                    _rd.Feedback.Teamperfomanceid = _read[0].ToString();
                    _rd.Feedback.OverallRating = _read[1].ToString();
                    _rd.Feedback.Remarks = _read[2].ToString();
                    _rd.Feedback.Weekinfo = _read[3].ToString();
                }

                _read.Close();

            }
            else if (tblName == "Monthly")
            {
                strquery = @"select Teamperfomanceid,[OverAllRating]" +
                            ",[Remarks],Monthinfo from TeamPerfomanceIndia_Monthly where Monthinfo='" + Weekinfo + "' and TWEID='" + TWE_id + "'";
                _read = _sql.doRead(strquery);
                while (_read.Read())
                {

                    _rd.Feedback.Teamperfomanceid = _read[0].ToString();
                    _rd.Feedback.OverallRating = _read[1].ToString();
                    _rd.Feedback.Remarks = _read[2].ToString();
                    _rd.Feedback.Weekinfo = _read[3].ToString();
                }

                _read.Close();
            }

            DateTime startDate = Convert.ToDateTime(prevfromdate);
            DateTime endDate = Convert.ToDateTime(prevtodate);
            int days = 0;

            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                if (startDate.DayOfWeek != DayOfWeek.Saturday && startDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    days++;
                }
                startDate = startDate.AddDays(1);
            }

            List<targetfixingMstr> lstPrevTarget= getTarget(TWE_id, prevfromdate, prevtodate, strtype);

            
            var prevsubmissionper = (Convert.ToDecimal(lstPrevTarget[0].Submission_Daily) / Convert.ToDecimal(lstPrevTarget[1].Submission_Daily)) * 100;
            var prevsubmissionTLper = (Convert.ToDecimal(lstPrevTarget[0].SubmissiontoTL_Daily) / Convert.ToDecimal(lstPrevTarget[1].SubmissiontoTL_Daily)) * 100;
            var prevsubmissionBPper = (Convert.ToDecimal(lstPrevTarget[0].SubmissiontoBP_Daily) / Convert.ToDecimal(lstPrevTarget[1].SubmissiontoBP_Daily)) * 100;

            _rd.lstprevTarget = lstPrevTarget;
            if (prevsubmissionper > 100)
            {
                _rd.lstprevTarget[0].SBPercentage = "100";

            }
            else
            {
                _rd.lstprevTarget[0].SBPercentage = prevsubmissionper.ToString();
            }
            if (prevsubmissionTLper > 100)
            {
                _rd.lstprevTarget[0].TLPercentage = "100";
            }
            else
            {
                _rd.lstprevTarget[0].TLPercentage = prevsubmissionTLper.ToString();
            }

            if (prevsubmissionBPper > 100)
            {
                _rd.lstprevTarget[0].BPPercentage = "100";
            }
            else {
                _rd.lstprevTarget[0].BPPercentage = prevsubmissionBPper.ToString();
            }
           

            if (tblName == "Monthly")
            {
                if (Convert.ToInt32(lstPrevTarget[1].Closure_Daily)!=0)
                {
                    _rd.lstprevTarget[0].CLPercentage = ((Convert.ToDecimal(lstPrevTarget[0].Closure_Daily) / Convert.ToDecimal(lstPrevTarget[1].Closure_Daily)) * 100).ToString();
                    if (Convert.ToInt32(_rd.lstprevTarget[0].CLPercentage) > 100)
                    {
                        _rd.lstprevTarget[0].CLPercentage = "100";
                    }
                    else
                    {
                        _rd.lstprevTarget[0].CLPercentage = ((Convert.ToDecimal(lstPrevTarget[0].Closure_Daily) / Convert.ToDecimal(lstPrevTarget[1].Closure_Daily)) * 100).ToString();
                    }
                }
                else
                {
                    _rd.lstprevTarget[0].CLPercentage = "0";
                }
                
                str = "<canvas id = 'chart-consumptionprev' class='chart-canvas' height='246' width='275' style='display: block; box-sizing: border-box; height: 197px; width: 220.6px;'></canvas> <script>" +

            "var ctx1 = document.getElementById('chart-consumptionprev').getContext('2d');" +
            "var gradientStroke1 = ctx1.createLinearGradient(0, 230, 0, 50);" +
            "gradientStroke1.addColorStop(1, 'rgba(203,12,159,0.2)');" +
            "gradientStroke1.addColorStop(0.2, 'rgba(72,72,176,0.0)');" +
            "gradientStroke1.addColorStop(0, 'rgba(203,12,159,0)');" +
            "new Chart(ctx1, {" +
            "type: 'doughnut'," +
            "data:" +
            "{" +
            "labels: ['Submission', 'Submission to TL', 'Submission to BP','Closures']," +
            "datasets: [{" +
            "label: 'Performance'," +
            "weight: 9," +
            "cutout: 90," +
            "tension: 0.9," +
            "pointRadius: 2," +
            "borderWidth: 2," +
            "backgroundColor:  ['#2ed9fb', '#8092b1', '#f99336','#56cc32']," +
            "data: [" + prevsubmissionper + ", " + prevsubmissionTLper + ", " + prevsubmissionBPper + ", " + _rd.lstprevTarget[0].CLPercentage + "]," +
            "fill: false" +
            "}]," +
            "}," +
            "options:" +
            "{" +
            "responsive: true," +
            "cutoutPercentage: 93," +
            "maintainAspectRatio: false," +
            "legend:" +
            "{" +
            "display: false" +
            "}," +
            "plugins:" +
            "{" +
            "legend:" +
            "{" +
            "display: false," +
            "}" +
            "}," +
            "interaction:" +
            "{" +
            "intersect: false," +
            "mode: 'index'," +
            "}," +
            "scales:" +
            "{" +
            "y:" +
            "{" +
            "grid:" +
            "{" +
            "drawBorder: false," +
            "display: false," +
            "drawOnChartArea: false," +
            "drawTicks: false," +
            "}," +
            "ticks:" +
            "{" +
            "display: false" +
            "}" +
            "}," +
            "x:" +
            "{" +
            "grid:" +
            "{" +
            "drawBorder: false," +
            "display: false," +
            "drawOnChartArea: false," +
            "drawTicks: false," +
            "}," +
            "ticks:" +
            "{" +
            "display: false," +
            "}" +
            "}," +
            "}," +
            "}," +
            "});" +
            "</script>";


            }
            else
            {
                str = "<canvas id = 'chart-consumptionprev' class='chart-canvas' height='246' width='275' style='display: block; box-sizing: border-box; height: 197px; width: 220.6px;'></canvas> <script>" +

            "var ctx1 = document.getElementById('chart-consumptionprev').getContext('2d');" +
            "var gradientStroke1 = ctx1.createLinearGradient(0, 230, 0, 50);" +
            "gradientStroke1.addColorStop(1, 'rgba(203,12,159,0.2)');" +
            "gradientStroke1.addColorStop(0.2, 'rgba(72,72,176,0.0)');" +
            "gradientStroke1.addColorStop(0, 'rgba(203,12,159,0)');" +
            "new Chart(ctx1, {" +
            "type: 'doughnut'," +
            "data:" +
            "{" +
            "labels: ['Submission', 'Submission to TL', 'Submission to BP']," +
            "datasets: [{" +
            "label: 'Performance'," +
            "weight: 9," +
            "cutout: 90," +
            "tension: 0.9," +
            "pointRadius: 2," +
            "borderWidth: 2," +
            "backgroundColor:  ['#2ed9fb', '#8092b1', '#f99336']," +
            "data: [" + prevsubmissionper + ", " + prevsubmissionTLper + ", " + prevsubmissionBPper + "]," +
            "fill: false" +
            "}]," +
            "}," +
            "options:" +
            "{" +
            "responsive: true," +
            "cutoutPercentage: 93," +
            "maintainAspectRatio: false," +
            "legend:" +
            "{" +
            "display: false" +
            "}," +
            "plugins:" +
            "{" +
            "legend:" +
            "{" +
            "display: false," +
            "}" +
            "}," +
            "interaction:" +
            "{" +
            "intersect: false," +
            "mode: 'index'," +
            "}," +
            "scales:" +
            "{" +
            "y:" +
            "{" +
            "grid:" +
            "{" +
            "drawBorder: false," +
            "display: false," +
            "drawOnChartArea: false," +
            "drawTicks: false," +
            "}," +
            "ticks:" +
            "{" +
            "display: false" +
            "}" +
            "}," +
            "x:" +
            "{" +
            "grid:" +
            "{" +
            "drawBorder: false," +
            "display: false," +
            "drawOnChartArea: false," +
            "drawTicks: false," +
            "}," +
            "ticks:" +
            "{" +
            "display: false," +
            "}" +
            "}," +
            "}," +
            "}," +
            "});" +
            "</script>";
            }


            _rd.Linechart = str;

            List<targetfixingMstr> lstCurrTarget = getTarget(TWE_id, fromdate, todate, strtype);
            decimal submissionper;
            decimal submissionTLper;
            decimal submissionBPper;

            if (Convert.ToInt32(lstCurrTarget[1].Submission_Daily) != 0)
            {
                 submissionper = (Convert.ToDecimal(lstCurrTarget[0].Submission_Daily) / Convert.ToDecimal(lstCurrTarget[1].Submission_Daily)) * 100;

            }
            else
            {
                submissionper = 0;
            }

            if (Convert.ToInt32(lstCurrTarget[1].SubmissiontoTL_Daily) != 0)
            {
                submissionTLper = (Convert.ToDecimal(lstCurrTarget[0].SubmissiontoTL_Daily) / Convert.ToDecimal(lstCurrTarget[1].SubmissiontoTL_Daily)) * 100;
            }
            else
            {
                submissionTLper = 0;
            }

            if (Convert.ToInt32(lstCurrTarget[1].SubmissiontoBP_Daily) != 0)
            {
                submissionBPper = (Convert.ToDecimal(lstCurrTarget[0].SubmissiontoBP_Daily) / Convert.ToDecimal(lstCurrTarget[1].SubmissiontoBP_Daily)) * 100;
            }
            else
            {
                submissionBPper = 0;
            }

            _rd.lstTarget = lstCurrTarget;

            if (submissionper > 100)
            {
                _rd.lstTarget[0].SBPercentage = "100";

            }
            else
            {
                _rd.lstTarget[0].SBPercentage = submissionper.ToString();
            }
            if (submissionTLper > 100)
            {
                _rd.lstTarget[0].TLPercentage = "100";
            }
            else
            {
                _rd.lstTarget[0].TLPercentage = submissionTLper.ToString();
            }

            if (submissionBPper > 100)
            {
                _rd.lstTarget[0].BPPercentage = "100";
            }
            else
            {
                _rd.lstTarget[0].BPPercentage = submissionBPper.ToString();
            }
            

            if (tblName == "Monthly")
            {
                if (Convert.ToInt32(lstCurrTarget[1].Closure_Daily)!=0)
                {
                    _rd.lstTarget[0].CLPercentage = ((Convert.ToDecimal(lstCurrTarget[0].Closure_Daily) / Convert.ToDecimal(lstCurrTarget[1].Closure_Daily)) * 100).ToString();

                    if (Convert.ToInt32(_rd.lstTarget[0].CLPercentage) > 100)
                    {
                        _rd.lstTarget[0].CLPercentage = "100";
                    }
                    else
                    {
                        _rd.lstTarget[0].CLPercentage = ((Convert.ToDecimal(lstCurrTarget[0].Closure_Daily) / Convert.ToDecimal(lstCurrTarget[1].Closure_Daily)) * 100).ToString();
                    }
                }
                else
                {
                    _rd.lstTarget[0].CLPercentage = "0";
                }
               
                str = "<canvas id = 'chart-consumption' class='chart-canvas' height='246' width='275' style='display: block; box-sizing: border-box; height: 197px; width: 220.6px;'></canvas> <script>" +

            "var ctx1 = document.getElementById('chart-consumption').getContext('2d');" +
            "var gradientStroke1 = ctx1.createLinearGradient(0, 230, 0, 50);" +
            "gradientStroke1.addColorStop(1, 'rgba(203,12,159,0.2)');" +
            "gradientStroke1.addColorStop(0.2, 'rgba(72,72,176,0.0)');" +
            "gradientStroke1.addColorStop(0, 'rgba(203,12,159,0)');" +
            "new Chart(ctx1, {" +
            "type: 'doughnut'," +
            "data:" +
            "{" +
            "labels: ['Submission', 'Submission to TL', 'Submission to BP','Closure']," +
            "datasets: [{" +
            "label: 'Performance'," +
            "weight: 9," +
            "cutout: 90," +
            "tension: 0.9," +
            "pointRadius: 2," +
            "borderWidth: 2," +
            "backgroundColor:  ['#2ed9fb', '#8092b1', '#f99336','#56cc32']," +
           "data: [" + submissionper + ", " + submissionTLper + ", " + submissionBPper + ", " + _rd.lstTarget[0].CLPercentage + "]," +
            "fill: false" +
            "}]," +
            "}," +
            "options:" +
            "{" +
            "responsive: true," +
            "cutoutPercentage: 93," +
            "maintainAspectRatio: false," +
            "legend:" +
            "{" +
            "display: false" +
            "}," +
            "plugins:" +
            "{" +
            "legend:" +
            "{" +
            "display: false," +
            "}" +
            "}," +
            "interaction:" +
            "{" +
            "intersect: false," +
            "mode: 'index'," +
            "}," +
            "scales:" +
            "{" +
            "y:" +
            "{" +
            "grid:" +
            "{" +
            "drawBorder: false," +
            "display: false," +
            "drawOnChartArea: false," +
            "drawTicks: false," +
            "}," +
            "ticks:" +
            "{" +
            "display: false" +
            "}" +
            "}," +
            "x:" +
            "{" +
            "grid:" +
            "{" +
            "drawBorder: false," +
            "display: false," +
            "drawOnChartArea: false," +
            "drawTicks: false," +
            "}," +
            "ticks:" +
            "{" +
            "display: false," +
            "}" +
            "}," +
            "}," +
            "}," +
            "});" +
            "</script>";
            }
            else
            {
                str = "<canvas id = 'chart-consumption' class='chart-canvas' height='246' width='275' style='display: block; box-sizing: border-box; height: 197px; width: 220.6px;'></canvas> <script>" +

            "var ctx1 = document.getElementById('chart-consumption').getContext('2d');" +
            "var gradientStroke1 = ctx1.createLinearGradient(0, 230, 0, 50);" +
            "gradientStroke1.addColorStop(1, 'rgba(203,12,159,0.2)');" +
            "gradientStroke1.addColorStop(0.2, 'rgba(72,72,176,0.0)');" +
            "gradientStroke1.addColorStop(0, 'rgba(203,12,159,0)');" +
            "new Chart(ctx1, {" +
            "type: 'doughnut'," +
            "data:" +
            "{" +
            "labels: ['Submission', 'Submission to TL', 'Submission to BP']," +
            "datasets: [{" +
            "label: 'Performance'," +
            "weight: 9," +
            "cutout: 90," +
            "tension: 0.9," +
            "pointRadius: 2," +
            "borderWidth: 2," +
            "backgroundColor:  ['#2ed9fb', '#8092b1', '#f99336']," +
           "data: [" + submissionper + ", " + submissionTLper + ", " + submissionBPper + "]," +
            "fill: false" +
            "}]," +
            "}," +
            "options:" +
            "{" +
            "responsive: true," +
            "cutoutPercentage: 93," +
            "maintainAspectRatio: false," +
            "legend:" +
            "{" +
            "display: false" +
            "}," +
            "plugins:" +
            "{" +
            "legend:" +
            "{" +
            "display: false," +
            "}" +
            "}," +
            "interaction:" +
            "{" +
            "intersect: false," +
            "mode: 'index'," +
            "}," +
            "scales:" +
            "{" +
            "y:" +
            "{" +
            "grid:" +
            "{" +
            "drawBorder: false," +
            "display: false," +
            "drawOnChartArea: false," +
            "drawTicks: false," +
            "}," +
            "ticks:" +
            "{" +
            "display: false" +
            "}" +
            "}," +
            "x:" +
            "{" +
            "grid:" +
            "{" +
            "drawBorder: false," +
            "display: false," +
            "drawOnChartArea: false," +
            "drawTicks: false," +
            "}," +
            "ticks:" +
            "{" +
            "display: false," +
            "}" +
            "}," +
            "}," +
            "}," +
            "});" +
            "</script>";
            }


            

            _rd.Barchart = str;         
            

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
                _json.data = _rd;
            }

            return _json;

        }

        public jsonArray getTeammemberTargetdetails(string TWE_id, string Weekinfo, string fromdate, string todate, string strtype, string prevfromdate, string prevtodate, string tblName)
        {
            Recrutingdashboard _rd = new Recrutingdashboard();
            int status = 1;
            string strquery = "";
            //int isExists = 0;
            string str = "";

            _rd.lstRemarks = new List<dropDownTemplate>();
            _rd.lstTarget = new List<targetfixingMstr>();
            _rd.lstprevTarget = new List<targetfixingMstr>();

            strquery = @"SELECT [RemarksID],[RemarksName] FROM [Remarks_Master] where Status=1";

            SqlDataReader _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                _rd.lstRemarks.Add(new dropDownTemplate
                {
                    ID = _read["RemarksID"].ToString(),
                    Name = _read["RemarksName"].ToString()
                });
            }

            _read.Close();

            _rd.Feedback = new TeamPerfomanceFeedback();
            strquery = @"SELECT [firstname]+' '+[lastname] FROM [Userprofilecreation] where [TWE_ID]='" + TWE_id + "'";

            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                _rd.Feedback.TWEID = _read[0].ToString();
            }

            _read.Close();

            if (tblName == "Weekly")
            {
                strquery = @"select Teamperfomanceid,[OverAllRating]" +
                            ",[Remarks],Weekinfo from TeamPerfomance_Weekly where Weekinfo='" + Weekinfo + "' and TWEID='" + TWE_id + "'";
                _read = _sql.doRead(strquery);
                while (_read.Read())
                {

                    _rd.Feedback.Teamperfomanceid = _read[0].ToString();
                    _rd.Feedback.OverallRating = _read[1].ToString();
                    _rd.Feedback.Remarks = _read[2].ToString();
                    _rd.Feedback.Weekinfo = _read[3].ToString();
                }

                _read.Close();

            }
            else if (tblName == "Monthly")
            {
                strquery = @"select Teamperfomanceid,[OverAllRating]" +
                            ",[Remarks],Monthinfo from TeamPerfomance_Monthly where Monthinfo='" + Weekinfo + "' and TWEID='" + TWE_id + "'";
                _read = _sql.doRead(strquery);
                while (_read.Read())
                {

                    _rd.Feedback.Teamperfomanceid = _read[0].ToString();
                    _rd.Feedback.OverallRating = _read[1].ToString();
                    _rd.Feedback.Remarks = _read[2].ToString();
                    _rd.Feedback.Weekinfo = _read[3].ToString();
                }

                _read.Close();
            }

            DateTime startDate = Convert.ToDateTime(prevfromdate);
            DateTime endDate = Convert.ToDateTime(prevtodate);
            int days = 0;

            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                if (startDate.DayOfWeek != DayOfWeek.Saturday && startDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    days++;
                }
                startDate = startDate.AddDays(1);
            }

            List<targetfixingMstr> lstPrevTarget = getTargetUSA(TWE_id, prevfromdate, prevtodate, strtype);


            var prevsubmissionper = (Convert.ToDecimal(lstPrevTarget[0].Submission_Daily) / Convert.ToDecimal(lstPrevTarget[1].Submission_Daily)) * 100;
            var prevsubmissionTLper = (Convert.ToDecimal(lstPrevTarget[0].SubmissiontoTL_Daily) / Convert.ToDecimal(lstPrevTarget[1].SubmissiontoTL_Daily)) * 100;
            var prevsubmissionBPper = (Convert.ToDecimal(lstPrevTarget[0].SubmissiontoBP_Daily) / Convert.ToDecimal(lstPrevTarget[1].SubmissiontoBP_Daily)) * 100;

            _rd.lstprevTarget = lstPrevTarget;

            if (prevsubmissionper > 100)
            {
                _rd.lstprevTarget[0].SBPercentage = "100";

            }
            else
            {
                _rd.lstprevTarget[0].SBPercentage = prevsubmissionper.ToString();
            }
            if (prevsubmissionTLper > 100)
            {
                _rd.lstprevTarget[0].TLPercentage = "100";
            }
            else
            {
                _rd.lstprevTarget[0].TLPercentage = prevsubmissionTLper.ToString();
            }

            if (prevsubmissionBPper > 100)
            {
                _rd.lstprevTarget[0].BPPercentage = "100";
            }
            else
            {
                _rd.lstprevTarget[0].BPPercentage = prevsubmissionBPper.ToString();
            }


            if (tblName == "Monthly")
            {
                if (Convert.ToInt32(lstPrevTarget[1].Closure_Daily) != 0)
                {
                    _rd.lstprevTarget[0].CLPercentage = ((Convert.ToDecimal(lstPrevTarget[0].Closure_Daily) / Convert.ToDecimal(lstPrevTarget[1].Closure_Daily)) * 100).ToString();

                    if (Convert.ToInt32(_rd.lstprevTarget[0].CLPercentage) > 100)
                    {
                        _rd.lstprevTarget[0].CLPercentage = "100";
                    }
                    else
                    {
                        _rd.lstprevTarget[0].CLPercentage = ((Convert.ToDecimal(lstPrevTarget[0].Closure_Daily) / Convert.ToDecimal(lstPrevTarget[1].Closure_Daily)) * 100).ToString();
                    }


                }
                else
                {
                    _rd.lstprevTarget[0].CLPercentage = "0";
                }

                str = "<canvas id = 'chart-consumptionprev' class='chart-canvas' height='246' width='275' style='display: block; box-sizing: border-box; height: 197px; width: 220.6px;'></canvas> <script>" +

            "var ctx1 = document.getElementById('chart-consumptionprev').getContext('2d');" +
            "var gradientStroke1 = ctx1.createLinearGradient(0, 230, 0, 50);" +
            "gradientStroke1.addColorStop(1, 'rgba(203,12,159,0.2)');" +
            "gradientStroke1.addColorStop(0.2, 'rgba(72,72,176,0.0)');" +
            "gradientStroke1.addColorStop(0, 'rgba(203,12,159,0)');" +
            "new Chart(ctx1, {" +
            "type: 'doughnut'," +
            "data:" +
            "{" +
            "labels: ['Submission', 'Submission to TL', 'Submission to BP','Closures']," +
            "datasets: [{" +
            "label: 'Performance'," +
            "weight: 9," +
            "cutout: 90," +
            "tension: 0.9," +
            "pointRadius: 2," +
            "borderWidth: 2," +
            "backgroundColor:  ['#2ed9fb', '#8092b1', '#f99336','#56cc32']," +
            "data: [" + prevsubmissionper + ", " + prevsubmissionTLper + ", " + prevsubmissionBPper + ", " + _rd.lstprevTarget[0].CLPercentage + "]," +
            "fill: false" +
            "}]," +
            "}," +
            "options:" +
            "{" +
            "responsive: true," +
            "cutoutPercentage: 93," +
            "maintainAspectRatio: false," +
            "legend:" +
            "{" +
            "display: false" +
            "}," +
            "plugins:" +
            "{" +
            "legend:" +
            "{" +
            "display: false," +
            "}" +
            "}," +
            "interaction:" +
            "{" +
            "intersect: false," +
            "mode: 'index'," +
            "}," +
            "scales:" +
            "{" +
            "y:" +
            "{" +
            "grid:" +
            "{" +
            "drawBorder: false," +
            "display: false," +
            "drawOnChartArea: false," +
            "drawTicks: false," +
            "}," +
            "ticks:" +
            "{" +
            "display: false" +
            "}" +
            "}," +
            "x:" +
            "{" +
            "grid:" +
            "{" +
            "drawBorder: false," +
            "display: false," +
            "drawOnChartArea: false," +
            "drawTicks: false," +
            "}," +
            "ticks:" +
            "{" +
            "display: false," +
            "}" +
            "}," +
            "}," +
            "}," +
            "});" +
            "</script>";


            }
            else
            {
                str = "<canvas id = 'chart-consumptionprev' class='chart-canvas' height='246' width='275' style='display: block; box-sizing: border-box; height: 197px; width: 220.6px;'></canvas> <script>" +

            "var ctx1 = document.getElementById('chart-consumptionprev').getContext('2d');" +
            "var gradientStroke1 = ctx1.createLinearGradient(0, 230, 0, 50);" +
            "gradientStroke1.addColorStop(1, 'rgba(203,12,159,0.2)');" +
            "gradientStroke1.addColorStop(0.2, 'rgba(72,72,176,0.0)');" +
            "gradientStroke1.addColorStop(0, 'rgba(203,12,159,0)');" +
            "new Chart(ctx1, {" +
            "type: 'doughnut'," +
            "data:" +
            "{" +
            "labels: ['Submission', 'Submission to TL', 'Submission to BP']," +
            "datasets: [{" +
            "label: 'Performance'," +
            "weight: 9," +
            "cutout: 90," +
            "tension: 0.9," +
            "pointRadius: 2," +
            "borderWidth: 2," +
            "backgroundColor:  ['#2ed9fb', '#8092b1', '#f99336']," +
            "data: [" + prevsubmissionper + ", " + prevsubmissionTLper + ", " + prevsubmissionBPper + "]," +
            "fill: false" +
            "}]," +
            "}," +
            "options:" +
            "{" +
            "responsive: true," +
            "cutoutPercentage: 93," +
            "maintainAspectRatio: false," +
            "legend:" +
            "{" +
            "display: false" +
            "}," +
            "plugins:" +
            "{" +
            "legend:" +
            "{" +
            "display: false," +
            "}" +
            "}," +
            "interaction:" +
            "{" +
            "intersect: false," +
            "mode: 'index'," +
            "}," +
            "scales:" +
            "{" +
            "y:" +
            "{" +
            "grid:" +
            "{" +
            "drawBorder: false," +
            "display: false," +
            "drawOnChartArea: false," +
            "drawTicks: false," +
            "}," +
            "ticks:" +
            "{" +
            "display: false" +
            "}" +
            "}," +
            "x:" +
            "{" +
            "grid:" +
            "{" +
            "drawBorder: false," +
            "display: false," +
            "drawOnChartArea: false," +
            "drawTicks: false," +
            "}," +
            "ticks:" +
            "{" +
            "display: false," +
            "}" +
            "}," +
            "}," +
            "}," +
            "});" +
            "</script>";
            }


            _rd.Linechart = str;

            List<targetfixingMstr> lstCurrTarget = getTargetUSA(TWE_id, fromdate, todate, strtype);
            decimal submissionper;
            decimal submissionTLper;
            decimal submissionBPper;

            if (Convert.ToInt32(lstCurrTarget[1].Submission_Daily) != 0)
            {
                submissionper = (Convert.ToDecimal(lstCurrTarget[0].Submission_Daily) / Convert.ToDecimal(lstCurrTarget[1].Submission_Daily)) * 100;

            }
            else
            {
                submissionper = 0;
            }

            if (Convert.ToInt32(lstCurrTarget[1].SubmissiontoTL_Daily) != 0)
            {
                submissionTLper = (Convert.ToDecimal(lstCurrTarget[0].SubmissiontoTL_Daily) / Convert.ToDecimal(lstCurrTarget[1].SubmissiontoTL_Daily)) * 100;
            }
            else
            {
                submissionTLper = 0;
            }

            if (Convert.ToInt32(lstCurrTarget[1].SubmissiontoBP_Daily) != 0)
            {
                submissionBPper = (Convert.ToDecimal(lstCurrTarget[0].SubmissiontoBP_Daily) / Convert.ToDecimal(lstCurrTarget[1].SubmissiontoBP_Daily)) * 100;
            }
            else
            {
                submissionBPper = 0;
            }

            _rd.lstTarget = lstCurrTarget;
            if (submissionper > 100)
            {
                _rd.lstTarget[0].SBPercentage = "100";

            }
            else
            {
                _rd.lstTarget[0].SBPercentage = submissionper.ToString();
            }
            if (submissionTLper > 100)
            {
                _rd.lstTarget[0].TLPercentage = "100";
            }
            else
            {
                _rd.lstTarget[0].TLPercentage = submissionTLper.ToString();
            }

            if (submissionBPper > 100)
            {
                _rd.lstTarget[0].BPPercentage = "100";
            }
            else
            {
                _rd.lstTarget[0].BPPercentage = submissionBPper.ToString();
            }

            if (tblName == "Monthly")
            {
                if (Convert.ToInt32(lstCurrTarget[1].Closure_Daily) != 0)
                {
                    _rd.lstTarget[0].CLPercentage = ((Convert.ToDecimal(lstCurrTarget[0].Closure_Daily) / Convert.ToDecimal(lstCurrTarget[1].Closure_Daily)) * 100).ToString();

                    if (Convert.ToInt32(_rd.lstTarget[0].CLPercentage) > 100)
                    {
                        _rd.lstTarget[0].CLPercentage = "100";
                    }
                    else
                    {
                        _rd.lstTarget[0].CLPercentage = ((Convert.ToDecimal(lstCurrTarget[0].Closure_Daily) / Convert.ToDecimal(lstCurrTarget[1].Closure_Daily)) * 100).ToString();
                    }
                }
                else
                {
                    _rd.lstTarget[0].CLPercentage = "0";
                }

                str = "<canvas id = 'chart-consumption' class='chart-canvas' height='246' width='275' style='display: block; box-sizing: border-box; height: 197px; width: 220.6px;'></canvas> <script>" +

            "var ctx1 = document.getElementById('chart-consumption').getContext('2d');" +
            "var gradientStroke1 = ctx1.createLinearGradient(0, 230, 0, 50);" +
            "gradientStroke1.addColorStop(1, 'rgba(203,12,159,0.2)');" +
            "gradientStroke1.addColorStop(0.2, 'rgba(72,72,176,0.0)');" +
            "gradientStroke1.addColorStop(0, 'rgba(203,12,159,0)');" +
            "new Chart(ctx1, {" +
            "type: 'doughnut'," +
            "data:" +
            "{" +
            "labels: ['Submission', 'Submission to TL', 'Submission to BP','Closure']," +
            "datasets: [{" +
            "label: 'Performance'," +
            "weight: 9," +
            "cutout: 90," +
            "tension: 0.9," +
            "pointRadius: 2," +
            "borderWidth: 2," +
            "backgroundColor:  ['#2ed9fb', '#8092b1', '#f99336','#56cc32']," +
           "data: [" + submissionper + ", " + submissionTLper + ", " + submissionBPper + ", " + _rd.lstTarget[0].CLPercentage + "]," +
            "fill: false" +
            "}]," +
            "}," +
            "options:" +
            "{" +
            "responsive: true," +
            "cutoutPercentage: 93," +
            "maintainAspectRatio: false," +
            "legend:" +
            "{" +
            "display: false" +
            "}," +
            "plugins:" +
            "{" +
            "legend:" +
            "{" +
            "display: false," +
            "}" +
            "}," +
            "interaction:" +
            "{" +
            "intersect: false," +
            "mode: 'index'," +
            "}," +
            "scales:" +
            "{" +
            "y:" +
            "{" +
            "grid:" +
            "{" +
            "drawBorder: false," +
            "display: false," +
            "drawOnChartArea: false," +
            "drawTicks: false," +
            "}," +
            "ticks:" +
            "{" +
            "display: false" +
            "}" +
            "}," +
            "x:" +
            "{" +
            "grid:" +
            "{" +
            "drawBorder: false," +
            "display: false," +
            "drawOnChartArea: false," +
            "drawTicks: false," +
            "}," +
            "ticks:" +
            "{" +
            "display: false," +
            "}" +
            "}," +
            "}," +
            "}," +
            "});" +
            "</script>";
            }
            else
            {
                str = "<canvas id = 'chart-consumption' class='chart-canvas' height='246' width='275' style='display: block; box-sizing: border-box; height: 197px; width: 220.6px;'></canvas> <script>" +

            "var ctx1 = document.getElementById('chart-consumption').getContext('2d');" +
            "var gradientStroke1 = ctx1.createLinearGradient(0, 230, 0, 50);" +
            "gradientStroke1.addColorStop(1, 'rgba(203,12,159,0.2)');" +
            "gradientStroke1.addColorStop(0.2, 'rgba(72,72,176,0.0)');" +
            "gradientStroke1.addColorStop(0, 'rgba(203,12,159,0)');" +
            "new Chart(ctx1, {" +
            "type: 'doughnut'," +
            "data:" +
            "{" +
            "labels: ['Submission', 'Submission to TL', 'Submission to BP']," +
            "datasets: [{" +
            "label: 'Performance'," +
            "weight: 9," +
            "cutout: 90," +
            "tension: 0.9," +
            "pointRadius: 2," +
            "borderWidth: 2," +
            "backgroundColor:  ['#2ed9fb', '#8092b1', '#f99336']," +
           "data: [" + submissionper + ", " + submissionTLper + ", " + submissionBPper + "]," +
            "fill: false" +
            "}]," +
            "}," +
            "options:" +
            "{" +
            "responsive: true," +
            "cutoutPercentage: 93," +
            "maintainAspectRatio: false," +
            "legend:" +
            "{" +
            "display: false" +
            "}," +
            "plugins:" +
            "{" +
            "legend:" +
            "{" +
            "display: false," +
            "}" +
            "}," +
            "interaction:" +
            "{" +
            "intersect: false," +
            "mode: 'index'," +
            "}," +
            "scales:" +
            "{" +
            "y:" +
            "{" +
            "grid:" +
            "{" +
            "drawBorder: false," +
            "display: false," +
            "drawOnChartArea: false," +
            "drawTicks: false," +
            "}," +
            "ticks:" +
            "{" +
            "display: false" +
            "}" +
            "}," +
            "x:" +
            "{" +
            "grid:" +
            "{" +
            "drawBorder: false," +
            "display: false," +
            "drawOnChartArea: false," +
            "drawTicks: false," +
            "}," +
            "ticks:" +
            "{" +
            "display: false," +
            "}" +
            "}," +
            "}," +
            "}," +
            "});" +
            "</script>";
            }




            _rd.Barchart = str;

            //targetfixingMstr targetfixingMstr = new targetfixingMstr();

            //strquery = @"select
            //        (
            //        select count(*) candcount from CandidateDetailsIndia can
            //        where can.Created_By like '%" + TWE_id + "%' and can.Created_on" +
            //       " between '" + prevfromdate + "' and '" + prevtodate + "') subachieved," +
            //       "(select Submission_Daily * "+days+" as TargetValue from UserTargetMaster" +
            //       " where TWEID like'%" + TWE_id + "%') subtarget ," +
            //       " (select count(*) candcount from CandidateDetailsIndia can" +
            //       " join CandidateJobIndia canjob on can.candidateid = canjob.CandidateId" +
            //       " join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
            //       " where can.Created_By like '%" + TWE_id + "%' and Cand_Status >= 103" +
            //       " and can.Created_on between '" + prevfromdate + "' and '" + prevtodate + "' ) subTLachieved, " +
            //       " (select SubmissiontoTL_Daily * " + days + " as TargetValue from UserTargetMaster" +
            //       " where TWEID like'%" + TWE_id + "%') SubTLtarget," +
            //       " (select count(*) candcount from CandidateDetailsIndia can" +
            //       " join CandidateJobIndia canjob on can.candidateid = canjob.CandidateId" +
            //       " join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
            //       " where can.Created_By like '%" + TWE_id + "%' and Cand_Status > 103 and Cand_Status!= 104" +
            //       " and can.Created_on between '" + prevfromdate + "' and '" + prevtodate + "') subBPacheived," +
            //       " (select SubmissiontoBP_Daily * " + days + " as TargetValue from" +
            //       " UserTargetMaster where TWEID like'%" + TWE_id + "%') subBPtarget";

            //_read = _sql.doRead(strquery);
            //decimal s1 = 0;
            //while (_read.Read())
            //{
            //    try
            //    {
            //        s1 = (Convert.ToDecimal(_read[0])/ Convert.ToDecimal(_read[1]))*100;
            //        targetfixingMstr.Submission_Daily = ((Convert.ToDecimal(_read[0])/ Convert.ToDecimal(_read[1]))*100).ToString();
            //        targetfixingMstr.SubmissiontoTL_Daily =((Convert.ToDecimal(_read[2]) / Convert.ToDecimal(_read[3]))*100).ToString();
            //        targetfixingMstr.SubmissiontoBP_Daily = ((Convert.ToDecimal(_read[4]) / Convert.ToDecimal(_read[5]))*100).ToString();
            //        _rd.lstTarget.Add(targetfixingMstr);

            //    }
            //    catch(Exception ex)
            //    { }

            //}

            //_read.Close();



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
                _json.data = _rd;
            }

            return _json;

        }

        public jsonArray getTeammemberFeedbackgivendetailsIndia(string TWE_id, List<string> Weekinfo, string fromdate, string todate, string type)
        {
            List<Feedbackstatus> lstFeed = new List<Feedbackstatus>();
            int status = 1;
            string strquery = "";

            for (int i = 0; i < Weekinfo.Count; i++)
            {
                strquery = @"select * from TeamPerfomanceIndia_Weekly where Weekinfo='" + Weekinfo[i] + "' and TWEID='" + TWE_id + "'";
                SqlDataReader _read = _sql.doRead(strquery);
                if (_read.HasRows)
                {
                    Feedbackstatus objFeed = new Feedbackstatus();
                    objFeed.Weekinfo = Weekinfo[i];
                    objFeed.status = "1";
                    lstFeed.Add(objFeed);
                }
                else
                {
                    Feedbackstatus objFeed = new Feedbackstatus();
                    objFeed.Weekinfo = Weekinfo[i];
                    objFeed.status = "0";
                    lstFeed.Add(objFeed);
                }

                _read.Close();
            }

            DateTime startDate = Convert.ToDateTime(fromdate);
            DateTime endDate = Convert.ToDateTime(todate);
            int days = 0;

            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                if (startDate.DayOfWeek != DayOfWeek.Saturday && startDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    days++;
                }
                startDate = startDate.AddDays(1);
            }

            //strquery = @"select
            //            (
            //            select cast(candcount as float)/"+ days + " * cast(TargetValue as float) from"+
            //            "("+
            //            "select count(*) candcount from CandidateDetailsIndia can"+
            //            " where can.Created_By like '%" + TWE_id + "%' and " +
            //            "can.Created_on between '" + fromdate + "' and '" + todate + "' ) tb1," +
            //            "(select Candidate_adding as TargetValue from Userprofilecreation where TWE_ID like'%" + TWE_id + "%') tb2" +
            //            ") candcount,(" +
            //            "select cast(candcount as float)/" + days + " *cast(TargetValue as float) from" +
            //            "(" +
            //            "select count(*) candcount from CandidateDetailsIndia can" +
            //             " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
            //             " join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
            //            " where can.Created_By like '%" + TWE_id + "%' and Cand_Status in ('103')" +
            //            " and can.Created_on between '" + fromdate + "' and '" + todate + "' ) tb5, " +
            //            "(select Submittion as TargetValue from Userprofilecreation where TWE_ID like'%" + TWE_id + "%') tb6" +
            //            ")subcount," +
            //                "(select cast(candcount as float) /" + days + " * cast(TargetValue as float) from" +
            //                "(" +
            //                "select count(*) candcount from CandidateDetailsIndia can" +
            //                 " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
            //                 " join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
            //                " where can.Created_By like '%" + TWE_id + "%' and Cand_Status > 103" +
            //                "and can.Created_on between '" + fromdate + "' and '" + todate + "') tb7," +
            //                "(select TLApproval as TargetValue from Userprofilecreation where TWE_ID like'%" + TWE_id + "%') tb8" +
            //                ")TLAppcount," +
            //                "(" +
            //                "select cast(candcount as float) /" + days + " * cast(TargetValue as float) from" +
            //                "(" +
            //                "select count(*) candcount from CandidateDetailsIndia can" +
            //                " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
            //                " join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
            //                " where can.Created_By like '%" + TWE_id + "%' and Cand_Status >= 105" +
            //                "and can.Created_on between '" + fromdate + "' and '" + todate + "') tb7," +
            //                "(select BPApproval as TargetValue from Userprofilecreation where TWE_ID like'%" + TWE_id + "%') tb8" +
            //                ")BPAppcount," +
            //                "(" +
            //                "select cast(candcount as float) /" + days + " * cast(TargetValue as float) from" +
            //                "(" +
            //                "select count(*) candcount from CandidateDetailsIndia can" +
            //                " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
            //                " join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
            //                " where can.Created_By like '%" + TWE_id + "%' and Cand_Status >= 107" +
            //                "and can.Created_on between '" + fromdate + "' and '" + todate + "') tb7," +
            //                "(select ECApproval as TargetValue from Userprofilecreation where TWE_ID like'%" + TWE_id + "%') tb8" +
            //                ")ECAppcount";

            if (type == "Daily")
            {

                strquery = @"select
                            (
                            select (cast(candcount as float)/(" + days + "* cast(TargetValue as float)))*100 from" +
                            "(" +
                            "select count(*) candcount from CandidateDetailsIndia can" +
                            " where can.Created_By like '%" + TWE_id + "%' and " +
                            "can.Created_on between '" + fromdate + "' and '" + todate + "' ) tb1," +
                            "(select Submission_Daily as TargetValue from UserTargetMaster where TWEID like'%" + TWE_id + "%') tb2" +
                            ") candcount,(" +
                            "select (cast(candcount as float)/(" + days + "* cast(TargetValue as float)))*100 from" +
                            "(" +
                            "select count(*) candcount from CandidateDetailsIndia can" +
                            " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                            " join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
                            " where can.Created_By like '%" + TWE_id + "%' and Cand_Status > 103" +
                            " and can.Created_on between '" + fromdate + "' and '" + todate + "' ) tb5, " +
                            "(select SubmissiontoTL_Daily as TargetValue from UserTargetMaster where TWEID like'%" + TWE_id + "%') tb6" +
                            ")subtoTLcount," +
                            "(select (cast(candcount as float)/(" + days + "* cast(TargetValue as float)))*100 from" +
                            "(" +
                            "select count(*) candcount from CandidateDetailsIndia can" +
                            " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                            " join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
                            " where can.Created_By like '%" + TWE_id + "%' and Cand_Status > 103 and Cand_Status!=104" +
                            "and can.Created_on between '" + fromdate + "' and '" + todate + "') tb7," +
                            "(select SubmissiontoBP_Daily as TargetValue from UserTargetMaster where TWEID like'%" + TWE_id + "%') tb8" +
                            ")subtoBPcount";
            }

            else if (type == "Monthly")
            {
                strquery = @"select
                            (
                            select (cast(candcount as float)/(cast(TargetValue as float)))*100 from" +
                            "(" +
                            "select count(*) candcount from CandidateDetailsIndia can" +
                            " where can.Created_By like '%" + TWE_id + "%' and " +
                            "can.Created_on between '" + fromdate + "' and '" + todate + "' ) tb1," +
                            "(select Submission_Monthly as TargetValue from UserTargetMaster where TWEID like'%" + TWE_id + "%') tb2" +
                            ") candcount,(" +
                            "select (cast(candcount as float)/(cast(TargetValue as float)))*100 from" +
                            "(" +
                            "select count(*) candcount from CandidateDetailsIndia can" +
                            " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                            " join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
                            " where can.Created_By like '%" + TWE_id + "%' and Cand_Status > 103" +
                            " and can.Created_on between '" + fromdate + "' and '" + todate + "' ) tb5, " +
                            "(select SubmissiontoTL_Monthly as TargetValue from UserTargetMaster where TWEID like'%" + TWE_id + "%') tb6" +
                            ")subtoTLcount," +
                            "(select (cast(candcount as float)/cast(TargetValue as float))*100 from" +
                            "(" +
                            "select count(*) candcount from CandidateDetailsIndia can" +
                            " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                            " join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
                            " where can.Created_By like '%" + TWE_id + "%' and Cand_Status > 103 and Cand_Status!=104" +
                            "and can.Created_on between '" + fromdate + "' and '" + todate + "') tb7," +
                            "(select SubmissiontoBP_Monthly as TargetValue from UserTargetMaster where TWEID like'%" + TWE_id + "%') tb8" +
                            ")subtoBPcount," +
                            "(" +
                            "select (cast(candcount as float)/(cast(TargetValue as float)))*100 from" +
                            "(" +
                            "select count(*) candcount from CandidateDetailsIndia can" +
                            " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                            " join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
                            " where can.Created_By like '%" + TWE_id + "%' and Cand_Status in ('109')" +
                            "and can.Created_on between '" + fromdate + "' and '" + todate + "') tb7," +
                            "(select NULLIF(Closure_Monthly,0) as TargetValue from UserTargetMaster where TWEID like'%" + TWE_id + "%') tb8" +
                            ")Closurecount";
            }


            SqlDataReader _read1 = _sql.doRead(strquery);

            string strOver = "";
            while (_read1.Read())
            {
                if (type == "Daily")
                    strOver = Math.Round(((Convert.ToDouble(_read1[0]) + Convert.ToDouble(_read1[1]) + Convert.ToDouble(_read1[2])) / 3), 2).ToString();
                else if (type == "Monthly")
                    strOver = Math.Round(((Convert.ToDouble(_read1[0]) + Convert.ToDouble(_read1[1]) + Convert.ToDouble(_read1[2]) + Convert.ToDouble(_read1[3])) / 4), 2).ToString();

                //strOver = Math.Round(((Convert.ToDouble(_read1[0]) + Convert.ToDouble(_read1[1]) + Convert.ToDouble(_read1[2]) + Convert.ToDouble(_read1[3]) + Convert.ToDouble(_read1[4])) / 5), 2).ToString();

            }

            _read1.Close();

            string str = "<canvas id = 'chart-consumption' class='chart-canvas' height='246' width='275' style='display: block; box-sizing: border-box; height: 197px; width: 220.6px;'></canvas> <script>" +

            "var ctx1 = document.getElementById('chart-consumption').getContext('2d');" +
            "var gradientStroke1 = ctx1.createLinearGradient(0, 230, 0, 50);" +
            "gradientStroke1.addColorStop(1, 'rgba(203,12,159,0.2)');" +
            "gradientStroke1.addColorStop(0.2, 'rgba(72,72,176,0.0)');" +
            "gradientStroke1.addColorStop(0, 'rgba(203,12,159,0)');" +
            "new Chart(ctx1, {" +
            "type: 'doughnut'," +
            "data:" +
            "{" +
            "labels: ['Overall Performance', 'Under Performance']," +
            "datasets: [{" +
            "label: 'Performance'," +
            "weight: 9," +
            "cutout: 90," +
            "tension: 0.9," +
            "pointRadius: 2," +
            "borderWidth: 2," +
            "backgroundColor: ['#21d4fd', '#FF0080']," +
            "data: [" + strOver + ", " + (100 - Convert.ToDouble(strOver)).ToString() + "]," +
            "fill: false" +
            "}]," +
            "}," +
            "options:" +
            "{" +
            "responsive: true," +
            "cutoutPercentage: 93," +
            "maintainAspectRatio: false," +
            "legend:" +
            "{" +
            "display: false" +
            "}," +
            "plugins:" +
            "{" +
            "legend:" +
            "{" +
            "display: false," +
            "}" +
            "}," +
            "interaction:" +
            "{" +
            "intersect: false," +
            "mode: 'index'," +
            "}," +
            "scales:" +
            "{" +
            "y:" +
            "{" +
            "grid:" +
            "{" +
            "drawBorder: false," +
            "display: false," +
            "drawOnChartArea: false," +
            "drawTicks: false," +
            "}," +
            "ticks:" +
            "{" +
            "display: false" +
            "}" +
            "}," +
            "x:" +
            "{" +
            "grid:" +
            "{" +
            "drawBorder: false," +
            "display: false," +
            "drawOnChartArea: false," +
            "drawTicks: false," +
            "}," +
            "ticks:" +
            "{" +
            "display: false," +
            "}" +
            "}," +
            "}," +
            "}," +
            "});" +
            "</script>";

            Feedbackstatus objFeed1 = new Feedbackstatus();
            objFeed1.Weekinfo = str;
            objFeed1.status = "0";

            if (Convert.ToDouble(strOver) >= 75)
            {
                objFeed1.status = "Excellent";
            }
            else if (Convert.ToDouble(strOver) >= 50)
            {
                objFeed1.status = "Good";
            }
            else if (Convert.ToDouble(strOver) >= 25)
            {
                objFeed1.status = "Average";
            }
            else if (Convert.ToDouble(strOver) <= 24)
            {
                objFeed1.status = "Bad";
            }
                       
            lstFeed.Add(objFeed1);

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
                _json.data = lstFeed;
            }

            return _json;

        }

        public jsonArray getTeammemberFeedbackgivendetails(string TWE_id, List<string> Weekinfo, string fromdate, string todate, string type)
        {
            List<Feedbackstatus> lstFeed = new List<Feedbackstatus>();
            int status = 1;
            string strquery = "";

            for (int i = 0; i < Weekinfo.Count; i++)
            {
                strquery = @"select * from TeamPerfomance_Weekly where Weekinfo='" + Weekinfo[i].Trim() + "' and TWEID='" + TWE_id + "'";
                SqlDataReader _read = _sql.doRead(strquery);
                if (_read.HasRows)
                {
                    Feedbackstatus objFeed = new Feedbackstatus();
                    objFeed.Weekinfo = Weekinfo[i];
                    objFeed.status = "1";
                    lstFeed.Add(objFeed);
                }
                else
                {
                    Feedbackstatus objFeed = new Feedbackstatus();
                    objFeed.Weekinfo = Weekinfo[i];
                    objFeed.status = "0";
                    lstFeed.Add(objFeed);
                }

                _read.Close();
            }

            DateTime startDate = Convert.ToDateTime(fromdate);
            DateTime endDate = Convert.ToDateTime(todate);
            int days = 0;

            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                if (startDate.DayOfWeek != DayOfWeek.Saturday && startDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    days++;
                }
                startDate = startDate.AddDays(1);
            }

           

            if (type == "Daily")
            {

                strquery = @"select
                            (
                            select (cast(candcount as float)/(" + days + "* cast(TargetValue as float)))*100 from" +
                            "(" +
                            "select count(*) candcount from CandidateDetails can" +
                            " where can.Created_By like '%" + TWE_id + "%' and " +
                            "can.Created_on between '" + fromdate + "' and '" + todate + "' ) tb1," +
                            "(select Submission_Daily as TargetValue from UserTargetMaster where TWEID like'%" + TWE_id + "%') tb2" +
                            ") candcount,(" +
                            "select (cast(candcount as float)/(" + days + "* cast(TargetValue as float)))*100 from" +
                            "(" +
                            "select count(*) candcount from CandidateDetails can" +
                            " join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                            " join Job_Master_USA job on job.Jobcode = canjob.Jobcode" +
                            " where can.Created_By like '%" + TWE_id + "%' and Cand_Status > 103" +
                            " and can.Created_on between '" + fromdate + "' and '" + todate + "' ) tb5, " +
                            "(select SubmissiontoTL_Daily as TargetValue from UserTargetMaster where TWEID like'%" + TWE_id + "%') tb6" +
                            ")subtoTLcount," +
                            "(select (cast(candcount as float)/(" + days + "* cast(TargetValue as float)))*100 from" +
                            "(" +
                            "select count(*) candcount from CandidateDetails can" +
                            " join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                            " join Job_Master_USA job on job.Jobcode = canjob.Jobcode" +
                            " where can.Created_By like '%" + TWE_id + "%' and Cand_Status > 103 and Cand_Status!=104" +
                            "and can.Created_on between '" + fromdate + "' and '" + todate + "') tb7," +
                            "(select SubmissiontoBP_Daily as TargetValue from UserTargetMaster where TWEID like'%" + TWE_id + "%') tb8" +
                            ")subtoBPcount";
            }

            else if (type == "Monthly")
            {
                strquery = @"select
                            (
                            select (cast(candcount as float)/(cast(TargetValue as float)))*100 from" +
                            "(" +
                            "select count(*) candcount from CandidateDetails can" +
                            " where can.Created_By like '%" + TWE_id + "%' and " +
                            "can.Created_on between '" + fromdate + "' and '" + todate + "' ) tb1," +
                            "(select Submission_Monthly as TargetValue from UserTargetMaster where TWEID like'%" + TWE_id + "%') tb2" +
                            ") candcount,(" +
                            "select (cast(candcount as float)/(cast(TargetValue as float)))*100 from" +
                            "(" +
                            "select count(*) candcount from CandidateDetails can" +
                            " join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                            " join Job_Master_USA job on job.Jobcode = canjob.Jobcode" +
                            " where can.Created_By like '%" + TWE_id + "%' and Cand_Status > 103" +
                            " and can.Created_on between '" + fromdate + "' and '" + todate + "' ) tb5, " +
                            "(select SubmissiontoTL_Monthly as TargetValue from UserTargetMaster where TWEID like'%" + TWE_id + "%') tb6" +
                            ")subtoTLcount," +
                            "(select (cast(candcount as float)/cast(TargetValue as float))*100 from" +
                            "(" +
                            "select count(*) candcount from CandidateDetails can" +
                            " join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                            " join Job_Master_USA job on job.Jobcode = canjob.Jobcode" +
                            " where can.Created_By like '%" + TWE_id + "%' and Cand_Status > 103 and Cand_Status!=104" +
                            "and can.Created_on between '" + fromdate + "' and '" + todate + "') tb7," +
                            "(select SubmissiontoBP_Monthly as TargetValue from UserTargetMaster where TWEID like'%" + TWE_id + "%') tb8" +
                            ")subtoBPcount," +
                            "(" +
                            "select (cast(candcount as float)/(cast(TargetValue as float)))*100 from" +
                            "(" +
                            "select count(*) candcount from CandidateDetails can" +
                            " join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                            " join Job_Master_USA job on job.Jobcode = canjob.Jobcode" +
                            " where can.Created_By like '%" + TWE_id + "%' and Cand_Status in ('109')" +
                            "and can.Created_on between '" + fromdate + "' and '" + todate + "') tb7," +
                            "(select NULLIF(Closure_Monthly,0) as TargetValue from UserTargetMaster where TWEID like'%" + TWE_id + "%') tb8" +
                            ")Closurecount";
            }


            SqlDataReader _read1 = _sql.doRead(strquery);

            string strOver = "";
            while (_read1.Read())
            {
                if (type == "Daily")
                    strOver = Math.Round(((Convert.ToDouble(_read1[0]) + Convert.ToDouble(_read1[1]) + Convert.ToDouble(_read1[2])) / 3), 2).ToString();
                else if (type == "Monthly")
                    strOver = Math.Round(((Convert.ToDouble(_read1[0]) + Convert.ToDouble(_read1[1]) + Convert.ToDouble(_read1[2]) + Convert.ToDouble(_read1[3])) / 4), 2).ToString();

                //strOver = Math.Round(((Convert.ToDouble(_read1[0]) + Convert.ToDouble(_read1[1]) + Convert.ToDouble(_read1[2]) + Convert.ToDouble(_read1[3]) + Convert.ToDouble(_read1[4])) / 5), 2).ToString();

            }

            _read1.Close();

            string str = "<canvas id = 'chart-consumption' class='chart-canvas' height='246' width='275' style='display: block; box-sizing: border-box; height: 197px; width: 220.6px;'></canvas> <script>" +

            "var ctx1 = document.getElementById('chart-consumption').getContext('2d');" +
            "var gradientStroke1 = ctx1.createLinearGradient(0, 230, 0, 50);" +
            "gradientStroke1.addColorStop(1, 'rgba(203,12,159,0.2)');" +
            "gradientStroke1.addColorStop(0.2, 'rgba(72,72,176,0.0)');" +
            "gradientStroke1.addColorStop(0, 'rgba(203,12,159,0)');" +
            "new Chart(ctx1, {" +
            "type: 'doughnut'," +
            "data:" +
            "{" +
            "labels: ['Overall Performance', 'Under Performance']," +
            "datasets: [{" +
            "label: 'Performance'," +
            "weight: 9," +
            "cutout: 90," +
            "tension: 0.9," +
            "pointRadius: 2," +
            "borderWidth: 2," +
            "backgroundColor: ['#21d4fd', '#FF0080']," +
            "data: [" + strOver + ", " + (100 - Convert.ToDouble(strOver)).ToString() + "]," +
            "fill: false" +
            "}]," +
            "}," +
            "options:" +
            "{" +
            "responsive: true," +
            "cutoutPercentage: 93," +
            "maintainAspectRatio: false," +
            "legend:" +
            "{" +
            "display: false" +
            "}," +
            "plugins:" +
            "{" +
            "legend:" +
            "{" +
            "display: false," +
            "}" +
            "}," +
            "interaction:" +
            "{" +
            "intersect: false," +
            "mode: 'index'," +
            "}," +
            "scales:" +
            "{" +
            "y:" +
            "{" +
            "grid:" +
            "{" +
            "drawBorder: false," +
            "display: false," +
            "drawOnChartArea: false," +
            "drawTicks: false," +
            "}," +
            "ticks:" +
            "{" +
            "display: false" +
            "}" +
            "}," +
            "x:" +
            "{" +
            "grid:" +
            "{" +
            "drawBorder: false," +
            "display: false," +
            "drawOnChartArea: false," +
            "drawTicks: false," +
            "}," +
            "ticks:" +
            "{" +
            "display: false," +
            "}" +
            "}," +
            "}," +
            "}," +
            "});" +
            "</script>";

            Feedbackstatus objFeed1 = new Feedbackstatus();
            objFeed1.Weekinfo = str;
            objFeed1.status = "0";

            if (Convert.ToDouble(strOver) >= 75)
            {
                objFeed1.status = "Excellent";
            }
            else if (Convert.ToDouble(strOver) >= 50)
            {
                objFeed1.status = "Good";
            }
            else if (Convert.ToDouble(strOver) >= 25)
            {
                objFeed1.status = "Average";
            }
            else if (Convert.ToDouble(strOver) <= 24)
            {
                objFeed1.status = "Bad";
            }

            lstFeed.Add(objFeed1);

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
                _json.data = lstFeed;
            }

            return _json;

        }

        public int NumberOfParticularDaysInMonth(int year, int month, DayOfWeek dayOfWeek)
        {
            DateTime startDate = new DateTime(year, month, 1);
            int totalDays = startDate.AddMonths(1).Subtract(startDate).Days;

            int answer = Enumerable.Range(1, totalDays)
                .Select(item => new DateTime(year, month, item))
                .Where(date => date.DayOfWeek == dayOfWeek)
                .Count();

            return answer;
        }


        public jsonArray checkEmaildata(string emailid)
        {
            int status = 1;
            string query = "";
            string isExists = "False";

            query = @"select TWE_ID,accountpassword from Userprofilecreation where emailid='" + emailid + "' and Status=1";           

            SqlDataReader _read = _sql.doRead(query);

            while(_read.Read())
            {
                isExists = "True" + "$" + _read[0].ToString() +"$"+ Decrypt(_read[1].ToString());
            }

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
                _json.data = isExists;
            }

            return _json;

        }

        public jsonArray updatePassword(string TWE_ID,string newpsw )
        {
            int status = 1;

            string query = @"update Userprofilecreation set accountpassword='"+Encrypt(newpsw)+ "' where TWE_ID='" + TWE_ID + "'";
            int success=_sql.doInsert(query);


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
                _json.data = success;
            }

            return _json;

        }

        public jsonArray getCandidateClosureListDetails(string TWE_Id)
        {
            int status = 1;
            string query = "";
            candidateOverview objCand = new candidateOverview();

            objCand._lstcandilist = new List<candidatelist>();

            
            query = @"select can.candidateid,candidatename,candidateemailid,candidatemobileno,ratePerHr,
                        typ.TypeName,ContactPerson,MailId,sta.CandidateStatusName Cand_Status,
                        up.UP_firstName+' '+up.UP_lastName Empname,
                        convert(varchar,can.Created_On,106) CreatedOn,CreatedTime,linkedinURL,job.Jobcode,job.JobTitle
                        from CandidateDetails can
                        join EmployerDetails emp on can.employerid=emp.employerid
                        join EmployerContactPerson empc on empc.VendorID=emp.employerid
                        join Userprofile up on can.Created_By=up.TWE_ID
                        join CandidateJob canjob on can.candidateid=canjob.CandidateId
                        join CandidateStatus_Master sta on sta.CandidateStatusID=canjob.Cand_Status
                        join Type_Master typ on typ.TypeID=can.type 
                        join Job_Master_USA job on job.Jobcode=canjob.Jobcode
                        where can.Created_By like '%" + TWE_Id + "%' " +
                        "and Cand_Status in ('109')";


            SqlDataReader _read =_sql.doRead(query);
            while (_read.Read())
            {
                candidatelist candilst = new candidatelist();
                candilst.candidateid = _read[0].ToString();
                candilst.candidatemediapath = "";
                candilst.candidatename = _read[1].ToString();
                candilst.candidateemailid = _read[2].ToString();
                candilst.candidatemobno = _read[3].ToString();
                candilst.ratePerHr = _read[4].ToString();
                candilst.type = _read[5].ToString();
                candilst.vendorname = _read[6].ToString();
                candilst.vendoremailid = _read[7].ToString();
                candilst.candidatestatus = _read[8].ToString();
                candilst.submittedby = _read[9].ToString();
                candilst.submitteddate = _read[10].ToString();
                candilst.submittedtime = _read[11].ToString();
                candilst.linkedinURL = _read[12].ToString();
                candilst.jobcode = _read[13].ToString();
                candilst.jobTitle = _read[14].ToString();
                
                objCand._lstcandilist.Add(candilst);
            }
            _read.Close();

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
                _json.data = objCand;
            }

            return _json;
        }


        public jsonArray getCandidateClosureListIndiaDetails(string TWE_Id)
        {
            int status = 1;
            string query = "";
            candidateOverview objCand = new candidateOverview();

            objCand._lstcandilist = new List<candidatelist>();


            query = @"select can.candidateid,candidatename,candidateemailid,candidatemobileno,ratePerHr,
                        employername,employeremailid,sta.CandidateStatusName Cand_Status,
                        up.UP_firstName+' '+up.UP_lastName Empname,
                        convert(varchar,can.Created_On,106) CreatedOn,CreatedTime,linkedinURL,job.Jobcode,job.JobTitle
                        from CandidateDetailsIndia can
                        left join EmployerDetailsIndia emp on can.employerid=emp.employerid
                         join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId
                        join CandidateStatus_Master sta on sta.CandidateStatusID=canjob.Cand_Status
                        join Userprofile up on can.Created_By=up.TWE_ID
                        join Job_Master_IND job on job.Jobcode=canjob.Jobcode
                        where can.Created_By like '%" + TWE_Id + "%' and " +
                        "Cand_Status in ('109') ";


            SqlDataReader _read = _sql.doRead(query);
            while (_read.Read())
            {
                candidatelist candilst = new candidatelist();
                candilst.candidateid = _read[0].ToString();
                candilst.candidatemediapath = "";
                candilst.candidatename = _read[1].ToString();
                candilst.candidateemailid = _read[2].ToString();
                candilst.candidatemobno = _read[3].ToString();
                candilst.ratePerHr = _read[4].ToString();
                candilst.vendorname = _read[5].ToString();
                candilst.vendoremailid = _read[6].ToString();
                candilst.candidatestatus = _read[7].ToString();
                candilst.submittedby = _read[8].ToString();
                candilst.submitteddate = _read[9].ToString();
                candilst.submittedtime = _read[10].ToString();
                candilst.linkedinURL = _read[11].ToString();
                candilst.jobcode = _read[12].ToString();
                candilst.jobTitle = _read[13].ToString();
                objCand._lstcandilist.Add(candilst);

            }
            _read.Close();

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
                _json.data = objCand;
            }

            return _json;
        }

        public string calculatePercentageOverview(string TWE_id, string fromdate, string todate,string type)
        {
            string strquery = "";
            string OverViewPercentage = "";

            DateTime startDate = Convert.ToDateTime(fromdate);
            DateTime endDate = Convert.ToDateTime(todate);
            int days = 0;

            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                if (startDate.DayOfWeek != DayOfWeek.Saturday && startDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    days++;
                }
                startDate = startDate.AddDays(1);
            }

            if (type == "Daily" && days!=0)
            {

            strquery = @"select
            (
            select (cast(candcount as float)/("+days+"* cast(TargetValue as float)))*100 from" +
                 "(" +
                 "select count(*) candcount from CandidateDetailsIndia can" +
                 " where can.Created_By like '%" + TWE_id + "%' and " +
                 "can.Created_on between '" + fromdate + "' and '" + todate + "' ) tb1," +
                 "(select Submission_Daily as TargetValue from UserTargetMaster where TWEID like'%" + TWE_id + "%') tb2" +
                 ") candcount,(" +
                 "select (cast(candcount as float)/(" + days + "* cast(TargetValue as float)))*100 from" +
                 "(" +
                 "select count(*) candcount from CandidateDetailsIndia can" +
                 " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                 " join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
                 " where can.Created_By like '%" + TWE_id + "%' and Cand_Status > 103" +
                 " and can.Created_on between '" + fromdate + "' and '" + todate + "' ) tb5, " +
                 "(select SubmissiontoTL_Daily as TargetValue from UserTargetMaster where TWEID like'%" + TWE_id + "%') tb6" +
                 ")subtoTLcount," +
                 "(select (cast(candcount as float)/(" + days + "* cast(TargetValue as float)))*100 from" +
                 "(" +
                 "select count(*) candcount from CandidateDetailsIndia can" +
                 " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                 " join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
                 " where can.Created_By like '%" + TWE_id + "%' and Cand_Status > 103 and Cand_Status!=104" +
                 "and can.Created_on between '" + fromdate + "' and '" + todate + "') tb7," +
                 "(select SubmissiontoBP_Daily as TargetValue from UserTargetMaster where TWEID like'%" + TWE_id + "%') tb8" +
                 ")subtoBPcount";
            }

            else if (type=="Monthly")
            {
                strquery = @"select
                (
                select (cast(candcount as float)/(cast(TargetValue as float)))*100 from" +
                 "(" +
                 "select count(*) candcount from CandidateDetailsIndia can" +
                 " where can.Created_By like '%" + TWE_id + "%' and " +
                 "can.Created_on between '" + fromdate + "' and '" + todate + "' ) tb1," +
                 "(select Submission_Monthly as TargetValue from UserTargetMaster where TWEID like'%" + TWE_id + "%') tb2" +
                 ") candcount,(" +
                 "select (cast(candcount as float)/(cast(TargetValue as float)))*100 from" +
                 "(" +
                 "select count(*) candcount from CandidateDetailsIndia can" +
                 " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                 " join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
                 " where can.Created_By like '%" + TWE_id + "%' and Cand_Status > 103" +
                 " and can.Created_on between '" + fromdate + "' and '" + todate + "' ) tb5, " +
                 "(select SubmissiontoTL_Monthly as TargetValue from UserTargetMaster where TWEID like'%" + TWE_id + "%') tb6" +
                 ")subtoTLcount," +
                 "(select (cast(candcount as float)/cast(TargetValue as float))*100 from" +
                 "(" +
                 "select count(*) candcount from CandidateDetailsIndia can" +
                 " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                 " join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
                 " where can.Created_By like '%" + TWE_id + "%' and Cand_Status > 103 and Cand_Status!=104" +
                 "and can.Created_on between '" + fromdate + "' and '" + todate + "') tb7," +
                 "(select SubmissiontoBP_Monthly as TargetValue from UserTargetMaster where TWEID like'%" + TWE_id + "%') tb8" +
                 ")subtoBPcount," +
                 "(" +
                 "select (cast(candcount as float)/(cast(TargetValue as float)))*100 from" +
                 "(" +
                 "select count(*) candcount from CandidateDetailsIndia can" +
                 " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                 " join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
                 " where can.Created_By like '%" + TWE_id + "%' and Cand_Status in ('109')" +
                 "and can.Created_on between '" + fromdate + "' and '" + todate + "') tb7," +
                 "(select NULLIF(Closure_Monthly,0) as TargetValue from UserTargetMaster where TWEID like'%" + TWE_id + "%') tb8" +
                 ")Closurecount";
            }

            SqlDataReader _read = _sql.doRead(strquery);
           
          
            while (_read.Read())
            {
                if (type == "Daily")
                    OverViewPercentage = Math.Round(((Convert.ToDouble(_read[0]) + Convert.ToDouble(_read[1]) + Convert.ToDouble(_read[2])) / 3), 2).ToString() + " % for the duration of ";
                else if (type == "Monthly")
                    OverViewPercentage = Math.Round(((Convert.ToDouble(_read[0]) + Convert.ToDouble(_read[1]) + Convert.ToDouble(_read[2]) + Convert.ToDouble(_read[3])) / 4), 2).ToString() + " % for the duration of ";
            }
            _read.Close();


            return OverViewPercentage;
        }

        public List<targetfixingMstr> getTarget(string TWE_id, string fromdate, string todate, string type)
        {
            List<targetfixingMstr> lstTarget = new List<targetfixingMstr>();
            string strQuery = "";
            if (type == "Daily")
            {
                strQuery = @"select
                    (
                    select count(*) candcount from CandidateDetailsIndia can
                    where can.Created_By like '%" + TWE_id + "%' and can.Created_on" +
                    " between '" + fromdate + "' and '" + todate + "') subachieved," +
                    "(select Submission_Daily as TargetValue from UserTargetMaster" +
                    " where TWEID like'%" + TWE_id + "%') subtarget ," +
                    " (select count(*) candcount from CandidateDetailsIndia can" +
                    " join CandidateJobIndia canjob on can.candidateid = canjob.CandidateId" +
                    " join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
                    " where can.Created_By like '%" + TWE_id + "%' and Cand_Status >= 103" +
                    " and can.Created_on between '" + fromdate + "' and '" + todate + "' ) subTLachieved, " +
                    " (select SubmissiontoTL_Daily as TargetValue from UserTargetMaster" +
                    " where TWEID like'%" + TWE_id + "%') SubTLtarget," +
                    " (select count(*) candcount from CandidateDetailsIndia can" +
                    " join CandidateJobIndia canjob on can.candidateid = canjob.CandidateId" +
                    " join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
                    " where can.Created_By like '%" + TWE_id + "%' and Cand_Status > 103 and Cand_Status!= 104" +
                    " and can.Created_on between '" + fromdate + "' and '" + todate + "') subBPacheived," +
                    " (select SubmissiontoBP_Daily as TargetValue from" +
                    " UserTargetMaster where TWEID like'%" + TWE_id + "%') subBPtarget," +
                    " (select count(*) candcount from CandidateDetailsIndia can join" +
                    " CandidateJobIndia canjob on can.candidateid = canjob.CandidateId" +
                    " join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
                    " where can.Created_By like '%" + TWE_id + "%' and Cand_Status in ('109')" +
                    " and can.Created_on between '" + fromdate + "' and '" + todate + "') closacheived," +
                    " (select Closure_Daily as TargetValue from UserTargetMaster" +
                    " where TWEID like'%" + TWE_id + "%') clostarget,"+
                    " (select count(*) candcount from CandidateDetailsIndia can" +
                    " join CandidateJobIndia canjob on can.candidateid = canjob.CandidateId" +
                    " join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
                    " where can.Created_By like '%" + TWE_id + "%' and Cand_Status > 103 and Cand_Status!= 104 and Cand_Status!= 106" +
                    " and can.Created_on between '" + fromdate + "' and '" + todate + "') subECacheived";
            }

            else if (type == "Monthly")
            {
                strQuery = @"select
                    (
                    select count(*) candcount from CandidateDetailsIndia can
                    where can.Created_By like '%" + TWE_id + "%' and can.Created_on" +
                    " between '" + fromdate + "' and '" + todate + "') subachieved," +
                    "(select Submission_Monthly as TargetValue from UserTargetMaster" +
                    " where TWEID like'%" + TWE_id + "%') subtarget ," +
                    " (select count(*) candcount from CandidateDetailsIndia can" +
                    " join CandidateJobIndia canjob on can.candidateid = canjob.CandidateId" +
                    " join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
                    " where can.Created_By like '%" + TWE_id + "%' and Cand_Status >= 103" +
                    " and can.Created_on between '" + fromdate + "' and '" + todate + "' ) subTLachieved, " +
                    " (select SubmissiontoTL_Monthly as TargetValue from UserTargetMaster" +
                    " where TWEID like'%" + TWE_id + "%') SubTLtarget," +
                    " (select count(*) candcount from CandidateDetailsIndia can" +
                    " join CandidateJobIndia canjob on can.candidateid = canjob.CandidateId" +
                    " join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
                    " where can.Created_By like '%" + TWE_id + "%' and Cand_Status > 103 and Cand_Status!= 104" +
                    " and can.Created_on between '" + fromdate + "' and '" + todate + "') subBPacheived," +
                    " (select SubmissiontoBP_Monthly as TargetValue from" +
                    " UserTargetMaster where TWEID like'%" + TWE_id + "%') subBPtarget," +
                    " (select count(*) candcount from CandidateDetailsIndia can join" +
                    " CandidateJobIndia canjob on can.candidateid = canjob.CandidateId" +
                    " join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
                    " where can.Created_By like '%" + TWE_id + "%' and Cand_Status in ('109')" +
                    " and can.Created_on between '" + fromdate + "' and '" + todate + "') closacheived," +
                    " (select Closure_Monthly as TargetValue from UserTargetMaster" +
                    " where TWEID like'%" + TWE_id + "%') clostarget"+ ",' ' subECacheived";
            }


            SqlDataReader _read = _sql.doRead(strQuery);

            DateTime startDate = Convert.ToDateTime(fromdate);
            DateTime endDate = Convert.ToDateTime(todate);
            int days = 0;

            DateTime dt1 = DateTime.Now;

            if (type == "Daily")
            {
                for (DateTime date = startDate; date <= endDate ; date = date.AddDays(1))
                {
                    if (startDate.DayOfWeek != DayOfWeek.Saturday && startDate.DayOfWeek != DayOfWeek.Sunday)
                    {
                        days++;
                    }
                    startDate = startDate.AddDays(1);
                }
            }

            else if (type == "Monthly")
            {
                for (DateTime date = startDate; date <= endDate && date <= dt1; date = date.AddDays(1))
                {
                    if (startDate.DayOfWeek != DayOfWeek.Saturday && startDate.DayOfWeek != DayOfWeek.Sunday)
                    {
                        days++;
                    }
                    startDate = startDate.AddDays(1);
                }
            }


            double weeks = (endDate.Date - startDate.Date).TotalDays / 7;

            double s1 = weeks;

            while (_read.Read())
            {
                targetfixingMstr obj1 = new targetfixingMstr();
                targetfixingMstr obj2 = new targetfixingMstr();
                obj1.Submission_Daily = _read[0].ToString();
                obj1.SubmissiontoTL_Daily = _read[2].ToString();
                obj1.SubmissiontoBP_Daily = _read[4].ToString();
                obj1.SubmissiontoEC_Daily = _read["subECacheived"].ToString();
                obj1.Closure_Daily = _read[6].ToString();

                lstTarget.Add(obj1);
                if (type == "Daily" && days!=0)
                {
                    obj2.Submission_Daily = (Convert.ToInt16(_read[1]) * days).ToString();
                    obj2.SubmissiontoTL_Daily = (Convert.ToInt16(_read[3]) * days).ToString();
                    obj2.SubmissiontoBP_Daily = (Convert.ToInt16(_read[5]) * days).ToString();
                    obj2.Closure_Daily = (Convert.ToInt16(_read[7]) * days).ToString();
                }
                else if (type == "Monthly")
                {

                    obj2.Submission_Daily = (Convert.ToInt16(_read[1])).ToString();
                    obj2.SubmissiontoTL_Daily = (Convert.ToInt16(_read[3])).ToString();
                    obj2.SubmissiontoBP_Daily = (Convert.ToInt16(_read[5])).ToString();
                    obj2.Closure_Daily = (Convert.ToInt16(_read[7])).ToString();
                }
                    lstTarget.Add(obj2);

            }

            _read.Close();
            return lstTarget;
        }

        public List<targetfixingMstr> getTargetUSA(string TWE_id, string fromdate, string todate, string type)
        {
            List<targetfixingMstr> lstTarget = new List<targetfixingMstr>();
            string strQuery = "";
            if (type == "Daily")
            {
                strQuery = @"select
                    (
                    select count(*) candcount from CandidateDetails can
                    where can.Created_By like '%" + TWE_id + "%' and can.Created_on" +
                    " between '" + fromdate + "' and '" + todate + "') subachieved," +
                    "(select Submission_Daily as TargetValue from UserTargetMaster" +
                    " where TWEID like'%" + TWE_id + "%') subtarget ," +
                    " (select count(*) candcount from CandidateDetails can" +
                    " join CandidateJob canjob on can.candidateid = canjob.CandidateId" +
                    " join Job_Master_USA job on job.Jobcode = canjob.Jobcode" +
                    " where can.Created_By like '%" + TWE_id + "%' and Cand_Status >= 103" +
                    " and can.Created_on between '" + fromdate + "' and '" + todate + "' ) subTLachieved, " +
                    " (select SubmissiontoTL_Daily as TargetValue from UserTargetMaster" +
                    " where TWEID like'%" + TWE_id + "%') SubTLtarget," +
                    " (select count(*) candcount from CandidateDetails can" +
                    " join CandidateJob canjob on can.candidateid = canjob.CandidateId" +
                    " join Job_Master_USA job on job.Jobcode = canjob.Jobcode" +
                    " where can.Created_By like '%" + TWE_id + "%' and Cand_Status > 103 and Cand_Status!= 104" +
                    " and can.Created_on between '" + fromdate + "' and '" + todate + "') subBPacheived," +
                    " (select SubmissiontoBP_Daily as TargetValue from" +
                    " UserTargetMaster where TWEID like'%" + TWE_id + "%') subBPtarget," +
                    " (select count(*) candcount from CandidateDetails can join" +
                    " CandidateJob canjob on can.candidateid = canjob.CandidateId" +
                    " join Job_Master_USA job on job.Jobcode = canjob.Jobcode" +
                    " where can.Created_By like '%" + TWE_id + "%' and Cand_Status in ('109')" +
                    " and can.Created_on between '" + fromdate + "' and '" + todate + "') closacheived," +
                    " (select Closure_Daily as TargetValue from UserTargetMaster" +
                    " where TWEID like'%" + TWE_id + "%') clostarget," +
                    " (select count(*) candcount from CandidateDetails can" +
                    " join CandidateJob canjob on can.candidateid = canjob.CandidateId" +
                    " join Job_Master_USA job on job.Jobcode = canjob.Jobcode" +
                    " where can.Created_By like '%" + TWE_id + "%' and Cand_Status > 103 and Cand_Status!= 104 and Cand_Status!= 106" +
                    " and can.Created_on between '" + fromdate + "' and '" + todate + "') subECacheived";
            }

            else if (type == "Monthly")
            {
                strQuery = @"select
                    (
                    select count(*) candcount from CandidateDetails can
                    where can.Created_By like '%" + TWE_id + "%' and can.Created_on" +
                    " between '" + fromdate + "' and '" + todate + "') subachieved," +
                    "(select Submission_Monthly as TargetValue from UserTargetMaster" +
                    " where TWEID like'%" + TWE_id + "%') subtarget ," +
                    " (select count(*) candcount from CandidateDetails can" +
                    " join CandidateJob canjob on can.candidateid = canjob.CandidateId" +
                    " join Job_Master_USA job on job.Jobcode = canjob.Jobcode" +
                    " where can.Created_By like '%" + TWE_id + "%' and Cand_Status >= 103" +
                    " and can.Created_on between '" + fromdate + "' and '" + todate + "' ) subTLachieved, " +
                    " (select SubmissiontoTL_Monthly as TargetValue from UserTargetMaster" +
                    " where TWEID like'%" + TWE_id + "%') SubTLtarget," +
                    " (select count(*) candcount from CandidateDetails can" +
                    " join CandidateJob canjob on can.candidateid = canjob.CandidateId" +
                    " join Job_Master_USA job on job.Jobcode = canjob.Jobcode" +
                    " where can.Created_By like '%" + TWE_id + "%' and Cand_Status > 103 and Cand_Status!= 104" +
                    " and can.Created_on between '" + fromdate + "' and '" + todate + "') subBPacheived," +
                    " (select SubmissiontoBP_Monthly as TargetValue from" +
                    " UserTargetMaster where TWEID like'%" + TWE_id + "%') subBPtarget," +
                    " (select count(*) candcount from CandidateDetails can join" +
                    " CandidateJob canjob on can.candidateid = canjob.CandidateId" +
                    " join Job_Master_USA job on job.Jobcode = canjob.Jobcode" +
                    " where can.Created_By like '%" + TWE_id + "%' and Cand_Status in ('109')" +
                    " and can.Created_on between '" + fromdate + "' and '" + todate + "') closacheived," +
                    " (select Closure_Monthly as TargetValue from UserTargetMaster" +
                    " where TWEID like'%" + TWE_id + "%') clostarget" + ",' ' subECacheived";
            }


            SqlDataReader _read = _sql.doRead(strQuery);

            DateTime startDate = Convert.ToDateTime(fromdate);
            DateTime endDate = Convert.ToDateTime(todate);
            int days = 0;

            DateTime dt1 = DateTime.Now;

            if (type == "Daily")
            {
                for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
                {
                    if (startDate.DayOfWeek != DayOfWeek.Saturday && startDate.DayOfWeek != DayOfWeek.Sunday)
                    {
                        days++;
                    }
                    startDate = startDate.AddDays(1);
                }
            }

            else if (type == "Monthly")
            {
                for (DateTime date = startDate; date <= endDate && date <= dt1; date = date.AddDays(1))
                {
                    if (startDate.DayOfWeek != DayOfWeek.Saturday && startDate.DayOfWeek != DayOfWeek.Sunday)
                    {
                        days++;
                    }
                    startDate = startDate.AddDays(1);
                }
            }


            double weeks = (endDate.Date - startDate.Date).TotalDays / 7;

            double s1 = weeks;

            while (_read.Read())
            {
                targetfixingMstr obj1 = new targetfixingMstr();
                targetfixingMstr obj2 = new targetfixingMstr();
                obj1.Submission_Daily = _read[0].ToString();
                obj1.SubmissiontoTL_Daily = _read[2].ToString();
                obj1.SubmissiontoBP_Daily = _read[4].ToString();
                obj1.SubmissiontoEC_Daily = _read[7].ToString();
                obj1.Closure_Daily = _read[6].ToString();

                lstTarget.Add(obj1);
                if (type == "Daily" && days != 0)
                {
                    obj2.Submission_Daily = (Convert.ToInt16(_read[1]) * days).ToString();
                    obj2.SubmissiontoTL_Daily = (Convert.ToInt16(_read[3]) * days).ToString();
                    obj2.SubmissiontoBP_Daily = (Convert.ToInt16(_read[5]) * days).ToString();
                    obj2.Closure_Daily = (Convert.ToInt16(_read[7]) * days).ToString();
                }
                else if (type == "Monthly")
                {

                    obj2.Submission_Daily = (Convert.ToInt16(_read[1])).ToString();
                    obj2.SubmissiontoTL_Daily = (Convert.ToInt16(_read[3])).ToString();
                    obj2.SubmissiontoBP_Daily = (Convert.ToInt16(_read[5])).ToString();
                    obj2.Closure_Daily = (Convert.ToInt16(_read[7])).ToString();
                }
                lstTarget.Add(obj2);

            }

            _read.Close();
            return lstTarget;
        }

        public List<linechartlist> getSubmissionchartData(string TWE_id, string fromdate, string todate, string strtype)
        {
            string strquery = "";
            List<linechartlist> _lstline = new List<linechartlist>();

            if (strtype == "Monthly")
            {
                strquery = @"select 'SB'colname, count(*) Submitted,month(can.Created_On) Monname  from CandidateDetailsIndia can" +
                                       " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                                       " left join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
                                       " where Cand_Status in ('101','102') and can.Created_By like '%" + TWE_id + "%' " +
                                       " and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                                       " group by month(can.Created_On) " +
                                       " union " +
                                       " select 'TL'colname,count(*) TL_Selected,month(can.Created_On) Monname from CandidateDetailsIndia can" +
                                       " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                                       " join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
                                       " where Cand_Status in ('103') and can.Created_By like '%" + TWE_id + "%' " +
                                       " and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                                       " group by month(can.Created_On) " +
                                       " union " +
                                       " select 'BP'colname,count(*) BP_Selected,month(can.Created_On) Monname  from CandidateDetailsIndia can" +
                                       " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                                       " join Job_Master_IND job on job.Jobcode = canjob.Jobcode where " +
                                       " Cand_Status in ('105') and can.Created_By like '%" + TWE_id + "%' " +
                                       " and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                                       " group by month(can.Created_On) " +
                                       " union " +
                                       " select 'EC'colname,count(*) EC_Selected,month(can.Created_On) Monname from CandidateDetailsIndia can" +
                                       " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                                       " join Job_Master_IND job on job.Jobcode = canjob.Jobcode where " +
                                       " Cand_Status in ('107') and can.Created_By like '%" + TWE_id + "%' " +
                                       " and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                                       " group by month(can.Created_On)";
            }
            else if (strtype == "Weekly")
            {
                strquery = @"select 'SB'colname, count(*) Submitted,DATEPART(week,can.Created_On) Wkname  from CandidateDetailsIndia can" +
                            " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                            " left join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
                            " where Cand_Status in ('101','102') and can.Created_By like '%" + TWE_id + "%' " +
                            " and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                            " group by DATEPART(week,can.Created_On) " +
                            " union " +
                            " select 'TL'colname,count(*) TL_Selected,DATEPART(week,can.Created_On) Wkname from CandidateDetailsIndia can" +
                            " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                            " join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
                            " where Cand_Status in ('103') and can.Created_By like '%" + TWE_id + "%' " +
                            " and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                            " group by DATEPART(week,can.Created_On) " +
                            " union " +
                            " select 'BP'colname,count(*) BP_Selected,DATEPART(week,can.Created_On) Wkname  from CandidateDetailsIndia can" +
                            " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                            " join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
                            " where Cand_Status in ('105') and can.Created_By like '%" + TWE_id + "%' " +
                            " and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                            " group by DATEPART(week,can.Created_On) " +
                            " union " +
                            " select 'EC'colname,count(*) EC_Selected,DATEPART(week,can.Created_On) Wkname from CandidateDetailsIndia can" +
                            " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                            " join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
                            " where Cand_Status in ('107') and can.Created_By like '%" + TWE_id + "%' " +
                            " and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                            " group by DATEPART(week,can.Created_On)";
            }
            else if (strtype == "Daily")
            {
                strquery = @"select 'SB'colname, count(*) Submitted,datepart(dw,can.Created_On) dyname  from CandidateDetailsIndia can" +
                                   " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                                   " left join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
                                   " where Cand_Status in (101,102,103,104,105,106,107,108,109,110,111)  and can.Created_By like '%" + TWE_id + "%' " +
                                   " and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                                   " group by datepart(dw,can.Created_On) " +
                                   " union " +
                                   " select 'TL'colname,count(*) TL_Selected,datepart(dw,can.Created_On) dyname from CandidateDetailsIndia can" +
                                   " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                                   " join Job_Master_IND job on job.Jobcode = canjob.Jobcode" +
                                   " where Cand_Status >= 103 and can.Created_By like '%" + TWE_id + "%' " +
                                   " and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                                   " group by datepart(dw,can.Created_On) " +
                                   " union " +
                                   " select 'BP'colname,count(*) BP_Selected,datepart(dw,can.Created_On) dyname  from CandidateDetailsIndia can" +
                                   " join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId" +
                                   " join Job_Master_IND job on job.Jobcode = canjob.Jobcode where " +
                                   " Cand_Status in (103,105,106,107,108,109,110,111) and can.Created_By like '%" + TWE_id + "%' " +
                                   " and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                                   " group by datepart(dw,can.Created_On) " +
                                   " union " +
                                   " select 'EC'colname,count(*) EC_Selected,datepart(dw,can.Created_On) dyname from CandidateDetailsIndia can" +
                                   " join CandidateJob canjob on can.candidateid=canjob.CandidateId" +
                                   " join Job_Master_IND job on job.Jobcode = canjob.Jobcode where " +
                                   " Cand_Status in (103,105,107,108,109,110,111) and can.Created_By like '%" + TWE_id + "%' " +
                                   " and can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                                   " group by datepart(dw,can.Created_On) ";
            }
            SqlDataReader _read = _sql.doRead(strquery);
            while (_read.Read())
            {
                linechartlist _lcl = new linechartlist();
                _lcl.colName = _read[0].ToString();
                _lcl.submitted = _read[1].ToString();
                _lcl.itemName = _read[2].ToString();
                _lstline.Add(_lcl);

            }
            _read.Close();

            return _lstline;

        }

        public jsonArray getRecruiterdetailsIndia(string TWE_Id, string fromdate, string todate, string filter)
        {
            int status = 1;
            string query = "";

            candidateOverview objCand = new candidateOverview();
            objCand._lstcandilist = new List<candidatelist>();



             if (filter == "Submission")
            {
                query = @"select can.candidateid,candidatename,candidateemailid,candidatemobileno,ratePerHr,
                        sta.CandidateStatusName Cand_Status,linkedinURL,job.Jobcode,job.JobTitle
                        from CandidateDetailsIndia can
                        left join EmployerDetailsIndia emp on can.employerid=emp.employerid
                        join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId
                        join CandidateStatus_Master sta on sta.CandidateStatusID=canjob.Cand_Status
                        join Userprofile up on can.Created_By=up.TWE_ID
                        left join Job_Master_IND job on job.Jobcode=canjob.Jobcode
                        where can.Created_By like '%" + TWE_Id + "%' and " +
                        "can.Created_On between '" + fromdate + "' and '" + todate + "' " ;
            }


            else if (filter == "TL Submission")
            {
                query = @"select can.candidateid,candidatename,candidateemailid,candidatemobileno,ratePerHr,
                        sta.CandidateStatusName Cand_Status,linkedinURL,job.Jobcode,job.JobTitle
                        from CandidateDetailsIndia can
                        left join EmployerDetailsIndia emp on can.employerid=emp.employerid
                        join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId
                        join CandidateStatus_Master sta on sta.CandidateStatusID=canjob.Cand_Status
                        join Userprofile up on can.Created_By=up.TWE_ID
                        join Job_Master_IND job on job.Jobcode=canjob.Jobcode
                        where can.Created_By like '%" + TWE_Id + "%' and " +
                        "can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                        " and Cand_Status >= 103";
            }

            else if (filter == "BP Submission")
            {
                query = @"select can.candidateid,candidatename,candidateemailid,candidatemobileno,ratePerHr,
                        sta.CandidateStatusName Cand_Status,
                        linkedinURL,job.Jobcode,job.JobTitle
                        from CandidateDetailsIndia can
                        left join EmployerDetailsIndia emp on can.employerid=emp.employerid
                        join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId
                        join CandidateStatus_Master sta on sta.CandidateStatusID=canjob.Cand_Status
                        join Userprofile up on can.Created_By=up.TWE_ID
                        join Job_Master_IND job on job.Jobcode=canjob.Jobcode
                        where can.Created_By like '%" + TWE_Id + "%' and " +
                        "can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                        " and Cand_Status > 103 and Cand_Status!= 104";
            }

            else if (filter == "EC Submission")
            {
                query = @"select can.candidateid,candidatename,candidateemailid,candidatemobileno,ratePerHr,
                        sta.CandidateStatusName Cand_Status,linkedinURL,job.Jobcode,job.JobTitle
                        from CandidateDetailsIndia can
                        left join EmployerDetailsIndia emp on can.employerid=emp.employerid
                         join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId
                        join CandidateStatus_Master sta on sta.CandidateStatusID=canjob.Cand_Status
                        join Userprofile up on can.Created_By=up.TWE_ID
                        join Job_Master_IND job on job.Jobcode=canjob.Jobcode
                        where can.Created_By like '%" + TWE_Id + "%' and " +
                        "can.Created_On between '" + fromdate + "' and '" + todate + "' " +
                        " and Cand_Status > 103 and Cand_Status!= 104 and Cand_Status!= 106";
            }


            else if (filter == "Closures")

            {
                query = @"select can.candidateid,candidatename,candidateemailid,candidatemobileno,ratePerHr,
                        CandidateStatusName Cand_Status,linkedinURL
                        ,jobTitle,job.jobcode
                        from CandidateDetailsIndia can
                        join CandidateJobIndia canjob on can.candidateid=canjob.CandidateId
                        join CandidateStatus_Master sta on sta.CandidateStatusID=canjob.Cand_Status
                        left join EmployerDetailsIndia emp on can.employerid=emp.employerid
                        join Job_Master_IND job on canjob.Jobcode=job.Jobcode 
                        join Userprofile up on can.Created_By=up.TWE_ID
                        where canjob.Created_By='" + TWE_Id + "' and Cand_Status in ('109')" +
                        " and canjob.Created_On between '" + fromdate + "' and '" + todate + "'";
            }

            SqlDataReader _read = _sql.doRead(query);

            while (_read.Read())
            {
                candidatelist candilst = new candidatelist();
                candilst.candidateid = _read[0].ToString();
                candilst.candidatemediapath = "";
                candilst.candidatename = _read[1].ToString();
                candilst.candidateemailid = _read[2].ToString();
                candilst.candidatemobno = _read[3].ToString();
                candilst.ratePerHr = _read[4].ToString();
                candilst.candidatestatus = _read[5].ToString();
                candilst.linkedinURL = _read[6].ToString();
                candilst.jobTitle = _read[8].ToString();
                candilst.jobcode = _read[7].ToString();
                objCand._lstcandilist.Add(candilst);
            }


            _read.Close();

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
                _json.data = objCand;
            }

            return _json;
        }


        public jsonArray insertQuestionheadingmaster(questionheading questionheading)
        {
            int status = 1;
            string query = "";
            if (questionheading.QuestionHeadingid == "")
            {
                query = @"INSERT [QuestionHeading_Master] ([QuestionHeadingname],[OutofMark],Regionid, [Status]) VALUES
           ('" + questionheading.QuestionHeadingname +
           "','" + questionheading.OutofMark +
           "','" + questionheading.Regionid +
           "',"+ questionheading.Status+")";
            }
            else if (questionheading.QuestionHeadingid != "")
            {
                query = @"UPDATE [QuestionHeading_Master]
                           SET [QuestionHeadingname] = '" + questionheading.QuestionHeadingname +
                              "',[OutofMark] = '" + questionheading.OutofMark +
                              "',[Regionid] = '" + questionheading.Regionid +
                              "',[Status] = '" + questionheading.Status +
                              "' WHERE QuestionHeadingid='" + questionheading.QuestionHeadingid + "'";

            }
            _sql.doInsert(query);


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
                _json.data = "";
            }

            return _json;

        }

        public jsonArray getQuestionHeadingdetails(string id)
        {
            int status = 1;

            questionheadingtabledetails _que = new questionheadingtabledetails();
            _que.questionheadings = new List<questionheading>();

            string strquery = "";


            _que.lstRegion = new List<dropDownTemplate>();

            strquery = @"SELECT[Regionid],[Regionname] FROM [Region_Master] where Status=1";

            SqlDataReader _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                _que.lstRegion.Add(new dropDownTemplate
                {
                    ID = _read["Regionid"].ToString(),
                    Name = _read["Regionname"].ToString()
                });
            }
            _read.Close();


            if (id=="")
            {
                strquery = @"select [QuestionHeadingid],[QuestionHeadingname],[OutofMark],[Regionid],[Status] from QuestionHeading_Master where Status!=2";
            }
            else
            {
                strquery = @"select [QuestionHeadingid],[QuestionHeadingname],[OutofMark],[Regionid],[Status] from QuestionHeading_Master where QuestionHeadingid="+id;
            }
           

             _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                questionheading questionheading = new questionheading();
                questionheading.QuestionHeadingid = _read[0].ToString();
                questionheading.QuestionHeadingname = _read[1].ToString();
                questionheading.OutofMark =Convert.ToInt32(_read[2]);
                questionheading.Regionid = Convert.ToInt32(_read[3]);
                questionheading.Status = Convert.ToInt32(_read[4]);

                _que.questionheadings.Add(questionheading);

            }

            _read.Close();

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
                _json.data = _que;
            }

            return _json;
        }

        public jsonArray insertQuestionmaster(question que)
        {
            int status = 1;
            string query = "";
            if (que.Questionid == "")
            {
                query = @"INSERT INTO [Question_Master]
                        ([QuestionHeadingid]
                        ,[Question]
                        ,[Answer]
                        ,[Mark]
                        ,[Status])
                        VALUES
                        ('" + que.QuestionHeadingid +
                        "','" + que.Question +
                        "','" + que.Answer +
                        "','" + que.Mark +
                        "','" + que.Status + "')";
            }
            else if (que.QuestionHeadingid != "")
            {
                query = @"UPDATE [Question_Master]
                        SET [QuestionHeadingid] = '" + que.QuestionHeadingid +
                        "',[Question] = '" + que.Question +
                        "',[Answer] = '" + que.Answer +
                        "',[Mark] = '" + que.Mark +
                        "',[Status] = '" + que.Status +
                        "' WHERE Questionid='" + que.Questionid + "'";

            }
            _sql.doInsert(query);


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
                _json.data = "";
            }

            return _json;

        }

        public jsonArray getQuestiondetails(string id)
        {
            int status = 1;

            questiontabledetails _que = new questiontabledetails();
            _que.question = new List<question>();

            string strquery = "";

            _que.lstquestionTable = new List<dropDownTemplate>();
            _que.lstanswer = new List<dropDownTemplate>();

            strquery = @"select [QuestionHeadingid],[QuestionHeadingname] from QuestionHeading_Master where Status=1";

            SqlDataReader _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                _que.lstquestionTable.Add(new dropDownTemplate
                {
                    ID = _read["QuestionHeadingid"].ToString(),
                    Name = _read["QuestionHeadingname"].ToString()
                });
            }
            _read.Close();

            strquery = @"select [Answerid],[Answervalue] from Answer_Master where Status=1";

            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                _que.lstanswer.Add(new dropDownTemplate
                {
                    ID = _read["Answerid"].ToString(),
                    Name = _read["Answervalue"].ToString()
                });
            }
            _read.Close();


            if (id == "")
            {
                strquery = @"SELECT Questionid,QuestionHeadingid,Question,Answer,Answervalue,Mark,que.Status 
                                FROM Question_Master que
                                join answer_master ans on que.answer=ans.Answerid
                                where que.Status!=2 ";
            }
            else
            {
                strquery = @"SELECT [Questionid],[QuestionHeadingid],[Question],[Answer],[Mark],[Status] FROM [Question_Master] where Questionid=" + id;
            }


            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                question questionheading = new question();
                questionheading.Questionid = _read[0].ToString();
                questionheading.QuestionHeadingid = _read[1].ToString();
                questionheading.Question = _read[2].ToString();               
                questionheading.Answerid = Convert.ToInt32(_read[3]);
                questionheading.Answer = _read[4].ToString();
                questionheading.Mark = Convert.ToInt32(_read[5]);
                questionheading.Status = Convert.ToInt32(_read[6]);

                _que.question.Add(questionheading);

            }

            _read.Close();

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
                _json.data = _que;
            }

            return _json;
        }

        public jsonArray getTotalMarks(string id)
        {
            int status = 1;

            string Totalmarks = "";
            string strquery = "";

            strquery = @"select							
                            (
                            select sum(Mark) TotalMarks FROM Question_Master where QuestionHeadingid="+id+") tb1,"+
                            "(select OutofMark from Questionheading_Master where QuestionHeadingid="+id+") tb2";

            SqlDataReader _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                Totalmarks = _read[0]+"|"+ _read[1];
            }
            _read.Close();

           

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
                _json.data = Totalmarks;
            }

            return _json;
        }

        public jsonArray getGenuinityQuestionlistdetails(string regionid)
        {
            int status = 1;

            questiontabledetails _que = new questiontabledetails();
            _que.question = new List<question>();
            _que.questionheadings = new List<questionheading>();

            string strquery = "";

            strquery = @"select QuestionHeadingid,questionheadingname,outofmark from QuestionHeading_Master where regionid=" + regionid;
            SqlDataReader _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                questionheading questionheading = new questionheading();
                questionheading.QuestionHeadingid= _read[0].ToString();
                questionheading.QuestionHeadingname = _read[1].ToString();
                questionheading.OutofMark = Convert.ToInt32(_read[2]);
                _que.questionheadings.Add(questionheading);
            }           

            strquery = @"SELECT Questionid,Question,Answervalue,Mark,que.QuestionHeadingid
                        FROM Question_Master que join answer_master ans
                        on que.answer=ans.Answerid 
                        join QuestionHeading_Master head on que.QuestionHeadingid=head.QuestionHeadingid
                        where que.Status=1 and regionid=" + regionid;

            _read.Close();

            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                question questionheading = new question();
                questionheading.Questionid = _read[0].ToString();
                questionheading.Question = _read[1].ToString();
                questionheading.Answer = _read[2].ToString();
                questionheading.Mark = Convert.ToInt32(_read[3]);
                questionheading.QuestionHeadingid = _read[4].ToString();
                _que.question.Add(questionheading);

            }

            _read.Close();

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
                _json.data = _que;
            }

            return _json;
        }

        public jsonArray insertGenuinityCheck(candidateGenuinityCheck que)
        {
            int status = 1;
            string candidateid = "";
            string query = "";

            if (que.mode == "I")
            {
                query = @"select candidateid from candidatedetails where candidateemailid='" + que.mailid+"'";
                SqlDataReader _read = _sql.doRead(query);

                while (_read.Read())
                {
                    candidateid = _read[0].ToString();

                }

                _read.Close();
            }

            for (int i = 0; i < que.genuinityChecks.Count; i++)
            {
                if (que.mode == "I")
                {
                    query = @"insert into GenuinityCheck (candidateid,QuestionHeadingid,Questionid,Answer,Comments) values
                        ('" + candidateid +
                        "','" + que.genuinityChecks[i].QuestionHeadingid +
                            "','" + que.genuinityChecks[i].Questionid +
                            "','" + que.genuinityChecks[i].Answer +
                            "','" + que.genuinityChecks[i].Comments + "')";
                }
                else if (que.mode == "U")
                {
                    query = @"UPDATE [GenuinityCheck]
                        SET [QuestionHeadingid] = '" + que.genuinityChecks[i].QuestionHeadingid +
                            "',[Questionid] = '" + que.genuinityChecks[i].Questionid +
                            "',[Answer] = '" + que.genuinityChecks[i].Answer +
                            "',[Comments] = '" + que.genuinityChecks[i].Comments +
                            "' WHERE candidateid='" + que.genuinityChecks[i].candidateid + "'";

                }
                _sql.doInsert(query);
            }

            if (que.mode == "I")
            {
                query = @"insert into GenuinityCheckRating (candidateid,LinkedInrating,Visarating,Educationrating,Overallsystemrating,Overallrecruiterrating,Remarks) values
                        ('" + candidateid +
                        "','" + que.genuinityCheckRating.LinkedInrating +
                        "','" + que.genuinityCheckRating.Visarating +
                        "','" + que.genuinityCheckRating.Educationrating +
                        "','" + que.genuinityCheckRating.Overallsystemrating +
                        "','" + que.genuinityCheckRating.Overallrecruiterrating +
                        "','" + que.genuinityCheckRating.Remarks + "')";
            }
            else if (que.mode == "U")
            {
                query = @"UPDATE [GenuinityCheckRating]
                        SET [LinkedInrating] = '" + que.genuinityCheckRating.LinkedInrating +
                        "',[Visarating] = '" + que.genuinityCheckRating.Visarating +
                        "',[Educationrating] = '" + que.genuinityCheckRating.Educationrating +
                        "',[Overallsystemrating] = '" + que.genuinityCheckRating.Overallsystemrating +
                        "',[Overallrecruiterrating] = '" + que.genuinityCheckRating.Overallrecruiterrating +
                        "',[Remarks] = '" + que.genuinityCheckRating.Remarks +
                        "' WHERE GenuinityCheckID='" + que.genuinityCheckRating.GenuinityCheckRatingID + "'";

            }
            _sql.doInsert(query);           


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
                _json.data = "";
            }

            return _json;

        }

        public jsonArray getGenuinityCandidatedetails(string candidateid)
        {
            int status = 1;

            candidateGenuinityCheck candidateGenuinity = new candidateGenuinityCheck();
            candidateGenuinity.genuinityChecks = new List<GenuinityCheckQuestion>();
            candidateGenuinity.genuinityCheckRating = new GenuinityCheckRating();

            string strquery = "";

            strquery = @"SELECT [GenuinityCheckID],[QuestionHeadingid],[Questionid],[Answer],[Comments]
                                                        FROM [GenuinityCheck] where [candidateid]=" + candidateid;
            SqlDataReader _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                GenuinityCheckQuestion genuinity = new GenuinityCheckQuestion();
                genuinity.GenuinityCheckID = _read[0].ToString();
                genuinity.QuestionHeadingid = _read[1].ToString();
                genuinity.Questionid = _read[2].ToString();
                genuinity.Answer = _read[3].ToString();
                genuinity.Comments = _read[4].ToString();

                candidateGenuinity.genuinityChecks.Add(genuinity);
            }

            _read.Close();

            strquery = @"SELECT [GenuinityCheckRatingID],[LinkedInrating]
                        ,[Visarating],[Educationrating],[Overallsystemrating]
                        ,[Overallrecruiterrating],[Remarks]
                        FROM [GenuinityCheckRating] where [candidateid]=" + candidateid;

            _read.Close();

            _read = _sql.doRead(strquery);

            while (_read.Read())
            {
                
                candidateGenuinity.genuinityCheckRating.GenuinityCheckRatingID = _read[0].ToString();
                candidateGenuinity.genuinityCheckRating.LinkedInrating = _read[1].ToString();
                candidateGenuinity.genuinityCheckRating.Visarating = _read[2].ToString();
                candidateGenuinity.genuinityCheckRating.Educationrating = _read[3].ToString();
                candidateGenuinity.genuinityCheckRating.Overallsystemrating = _read[4].ToString();
                candidateGenuinity.genuinityCheckRating.Overallrecruiterrating = _read[5].ToString();
                candidateGenuinity.genuinityCheckRating.Remarks = _read[6].ToString();               

            }

            _read.Close();

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
                _json.data = candidateGenuinity;
            }

            return _json;
        }


    }
}




