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

        /// <summary>
        /// Page load function
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            List<string> list = Helpers.UIBasedUtility.GetSearchTypesData();
            //populate drop down with search types on initial pageload
            if (!IsPostBack)
            {
                SearchTypeDropDownList.DataSource = from i in list
                                                    select new ListItem()
                                                    {
                                                        Text = i,
                                                        Value = i
                                                    };
                SearchTypeDropDownList.DataBind();
                searchType = Helpers.CommonValues.SimpleSearch;
                SearchTerm1TextBox.Attributes.Add("placeholder", CommonValues.SimplePlaceHolder);
            }


        }

        /// <summary>
        /// Search button submit action function
        /// </summary>
        protected void SearchSubmitButton_Click(object sender, EventArgs e)
        {
            //get the search terms value from the text boxes
            string searchTerm1 = !(string.IsNullOrWhiteSpace(SearchTerm1TextBox.Text)) ? SearchTerm1TextBox.Text.Trim().ToString() : string.Empty;
            string searchTerm2 = !(string.IsNullOrWhiteSpace(SearchTerm2TextBox.Text))  ? SearchTerm2TextBox.Text.Trim().ToString() : string.Empty;
            //initialize the results list as empty listview
            ResultsListView.DataSource = null;
            ResultsListView.DataBind();
            List<Document> searchResults = new List<Document>();
            string[] searchTerms = new string[2];//although this could have been made a list of strings or initialized as a bigger array but since we need just two strings
            // so we are initiliaznig it as such   
            //fetch search results on the basis of search type
            switch (searchType)
            {
                case CommonValues.SimpleSearch:
                    searchResults = Helpers.Search.SimpleSearch(searchTerm1);
                    break;
                case CommonValues.BooleanSearch:
                    searchResults = Helpers.Search.BooleanSearch(searchTerm1, searchTerm2);
                    break;
                case CommonValues.RegexSearch:
                    searchResults = Helpers.Search.RegexSearch(searchTerm1, searchTerm2);
                    break;
            }
            //show the results in the list view
            ResultsListView.DataSource = searchResults;
            ResultsListView.DataBind();
        }

        /// <summary>
        /// Drop down selection chage event function
        /// </summary>
        protected void SearchTypeChanged(object sender, EventArgs e)
        {
            searchType = SearchTypeDropDownList.SelectedValue.ToString();
            UpdateUI();
        }

        /// <summary>
        /// Calls all the necessary UI based code updates on search type change
        /// </summary>
        private void UpdateUI()
        {
            ControlSearchTextBoxesVisibility();
            UpdatePlaceHolderText();
        }

        
        /// <summary>
        /// Controls how the visibility of search text boxes is handled
        /// </summary>
        private void ControlSearchTextBoxesVisibility()
        {
            //hide the second searchterm and its validation controls lables for simple search
            switch (searchType)
            {
                case CommonValues.SimpleSearch:
                    SearchTerm2TextBox.Visible = false;
                    RequiredSearchField2Validator.Visible = false;
                    break;
                case CommonValues.BooleanSearch:
                    SearchTerm2TextBox.Visible = true;
                    RequiredSearchField2Validator.Visible = true;
                    break;
                case CommonValues.RegexSearch:
                    SearchTerm2TextBox.Visible = true;
                    RequiredSearchField2Validator.Visible = true;
                    break;
            }
        }

        private void UpdatePlaceHolderText()
        {
            //clear the previously searched terms on selection change
            SearchTerm1TextBox.Text = null;
            SearchTerm2TextBox.Text = null;
            SearchTerm1TextBox.Attributes.Remove("placeholder");
            SearchTerm2TextBox.Attributes.Remove("placeholder");
            //change the place holder text for different type of search actions
            switch (searchType)
            {
                case CommonValues.SimpleSearch:
                    SearchTerm1TextBox.Attributes.Add("placeholder", CommonValues.SimplePlaceHolder);
                    break;
                case CommonValues.BooleanSearch:
                    SearchTerm1TextBox.Attributes.Add("placeholder", CommonValues.BooleanFirstTermPlaceHolder);
                    SearchTerm2TextBox.Attributes.Add("placeholder",CommonValues.BooleanSecondTermPlaceHolder);
                    break;
                case CommonValues.RegexSearch:
                    SearchTerm1TextBox.Attributes.Add("placeholder", CommonValues.RegexFirstTermPlaceHolder);
                    SearchTerm2TextBox.Attributes.Add("placeholder", CommonValues.RegexSecondTermPlaceHolder);
                    break;
            }
        }
    }
}