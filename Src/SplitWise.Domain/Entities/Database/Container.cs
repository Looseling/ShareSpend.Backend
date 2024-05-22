using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShareSpend.Domain.Entities;

public class Container
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? PublicId { get; set; }
    public List<Receipt>? Receipts { get; set; }
    public List<User>? Users { get; set; }
    public string? AdminId { get; set; }
}