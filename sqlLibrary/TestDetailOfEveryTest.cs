using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqlLibrary
{
    public class TestDetailOfEveryTest
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("TestDetail")]
        public int TestDetail_Id { get; set; }
        public string AssembelyFileName { get; set; }
        public string ClassName { get; set; }
        public string TestName { get; set; }
        public string Outcome { get; set; }
        public double DurationInSeconds { get; set; }
        public string ErrorMessage { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TestDetail TestDetail { get; set; }
    }
}
