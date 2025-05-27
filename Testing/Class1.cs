using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SLLearning.Controllers;
using SLLearning.Models;
using Xunit;

namespace Testing
{
    public class Class1
    {
        public class EnrolTest
        {
            [Fact]

            public void EnrolMethod_Returns_True()
            {
                var mock = new Enrolment();
                mock.Enrol();
                Assert.True(mock.IsEnrolled);


            }
        }

        public class LessonControllerTests
        {


            private AppDbContext GetInMemoryDbContext()
            {
                var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(databaseName: (Guid.NewGuid().ToString())).Options;

                return new AppDbContext(options);
          
            }


            [Fact]

            public async Task GetLessons_ReturnOKResult_InList()
            {
                var context = GetInMemoryDbContext();

                context.Lessons.AddRange(new Lesson { Id = 1, Title = "Maths", LessonStatus = LessonStatus.completed}, new Lesson { Id = 2, Title = "Music", LessonStatus = LessonStatus.closed});

                await context.SaveChangesAsync();

                var controller = new LessonController(context);
                var result = await controller.Index();

                var okResult = Assert.IsType<ViewResult>(result);
                Assert.IsAssignableFrom<List<Lesson>>(okResult.Model);

            }

            [Fact]
            public void GetLessonById_ReturnsOK_WhenLessonExists()
            {
                var context = GetInMemoryDbContext();
                context.Lessons.AddRange(new Lesson { Id = 1, Title = "Music", LessonStatus = LessonStatus.cancelled});

                context.SaveChanges();

                var controller = new LessonController(context);

                var result = controller.Details(1).Result;

                var okResult = Assert.IsType<ViewResult>(result);
                var lesson = Assert.IsType<Lesson>(okResult.Model);
                Assert.Equal("Music", lesson.Title);
                Assert.Equal ("cancelled", lesson.LessonStatus.ToString());

            }

            [Fact]

            public void GetLessonById_ReturnsBad_WhenLessonDoesNotExist()
            {
                var context = GetInMemoryDbContext();
                context.Lessons.AddRange(new Lesson { Id = 1, Title = "Music", LessonStatus = LessonStatus.cancelled });

                context.SaveChanges();

                var controller = new LessonController(context);
                var result = controller.Details(2).Result;

                Assert.IsType<NotFoundResult>(result);
            }

            [Fact]

            public void Create_Returns_LessonObject()
            {
                var context = GetInMemoryDbContext();
                var controller = new LessonController(context);

                var newLesson = new Lesson { Id = 1, Title = "Music", LessonStatus = LessonStatus.cancelled };



                var result = controller.Create(newLesson).Result;

                var savedLesson = context.Lessons.FirstOrDefault(a => a.Title == "Music");
                Assert.NotNull(savedLesson);
                Assert.Equal("Music", savedLesson.Title);
                           

                
            
            }

            [Fact]

            public void Edit_Returns_LessonObject()
            {
                var context = GetInMemoryDbContext();
            

                var editedLesson = new Lesson { Id = 1, Title = "Music", LessonStatus = LessonStatus.cancelled };

                context.Lessons.Add(editedLesson);
                context.SaveChanges();
                var controller = new LessonController(context);

                var result = controller.Edit(1).Result;

                var viewResult = Assert.IsType<ViewResult>(result);

                var model = Assert.IsType<Lesson>(viewResult.Model);

                Assert.Equal (1, model.Id);
                Assert.Equal("Music", model.Title);
                Assert.Equal(LessonStatus.cancelled, model.LessonStatus);
                Assert.NotNull(editedLesson);            

            }

            [Fact]
            public void EditWrong_Returns_Error()
            {
                var context = GetInMemoryDbContext();


                var editedLesson = new Lesson { Id = 1, Title = "Music", LessonStatus = LessonStatus.cancelled };

                context.Lessons.Add(editedLesson);
                context.SaveChanges();
                var controller = new LessonController(context);

                var result = controller.Edit(2).Result;
                
                Assert.IsType<NotFoundResult>(result);

            


            }

            [Fact]

            public void DeleteConfirmed_RemovesLesson_WhenLessonIdExists()
            {
                var context = GetInMemoryDbContext();


                var newLesson = new Lesson { Id = 1, Title = "Music", LessonStatus = LessonStatus.cancelled };

                context.Lessons.Add(newLesson);
                context.SaveChanges();

                var controller = new LessonController(context);

                var result = controller.DeleteConfirmed(1).Result;

                var redirect = Assert.IsType<RedirectToActionResult>(result);
                Assert.Equal("Index", redirect.ActionName);

                var deletedLesson = context.Lessons.FirstOrDefault(a => a.Id == 1);
                Assert.Null(deletedLesson);

            }
        }

        public class EnrolmentControllerTests
        {
            private AppDbContext GetInMemoryDbContext()
            {
                var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(databaseName: (Guid.NewGuid().ToString())).Options;

                return new AppDbContext(options);

            }
            [Fact]

            public void EnrolButton_EnrolsMember_UpdatesLessonEnrolmentStatus()
            {

                var context = GetInMemoryDbContext();


                var newLesson = new Lesson { Id = 1, Title = "Music", LessonStatus = LessonStatus.cancelled };

                context.Lessons.Add(newLesson);
                

                var newMember = new Member { Id = 1, FirstName = "Sam", LastName = "Doe" };

                context.Members.Add(newMember);

                var newEnrolment = new Enrolment { Id = 1, MemberId =1, LessonId = 1, IsEnrolled = false };

              


                var controller = new EnrolmentController(context);
                {

                    var result = controller.EnrolButton(newEnrolment);
                                   

                    Assert.Equal(true, newEnrolment.IsEnrolled);
                    


                }

            }
        }
    }
}
