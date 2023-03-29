using Microsoft.AspNetCore.Mvc;
using HelloWorld.Models;
using Microsoft.Extensions.Primitives;

namespace HelloWorld.Controllers
{
    public class CatchAllController : Controller
    {
        /// <summary>
        /// Catches any incoming requests and processes the request
        /// </summary>
        /// <param name="catchAll"></param>
        /// <returns></returns>
        [Route("/{**catchAll}")]
        public async Task<IActionResult> CatchAllAsync(string catchAll)
        {
            var model = await GenerateViewModel(Request);

            if (Request.Headers.Accept.Any(x => x.Contains("text/html")))
            {
                return View("index", model);
            }
            return Ok(model);
        }

        private async Task<ResponseViewModel> GenerateViewModel(HttpRequest request)
        {
            var body = (await GetRawBodyContent(request)) ?? string.Empty;
            return new ResponseViewModel(
                Environment.MachineName,
                request.HttpContext.TraceIdentifier,
                request.Method,
                new Uri($"{request.Scheme}://{request.Host.Value}{request.Path}{request.QueryString}"),
                GetFormContent(request).Concat(new string[]{ body }).ToArray(),
                request.Headers.Select(x => $"{x.Key}: {x.Value}")
            );
        }

        private IEnumerable<string> GetFormContent(HttpRequest request)
        {
            try
            {
                return request.Form.Select(x => $"{x.Key}: {x.Value}");
            }
            catch (InvalidOperationException ex)
            {
                return Array.Empty<string>();
            }
        }

        private async Task<string?> GetRawBodyContent(HttpRequest request)
        {
            if (!request.ContentLength.HasValue) return null;

            request.Body.Position = 0;
            using var reader = new StreamReader(request.Body, leaveOpen: true);
            var value = await reader.ReadToEndAsync();

            // Resetting stream index for any future access.
            reader.BaseStream.Position = 0;

            return value;
        }
    }
}