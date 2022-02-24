<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Dashboard" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    Hello! <asp:Label ID="Username_lbl" runat="server" Font-Bold="true"/> <br />
    Id= <asp:Label ID="UserId_lbl" runat="server" Font-Bold="true"/> <br />
    <asp:Button ID="Logout_btn" runat="server" Text="Log-Out" OnClick="Logout_btn_Click" />

    </div>
    </form>
</body>
</html>
