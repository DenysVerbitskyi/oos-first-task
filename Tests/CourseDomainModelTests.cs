using System.ComponentModel.DataAnnotations;

using FluentAssertions;

using NetCoreTask.Models.Domain;

namespace Tests;

[TestFixture]
public class CourseTests
{
    private Course _course;

    [SetUp]
    public void SetUp()
    {
        _course = new Course
        {
            CourseName = "Valid Course",
            Description = "Valid Description",
            TeacherId = Guid.NewGuid()
        };
    }

    [Test]
    public void CourseName_RequiredValidation_Valid()
    {
        // Arrange
        _course.CourseName = "Valid Course";

        // Act
        Action validationAction = () => Validator.ValidateObject(_course, new ValidationContext(_course), true);

        // Assert
        validationAction.Should().NotThrow<ValidationException>();
    }

    [Test]
    public void CourseName_RequiredValidation_Invalid()
    {
        // Arrange
        _course.CourseName = null;

        // Act
        Action validationAction = () => Validator.ValidateObject(_course, new ValidationContext(_course), true);

        // Assert
        validationAction.Should().Throw<ValidationException>()
            .WithMessage("Course name is required");
    }

    [Test]
    public void CourseName_MaxLengthValidation_Valid()
    {
        // Arrange
        _course.CourseName = new string('A', 120);

        // Act
        Action validationAction = () => Validator.ValidateObject(_course, new ValidationContext(_course), true);

        // Assert
        validationAction.Should().NotThrow<ValidationException>();
    }

    [Test]
    public void CourseName_MaxLengthValidation_Invalid()
    {
        // Arrange
        _course.CourseName = new string('A', 121);

        // Act
        Action validationAction = () => Validator.ValidateObject(_course, new ValidationContext(_course), true);

        // Assert
        validationAction.Should().Throw<ValidationException>()
            .WithMessage("The field CourseName must be a string or array type with a maximum length of '120'.");
    }

    [Test]
    public void CourseName_MinLengthValidation_Valid()
    {
        // Arrange
        _course.CourseName = "A";

        // Act
        Action validationAction = () => Validator.ValidateObject(_course, new ValidationContext(_course), true);

        // Assert
        validationAction.Should().NotThrow<ValidationException>();
    }

    [Test]
    public void CourseName_MinLengthValidation_Invalid()
    {
        // Arrange
        _course.CourseName = "A";

        // Act
        Action validationAction = () => Validator.ValidateObject(_course, new ValidationContext(_course), true);

        // Assert
        validationAction.Should().Throw<ValidationException>()
            .WithMessage("Course Name must be a minimum length of '2'.");
    }

    [Test]
    public void Description_RequiredValidation_Valid()
    {
        // Arrange
        _course.Description = "Valid Description";

        // Act
        Action validationAction = () => Validator.ValidateObject(_course, new ValidationContext(_course), true);

        // Assert
        validationAction.Should().NotThrow<ValidationException>();
    }

    [Test]
    public void Description_RequiredValidation_Invalid()
    {
        // Arrange
        _course.Description = null;

        // Act
        Action validationAction = () => Validator.ValidateObject(_course, new ValidationContext(_course), true);

        // Assert
        validationAction.Should().Throw<ValidationException>()
            .WithMessage("Description is required");
    }

    [Test]
    public void Description_MaxLengthValidation_Valid()
    {
        // Arrange
        _course.Description = new string('A', 60);

        // Act
        Action validationAction = () => Validator.ValidateObject(_course, new ValidationContext(_course), true);

        // Assert
        validationAction.Should().NotThrow<ValidationException>();
    }

    [Test]
    public void Description_MaxLengthValidation_Invalid()
    {
        // Arrange
        _course.Description = new string('A', 61);

        // Act
        Action validationAction = () => Validator.ValidateObject(_course, new ValidationContext(_course), true);

        // Assert
        validationAction.Should().Throw<ValidationException>()
            .WithMessage("The field Description must be a string or array type with a maximum length of '60'.");
    }

    [Test]
    public void TeacherId_RequiredValidation_Valid()
    {
        // Arrange
        _course.TeacherId = Guid.NewGuid();

        // Act
        Action validationAction = () => Validator.ValidateObject(_course, new ValidationContext(_course), true);

        // Assert
        validationAction.Should().NotThrow<ValidationException>();
    }
}
