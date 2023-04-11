using TestCorp.Domain.Data;
using TestCorp.Domain.Models;
using TestCorp.Services.Interfaces;

namespace TestCorp.Services
{
    public class Logger : ILog
    {
        private readonly Test4CreateDbContext db;

        public Logger(Test4CreateDbContext context)
        {
            db = context;
        }

        public async Task<bool> Log(SystemLog entry)
        {
            try
            {
                await db.SystemLog.AddAsync(entry);
                await db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
