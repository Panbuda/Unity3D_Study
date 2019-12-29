using NHibernateStudy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Criterion;

namespace NHibernateStudy.Managers
{
	class UserManager : IUserManager
	{
		public bool Add(User user)
		{
			//using语法可以自动将语句放进try块并且自动创建Dispose方法释放资源
			using (ISession session = NHibernateHelper.OpenSession())
			{
				try
				{
					session.Save(user);
				}
				catch
				{
					//用户名重复
					return false;
				}
			}
			return true;
		}
		public User GetUserByName(string userName)
		{
			using (ISession session = NHibernateHelper.OpenSession())
			{
				return session.CreateCriteria<User>().Add(Restrictions.Eq("username", userName)).UniqueResult<User>();
			}
		}
		//Update和Delete操作必须放在事务中，不然不会正确执行
		public bool Update(User user)
		{
			using (ISession session = NHibernateHelper.OpenSession())
			{
				using (ITransaction transaction = session.BeginTransaction())
				{
					try
					{
						session.Update(user);
						transaction.Commit();
					}
					catch
					{
						//用户名重复
						return false;
					}
				}
			}
			return true;
		}
		public bool Delete(User user)
		{
			using (ISession session = NHibernateHelper.OpenSession())
			{
				using (ITransaction transaction = session.BeginTransaction())
				{
					try
					{
						session.Delete(user);
						transaction.Commit();
					}
					catch
					{
						//查无此人
						return false;
					}
				}
			}
			return true;
		}
	}
}
