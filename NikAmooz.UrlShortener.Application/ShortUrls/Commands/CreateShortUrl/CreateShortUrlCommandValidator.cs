using FluentValidation;

namespace NikAmooz.UrlShortener.Application.ShortUrls.Commands.CreateShortUrl
{
    public class CreateShortUrlCommandValidator : AbstractValidator<CreateShortUrlCommand>
    {
        public CreateShortUrlCommandValidator()
        {
            RuleFor(x => x.Url).NotEmpty();
        }
    }
}
