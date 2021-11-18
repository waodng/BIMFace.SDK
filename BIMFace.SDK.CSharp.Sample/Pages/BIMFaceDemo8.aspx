<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BIMFaceDemo8.aspx.cs" Inherits="BIMFace.SDK.CSharp.Sample.Pages.BIMFaceDemo8" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>离线数据包API</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin: 10px;">
            <asp:TextBox ID="txtAccessToken" runat="server" Width="311px"></asp:TextBox>
            &nbsp;
            <asp:Button ID="btnGetAccessToken" runat="server" Text="获取 AccessToken" Width="260px" OnClick="btnGetAccessToken_Click" />
        </div>

        <div style="margin: 10px; width: 860px;">

            <asp:Panel ID="Panel1ForDWG" runat="server" BorderStyle="Dotted" GroupingText="离线数据包">
                <div>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                   FileId:
                  <asp:TextBox ID="txtFileId" runat="server" Width="418px"></asp:TextBox>
                </div>
                <div style="margin-top: 10px;">
                    &nbsp;  &nbsp; 
                IntegratId：
                <asp:TextBox ID="txtIntegratId" runat="server" Width="418px"></asp:TextBox>
                </div>
                <div style="margin-top: 10px;">
                    &nbsp; 
                CompareId：
                <asp:TextBox ID="txtCompareId" runat="server" Width="418px"></asp:TextBox>
                </div>
                <div style="margin-top: 10px;">
                    &nbsp; 
                离线数据包下载地址：
                <asp:TextBox ID="txtOffilineDataBagDownloadUrl" runat="server" Width="418px"></asp:TextBox>
                </div>
                <div style="margin: 5px;">
                    &nbsp;<asp:Button ID="btnCreateOffilineDataBagByFileId" runat="server" Text="创建文件离线数据包" Width="260px" OnClick="btnCreateOffilineDataBagByFileId_Click" />
                    &nbsp;<asp:Button ID="btnCreateOffilineDataBagByIntegratId" runat="server" Text="创建集成文件离线数据包" Width="260px" OnClick="btnCreateOffilineDataBagByIntegratId_Click" />
                    &nbsp;<asp:Button ID="btnCreateOffilineDataBagByCompareId" runat="server" Text="创建对比文件离线数据包" Width="260px" OnClick="btnCreateOffilineDataBagByCompareId_Click" />
                    <br /><br />
                    &nbsp;<asp:Button ID="btnQueryOffilineDataBagByFileId" runat="server" Text="查询文件离线数据包" Width="260px" OnClick="btnQueryOffilineDataBagByFileId_Click" />
                    &nbsp;<asp:Button ID="btnQueryOffilineDataBagByIntegratId" runat="server" Text="查询集成文件离线数据包" Width="260px" OnClick="btnQueryOffilineDataBagByIntegratId_Click" />
                    &nbsp;<asp:Button ID="btnQueryOffilineDataBagByCompareId" runat="server" Text="查询对比文件离线数据包" Width="260px" OnClick="btnQueryOffilineDataBagByCompareId_Click" />
                    <br /><br />
                    &nbsp;<asp:Button ID="btnQueryOffilineDataBagDownloadUrlByFileId" runat="server" Text="获取数据包下载地址" Width="260px" OnClick="btnQueryOffilineDataBagDownloadUrlByFileId_Click" />
                    &nbsp;<asp:Button ID="btnQueryOffilineDataBagDownloadUrlByIntegratId" runat="server" Text="获取数据包下载地址(集成)" Width="260px" OnClick="btnQueryOffilineDataBagDownloadUrlByIntegratId_Click" />
                    &nbsp;<asp:Button ID="btnQueryOffilineDataBagDownloadUrlByCompareId" runat="server" Text="获取数据包下载地址(集成)" Width="260px" OnClick="btnQueryOffilineDataBagDownloadUrlByCompareId_Click"  />
                    <br /><br />
                    &nbsp;<asp:Button ID="btnDownloadOffilineDataBag" runat="server" Text="下载离线数据包" Width="260px" OnClick="btnDownloadOffilineDataBag_Click"   />

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
