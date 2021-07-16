using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BIMFace.SDK.CSharp.Common.Extensions;

using Gloden.Review.AI.HY.SDK.CSharp.API;
using Gloden.Review.AI.HY.SDK.CSharp.Entity;

namespace Gloden.Review.AI.HY.SDK.CSharp.Sample.Pages
{
    public partial class APIDemo2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private string ProjectID = "P-01";

        // 发起智能审查
        protected void btnStartSC_Click(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;

            IAuthorizeApi authApi = new AuthorizeApi();
            string token = authApi.GetToken();

            List<FilesViewModel> lstFiles = new List<FilesViewModel>();
            lstFiles.Add(
                new FilesViewModel
                {
                    FileId = "F-01",
                    FileName = "F-01.rvt",
                    Path = "http://www.spark-ifuture.com/RVT/F-01.rvt"
                });
            lstFiles.Add(
               new FilesViewModel
               {
                   FileId = "F-02",
                   FileName = "F-02.rvt",
                   Path = "http://www.spark-ifuture.com/RVT/F-02.rvt"
               });

            IModelCheckApi modelCheckApi = new ModelCheckApi();
            var response = modelCheckApi.Review(token, ProjectID, lstFiles);

            txtResult.Text = response.SerializeToJson(true);
        }

        // 发起智能审查
        protected void btnQuerySCProgress_Click(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;

            IAuthorizeApi authApi = new AuthorizeApi();
            string token = authApi.GetToken();

            List<string> lstIds = new List<string>();
            lstIds.Add(ProjectID);

            IAbutmentApi abutmentApi = new AbutmentApi();
            var response = abutmentApi.GetModelCheckProgress(token, lstIds);

            txtResult.Text = response.SerializeToJson(true);
        }
    }
}