using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace SLLearning.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public LessonStatus LessonStatus { get; set; }

        [NotMapped]
        [ValidateNever]
        public IEnumerable<SelectListItem> LessonStatusList { get; set; }



        public ICollection<Enrolment> Enrollments { get; set; } = new List<Enrolment>();
    }
}
