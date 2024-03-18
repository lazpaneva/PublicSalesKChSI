using PublicSalesKChSI.Core.Models.WorkingOnFiles;
using PublicSalesKChSI.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PublicSalesKChSI.Models.WorkingOnFiles
{
    public class AllFilesQueryModel
    {
        public const int FilesPerPage = 20;

        public string Court { get; init; } = null!;
        [Display(Name = "Търсене в името")]
        public string SearchTermName { get; init; } = null!;

        [Display(Name = "Търсене в текста")]
        public string SearchTermText { get; init; } = null!;
        public FileSorting Sorting { get; init; }
        public int CurrentPage { get; init; } = 1;
        public int TotalFilesCount { get; set; }

        public IEnumerable<string> Courts { get; set; } = new List<string>();

        public IEnumerable<FileServiceModel> Files { get; set; }
            = new List<FileServiceModel>();

    }
}
