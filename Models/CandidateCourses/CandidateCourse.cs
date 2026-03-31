using EasyTask.Models.Candidates;
using EasyTask.Models.Courses;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyTask.Models.CandidateCourses
{

    [Table("CandidateCourse", Schema = "CandidateCourses")]
    public class CandidateCourse : BaseModel
    {
        [ForeignKey("Candidate")]
        public string CandidateId { get; set; }
        public Candidate Candidate { get; set; }
        [ForeignKey("Course")]
        public string CourseId { get; set; }
        public Course Course { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly? ActualStartDate { get; set; }
        public DateOnly EndDate { get; set; }
    }
}
