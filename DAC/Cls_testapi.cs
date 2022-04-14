using Recruiting_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recruiting_API.DAC
{
    public class Cls_testapi
    {
        TSql _sql = null;
        public Cls_testapi()
        {
            _sql = new TSql();
        }

        public String insertNewRecord1(string data)
        {

            string[] user_data = data.Split('$');

            string strquery = @"insert into Userprofile ( UP_firstName, UP_lastName, UP_mailid, UP_MT_region, UP_reportingto, UP_MT_designation,  UP_MT_Designationmaster, UP_createdon,UP_userName,UP_Password,TWE_ID,UP_MT_profilestatus  ) 
                                values('" + user_data[0] + "','" + user_data[1] + "','" + user_data[2] + "','" + user_data[3] + "','" + user_data[4] + "','" + user_data[5] + "','" + user_data[6] + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + user_data[7] + "','" + user_data[8] + "','" + user_data[9] + "','" + user_data[10] + "')";
            _sql.doInsert(strquery);
            return "success";

        }

        public jsonArray insertNewFeed(string firstnmae, string lastname, string email, string regioin,
            string reportingto, string role, string designation, string username,
            string password, string userid, string profilestatus)
        {
            //feedtitle = feedtitle.Replace("'", "''");/*single '' replace code */
           

            int status = 1;
            string strquery = @"insert into Userprofile ( UP_firstName, UP_lastName, UP_mailid, UP_MT_region, UP_reportingto, UP_MT_designation,  UP_MT_Designationmaster, UP_createdon,UP_userName,UP_Password,TWE_ID,UP_MT_profilestatus ) 
                               values(" + firstnmae + ",'" + lastname + "','" + email + "','" +
                               regioin + "','" + reportingto + "','" + role + "'," + designation + ",'" +
                               DateTime.Now.ToString("yyyy-MM-dd") + "'," + username + "," + password + ",'" +
                               userid + "','" + profilestatus + "')";

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
                _json.data = new object();
            }


            return _json;
        }
    }
}