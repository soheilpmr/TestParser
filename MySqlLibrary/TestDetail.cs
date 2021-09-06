using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqlLibrary
{
    public class TestDetail
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("TestKind")]
        public int TestKind_Id { get; set; }

        public double PercentPassed { get; set; }
        public string DateTimeDuration { get; set; }
        public int TotalTests { get; set; }
        public int Passed { get; set; }

        //public int Failed { get; set; }

        public ICollection<TestDetailOfEveryTest> TestDetailOfEveryTest { get; set; }
        public ICollection<FiveShowestTest> FiveMostShowestTest { get; set; }
        public TestKind TestKind { get; set; }

    }
}
