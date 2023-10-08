using DDD.Domain.Exceptions;

namespace DDD.Domain.Models.Product.ValueObjects;

public record Image
{
    public string Value { get; private set; }
    private readonly string[] _allowedExtension = new[] { "JPG","JPEG","PNG" };
    public Image(string image)
    {
        var extension = image.Split(".").Last() ?? throw new InvalidImageException("Invalid URL");
        if (!_allowedExtension.Any(ex=>string.Equals(ex, extension, StringComparison.CurrentCultureIgnoreCase)))
            throw new InvalidImageException("Invalid Image Extension");
        Value = image;
    }
};