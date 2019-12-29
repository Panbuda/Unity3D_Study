using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernateStudy.Model;

namespace NHibernateStudy.Managers
{
	interface IUserManager
	{
		bool Add(User user);
		bool Update(User user);
		bool Delete(User user);
		User GetUserByName(string userName);
	}
}
