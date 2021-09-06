using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqlLibrary
{
    public class FiveShowestTest
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("TestDetail")]
        public int TestDetail_Id { get; set; }
        public string FullClassName { get; set; }
        public string ClassName { get; set; }
        public double DurationSecond { get; set; }
        public string TestName { get; set; }
        public TestDetail TestDetail { get; set; }
    }
}
