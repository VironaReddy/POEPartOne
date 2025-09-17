using System.ComponentModel.DataAnnotations;

namespace POEOne.Models
{
    public class FileUpLoad
    {
        [Key]
        public string Name { get; set; }
        public long Size { get; set; }
        public DateTimeOffset? LastModified { get; set; }

        public string DisplaySize
        {
            get
            {
                if (Size >= 1024 * 1024)
                    return $"{Size / (1024 * 1024)} MB";
                if (Size >= 1024)
                    return $"{Size / 1024} KB";
                return $"{Size} Bytes";
            }
        }

    }
}
    