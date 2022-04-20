using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Recruiting_API.Models
{

    public class Master
    {
        public int key1 { get; set; }
        public int key2 { get; set; }
    }
    public class JsonReturn
    {
        public string key { get; set; }
        public string kpi { get; set; }
        public object value { get; set; }

    }


    public class MasterFileUploadData
    {
        public string fileName { get; set; }
        public string status { get; set; }
    }

    public class jsonData
    {
        public object d { get; set; }
    }
    public class jsonArray
    {
        public string status { get; set; }
        public string message { get; set; }
        public object data { get; set; }
    }

    public class dashboardTimer
    {
        public List<RecruitingTimeZone> Timezonelist { get; set; }
    }

    public class dropDownTemplate
    {
        public string ID { get; set; }
        public string Name { get; set; }
    }

    public class RecruitingTimeZone
    {
        public string TimeZoneName { get; set; }
        public string TimeZoneDay { get; set; }
        public string TimeZoneDate { get; set; }
        public string TimeZoneTime { get; set; }
    }

    public class dashboard
    {
        public string userid { get; set; }

        public string TWE_ID { get; set; }
        public string name { get; set; }
        public string region { get; set; }

        public string rolename { get; set; }

        public string emailid { get; set; }

        public string designation { get; set; }


        public string jobAccess { get; set; }
        public string jobCreation { get; set; }
        public string jobEdit { get; set; }
        public string jobView { get; set; }
        public string jobFeedback { get; set; }
        public string candidateAccess { get; set; }
        public string candCreation { get; set; }
        public string candEdit { get; set; }
        public string candView { get; set; }
        public string vendorAccess { get; set; }
        public string vendCreation { get; set; }
        public string vendEdit { get; set; }
        public string vendView { get; set; }

        /**Dashboard page**/

        public List<string> TileCount { get; set; }
          
        public List<string> ChartData { get; set; }
        public List<string> ProgressbarCount { get; set; }
        public List<Jobcode> Joblist { get; set; }
        public List<string> OverviewCount { get; set; }

    }

    public class JobMaster
    {
        public List<tiles> lsttiles { get; set; }
        public List<JobcodeList> lstJob { get; set; }
    }

    public class Jobcode
    {
        public string Jobcodename { get; set; }
        public string JobTitle { get; set; }
        public string Duration { get; set; }
        public string EmplType { get; set; }
        public string Location { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Clientname { get; set; }
        public string Contactname { get; set; }
        public string Description { get; set; }
        public string AssignedTo { get; set; }
        public string Prioritylevel { get; set; }
        public string Jobstatus { get; set; }

        public string Rate1 { get; set; }
        public string WorkType1 { get; set; }
        public string Currency1 { get; set; }
        public string Rate2 { get; set; }
        public string WorkType2 { get; set; }
        public string Currency2 { get; set; }
        public string Skill { get; set; }            
        public string Jobopendate { get; set; }          
        public string Jobclosedate { get; set; }
        public string OpenComments { get; set; }
        public string CloseComments { get; set; }
        public string Jobimage { get; set; }
        public string Created_By { get; set; }
        public string Created_On { get; set; }
        public string Created_Time { get; set; }
        public string Updated_By { get; set; }
        public string Updated_By_ID { get; set; }
        public string Updated_On { get; set; }
        public string Updated_Time { get; set; }
        public string Publish_Web { get; set; }
        public string Mode { get; set; }
        
    }

    public class listarray
    {
        public string Jobcodename { get; set; }
        public List<dropDownTemplate> lstClient { get; set; }
        public List<dropDownTemplate> lstClicontact { get; set; }
        public List<dropDownTemplate> lstPriority { get; set; }
        public List<dropDownTemplate> lstEmployee { get; set; }
        public List<dropDownTemplate> lstJobstatus { get; set; }
        public List<dropDownTemplate> lstCurrency { get; set; }
        public List<dropDownTemplate> lstType { get; set; }

        public List<dropDownTemplate> lstrateType { get; set; }
        public List<dropDownTemplate> lstEmploymentType { get; set; }
        public List<dropDownTemplate> lstLocation { get; set; }
        public List<dropDownTemplate> lstTechnology { get; set; }
        public List<dropDownTemplate> lstSkill { get; set; }
        public List<dropDownTemplate> lstManager { get; set; }
        public List<dropDownTemplate> lstTeamlead { get; set; }
    }


    public class Recrutingdashboard
    {
        public string TWE_id { get; set; }
        public string UserName { get; set; }
        public string Roleid { get; set; }
        public string UserProfile { get; set; }
        public string DateRange { get; set; }
        public object Tiles { get; set; }
        public object HoldResumeTiles { get; set; }
        public string Barchart { get; set; }
        public string BarTitle { get; set; }
        public string BarDuration { get; set; }
        public object StatusCount { get; set; }
        public string Linechart { get; set; }
        public string LinechartTitle { get; set; }
        public string LineDuration { get; set; }
        public string RecentRecuitmentTitle { get; set; }
        public string RecentRecuitmentCount { get; set; }
        public object RecuitmentTable { get; set; }
        public string OverviewTitle { get; set; }
        public string OverViewPercentage { get; set; }
        public object PerformaceOverView { get; set; }
        public List<targetfixingMstr> lstTarget { get; set; }
        public List<targetfixingMstr> lstprevTarget { get; set; }
        public List<JobcodeList> lstJob { get; set; }
        public List<dropDownTemplate> lstRemarks { get; set; }
        public TeamPerfomanceFeedback Feedback { get; set; }

    }

    public class tiles
    {
        public string TileTitle { get; set; }
        public string TotalCount { get; set; }
        public string Name { get; set; }
        public string AchiveCount { get; set; }
    }

    public class holdresumetiles
    {
        public string FirstHeading { get; set; }
        public string SecondHeading { get; set; }
        public string ThirdHeading { get; set; }
        public string Count { get; set; }
    }

    public class statuscount
    {
        public string StatusTitle { get; set; }
        public string StatusValue { get; set; }
    }


    public class recruitmenttable
    {
        public string RecruitmentId { get; set; }
        public string JobMediaPath { get; set; }
        public string JobName { get; set; }
        public string JobDuration { get; set; }
        public string JobState { get; set; }
        public string JobCity { get; set; }
        public string JobType { get; set; }
        public string JobClient { get; set; }
        public string JobSubmission { get; set; }

    }
    public class performanceoverview
    {
        public string PerformanceName { get; set; }
        public string PerformanceCount { get; set; }
    }

    public class JobcodeList
    {
        public string Jobcode { get; set; }
        public string JobMediaPath { get; set; }
        public string JobTitle { get; set; }
        public string JobDuration { get; set; }
        public string JobType { get; set; }
        public string JobCity { get; set; }
        public string JobState { get; set; }        
        public string JobStatus { get; set; }
        public string JobClient { get; set; }
        public string JobContact { get; set; }
        public string JobRate { get; set; }
        public string JobCountry { get; set; }
        public string CreatedOn { get; set; }
        public string Assigned_To { get; set; }

    }

    public class candidatelistDetails : Jobcode
    {
        public object candidatelistinfo { get; set; }

    }
    public class candidatelist
    {
        public string candidateid { get; set; }
        public string candidatename { get; set; }
        public string candidatemediapath { get; set; }
        public string candidateemailid { get; set; }
        public string candidatemobno { get; set; }
        public string ratePerHr { get; set; }
        public string type { get; set; }

        public string linkedinURL { get; set; }
        public string vendorname { get; set; }
        public string vendoremailid { get; set; }
        public string candidatestatus { get; set; }
        public string submittedby { get; set; }
        public string submitteddate { get; set; }
        public string submittedtime { get; set; }
        public string jobcode { get; set; }
        public string jobTitle { get; set; }

        public string currLocation { get; set; }

        public string totYrsExp { get; set; }

    }

    public class Candidatedetails
    {
        public string candidateid { get; set; }
        public string jobcode { get; set; }
        public string candidateemailid { get; set; }
        public string candidatemobileno { get; set; }
        public string candidatename { get; set; }
        public string currentLocation { get; set; }
        public string visastatus { get; set; }
        public string yrsofexp { get; set; }
        public string ratecoverage { get; set; }
        public string relocate { get; set; }
        public string documenttype { get; set; }
        public string idNo { get; set; }
        public string ratePerHr { get; set; }
        public string type { get; set; }
        public string skillsandCertif { get; set; }
        public string linkedinURL { get; set; }
        public string noticePeriod { get; set; }
        public string availableforinterview { get; set; }
        public string employerid { get; set; }
        public string employermailid { get; set; }
        public string employerContactno { get; set; }
        public string employeename { get; set; }
        public string employerspecialization { get; set; }
        public string corporationname { get; set; }
        public string employeradderinformation { get; set; }
        public string candidateRemark { get; set; }
        public string createdBy { get; set; }
        public string createdOn { get; set; }
        public string createdTime { get; set; }
        public string lastupdatedOn { get; set; }
        public string lastupdatedBy { get; set; }
        public string updatedTime { get; set; }
        public string candStatus { get; set; }
        public string rtrStatus { get; set; }
        public string jobtitle { get; set; }
        public string jobduration { get; set; }
        public string jobempltype { get; set; }
        public string joblocation { get; set; }
        public string jobimage { get; set; }
        public string recruiterrating { get; set; }
        public string mode { get; set; }
        public List<candidateProof> lstCandProof { get; set; }
        public string genuinityStatus { get; set; }
    }

    public class candidateProof
    {
        public string candproofid { get; set; }
        public string candidateid { get; set; }
        public string documenttype { get; set; }
        public string idNo { get; set; }
        public string idfilename { get; set; }
        public string mode { get; set; }
    }

    public class Employerdetails
    {
        public string employerid { get; set; }
        public string employeremailid { get; set; }
        public string employermobileno { get; set; }
        public string employername { get; set; }
        public string employercorporationname { get; set; }
        public string employerspecialization { get; set; }
        public string employeradditionalinfo { get; set; }
    }

        public class barchartlist
    {
        public string itemName { get; set; }
        public string candCount { get; set; }
    }

    public class linechartlist
    {
        public string colName { get; set; }
        public string submitted { get; set; }
        public string itemName { get; set; }
    }


    public class mailInfo
    {
        public string fromAddr { get; set; }
        public string ccAddr { get; set; }
        public string toAddr { get; set; }
        public string subject { get; set; }
        public string Description { get; set; }
        public string jobcode { get; set; }
        public string candidateemailid { get; set; }
        public string employeremaildid { get; set; }

    }


    public class JobcodeIndia
    {
        public string Jobcodename { get; set; }
        public string JobTitle { get; set; }
        public string Duration { get; set; }
        public string EmplType { get; set; }
        public string Location { get; set; }
        public string Country { get; set; }
        public string Startdate { get; set; }
        public string Noofopening { get; set; }
        public string ShiftTiming { get; set; }
        public string TurnAroundtime { get; set; }        
        public string Clientname { get; set; }
        public string Contactname { get; set; }
        public string Description { get; set; }
        public string AssignedTo { get; set; }
        public string Prioritylevel { get; set; }
        public string Jobstatus { get; set; }
        public string Minrate { get; set; }
        public string Maxrate { get; set; }
        public string Ratetype { get; set; }
        public string Currency { get; set; }
        public string Skill { get; set; }
        public string Jobopendate { get; set; }
        public string Jobclosedate { get; set; }
        public string OpenComments { get; set; }
        public string CloseComments { get; set; }
        public string Jobimage { get; set; }
        public string Created_By { get; set; }
        public string Created_On { get; set; }
        public string Created_Time { get; set; }
        public string Updated_By { get; set; }
        public string Updated_By_ID { get; set; }
        public string Updated_On { get; set; }
        public string Updated_Time { get; set; }
        public string Mode { get; set; }
        public string Publish_Web { get; set; }
    }

    public class CandidatedetailsIndia
    {
        public string candidateid { get; set; }
        public string jobcode { get; set; }
        public string candidateemailid { get; set; }
        public string candidatemobileno { get; set; }
        public string candidatename { get; set; }
        public string currentLocation { get; set; }
        public string TotYearsofExp { get; set; }
        public string yrsofexp { get; set; }
        public string currcompany { get; set; }
        public string startdate { get; set; }
        public string enddate { get; set; }
        public string ratePerHr { get; set; }
        public string type { get; set; }
        public string skillsandCertif { get; set; }
        public string linkedinURL { get; set; }
        public string noticePeriod { get; set; }
        public string availableforinterview { get; set; }
        public string employerid { get; set; }
        public string employermailid { get; set; }
        public string employerContactno { get; set; }
        public string employeename { get; set; }
        public string employerspecialization { get; set; }
        public string corporationname { get; set; }
        public string employeradderinformation { get; set; }
        public string candidateRemark { get; set; }

        public string recruiterrating { get; set; }
        public string createdBy { get; set; }
        public string createdOn { get; set; }
        public string createdTime { get; set; }
        public string lastupdatedOn { get; set; }
        public string lastupdatedBy { get; set; }
        public string updatedTime { get; set; }
        public string candStatus { get; set; }
        public string rtrStatus { get; set; }
        public string jobtitle { get; set; }
        public string jobduration { get; set; }
        public string jobempltype { get; set; }
        public string joblocation { get; set; }
        public string jobimage { get; set; }

        public string shiftTime { get; set; }
        public string mode { get; set; }
        public string RTRemailstatus { get; set; }
        public List<candidateProof> lstCandProof { get; set; }
    }

    public class candidatelistDetailsIndia : JobcodeIndia
    {
        public object candidatelistinfo { get; set; }

    }

    public class candidatelistIndia
    {
        public string candidateid { get; set; }
        public string candidatename { get; set; }
        public string candidatemediapath { get; set; }
        public string candidateemailid { get; set; }
        public string candidatemobno { get; set; }
        public string ratePerHr { get; set; }
        public string type { get; set; }
        public string currentLocation { get; set; }
        public string TotYearsofExp { get; set; }
        public string linkedinURL { get; set; }
        public string vendorname { get; set; }
        public string vendoremailid { get; set; }
        public string candidatestatus { get; set; }
        public string submittedby { get; set; }
        public string submitteddate { get; set; }
        public string submittedtime { get; set; }

    }

    public class candidateOverview
    {
        public List<tiles> _lstTile { get; set; }
        public List<candidatelist> _lstcandilist { get; set; }
        public List<JobcodeList> _lstJob { get; set; }

    }

    public class candidateProfileview
    {
        public Candidatedetails candDetail { get; set; }
        public string negativerating { get; set; }
        public string positiverating { get; set; }

        public List<JobcodeList> _lstJob { get; set; }
        public List<JobcodeList> _lstMatchJob { get; set; }
        public List<candidateProof> _lstCandProof { get; set; }
        public List<candidateComments> _lstFeedback { get; set; }
        public List<JobcodeList> _lstAssignedJob { get; set; }
        public List<dropDownTemplate> _lstdrpJob { get; set; }

    }

    public class candidateComments : Candidatedetails
    {
        public string candstatusid { get; set; }
        public string candcommentid { get; set; }
        public string emplType { get; set; }
        public string duration { get; set; }
        public string jobstatus { get; set; }
        public string jobcreatedBy { get; set; }
        public string jobcreatedOn { get; set; }
        public string jobcreatedTime { get; set; }
        public string TLComments { get; set; }
        public string TLRating { get; set; }
        public string TLcomgivenby { get; set; }
        public string TLcomgivenon { get; set; }
        public string TLcomgiventime { get; set; }
        public string TLcomupdatedby { get; set; }
        public string TLcomupdatedon { get; set; }
        public string TLcomupdatedtime { get; set; }
        public string BPComments { get; set; }
        public string BPcomgivenby { get; set; }
        public string BPcomgivenon { get; set; }
        public string BPcomgiventime { get; set; }
        public string BPcomupdatedby { get; set; }
        public string BPcomupdatedon { get; set; }
        public string BPcomupdatedtime { get; set; }
        public string BPIstartdate { get; set; }
        public string BPITime { get; set; }
        public string BPIcomgivenby { get; set; }
        public string BPIcomgivenon { get; set; }
        public string BPIcomgiventime { get; set; }
        public string BPIcomupdatedby { get; set; }
        public string BPIcomupdatedon { get; set; }
        public string BPIcomupdatedtime { get; set; }
        public string ECComments { get; set; }
        public string ECcomgivenby { get; set; }
        public string ECcomgivenon { get; set; }
        public string ECcomgiventime { get; set; }
        public string ECcomupdatedby { get; set; }
        public string ECcomupdatedon { get; set; }
        public string ECcomupdatedtime { get; set; }
        public string ECIstartdate { get; set; }
        public string ECITime { get; set; }
        public string ECIcomgivenby { get; set; }
        public string ECIcomgivenon { get; set; }
        public string ECIcomgiventime { get; set; }
        public string ECIcomupdatedby { get; set; }
        public string ECIcomupdatedon { get; set; }
        public string ECIcomupdatedtime { get; set; }
        public string RecruiterComments { get; set; }
        public string CLComments { get; set; }
        public string CLcomgivenby { get; set; }
        public string CLcomgivenon { get; set; }
        public string CLcomgiventime { get; set; }
        public string CLcomupdatedby { get; set; }
        public string CLcomupdatedon { get; set; }
        public string CLcomupdatedtime { get; set; }

    }

    public class feedbackmaster
    {
        public string profilepic { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string location { get; set; }
        public object range { get; set; }
        public object projects { get; set; }
        public object feedbackdetails { get; set; }

    }

    public class range
    {
        public string negativepercentage { get; set; }
        public string positivepercentage { get; set; }

    }

    public class assignedJob
    {
        public string logo { get; set; }
        public string jobid { get; set; }
        public string name { get; set; }
    }
    public class feedbackdetails
    {
        public string logo { get; set; }
        public string prjname { get; set; }
        public string duration { get; set; }
        public string type { get; set; }
        public string worktype { get; set; }
        public string rateperhr { get; set; }
        public string ratetype { get; set; }
        public string createdby { get; set; }
        public string createddate { get; set; }
        public object trackprofile { get; set; }
        public object feedback { get; set; }
        public object interview { get; set; }
    }
    public class trackprofile
    {
        public string title { get; set; }
        public string status { get; set; }
        public string date { get; set; }
        public string time { get; set; }
    }

    public class feedback
    {
        public string toggle { get; set; }
        public string commands { get; set; }
        public string createdondate { get; set; }
        public string creratedtime { get; set; }
        public string updateddata { get; set; }
        public string updatedtime { get; set; }
    }

    public class interview
    {
        public string toggle { get; set; }
        public string state { get; set; }
        public string time { get; set; }
        public string createdondate { get; set; }
        public string creratedtime { get; set; }
        public string updateddata { get; set; }
        public string updatedtime { get; set; }

    }

}

public class master
{
    public string masterid { get; set; }
    public string mastername { get; set; }
    public string masterdetaila { get; set; }
    public string masterstatus { get; set; }
}

public class vendorsearch
{
    public string vendorid { get; set; }
    public string vendorname { get; set; }
    public string specilization { get; set; }
    public string noofrecruiter { get; set; }
    public string city { get; set; }
    public string country { get; set; }
    public string status { get; set; }

    public string createdby { get; set; }

    public string vendormailid { get; set; }
    public List<vendorsearch> lstContact { get; set; }
}

public class vendorlist
{
    public string vendorid { get; set; }
    public string vendorname { get; set; }
    public string noofrecruiter { get; set; }
    public string status { get; set; }
    public string submittedby { get; set; }
    public List<vendorlist> lstVen { get; set; }

}

public class vendor
{
    public string employercorporationaname { get; set; }
    public string website { get; set; }
    public string linkedin { get; set; }
    public string employerspecialization { get; set; }
    public string employeradditionalinfo { get; set; }
    public string address { get; set; }
    public string city { get; set; }
    public string country { get; set; }
    public string Created_On { get; set; }
    public string Created_By { get; set; }
    public string Updated_On { get; set; }
    public string CreatedOn { get; set; }
    public string UpdatedOn { get; set; }
    public string Updated_By { get; set; }
    public string Status { get; set; }
    public string employerid { get; set; }
    public string vendortype { get; set; }
    public string placeofsupply { get; set; }

    public List<vendorcontact> lstVencontact { get; set; }
}

 public class vendorcontact
{
    public string mode { get; set; }
    public string vencontactid { get; set; }
    public string contactname { get; set; }
    public string employeremailid { get; set; }
    public string employermobileno { get; set; }
    public string employerremarks { get; set; }
    public string vendorid { get; set; }
    public string venConstatus { get; set; }
}

public class Userprofilecreaton
{
    public object basicinfo { get; set; }
    public object supportaccess { get; set; }
    public object account { get; set; }
    public string jobs { get; set; }
    public object candidate { get; set; }
    public object vendor { get; set; }
    public object targetfixingMstr { get; set; }
    public object report { get; set; }

    public RoleMenu MenuAccess { get; set; }

    public List<BasiInfo> LstbasicInfo { get; set; }
    //public object notification { get; set; }

}
public class BasiInfo
{   
    public string TWE_ID { get; set; }
    public string userid { get; set; }
    public string firstname { get; set; }
    public string lastname { get; set; }
    public string gender { get; set; }
    public string dob { get; set; }
    public string email { get; set; }
    public string confirmationemail { get; set; }
    public string location { get; set; }
    public string phoneno { get; set; }
    public string language { get; set; }
    public string designation { get; set; }
    public string region { get; set; }
    public string role { get; set; }
    public string level { get; set; }

}
public class SupportAccess
{
    public string region { get; set; }
    public string monster { get; set; }
    public string textnow { get; set; }

}
public class Account
{
    public string role { get; set; }
    public string level { get; set; }
    public string personalizedashboard { get; set; }
    public string reportingmanager { get; set; }
    public string reportingTL { get; set; }


}

public class targetfixing
{
    public string targetfixingid { get; set; }
    public string candidateadding { get; set; }
    public string vendorcreation { get; set; }
    public string submission { get; set; }
    public string TLApproval { get; set; }
    public string BPApproval { get; set; }
    public string ECApproval { get; set; }
}
public class RoleAccess
{
    public string creation { get; set; }
    public string edit { get; set; }
    public string view { get; set; }
    public string feedback { get; set; }
}

public class userprofileinsert
{
    public string firstname { get; set; }
    public string lastname { get; set; }
    public string gender { get; set; }
    public string dob { get; set; }
    public string emailid { get; set; }
    public string confirmationemail { get; set; }
    public string location { get; set; }
    public string phoneno { get; set; }
    public string language { get; set; }
    public string designation { get; set; }
    public string region { get; set; }
    public string monsterusername { get; set; }
    public string monsterpassword { get; set; }
    public string textnow { get; set; }
    public string username { get; set; }
    public string password { get; set; }
    public string reportingmanager { get; set; }
    public string reportingTL { get; set; }
    public string status { get; set; }


}

public class menuaccess
{
    public string designationid { get; set; }
    public string menutype { get; set; }
    public string menuadd { get; set; }
    public string menuedit { get; set; }
    public string menuview { get; set; }
    public string menudelete { get; set; }
}

public class dropdownlist
{
    public List<dropdowndata> Designation { get; set; }
    public List<dropdowndata> Gender{ get; set; }
    public List<dropdowndata> Reportingmanager { get; set; }
    public List<dropdowndata> ReporingTL { get; set; }
    public List<dropdowndata> Role { get; set; }
    public List<dropdowndata> Level { get; set; }
    public List<dropdowndata> Language { get; set; }
}

public class dropdowndata
{
    public string drpid { get; set; }
    public string drpname { get; set; }
}

public class TargetFixing
{
    public string TargetID { get; set; }
    public string TargetType { get; set; }
    public string RoleType { get; set; }
    public string TargetValue { get; set; }
    public string LevelType { get; set; }
    
}

public class menuaccesspermision : RoleMenu
{
    public string menuaccessid { get; set; }
    public string roleid { get; set; }
    public string regionid { get; set; }

}


public class questionheading
{
    public string QuestionHeadingid { get; set; }
    public string QuestionHeadingname { get; set; }
    public int OutofMark { get; set; }
    public int Regionid { get; set; }
    public string Regionname { get; set; }
    public int Status { get; set; }
}

public class questionheadingtabledetails
{
    public List<questionheading> questionheadings { get; set; }
    public List<Recruiting_API.Models.dropDownTemplate> lstRegion { get; set; }

}

public class question
{
    public string Questionid { get; set; }
    public string QuestionHeadingid { get; set; }
    public string Question { get; set; }
    public int Answerid { get; set; }
    public string Answer { get; set; }
    public int Mark { get; set; }    
    public int Status { get; set; }
}

public class questiontabledetails
{
    public List<questionheading> questionheadings { get; set; }
    public List<question> question { get; set; }
    public List<Recruiting_API.Models.dropDownTemplate> lstquestionTable { get; set; }

    public List<Recruiting_API.Models.dropDownTemplate> lstanswer { get; set; }

}

public class RoleMenu
{
    public string jobAccess { get; set; }
    public string jobCreation { get; set; }
    public string jobEdit { get; set; }
    public string jobView { get; set; }
    public string jobFeedback { get; set; }
    public string candidateAccess { get; set; }
    public string candidateCreation { get; set; }
    public string candidateView { get; set; }
    public string candidateEdit { get; set; }
    public string vendorAccess { get; set; }
    public string vendorCreation { get; set; }
    public string vendorEdit { get; set; }
    public string vendorView { get; set; }
    public string reportAccess { get; set; }
    public string Status { get; set; }


}
public class Imagemaster
{
    public string imageid { get; set; }
    public string technologyname { get; set; }
    public string path { get; set; }
    public string status { get; set; }
}

public class targetfixingMstr
{
    public string TargetfixingId { get; set; }
    public string RoleType { get; set; }
    public string LevelType { get; set; }
    public string RegionType { get; set; }
    public string SubmissiontoTL_Daily { get; set; }
    public string Submission_Daily { get; set; }
    public string SubmissiontoBP_Daily { get; set; }
    public string SubmissiontoEC_Daily { get; set; }
    public string Closure_Daily { get; set; }
    public string Vendor_Daily { get; set; }
    public string Submission_Monthly { get; set; }
    public string SubmissiontoTL_Monthly { get; set; }
    public string SubmissiontoBP_Monthly { get; set; }
    public string SubmissiontoEc_Monthly { get; set; }
    public string Closure_Monthly { get; set; }
    public string Vendor_Monthly { get; set; }
    public string Submission_Weekly { get; set; }
    public string SubmissiontoTL_Weekly { get; set; }
    public string SubmissiontoBP_Weekly { get; set; }
    public string Closure_Weekly { get; set; }
    public string Vendor_Weekly { get; set; }
    public string SBPercentage { get; set; }
    public string TLPercentage { get; set; }
    public string BPPercentage { get; set; }
    public string CLPercentage { get; set; }
}


public class teamlist
{
    public string Username { get; set; }
    public string Role { get; set; }
    public string Userid { get; set; }
    public string Roleid { get; set; }
    public string Profileimg { get; set; }
}

public class TeamPerfomanceFeedback
{
    public string Teamperfomanceid { get; set; }
    //public string candidatetarget { get; set; }
    //public string candidateAchieved { get; set; }
    //public string candidateRemarks { get; set; }
    //public string vendorTarget { get; set; }
    //public string vendorAchieved { get; set; }
    //public string vendorRemarks { get; set; }
    public string submittiontarget { get; set; }
    public string submittionAchieved { get; set; }
    public string submittionRemarks { get; set; }
    public string SubmissionPercentage { get; set; }
    public string TLApprovalTarget { get; set; }
    public string TLApprovalAchieved { get; set; }
    public string TLPercentage { get; set; }
    public string TLApprovalRemarks { get; set; }
    public string BPApprovalTarget { get; set; }
    public string BPApprovalAchieved { get; set; }
    public string BPPercentage { get; set; }
    public string BPApprovalRemarks { get; set; }
    public string ClosureTarget { get; set; }
    public string ClosureAchieved { get; set; }
    public string ClosurePercentage { get; set; }
    public string ClosureRemarks { get; set; }
    public string OverallRating { get; set; }
    public string Remarks { get; set; }
    public string status { get; set; }
    public string TWEID { get; set; }
    public string Weekinfo { get; set; }
    public string Feedback_givenby { get; set; }
    public string Feedback_givenon { get; set; }
    public string Feedback_updatedby { get; set; }
    public string Feedback_updatedon { get; set; }
}

public class Feedbackstatus
{
    public string Weekinfo { get; set; }
    public string status { get; set; }
}

public class GenuinityCheckQuestion
{
    public string GenuinityCheckID { get; set; }
    public string candidateid { get; set; }
    public string QuestionHeadingid { get; set; }
    public string Questionid { get; set; }
    public string Answer { get; set; }
    public string Question { get; set; }
    public string Comments { get; set; }
}

public class GenuinityCheckRating
{
    public string GenuinityCheckRatingID { get; set; }
    public string candidateid { get; set; }
    public string LinkedInrating { get; set; }
    public string Visarating { get; set; }
    public string Educationrating { get; set; }
    public string Overallsystemrating { get; set; }
    public string Overallrecruiterrating { get; set; }
    public string Remarks { get; set; }
}

public class candidateGenuinityCheck
{
    public string mode { get; set; }
    public string mailid { get; set; }
    public GenuinityCheckRating genuinityCheckRating { get; set; }
    public List<GenuinityCheckQuestion> genuinityChecks { get; set; }
}