using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    public interface IDataManager
    {
        IEnumerable<IUser> loadUsers();
        IEnumerable<IVille> loadVilles();
        void saveUsers(List<IUser> userList);
        void saveVille(List<IVille> villeList);
    }
}
