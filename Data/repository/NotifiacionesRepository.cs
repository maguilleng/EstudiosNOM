using Data.Models;
using Data.repositoryInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.repository
{
    public class NotifiacionesRepository : GenericRepository<CuerpoNotificacione>, INotificacionesRepository
    {
        public NotifiacionesRepository(ESTUDIOS_NOM35Context context)
           : base(context)
        { }
    }
}
