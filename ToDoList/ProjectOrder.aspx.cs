// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectOrder.aspx.cs" company="Software Inc.">
//   A.Robson
// </copyright>
// <summary>
//   Defines the ProjectOrder type.
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

    public partial class ProjectOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}

/*
        <script src="Scripts/jquery-1.10.2.js"></script>
        <script type="text/javascript">
            $(document).ready(function () {
                
                $("projectGridView.ClientID").submit(function (evt) {
                    alert("hello");
                    if ($("#projectGridView input:text").length > 0) {
                        if ($("#projectGridView :input[name$='nameTextBox']").val() == "") {
                            alert("Please enter project name!");
                            evt.preventDefault();
                        }
                        if ($("#projectGridView :input[name$='descriptionTextBox']").val() == "") {
                            alert("Please enter description!");
                            evt.preventDefault();
                        }
                        if ($("#projectGridView :input[name$='orderTextBox']").val() == "") {
                            alert("Please add order value!");
                            evt.preventDefault();
                        }
                    }

                    alert($("#projectGridView :input[name$='nameTextBox']").val());
                    alert($("#projectGridView :input[name$='descriptionTextBox']").val());
                    alert($("#projectGridView :input[name$='orderTextBox']").val());
                });

            });
        </script>

*/