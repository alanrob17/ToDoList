<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddTask.aspx.cs" Inherits="ToDoList.AddTask" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row" id="formblock">
    <div class="col-xs-12 col-md-8 center-block">
      <div class="panel panel-primary">
        <div class="panel-heading">
          <div class="panel-title">&nbsp;<strong>Add Task</strong></div>
        </div>
        <div class="panel-body">
          <div class="form-horizontal">
            <div class="form-group">
              <label for="projectDropDownList" class="control-label col-md-2">
                Project:</label>
              <div class="col-md-10">
                <asp:DropDownList ID="projectDropDownList" runat="server"
                  CssClass="form-control"
                  autofocus="autofocus"
                  AutoPostBack="true"
                  OnSelectedIndexChanged="projectDropDownList_SelectedIndexChanged"
                  AppendDataBoundItems="true" 
                  DataSourceID="projectObjectDataSource"
                  DataTextField="Name"
                  DataValueField="ProjectId"
                  title="Select Task">
                  <asp:ListItem Text="Select Project" Value="0" />
                </asp:DropDownList>
              </div>
            </div>
              <asp:Panel ID="dataPanel" runat="server">
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
                <asp:TextBox ID="targetDateTextBox" runat="server" TextMode="Date" z-index="1051" CssClass="form-control"
                  placeholder="Target Date" title="Target Date">
                </asp:TextBox>
                <span class="input-group-addon">
                     <i class="glyphicon glyphicon-calendar"></i>
                  </span>
                  </div>
                  <asp:CompareValidator id="targetdateCompareValidator" runat="server" ControlToValidate="targetDateTextBox" ForeColor="red" ErrorMessage="Date must be greater than now" Operator="GreaterThanEqual" Type="Date"></asp:CompareValidator>
              </div>
            </div>
            <div class="form-group">
              <label for="importanceDropDownList" class="control-label col-md-2"><strong>Importance:</strong></label>
              <div class="col-md-10">
                <asp:DropDownList ID="importanceDropDownList" runat="server"
                    CssClass="form-control"
                    AppendDataBoundItems="true"
                    DataSourceID="importanceObjectDataSource"
                    DataTextField="Importance"
                    DataValueField="Importance"
                  title="Select Importance">
                    <asp:ListItem Text="Select Importance" Value="0" />
                </asp:DropDownList>
                <asp:CustomValidator runat="server" id="importanceCustomValidator" ControlToValidate="importanceDropDownList" OnServerValidate="importanceCustomValidator_ServerValidate" ForeColor="red" ErrorMessage="Select a priority value" />
              </div>
            </div>
            <div class="form-group">
              <label for="statusDropDownList" class="control-label col-md-2"><strong>Status:</strong></label>
              <div class="col-md-10">
                <asp:DropDownList ID="statusDropDownList" runat="server"
                  CssClass="form-control"
                  AppendDataBoundItems="true"
                  DataSourceID="statusObjectDataSource"
                  DataTextField="Status"
                    DataValueField="Status"
                  title="Status">
                    <asp:ListItem Text="Select Status" Value="0" />
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
            </asp:Panel>            
          </div>
        </div>
        <asp:Panel ID="footerPanel" runat="server">
        <div class="panel-footer">
          <div class="row">
            <div class="col-xs-12">
               <asp:button id="SubmitButton" CssClass="btn btn-primary" runat="server" Text="Save" OnClick="SubmitButton_Click"></asp:button>          
               </div>
          </div>
        </div>
       </asp:Panel>
      </div>
    </div>
  </div>
  <asp:ObjectDataSource ID="projectObjectDataSource" runat="server"
    TypeName="ToDoDAL.ProjectData"
    SelectMethod="SelectProjectList" />
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
