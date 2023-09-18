using System;
using System.Collections.Generic;

namespace LOGGIN_AGENDA.Models;

public partial class Persona
{
    public int IdPersona { get; set; }

    public string? NombreCompleto { get; set; }

    public int? Telefono { get; set; }

    public string? Direccion { get; set; }

    public string? Correo { get; set; }

    public DateTime? FechaCita { get; set; }
}
