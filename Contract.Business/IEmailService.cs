using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace Contract.Business
{
    public interface IEmailService 
    {
        Task sendEmailAsync(DTOEnvioNotificacion mailRequest);
    }
}
