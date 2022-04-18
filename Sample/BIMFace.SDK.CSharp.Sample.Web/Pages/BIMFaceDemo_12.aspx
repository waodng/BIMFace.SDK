<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BIMFaceDemo_12.aspx.cs" Inherits="BIMFace.SDK.CSharp.Sample.Pages.BIMFaceDemo_12" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>文档管理3-Folder</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin: 25px; padding-left:35px;">
            <asp:Label ID="lblAccessToken" runat="server" Text="Token："></asp:Label>
            <asp:TextBox ID="txtAccessToken" runat="server" Width="400px"></asp:TextBox>
            &nbsp;
                <asp:Button ID="btnGetAccessToken" runat="server" Text="获取 AccessToken" Width="170px" OnClick="btnGetAccessToken_Click" />&nbsp;
                <asp:Button ID="btnGetHubs" runat="server" Text="获取Hub列表" Width="170px"  OnClick="btnGetHubs_Click" />
        </div>
        <div style="margin: 25px;padding-left:35px;">
            <asp:Label ID="lblHbu" runat="server" Text="HubId："></asp:Label>
            <asp:TextBox ID="txtHubId" runat="server" Width="400px"></asp:TextBox>&nbsp;
            <asp:Button ID="btnGetProjects" runat="server" Text="获取项目列表" Width="170px" OnClick="btnGetProjects_Click" />
        </div>
        <div style="margin: 25px;padding-left:30px;">
            <asp:Label ID="lblProjectId" runat="server" Text="项目ID："></asp:Label>&nbsp;
            <asp:TextBox ID="txtProjectId" runat="server" Width="400px"></asp:TextBox>&nbsp;
        </div>

        <div style="margin: 25px;">
            <asp:Label ID="Label5" runat="server" Text="文件夹路径："></asp:Label>
            <asp:TextBox ID="txtFolderPath" runat="server" Width="400px"></asp:TextBox>&nbsp;
            <asp:Button ID="btnGetFolderInfo" runat="server" Text="获取文件夹信息" Width="170px" OnClick="btnGetFolderInfo_Click" />&nbsp;
          
        </div>
        <div style="margin: 25px;">
            <asp:Label ID="Label6" runat="server" Text="文件夹ID："></asp:Label>&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtFolderId" runat="server" Width="400px"></asp:TextBox>&nbsp;
            <asp:Button ID="btnGetFolderPath" runat="server" Text="获取文件夹路径" Width="170px" OnClick="btnGetFolderPath_Click" />&nbsp;
            <asp:Button ID="btnGetParentFolder" runat="server" Text="获取父文件夹" Width="170px" OnClick="btnGetParentFolder_Click"/>
        </div>
        <div style="margin: 25px;">
            <asp:Label ID="Label1" runat="server" Text="文件夹名称："></asp:Label>
            <asp:TextBox ID="txtFolderName" runat="server" Width="400px"></asp:TextBox>&nbsp;
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="父目录路径："></asp:Label>
            <asp:TextBox ID="txtParentPath" runat="server" Width="400px"></asp:TextBox>&nbsp;
            <asp:Button ID="btnCreateFolderByParentPath" runat="server" Text="指定目录下创建文件夹" Width="170px" OnClick="btnCreateFolderByParentPath_Click" />&nbsp;
            <asp:Button ID="btnGetFolderContents" runat="server" Text="获取文件夹下的所有文件" Width="170px" OnClick="btnGetFolderContents_Click" />&nbsp;
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="父目录ID："></asp:Label>&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtParentId" runat="server" Width="400px"></asp:TextBox>&nbsp;   
            <asp:Button ID="btnCreateFolderByParentId" runat="server" Text="指定目录下创建文件夹" Width="170px" OnClick="btnCreateFolderByParentId_Click" />
        </div>

        <div style="margin: 25px;">
            <asp:Label ID="Label2" runat="server" Text="结果："></asp:Label>
            <br />
            <asp:TextBox ID="txtResult" runat="server" Height="300px" TextMode="MultiLine" Width="1000px"></asp:TextBox>
        </div>
    </form>
</body>
</html>

