using Api.Models.Data;

namespace Api.Interfaces
{
	public interface IVoituresService
	{
		Voiture GetVoitureById(int id);
		IEnumerable<Voiture> GetAllVoitures();
		void AddVoitures(Voiture v);
		void DeleteVoiture(Voiture v);
		void UpdateVoiture(Voiture v);
	}
}
