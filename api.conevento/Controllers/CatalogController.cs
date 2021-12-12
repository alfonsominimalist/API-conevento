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
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly IUserRepository _userRepository;
        private readonly ICat_categoria_productosRepository _cat_CategoriaREpository;
        private readonly Icat_productos_serviciosRepository _productos;

        public CatalogController(
             IMapper mapper,
             ILoggerManager logger,
             IUserRepository userRepository
           , ICat_categoria_productosRepository cat_CategoriaREpository
           , Icat_productos_serviciosRepository cat_Productos_Servicios)
        {
            _mapper = mapper;
            _logger = logger;
            _userRepository = userRepository;
            _cat_CategoriaREpository = cat_CategoriaREpository;
            _productos = cat_Productos_Servicios;
        }
        


        [HttpGet("Cat_Categorias", Name = "Cat_Categorias")]
        public ActionResult Cat_Categorias(int id_categoria)
        {
            try
            {
                IQueryable<CatCategoriaProducto> categorias = null;

                if (id_categoria != 0)
                {
                    categorias = _cat_CategoriaREpository.FindBy(x => x.Id == id_categoria);
                }
                else
                {
                    categorias = _cat_CategoriaREpository.GetAll();
                }

                if (categorias.Count() > 0)
                {
                    string pathimg = _userRepository.GetConfiguration("path_imagenes");
                    foreach (CatCategoriaProducto element in categorias)
                    {
                        element.Imagen = pathimg + element.Imagen;
                        element.ImagenSeleccion = pathimg + element.ImagenSeleccion;
                    }
                }

                return StatusCode(202, new
                {
                    Success = true,
                    Result = categorias,
                    Message = ""
                });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: { ex.ToString() }");
                return StatusCode(500, new { Success = false, Result = 0, Message = $"Internal server error {ex.Message}" });
            }
        }

        [HttpGet("productos_by_Cat", Name = "productos_by_Cat")]
        public ActionResult productos_by_Cat(int id_categoria)
        {
            try
            {
                //var categorias = _cat_CategoriaREpository.GetAll();
                IQueryable<CatProductosServicio> res_productos = null;
                if ( id_categoria != 0)
                {
                     res_productos = _productos.FindBy(x => x.IdCategoriaProducto == id_categoria && x.Activo == true);
                }
                else
                {
                     res_productos = _productos.GetAll();
                }
                
                if(res_productos.Count() > 0 )
                {
                    string pathimg = _userRepository.GetConfiguration("path_imagenes");
                    foreach (CatProductosServicio element in res_productos)
                    {
                        element.ImagenSeleccion = pathimg + element.ImagenSeleccion;
                    }
                }
               
                return StatusCode(202, new
                {
                    Success = true,
                    Result = res_productos,
                    Message = ""
                });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: { ex.ToString() }");
                return StatusCode(500, new { Success = false, Result = 0, Message = $"Internal server error {ex.Message}" });
            }
        }

        [HttpGet("productos_by_id", Name = "productos_by_id")]
        public ActionResult productos_by_id(int id)
        {
            try
            {
                //var categorias = _cat_CategoriaREpository.GetAll();
                IQueryable<CatProductosServicio> res_productos = null;
                if (id != 0)
                {
                    res_productos = _productos.FindBy(x => x.Id == id);
                }
                else
                {
                    res_productos = _productos.GetAll();
                }

                if (res_productos.Count() > 0)
                {
                    string pathimg = _userRepository.GetConfiguration("path_imagenes");
                    foreach (CatProductosServicio element in res_productos)
                    {
                        element.ImagenSeleccion = pathimg + element.ImagenSeleccion;
                    }
                }

                return StatusCode(202, new
                {
                    Success = true,
                    Result = res_productos,
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



