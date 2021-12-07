using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using api.conevento.ActionFilter;
using api.conevento.Models;
using biz.conevento.Entities;
using biz.conevento.Repository;
using biz.conevento.Servicies;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using api.conevento.Models.User;
using System.Text;

namespace api.conevento.Controllers
{
    public class CatalogController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly IUserRepository _userRepository;

        public CatalogController(
             IMapper mapper,
             ILoggerManager logger,
             IUserRepository userRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _userRepository = userRepository;



        }
    

    }
}
