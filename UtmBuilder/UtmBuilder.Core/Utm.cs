using UtmBuilder.Core.Extensions;
using UtmBuilder.Core.ValueObjects;

namespace UtmBuilder.Core;

public class Utm
{
    public Utm(
        Url url,
        Campaign campaign)
    {
        Url = url;
        Campaign = campaign;          
    }

    /// <summary>
    /// URL (Website Link)
    /// </summary>
    public Url Url { get; }

    /// <summary>
    /// Campaign Details
    /// </summary>
    public Campaign Campaign { get; }

    public override string ToString()
    {
        var segments = new List<string>();
        segments.AddIfNotNull();
        return $"{Url.Address}?{string.Join("&", segments)}";
    }
}
