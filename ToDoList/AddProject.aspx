<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddProject.aspx.cs" Inherits="ToDoList.AddProject" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row" id="formblock">
    <div class="col-xs-12 col-md-8 center-block">
      <div class="panel panel-primary">
        <div class="panel-heading">
          <div class="panel-title">&nbsp;<strong>Add Project</strong></div>
        </div>
          <div class="form-horizontal">
            <div class="form-group">
                <br/>
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
        <div class="panel-footer">
          <div class="row">
            <div class="col-xs-12">
               <asp:button id="SubmitButton" CssClass="btn btn-primary" runat="server" Text="Save" OnClick="SubmitButton_Click"></asp:button>          
               </div>
          </div>
        </div>
      </div>
    </div>
  </div>
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
