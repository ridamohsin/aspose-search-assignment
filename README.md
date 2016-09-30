# aspose-search-assignment
A technical evaluation Assignment for Aspose that carries out different types of searches    
The main purpose of this application is to use GroupDocs.Search API for .Net to perform three types of search namely Simple, Boolean and Regex.   
The user can select the type of the search he wants to perform and the application performs that search and shows the results of that search in the same page.  

## Code Example

The most basic function this application performs is applying search on index documents
**For Example** Based on the searchType it calls the requisite search function, a sample code snippet is shown here
```ruby
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
```

## API Reference

This application makes use of the **GroupDocs.Search API for .Net v1.2.0**  [Download Link](http://www.groupdocs.com/downloads/search/net) to perform the search on documents


##Resources:
1. [Video Link](https://www.dropbox.com/s/wi22sm0e55qp3mw/Home%20Page%20-%20Aspose%20Technical%20Evaluation%20Assignment%20-%20Mozilla%20Firefox%209_30_2016%204_03_09%20PM.mp4?dl=0) 
2. [Wiki Link](https://github.com/ridamohsin/aspose-search-assignment/wiki)
