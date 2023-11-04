using EntityLayer.Concrete;


namespace BusinessLayer.Abstract
{
    public interface IWriterService
    {
        void WriterAdd(Writer writer);
        void WriterDelete(Writer writer);
        void WriterUpdate(Writer writer);
        List<Writer> GetList(Writer writer);
        Writer GetByID(int id);
    }
}
