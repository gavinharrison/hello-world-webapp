namespace HelloWorld.Models
{
    public class ResponseViewModel
    {
        internal ResponseViewModel(string machineName, HttpRequest request)
        {
            MachineName = machineName;
            RequestId = request.HttpContext.TraceIdentifier;

            RequestData = new RequestDataViewModel(request);
        }

        internal ResponseViewModel(
            string? machineName,
            string? requestId,
            string method,
            Uri url,
            IEnumerable<string> body,
            IEnumerable<string> headers)
        {
            RequestId = requestId;
            MachineName = machineName;

            Method = method;
            Url = url;
            Body = body;
            Headers = headers;

            RequestData = new RequestDataViewModel(method, url, body, headers);
        }

        /// <summary>
        /// The request trace identifier
        /// </summary>
        public string? RequestId { get; }

        /// <summary>
        /// The machine name or container identifier
        /// </summary>
        public string? MachineName { get; }

        public RequestDataViewModel RequestData { get; }
        
        /// <summary>
        /// The incoming request method type e.g. [ GET, PUT, POST, DELETE, HEAD ]
        /// </summary>
        public string Method { get; }

        /// <summary>
        /// The absolute request url
        /// </summary>
        public Uri? Url { get; }

        /// <summary>
        /// The request body content
        /// </summary>
        public IEnumerable<string> Body { get; }

        /// <summary>
        /// The request headers
        /// </summary>
        public IEnumerable<string> Headers { get; }
    }

    public class RequestDataViewModel
    {
        internal RequestDataViewModel(HttpRequest request)
        {

        }

        internal RequestDataViewModel(
            string method, 
            Uri? url, 
            IEnumerable<string> body, 
            IEnumerable<string> headers)
        {
            Method = method;
            Url = url;
            Body = body;
            Headers = headers;
        }


        /// <summary>
        /// The incoming request method type e.g. [ GET, PUT, POST, DELETE, HEAD ]
        /// </summary>
        public string Method { get; }

        /// <summary>
        /// The absolute request url
        /// </summary>
        public Uri? Url { get; }

        /// <summary>
        /// The request headers
        /// </summary>
        public IEnumerable<string> Headers { get; }
        public IEnumerable<string> Cookies { get; }

        public IEnumerable<string> Form { get; }
        public IEnumerable<string> Files { get; }
        /// <summary>
        /// The request body content
        /// </summary>
        public IEnumerable<string> Body { get; }

        
    }
}
