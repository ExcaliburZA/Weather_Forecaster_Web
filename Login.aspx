<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Weather_Forecaster_Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="frmLogin" style="background-color:tan; height:259px; width:429px" runat="server" >

                 <asp:Label style="position:absolute; top: 43px; left: 26px;" ID="lblLoginHeading" runat="server" Text="Login" Font-Names="Arial" Font-Size="XX-Large" Font-Italic="True"></asp:Label>
    <br/>
            <asp:Label style="position:absolute; top: 99px; left: 29px;" ID="lblUsername" runat="server" Text="Username:" Font-Bold="true" Font-Size="Large"></asp:Label>      

    
            <asp:TextBox style="position:absolute; top: 127px; left: 156px; width: 201px;" ID="txtPassword" runat="server" Height="22px"></asp:TextBox> 
            
            <asp:TextBox style="position:absolute; top: 90px; left: 156px; width: 200px;" ID="txtUsername" runat="server" Height="22px"></asp:TextBox> 
            
            <br/> 
            
    <asp:Label style="position:absolute; top: 132px; left: 30px;" ID="lblPassword" runat="server" Text="Password:" Font-Bold="true" Font-Size="Large"></asp:Label>         

        <br/> 
            <br/><br/>
        <br/><br/>
            <asp:Button style="position:absolute; top: 184px; left: 25px; right: 890px;" ID="btnCasterLogin" Height="50px" Width="160px" runat="server" Text="Login as caster" BackColor="Tan" Font-Size="Medium" OnClick="btnCasterLogin_Click"></asp:Button> 
            
    <asp:Button style="position:absolute; top: 183px; left: 204px;" ID="btnUserLogin" Height="50px" Width="160px" runat="server" Text="Login as user" BackColor="Tan" Font-Size="Medium" OnClick="btnUserLogin_Click"></asp:Button>
    
    <asp:SqlDataSource ID="ds1" runat="server" ConnectionString="<%$ ConnectionStrings:weather_forecasterConnectionString %>" SelectCommand="SELECT * FROM [CASTERS]"></asp:SqlDataSource>

                 <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:weather_forecasterConnectionString %>" SelectCommand="SELECT * FROM [USERS]"></asp:SqlDataSource>

    </form>
</body>
</html>
