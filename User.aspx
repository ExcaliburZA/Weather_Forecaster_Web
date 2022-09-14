<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="Weather_Forecaster_Web.User" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="frmUser" style="background-color:tan; height:639px; width:429px" runat="server" >
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:weather_forecasterConnectionString %>" SelectCommand="SELECT * FROM [FORECASTS]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:weather_forecasterConnectionString %>" SelectCommand="SELECT * FROM [USER_CITIES]"></asp:SqlDataSource>
            <asp:Label style="position:absolute; top: 15px; left: 18px;" ID="lblUserWelcome" runat="server" Text="Welcome to the user portal!" Font-Names="Arial" Font-Size="XX-Large" Font-Italic="True"></asp:Label>
            <asp:Label style="position:absolute; top: 73px; left: 41px;" ID="lblSelectCity" runat="server" Text="Please select a city to view the forecasts for" Font-Names="Arial" Font-Size="Large"></asp:Label>
            <asp:Label style="position:absolute; top: 49px; left: 20px;" ID="lblLine" runat="server" Text="------------------------------------------------------------------" Font-Names="Arial" Font-Size="Large"></asp:Label>           

            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:weather_forecasterConnectionString %>" SelectCommand="SELECT * FROM [USERS]"></asp:SqlDataSource>

        <asp:Button style="position:absolute; top: 291px; left: 230px; width: 120px; margin-top: 0px; background-color:tan" ID="btnAddCity0" runat="server" Text="Add city" Height="40px"/>
            
            <asp:DropDownList style="position:absolute; top: 106px; left: 91px; width: 240px; height: 16px;" ID="ddlUserCities" runat="server" OnSelectedIndexChanged="ddlUserCities_SelectedIndexChanged" AutoPostBack="false">
                <asp:ListItem Text="No cities selected for user" />
            </asp:DropDownList>
        
        <asp:Button style="position:absolute; top: 142px; left: 92px; width: 239px; margin-top: 2px; background-color:tan" ID="btnViewForecasts" runat="server" Text="View" Height="40px" OnClick="btnViewForecasts_Click" />
            <asp:TextBox style="position:absolute; top: 254px; left: 96px; width: 230px;" ID="txtCity" runat="server"></asp:TextBox>
            


        <asp:Button style="position:absolute; top: 290px; left: 77px; width: 120px; margin-top: 0px; background-color:tan" ID="btnRemoveCity" runat="server" Text="Remove city" Height="40px" OnClick="btnRemoveCity_Click"/>
            
        <asp:Button style="position:absolute; top: 291px; left: 230px; width: 120px; margin-top: 0px; background-color:tan" ID="btnAddCity" runat="server" Text="Add city" Height="40px" OnClick="btnAddCity_Click"/>
            
        <asp:Label style="position:absolute; top: 329px; left: 19px;" ID="lblLine3" runat="server" Text="------------------------------------------------------------------" Font-Names="Arial" Font-Size="Large"></asp:Label>
        <asp:Label style="position:absolute; top: 183px; left: 20px;" ID="lblLine2" runat="server" Text="------------------------------------------------------------------" Font-Names="Arial" Font-Size="Large"></asp:Label>
            <asp:TextBox style="position:absolute; top: 366px; left: 74px; height: 258px; width: 271px;" ID="txtOutput" runat="server" TextMode="MultiLine"></asp:TextBox>

        <asp:Label style="position:absolute; top: 204px; left: 43px; width: 340px;" ID="lblEditMessage" runat="server" Text="Here you can make changes to your list of selected cities to view" Font-Names="Arial" Font-Size="Large"></asp:Label>

    </form>
</body>
</html>
