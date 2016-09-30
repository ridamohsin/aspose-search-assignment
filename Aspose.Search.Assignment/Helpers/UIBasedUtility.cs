using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Aspose.Search.Assignment.Helpers
{
    public class UIBasedUtility
    {
        /// <summary>
        /// Creates a list of string conatining the available search types
        /// </summary>
        /// <returns>searchTypes</returns>
        public static List<string> GetSearchTypesData()
        {
            List<string> searchTypes = new List<string>()
         {
            CommonValues.SimpleSearch,
            CommonValues.BooleanSearch,
            CommonValues.RegexSearch
         };
            return searchTypes;
        }

        /// <summary>
        /// Get the filename from the complete path
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>fileName</returns>
        public static string DisplayFileName(string filePath)
        {
            string fileName = filePath;

            try
            {
                 fileName = Path.GetFileName(filePath);
            }
            catch (Exception ex) {
            }
            return fileName;
        }

        /// <summary>
        /// fomat the hit count
        /// </summary>
        /// <param name="hitCount"></param>
        /// <returns>formattedHitCount</returns>
        public static string DisplayHitCount(int hitCount)
        {
            string formattedHitCount = string.Empty;
            if (hitCount <= 1)
            {
                formattedHitCount = hitCount + " time";
            }
            else
            {
                formattedHitCount = hitCount + " times";
            }
            return formattedHitCount;
        }
    }
}