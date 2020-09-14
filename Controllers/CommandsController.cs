using System.Collections.Generic;
using Commander.Data;
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

        public CommandsController(ICommanderRepo repository)
        {
            //repository is passed here from startup service.AddScoped
            _repository = repository;
        }
        
        //private readonly MockCommanderRepo _repository = new MockCommanderRepo();
        [HttpGet]
        public ActionResult <IEnumerable<Command>> GetAllCommands(){
            var commandItems = _repository.GetAppCommands();
            return Ok(commandItems);
        }

        //api/commands/{id}
        [HttpGet("{id}")]
        public ActionResult <Command> GetCommandById(int id){
            var commandItem = _repository.GetCommandById(id);
            return Ok(commandItem);
        
        }
    }
}