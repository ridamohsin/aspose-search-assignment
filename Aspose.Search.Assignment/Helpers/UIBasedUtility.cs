using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aspose.Search.Assignment.Helpers
{
    public class UIBasedUtility
    {
        public static List<string> GetSearchTypesData() {
            List<string> searchTypes = new List<string>()
         {
                "Simple",
            "Boolean",
            "Regex"
         };
            return searchTypes;
        }
    }
}