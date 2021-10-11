using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moq;
using MovieApp.Core.DTOs.TicketDtos;
using MovieApp.Core.Entities;
using MovieApp.Core.Interfaces;
using MovieApp.Core.Services;
using MovieApp.Database;
using MovieApp.Mapper;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieApp.Tests
{
    [TestFixture]
    public class ScreeningStartTimeNUnitTests
    {
        private Mock<ITicketRepository> ticketRepository;
        private Mock<IScreeningRepository> screeningRepository;
        private Mock<IAuthRepository> authRepository;
        private IMapper mapper;  
        private Mock<IMediaRepository> mediaRepository;
        private TicketService ticketService;

        [SetUp]
        public void SetUp()
        {
            ticketRepository = new Mock<ITicketRepository>();
            screeningRepository = new Mock<IScreeningRepository>();
            authRepository = new Mock<IAuthRepository>();
            mediaRepository = new Mock<IMediaRepository>();

            ticketService = new TicketService(ticketRepository.Object, screeningRepository.Object,
                 mapper, authRepository.Object, mediaRepository.Object);

            var mappingConfig = new MapperConfiguration(x =>
            {
                x.AddProfile(new AutoMapperProfiles());
            });
            mapper = mappingConfig.CreateMapper();
        }

        [Test]
        public void ScreeningDate_MediaDoesNotExists_ThrowException()
        {
            screeningRepository.Setup(x => x.GetScreening(It.IsAny<int>()))
                  .Returns(Task.FromResult<Screening>(new Screening { }));
            mediaRepository.Setup(x => x.MediaExists(It.IsAny<int>())).Returns(Task.FromResult(false));
            authRepository.Setup(x => x.GetUserByUsernameAsync(It.IsAny<string>())).Returns(Task.FromResult<AppUser>(new AppUser { }));
            Ticket ticket = new Ticket
            {
                Id = 1,
                ScreeningId = 1,
                MediaId = 0
            };
            ticketRepository.Setup(x => x.AddTicket(ticket)).Returns(Task.FromResult<Ticket>(null));

            TicketDto ticketDto = new TicketDto
            {
                MediaId = 0,
                ScreeningId = 1
            };
            

            var ex = Assert.ThrowsAsync<ArgumentException>(() => ticketService.BuyTicket(ticketDto, "selma"));
            Assert.That(ex.Message, Is.EqualTo("Movie id is not valid."));
        }

        [Test]
        public void ScreeningDate_UserDoesNotExist_ThrowException()
        {
            screeningRepository.Setup(x => x.GetScreening(It.IsAny<int>()))
                  .Returns(Task.FromResult<Screening>(null));
            mediaRepository.Setup(x => x.MediaExists(It.IsAny<int>())).Returns(Task.FromResult(true));
            authRepository.Setup(x => x.GetUserByUsernameAsync(It.IsAny<string>())).Returns(Task.FromResult<AppUser>(new AppUser { }));
            Ticket ticket = new Ticket
            {
                Id = 1,
                ScreeningId = 1,
                MediaId = 0
            };
            ticketRepository.Setup(x => x.AddTicket(ticket)).Returns(Task.FromResult<Ticket>(null));

            TicketDto ticketDto = new TicketDto
            {
                MediaId = 0,
                ScreeningId = 1
            };


            var ex = Assert.ThrowsAsync<ArgumentException>(() => ticketService.BuyTicket(ticketDto, "selma"));
            Assert.That(ex.Message, Is.EqualTo("Screening id is not valid."));
        }
    }
}