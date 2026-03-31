using EasyTask.Models.Enums;
using EasyTask.Models.Medias;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyTask.Models.Documents
{
    [Table("Document", Schema = "Documents")]
    public class Document : BaseModel
    {
        public string LogicalName { get; set; }
        public string PhysicalName { get; set; }
        public string SourceId { get; set; }
        public DocumentType SourceType { get; set; }
        public string Path { get; set; }
        //self-referencing relationship
        public string? ParentDocumentId { get; set; }

        [ForeignKey("ParentDocumentId")]
        public Document ParentDocument { get; set; }

        public ICollection<Document> ChildDocuments { get; set; }
        public ICollection<Media> Medias { get; set; } = new List<Media>();
    }
}
