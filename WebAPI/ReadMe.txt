Reference : https://docs.microsoft.com/en-us/aspnet/web-api/overview/getting-started-with-aspnet-web-api/tutorial-your-first-web-api
1. WEB API Action Results : content of response get serialized based on accept header of request like application/json, text/html, text/xml etc...
   - Void --Returns NoContent
   - HttpResponseMessage -- Returns message with status code
   - IHttpActionResult - Wrapper over HttpResponseMessage - Call ExcecuteAsync method to get response message
   - Any - IEnumerable<T> or T -- returns data with specified media formatter

   Note : Content-Type : this header values states what type of data in request flow Client->Server
          Accept : this header values tells what type of response is expected from server flow Server->Client
