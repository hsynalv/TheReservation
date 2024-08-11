using System.Text.RegularExpressions;

namespace API.Application_.Helpers;

public static class SlugHelper
{
    public static string GenerateSlug(string title)
    {
        var slug = title.ToLower();
        slug = Regex.Replace(slug, @"\s+", "-");  // Boşlukları tire ile değiştir
        slug = Regex.Replace(slug, @"[^a-z0-9\-]", "");  // Alfanumerik olmayan karakterleri kaldır
        slug = slug.Trim('-');  // Baş ve sondaki tireleri kaldır
        return slug;
    }
}