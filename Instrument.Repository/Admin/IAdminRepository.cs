using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Instrument.DomainModel.Models;

namespace Instrument.Repository.Admin
{
    public interface IAdminRepository
    {
        Task<InstrumentModel> AddAsync(InstrumentModel instrument);
        List<InstrumentModel> GetAll();
    }
}
