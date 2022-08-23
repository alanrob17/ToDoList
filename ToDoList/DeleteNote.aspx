<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DeleteNote.aspx.cs" Inherits="ToDoList.DeleteNote" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <div class="row" id="formblock">
    <div class="col-xs-12 col-md-8 center-block">
      <div class="panel panel-primary">
        <div class="panel-heading">
          <div class="panel-title">&nbsp;<strong>Delete Note</strong></div>
        </div>
        <div class="panel-body">
          <div class="form-horizontal">
              <asp:Panel ID="dataPanel" runat="server">
                  <div class="form-group">
                      <asp:Label ID="deleteLabel" runat="server" ForeColor="red" class="control-label col-md-8"><strong>You are about to delete the following note!</strong></asp:Label>
                  </div>
                  <input type="hidden" id="hiddenNotePK" runat="server" />
                  <input type="hidden" id="hiddenTaskPK" runat="server" />
            <div class="form-group">
              <label for="taskTextBox" class="control-label col-md-2"><strong>Task:</strong></label>
              <div class="col-md-10">
                <strong><asp:TextBox ID="taskTextBox" TextMode="SingleLine" runat="server"
                  CssClass="form-control"></asp:TextBox></strong>
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
              <label for="startDateTextBox" class="control-label col-md-2"><strong>Start Date:</strong></label>
              <div class="col-xs-4">
                  <div class="input-group">
                <asp:TextBox ID="startDateTextBox" runat="server" CssClass="form-control"
                  placeholder="Start Date" title="Start Date">
                </asp:TextBox>
                <span class="input-group-addon">
                     <i class="glyphicon glyphicon-calendar"></i>
                  </span>
                  </div>
              </div>
            </div>
            <div class="form-group">
              <label for="targetDateTextBox" class="control-label col-md-2"><strong>Target Date:</strong></label>
              <div class="col-xs-4">
                  <div class="input-group">
                <asp:TextBox ID="targetDateTextBox" runat="server" CssClass="form-control"
                  placeholder="Target Date" title="Target Date">
                </asp:TextBox>
                <span class="input-group-addon">
                     <i class="glyphicon glyphicon-calendar"></i>
                  </span>
                  </div>
              </div>
            </div>
            <div class="form-group">
              <label for="statusTextBox" class="control-label col-md-2"><strong>Status:</strong></label>
              <div class="col-md-10">
                <asp:TextBox ID="statusTextBox" CssClass="form-control width" TextMode="SingleLine" title="Status" runat="server"></asp:TextBox>
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
                            OnClientClick="return confirm('This will permanently delete this Task and its notes. Are you sure you want to do this?');"                            
                            OnCommand="DeleteButton_ItemDeleted"></asp:button>&nbsp;                    
               <asp:button id="returnButton" CssClass="btn btn-primary" runat="server" Text="Back" OnClick="ReturnButton_Click"></asp:button>               
             </div>
          </div>
        </div>
       </asp:Panel>
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
            max-width: 480px;
        }       

        .width {
            max-width: 480px;
        }

        .panel-primary > .panel-heading {
            background-color: #c71c22;
        }

    </style>
</asp:Content>
