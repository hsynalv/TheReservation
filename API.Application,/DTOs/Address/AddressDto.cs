using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Application_.DTOs.Address
{
    public class AddressDto
    {
        public string? Street { get; set; }  // Cadde veya sokak adı
        public string? City { get; set; }    // Şehir adı
        public string? State { get; set; }   // Eyalet/il adı
        public string? PostalCode { get; set; }  // Posta kodu
        public string Country { get; set; }
    }
}
