﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aspose.Search.Assignment.Helpers
{
    public class CommonValues
    {
        //Paths of directories used in this project
        public static string dataDir = AppDomain.CurrentDomain.GetData("DataDirectory").ToString(); // App_Data folder path
        public static string documentsDir = AppDomain.CurrentDomain.GetData("DataDirectory")+ "\\DocumentsDirectory"; //path where documents are kept
        public static string indexPath = dataDir + "\\IndexDirectory"; 
        

        //Types of available searches
        public const string SimpleSearch = "Simple";
        public const string BooleanSearch = "Boolean";
        public const string RegexSearch = "Regex";

        //Place holder text values for text boxes
        public const string SimplePlaceHolder = "Enter search term";
        public const string BooleanFirstTermPlaceHolder = "Enter first term";
        public const string BooleanSecondTermPlaceHolder = "Enter second term";
        public const string RegexFirstTermPlaceHolder = "Enter relevent key";
        public const string RegexSecondTermPlaceHolder = "Enter regex string";
    }
}