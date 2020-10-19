using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    //[Route("api/[controller]")] this will make the route depends on class name, api/Commands in this case.
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepo repository, IMapper mapper)
        {
            //repository is passed here from startup service.AddScoped
            _repository = repository;
            _mapper = mapper;
        }
        
        //private readonly MockCommanderRepo _repository = new MockCommanderRepo();
        [HttpGet]
        public ActionResult <IEnumerable<CommandReadDto>> GetAllCommands(){
            var commandItems = _repository.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }

        //api/commands/{id}
        [HttpGet("{id}", Name="GetCommandById")]
        public ActionResult <CommandReadDto> GetCommandById(int id){
            var commandItem = _repository.GetCommandById(id);
            if(commandItem != null)
                return Ok(_mapper.Map<CommandReadDto>(commandItem));
            else
                return NotFound();
        
        }

        //POST api/commands/
        [HttpPost()]
        public ActionResult <CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto){
            var commandModel = _mapper.Map<Command>(commandCreateDto);
            _repository.CreateCommand(commandModel);
            _repository.saveChanges();

            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);
            return CreatedAtRoute(nameof(GetCommandById), new {Id = commandReadDto.Id}, commandReadDto);
        }
    }
}