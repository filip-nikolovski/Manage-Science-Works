<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminProfile.aspx.cs" Inherits="Diplomska.AdminProfile" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Научни трудови</title>
     <link href="style/style.css" rel="stylesheet" />
    <link href="style/bootstrap.css" rel="stylesheet" />
    <link href="style/justified-nav.css" rel="stylesheet" />
    
    
</head>
<body>
    <form id="form1" runat="server">
        
    <div class="container">
        <div id="acount">
            <a href="http://www.ukim.edu.mk/" style="float: left">
                    <asp:Image ID="imgLogo" runat="server" ImageUrl="~/Images/ukim-logo-9.png" /></a><a href="http://www.finki.ukim.mk/mk/home" style="float: left"> <asp:Image ID="imgLogo1" runat="server" ImageUrl="~/Images/finki-logo-9.png" /></a><a href="http://liit.finki.ukim.mk/" style="float: left"><asp:Image ID="ImageliitLogo" runat="server" ImageUrl="~/Images/liit1 logo.png"  Style="height:100%;width:70%;float:left;margin-bottom:-1px"/></a>    

            <asp:Label ID="lblLoged" runat="server" Text=""></asp:Label>  <a href="AdminProfile.aspx"> <asp:Label ID="lblLogedAs" runat="server" Text=""></asp:Label></a>

                &nbsp;

        <asp:Button ID="btnLoguot" runat="server" Text="Loguot" Width="70px" OnClick="btnLoguot_Click" CssClass="btn btn-primary"/>


            </div>
       
        <div class="masthead"> 
          <ul class="nav nav-justified">
          <li ><a href="Admin.aspx">Корисници</a></li>
          <li ><a href="ListingSW.aspx">Научен труд</a></li
          </ul>
        </div >

    <div class="main-content">
        <div class="main-content1">

            <div runat="server" id="tblChangePass" visible="true" style="height:250px">
                            <table style="width:80%">
                                <tr>
                                    <td style="text-align:right;width:250px">
                                        <asp:Label ID="lblPass" runat="server" Text="Внеси постоечка лозинка"></asp:Label>
                                    </td>
                                    <td style="padding-left:5%;">
                                        <asp:TextBox ID="txtPass" TextMode="Password" runat="server" class="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Задолжително поле" Display="Dynamic" ControlToValidate="txtPass" ValidationGroup="group1"></asp:RequiredFieldValidator>

                                    </td>
                                </tr>
                                 <tr>
                                    <td style="text-align:right">
                                        <asp:Label ID="lblRepeatPass" runat="server" Text="Повтори ја постоечката лозинка"></asp:Label>
                                    </td>
                                    <td style="padding-left:5%;">
                                        <asp:TextBox ID="txtRePass" TextMode="Password" runat="server" class="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*Задолжително поле" Display="Dynamic" ControlToValidate="txtRePass" ValidationGroup="group1"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*Внеси иста лозинка" ControlToValidate="txtRePass" ControlToCompare="txtPass" ValidationGroup="group1" Display="Dynamic"></asp:CompareValidator>
                
                                    </td>
                                </tr>
                                 <tr>
                                    <td style="text-align:right">
                                        <asp:Label ID="lblNewPass" runat="server" Text="Внеси ја новата лозинка"></asp:Label>
                                    </td>
                                    <td style="padding-left:5%;">
                                        <asp:TextBox ID="txtNewPass" TextMode="Password" runat="server" class="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Задолжително поле" Display="Dynamic" ControlToValidate="txtNewPass" ValidationGroup="group1"></asp:RequiredFieldValidator>
                    
                                         <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationExpression="^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).*$" ControlToValidate="txtNewPass" ErrorMessage="*Неправилен формат на лозинка" Display="Dynamic" ValidationGroup="group1"></asp:RegularExpressionValidator><br />
        <asp:Label ID="lblErr" runat="server" Text="" Visible="true"></asp:Label>

                                    </td>
                                </tr>
                              

                            </table>

                                <div class="btnDown" style="margin-right:20%">
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"    class="btn btn-primary"/>
                                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"  class="btn btn-primary" ValidationGroup="group1"/>


                                </div>
                                <br />
                                </div>



   
        </div>
        </div>
        <div>
        </div>
    </div>
    </form>
</body>
</html>
