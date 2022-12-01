using SchoolSoft.Data;
using SchoolSoft.Models;
using SchoolSoft.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSoft.Repositories.Implementations
{
    public class FacultyRepository : GenericRepository<Faculty>, IFacultyRepository
    {
        public FacultyRepository(ApplicationDbContext options):base(options)
        {

        }
    }
}
