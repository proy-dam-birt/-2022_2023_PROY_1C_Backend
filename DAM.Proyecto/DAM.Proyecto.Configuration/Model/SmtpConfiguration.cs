using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.Configuration.Model
{
    public class SmtpConfiguration
    {
        public string Hostname { get; init; }
        public int Port { get; init; }
        public string From { get; init; }
        public string To { get; init; }


        // TODO levantar los datos de un fichero (xml, json,...)
        // Ver Usar con Docker

        public SmtpConfiguration()
        {
            Hostname = "GetHostname";
            Port = Int16.Parse("GetPortnumber");
            From = "GetAddressSender";
            To = string.Empty;
        }
    }
}
