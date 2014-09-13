Newtonsoft.JsonResult
=====================

A JsonResult ActionResult for ASP.NET MVC that uses the Json.NET the json serializer.

## Use
All you need to do is override the Json method inside your controller so that it returns a Newtonsoft.JsonResult.JsonResult instead of a regular JsonResult:
```
protected override JsonResult Json(object data, string contentType, System.Text.Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new Newtonsoft.JsonResult.JsonResult
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior
            };
        }
		```