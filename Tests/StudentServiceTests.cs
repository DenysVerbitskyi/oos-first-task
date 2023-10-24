using FluentAssertions;

using Microsoft.Extensions.Logging;

using Moq;

using NetCoreTask.DataBase.Entities;
using NetCoreTask.DataBase.Repository.Abstract;
using NetCoreTask.Models.Dto;
using NetCoreTask.Services;

namespace Tests
{
    public class StudentServiceTests
    {
        private readonly StudentsService _sut;
        private readonly Mock<IRepository<StudentEntity>> _studentRepoMock = new Mock<IRepository<StudentEntity>>();
        private readonly Mock<ILogger<ApiService<StudentEntity, StudentDto>>> _loggerMock = new Mock<ILogger<ApiService<StudentEntity, StudentDto>>>();
  
        public StudentServiceTests()
        {
            _sut = new StudentsService(_studentRepoMock.Object, _loggerMock.Object);
        }

        [Test]
        public async Task GetGetById_ShouldReturnStudent_WhenStudentExists()
        {
            //Arrange
            var studentId = Guid.NewGuid();
            var firstName = "Den";
            var lastName = "Var";
            var studentEntity = new StudentEntity()
            {
                Id = studentId,
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = DateTime.Now
            };

            _studentRepoMock.Setup(s => s.GetById(studentId))
                .ReturnsAsync(studentEntity);

            //Act
            var studnt = await _sut.GetById(studentId);

            //Assert

            studnt.Id.Should().Be(studentId);
            studnt.FirstName.Should().Be(firstName);
            studnt.LastName.Should().Be(lastName);
        }

        [Test]
        public async Task GetGetById_ShouldReturnNothing_WhenStudentDoesNotExists()
        {
            //Arrange
            _studentRepoMock.Setup(s => s.GetById(It.IsAny<Guid>()))
                .ReturnsAsync(() => null);

            //Act
            var studnt = await _sut.GetById(Guid.NewGuid());

            //Assert
            studnt.Should().Be(null);
        }

        [Test]
        public async Task GetAll_ShouldReturnAllStudents_WhenStudentsExists()
        {
            //Arrange
            _studentRepoMock.Setup(s => s.GetAll())
                .ReturnsAsync(new List<StudentEntity>
                {
                    new StudentEntity {
                                            Id = Guid.NewGuid()
                                            ,FirstName = "John"
                                            ,LastName = "Doe"
                                            ,DateOfBirth = DateTime.Now.AddDays(-4000)
                                    },
                    new StudentEntity {
                                            Id = Guid.NewGuid()
                                            ,FirstName = "Alice"
                                            ,LastName = "Born"
                                            ,DateOfBirth = DateTime.Now.AddDays(-5000)
                                    },
                    new StudentEntity {
                                            Id = Guid.NewGuid()
                                            ,FirstName = "Andrew"
                                            ,LastName = "Kid"
                                            ,DateOfBirth = DateTime.Now.AddDays(-6000)
                                    }
                });

            //Act
            var students = await _sut.GetAll();

            //Assert
            students.Should().HaveCount(3);
        }

        [Test]
        public async Task GetAll_ShouldReturnNothing_WhenStudentsDoesNotExists()
        {
            //Arrange
            _studentRepoMock.Setup(s => s.GetAll())
                .ReturnsAsync(new List<StudentEntity>());

            //Act
            var students = await _sut.GetAll();

            //Assert
            students.Should().HaveCount(0);
        }

        [Test]
        public async Task Delete_ShouldReturnStudent_WhenStudentIsWxists()
        {
            //Arrange
            var studentEntity = new StudentEntity
            {
                Id = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = DateTime.Now.AddDays(-10000)
            };

            _studentRepoMock.Setup(s => s.Delete(studentEntity.Id))
                .ReturnsAsync(studentEntity);

            //Act
            var student = await _sut.Delete(studentEntity.Id);

            //Assert
            student.Id.Should().Be(studentEntity.Id);
            student.FirstName.Should().Be(studentEntity.FirstName);
        }

        [Test]
        public async Task Delete_ShouldThrowArgumentNullException_WhenStudentDoesNotWxists()
        {
            Guid nonExistentStudentId = Guid.NewGuid();
            //Arrange
            _studentRepoMock.Setup(s => s.Delete(nonExistentStudentId))
                .ThrowsAsync(new ArgumentNullException());

            //Act & Assert
            Assert.ThrowsAsync<ArgumentNullException>(async () => await _sut.Delete(nonExistentStudentId));
        }
    }
}