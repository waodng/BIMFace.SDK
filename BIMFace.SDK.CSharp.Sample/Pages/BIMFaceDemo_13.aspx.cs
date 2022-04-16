using System;
using System.Collections.Generic;
using System.IO;

using BIMFace.SDK.CSharp.API;
using BIMFace.SDK.CSharp.Common.Extensions;
using BIMFace.SDK.CSharp.Common.Utils;
using BIMFace.SDK.CSharp.Entity;

namespace BIMFace.SDK.CSharp.Sample.Pages
{
    public partial class BIMFaceDemo_13 : System.Web.UI.Page
    {
        readonly string _appKey = ConfigUtility.GetAppSettingValue("BIMFACE_AppKey");
        readonly string _appSecret = ConfigUtility.GetAppSettingValue("BIMFACE_AppSecret");


        protected void Page_Load(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;
        }

        // 获取 AccessToken
        protected void btnGetAccessToken_Click(object sender, EventArgs e)
        {
            txtAccessToken.Text = string.Empty;

            IBasicApi api = new BasicApi();
            AccessTokenResponse response = api.GetAccessToken(_appKey, _appSecret);
            if (response != null)
            {
                txtAccessToken.Text = response.Data.Token;
            }
        }

        // 获取Hub列表
        protected void btnGetHubs_Click(object sender, EventArgs e)
        {
            txtHubId.Text = string.Empty;
            txtResult.Text = string.Empty;

            IFileManagementApi api = new FileManagementApi();
            var response = api.GetHubs(txtAccessToken.Text);
            if (response != null)
            {
                txtHubId.Text = response.Data[0].Id;
                txtResult.Text = response.SerializeToJson(true);
            }
        }

        // 获取项目列表
        protected void btnGetProjects_Click(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;

            IFileManagementApi api = new FileManagementApi();
            var response = api.GetProjects(txtAccessToken.Text, txtHubId.Text);
            if (response != null)
            {
                txtResult.Text = response.SerializeToJson(true);
            }
        }

        // 获取文件夹信息
        protected void btnGetFolderInfo_Click(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;

            IFileManagementApi api = new FileManagementApi();
            var response = api.GetFolder(txtAccessToken.Text, txtProjectId.Text, null, txtParentPath.Text);
            if (response != null)
            {
                txtResult.Text = response.SerializeToJson(true);

                if (response.Code == "success" && response.Data != null)
                {
                    txtParentId.Text = response.Data.Id;
                }
            }
        }

        // 普通文件流上传（ParentPath）
        protected void btnUploadFileByStream_Click(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;

            var fileInfo = new FileInfo(txtLocalFile.Text);
            string fileName = fileInfo.Name;
            var fileStream = new FileStream(txtLocalFile.Text, FileMode.Open, FileAccess.Read);

            IFileManagementApi api = new FileManagementApi();
            var response = api.UploadFileByStream(txtAccessToken.Text, txtProjectId.Text, fileName, fileStream, null, txtParentPath.Text);
            if (response != null)
            {
                txtResult.Text = response.SerializeToJson(true);
            }
        }

        // 普通文件流上传（ParentId）
        protected void btnUploadFileByStream2_Click(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;

            var fileInfo = new FileInfo(txtLocalFile.Text);
            string fileName = fileInfo.Name;
            var fileStream = new FileStream(txtLocalFile.Text, FileMode.Open, FileAccess.Read);

            IFileManagementApi api = new FileManagementApi();
            var response = api.UploadFileByStream(txtAccessToken.Text, txtProjectId.Text, fileName, fileStream, txtParentId.Text, null);
            if (response != null)
            {
                txtResult.Text = response.SerializeToJson(true);
            }
        }

        // 指定外部文件url方式上传（ParentPath）
        protected void btnUploadFileByUrl_Click(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;

            // http: //www.spark-ifuture.com/RVT/ArchLinkModel.rvt
            string[] arrFiles = txtFileWebUrl.Text.Split('/');
            string fileName = arrFiles[arrFiles.Length - 1];

            IFileManagementApi api = new FileManagementApi();
            var response = api.UploadFileByUrl(txtAccessToken.Text, txtProjectId.Text, fileName, null, txtParentPath.Text, txtFileWebUrl.Text);
            if (response != null)
            {
                txtResult.Text = response.SerializeToJson(true);
            }
        }

