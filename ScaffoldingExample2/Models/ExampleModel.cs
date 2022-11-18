using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ScaffoldingExample2.Models
{
    public class ExampleModel //Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime JoiningDate { get; set; }
        public int Age { get; set; }
    }

    public class ExampleModelContext : DbContext
    {
        public DbSet<ExampleModel> exampleModels { get; set; }
    }
}