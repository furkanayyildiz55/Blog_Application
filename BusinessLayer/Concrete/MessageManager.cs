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
	public class MessageManager // : IMessageService
	{
		IMessadeDal _messageDal;

		//public MessageManager(IMessadeDal messageDal)
		//{
		//	_messageDal = messageDal;
		//}

		//public void Add(Message t)
		//{
		//	_messageDal.Insert(t);
		//}

		//public void Delete(Message t)
		//{
		//	_messageDal.Delete(t);
		//}

		//public Message GetByID(int id)
		//{
		//	return _messageDal.GetByID(id);
		//}

		//public List<Message> GetList()
		//{
		//	return _messageDal.GetListAll();
		//}

		//public List<Message> GetInboxListByWriter(string WriterMail)
		//{
		//	return _messageDal.GetListAll(x => x.Receiver == WriterMail);
		//}

		//public void Update(Message t)
		//{
		//	_messageDal.Update(t);
		//}
	}
}
