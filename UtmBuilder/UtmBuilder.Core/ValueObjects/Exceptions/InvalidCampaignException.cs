namespace UtmBuilder.Core.ValueObjects.Exceptions;

public class InvalidCampaignException : Exception
{
    private const string DefaultErrorMessage = "Invalid Campaign";

    public InvalidCampaignException(string message = DefaultErrorMessage)
        : base(message)
    {

    }

    public static void ThrowIfInvalid(
        string address,
        string message = DefaultErrorMessage)
    {
        if (string.IsNullOrEmpty(address))
            throw new InvalidUrlException(message);
    }
}
