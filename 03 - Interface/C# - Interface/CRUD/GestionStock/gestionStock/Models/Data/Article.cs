using System;
using System.Collections.Generic;

namespace gestionStock.Models.Data;

public partial class Article
{
    public int IdArticle { get; set; }

    public string? LibelleArticle { get; set; }

    public int? QuantiteStrockee { get; set; }

    public int IdCategorie { get; set; }

    public virtual Category IdCategorieNavigation { get; set; } = null!;
}
