using System;
using System.Collections.Generic;

namespace GradeBook
{
  class Program
  {
    static void Main(string[] args)
    {

      var book = new Book("Jason's Grade Book");
      book.GradeAdded += OnGradeAdded;

      string input;

      do
      {
        Console.WriteLine("Enter a new grade. To finish enter 'q'");
        input = Console.ReadLine().ToLower();

        try
        {
          var grade = double.Parse(input);
          book.AddGrade(grade);
        }
        catch (FormatException e)
        {

          Console.WriteLine(e.Message);
          if (input != "q")
          {
            Console.WriteLine($"You did not provide a proper grade: '{input}");
          }
        }
        catch (ArgumentException)
        {
          Console.WriteLine($"The provided grade is not within an acceptable range(0-100) {input}");
        }
      } while (input != "q");


      var stats = book.GetStatistics();

      Console.WriteLine($"For the book labeled {book.Name}");
      Console.WriteLine($"The average is {stats.Average:N1}");
      Console.WriteLine($"The lowest is {stats.Low}");
      Console.WriteLine($"The highest is {stats.High}");
      Console.WriteLine($"The letter grade is {stats.Letter}");
    }

    static void OnGradeAdded(object sender, EventArgs e)
    {
      Console.WriteLine("A grade was added");
    }
  }
}