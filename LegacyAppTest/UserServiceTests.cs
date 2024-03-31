using LegacyApp;

namespace LegacyAppTest;

public class UserServiceTests
{
    [Fact]
    public void AddUser_ReturnsFalseWhenFirstNameIsEmpty()
    {
        
        // Arrange
        var userService = new UserService();

        // Act
        var result = userService.AddUser(
            null, 
            "Kowalski", 
            "kowalski@wp.pl",
            DateTime.Parse("2000-01-01"),
            1
        );

        // Assert
        // Assert.Equal(false, result);
        Assert.False(result);
    }

    [Fact]
    public void AddUser_ReturnsFalseWhenMissingAtSignAndDotInEmail()
    {
        //Arrange
        var userService = new UserService();
        //Act
        var result = userService.AddUser(
            "Jan", 
            "Kowalski", 
            "kowalskiwppl",
            DateTime.Parse("2000-01-01"),
            1
        );
        //Assert
        Assert.False(result);
    }
    [Fact]
    public void AddUser_ReturnsFalseWhenYoungerThen21YearsOld()
    {
        //Arrange
        var userService = new UserService();
        //Act
        var result = userService.AddUser(
            "Jan", 
            "Kowalski", 
            "kowalski@wp.pl",
            DateTime.Now,
            1
        );
        //Assert
        Assert.False(result);
    }
    [Fact]
    public void AddUser_ReturnsTrueWhenVeryImportantClient()
    {
        //Arrange
        var userService = new UserService();
        //Act
        var result = userService.AddUser(
            "Jan", 
            "Kowalski", 
            "kowalski@kowalski.pl",
            DateTime.Parse("2000-01-01"),
            2
        );
        //Assert
        Assert.True(result);
    }
    [Fact]
    public void AddUser_ReturnsTrueWhenImportantClient()
    {
        //Arrange
        var userService = new UserService();
        //Act
        var result = userService.AddUser(
            "Jan", 
            "Kowalski", 
            "kowalski@kowalski.pl",
            DateTime.Parse("2000-01-01"),
            3
        );
        //Assert
        Assert.True(result);
    }
    [Fact]
    public void AddUser_ReturnsTrueWhenNormalClient()
    {
        //Arrange
        var userService = new UserService();
        //Act
        var result = userService.AddUser(
            "Jan", 
            "Kwiatkowski", 
            "andrzejewicz@wp.pl",
            DateTime.Parse("2000-01-01"),
            5
        );
        //Assert
        Assert.True(result);
    }
    [Fact]
    public void AddUser_ReturnsFalseWhenNormalClientWithNoCreditLimit()
    {
        //Arrange
        var userService = new UserService();
        //Act
        var result = userService.AddUser(
            "Jan", 
            "Kowalski", 
            "kowalski@kowalski.pl",
            DateTime.Parse("2000-01-01"),
            1
        );
        //Assert
        Assert.False(result);
    }
    [Fact]
    public void AddUser_ThrowsExceptionWhenUserDoesNotExist()
    {
        // Arrange
        var userService = new UserService();
        // Act
        Action action = () => userService.AddUser(
            "Jan", 
            "Kowalski", 
            "kowalski@kowalski.pl",
            DateTime.Parse("2000-01-01"),
            100
        );
        // Assert
        Assert.Throws<ArgumentException>(action);
    }
    [Fact]
    public void AddUser_ThrowsExceptionWhenUserNoCreditLimitExistsForUser()
    {
        // Arrange
        var userService = new UserService();
        // Act
        Action action = () => userService.AddUser(
            "Jan", 
            "Kowalski", 
            "kowalski@kowalski.pl",
            DateTime.Parse("2000-01-01"),
            100
        );
        // Assert
        Assert.Throws<ArgumentException>(action);
    }
    // AddUser_ReturnsFalseWhenMissingAtSignAndDotInEmail. Done
    // AddUser_ReturnsFalseWhenYoungerThen21YearsOld. Done 
    // AddUser_ReturnsTrueWhenVeryImportantClient. Done
    // AddUser_ReturnsTrueWhenImportantClient. Done
    // AddUser_ReturnsTrueWhenNormalClient. Done
    // AddUser_ReturnsFalseWhenNormalClientWithNoCreditLimit. Done
    // AddUser_ThrowsExceptionWhenUserDoesNotExist. Done
    // AddUser_ThrowsExceptionWhenUserNoCreditLimitExistsForUser. Done
    
}