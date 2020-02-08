using System;
using Xunit;


namespace GradeBook.Tests
{
  public class BookTests
  {

    [Fact]
    public void GradeMustBeWithinRange0To100()
    {
      var book = new InMemoryBook("Book");

      book.AddGrade(100);
      book.AddGrade(0);
      Assert.Throws<ArgumentException>(() => book.AddGrade(-10));

      var stats = book.GetStatistics();

      Assert.InRange(stats.High, 0, 100);
      Assert.InRange(stats.Low, 0, 100);
      Assert.Equal(0, stats.Low);
      Assert.Equal(100, stats.High);
    }


    [Fact]
    public void BookCalculatesAnAverageGrade()
    {
      // arrange
      var book = new InMemoryBook("");
      book.AddGrade(89.1);
      book.AddGrade(90.5);
      book.AddGrade(77.3);

      // act

      var stats = book.GetStatistics();

      // assert

      Assert.Equal(85.6, stats.Average, 1);
      Assert.Equal(90.5, stats.High, 1);
      Assert.Equal(77.3, stats.Low, 1);
      Assert.Equal('B', stats.Letter);
    }
  }
}
