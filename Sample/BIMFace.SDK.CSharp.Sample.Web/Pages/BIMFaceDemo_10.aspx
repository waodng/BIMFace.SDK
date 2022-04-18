<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BIMFaceDemo_10.aspx.cs" Inherits="BIMFace.SDK.CSharp.Sample.Pages.BIMFaceDemo10" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>文档管理1-Hubs</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin: 25px;">
            <asp:Label ID="lblAccessToken" runat="server" Text="Token："></asp:Label>
            <asp:TextBox ID="txtAccessToken" runat="server" Width="400px"></asp:TextBox>
            &nbsp;
            <asp:Button ID="btnGetAccessToken" runat="server" Text="获取 AccessToken" Width="120px" OnClick="btnGetAccessToken_Click" />&nbsp;
            <asp:Button ID="btnGetHubs" runat="server" Text="获取Hub列表" Width="120px" OnClick="btnGetHubs_Click" /> 
        </div>
        <div style="margin: 25px;">
            <asp:Label ID="lblHbu" runat="server" Text="HubId："></asp:Label>
            <asp:TextBox ID="txtHubId" runat="server" Width="400px"></asp:TextBox>&nbsp;
            <asp:Button ID="btnGetHubMeta" runat="server" Text="获取Hub Meta信息" Width="120px" OnClick="btnGetHubMeta_Click" />
        </div>
        <div style="margin: 25px;">
            <asp:Label ID="Label2" runat="server" Text="结果："></asp:Label>
            <br />
            <asp:TextBox ID="txtResult" runat="server" Height="200px" TextMode="MultiLine" Width="1000px"></asp:TextBox>
        </div>
    </form>
</body>
</html>
