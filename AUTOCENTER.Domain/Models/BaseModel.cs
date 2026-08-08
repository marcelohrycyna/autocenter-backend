using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AUTOCENTER.Domain.Models
{
    [DataContract]
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }
    }
}