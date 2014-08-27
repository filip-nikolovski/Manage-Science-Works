<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RessetPassword.aspx.cs" Inherits="Diplomska.RessetPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<<<<<<< HEAD
   <title>Заборавена лозинка</title>
=======
   <title></title>
>>>>>>> cc9771e163cb639c96757945fd47119dba0d514a
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
<<<<<<< HEAD
                <a href="http://www.ukim.edu.mk/" style="float: left">
                    <asp:Image ID="imgLogo" runat="server" ImageUrl="~/Images/ukim-logo-9.png" /></a><a href="http://www.finki.ukim.mk/mk/home" style="float: left"> <asp:Image ID="imgLogo1" runat="server" ImageUrl="~/Images/finki-logo-9.png" /></a><a href="http://liit.finki.ukim.mk/" style="float: left"><asp:Image ID="ImageliitLogo" runat="server" ImageUrl="~/Images/liit1 logo.png"  Style="height:100%;width:70%;float:left;margin-bottom:-1px"/></a>
=======
                 <a href="Index.aspx" style="float:left">
                    <asp:Image ID="imgLogo" runat="server" ImageUrl="~/Images/ukim-logo-9.png" /><asp:Image ID="imgLogo1" runat="server" ImageUrl="~/Images/finki-logo-9.png" /></a>
               
>>>>>>> cc9771e163cb639c96757945fd47119dba0d514a
               

            </div>
            <div class="main-content" style="padding-left: 3%">
<<<<<<< HEAD
                <div class="main-content1" style="height:350px">
=======
                <div class="main-content1">
>>>>>>> cc9771e163cb639c96757945fd47119dba0d514a
                <h3 class="text-muted">
                    <asp:Label ID="lblTitle1" runat="server" Text="Рестарирање на лозинка."></asp:Label></h3>

                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lblEmail" runat="server" Text="Внеси емаил"></asp:Label></td>
                        <td>
<<<<<<< HEAD
                            <asp:TextBox ID="txtEmail" runat="server" class="form-control" placeholder="email"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"  ErrorMessage="*Задолжително поле" Display="Dynamic" ControlToValidate="txtEmail" ValidationGroup="group1"></asp:RequiredFieldValidator>
                     <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail" ErrorMessage="*Неправилен емаил формат" Display="Dynamic" ValidationGroup="group1"></asp:RegularExpressionValidator>
    
                        </td>
                    </tr>
              
             
                </table>
                    <div class="btnDown" style="margin-right:39%">
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-primary" OnClick="btnCancel_Click"/>
                            <asp:Button ID="btnSend" runat="server" Text="Applay" class="btn btn-primary" OnClick="btnSend_Click" ValidationGroup="group1"/>
                    </div>
                    <asp:Label ID="lblErr" runat="server" Text="" ForeColor="Red"></asp:Label>

                    <div class="description">

                        *Доколку сте ја заборавиле лозинката во овој дел можете да ја рестартирате.<br />
                        Со испраќање на барањето, новата лозинка ќе биде испратена на вашиот email.<br /> Новата лозинка подоцна може да ја смените.

                    </div>
=======
                            <asp:TextBox ID="txtEmail" runat="server" class="form-control" placeholder="емаил"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>
                            
                        </td>
                        <td>
                            
                            <asp:Button ID="btnCancel" runat="server" Text="cancel" class="btn btn-primary" OnClick="btnCancel_Click"/>
                            <asp:Button ID="btnSend" runat="server" Text="испрати барање" class="btn btn-primary" OnClick="btnSend_Click"/>
                        </td>
                    </tr>
                </table>

                    <asp:Label ID="lblErr" runat="server" Text="" ForeColor="Red"></asp:Label>
>>>>>>> cc9771e163cb639c96757945fd47119dba0d514a
                </div>
            </div>
        </div>
    </form>
</body>
</html>
