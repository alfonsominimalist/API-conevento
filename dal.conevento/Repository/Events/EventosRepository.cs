using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using biz.conevento.Entities;
using biz.conevento.Models.Email;
using biz.conevento.Repository;
using biz.conevento.Servicies;
using dal.conevento.DBContext;
using Microsoft.Extensions.Configuration;

namespace dal.conevento.Repository
{
    public class EventosRepository : GenericRepository<Evento>, IEventosRepository
    {

        public EventosRepository(Db_ConeventoContext context) : base(context)
        {

        }

    }
}
