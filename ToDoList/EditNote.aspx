<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditNote.aspx.cs" Inherits="ToDoList.EditNote" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="row" id="formblock">
    <div class="col-xs-12 col-md-7 center-block">
      <div class="panel panel-primary">
        <div class="panel-heading">
          <div class="panel-title">&nbsp;<strong>Update Note</strong></div>
        </div>
            <input type="hidden" id="hiddenTaskPK" runat="server" /> 
            <input type="hidden" id="hiddenNotePK" runat="server" />
            <input type="hidden" id="hiddenStartDate" runat="server" />                               
            <div class="panel-body">
            <div class="form-horizontal">
            <div class="form-group">
              <label for="taskTextBox" class="control-label col-md-2"><strong>Task:</strong></label>
              <div class="col-md-10">
                <strong><asp:TextBox ID="taskTextBox" TextMode="SingleLine" ReadOnly="True" runat="server"
                  CssClass="form-control"></asp:TextBox></strong>
              </div>
            </div>
            <div class="form-group">
              <label for="descriptionTextBox" class="control-label col-md-2">
                <strong>Description:</strong></label>
              <div class="col-md-10">
                <asp:TextBox ID="descriptionTextBox" runat="server" 
                  CssClass="form-control" TextMode="MultiLine" Height="60px"
                  title="Task"></asp:TextBox>
                  <asp:RequiredFieldValidator ID="descriptionRequiredFieldValidator" ControlToValidate="descriptionTextBox" runat="server" ForeColor="red" ErrorMessage="[Description required]"></asp:RequiredFieldValidator>
              </div>
            </div>
            <div class="form-group">
              <label for="targetDateTextBox" class="control-label col-md-2"><strong>Target Date:</strong></label>
              <div class="col-xs-4">
                  <div class="input-group">
                <asp:TextBox ID="targetDateTextBox" runat="server" CssClass="form-control"
                  placeholder="Target Date" title="Target Date" TextMode="Date">
                </asp:TextBox>
                <span class="input-group-addon">
                     <i class="glyphicon glyphicon-calendar"></i>
                  </span>
                  </div>
                  <asp:RequiredFieldValidator ID="targetDateRequiredFieldValidator" ControlToValidate="targetDateTextBox" runat="server" ForeColor="red" ErrorMessage="[Target Date Required]"></asp:RequiredFieldValidator>
              </div>
            </div>
            <div class="form-group">
              <label for="statusDropDownList" class="control-label col-md-2"><strong>Status:</strong></label>
              <div class="col-md-10">
                <asp:DropDownList ID="statusDropDownList" runat="server"
                  CssClass="form-control width" DataSourceID="statusObjectDataSource"
                  DataValueField="Status" title="Status">
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

          </div>
        <asp:Panel ID="footerPanel" runat="server">
        <div class="panel-footer">
          <div class="row">
            <div class="col-xs-12">
               <asp:button id="SubmitButton" CssClass="btn btn-primary" runat="server" Text="Save" OnClick="SubmitButton_Click"></asp:button>&nbsp;
                <asp:button id="DeleteButton" CssClass="btn btn-warning" runat="server" Text="Delete" OnClick="DeleteButton_Click"></asp:button>
             </div>
          </div>
        </div>
       </asp:Panel>
      </div>
  </div>
  <asp:ObjectDataSource ID="statusObjectDataSource" runat="server"
    TypeName="ToDoDAL.TaskData"
    SelectMethod="SelectStatusList" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="EndOfPageContent" runat="server">
    <script type="text/css" src="content/styles.css"></script>
     <style type="text/css">
        #formblock {
            margin-top: 20px;
        }
        /* Set widths on the form inputs since otherwise they're 100% wide */
        input,
        select,
        textarea {
            max-width: 480px;
        }       
        .width {
            max-width: 210px;
        } 
    </style>
</asp:Content>
