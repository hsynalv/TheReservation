using API.Domain.Entities.Common;

namespace API.Domain.Entities;

public class Address : BaseEntity
{
    public string? Street { get; set; }  // Cadde veya sokak adı
    public string? City { get; set; }    // Şehir adı
    public string? State { get; set; }   // Eyalet/il adı
    public string? PostalCode { get; set; }  // Posta kodu
    public string? Country { get; set; }  // Ülke

    // Navigation Properties
    public string? RestaurantId { get; set; }
    public Restaurant? Restaurant { get; set; }
}