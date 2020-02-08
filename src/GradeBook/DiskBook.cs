using System.Collections.Generic;
using System.IO;
using System;

namespace GradeBook
{
  public class DiskBook : Book
  {
    public DiskBook(string name) : base(name)
    {
    }

    public override event GradeAddedDelegate GradeAdded;

    public override void AddGrade(double grade)
    {
      using (var writer = File.AppendText($"{Name}.txt"))
      {
        writer.WriteLine(grade);

        this?.GradeAdded(this, new EventArgs());
      }
    }

    public override Statistics GetStatistics()
    {
      var stats = new Statistics();

      using (var reader = File.OpenText($"{Name}.txt"))
      {
        var line = reader.ReadLine();

        while (line != null)
        {
          var number = double.Parse(line);
          stats.Add(number);
          line = reader.ReadLine();
        }
      }

      return stats;
    }
  }
}