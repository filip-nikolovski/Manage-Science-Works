<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Events.aspx.cs" Inherits="Diplomska.Events" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Настани</title>

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
                 scrollTop: $("#addWork").offset().top
             }, 1000);
         }

         function hide(id) {
             var target = document.getElementById(id);
             //window.location = "#gv";

             $('html,body').animate({
                 scrollTop: $("#newWork").offset().top
             }, 500);
             target.style.display = "none";
         }

    </script>



        
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div id="acount">
                <a href="http://www.ukim.edu.mk/" style="float: left">
                    <asp:Image ID="imgLogo" runat="server" ImageUrl="~/Images/ukim-logo-9.png" /></a><a href="http://www.finki.ukim.mk/mk/home" style="float: left"> <asp:Image ID="imgLogo1" runat="server" ImageUrl="~/Images/finki-logo-9.png" /></a><a href="http://liit.finki.ukim.mk/" style="float: left"><asp:Image ID="ImageliitLogo" runat="server" ImageUrl="~/Images/liit1 logo.png"  Style="height:100%;width:70%;float:left;margin-bottom:-1px"/></a>

                <asp:Label ID="lblLogedAs" runat="server" Text=""></asp:Label><a href="UserProfile.aspx"><asp:Label ID="lblLogedAs1" runat="server" Text=""></asp:Label></a>

              (<asp:LinkButton runat="server" ID="lbtnLoguot" OnClick="Button1_Click" Text="Logout"></asp:LinkButton>)

            </div>

            <div class="masthead">

                <ul class="nav nav-justified">
                    <li ><a href="Index.aspx">Научен Труд</a></li>
                    <li><a href="Conference.aspx">Конференција</a></li>
                    <li class="active"><a href="Events.aspx">Настани</a></li>

                </ul>
            </div>
        
             <asp:ScriptManager ID="ScriptManager2" runat="server">
                        </asp:ScriptManager>
            

        <div class="main-content" >
             <div class="main-content1">
                 <div class="topMain">
                                <h3 class="text-muted">
                                    <asp:Label ID="lblTitleEmpty" runat="server" Text=""></asp:Label></h3>
                            </div>
            <div id="newWork">
                    <asp:Label ID="lblNew" runat="server" Text="Додади настан"></asp:Label>
                    
                 <input type="button" onclick="display('addWork')" value=" add " class="scroll btn btn-default"/>
                    &nbsp;</div>
            <asp:GridView ID="gvEvents" runat="server" DataKeyNames="id" AutoGenerateColumns="False" Style="width: 100%" OnSelectedIndexChanged="gvEvents_SelectedIndexChanged" OnRowCreated="gvEvents_RowCreated" CellPadding="6" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField HeaderText="#">
                        <ItemTemplate>
                            <%# Container.DataItemIndex +1+"." %>
                        </ItemTemplate>
                    </asp:TemplateField>
                   
                    <asp:BoundField DataField="event" HeaderText="Event" />
                    <asp:BoundField DataField="HolidayDate" HeaderText="Date" />
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
           
            <asp:Label ID="lblErr" runat="server" Text="" ForeColor="Red"></asp:Label>
                 
      
            </div>
             <asp:Panel  runat="server" ID="addWork" class="add" Style="display: none">
               
                 <button type="button" class="close" aria-hidden="true"  onclick="hide('addWork')">&times;</button>
                 <h3 class="text-muted" >
                    <asp:Label ID="lblTitle1" runat="server" Text="Креирај Настан"></asp:Label></h3>

                <table >
                    <tr>
                        <td>
                             <asp:Label ID="lblSW" runat="server" Text="Конференција"></asp:Label>
                
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSW" runat="server" DataTextField="fname" DataValueField="id" AppendDataBoundItems="true" AutoPostBack="false" class="form-control" >
                    <asp:ListItem Value="0">=Select=</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Задолжително поле" Display="Dynamic" ControlToValidate="ddlSW" ValidationGroup="group1" InitialValue="0"></asp:RequiredFieldValidator>

                        </td>
                    </tr>
                    <tr>
                        <td>
                             <asp:Label ID="lblEvent" runat="server" Text="Настан"></asp:Label>  
               
                        </td>
                        <td>
                         <asp:DropDownList ID="ddlEvent" runat="server" AutoPostBack="false" class="form-control" >
                    <asp:ListItem Value="0">=Select=</asp:ListItem>
                    <asp:ListItem Value="date_abstract">Date abstract</asp:ListItem>
                    <asp:ListItem Value="date_full_paper">Date full paper </asp:ListItem>
                    <asp:ListItem Value="date_izvestuvajne">Date izvestuvajne</asp:ListItem>
                    <asp:ListItem Value="date_camera_ready">Date camera ready</asp:ListItem>
                    <asp:ListItem Value="date_konferencija">Date konferencija</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Задолжително поле" Display="Dynamic" ControlToValidate="ddlEvent" ValidationGroup="group1" InitialValue="0"></asp:RequiredFieldValidator>

                      

                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblEventDate" runat="server" Text="Датум"></asp:Label>
           
                        </td>
                        <td>
                             <asp:TextBox ID="txtEventDate" runat="server" class="form-control" ></asp:TextBox>
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/icon.jpg" AlternateText="Calendar" Height="20px" Width="20px" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*Задолжително поле" Display="Dynamic" ControlToValidate="txtEventDate" ValidationGroup="group1"></asp:RequiredFieldValidator>
            <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtEventDate" PopupButtonID="ImageButton1" Format="yyyy-MM-dd"  PopupPosition="TopRight"></asp:CalendarExtender>

                        </td>
                    </tr>
        
                </table>

                 <div class="btnDown" style="margin-right:42%">
                            <input type="button" onclick="hide('addWork')" value="Cancel " class="scroll btn btn-primary"/>

                      <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="group1"  class="btn btn-primary"/>
                            
                 </div>
        
               
           
            </asp:Panel>
        </div>
        
            <div class="aside">
                
                
                    
                <section>
                   
                    <div id="inTouch" style="margin-top:3%">
                        
                            <div class="asideCalendar">

                                

                            <asp:Calendar ID="Calendar1"  SelectionMode="Day" runat="server" OnDayRender="Calendar1_DayRender"   OnVisibleMonthChanged="Calendar1_VisibleMonthChanged" OnSelectionChanged="Calendar1_SelectionChanged"  Style="width: 100%">
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
                                DropShadow="True" >
                            </ajaxToolkit:ModalPopupExtender>

                        <asp:Panel ID="Panel1" runat="server" Style="display: none" CssClass="modalPopupCalendar">
                            <div class="calTitile">
                                <asp:Label ID="lblPopTitle" runat="server" Text=""></asp:Label>
                            </div>

                        </asp:Panel>

                    <h4 style="margin-left:4%"><asp:Label ID="lblReminderTitle" runat="server" Text="Настани кои следуваат"></asp:Label> </h4>
           <div runat="server"  id="pnl" class="asideReminder">
                   
                        <asp:GridView ID="gvReminder" runat="server" DataKeyNames="id" AutoGenerateColumns="False" Style="width: 100%" OnRowCreated="gvReminder_RowCreated" OnSelectedIndexChanged="gvReminder_SelectedIndexChanged" ShowHeader="False" CellPadding="7" ForeColor="#333333" GridLines="None" EmptyDataText="Нема настани во наредните неколку денови.">
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
                    
                </section>
                
            </div>
           
            </div>
       
            <script>
                var idd;
                function ShowInfo(id, ss) {

                    $get('<%=lblPopTitle.ClientID %>').innerText = ss;
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
