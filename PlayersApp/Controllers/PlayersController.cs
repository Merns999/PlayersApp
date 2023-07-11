using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using PlayersApp.Data;
using PlayersApp.Data.EFCore;
using PlayersApp.Models.Domain;

namespace PlayersApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : MyPlayersController<Player, EfCorePlayerRepository>
    {

        public PlayersController(EfCorePlayerRepository repository):base(repository) { }
        
    }
}
