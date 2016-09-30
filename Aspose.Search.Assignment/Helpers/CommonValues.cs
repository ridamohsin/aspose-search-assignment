using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aspose.Search.Assignment.Helpers
{
    public class CommonValues
    {
        public static string dataDir = AppDomain.CurrentDomain.GetData("DataDirectory").ToString(); // App_Data folder path
        public static string documentsDir = AppDomain.CurrentDomain.GetData("DataDirectory")+ "\\DocumentsDirectory"; //path where documents are kept
        public static string indexPath = dataDir + "\\IndexDirectory"; 
        public static string tempDir = "~/Temp/";

        public const string SimpleSearch = "Simple";
        public const string BooleanSearch = "Boolean";
        public const string RegexSearch = "Regex";
    }
}