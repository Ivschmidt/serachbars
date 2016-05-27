using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    class Bar : IEquatable<Bar>, IBar
    {
        private Dictionary<User, Avis> commentaires = new Dictionary<User, Avis>();
        //je n'ai pas reussi à faire un ROD de <IUser,Avis> car impossible de convertir le dico <User,Avis> en <IUser,Avis>
        public ReadOnlyDictionary<IUser, Avis> Commentaires
        {
            get;
            private set;
        }

        private List<Boisson> listBoissons = new List<Boisson>();
        public IEnumerable<IBoisson> ListBoisson
        {
            get
            {
                return listBoissons;
            }
        }

        private List<string> listCheminPhoto = new List<string>();
        public ReadOnlyCollection<string> CheminPhotoROC
        {
            get;
            private set; 
        }

        public string Nom { get; set; }
        public float? NoteMoyenne
        {
            get
            {
                if (commentaires == null || commentaires.Count == 0)
                {
                    return null;
                }
                return (float) commentaires.Average(kvp => kvp.Value.Note);
            }
        }
        public CoordonneesGPS GPS{ get; set; }
        public bool Restauration { get; set; }

        public Bar(string nom, CoordonneesGPS gps, bool restauration = false) 
        {
            Nom = nom;
            GPS = gps;
            Restauration = restauration;
            CheminPhotoROC = new ReadOnlyCollection<string>(listCheminPhoto);

            //je n'ai pas reussi à faire un ROD de <IUser,Avis> car impossible de convertir le dico <User,Avis> en <IUser,Avis>
            Commentaires = new ReadOnlyDictionary<IUser, Avis>(commentaires.ToDictionary(kvp => kvp.Key as IUser, kvp => kvp.Value)); 
        }

        public void ajouterBoisson(Boisson b)
        {
            listBoissons.Add(b);
        }
        /// <summary>
        /// returns a hash code in order to use this class in hash table
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode()
        {
            return GPS.GetHashCode() + Nom.GetHashCode();
        }

        /// <summary>
        /// checks if the "right" object is equal to this Bar or not
        /// </summary>
        /// <param name="right">the other object to be compared with this Bar</param>
        /// <returns>true if equals, false if not</returns>
        public override bool Equals(object right)
        {
            //check null
            if (object.ReferenceEquals(right, null))
            {
                return false;
            }

            if (object.ReferenceEquals(this, right))
            {
                return true;
            }

            if (this.GetType() != right.GetType())
            {
                return false;
            }

            return this.Equals(right as Bar);
        }

        /// <summary>
        /// checks if this Bar is equal to the other Bar
        /// </summary>
        /// <param name="other">the other Bar to be compared with</param>
        /// <returns>true if equals</returns>
        public bool Equals(Bar other)
        {
            return (this.GPS.Equals(other.GPS) && this.Nom.Equals(other.Nom));
        }

        public void laisserAvis(Avis avis, User user)
        {
            commentaires.Add(user, avis);
        }

        public override string ToString()
        {
            string temp = Nom + "\n";
            if(NoteMoyenne != null)
            {
                temp += "note moyenne : " + NoteMoyenne.ToString() + "/5\n";
            }
            if(ListBoisson != null)
            {
                foreach(Boisson boiss in ListBoisson)
                {
                    temp += boiss.ToString();
                }
                temp += "\n";
            }
            if(commentaires != null && commentaires.Count > 0)
            {
                temp += "Liste des avis :\n";
                foreach(KeyValuePair<User,Avis> kvp in commentaires)
                {
                    temp += kvp.Key.Pseudo + " : " + kvp.Value.Note + "/5\n" + kvp.Value.Description + "\n"; 
                }
            }
            return temp;
        }
    }
}
