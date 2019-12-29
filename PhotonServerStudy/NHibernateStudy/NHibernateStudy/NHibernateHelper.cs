using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg;

namespace NHibernateStudy
{
	class NHibernateHelper
	{
		public static ISessionFactory sessionFactory = null;
		public static ISessionFactory SessionFactory
		{
			get
			{
				if(sessionFactory == null)
				{
					try
					{
						Configuration cfg = new Configuration();
						cfg.Configure();
						cfg.AddAssembly("NHibernateStudy");
						sessionFactory = cfg.BuildSessionFactory();
					}
					catch(Exception e)
					{
						Console.WriteLine(e.ToString());
					}
				}
				return sessionFactory;
			}
		}

		public static ISession OpenSession()
		{
			return SessionFactory.OpenSession();
		}
	}
}
