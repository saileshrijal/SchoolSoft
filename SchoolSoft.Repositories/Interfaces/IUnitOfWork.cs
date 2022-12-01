﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSoft.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IFacultyRepository Faculty { get; }

        Task SaveAsync();
    }
}