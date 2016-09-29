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
        /// Creates index, adds documents to index and search string in index
        /// </summary>
        /// <param name="searchString">string to search</param>
        public static List<Document> SimpleSearch(string searchString)
        {
            List<Document> documentList = new List<Document>();
            //ExStart:CustomExtractor
            Index index = new Index(CommonUtilities.indexPath);
            index.CustomExtractors.Add(new CustomizedFieldExtractor());

            index.AddToIndex(CommonUtilities.documentsDir);

            // Search in index
            SearchResults searchResults = index.Search(searchString);
            //// List of found files
            foreach (DocumentResultInfo documentResultInfo in searchResults)
            {
                documentList.Add(new Document { FileName = documentResultInfo.FileName, HitCount = documentResultInfo.HitCount});
            }
            return documentList;
        }

        /// <summary>
        /// Creates index, adds documents to index and do boolean search
        /// </summary>
        /// <param name="firstTerm">first term to search</param>
        /// <param name="secondTerm">second term to search</param>
        public static void BooleanSearch(string firstTerm, string secondTerm)
        {
            //ExStart:BooleanSearch
            // Create index
            Index index = new Index(CommonUtilities.indexPath);

            // Add documents to index
            index.AddToIndex(CommonUtilities.documentsDir);

            // Search in index
            SearchResults searchResults = index.Search(firstTerm + "OR" + secondTerm);

            // List of found files
            foreach (DocumentResultInfo documentResultInfo in searchResults)
            {
                Console.WriteLine("Query \"{0}\" has {1} hit count in file: {2}", firstTerm, documentResultInfo.HitCount, documentResultInfo.FileName);
                Console.WriteLine("Query \"{0}\" has {1} hit count in file: {2}", secondTerm, documentResultInfo.HitCount, documentResultInfo.FileName);
            }
        }

        /// <summary>
        /// Creates index, adds documents to index and do regex search
        /// </summary>
        /// <param name="relevantKey">single keyword</param>
        /// <param name="regexString">regex</param>
        public static void RegexSearch(string relevantKey, string regexString)
        {
            //ExStart:Regexsearch
            // Create index
            // Create index
            Index index = new Index(CommonUtilities.indexPath);

            // Add documents to index
            index.AddToIndex(CommonUtilities.documentsDir);

            // Search for documents where at least one word contain given regex
            SearchResults searchResults1 = index.Search(relevantKey);

            //Search for documents where present term1 or any email adress or term2
            SearchResults searchResults2 = index.Search(regexString);

            // List of found files 
            Console.WriteLine("Follwoing document(s) contain provided relevant tag: \n");
            foreach (DocumentResultInfo documentResultInfo in searchResults1)
            {
                Console.WriteLine("Query \"{0}\" has {1} hit count in file: {2}", relevantKey, documentResultInfo.HitCount, documentResultInfo.FileName);
                Console.WriteLine("Query \"{0}\" has {1} hit count in file: {2}", regexString, documentResultInfo.HitCount, documentResultInfo.FileName);
            }

            // List of found files
            Console.WriteLine("Follwoing document(s) contain provided RegEx: \n");
            foreach (DocumentResultInfo documentResultInfo in searchResults2)
            {
                Console.WriteLine("Query \"{0}\" has {1} hit count in file: {2}", relevantKey, documentResultInfo.HitCount, documentResultInfo.FileName);
                Console.WriteLine("Query \"{0}\" has {1} hit count in file: {2}", regexString, documentResultInfo.HitCount, documentResultInfo.FileName);
            }
        }

    }
}