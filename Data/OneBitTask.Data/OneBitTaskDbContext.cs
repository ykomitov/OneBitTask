namespace OneBitTask.Data
{
    using System.Data.Entity;
    using Models;

    public class OneBitTaskDbContext : DbContext, IOneBitTaskDbContext
    {
        public OneBitTaskDbContext()
            : base("OneBitTask")
        {
        }

        public IDbSet<Contact> Contacts { get; set; }

        public static OneBitTaskDbContext Create()
        {
            return new OneBitTaskDbContext();
        }
    }
}
