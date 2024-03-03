using Microsoft.EntityFrameworkCore;

namespace PublicSalesKChSI.Infrastructure.Data.Models
{
    public class DetailedSeekAttribOutDb
    {
        [Comment("Can be city or village")]
        public string Place { get; set; } = null!;

        [Comment("0 for city and 1 for village")]
        public int TypePlace { get; set; }

        public string? Sreet { get; set; }
        public string? SreetNumber { get; set; }

        public string? Complex { get; set; } 

        public string? Building { get; set; } 

        public string? Enrtance { get; set; } 

        public string? Floor { get; set; } 

        public int? Appartment { get; set; } 

        public string? Terrain { get; set; }

        public string? PINumber { get; set; }
    }
}