        // 指定外部文件url方式上传（ParentId）
        protected void btnUploadFileByUrl2_Click(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;

            // http: //www.spark-ifuture.com/RVT/ArchLinkModel.rvt
            string[] arrFiles = txtFileWebUrl.Text.Split('/');
            string fileName = arrFiles[arrFiles.Length - 1];

            IFileManagementApi api = new FileManagementApi();
            var response = api.UploadFileByUrl(txtAccessToken.Text, txtProjectId.Text, fileName, txtParentId.Text, null, txtFileWebUrl.Text);
            if (response != null)
            {
                txtResult.Text = response.SerializeToJson(true);
            }
        }

        // 根据policy凭证在web端上传文件（ParentPath）
        protected void btnGetFileUploadPolicy_Click(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;

            IFileManagementApi api = new FileManagementApi();
            var response = api.UploadFileByPolicy(txtAccessToken.Text, txtProjectId.Text, txtLocalFile.Text, null, txtParentPath.Text);
            if (response != null)
            {
                txtResult.Text = response.SerializeToJson(true);
            }
        }

        // 根据policy凭证在web端上传文件（ParentId）
        protected void btnGetFileUploadPolicy2_Click(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;

            IFileManagementApi api = new FileManagementApi();
            var response = api.UploadFileByPolicy(txtAccessToken.Text, txtProjectId.Text, txtLocalFile.Text, txtParentId.Text, null);
            if (response != null)
            {
                txtResult.Text = response.SerializeToJson(true);
            }
        }

        // 获取文件信息
        protected void btnGetFileInfo_Click(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;

            IFileManagementApi api = new FileManagementApi();
            var response = api.GetFile(txtAccessToken.Text, txtProjectId.Text, txtFileId.Text, txtFileFath.Text, null);
            if (response != null)
            {
                txtResult.Text = response.SerializeToJson(true);
            }
        }

        // 获取文件状态
        protected void btnGetFileUploadStatus_Click(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;

            IFileManagementApi api = new FileManagementApi();
            var response = api.GetFileUploadStatus(txtAccessToken.Text, txtProjectId.Text, txtFileId.Text, txtFileFath.Text);
            if (response != null)
            {
                txtResult.Text = response.SerializeToJson(true);
            }
        }

        // 获取文件路径
        protected void btnGetFilePath_Click(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;

            IFileManagementApi api = new FileManagementApi();
            var response = api.GetFilePath(txtAccessToken.Text, txtProjectId.Text, txtFileId.Text);
            if (response != null)
            {
                txtResult.Text = response.SerializeToJson(true);
            }
        }

        // 获取源文件下载地址
        protected void btnGetFileDownloadUrl_Click(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;

            IFileManagementApi api = new FileManagementApi();
            var response = api.GetFileDownloadUrl(txtAccessToken.Text, txtProjectId.Text, txtFileId.Text, txtFileFath.Text);
            if (response != null)
            {
                txtResult.Text = response.SerializeToJson(true);
            }
        }

        // 打包下载压缩文件
        protected void btnDownloadZip_Click(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;

            List<string> lstFileIds = new List<string>();
            lstFileIds.Add("10000737158730");
            //lstFileIds.Add("10000736648068");

            IFileManagementApi api = new FileManagementApi();
            var response = api.DownloadFilesByZip(txtAccessToken.Text, txtProjectId.Text, lstFileIds);
            if (response != null)
            {
                txtResult.Text = response.SerializeToJson(true);
            }
        }

        // 批量删除文件
        protected void btnDeleteFiles_Click(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;

            List<string> lstFileIds = new List<string>();
            lstFileIds.Add(txtFileId.Text.Trim());
           

            IFileManagementApi api = new FileManagementApi();
            var response = api.DeleteFiles(txtAccessToken.Text, txtProjectId.Text, lstFileIds);
            if (response != null)
            {
                txtResult.Text = response.SerializeToJson(true);
            }
        }
    }
}