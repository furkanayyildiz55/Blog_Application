using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class IMessageManager : IMessageService
	{
		IMessadeDal _messageDal;

		public IMessageManager(IMessadeDal messageDal)
		{
			_messageDal = messageDal;
		}

		public void Add(Message t)
		{
			_messageDal.Insert(t);
		}

		public void Delete(Message t)
		{
			_messageDal.Delete(t);
		}

		public Message GetByID(int id)
		{
			return _messageDal.GetByID(id);
		}

		public List<Message> GetList()
		{
			return _messageDal.GetListAll();
		}

		public void Update(Message t)
		{
			_messageDal.Update(t);
		}
	}
}
