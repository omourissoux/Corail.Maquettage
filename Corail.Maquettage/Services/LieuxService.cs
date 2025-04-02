using Corail.Maquettage.Models;

namespace Corail.Maquettage.Services;

public class LieuxService
{
    private List<LieuDeLivraisonInfosDto> lieuDeLivraisonInfos;

    private List<LieuDeLivraisonDetailDto> lieuDeLivraisonDetail;
    protected void Init()
    {
        var names = new[] { "Ecole", "Mairie", "Stade", "Piscine", "Salle des fêtes" };
        var rues = new[] { "Rue des Platanes", "Rue des Coquelicots", "Rue des Bleuets", "Rue des Augas", "Rue des fêtes" };
        var num = new[] { "1", "2", "3", "4", "5" };
        var compl = new[] { "compl1", "compl2", "compl3", "compl4", "compl5" };

        lieuDeLivraisonInfos = Enumerable.Range(0, 5).Select(index => new LieuDeLivraisonInfosDto(index+1, names[index], "64260", "Arudy")).ToList();
        lieuDeLivraisonDetail = [.. Enumerable.Range(0, 5).Select(index => new LieuDeLivraisonDetailDto(index + 1, names[index], num[index], rues[index], compl[index], "64260", "Arudy"))];

    }

    public LieuxService() 
    { 
        Init();
    }

    public async Task<List<LieuDeLivraisonPreview>> GetLocations()
    {
        // API Call simulation
        await Task.Delay(1000);

        return [.. lieuDeLivraisonInfos.Select(ll => new LieuDeLivraisonPreview()
        {
            Id = ll.Id,
            Nom = ll.Nom,
            CodePostal = ll.CodePostal,
            Ville = ll.Ville
        })];
    }

    public async Task AddLocation(LieuxDeLivraisonModel lieu)
    {
        // API Call simulation
        await Task.Delay(500);

        // ATTENTION génération de l'id uniquement pour du test en DUR !!!!!
        lieuDeLivraisonInfos.Add(new LieuDeLivraisonInfosDto(DateTime.Now.Minute + DateTime.Now.Second, lieu.Nom, lieu.CodePostal, lieu.Ville));
        lieuDeLivraisonDetail.Add(new LieuDeLivraisonDetailDto(DateTime.Now.Minute + DateTime.Now.Second, lieu.Nom, lieu.Numero, lieu.Rue, lieu.Complement, lieu.CodePostal, lieu.Ville));
    }

    public async Task UpdateLocation(LieuxDeLivraisonModel lieu)
    {
        // API Call simulation
        await Task.Delay(500);

        var index = lieuDeLivraisonInfos.FindIndex(l => l.Id == lieu.Id);
        if (index != -1)
        {
            lieuDeLivraisonInfos[index] = new LieuDeLivraisonInfosDto(lieu.Id.GetValueOrDefault(), lieu.Nom, lieu.CodePostal, lieu.Ville);
            lieuDeLivraisonDetail[index] = new LieuDeLivraisonDetailDto(lieu.Id.GetValueOrDefault(), lieu.Nom, lieu.Numero, lieu.Rue, lieu.Complement, lieu.CodePostal, lieu.Ville);
        }
    }

    public async Task<LieuDeLivraisonDetailDto?> GetLocationById(int id)
    {
        // API Call simulation
        await Task.Delay(250);

        return lieuDeLivraisonDetail.Find(l => l.Id == id);
    }

    public async Task DeleteLocation(int id)
    {
        // API Call simulation
        await Task.Delay(250);

        lieuDeLivraisonInfos.RemoveAll(l => l.Id == id);
        lieuDeLivraisonDetail.RemoveAll(l => l.Id == id);
    }
}
