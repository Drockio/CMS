using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CMS.Models
{
    public class CMSPage : DAL
    {
        public int PageId { get; set; }
        public string ContentKey { get; set; }
        public string Param1 { get; set; }
        public string Param2 { get; set; }
        public string Title { get; set; }
        public string PageContent { get; set; }
        public string HeadContent { get; set; }
        public string ScriptBlock { get; set; }
        public DateTime DateModified { get; set; }

        public CMSPage GetPage(string pageName)
        {
            var pages = GetPages();
            return pages.FirstOrDefault(x => x.ContentKey.ToLower() == pageName.ToLower());
        }

        public List<CMSPage> GetPages()
        {
            var pages = new List<CMSPage>();

            var dt = GetDTFromStoredProc("page_select", new List<SqlParameter> { });
            foreach (DataRow dr in dt.Rows)
            {
                var page = new CMSPage();
                page.PageId = Convert.ToInt32(dr["pageId"].ToString());
                page.ContentKey = dr["ContentKey"].ToString();
                page.Title = dr["Title"].ToString();
                page.PageContent = dr["PageContent"].ToString();
                page.HeadContent = dr["HeadContent"].ToString();
                page.ScriptBlock = dr["ScriptBlock"].ToString();
                page.ScriptBlock = dr["MetaContent"].ToString();
                page.ScriptBlock = dr["PrimaryMenu"].ToString();
                page.ScriptBlock = dr["AuxMenu"].ToString();
                page.DateModified = Convert.ToDateTime(dr["DateModified"]);
                pages.Add(page);
            }

            return pages;
        }
    }
}