using DataAccessLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Repositories
{
    public class RolesRepository : IRolesRepository
    {
        private readonly NSC_VraagpunteStelselEntities dbContext;
        public RolesRepository()
        {
            dbContext = new NSC_VraagpunteStelselEntities();
        }
        public List<string> GetAllRoleNames()
        {
            return dbContext.Roles.Select(r => r.RoleName).ToList();
        }

        public List<Role> GetAllRoles()
        {
            return dbContext.Roles.ToList();
        }
    }
}
