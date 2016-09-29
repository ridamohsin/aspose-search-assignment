using Aspose.Search.Assignment.Models;
using GroupDocs.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aspose.Search.Assignment.Helpers
{
    public class Search
    {
        /// <summary>
        /// Does simple search after indexing the documents present in a specified application folder
        /// </summary>
        /// <param name="searchString">string to search</param>
        public static List<Document> SimpleSearch(string searchString)
        {
            //Create index and documents to index
            Index index = CreateDocumentIndex();

            // Search for the term in index
            SearchResults searchResults = index.Search(searchString);

            //Generate a list of documents from the search results
            List<Document> documentList = GenerateDocumentList(searchResults, searchString);
            
            return documentList;
        }


        /// <summary>
        /// Does boolean search after indexing the documents present in a specified application folder
        /// </summary>
        /// <param name="firstTerm">first term to search</param>
        /// <param name="secondTerm">second term to search</param>
        public static List<Document> BooleanSearch(string firstTerm, string secondTerm)
        {
            // Create index and add documents to index
            Index index = CreateDocumentIndex();

            // Search in index based on applying OR operation on first and second term
            SearchResults searchResults = index.Search(firstTerm + "OR" + secondTerm);

            //Generate a list of documents from the search results
            List<Document> documentList = GenerateDocumentList(searchResults, firstTerm + "OR" + secondTerm);
            return documentList;
        }

        /// <summary>
        /// Does regex search after indexing the documents present in a specified application folder
        /// </summary>
        /// <param name="relevantKey">single keyword</param>
        /// <param name="regexString">regex</param>
        public static List<Document> RegexSearch(string relevantKey, string regexString)
        {
            // Create index and add documents to index
            Index index = CreateDocumentIndex();

            // Search for documents based on the relevent key
            SearchResults searchResults1 = index.Search(relevantKey);

            //Search for documents based on the regex string
            SearchResults searchResults2 = index.Search(regexString);

            //Generate a list of documents from the search results for both relevent key and regex string
            List<Document> releventKeyResults = searchResults1.Count > 0 ? GenerateDocumentList(searchResults1, "Relevent Key (" + relevantKey + ") Based Results") : GenerateEmptyResult("Relevent Key(" + relevantKey + ") Based Results");
            List<Document> regexStringResults = searchResults2.Count > 0 ? GenerateDocumentList(searchResults2, "Regex String (" + regexString + ") Based Results") : GenerateEmptyResult("Regex String(" + regexString + ") Based Results"); ;

            //combine the results in a single list
            List<Document> documentList = releventKeyResults.Concat(regexStringResults).ToList();

            //return the list
            return documentList;
        }

        /// <summary>
        /// Creates index and adds documents from a specified folder to index
        /// </summary>
        /// <returns>index</returns>
        private static Index CreateDocumentIndex()
        {
            // Create index
            Index index = new Index(CommonUtilities.indexPath);
            //adding a test custom extractor
            index.CustomExtractors.Add(new CustomizedFieldExtractor());
            // adding all files from folder and its subfolders to the index
            index.AddToIndex(CommonUtilities.documentsDir);
            return index;
        }

        /// <summary>
        /// Generates a document list from filename and its hitcount from documentsResultsInfo
        /// </summary>
        /// <params>searchResults, searchTerm</params>
        /// <returns>documentList</returns>
        private static List<Document> GenerateDocumentList(SearchResults searchResults, string searchTerm)
        {
            List<Document> documentList = new List<Document>();
            foreach (DocumentResultInfo documentResultInfo in searchResults)
            {
                documentList.Add(new Document { FileName = documentResultInfo.FileName, HitCount = documentResultInfo.HitCount, SearchTerm = searchTerm });
            }
            return documentList;
        }

        /// <summary>
        /// Creates a template in case of no result
        /// </summary>
        /// <param name="regexSubTerm">the subterm of the regex search i-e either releventKey or regexString</param>
        /// <returns>emptyResultList</returns>
        private static List<Document> GenerateEmptyResult(string regexSubTerm)
        {
            return new List<Document> {
                new Document { HitCount = 0, FileName= "No Results Found on this basis", SearchTerm = regexSubTerm}
            };

        }

    }
}