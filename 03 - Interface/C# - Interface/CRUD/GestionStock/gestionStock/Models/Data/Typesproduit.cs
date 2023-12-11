using System;
using System.Collections.Generic;

namespace gestionStock.Models.Data;

public partial class Typesproduit
{
    public int IdTypeProduit { get; set; }

    public string? LibelleTypeProduit { get; set; }

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
}
