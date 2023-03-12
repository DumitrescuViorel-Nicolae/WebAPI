using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DatabaseModels
{
    [Table("test2")]
    public partial class Test2Model
    {
        [Column("ID")]
        public int? Id { get; set; }
        [StringLength(50)]
        public string Property { get; set; }
        [StringLength(50)]
        public string AnotherProperty { get; set; }
    }
}
