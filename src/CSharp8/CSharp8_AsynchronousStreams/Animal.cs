using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Animal
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Birthday { get; set; }
    public bool Processed { get; set; }
        
    public override string ToString()
    {
        return $"Animal - Id: {Id}, Name: {Name}, Birthday: {Birthday:dd/MM/yyyy. HH:mm:ss.fff}";
    }
}