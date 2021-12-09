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
using api.conevento.Models.Events;
using api.conevento.Models.User;
using System.Text;

namespace api.conevento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly IUserRepository _userRepository;
        private readonly IEventosRepository _eventoRepository;

        public EventosController(
             IMapper mapper,
             ILoggerManager logger,
             IUserRepository userRepository
            ,IEventosRepository eventoRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _userRepository = userRepository;
            _eventoRepository = eventoRepository;
        }

        [HttpPost("AddEvent", Name = "AddEvent")]
        public async Task<ActionResult<ApiResponse<Evento>>> AddEvent(EventoDto _evento)
        {
            var response = new ApiResponse<Evento>();

            try
            {
                var Sevento = _eventoRepository.Add(_mapper.Map<Evento>(_evento));
                StreamReader reader = new StreamReader(Path.GetFullPath("TemplateMail/Email.html"));
                string pathimg = _userRepository.GetConfiguration("path_imagenes");
                string body = string.Empty;
                body = reader.ReadToEnd();
                body = body.Replace("{user}", _evento.NombreContratane);
                body = body.Replace("{username}", $"{_evento.Correo}");
                body = body.Replace("{path_imagenes}", pathimg);
                body = body.Replace("{pass}", _evento.FechaHoraInicio.ToString());

                 _userRepository.SendMail(_evento.Correo, body, "Bienvenido a Conevento");

                response.Result = Sevento;
                response.Success = true;
                response.Message = "Evento creado con exíto";

            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Success = false;
                response.Message = "Internal server error";
                _logger.LogError($"Something went wrong: { ex.ToString() }");
                return StatusCode(500, response);
            }

            return Ok(response);
        }

        [HttpPost("GetEventsbyuser", Name = "GetEventsbyuser")]
        public ActionResult GetEventsbyuser(int id_user)
        {
            try
            {
                IQueryable<Evento> _eventos = null;
                _eventos = _eventoRepository.FindBy(x => x.IdUsuario == id_user);
                return StatusCode(202, new
                {
                    Success = true,
                    Result = _eventos,
                    Message = ""
                });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: { ex.ToString() }");
                return StatusCode(500, new { Success = false, Result = 0, Message = $"Internal server error {ex.Message}" });
            }
        }
    }
}
