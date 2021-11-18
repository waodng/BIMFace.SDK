<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BIMFaceDemo5.aspx.cs" Inherits="BIMFace.SDK.CSharp.Sample.Pages.BIMFaceDemo5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>模型集成</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin: 10px;">
            <asp:TextBox ID="txtAccessToken" runat="server" Width="311px"></asp:TextBox>
            &nbsp;
            <asp:Button ID="btnGetAccessToken" runat="server" Text="获取 AccessToken" Width="260px" OnClick="btnGetAccessToken_Click" />
        </div>
        <div style="margin: 10px; width: 860px;">

            <asp:Panel ID="Panel1ForDWG" runat="server" BorderStyle="Dotted" GroupingText="模型集成">
                <div>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    <asp:Label ID="Label1" runat="server" Text="文件1_ID：">
                    </asp:Label><asp:TextBox ID="txtFile1Id" runat="server" Width="246px"></asp:TextBox>
                    &nbsp;
                    <asp:Label ID="Label2" runat="server" Text="文件2_ID：">
                    </asp:Label><asp:TextBox ID="txtFile2Id" runat="server" Width="246px"></asp:TextBox>
                </div>
                <br />
                  &nbsp; 
                IntegratID：
                <asp:TextBox ID="txtIntegratID" runat="server" Width="418px"></asp:TextBox>
                <div style="margin: 5px;">
                    &nbsp;<asp:Button ID="btnStartIntegrate" runat="server" Text="开始集成" Width="260px" OnClick="btnStartIntegrate_Click" />
                    &nbsp;<asp:Button ID="btnGetIntegrateStatus" runat="server" Text="获取集成状态" Width="260px" OnClick="btnGetIntegrateStatus_Click"  />
                </div>

            </asp:Panel>
        </div>

        <div style="margin: 10px;">
            <asp:Label ID="Label3" runat="server" Text="结果："></asp:Label>
            <br />
            <asp:TextBox ID="txtResult" runat="server" Height="160px" TextMode="MultiLine" Width="860px"></asp:TextBox>
        </div>
    </form>
</body>
</html>
