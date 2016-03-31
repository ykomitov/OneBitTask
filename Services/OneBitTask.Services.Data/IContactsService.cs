namespace OneBitTask.Services.Data
{
    using System.Linq;
    using Models;

    public interface IContactsService
    {
        IQueryable<Contact> All();

        Contact GetById(int id);

        void DeleteById(int id);

        int CreateContact(string firstName, string lastName, bool sex, string telephone, string photoUrl, Status status);

        void Save();

        bool ToggleStatus(int id);
    }
}
