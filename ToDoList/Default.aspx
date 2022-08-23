<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ToDoList._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron jumbotron-billboard">
      <div class="img"></div>
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <h1 style="color: navy;">Task list</h1>
                    <p class="lead" style="color: navy;">This is a list of tasks that I need to carry out.</p>
                    <h3 class="dateLabel"><asp:label ID="dateLabel" runat="server"></asp:label></h3>
                    <h4 class="clockFace"><asp:TextBox ID="textClock" Width="80px" BorderStyle="None" ForeColor="#000099" Font="Bold" runat="server"></asp:TextBox></h4>    
                </div>
            </div>
        </div>
    </div>
    <asp:HyperLink ID="allHyperLink" NavigateUrl="ShowTasks/all" runat="server">All Tasks</asp:HyperLink><br/>
    <asp:HyperLink ID="levelHyperLink" NavigateUrl="ShowTasks/level~Medium" runat="server">Order tasks by level</asp:HyperLink><br/>
    <asp:HyperLink ID="projectHyperLink" NavigateUrl="ShowTasks/pid~2" runat="server">Show tasks by project</asp:HyperLink><br/>
    <asp:HyperLink ID="dateHyperLink" NavigateUrl="ShowTasks/date" runat="server">Show out of date tasks by project</asp:HyperLink><br/>
    <asp:HyperLink ID="activeHyperLink" NavigateUrl="ShowTasks/status~active" runat="server">Show active tasks</asp:HyperLink><br/>
    <asp:HyperLink ID="HyperLink2" NavigateUrl="ShowTasks/status~completed" runat="server">Show completed tasks</asp:HyperLink><br/>
    <asp:HyperLink ID="taskHyperLink" NavigateUrl="ViewTask/13" runat="server">Show task</asp:HyperLink><br/>
    <asp:Label ID="yearLabel" runat="server"></asp:Label><br/><br/>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="EndOfPageContent" runat="server">
    <style>
    .jumbotron-billboard .img {
        margin-bottom: 0px;
        opacity: 0.2;
        color: #fff;
        background: #000 url("Images/learning-story.png") center center;
        width: 100%;
        height: 100%;
        background-size: cover;
        overflow: hidden;
      position:absolute;
      top:0;left:0;
      z-index:1;
    }
    .jumbotron {position:relative;padding:50px;}
    .jumbotron .container {z-index:2;
     position:relative;
      z-index:2;
    }
    #MainContent_textClock {
        background-color: #FDF2E9;
    }
    </style>
    <script type="text/javascript">
          var yr = new Date();
          var year = yr.getFullYear();
    
          function ShowTime() {
              var dt = new Date();
              var hours = dt.getHours();
    
              var part = "am";
              if (hours > 12) {
                  hours -= 12;
                  part = "pm";
              }
              var newtime = +hours + ":" + dt.getMinutes() + part;
              if (dt.getMinutes() < 10) {
                  newtime = newtime.replace(":", ":0");
              }
              document.getElementById('<%= textClock.ClientID %>').value = newtime;
              window.setTimeout("ShowTime()", 500);
          }
          function runCode() {
              window.setTimeout("ShowTime()", 1000);
          }
    
          $('div.row').hide().fadeIn(1000);
          $('h1').css('text-align', 'center');
          $('p').css('text-align', 'center');
          $('h2.headerLabel').css('text-align', 'center');
          $('h3.dateLabel').css('text-align', 'center');
          $('h4.clockFace').css('text-align', 'center');
          $('#<%=textClock.ClientID %>').css('text-align', 'center');
          runCode();
    </script>
</asp:Content>
