using GroupDocs.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aspose.Search.Assignment.Helpers
{
    public class CustomizedFieldExtractor : IFieldExtractor
    {
        public string[] Extensions
        {
            get
            {
                return new[] { ".doc",".doc"};
            }
        }

        public FieldInfo[] GetFields(string fileName)
        {
            return new FieldInfo[4];
        }
    }
}