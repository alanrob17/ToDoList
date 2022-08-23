<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShowTasks.aspx.cs" Inherits="ToDoList.Task" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="/Content/PagerStyle.css" rel="stylesheet" type="text/css" />
    <div class="container">
        <h3><asp:Label ID="pageHeaderLabel" runat="server"></asp:Label></h3>
        <div class="row">
            <div class="col-xs-12">
                <div class="table-responsive">
                    <asp:GridView ID="taskGridView" CssClass="table table-striped table-bordered" AutoGenerateColumns="False" AllowPaging="True" PageSize="15"  DataSourceID="taskDataSource" runat="server">
                       <Columns>
                          <asp:BoundField DataField="ProjectName" HtmlEncode="False" HeaderText="Project">
                              <HeaderStyle Width="10%"></HeaderStyle>
                          </asp:BoundField>
                          <asp:BoundField DataField="TaskName" HtmlEncode="False" HeaderText="Task">
                              <HeaderStyle Width="30%"></HeaderStyle>
                          </asp:BoundField>
                          <asp:BoundField DataField="TaskDescription" HeaderText="Description">
                              <HeaderStyle Width="31%"></HeaderStyle>
                          </asp:BoundField>
                          <asp:BoundField DataField="StartDate" HeaderText="Start" DataFormatString="{0:d}">
                              <HeaderStyle Width="7%"></HeaderStyle>
                          </asp:BoundField>
                          <asp:BoundField DataField="TargetDate" HeaderText="Target" DataFormatString="{0:d}">
                              <HeaderStyle Width="7%"></HeaderStyle>
                          </asp:BoundField>
                          <asp:BoundField DataField="Importance" HeaderText="Level" HtmlEncode="False">
                              <HeaderStyle Width="5%"></HeaderStyle>
                          </asp:BoundField>
                          <asp:BoundField DataField="Status" HeaderText="Status" HtmlEncode="False">
                              <HeaderStyle Width="5%"></HeaderStyle>
                          </asp:BoundField>
                       </Columns>             
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
    <asp:ObjectDataSource
         id="taskDataSource"
         TypeName="ToDoDAL.TaskData"
         SelectMethod="SelectTasks"
         Runat="server">
            <SelectParameters>                                            
                 <asp:RouteParameter Name="show" RouteKey="show" Type="string" />
            </SelectParameters>
    </asp:ObjectDataSource>        
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="EndOfPageContent" runat="server">
        <script type="text/javascript">
        function runCode() {
            window.setTimeout("ShowTime()", 1000);
        }

        $(document).ready(function () {
            $(document).ready(function () {
                var today = new Date();
                if ($("#<%=pageHeaderLabel.ClientID%>").innerHTML != "Completed Tasks") {
                    $("#<%=taskGridView.ClientID%> tr:has(td)").each(function () {
                        var cell = $(this).find("td:eq(4)");
                        var date = $(cell).html();
                        var dateParts = date.split("/");
                        var targetDate = new Date(dateParts[2], dateParts[1] - 1, dateParts[0]); // month is 0-based
                        if (today > targetDate) {
                            $(cell).css("background-color", "#fa8072");
                        }
                    });
                }
            });
        });
     </script>
</asp:Content>
