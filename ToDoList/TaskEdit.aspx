<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TaskEdit.aspx.cs" Inherits="ToDoList.TaskEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="row" id="formblock">
    <div class="col-xs-12 col-md-8 center-block">
      <div class="panel panel-primary">
        <div class="panel-heading">
          <div class="panel-title">&nbsp;<strong>Update Task</strong></div>
        </div>
        <div class="panel-body">
          <div class="form-horizontal">
            <input type="hidden" id="hiddenTaskPK" runat="server" /> 
            <input type="hidden" id="hiddenProjectPK" runat="server" /> 
            <input type="hidden" id="hiddenOrder" runat="server" /> 
            <input type="hidden" id="hiddenStartDate" runat="server" /> 
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
                <strong>Task Name:</strong></label>
              <div class="col-md-10">
                <asp:TextBox ID="nameTextBox" runat="server"
                  CssClass="form-control width" TextMode="SingleLine"
                  title="Task"></asp:TextBox>
                  <asp:RequiredFieldValidator ID="nameRequiredFieldValidator" ControlToValidate="nameTextBox" runat="server" ForeColor="red" ErrorMessage="[Name required]"></asp:RequiredFieldValidator>
              </div>
            </div>
            <div class="form-group">
              <label for="descriptionTextBox" class="control-label col-md-2"><strong>Description:</strong></label>
                  <div class="col-md-10">
                    <asp:TextBox ID="descriptionTextBox" runat="server"
                      CssClass="form-control width" TextMode="MultiLine" Height="220px"
                      placeholder="Description" title="Description"></asp:TextBox>
                  </div>
            </div>
            <div class="form-group">
              <label for="targetDateTextBox" class="control-label col-md-2"><strong>Target Date:</strong></label>
              <div class="col-xs-4">
                  <div class="input-group">
                <asp:TextBox ID="targetDateTextBox" runat="server" CssClass="form-control" TextMode="Date" 
                  placeholder="Target Date" title="Target Date">
                </asp:TextBox>
                <span class="input-group-addon">
                     <i class="glyphicon glyphicon-calendar"></i>
                  </span>
                  </div>
                  <asp:RequiredFieldValidator ID="targetDateRequiredFieldValidator" ControlToValidate="targetDateTextBox" runat="server" ForeColor="red" ErrorMessage="[Target Date Required]"></asp:RequiredFieldValidator>
              </div>
            </div>
            <div class="form-group">
              <label for="importanceDropDownList" class="control-label col-md-2"><strong>Importance:</strong></label>
              <div class="col-md-10">
                <asp:DropDownList ID="importanceDropDownList" runat="server"
                    CssClass="form-control"
                  title="Select Importance">
                </asp:DropDownList>
                  <asp:CustomValidator runat="server" id="importanceCustomValidator" ControlToValidate="importanceDropDownList" OnServerValidate="importanceCustomValidator_ServerValidate" ForeColor="red" ErrorMessage="Select a priority value" />
              </div>
            </div>
            <div class="form-group">
              <label for="statusDropDownList" class="control-label col-md-2"><strong>Status:</strong></label>
              <div class="col-md-10">
                <asp:DropDownList ID="statusDropDownList" runat="server"
                  CssClass="form-control"
                  title="Status">
                </asp:DropDownList>
                <asp:CustomValidator runat="server" id="statusCustomValidator1" ControlToValidate="statusDropDownList" OnServerValidate="statusCustomValidator_ServerValidate" ForeColor="red" ErrorMessage="Select a status value" />  
              </div>
            </div>
            <div class="row">
              <div class="col-xs-12">
                <div id="divMessageArea"
                  runat="server"
                  visible="false">
                  <div class="well">
                    <asp:Label ID="messageLabel" runat="server"
                      CssClass="text-warning"
                      Text="Area to display messages." />
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div class="panel-footer">
          <div class="row">
            <div class="col-xs-12">
               <asp:button id="SubmitButton" CssClass="btn btn-primary" runat="server" Text="Save" OnClick="SubmitButton_Click"></asp:button>&nbsp;
                <asp:button id="CancelButton" CssClass="btn btn-primary" runat="server" Text="Cancel" OnClick="CancelButton_Click"></asp:button>               
             </div>
          </div>
        </div>
      </div>
    </div>
  </div>
  <asp:ObjectDataSource ID="importanceObjectDataSource" runat="server"
    TypeName="ToDoDAL.TaskData"
    SelectMethod="SelectImportanceList" />
  <asp:ObjectDataSource ID="statusObjectDataSource" runat="server"
    TypeName="ToDoDAL.TaskData"
    SelectMethod="SelectStatusList" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="EndOfPageContent" runat="server">
     <style type="text/css">
        #formblock {
            margin-top: 20px;
        }
        /* Set widths on the form inputs since otherwise they're 100% wide */
        input,
        select,
        textarea {
            max-width: 280px;
        }       

        .width {
            max-width: 480px;
        }
    </style>
</asp:Content>
