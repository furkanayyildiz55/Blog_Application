﻿using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class Message2Manager : IMessage2Service
    {
        IMessage2Dal _message2Dal;

        public Message2Manager(IMessage2Dal messageDal)
        {
            _message2Dal = messageDal;
        }

        public void Add(Message2 t)
        {
            _message2Dal.Insert(t);
        }

        public void Delete(Message2 t)
        {
            _message2Dal.Delete(t);
        }

        public Message2 GetByID(int id)
        {
            return _message2Dal.GetByID(id);
        }

        public List<Message2> GetList()
        {
            return _message2Dal.GetListAll();
        }

        public List<Message2> GetInboxListByWriter(int  WriterID)
        {
            return _message2Dal.GetListWithMessageByWriter(WriterID);
        }

        public void Update(Message2 t)
        {
            _message2Dal.Update(t);
        }

    }
}
