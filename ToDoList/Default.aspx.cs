// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Default.aspx.cs" company="Software inc.">
//   A.Robson
// </copyright>
// <summary>
//   Defines the _Default type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ToDoList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var dtnow = DateTime.Now;
                dateLabel.Text = dtnow.ToLongDateString();
            }
        }
    }
}


/*


        <div class="container">
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





*/