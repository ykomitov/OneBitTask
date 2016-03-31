namespace OneBitTask.Services.Data
{
    using System;
    using System.Linq;
    using Models;
    using OneBitTask.Data;

    public class ContactsService : IContactsService
    {
        private readonly IRepository<Contact> contacts;

        public ContactsService(IRepository<Contact> contacts)
        {
            this.contacts = contacts;
        }

        public IQueryable<Contact> All()
        {
            return this.contacts
                    .All()
                    .Where(c => c.Status != Status.Deleted)
                    .OrderBy(c => c.Id);
        }

        public Contact GetById(int id)
        {
            return this.contacts
                    .All()
                    .Where(c => c.Id == id)
                    .FirstOrDefault();
        }

        public void DeleteById(int id)
        {
            var contactToDelete = this.GetById(id);

            this.contacts.Delete(contactToDelete);
            this.contacts.SaveChanges();
        }

        public int CreateContact(string firstName, string lastName, bool sex, string telephone, string photoUrl, Status status)
        {
            var creationDate = DateTime.UtcNow;
            var newContact = new Contact()
            {
                 FirstName = firstName,
                 LastName = lastName,
                 Sex = sex,
                 Telephone = telephone,
                 PhotoUrl = photoUrl,
                 Status = status
            };

            newContact.CreatedOn = creationDate;

            this.contacts.Add(newContact);
            this.contacts.SaveChanges();

            return newContact.Id;
        }

        public bool ToggleStatus(int id)
        {
            var selectedContact = this.contacts.GetById(id);

            if (selectedContact.Status == Status.Active)
            {
                selectedContact.Status = Status.Inactive;
                this.contacts.SaveChanges();
                return true;
            }

            if (selectedContact.Status == Status.Inactive)
            {
                selectedContact.Status = Status.Active;
                this.contacts.SaveChanges();
                return true;
            }

            return false;
        }

        public void Save()
        {
            this.contacts.SaveChanges();
        }
    }
}
