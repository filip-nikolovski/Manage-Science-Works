﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Versions.aspx.cs" Inherits="Diplomska.Versions" EnableEventValidation="false"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Верзии</title>

   
     <link href="style/style.css" rel="stylesheet" />
     <link href="style/bootstrap.css" rel="stylesheet" />
    <link href="style/justified-nav.css" rel="stylesheet" />
    <script type="text/javascript" src="scripts/jquery.js"></script>

     <script>


         function display(id) {

             var traget = document.getElementById(id);

             traget.style.display = "block";
             //window.location = "#addConference ";
             $('html,body').animate({
                 scrollTop: $("#newVersion").offset().top
             }, 750);

           
         }

         function display1(id) {

             var traget = document.getElementById(id);

             traget.style.display = "block";
             //window.location = "#addConference ";
             $('html,body').animate({
                 scrollTop: $("#newVersion1").offset().top
             }, 750);


         }

         function hide(id) {
             var target = document.getElementById(id);
             //window.location = "#gv";
             target.style.display = "none";
          
             document.getElementById('txtVersionName1').value = '';
         }
    </script>



</head>
<body>
    <form id="form1" runat="server" method="post" enctype="multipart/form-data">
        <ajaxToolkit:ToolkitScriptManager runat="Server" ID="ScriptManager1" />
        <div class="container">
            <div id="acount">
               <a href="http://www.ukim.edu.mk/" style="float: left">
                    <asp:Image ID="imgLogo" runat="server" ImageUrl="~/Images/ukim-logo-9.png" /></a><a href="http://www.finki.ukim.mk/mk/home" style="float: left"> <asp:Image ID="imgLogo1" runat="server" ImageUrl="~/Images/finki-logo-9.png" /></a><a href="http://liit.finki.ukim.mk/" style="float: left"><asp:Image ID="ImageliitLogo" runat="server" ImageUrl="~/Images/liit1 logo.png"  Style="height:100%;width:70%;float:left;margin-bottom:-1px"/></a>

                <asp:Label ID="lblLogedAs" runat="server" Text=""></asp:Label><a href="UserProfile.aspx"><asp:Label ID="lblLogedAs1" runat="server" Text=""></asp:Label></a>
              (<asp:LinkButton runat="server" ID="lbtnLoguot" OnClick="Button1_Click" Text="Logout"></asp:LinkButton>)
            </div>

            <div class="masthead">

                <ul class="nav nav-justified">
                    <li class="active"><a href="Index.aspx">Научен Труд</a></li>
                    <li><a href="Conference.aspx">Конференција</a></li>
                    <li><a href="Events.aspx">Настани</a></li>

                </ul>
                <a href="Index.aspx" style="margin-bottom: -15px;">Научен Труд> </a>Верзии
            </div>

            <div class="main-content" style="width:73%">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>

                        <div class="main-content1">

                            <div class="topMain">
                                <h3 class="text-muted">
                                    <asp:Label ID="lblTitle" runat="server" Text="Избраниот труд нема креирано верзии."></asp:Label></h3>
                            </div>
                            <div id="newWork">

                                <asp:Label ID="lblNew" runat="server" Text="Додади нова верзија"></asp:Label>

<<<<<<< HEAD
                                <input type="button" onclick="display('newVersion')" value=" add " class=" btn btn-default" />
=======
                                <input type="button" onclick="display('newVersion')" value=" add " class="scroll btn btn-default" />
>>>>>>> cc9771e163cb639c96757945fd47119dba0d514a
                            </div>
                            <asp:GridView ID="gvVersions" runat="server" DataKeyNames="id_version" OnRowCreated="gvVersions_RowCreated" AutoGenerateColumns="False" OnSelectedIndexChanged="gvVersions_SelectedIndexChanged" Style="width: 100%" CellPadding="4" ForeColor="#333333" GridLines="None">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:TemplateField HeaderText="No.">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex +1+"." %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="version_name" HeaderText="Version Name" />
                                    <asp:BoundField DataField="uploader" HeaderText="Uploaded by" />
                                    <asp:BoundField DataField="date_upload" HeaderText="Date Uplod" />
                                    <asp:BoundField DataField="description" HeaderText="Description" />


                                    <asp:TemplateField HeaderText="Active Version">
                                        <ItemTemplate>
                                            <input name="MyRadioButton" type="radio" value='<%# Eval("id_version") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Button ID="btnEdit" runat="server" Text="edit" RowIndex='<%# Eval("id_version") %>'
<<<<<<< HEAD
                                                OnClick="btnEdit_click" OnClientClick="display1('newVersion1')" class=" btn btn-default" />
