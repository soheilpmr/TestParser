using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqlLibrary
{
    public class TestKind
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("TestTime")]
        public int TestTime_Id { get; set; }
        public string KindOfTest { get; set; }
        
        public ICollection<TestDetail> TestDetail { get; set; }
        
        public TestTime TestTime { get; set; }

        
        
    }
}
