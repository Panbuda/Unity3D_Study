using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Cfg;
using NHibernate;
using NHibernateStudy.Model;
using NHibernateStudy.Managers;

namespace NHibernateStudy
{
	class Program
	{
		static void Main(string[] args)
		{
			//Configuration cfg = new Configuration();
			//cfg.Configure();//解析hibernate.cfg.xml
			//cfg.AddAssembly("NHibernateStudy");//解析命名空间内的嵌入式配置文件
			//ISessionFactory sessionFactory = null;
			//ISession session = null;
			//ITransaction transaction = null;
			//try
			//{
			//	sessionFactory = cfg.BuildSessionFactory();//生成会话工厂
			//	session = sessionFactory.OpenSession();//打开一个会话

			//	//使用会话对数据库进行操作
			//	//User newUser = new User() { username = "xuweizhen", password = "77889" };
			//	//session.Save(newUser);

			//	//使用事务（transaction）对一系列操作进行绑定
			//	transaction = session.BeginTransaction();
			//	User newUser1 = new User() { username = "xuweizhen1", password = "77889" };
			//	User newUser2 = new User() { username = "xuweizhen2", password = "77889" };
			//	session.Save(newUser1);
			//	session.Save(newUser2);
			//	transaction.Commit();
			//}
			//catch(Exception e)
			//{
			//	Console.WriteLine(e.ToString());
			//}
			//finally
			//{
			//	if (transaction != null)
			//		transaction.Dispose();
			//	if (session != null)
			//		session.Close();
			//	if (sessionFactory != null)
			//		sessionFactory.Close();
			//}

			User newUser = new User() { username = "kakaluote", password = "fffffff" };
			IUserManager userManager = new UserManager();
			//User user = userManager.GetUserByName("zhaoyijie");
			//Console.WriteLine(user.id.ToString()+ user.username+user.password);
			//userManager.Update(newUser);
			//userManager.Delete(newUser);
			//userManager.Add(newUser);
			Console.ReadKey();
		}
	}
}
