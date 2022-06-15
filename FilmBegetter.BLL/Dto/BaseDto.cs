using System.ComponentModel.DataAnnotations.Schema;

namespace FilmBegetter.BLL.Dto; 

public abstract class BaseDto {
    
    public string Id { get; set; }

    public DateTime CreationDate { get; set; }
}