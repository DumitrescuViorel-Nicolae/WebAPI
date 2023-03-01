using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class TestsFromDbModel
    {
        public TestModel CreatedModel { get; set; }
        public List<TestModel> ModelsInDb { get; set; }
    }
}
