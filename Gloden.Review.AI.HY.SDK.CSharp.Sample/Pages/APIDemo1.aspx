<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="APIDemo1.aspx.cs" Inherits="Gloden.Review.AI.BIM.SDK.CSharp.Sample.Pages.APIDemo1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>APIDemo1 授权接口</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin: 10px;">
            <asp:Button ID="btnLogin" runat="server" Text="登录" Width="150px" OnClick="btnLogin_Click" />
        </div>
        <div style="margin: 10px;">
            <asp:Label ID="Label1" runat="server" Text="请求结果："></asp:Label>
        </div>
        <div style="margin: 10px;">
            <asp:TextBox ID="txtResult" runat="server" Rows="10" Width="700px" Height="300px" TextMode="MultiLine"></asp:TextBox>
        </div>
    </form>
</body>
</html>
