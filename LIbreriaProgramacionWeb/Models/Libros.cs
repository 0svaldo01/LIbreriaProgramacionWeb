using System;
using System.Collections.Generic;

namespace LIbreriaProgramacionWeb.Models;

public partial class Libros
{
    public int IdLibro { get; set; }

    public string Titulo { get; set; } = null!;

    public string Autor { get; set; } = null!;

    public int? AñoPublicacion { get; set; }

    public int? IdGenero { get; set; }

    public virtual Generosliterarios? IdGeneroNavigation { get; set; }
}
