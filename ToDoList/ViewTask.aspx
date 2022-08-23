<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewTask.aspx.cs" Inherits="ToDoList.ViewTask" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <script>
    function AddData() {
      $("#hdnPK").val("-1");
      // $("#lblTitle").text("Add New Product");
      $("#anDescriptionTextBox").val("");
      $("#anTargetDateTextBox").val(new Date().toLocaleDateString());
      $("#anStatusTextBox").val("");
      $("#SaveButton").val("Create Note");
      $("#hdnAddMode").val("true");
      $('#addNoteDialog').modal();
    }

  </script>

    <div class="row"><!-- Add Note -->
      <div class="col-xs-12 col-sm-12 col-md-8">
        <div class="modal fade" id="addNoteDialog" tabindex="-1" role="dialog">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                <h4 class="modal-title" id="lblTitle" runat="server">Add new Note</h4>
              </div>
              <div class="modal-body">
                <input type="hidden" id="hdnPK" runat="server" />                
                <input type="hidden" id="hdnAddMode" runat="server" value="false" />
                <div class="row">
                  <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                    <div class="form-group">
                      <label for="anDescriptionTextBox">Description</label>
                      <div class="row">
                        <div class="col-xs-12 col-sm-8 col-md-8 col-lg-8">
                          <asp:TextBox ID="anDescriptionTextBox" runat="server" TextMode="MultiLine" Height="160px" Width="380px"  CssClass="form-control" autofocus="autofocus"
                            required="required" placeholder="Description" title="Description"></asp:TextBox>
                        </div>
                      </div>
                    </div>
                    <div class="form-group">
                      <label for="anTargetDateTextBox">Target Date</label>
                      <div class="row">
                        <div class="col-xs-12 col-sm-4 col-md-4 col-lg-4">
                          <asp:TextBox ID="anTargetDateTextBox" runat="server"
                            CssClass="form-control" TextMode="Date"
                            placeholder="Target Date" title="Target Date"></asp:TextBox>
                        </div>
                      </div>
                    </div>
                    <div class="form-group">
                      <label for="anStatusDropDownList"><strong>Status:</strong></label>
                    <div class="row">
                      <div class="col-xs-12 col-sm-4 col-md-4 col-lg-4">
                    <asp:DropDownList ID="anStatusDropDownList" runat="server"
                      CssClass="form-control"
                      title="Status">
                    </asp:DropDownList>
                    <asp:CustomValidator runat="server" id="anStatusCustomValidator" ControlToValidate="anStatusDropDownList" OnServerValidate="anStatusCustomValidator_ServerValidate" ForeColor="red" ErrorMessage="Select a status value" />  
                    </div>
              </div>
                    </div>
                  </div>
                </div>
                <div id="divMessageArea" runat="server" visible="false">
                  <div class="clearfix"></div>
                  <div class="row messageArea">
                    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                      <div class="well">
                        <asp:Label ID="messageLabel" runat="server"
                          CssClass="text-warning"
                          Text="This is some text to show what a message would look like."></asp:Label>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
              <div class="modal-footer">
                <asp:Button ID="CancelButton" runat="server" 
                  Text="Cancel" 
                  CssClass="btn btn-default"
                  title="Cancel" 
                  data-dismiss="modal" />
                <asp:Button ID="SaveButton" runat="server" 
                  Text="Add Note" 
                  CssClass="btn btn-primary"
                  title="Add Note" 
                  OnClick="ANSaveButton_Click" />
              </div>
            </div>
          </div>
        </div>
      </div>
    </div> <!-- Add Note -->

  <div class="row">
    <div class="col-xs-12 col-md-10 center-block">
      <div class="panel panel-primary">
        <div class="panel-heading">
          <h3 class="panel-title">Task</h3>
        </div>
        <div class="panel-body">
          <div class="form-horizontal">
            <div class="form-group">
              <label for="projectTextBox" class="control-label col-md-2">
                Project:</label>
              <div class="col-md-8">
                   <strong><asp:TextBox ID="projectTextBox" runat="server"
                      CssClass="form-control width" TextMode="SingleLine"
                      title="Task" ReadOnly="True"></asp:TextBox></strong>
              </div>
            </div>
            <div class="form-group">
              <label for="nameTextBox" class="control-label col-md-2">
                Task:</label>
              <div class="col-md-8">
                    <asp:TextBox ID="nameTextBox" runat="server"
                      CssClass="form-control width" TextMode="SingleLine"
                      title="Task" ReadOnly="True"></asp:TextBox>                  
              </div>
            </div>
            <div class="form-group">
              <label for="descriptionTextBox" class="control-label col-md-2"><strong>Description:</strong></label>
                  <div class="col-md-8">
                    <asp:TextBox ID="descriptionTextBox" runat="server"
                      CssClass="form-control width" TextMode="MultiLine" Height="100px"
                      placeholder="Description" title="Description" ReadOnly="True"></asp:TextBox>
                  </div>
            </div>
            <div class="form-group">
              <label for="startDateTextBox" class="control-label col-md-2"><strong>Start Date:</strong></label>
              <div class="col-md-4">
                  <div class="input-group">
                <asp:TextBox ID="startDateTextBox" runat="server" CssClass="form-control"
                  placeholder="Start Date" title="Start Date" ReadOnly="True">
                </asp:TextBox>
                  </div>
              </div>
              <label for="targetDateTextBox" class="control-label col-md-2"><strong>Target Date:</strong></label>
              <div class="col-md-4">
                  <div class="input-group">
                <asp:TextBox ID="targetDateTextBox" runat="server" CssClass="form-control"
                  placeholder="Target Date" title="Target Date" ReadOnly="True">
                </asp:TextBox>
                  </div>
              </div>
            </div>
            <div class="form-group">
              <label for="importanceTextBox" class="control-label col-md-2"><strong>Importance:</strong></label>
              <div class="col-md-4">
                <asp:TextBox ID="importanceTextBox" runat="server" CssClass="form-control"
                  placeholder="Importance" title="Importance" ReadOnly="True">
                </asp:TextBox>
              </div>
              <label for="statusTextBox" class="control-label col-md-2"><strong>Status:</strong></label>
              <div class="col-md-4">
                <asp:TextBox ID="statusTextBox" runat="server" CssClass="form-control"
                  placeholder="Status" title="Status" ReadOnly="True">
                </asp:TextBox>
              </div>
            </div>
              </div>
          <hr/>            
          <asp:Panel ID="dataPanel" runat="server">
            <h4><asp:Label ID="pageHeaderLabel" runat="server">Notes:</asp:Label></h4>
              <input type="hidden" id="hiddenTaskPK" runat="server" />
            <div class="row">
                <div class="col-xs-12">
                    <div class="table-responsive">
                      <asp:GridView ID="notesGridView" runat="server"  CssClass="table table-striped table-bordered" AutoGenerateColumns="False" AllowPaging="False">
                          <Columns>
                              <asp:BoundField DataField="TaskId" HtmlEncode="False" HeaderText="TaskId" InsertVisible="False" Visible="False">
                              </asp:BoundField>
                              <asp:BoundField DataField="NoteId" HtmlEncode="False" HeaderText="NoteId" InsertVisible="False" Visible="False">
                              </asp:BoundField>
                              <asp:TemplateField HeaderText="Description" SortExpression="Description">
                                <HeaderStyle Width="50%"></HeaderStyle>
                                <ItemTemplate>
                                    <a href='../UpdateNote/<%# Eval("NoteId") %>'>
                                        <asp:Label ID="descriptionLabel" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                    </a>
                                </ItemTemplate>
						      </asp:TemplateField>
                              <asp:TemplateField HeaderText="Start" SortExpression="StartDate">
                                <HeaderStyle Width="20%"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:Label ID="startDateLabel" runat="server" Text='<%# Bind("StartDate","{0:d}") %>'></asp:Label>
                                </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="Finish" SortExpression="TargetDate">
                                <HeaderStyle Width="20%"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:Label ID="targetDateLabel" runat="server" Text='<%# Bind("TargetDate","{0:d}") %>'></asp:Label>
                                </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="Status" SortExpression="Status">
                                <HeaderStyle Width="10%"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:Label ID="statusLabel" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                                </ItemTemplate>
                              </asp:TemplateField>
                              </Columns>             
                      </asp:GridView>
                    </div>
                </div> 
              </div>            
          </asp:Panel>
            <div class="form-group">
              <div class="col-md-8">
                  <asp:LinkButton class="btn btn-primary" id="editTaskLink" Text="Edit Task" OnClick="EditButton_Click" runat="server"/>&nbsp;
                  <a href="#" data-toggle="modal" onclick="AddData();" class="btn btn-primary">Add New Note</a>
              </div>
            </div>
            </div>
          </div>
        </div>
      </div>
      <asp:ObjectDataSource ID="anStatusObjectDataSource" runat="server"
        TypeName="ToDoDAL.TaskData"
        SelectMethod="SelectStatusList" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="EndOfPageContent" runat="server">
        <script type="text/css" src="content/styles.css"></script>
        <style type="text/css">
        .row {
            margin-top: 10px;
        } 
        /* Set widths on the form inputs since otherwise they're 100% wide */
        input,
        select,
        textarea {
            max-width: 380px;
        }       

        .width {
            max-width: 480px;
        }

        .form-control[readonly] {
            background-color: #d6ecf7;   
        }

        /*.table-bordered > tbody > tr > td {
            background-color: #e4ecec;
        }*/

        th {
            background-color: #317eac;
            /*color: #ffffff;*/
        }
    </style>
    <script type="text/javascript">
            function runCode() {
                window.setTimeout("ShowTime()", 1000);
            }

            $(document).ready(function () {
                $(document).ready(function () {
                    var today = new Date();
                    $("#<%=notesGridView.ClientID%> tr:has(td)").each(function () {
                        var cell = $(this).find("td:eq(2)");
                        debugger;
                    var date = $(cell).text(); // this will remove the span tags
                    var dateParts = date.split("/");
                    var targetDate = new Date(dateParts[2], dateParts[1] - 1, dateParts[0]); // month is 0-based
                    if (today > targetDate) {
                        $(cell).css("background-color", "#fa8072");
                    }
                });
            });
        });
     </script>

</asp:Content>
