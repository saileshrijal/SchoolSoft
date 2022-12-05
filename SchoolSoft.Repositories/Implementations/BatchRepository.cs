﻿using SchoolSoft.Data;
using SchoolSoft.Models;
using SchoolSoft.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSoft.Repositories.Implementations
{
    public class BatchRepository:GenericRepository<Batch>, IBatchRepository
    {
        public BatchRepository(ApplicationDbContext options):base(options)
        {
            
        }
    }
}
