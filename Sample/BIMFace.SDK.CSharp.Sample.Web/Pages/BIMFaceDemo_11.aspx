<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BIMFaceDemo_11.aspx.cs" Inherits="BIMFace.SDK.CSharp.Sample.Pages.BIMFaceDemo_11" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>文档管理2-Project</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin: 25px; padding-left: 17px;">
            <asp:Label ID="lblAccessToken" runat="server" Text="Token："></asp:Label>
            <asp:TextBox ID="txtAccessToken" runat="server" Width="400px"></asp:TextBox>
            &nbsp;
                <asp:Button ID="btnGetAccessToken" runat="server" Text="获取 AccessToken" Width="120px" OnClick="btnGetAccessToken_Click" />&nbsp;
                <asp:Button ID="btnGetHubs" runat="server" Text="获取Hub列表" OnClick="btnGetHubs_Click" />
        </div>
        <div style="margin: 25px; padding-left: 17px;">
            <asp:Label ID="lblHbu" runat="server" Text="HubId："></asp:Label>
            <asp:TextBox ID="txtHubId" runat="server" Width="400px"></asp:TextBox>&nbsp;
            <asp:Button ID="btnGetProjects" runat="server" Text="获取项目列表" Width="120px" OnClick="btnGetProjects_Click" />
        </div>
        <div style="margin: 25px;">
            <asp:Label ID="Label1" runat="server" Text="项目名称："></asp:Label>
            <asp:TextBox ID="txtProjectName" runat="server" Width="400px"></asp:TextBox>&nbsp;
            <asp:Button ID="btnCreateProject" runat="server" Text="创建项目" Width="120px" OnClick="btnCreateProject_Click" />

            <br />
            <br />
            <asp:Label ID="lblProjectId" runat="server" Text="项目ID："></asp:Label>&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtProjectId" runat="server" Width="400px"></asp:TextBox>&nbsp;
            <asp:Button ID="Button1" runat="server" Text="获取项目信息" Width="120px" OnClick="Button1_Click" />&nbsp;
            <asp:Button ID="btnDeleteProject" runat="server" Text="删除项目" Width="120px" OnClick="btnDeleteProject_Click" />
            &nbsp;
        </div>
        <div style="margin: 25px;">
        </div>
        <div style="margin: 25px;">
            <asp:Label ID="Label2" runat="server" Text="结果："></asp:Label>
            <br />
            <asp:TextBox ID="txtResult" runat="server" Height="300px" TextMode="MultiLine" Width="1000px"></asp:TextBox>
        </div>
    </form>
</body>
</html>
