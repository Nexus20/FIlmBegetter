using System.ComponentModel.DataAnnotations.Schema;

namespace FilmBegetter.DAL.Entities; 

public abstract class BaseEntity {

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; }

    public DateTime CreationDate { get; set; }
}