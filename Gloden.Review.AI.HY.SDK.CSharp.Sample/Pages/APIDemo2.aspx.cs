using System;
using System.Collections.Generic;

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
        private string ProjectID2 = "P-00003927";
        private string ProjectID22 = "P2-00003927";

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
                    FileId = "M-01",
                    FileName = "M1.rvt",
                    Path = "http://www.spark-ifuture.com/RVT/00003927/M1.rvt"
                });
            lstFiles.Add(
               new FilesViewModel
               {
                   FileId = "M-02",
                   FileName = "M2.rvt",
                   Path = "http://www.spark-ifuture.com/RVT/00003927/M2.rvt"
               });

            //lstFiles.Add(
            //   new FilesViewModel
            //   {
            //       FileId = "1152086",
            //       FileName = "建筑总平面图20210719174353920.rvt",
            //       Path = "http://www.spark-ifuture.com/RVT/00003927/建筑总平面图20210719174353920.rvt"
            //   });

            //lstFiles.Add(
            //  new FilesViewModel
            //  {
            //      FileId = "1152090",
            //      FileName = "电器120210719174356459.rv",
            //      Path = "http://www.spark-ifuture.com/RVT/00003927/电器120210719174356459.rvt"
            //  });

            //lstFiles.Add(
            //  new FilesViewModel
            //  {
            //      FileId = "1152087",
            //      FileName = "建筑120210719174354936.rvt",
            //      Path = "http://www.spark-ifuture.com/RVT/00003927/建筑120210719174354936.rvt"
            //  });

            //lstFiles.Add(
            //  new FilesViewModel
            //  {
            //      FileId = "1152088",
            //      FileName = "结构120210719174354396.rvt",
            //      Path = "http://www.spark-ifuture.com/RVT/00003927/结构120210719174354396.rvt"
            //  });

            //lstFiles.Add(
            //  new FilesViewModel
            //  {
            //      FileId = "1152089",
            //      FileName = "给排水1 污水管.20210719174355856.rvt",
            //      Path = "http://www.spark-ifuture.com/RVT/00003927/给排水1 污水管.20210719174355856.rvt"
            //  });


            IModelCheckApi modelCheckApi = new ModelCheckApi();
            var response = modelCheckApi.Review(token, ProjectID22, lstFiles);

            txtResult.Text = response.SerializeToJson(true);
        }

        // 检查模型审查进度
        protected void btnQuerySCProgress_Click(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;

            IAuthorizeApi authApi = new AuthorizeApi();
            string token = authApi.GetToken();

            IAbutmentApi abutmentApi = new AbutmentApi();
            var response = abutmentApi.GetModelCheckProgress(token, txtSCID.Text);

            txtResult.Text = response.SerializeToJson(true);
        }
    }
}