<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TaskOrder.aspx.cs" Inherits="ToDoList.TaskOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row" id="formblock">
        <div class="col-xs-12 col-md-10 center-block">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <div class="panel-title">&nbsp;<strong>Task Order</strong></div>
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
                    <h3><asp:Label ID="pageHeaderLabel" runat="server"></asp:Label></h3>
                    <div class="row">
                        <div class="col-xs-12">
                            <div class="table-responsive">
                                <asp:GridView ID="taskGridView" CssClass="table table-striped table-bordered" AutoGenerateColumns="False" AllowPaging="False" DataSourceID="taskDataSource" DataKeyNames="TaskId" runat="server">
                                    <Columns>
                                        <asp:BoundField DataField="TaskId" HtmlEncode="False" HeaderText="TaskId" InsertVisible="False" Visible="False">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ProjectId" HtmlEncode="False" HeaderText="ProjectId" InsertVisible="False" Visible="False">
                                            </asp:BoundField>
                                        <asp:TemplateField HeaderText="Task" SortExpression="Name">
                                          <HeaderStyle Width="40%"></HeaderStyle>
                                          <EditItemTemplate>
                                              <asp:TextBox ID="nameTextBox" Width="100%" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                                          </EditItemTemplate>
                                          <ItemTemplate>
                                              <asp:Label ID="nameLabel" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                          </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Priority">
                                            <EditItemTemplate>
                                                <asp:DropDownList ID="importanceDropDownList" runat="server" DataSourceID="importanceObjectDataSource"
                                                    DataTextField="Importance" DataValueField="Importance" SelectedValue='<%# Bind("Importance") %>'
                                                    AppendDataBoundItems="True">
                                                </asp:DropDownList>
                                            </EditItemTemplate>
                                        <ItemTemplate>
                                        <asp:Label ID="importanceLabel" runat="server" Text='<%# Bind("Importance") %>'></asp:Label>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Status">
                                            <EditItemTemplate>
                                                <asp:DropDownList ID="statusDropDownList" runat="server" DataSourceID="statusObjectDataSource"
                                                    DataTextField="Status" DataValueField="Status" SelectedValue='<%# Bind("Status") %>'
                                                    AppendDataBoundItems="True">
                                                </asp:DropDownList>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                            <asp:Label ID="statusLabel" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Order">
                                              <HeaderStyle Width="10%"></HeaderStyle>
                                              <EditItemTemplate>
                                                  <asp:TextBox ID="orderTextBox" Width="50%" runat="server" Text='<%# Bind("Order") %>'></asp:TextBox>
                                              </EditItemTemplate>
                                              <ItemTemplate>
                                                  <asp:Label ID="orderLabel" runat="server" Text='<%# Bind("Order") %>'></asp:Label>
                                              </ItemTemplate>
                                          </asp:TemplateField>
                                          <asp:CommandField ButtonType="Button" ShowEditButton="True" HeaderText="Edit" />
                                        </Columns>             
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
     </div>
    <asp:ObjectDataSource
         id="taskDataSource"
         TypeName="ToDoDAL.TaskData"
         SelectMethod="SelectTasksByOrder"
         UpdateMethod="Update"
         Runat="server">
           <SelectParameters>
                <asp:ControlParameter Name="ProjectId"
                    ControlID="projectDropDownList"
                    PropertyName="SelectedValue" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="TaskId" Type="Int32" />
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="Importance" Type="String" />
                <asp:Parameter Name="Status" Type="String" />
                <asp:Parameter Name="Order" Type="Int32" />
            </UpdateParameters>
    </asp:ObjectDataSource> 
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
            max-width: 380px;
        }       

        .width {
            max-width: 480px;
        }
    </style>
</asp:Content>
