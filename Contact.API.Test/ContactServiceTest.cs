using AutoMapper;
using Contact.Api.Service.Automapper;
using Contact.Api.Service.Interfaces;
using Contact.Api.Service.Services;
using Contact.API.Data.Repository.Interfaces;
using Contact.API.Domain.Dto;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Contact.API.Test
{
    public class ContactServiceTest
    {
        private Mock<IContactRepository> _contactRepositoryMoq;
        private Mock<IDetailRepository> _detailRepositoryMoq;
        private Mock<IReportHttpService> _reportHttpServiceMoq;
        private IMapper _mapper;
        private IContactService _contactService;

        public ContactServiceTest()
        {
            var mapperMoq = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            _mapper = mapperMoq.CreateMapper();

            _contactRepositoryMoq = new Mock<IContactRepository>();
            _detailRepositoryMoq = new Mock<IDetailRepository>();
            _reportHttpServiceMoq = new Mock<IReportHttpService>();
            _contactService = new ContactService(_contactRepositoryMoq.Object, _detailRepositoryMoq.Object, _mapper, _reportHttpServiceMoq.Object);
        }

        [Fact]
        public void ContactService_AddContact_ShouldReturnCreatedContact()
        {
            ContactDto contact = new ContactDto
            {
                Name = "name1",
                Surname = "surname1",
                Company = "company1"
            };

            _contactRepositoryMoq.Setup(x => x.AddAsync(It.IsAny<Domain.Entities.Contact>())).Returns(Task.FromResult(new Domain.Entities.Contact { Name = "name1" }));

            var added = _contactService.AddContact(contact);

            Assert.IsType<Domain.Entities.Contact>(added.Result);
            Assert.Contains("name1", added.Result.Name);
        }
    }
}