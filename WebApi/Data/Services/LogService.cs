using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data.Models;

namespace WebApi.Data.Services
{
    public class LogService
    {
        private readonly ApplicationDbContext _db;

        public LogService(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<Log> GetAllLogs() => _db.Logs.ToList();
    }
}
