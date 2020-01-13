using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using MusicShop.DomainModel.Context;
using MusicShop.DomainModel.Models;
using MusicShop.Repository.Admin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using FizzWare.NBuilder;
using System.Linq;
using MusicShop.Repository.Data;
using MusicShop.Core.Controllers;

namespace MusicShop.Test.Admin
{
    public class AdminRepositoryTests
    {
        private AdminController _adminController;
        private IAdminRepository _adminRepo;
        private Mock<IDataRepository> _dataRepositoryMock = new Mock<IDataRepository>();

        public AdminRepositoryTests()
        {
            _adminRepo = new AdminRepository(_dataRepositoryMock.Object);
            _adminController = new AdminController(_adminRepo);
        }

        

        [Fact]
        public void AddAsync_TestOfAdding()
        {
            
            InstrumentModel instr = new InstrumentModel();
            instr.Id = "1";
            instr.Model = "Yamaha psr i455";
            instr.Price = 20000;
            instr.Type = "keyboard";

            //var instrumentDbSetMock = Builder<InstrumentModel>.CreateListOfSize(1).Build().ToAsyncDbSetMock();
            _dataRepositoryMock.Setup(x => x.AddAsync((instr)));
            Assert.NotNull(_adminController.Add(instr));
        }


        [Fact]
        public void AddAsync_NullCheck()
        {
            InstrumentModel instr = new InstrumentModel();
            _dataRepositoryMock.Setup(x => x.AddAsync((instr)));
            Assert.ThrowsAsync<ArgumentException>(() => _adminRepo.AddAsync(instr));
        }

        [Fact]
        public void AddAsync_InstrumentTypeLength()
        {
            InstrumentModel instr = new InstrumentModel();
            instr.Id = "1";
            instr.Model = "Yamaha psr i455";
            instr.Type = "keyboard";

            _dataRepositoryMock.Setup(x => x.AddAsync((instr)));
            Assert.ThrowsAsync<ArgumentException>(() => _adminRepo.AddAsync(instr));
        }

        [Fact]
        public void GetAll_Test()
        {
            _dataRepositoryMock.Setup(x => x.GetAll());
            Assert.Null(_adminRepo.GetAll());
        }










    }
}
