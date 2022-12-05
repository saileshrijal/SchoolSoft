using SchoolSoft.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSoft.Services.Interfaces
{
    public interface IBatchService
    {
        public Task CreateBatch(BatchViewModel vm);
        public Task UpdateBatch(BatchViewModel vm);
        Task<List<BatchViewModel>> GetAllBatches();
        Task<BatchViewModel> GetBatch(int id);
        public Task DeleteBatch(int id);
    }
}
