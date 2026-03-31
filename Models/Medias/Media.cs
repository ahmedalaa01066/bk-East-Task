using EasyTask.Models.Documents;
using EasyTask.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyTask.Models.Medias
{
    [Table("Media", Schema = "Medias")]
    public class Media:BaseModel
    {
        public string SourceId {  get; set; }
        public SourceType SourceType {  get; set; }
        public string Path {  get; set; }

        [ForeignKey("Document")]
        public string? DocumentId { get; set; }
        public Document? Document { get; set; }
    }
}
