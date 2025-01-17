﻿using CardDomain.Enums;
using System.ComponentModel.DataAnnotations;

namespace CardDomain.Entities;

public class Card
{
    [Key]
    public Guid Id { get; set; }
    public string Title { get; set; }
    public CardStatus Status { get; set; }
    public Guid PhotoId { get; set; }
    public Photo Photo { get; set; }
}
