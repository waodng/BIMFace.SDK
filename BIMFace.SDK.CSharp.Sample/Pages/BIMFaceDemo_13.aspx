<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BIMFaceDemo_13.aspx.cs" Inherits="BIMFace.SDK.CSharp.Sample.Pages.BIMFaceDemo_13" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>文档管理4-FileItems</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin: 25px; padding-left: 35px;">
            <asp:Label ID="lblAccessToken" runat="server" Text="Token："></asp:Label>
            <asp:TextBox ID="txtAccessToken" runat="server" Width="400px"></asp:TextBox>
            &nbsp;
            <asp:Button ID="btnGetAccessToken" runat="server" Text="获取 AccessToken" Width="170px" OnClick="btnGetAccessToken_Click" />&nbsp;
            <asp:Button ID="btnGetHubs" runat="server" Text="获取Hub列表" Width="170px" OnClick="btnGetHubs_Click" />
        </div>
        <div style="margin: 25px; padding-left: 35px;">
            <asp:Label ID="lblHbu" runat="server" Text="HubId："></asp:Label>
            <asp:TextBox ID="txtHubId" runat="server" Width="400px"></asp:TextBox>&nbsp;
            <asp:Button ID="btnGetProjects" runat="server" Text="获取项目列表" Width="170px" OnClick="btnGetProjects_Click" />
        </div>
        <div style="margin: 25px; padding-left: 30px;">
            <asp:Label ID="lblProjectId" runat="server" Text="项目ID："></asp:Label>&nbsp;
            <asp:TextBox ID="txtProjectId" runat="server" Width="400px"></asp:TextBox>&nbsp;
        </div>
        <div style="margin: 25px; padding-left: 22px;">
            <asp:Label ID="Label1" runat="server" Text="外部URL："></asp:Label>
            <asp:TextBox ID="txtFileWebUrl" runat="server" Width="400px">http://www.spark-ifuture.com/RVT/ArchLinkModel.rvt</asp:TextBox>&nbsp;
        </div>
        <div style="margin: 25px; padding-left: 5px;">
            &nbsp;&nbsp;
            <asp:Label ID="Label5" runat="server" Text="本地文件："></asp:Label>
            <asp:TextBox ID="txtLocalFile" runat="server" Width="400px">G:\BIM 示例模型\01_BIMFACE示例文件-Revit模型.rvt</asp:TextBox>&nbsp;
          
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="父目录路径："></asp:Label>
            <asp:TextBox ID="txtParentPath" runat="server" Width="400px"></asp:TextBox>&nbsp;
            <span style="margin-left: 180px;">
                <asp:Button ID="btnUploadFileByStream" runat="server" Text="普通文件流上传" Width="170px" OnClick="btnUploadFileByStream_Click" />
                &nbsp;
            <asp:Button ID="btnUploadFileByUrl" runat="server" Text="指定外部文件url方式上传" Width="170px" OnClick="btnUploadFileByUrl_Click" />&nbsp;
            <asp:Button ID="btnUploadFileByPolicy" runat="server" Text="根据policy凭证在web端上传文件" Width="220px" OnClick="btnGetFileUploadPolicy_Click" />
            </span>
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="父目录ID："></asp:Label>&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtParentId" runat="server" Width="400px"></asp:TextBox>&nbsp; 
            <asp:Button ID="btnGetFolderInfo" runat="server" Text="获取路径信息" Width="170px" OnClick="btnGetFolderInfo_Click" />&nbsp;
            <asp:Button ID="btnUploadFileByStream2" runat="server" Text="普通文件流上传" Width="170px" OnClick="btnUploadFileByStream2_Click" />
            &nbsp;
            <asp:Button ID="btnUploadFileByUrl2" runat="server" Text="指定外部文件url方式上传" Width="170px" OnClick="btnUploadFileByUrl2_Click" />&nbsp;
            <asp:Button ID="btnUploadFileByPolicy2" runat="server" Text="根据policy凭证在web端上传文件" Width="220px" OnClick="btnGetFileUploadPolicy2_Click" />
        </div>

        <div style="margin: 25px; padding-left: 15px;">
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label6" runat="server" Text="文件ID："></asp:Label>
            <asp:TextBox ID="txtFileId" runat="server" Width="400px"></asp:TextBox>&nbsp;
            <asp:Button ID="btnGetFilePath" runat="server" Text="获取文件路径" Width="170px" OnClick="btnGetFilePath_Click" />&nbsp;
            <br />
            <br />
            <asp:Label ID="Label7" runat="server" Text="文件Path："></asp:Label>
            <asp:TextBox ID="txtFileFath" runat="server" Width="400px"></asp:TextBox>&nbsp;
        </div>
        <div style="margin: 25px; padding-left: 105px;">
            <asp:Button ID="btnGetFileInfo" runat="server" Text="获取文件信息" Width="170px" OnClick="btnGetFileInfo_Click" />&nbsp;
            <asp:Button ID="btnGetFileUploadStatus" runat="server" Text="获取文件状态" Width="170px" OnClick="btnGetFileUploadStatus_Click" />&nbsp;
           
            <asp:Button ID="btnGetFileDownloadUrl" runat="server" Text="获取源文件下载地址" Width="170px" OnClick="btnGetFileDownloadUrl_Click" />&nbsp;
           
            <asp:Button ID="btnDownloadZip" runat="server" Text="打包下载压缩文件" Width="170px" OnClick="btnDownloadZip_Click" />&nbsp;
            <asp:Button ID="btnDeleteFiles" runat="server" Text="批量删除文件" Width="170px" OnClick="btnDeleteFiles_Click" />&nbsp;
            
        </div>
        <div style="margin: 25px;">
            <asp:Label ID="Label2" runat="server" Text="结果："></asp:Label>
            <br />
            <asp:TextBox ID="txtResult" runat="server" Height="300px" TextMode="MultiLine" Width="1000px"></asp:TextBox>
        </div>
    </form>
</body>
</html>
