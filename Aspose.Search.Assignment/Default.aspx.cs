﻿using Aspose.Search.Assignment.Helpers;
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
            }


        }

        /// <summary>
        /// Search button submit action function
        /// </summary>
        protected void SearchSubmitButton_Click(object sender, EventArgs e)
        {
            //get the search terms value from the text boxes
            string searchTerm1 = SearchTerm1TextBox.Text.Trim().ToString();
            string searchTerm2 = SearchTerm2TextBox.Text != null ? SearchTerm2TextBox.Text.Trim().ToString():String.Empty;
            //initialize the results list as empty listview
            ResultsListView.DataSource = null;
            ResultsListView.DataBind();
            List<Document> searchResults = new List<Document>();
            string[] searchTerms = new string[2];
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
            ControlSearchTextBoxesVisibility();
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
                    SearchTerm2TextBox.Text=null;
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
    }
}