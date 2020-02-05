using System;
using System.Collections.Generic;

namespace GradeBook
{

  public delegate void GradeAddedDelegate(object sender, EventArgs args);

  public class Book
  {

    public event GradeAddedDelegate GradeAdded;
    private List<double> grades;

    public string Name
    {
      get;
      set;
    }

    const string CATEGORY = "Science";


    public Book(string name)
    {
      Name = name;
      grades = new List<double>();
    }

    public void AddGrade(char letter)
    {

      switch (char.ToUpper(letter))
      {
        case 'A':
          AddGrade(90);
          break;
        case 'B':
          AddGrade(80);
          break;
        case 'C':
          AddGrade(70);
          break;
        case 'D':
          AddGrade(60);
          break;
        default:
          AddGrade(0);
          break;
      }
    }



    public Statistics GetStatistics()
    {
      var result = new Statistics();
      result.Low = double.MaxValue;
      result.High = double.MinValue;
      var sum = 0.0;

      var index = 0;

      while (index < grades.Count)
      {
        var grade = grades[index++];
        sum += grade;
        result.Low = Math.Min(result.Low, grade);
        result.High = Math.Max(result.High, grade);
      }

      result.Average = sum / grades.Count;

      switch (result.Average)
      {
        case var d when d >= 90:
          result.Letter = 'A';
          break;
        case var d when d >= 80:
          result.Letter = 'B';
          break;
        case var d when d >= 70:
          result.Letter = 'C';
          break;
        case var d when d >= 60:
          result.Letter = 'D';
          break;
        default:
          result.Letter = 'F';
          break;
      }

      return result;
    }

    public void AddGrade(double grade)
    {
      if (grade <= 100 && grade >= 0)
      {
        grades.Add(grade);

        if (GradeAdded != null)
        {
          GradeAdded(this, new EventArgs());
        }
      }
      else
      {
        throw new ArgumentException($"Invalid grade {nameof(grade)}");
      }
    }

  }
}