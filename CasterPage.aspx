<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CasterPage.aspx.cs" Inherits="Weather_Forecaster_Web.CasterPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #frmCaster {
            height: 443px;
        }



    </style>
</head>
<body>
    <form id="frmCaster" style="background-color:tan; width: 652px;" runat="server">
        <div>
            <asp:Label style="position:absolute;" ID="lblCasterWelcome" runat="server" Text="Welcome to the caster portal!" Font-Names="Arial" Font-Size="XX-Large" Font-Italic="True"></asp:Label>

            <asp:Label style="position:absolute; font-family:Arial; font-size:large; top: 106px; left: 15px; height: 21px;" ID="lblStartDate" runat="server" Text="Start date"></asp:Label><br><br>                      
            <asp:TextBox style="position:absolute; top: 105px; left: 118px; width: 132px; right: 1786px;" ID="txtStartDate" runat="server"></asp:TextBox>                     

                                                     
            <asp:Label style="position:absolute; font-family:Arial; font-size:large; top: 143px; left: 16px;" ID="lblEndDate" runat="server" Text="End date"></asp:Label>
            <asp:TextBox style="position:absolute; top: 143px; left: 118px; width: 134px; right: 1784px;" ID="txtEndDate" runat="server"></asp:TextBox> 

            <asp:SqlDataSource ID="dsCasters" runat="server" ConnectionString="<%$ ConnectionStrings:weather_forecasterConnectionString %>" SelectCommand="SELECT * FROM [CASTERS]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dsForecasts" runat="server" ConnectionString="<%$ ConnectionStrings:weather_forecasterConnectionString %>" SelectCommand="SELECT * FROM [FORECASTS]"></asp:SqlDataSource>

            <asp:Button style="position:absolute; top: 225px; left: 18px; width: 240px; margin-top: 0px; background-color:tan" ID="btnView" runat="server" Text="View" Height="40px" OnClick="btnView_Click"/>

            <asp:Label style="position:absolute; top: 181px; left: 17px;" ID="lblCityView" runat="server" Text="City" Font-Names="Arial" Font-Size="Large"></asp:Label>
            <asp:TextBox style="position:absolute; top: 182px; left: 117px; width: 133px;" ID="txtCityView" runat="server"></asp:TextBox>

            
            
            <asp:Label style="position:absolute; top: 63px; left: 10px; height: 21px;" ID="lblViewForecasts" runat="server" Text="VIEW FORECASTS" Font-Bold="True" Font-Names="Arial" Font-Size="Large" Font-Underline="True"></asp:Label>
            <asp:Label style="position:absolute; top: 289px; left: 10px;" ID="lblEditForecasts" runat="server" Text="EDIT FORECASTS" Font-Bold="True" Font-Names="Arial" Font-Size="Large" Font-Underline="True"></asp:Label>
            
            <asp:Label style="position:absolute; top: 318px; left: 17px;" ID="lblDateEdit" runat="server" Text="Date" Font-Names="Arial" Font-Size="Large"></asp:Label>
            <asp:TextBox style="position:absolute; top: 318px; left: 115px; width: 134px; " ID="txtDateEdit" runat="server"></asp:TextBox> 

            <asp:Label style="position:absolute; top: 353px; left: 17px;" ID="lblCityEdit" runat="server" Text="City" Font-Names="Arial" Font-Size="Large"></asp:Label>
            <asp:TextBox style="position:absolute; top: 355px; left: 115px; width: 134px; " ID="txtCityEdit" runat="server"></asp:TextBox> 

            <asp:Button style="position:absolute; top: 400px; left: 20px; width: 238px; margin-top: 0px; background-color:tan" ID="btnEdit" runat="server" Text="Edit forecast" Height="40px" OnClick="btnEdit_Click"/>

            <asp:TextBox style="position:absolute; top: 73px; left: 289px; height: 362px; width: 342px;" ID="txtOutput" runat="server" TextMode="MultiLine"></asp:TextBox>

        </div>
    </form>
</body>
</html>
