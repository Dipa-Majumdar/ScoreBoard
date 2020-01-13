using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Instrument.DomainModel.Context;
using Instrument.DomainModel.Models;
using Microsoft.EntityFrameworkCore;

namespace Instrument.Repository.Admin
{
    public class AdminRepository : IAdminRepository
    {
        private InstrumentDbContext _context;

        public AdminRepository(InstrumentDbContext context)
        {
            _context = context;
        }

        public async Task<InstrumentModel> AddAsync(InstrumentModel instrument)
        {
            await _context.AddAsync(instrument);
            return instrument;
        }


        public List<InstrumentModel> GetAll()
        {
            return _context.Instruments.ToList();
        }

    }
}
