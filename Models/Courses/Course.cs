using EasyTask.Common.Interfaces;
using EasyTask.Models.CandidateCourses;
using EasyTask.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyTask.Models.Courses
{
    [Table("Course", Schema = "Courses")]
    public class Course : BaseModel, ISelectableListItem
    {
        public string Name { get; set; }
        public int Hours { get; set; }
        public string InstructorName { get; set; }
        public CourseClassification CourseClassification { get; set; }
        public CourseStatus Status { get; set; }
        public bool HasExam { get; set; }
        public CourseType CourseType { get; set; }
        public string Link { get; set; }
        public string Content { get; set; }
        public ICollection<CandidateCourse> candidateCourses { get; set; }
    }
}
