using System;
using System.Collections.Generic;

namespace gestionStock.Models.Data;

public partial class Category
{
    public int IdCategorie { get; set; }

    public string? LibelleCategorie { get; set; }

    public int IdTypeProduit { get; set; }

    public virtual ICollection<Article> Articles { get; set; } = new List<Article>();

    public virtual Typesproduit IdTypeProduitNavigation { get; set; } = null!;
}
