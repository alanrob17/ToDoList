<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProjectOrder.aspx.cs" Inherits="ToDoList.ProjectOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h3><asp:Label ID="pageHeaderLabel" Text="Project Order" runat="server"></asp:Label></h3>
        <div class="row">
            <div class="col-xs-12">
                <div class="table-responsive">
                    <asp:GridView ID="projectGridView" CssClass="table table-striped table-bordered" AutoGenerateColumns="False" AllowPaging="False" DataSourceID="projectDataSource" DataKeyNames="ProjectId" runat="server">
                        <Columns>
                            <asp:BoundField DataField="ProjectId" HtmlEncode="False" HeaderText="ProjectId" InsertVisible="False" Visible="False">
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Project" SortExpression="Name">
                              <HeaderStyle Width="20%"></HeaderStyle>
                              <EditItemTemplate>
                                  <asp:TextBox ID="nameTextBox" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                              </EditItemTemplate>
                              <ItemTemplate>
                                  <asp:Label ID="nameLabel" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                              </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Description">
                              <HeaderStyle Width="70%"></HeaderStyle>
                              <EditItemTemplate>
                                  <asp:TextBox ID="descriptionTextBox" runat="server" Text='<%# Bind("Description") %>' TextMode="MultiLine" Width="95%" Height="70px"></asp:TextBox>
                              </EditItemTemplate>
                              <ItemTemplate>
                                  <asp:Label ID="descriptionLabel" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                              </ItemTemplate>
                              </asp:TemplateField>
                                <asp:TemplateField HeaderText="Order">
                                  <HeaderStyle Width="10%"></HeaderStyle>
                                  <EditItemTemplate>
                                      <asp:TextBox ID="orderTextBox" runat="server" Text='<%# Bind("Order") %>'></asp:TextBox>
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
    </div>
    <asp:ObjectDataSource
         id="projectDataSource"
         TypeName="ToDoDAL.ProjectData"
         SelectMethod="SelectProjectsByOrder"
         UpdateMethod="Update"
         Runat="server">
            <UpdateParameters>
                <asp:Parameter Name="ProjectId" Type="Int32" />
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="Description" Type="String" />
                <asp:Parameter Name="Order" Type="Int32" />
            </UpdateParameters>
    </asp:ObjectDataSource>  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="EndOfPageContent" runat="server">
</asp:Content>
