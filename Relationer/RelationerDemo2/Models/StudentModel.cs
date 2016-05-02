using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelationerDemo2.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual CourseModel Course { get; set; }

    }
}
