<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="FaceDec_1.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 545px">
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Image ID="Image1" runat="server" Height="208px" Width="310px" />
        </br>
        
        <asp:TextBox ID="textBox1" runat="server" Text="Dev"> </asp:TextBox>
        <asp:Button ID="button2" runat="server" Text="Add Face" OnClick="button2_Click" />
           </br>
        
        <asp:Label ID="label4" runat="server" Text="NOBody"></asp:Label>
         <asp:Label ID="label3" runat="server" Text="0"></asp:Label>
        <asp:Button ID="button1" runat="server" Text="Detect & Recog" OnClick="button1_Click" />   
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

    </form>
</body>
</html>
