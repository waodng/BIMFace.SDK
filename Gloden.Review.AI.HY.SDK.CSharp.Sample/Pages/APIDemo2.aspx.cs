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
        private string ProjectID2 = "P-02";
        private string ProjectID22 = "P-03";

        // 发起智能审查
        protected void btnStartSC_Click(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;

            IAuthorizeApi authApi = new AuthorizeApi();
            string token = authApi.GetToken();

            List<FilesViewModel> lstFiles = new List<FilesViewModel>();
           
            #region 
            //lstFiles.Add(
            //    new FilesViewModel
            //    {
            //        FileId = "M-01",
            //        FileName = "M1.rvt",
            //        Path = "http://www.spark-ifuture.com/RVT/00003927/M1.rvt"
            //    });
            //lstFiles.Add(
            //   new FilesViewModel
            //   {
            //       FileId = "M-02",
            //       FileName = "M2.rvt",
            //       Path = "http://www.spark-ifuture.com/RVT/00003927/M2.rvt"
            //   });

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


            //lstFiles.Add(
            //    new FilesViewModel
            //    {
            //        FileId = "T-01",
            //        FileName = "T-01-2F建筑20210722144051159.rvt",
            //        Path = "http://www.spark-ifuture.com/RVT/00003928/2F建筑20210722144051159.rvt"
            //    });
            //lstFiles.Add(
            //   new FilesViewModel
            //   {
            //       FileId = "T-02",
            //       FileName = "T-02-2F装修20210722144119264.rvt",
            //       Path = "http://www.spark-ifuture.com/RVT/00003928/2F装修20210722144119264.rvt"
            //   });

            #endregion

            lstFiles.Add(
              new FilesViewModel
              {
                  FileId = "F1-20210727-10",
                  FileName = "翡翠湖别院_G8_建筑_2019_10_17.rvt",
                  Path = "http://www.spark-ifuture.com/RVT/G8/翡翠湖别院_G8_建筑_2019_10_17.rvt"
              });
            lstFiles.Add(
               new FilesViewModel
               {
                   FileId = "F2-20210727-10",
                   FileName = "翡翠湖别院_G8_结构_2019_10_17.rvt",
                   Path = "http://www.spark-ifuture.com/RVT/G8/翡翠湖别院_G8_结构_2019_10_17.rvt"
               });

            lstFiles.Add(
              new FilesViewModel
              {
                  FileId = "F3-20210727-10",
                  FileName = "翡翠湖别院_G8_电气_2019_10_17.rvt",
                  Path = "http://www.spark-ifuture.com/RVT/G8/翡翠湖别院_G8_电气_2019_10_17.rvt"
              });
            lstFiles.Add(
               new FilesViewModel
               {
                   FileId = "F4-20210727-10",
                   FileName = "翡翠湖别院_G8_给排水_2019_10_17.rvt",
                   Path = "http://www.spark-ifuture.com/RVT/G8/翡翠湖别院_G8_给排水_2019_10_17.rvt"
               });


            IModelCheckApi modelCheckApi = new ModelCheckApi();
            var response = modelCheckApi.Review(token, "T-20210727-30", lstFiles);

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

        protected void btnQuerySCResult_Click(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;

            IAuthorizeApi authApi = new AuthorizeApi();
            string token = authApi.GetToken();

            ICheckApi checkApi = new CheckApi();
            var response = checkApi.GetRedirectUrl(token, txtSCID.Text);

            txtResult.Text = response.SerializeToJson(true);

            System.Diagnostics.Process.Start(txtResult.Text);// 打开浏览器
        }
    }
}