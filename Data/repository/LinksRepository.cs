using Data.Models;
using Data.repositoryInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.repository
{
    public class LinksRepository : GenericRepository<Link>, ILinksRepository
    {
        public LinksRepository(ESTUDIOS_NOM35Context context)
            : base(context)
        { }
    }
}
