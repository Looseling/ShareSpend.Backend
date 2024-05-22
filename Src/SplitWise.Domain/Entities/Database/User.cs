using System.ComponentModel.DataAnnotations;

namespace ShareSpend.Domain.Entities;

public class User
{
    public int Id { get; set; }

    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? PublicId { get; set; }

    public List<Receipt>? Receipts { get; set; }
    public List<Container>? Containers { get; set; }
}