=======
                                                OnClick="btnEdit_click" OnClientClick="display1('newVersion1')" class="scroll btn btn-default" />
>>>>>>> cc9771e163cb639c96757945fd47119dba0d514a
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
<<<<<<< HEAD
                                            <asp:Button ID="ibtn1" runat="server" Text="delete" RowIndex='<%# Eval("id_version") %>' OnClick="button_click" class=" btn btn-default" />
=======
                                            <asp:Button ID="ibtn1" runat="server" Text="delete" RowIndex='<%# Eval("id_version") %>' OnClick="button_click" class="scroll btn btn-default" />
>>>>>>> cc9771e163cb639c96757945fd47119dba0d514a
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Button ID="btnSource" runat="server" Text="source files" RowIndex='<%# Eval("id_version") %>' OnClick="btnSource_Click" class="btn btn-default" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                             
<<<<<<< HEAD
                                     <asp:TemplateField>
                                        <ItemTemplate>
                                            <a href="<%# Eval("file_path")%>">download</a>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkDownload" Text = "view" RowIndex= '<%# Eval("id_version") %>' runat="server" OnClick = "DownloadFile"></asp:LinkButton>
=======

                                    <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkDownload" Text = "Download" RowIndex= '<%# Eval("id_version") %>' runat="server" OnClick = "DownloadFile"></asp:LinkButton>
>>>>>>> cc9771e163cb639c96757945fd47119dba0d514a
                                    </ItemTemplate>
                                </asp:TemplateField>
                                

                                </Columns>
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />

                            </asp:GridView>
                            <br />
                            <asp:Button ID="btnSelectVesion" runat="server" Text="set active version" OnClick="btnSelectVesion_Click" Style="float: right" class=" btn btn-default" />
                            <br />
                            <asp:Label ID="lblEx" runat="server" Text=""></asp:Label>
                        </div>

                        <div runat="server" id="newVersion1" style="display: block" class="add">

                            
                            <button type="button" class="close" aria-hidden="true" onclick="hide('newVersion1')">&times;</button>
                            <h3 class="text-muted">
                                <asp:Label ID="Label2" runat="server" Text="Измени "></asp:Label></h3>
                            <table >
                                <tr>
                                    <td>
                                        <asp:Label ID="lblVersionName1" runat="server" Text="Наслов на верзијата "></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="txtVersionName1" runat="server" class="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*Задолжително поле" Display="Dynamic" ControlToValidate="txtVersionName1" ValidationGroup="group1"></asp:RequiredFieldValidator>

                                    </td>
                                </tr>
                                <tr>
                                    <td>
<<<<<<< HEAD
                                        <asp:Label ID="lblDesc" runat="server" Text="Опис "></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="txtDesc" runat="server" class="form-control"></asp:TextBox>

                                    </td>
                                </tr>
                                <tr>
                                    <td>
=======
>>>>>>> cc9771e163cb639c96757945fd47119dba0d514a
                                        <asp:Label ID="lblActive1" runat="server" Text="Дали верзијата е активна"></asp:Label></td>
                                    <td>
                                        <asp:RadioButtonList ID="RadioButtonList11" runat="server">
                                            <asp:ListItem Text="Да" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="не" Value="0"></asp:ListItem>
                                        </asp:RadioButtonList>
                                </tr>


                            </table>
                            <div class="btnDown" style="margin-right:33%">
<<<<<<< HEAD
                                        <input type="button" onclick="hide('newVersion1')" value="Cancel" class=" btn btn-primary" />
=======
                                        <input type="button" onclick="hide('newVersion1')" value="Cancel" class="scroll btn btn-primary" />
>>>>>>> cc9771e163cb639c96757945fd47119dba0d514a

                                 <asp:Button ID="btnUpdate1" runat="server" Text="Update" OnClick="btnUpdate_Click" class="btn btn-primary" Visible="false"  ValidationGroup="group1"/>
                                    
                            </div>
                            <asp:Label ID="lblMsg1" runat="server" Text=""></asp:Label>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>

                <div runat="server" id="newVersion" style="display: block" class="add">

                   
                    <button type="button" class="close" aria-hidden="true" onclick="hide('newVersion')">&times;</button>
                    <h3 class="text-muted">
                        <asp:Label ID="lblTitle1" runat="server" Text="Креирај Верзија"></asp:Label></h3>
                    <table >
                        <tr>
                            <td>
                                <asp:Label ID="lblVersionName" runat="server" Text="Наслов на везијата "></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtVersionName" runat="server" class="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Задолжително поле" Display="Dynamic" ControlToValidate="txtVersionName" ValidationGroup="group2"></asp:RequiredFieldValidator>

                            </td>
                        </tr>
