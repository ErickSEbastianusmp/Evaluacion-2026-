using System.ComponentModel.DataAnnotations;

namespace TecnoGasHogar.Models;

public class SolicitudServicio
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre del cliente es obligatorio.")]
    [Display(Name = "Cliente")]
    public required string Cliente { get; set; }

    [Required(ErrorMessage = "El teléfono es obligatorio.")]
    [Display(Name = "Teléfono")]
    public required string Telefono { get; set; }

    [Required(ErrorMessage = "El distrito es obligatorio.")]
    [Display(Name = "Distrito")]
    public required string Distrito { get; set; }

    [Required(ErrorMessage = "El tipo de servicio es obligatorio.")]
    [Display(Name = "Tipo de Servicio")]
    public required string TipoServicio { get; set; }

    [Display(Name = "Descripción")]
    public string? Descripcion { get; set; }

    [Display(Name = "Fecha de Registro")]
    public DateTime FechaRegistro { get; set; } = DateTime.Now;
}
