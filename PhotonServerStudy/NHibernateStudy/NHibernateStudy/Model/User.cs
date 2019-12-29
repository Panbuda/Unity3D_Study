using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateStudy.Model
{
	public class User
	{
		public virtual int id { get; set; }
		public virtual string username { get; set; }
		public virtual string password { get; set; }
	}
}
