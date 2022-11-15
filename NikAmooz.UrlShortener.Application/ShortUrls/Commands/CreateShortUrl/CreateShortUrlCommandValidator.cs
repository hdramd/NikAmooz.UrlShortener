using System;
using System.Linq;
using FluentValidation;
using NikAmooz.UrlShortener.Application.Common.Interfaces;

namespace NikAmooz.UrlShortener.Application.ShortUrls.Commands.CreateShortUrl
{
    public class CreateShortUrlCommandValidator : AbstractValidator<CreateShortUrlCommand>
    {
        private readonly IUrlShortener _urlShortener;
        private readonly IApplicationDbContext _context;
        public CreateShortUrlCommandValidator(IUrlShortener urlShortener,
            IApplicationDbContext context)
        {
            _urlShortener = urlShortener;
            _context = context;

            RuleFor(x => x.Url).NotEmpty();

            RuleFor(x => x.Url).Must(BeValidUrl)
                .WithMessage("Url is not a valid url.");

            RuleFor(x => x.Url)
                .Must(BeUniquePath)
                .WithMessage("Url already exist.");
        }

        private bool BeUniquePath(string arg1)
        {
            var path = _urlShortener.GeneratePath(arg1);

            //TODO: Use async method
            var exist = _context.ShortUrls
                .Any(x => x.Path.Equals(path));

            return !exist;
        }

        private bool BeValidUrl(string arg)
        {
            return Uri.TryCreate(arg, UriKind.Absolute, out Uri uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
    }
}
