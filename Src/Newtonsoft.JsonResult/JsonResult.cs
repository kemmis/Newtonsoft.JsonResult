using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace Newtonsoft.JsonResult
{
    /// <summary>
    /// A JsonResult for asp.net mvc that uses the Newtonsoft.Json serializer.
    /// </summary>
    /// <remarks>
    /// The initial code came from this stackoverflow answer: http://stackoverflow.com/a/7150912/27497
    /// Props to @asgerhallas for his contribution!
    /// </remarks>
    public class JsonResult : System.Web.Mvc.JsonResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            var response = context.HttpContext.Response;

            response.ContentType = !String.IsNullOrEmpty(ContentType)
                ? ContentType
                : "application/json";

            if (ContentEncoding != null)
                response.ContentEncoding = ContentEncoding;

            // If you need special handling, you can call another form of SerializeObject below
            var serializedObject = JsonConvert.SerializeObject(Data, Formatting.Indented);
            response.Write(serializedObject);
        }
    }
}
