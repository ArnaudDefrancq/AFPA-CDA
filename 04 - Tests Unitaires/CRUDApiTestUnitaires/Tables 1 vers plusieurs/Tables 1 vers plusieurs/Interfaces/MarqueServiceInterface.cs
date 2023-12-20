using Tables_1_vers_plusieurs.Models.Data;

namespace Tables_1_vers_plusieurs.Interfaces
{
	public interface MarqueServiceInterface
	{
		void AddMarque(Marque v);
		void DeleteMarque(Marque v);
		IEnumerable<Marque> GetAllMarques();
		Marque GetMarqueById(int id);
		void UpdateMarque(Marque v);
	}
}
