using Api.Models;
using System.Threading;
using Infrastructure.Mapping;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Application.Queries.Report;
using Infrastructure.CQRS.Queries;
using Infrastructure.CQRS.Commands;
using Application.Commands.AddPerson;
using Application.Queries.SearchPerson;
using Application.Queries.GetPersonById;
using Application.Commands.DeletePerson;
using Application.Commands.UpdatePerson;
using Application.Commands.UploadPicture;
using Application.Commands.AddRelatedPerson;
using Infrastructure.CommonTypes.Abstractions;
using Application.Commands.DeleteRelatedPerson;

namespace Api.Controllers
{
    public class PersonController : BaseController
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;

        public PersonController(ICommandBus commandBus, IQueryBus queryBus)
        {
            _queryBus = queryBus;
            _commandBus = commandBus;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddPerson(AddPersonRequest request, CancellationToken cancellationToken)
        {
            var command = Mapping.Map<AddPersonRequest, AddPersonCommand>(request);
            var result = await _commandBus.Send(command, cancellationToken);

            return ReturnResponse(result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdatePerson(UpdatePersonRequest request, CancellationToken cancellationToken)
        {
            var command = Mapping.Map<UpdatePersonRequest, UpdatePersonCommand>(request);
            var result = await _commandBus.Send(command, cancellationToken);

            return ReturnResponse(result);
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> DeletePerson(DeletePersonRequest request, CancellationToken cancellationToken)
        {
            var command = Mapping.Map<DeletePersonRequest, DeletePersonCommand>(request);
            var result = await _commandBus.Send(command, cancellationToken);

            return ReturnResponse(result);
        }

        [HttpPost("AddRelatedPerson")]
        public async Task<IActionResult> AddRelatedPerson(AddRelatedPersonRequest request, CancellationToken cancellationToken)
        {
            var command = Mapping.Map<AddRelatedPersonRequest, AddRelatedPersonCommand>(request);
            var result = await _commandBus.Send(command, cancellationToken);

            return ReturnResponse(result);
        }

        [HttpPost("DeleteRelatedPerson")]
        public async Task<IActionResult> DeleteRelatedPerson(DeleteRelatedPersonRequest request, CancellationToken cancellationToken)
        {
            var command = Mapping.Map<DeleteRelatedPersonRequest, DeleteRelatedPersonCommand>(request);
            var result = await _commandBus.Send(command, cancellationToken);

            return ReturnResponse(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetPersonById(GetPersonByIdRequst request, CancellationToken cancellationToken)
        {
            var query = Mapping.Map<GetPersonByIdRequst, GetPersonByIdQuery>(request);
            var result = await _queryBus.Send(query, cancellationToken);

            return ReturnResponse(result);
        }

        [HttpGet("Search")]
        public async Task<IActionResult> SearchPerson(SearchPersonRequest request, CancellationToken cancellationToken)
        {
            var query = Mapping.Map<SearchPersonRequest, SearchPersonQuery>(request);
            var result = await _queryBus.Send(query, cancellationToken);

            return ReturnResponse(result);
        }

        [HttpGet("Report")]
        public async Task<IActionResult> PersonReport(CancellationToken cancellationToken)
        {
            var result = await _queryBus.Send(new ReportQuery(), cancellationToken);

            return ReturnResponse(result);
        }

        [HttpPost("UploadOrUpdatePicture")]
        public async Task<IActionResult> UploadOrUpdatePicture(IFormFile file, int personId)
        {
            var result = await _commandBus.Send(new UploadOrUpdatePictureCommand { File = file, PersonId = personId });

            return ReturnResponse(result);
        }
    }
}