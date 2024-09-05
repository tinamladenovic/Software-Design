using AutoMapper;
using Explorer.BuildingBlocks.Core.Domain;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Internal;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Stakeholders.Core.Domain.RepositoryInterfaces;
using FluentResults;

namespace Explorer.Stakeholders.Core.UseCases
{
    public class PersonService : CrudService<UpdatePersonDTO,Person> , IPersonService, IInternalPersonService
    {

        protected readonly ICrudRepository<Person> CrudRepository;
        private readonly IUserRepository UserRepository;
        public PersonService(ICrudRepository<Person> repository,IUserRepository userRepository, IMapper mapper) : base(repository, mapper) 
        {
            CrudRepository = repository;
            UserRepository = userRepository;
        }
        
        public Result<UpdatePersonDTO> GetByUserId(int id)
        {
            long personId = UserRepository.GetPersonId(id);

            var result = Get(Convert.ToInt32(personId)) ;
            return result;

        }

        public Result<UpdatePersonDTO> UpdatePerson(UpdatePersonDTO updatePerson, int personId)
        {

            if (updatePerson.Id != personId)
            {
                return Result.Fail(FailureCode.Forbidden);
            }
            var result = Update(updatePerson);
            return result;
        }

        public Result<string> GetName(long personId)
        {
            var person = CrudRepository.Get(personId);
            return person.Name;
        }

        public Result<string> GetPersonEmail(long personId)
        {
            var person = CrudRepository.Get(personId);
            return person.Email;
        }

        public Result<string> GetSurname(long personId)
        {
            var person = CrudRepository.Get(personId);
            return person.Surname;
        }

        public Result<StakeholdersCoordinateDto> GetPersonLocation(long personId)
        {
            var person = CrudRepository.Get(personId);
            if (person == null)
                return new StakeholdersCoordinateDto(45.2396M, 19.8227M);

            return new StakeholdersCoordinateDto(person.Latitude, person.Longitude);
        }

    }
        
}
