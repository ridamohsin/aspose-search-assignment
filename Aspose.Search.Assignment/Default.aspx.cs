using Aspose.Search.Assignment.Helpers;
using Aspose.Search.Assignment.Models;
using GroupDocs.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aspose.Search.Assignment
{
    public partial class _Default : Page
    {
        public static string searchType = CommonUtilities.SimpleSearch;
        protected void Page_Load(object sender, EventArgs e)
        {
            List<string> list = Helpers.UIBasedUtility.GetSearchTypesData();
            if (!IsPostBack) {
                SearchTypeDropDownList.DataSource = from i in list
                                                    select new ListItem()
                                                    {
                                                        Text = i,
                                                        Value = i
                                                    };
                SearchTypeDropDownList.DataBind();
            }
      

        }

        protected void SearchSubmitButton_Click(object sender, EventArgs e)
        {
            string searchKeyWord = SearchKeyWordTextBox.Text.ToString();
            switch (searchType)
            {
                case CommonUtilities.SimpleSearch:
                    List<Document> searchResults = Helpers.Search.SimpleSearch(searchKeyWord);
                    ResultsListView.DataSource = searchResults;
                    ResultsListView.DataBind();
                                        break;
                case CommonUtilities.BooleanSearch:
                    
                    break;
                case CommonUtilities.RegexSearch:
                    break;
            }
        }

       
        protected void SearchTypeChanged(object sender, EventArgs e)
        {
            searchType = SearchTypeDropDownList.SelectedValue.ToString();
                }

        //protected void GridView1_ItemDataBound(object sender, ListViewItemEventArgs e)
        //{
        //    var item = e.Item.DataItem as SearchResults;
        //    var lbFolderItem = e.Item.FindControl("lbFolderItem") as LinkButton;
        //    var lnkDownload = e.Item.FindControl("lnkDownload") as LinkButton;
        //    var lnkDelete = e.Item.FindControl("lnkDelete") as LinkButton;
        //    var chSelect = e.Item.FindControl("chSelect") as CheckBox;

        //    if (item.IsFolder)
        //    {
        //        lbFolderItem.Text = "<span class='glyphicon glyphicon-folder-open' aria-hidden='true'></span> " + item.Name;
        //        lnkDownload.Text = "";
        //        chSelect.Visible = false;
        //        // If folder is .., empty the delete link text
        //        if (item.Name == "..")
        //        {
        //            lnkDelete.Text = "";
        //        }

        //    }
        //    else
        //    {
        //        //lbFolderItem.Text = "";
        //        //if (this.CurrentFolder.StartsWith("~"))
        //        //    lbFolderItem.Text = string.Format(@"<a href=""{0}"" target=""_blank"">{1}</a>",
        //        //            Page.ResolveClientUrl(string.Concat(this.CurrentFolder, "/", item.Name).Replace("//", "/")),
        //        //            item.Name);
        //        //else
        //        //    lbFolderItem.Text = item.Name;
        //    }
        //}
    }
}