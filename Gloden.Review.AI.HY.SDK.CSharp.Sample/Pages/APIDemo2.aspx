<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="APIDemo2.aspx.cs" Inherits="Gloden.Review.AI.HY.SDK.CSharp.Sample.Pages.APIDemo2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>APIDemo2 智能审查</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin: 10px 10px 10px 507px">
            <asp:Button ID="btnStartSC" runat="server" Text="发起智能审查" Width="150px" OnClick="btnStartSC_Click" />
        </div>
         <div style="margin: 10px;">
             <asp:Label ID="Label2" runat="server" Text="审查ID："></asp:Label> 
             <asp:TextBox ID="txtSCID" runat="server" Width="410px"></asp:TextBox>&nbsp; 

            <asp:Button ID="btnQuerySCProgress" runat="server" Text="查询审查进度" Width="150px" OnClick="btnQuerySCProgress_Click" />
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
