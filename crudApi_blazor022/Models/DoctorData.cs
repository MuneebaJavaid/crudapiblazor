using System.ComponentModel.DataAnnotations;

namespace crudApi_blazor022.Models
{
    public class DoctorData
    {
        [Key]
        public int Id { get; set; }
        public string DocName { get; set; }
        public int DocExperience { get; set; }
    }
}