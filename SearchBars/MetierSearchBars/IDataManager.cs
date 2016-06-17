using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    /// <summary>
    /// Interface imposant un contrat aux classes de persistance qui souhaitent être utilisées par le Métier
    /// </summary>
    public interface IDataManager
    {
        /// <summary>
        /// Méthode permettant de charger la liste des Users
        /// </summary>
        /// <returns>La liste des Users chargée de façon encapsulée (car utilisée par d'autres assemblages que Métier)</returns>
        IEnumerable<IUser> loadUsers();

        /// <summary>
        /// Méthode permettant de charger la liste des Villes
        /// </summary>
        /// <returns>La liste des Villes chargée de façon encapsulée (car utilisée par d'autres assemblages que Métier)</returns>
        IEnumerable<IVille> loadVilles();

        /// <summary>
        /// Méthode permettant de sauvegarder la liste de Users du métier
        /// </summary>
        /// <param name="userList">la liste de Users à sauvegarder</param>
        void saveUsers(List<IUser> userList);

        /// <summary>
        /// Méthode permettant de sauvegarder la liste de Ville du métier
        /// </summary>
        /// <param name="villeList">la liste de Villes à sauvegarder</param>
        void saveVille(List<IVille> villeList);
    }
}
