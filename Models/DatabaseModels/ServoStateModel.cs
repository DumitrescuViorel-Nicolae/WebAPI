using System.ComponentModel.DataAnnotations;

namespace Models.DatabaseModels
{
    public class ServoStateModel
    {
        [Key]
        public int Id { get; set; }
        public bool IsOn { get; set; }
    }

}
