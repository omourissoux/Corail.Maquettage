namespace Corail.Maquettage.Models;

public class LieuxDeLivraisonDtos
{
}
public record class LieuDeLivraisonInfosDto(int Id, string Nom, string CodePostal, string Ville)
{
    public string VilleMaj => Ville.ToUpper();
}

public record NewLieuDeLivraisonDto(string Nom, string Numero, string Rue, string CodePostal, string Ville);

public record LieuDeLivraisonDetailDto(int Id, string Nom, string Numero, string Rue, string CodePostal, string Ville);