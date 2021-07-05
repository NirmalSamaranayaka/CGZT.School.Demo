using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGZT.School.Demo.UnitTest.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class TestFactory
    {
        /// <summary>
        /// Creates the dictionary.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static Dictionary<string, StringValues> CreateDictionary(string key, string value)
        {
            var qs = new Dictionary<string, StringValues>
            {
                { key, value },
            };
            return qs;
        }

        /// <summary>
        /// Creates the HTTP request.
        /// </summary>
        /// <param name="queryStrings">The query strings.</param>
        /// <param name="postData">The post data.</param>
        /// <returns></returns>
        public static HttpRequest CreateHttpRequest(QueryCollection queryStrings, Stream postData)
        {
            var context = new DefaultHttpContext();
            var request = context.Request;
            request.Query = queryStrings;
            request.Body = postData;
            return request;
        }
    }

}
