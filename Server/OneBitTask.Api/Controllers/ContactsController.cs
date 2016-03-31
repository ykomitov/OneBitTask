namespace OneBitTask.Api.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using Models;
    using Services.Data;

    public class ContactsController : ApiController
    {
        private readonly IContactsService contacts;

        public ContactsController(IContactsService contacts)
        {
            this.contacts = contacts;
        }

        public IHttpActionResult Get()
        {
            var result = this.contacts
                .All()
                .ToList();

            return this.Ok(result);
        }

        public IHttpActionResult Get(int id)
        {
            var result = this.contacts
                .GetById(id);

            return this.Ok(result);
        }

        public IHttpActionResult Post(CreateContactRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var createdProjectId = this.contacts.CreateContact(
                model.FirstName,
                model.LastName,
                model.Sex,
                model.Telephone,
                model.PhotoUrl,
                model.Status);

            return this.Created("/api/Contacts", createdProjectId);
        }

        public IHttpActionResult Put(UpdateContactRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var contactToUpdate = this.contacts.GetById(model.Id);

            contactToUpdate.FirstName = model.FirstName;
            contactToUpdate.LastName = model.LastName;
            contactToUpdate.Sex = model.Sex;
            contactToUpdate.Telephone = model.Telephone;
            contactToUpdate.PhotoUrl = model.PhotoUrl;
            contactToUpdate.Status = model.Status;
            contactToUpdate.ModifiedOn = DateTime.UtcNow;

            this.contacts.Save();

            if (contactToUpdate != null)
            {
                return this.Ok();
            }

            return this.NotFound();
        }

        public IHttpActionResult Put(int id)
        {
            var statusChanged = this.contacts.ToggleStatus(id);

            if (!statusChanged)
            {
                return this.StatusCode(System.Net.HttpStatusCode.NotModified);
            }

            return this.Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var contactToDelete = this.contacts.GetById(id);

            if (contactToDelete == null)
            {
                return this.NotFound();
            }

            this.contacts.DeleteById(id);
            return this.Ok();
        }
    }
}