using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    /// <summary>
    /// Façade immuable d'un User
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// Pseudo de l'utilisateur : uniquement récupérable
        /// </summary>
        string Pseudo { get;}

        /// <summary>
        /// Mot de passe de l'utilisateur  : uniquement récupérable
        /// </summary>
        string Mdp { get;}

        /// <summary>
        /// Nom de l'utilisateur  : uniquement récupérable
        /// </summary>
        string Nom { get;}

        /// <summary>
        /// Prénom de l'utilisateur  : uniquement récupérable
        /// </summary>
        string Prenom { get;}

        /// <summary>
        /// Sexe de l'utilisateur  : uniquement récupérable
        /// Homme ou Femme (cf énumération Sexe)
        /// </summary
        Sexe Sexe { get; }

        /// <summary>
        /// Date de naissance de l'utilisateur  : uniquement récupérable
        /// </summary>
        DateTime DdN { get; }

        /// <summary>
        /// Numéro de téléphone de l'utilisateur  : uniquement récupérable
        /// </summary>
        string NumTel { get; }

        /// <summary>
        /// Ville d'habitation de l'utilisateur  : uniquement récupérable
        /// </summary>
        string Ville { get;  }

        /// <summary>
        /// Type de la boisson préférée de l'utilisateur  : uniquement récupérable
        /// </summary>
        TypeBoisson? BoissonPref { get;  }

        /// <summary>
        /// Photo de profil de l'utilisateur  : uniquement récupérable
        /// </summary>
        string PhotoDeProfil { get; set; }
    }
}
