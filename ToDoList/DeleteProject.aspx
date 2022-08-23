<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DeleteProject.aspx.cs" Inherits="ToDoList.DeleteProject" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="row" id="formblock">
    <div class="col-xs-12 col-md-8 center-block">
      <div class="panel panel-primary">
        <div class="panel-heading">
          <div class="panel-title">&nbsp;<strong>Delete Project</strong></div>
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
                  title="Select Project">
                    <asp:ListItem Text="Select Project" Value="0" />
                </asp:DropDownList>
              </div>
            </div>
              <asp:Panel ID="dataPanel" runat="server">
                  <div class="form-group">
                      <asp:Label ID="deleteLabel" runat="server" ForeColor="red" class="control-label col-md-8"><strong>You are about to delete the following project!</strong></asp:Label>
                  </div>
            <div class="form-group">
              <label for="nameTextBox" class="control-label col-md-2">
                <strong>Task Name:</strong></label>
              <div class="col-md-10">
                <asp:TextBox ID="nameTextBox" runat="server"
                  CssClass="form-control width" TextMode="SingleLine"
                  title="Task"></asp:TextBox>
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
               <asp:button id="deleteButton" CssClass="btn btn-danger" runat="server" Text="Delete"
                            CommandName="Delete"
                            OnClientClick="return confirm('This will permanently delete this Project and related records. Are you sure you want to do this?');"                            
                            OnCommand="deleteButton_ItemDeleted"></asp:button>&nbsp;                    
               <asp:button id="returnButton" CssClass="btn btn-primary" runat="server" Text="Home" OnClick="returnButton_Click"></asp:button>               
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="EndOfPageContent" runat="server">
</asp:Content>