<<<<<<< HEAD

                        <tr>
                            <td>
                                <asp:Label ID="lblDesc1" runat="server" Text="Опис "></asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtDesc1" runat="server" class="form-control"></asp:TextBox>

                            </td>
                        </tr>

=======
>>>>>>> cc9771e163cb639c96757945fd47119dba0d514a
                        <tr>
                            <td>
                                <asp:Label ID="lblActive" runat="server" Text="Дали верзијата е активна "></asp:Label></td>
                            <td>
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                                    <asp:ListItem Text="Да" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Не" Value="0"></asp:ListItem>
                                </asp:RadioButtonList>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <asp:FileUpload ID="FileUpload1" runat="server" class="form-control" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Задолжително поле" Display="Dynamic" ControlToValidate="FileUpload1" ValidationGroup="group2"></asp:RequiredFieldValidator>

                            </td>
                        </tr>
                        
                    </table>
                    <div class="btnDown" style="margin-right:33%">
<<<<<<< HEAD
                                <input type="button" onclick="hide('newVersion')" value="Cancel" class=" btn btn-primary" />
=======
                                <input type="button" onclick="hide('newVersion')" value="Cancel" class="scroll btn btn-primary" />
>>>>>>> cc9771e163cb639c96757945fd47119dba0d514a

                        <asp:Button ID="btnConfirmAdd" runat="server" Text="Save" OnClick="btnConfirmAdd_Click" class="btn btn-primary" ValidationGroup="group2"/>

                            
                    </div>
                    <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                </div>
            </div>

            <div class="aside" style="width:25%">
                <section>
                   
                    <div id="inTouch">


                         <div class="asideCalendar">
                        <asp:Calendar ID="Calendar1" runat="server" OnDayRender="Calendar1_DayRender" OnVisibleMonthChanged="Calendar1_VisibleMonthChanged" OnSelectionChanged="Calendar1_SelectionChanged" Style="width: 100%">
                            <TodayDayStyle BackColor="#D1DDF1" ForeColor="White" />
                            <OtherMonthDayStyle ForeColor="#CC9966" />
                            <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                            <TitleStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="9pt"
                                ForeColor="White" />
                        </asp:Calendar>
                             </div>
                        <asp:Button runat="server" ID="hiddenTargetControlForModalPopup" Style="display: none" />
                        <ajaxToolkit:ModalPopupExtender runat="server" ID="programmaticModalPopup" BehaviorID="programmaticModalPopupBehavior"
                            TargetControlID="hiddenTargetControlForModalPopup" PopupControlID="Panel1"
                            DropShadow="True" RepositionMode="RepositionOnWindowScroll">
                        </ajaxToolkit:ModalPopupExtender>

                        <asp:Panel ID="Panel1" runat="server" Style="display: none" CssClass="modalPopupCalendar">
                            <div class="calTitile">
                                <asp:Label ID="lblPopTitle1" runat="server" Text=""></asp:Label>
                            </div>

                        </asp:Panel>
                    </div>

                </section>
                 <h4>Настани кои следуваат</h4>
           <div runat="server"  id="pnl" class="asideReminder">
                    

                    <asp:GridView ID="gvReminder" runat="server" DataKeyNames="id" AutoGenerateColumns="False" Style="width: 100%" OnRowCreated="gvReminder_RowCreated" OnSelectedIndexChanged="gvReminder_SelectedIndexChanged" ShowHeader="False" CellPadding="7" ForeColor="#333333" GridLines="None" EmptyDataText="Нема настани." >
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="hol" HeaderText="Event" />
                                <asp:BoundField DataField="HolidayDate"  />
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>

                </div>
            </div>

        </div>

        <script>

            $(document).ready(function () {

                //var tar = document.getElementById('newWork');
                // tar.style.display = "none";

                document.getElementById('<%=newVersion.ClientID%>').style.display = "none";
                document.getElementById('<%=newVersion1.ClientID%>').style.display = "none";
            });
        </script>

        
        <script>
            var idd;
            function ShowInfo(id, ss) {

                $get('<%=lblPopTitle1.ClientID %>').innerText = ss;
                    var div = document.getElementById(id);
                    div.style.display = "block";

                    var pop = $find('programmaticModalPopupBehavior');
                    pop.set_Y(event.clientY);
                    pop.show();
                    idd = id;
                }

                $('#Panel1').on('mouseleave', function () {
                    setTimeout(function () {
                        var div = document.getElementById(idd);
                        div.style.display = "none";
                        $find("programmaticModalPopupBehavior").hide();
                    }, 500);
                });


        </script>
    </form>
</body>
</html>
