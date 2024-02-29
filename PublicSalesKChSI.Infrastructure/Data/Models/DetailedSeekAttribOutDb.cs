using Microsoft.EntityFrameworkCore;

namespace PublicSalesKChSI.Infrastructure.Data.Models
{
    public class DetailedSeekAttribOutDb
    {
        [Comment("Can be city or village")]
        public string Place { get; set; } = null!;

        [Comment("0 for city and 1 for village")]
        public int TypePlace { get; set; }

        public string Sreet { get; set; } = null!;

        public string Complex { get; set; } = null!;

        public string Building { get; set; } = null!;

        public string Enrtance { get; set; } = null!;

        public int Floor { get; set; } 

        public int Appartment { get; set; } 

        public string Terrain { get; set; } = null!;

    }
}
