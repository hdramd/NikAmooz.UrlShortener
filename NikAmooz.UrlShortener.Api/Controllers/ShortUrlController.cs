using MediatR;
using Microsoft.AspNetCore.Mvc;
using NikAmooz.UrlShortener.Application.Common.Models;
using NikAmooz.UrlShortener.Application.ShortUrls.Commands.CreateShortUrl;
using NikAmooz.UrlShortener.Application.ShortUrls.Models;
using System.Threading.Tasks;

namespace NikAmooz.UrlShortener.Api.Controllers
{
    public class ShortUrlController : BaseController
    {
        public ShortUrlController(IMediator mediator)
            : base(mediator)
        {

        }

        /// <summary>
        /// Short url
        /// </summary>
        /// <response code="201">if short url successfully</response>
        /// <response code="400">if validation failed</response>
        /// <response code="500">if an unexpected error happen</response>
        [ProducesResponseType(typeof(ShortUrlDto), 201)]
        [ProducesResponseType(typeof(ApiMessage), 400)]
        [ProducesResponseType(typeof(ApiMessage), 500)]
        [HttpPost]
        public async Task<IActionResult> Post(CreateShortUrlCommand command)
        {
            var result = await Mediator.Send(command);

            if (result.Success == false)
                return result.ApiResult;

            return Created(Url.Link("", new { id = result.Data.Id }), result.Data);
        }
    }
}
