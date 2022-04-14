using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Recruiting_API
{
    public partial class RecruitingApp : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //ClearCacheItems();
            }
            
        }

        public void ClearCacheItems()
        {
            List<string> keys = new List<string>();
            System.Collections.IDictionaryEnumerator enumerator = Cache.GetEnumerator();

            while (enumerator.MoveNext())
                keys.Add(enumerator.Key.ToString());

            for (int i = 0; i < keys.Count; i++)
                Cache.Remove(keys[i]);
        }
    }
}