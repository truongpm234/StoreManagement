using BusinessObject;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class AccountDAO
    {
        public static AccountMember GetAccountById(string id)
        {
            using var _context = new MyStoreContext();
            return _context.AccountMembers.FirstOrDefault(e=>e.MemberId.Equals(id));
        }


    }
}
