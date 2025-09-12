using Data.Models;
using Data.repositoryInterface;
using System;
using System.Collections.Generic;
using System.Text;


namespace Data.repository
{
    public class ActividadesRepository : GenericRepository<Actividade>, IActividadesRepository
    {
          public ActividadesRepository(ESTUDIOS_NOM35Context context)
          : base(context)
    { }
}
}
