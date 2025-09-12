using Contract.Business;
using Data.repositoryInterface;
using Data.Models;
using DTO;
using Data;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.ComponentModel;
using System.Data;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using AutoMapper.Configuration;

namespace Business
{
    public class MailService : IEmailService
    {

        private ESTUDIOS_NOM35Context contexto;
        private readonly EmailSettings _mailSettings;
        public MailService(ESTUDIOS_NOM35Context context, IOptions<EmailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
            contexto = context;
        }

        public CuerpoNotificacione getPlantillaByIdFlujo()
        {
            var plantilla = (from e in contexto.CuerpoNotificaciones select e).FirstOrDefault();

            return plantilla;
        }

        public async Task sendEmailAsync(DTOEnvioNotificacion datosCorreos)
        {

            string plantillaHTML = "";
            plantillaHTML = getPlantillaByIdFlujo().Plantilla;
            //"PARA" EN USO NO PERSONAL
            if (datosCorreos.TipoNotificacion != "UsoPersonal")
            {
                int contador = 1;
                var email = new MimeMessage();
                email.Sender = MailboxAddress.Parse("requisiciones_test@outlook.com"/*_mailSettings.UserName*/);
                char delimitador = ';';
                //CC
                if(!string.IsNullOrEmpty(datosCorreos.Cc)){ 
                    string[] correosCC = datosCorreos.Cc.Split(delimitador);
                    for (int i = 0; i < correosCC.Count(); i++)
                    {
                        email.Cc.Add(MailboxAddress.Parse(correosCC[i]));
                    }
                }
                
                //ASUNTO
                email.Subject = datosCorreos.Asunto;
                //CUERPO
                var builder = new BodyBuilder();
                //builder.HtmlBody = datosCorreos.MensajeInicial;

                if (!string.IsNullOrEmpty(datosCorreos.Para))
                {
                    string[] correosPara = datosCorreos.Para.Split(delimitador);
                    for (int i = 0; i < correosPara.Count(); i++)
                    {
                        //PARA
                        email.To.Add(MailboxAddress.Parse(correosPara[i]));
                    }
                }                

                //LINKS
                foreach (var datosLInks in datosCorreos.Links)
                {
                    //builder.HtmlBody += datosLInks.Enlace;
                    builder.HtmlBody += "<tr><td><a href=" + datosLInks.Enlace + "> Enlace " + contador + "</a></td><td>" + datosLInks.Vigencia + "</td></tr>";
                    contador++;
                }
                //builder.HtmlBody += datosCorreos.MensajeFinal;
                plantillaHTML = plantillaHTML.Replace("@@FOOTER", datosCorreos.MensajeFinal);
                plantillaHTML = plantillaHTML.Replace("@@MENSAJE_BIENVENIDA", datosCorreos.MensajeInicial);
                plantillaHTML = plantillaHTML.Replace("@@TITULO_ENCABEZADO", datosCorreos.Asunto);
                plantillaHTML = plantillaHTML.Replace("@@TBODY_ENLACES", builder.HtmlBody);
                builder.HtmlBody = plantillaHTML;
                email.Body = builder.ToMessageBody();

                using var smtp = new SmtpClient();
                smtp.Connect("smtp.office365.com"/*_mailSettings.MailServer*/, 587/* _mailSettings.MailPort*/, SecureSocketOptions.StartTls);
                smtp.Authenticate("requisiciones_test@outlook.com"/*_mailSettings.UserName*/, "Adl2021#"/* _mailSettings.Password*/);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);
            }

            else
            {
                //CORREOS PARA USO PERSONAL
                foreach (var datosLInks in datosCorreos.Links)
                {
                    var email = new MimeMessage();
                    email.Sender = MailboxAddress.Parse("requisiciones_test@outlook.com"/*_mailSettings.UserName*/);
                    char delimitador = ';';
                    //CC
                    if (!string.IsNullOrEmpty(datosCorreos.Cc))
                    {
                        string[] correosCC = datosCorreos.Cc.Split(delimitador);
                        for (int i = 0; i < correosCC.Count(); i++)
                        {
                            email.Cc.Add(MailboxAddress.Parse(correosCC[i]));
                        }
                    }
                        
                    //ASUNTO
                    email.Subject = datosCorreos.Asunto;
                    //CUERPO
                    var builder = new BodyBuilder();
                    //PARA
                    email.To.Add(MailboxAddress.Parse(datosLInks.Correo));
                    //builder.HtmlBody = "<br>" + datosCorreos.MensajeInicial + "</br>";
                    //builder.HtmlBody += "<br><b>" + datosLInks.Enlace + "</b><br>";
                    builder.HtmlBody += "<tr><td><a href=" + datosLInks.Enlace + "> Vaya al cuestionario dando click aqui</a></td><td>" + datosLInks.Vigencia + "</td></tr>";
                    //builder.HtmlBody += "<br>" + datosCorreos.MensajeFinal + "<br>";


                    plantillaHTML = plantillaHTML.Replace("@@FOOTER", datosCorreos.MensajeFinal);
                    plantillaHTML = plantillaHTML.Replace("@@MENSAJE_BIENVENIDA", datosCorreos.MensajeInicial);
                    plantillaHTML = plantillaHTML.Replace("@@TITULO_ENCABEZADO", datosCorreos.Asunto);
                    plantillaHTML = plantillaHTML.Replace("@@TBODY_ENLACES", builder.HtmlBody);
                    builder.HtmlBody = plantillaHTML;

                    email.Body = builder.ToMessageBody();
                    using var smtp = new SmtpClient();
                    smtp.Connect("smtp.office365.com"/*_mailSettings.MailServer*/, 587/*_mailSettings.MailPort*/, SecureSocketOptions.StartTls);
                    smtp.Authenticate("requisiciones_test@outlook.com", "Adl2021#"/*_mailSettings.Password*/);
                    await smtp.SendAsync(email);
                    smtp.Disconnect(true);
                }
            }

            //if (mailRequest.Attachments != null)
            //{
            //    byte[] fileBytes;
            //    foreach (var file in mailRequest.Attachments)
            //    {
            //        if (file.Length > 0)
            //        {
            //            using (var ms = new MemoryStream())
            //            {
            //                file.CopyTo(ms);
            //                fileBytes = ms.ToArray();
            //            }
            //            builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
            //        }
            //    }
            //}
        }
    }
}
