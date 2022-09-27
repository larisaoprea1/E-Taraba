namespace ETaraba.Domain.Models
{
    public class BaseModel : Entity
    {
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}