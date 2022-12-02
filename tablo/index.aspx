<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="tablo.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link rel="stylesheet" type="text/css" href="index.css" />
    
    <title>Tablo</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="nav">
          
            <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
               
            </asp:DropDownList>
            <asp:Button ID="tablo" runat="server" Text="Tablo Oluştur" OnClick="tablo_Click"  />
                
        </div>
        <div class="container">
        <asp:Table ID="table" runat="server"  >          
        </asp:Table>
        </div>

      
    </form>
</body>
</html>
