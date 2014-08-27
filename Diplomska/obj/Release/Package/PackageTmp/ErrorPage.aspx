<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="Diplomska.ErrorPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Грешка</title>

          
    <link href="style/style.css" rel="stylesheet" />
     <link rel="shortcut icon" href="../Images/favicon.ico" />
    <link href="style/loginStile.css" rel="stylesheet" />
    <link href="style/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="container">
             <div id="acount" style="margin-bottom:7%">
                <a href="http://www.ukim.edu.mk/" style="float: left">
                    <asp:Image ID="imgLogo" runat="server" ImageUrl="~/Images/ukim-logo-9.png" /></a><a href="http://www.finki.ukim.mk/mk/home" style="float: left"> <asp:Image ID="imgLogo1" runat="server" ImageUrl="~/Images/finki-logo-9.png" /></a><a href="http://liit.finki.ukim.mk/" style="float: left"><asp:Image ID="ImageliitLogo" runat="server" ImageUrl="~/Images/liit1 logo.png"  Style="height:100%;width:70%;float:left;margin-bottom:-1px"/></a>
               

            </div>
            <div class="main-content1" style="padding-left: 3%">
                <h3 class="text-muted">
                    
                  <asp:Label ID="lblMesage" runat="server" Text=""></asp:Label></h3>
              

            </div>
        </div>
    </form>
</body>
</html>
