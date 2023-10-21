using Castle.Core.Logging;

using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

using Moq;

using NetCoreTask.DataBase.Entities;
using NetCoreTask.DataBase.Repository.Abstract;
using NetCoreTask.DataBase.Repository.Services;
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
            Assert.AreEqual(studentId, studnt.Id);
            Assert.AreEqual(firstName, studnt.FirstName);
            Assert.AreEqual(lastName, studnt.LastName);
        }
    }
}