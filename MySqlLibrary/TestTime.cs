using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqlLibrary
{
    public class TestTime
    {
        //public TestTime()
        //{
        //    TestKind = new HashSet<TestKind>();
        //}
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public ICollection<TestKind> TestKind { get; set; }
        //public int Totaltests { get; set; }
    }
}
