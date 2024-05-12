using System;
using System.ComponentModel.DataAnnotations;

namespace ShareSpend.Domain.Entities;

public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [EmailAddress]
    public string Email { get; set; }

    //Navigation properties
    public List<Receipt> Receipts { get; set; }

    public List<UserReceiptContainer> UserReceiptContainers { get; set; }
}