<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <asp:TextBox ID="Email_txt" runat="server" placeholder="Email"></asp:TextBox> <br />
        <asp:TextBox ID="Password_txt" runat="server" placeholder="Password"></asp:TextBox> <br />
      
        <asp:Button ID="Submit_btn" runat="server" Text="Login" 
            onclick="Submit_btn_Click" />
            <asp:Label ID="lblResult" runat="server" Font-Bold="true"/>  
    </div>
    </form>
</body>
</html>
