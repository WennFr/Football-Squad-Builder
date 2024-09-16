using Infrastructure.Contexts;
using Infrastructure.Handlers.Services;
using Infrastructure.Handlers.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Handlers.Repositories;
using Infrastructure.Models.TransfermarktAPI.DTOs;


namespace Infrastructure.Tests.Handlers.Services
{
    public class CompetitionServiceTests
    {
        TransfermarktDataContext _transfermarktDataContextTest;
        CompetitionRepository _competitionRepository;
        ITransfermarktAPIService _transfermarktAPIService;
        ICompetitionService _sut;

        public CompetitionServiceTests()
        {
            _transfermarktDataContextTest = GetContext();
            _competitionRepository = new CompetitionRepository(_transfermarktDataContextTest);
            _transfermarktAPIService = new TransfermarktAPIService();
            _sut = new CompetitionService(_competitionRepository, _transfermarktAPIService);
        }

        private TransfermarktDataContext GetContext()
        {
            var options = new DbContextOptionsBuilder<TransfermarktDataContext>()
                .UseSqlServer("Server=localhost;Database=TransfermarktDatabase_Test;Trusted_Connection=True;TrustServerCertificate=true;MultipleActiveResultSets=true")
                .Options;

            return new TransfermarktDataContext(options);
        }


        [Fact]
       private async void GetCompetitionsFromTransfermarktAPI_Should_Not_Return_Null()
        {
            //ACT
            IEnumerable<CompetitionDTO> result = await _sut.GetCompetitionsFromTransfermarktAPI();

            //Assert
            Assert.NotNull(result);

        }




    }
}
