using System.Collections.Generic;
using System;

namespace GradeBook
{
  public class Statistics
  {

    private int count = 0;
    private double sum = 0.0;

    public double Average
    {
      get
      {
        return sum / count;
      }
    }
    public double High;

    public double Low;

    public Statistics()
    {
      High = double.MinValue;
      Low = double.MaxValue;
    }

    public char Letter
    {
      get
      {
        switch (Average)
        {
          case var d when d >= 90:
            return 'A';
          case var d when d >= 80:
            return 'B';
          case var d when d >= 70:
            return 'C';
          case var d when d >= 60:
            return 'D';
          default:
            return 'F';
        }
      }
    }

    public void Add(double grade)
    {
      count++;
      sum += grade;
      Low = Math.Min(Low, grade);
      High = Math.Max(High, grade);
    }

    public Statistics Calculate(List<double> grades)
    {
      foreach (var grade in grades)
      {
        Add(grade);
      }

      return this;
    }
  }

}