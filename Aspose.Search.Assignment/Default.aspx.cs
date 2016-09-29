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
        public static string searchType { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            List<string> list = Helpers.UIBasedUtility.GetSearchTypesData();
            if (!IsPostBack)
            {
                SearchTypeDropDownList.DataSource = from i in list
                                                    select new ListItem()
                                                    {
                                                        Text = i,
                                                        Value = i
                                                    };
                SearchTypeDropDownList.DataBind();
                searchType = Helpers.CommonUtilities.SimpleSearch;
            }


        }

        protected void SearchSubmitButton_Click(object sender, EventArgs e)
        {
            string searchTerm1 = SearchTerm1TextBox.Text.Trim().ToString();
            string searchTerm2 = SearchTerm2TextBox.Text != null ? SearchTerm2TextBox.Text.Trim().ToString():String.Empty;
            ResultsListView.DataSource = null;
            ResultsListView.DataBind();
            List<Document> searchResults = new List<Document>();
            string[] searchTerms = new string[2];
            switch (searchType)
            {
                case CommonUtilities.SimpleSearch:
                    searchResults = Helpers.Search.SimpleSearch(searchTerm1);
                    break;
                case CommonUtilities.BooleanSearch:
                    searchResults = Helpers.Search.BooleanSearch(searchTerm1, searchTerm2);
                    break;
                case CommonUtilities.RegexSearch:
                    searchResults = Helpers.Search.RegexSearch(searchTerm1, searchTerm2);
                    break;
            }
            ResultsListView.DataSource = searchResults;
            ResultsListView.DataBind();
        }

        //private string[] GenerateSearchTerms(string searchKeyWord)
        //{
        //    string[] strings = searchKeyWord.Split(',').Select(x => x.Trim()).Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
        //    return strings;
        //}

        protected void SearchTypeChanged(object sender, EventArgs e)
        {
            searchType = SearchTypeDropDownList.SelectedValue.ToString();
            ControlSearchTextBoxesVisibility();
        }

        private void ControlSearchTextBoxesVisibility()
        {
            switch (searchType)
            {
                case CommonUtilities.SimpleSearch:
                    SearchTerm2TextBox.Visible = false;
                    SearchTerm2TextBox.Text=null;
                    RequiredSearchField2Validator.Visible = false;
                    break;
                case CommonUtilities.BooleanSearch:
                    SearchTerm2TextBox.Visible = true;
                    RequiredSearchField2Validator.Visible = true;
                    break;
                case CommonUtilities.RegexSearch:
                    SearchTerm2TextBox.Visible = true;
                    RequiredSearchField2Validator.Visible = true;
                    break;
            }
        }
    }
}