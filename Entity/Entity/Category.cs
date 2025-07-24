using System.ComponentModel.DataAnnotations;


namespace Entity
{
    public class Category
    {
        [Key]
        public int ID { get; set; }

        [StringLength(maximumLength: 50)]
        public string Name { get; set; }

        [StringLength(maximumLength: 450)]
        public string UserId { get; set; }
    }
}
