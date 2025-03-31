using System.ComponentModel.DataAnnotations;

namespace Corail.Maquettage.Models;

public class LieuxDeLivraisonModel
{
    public int? Id { get; set; }
    [Required(ErrorMessage = "Le nom est obligatoire")]
    public string Nom { get; set; }
    public string Numero { get; set; }
    [Required(ErrorMessage = "La rue est obligatoire")]
    public string Rue { get; set; }
    public string Complement { get; set; }
    [Required(ErrorMessage = "Le code postal est obligatoire")]
    public string CodePostal { get; set; }
    [Required(ErrorMessage = "La ville est obligatoire")]
    public string Ville { get; set; }
}
