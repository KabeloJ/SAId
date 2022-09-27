using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Email.Application
{
    public static class SmtpSettings
    {
        public static string Address { get; set; }
        public static string Password { get; set; }
        public static int Port { get; set; }
        public static string Host { get; set; }
        public static bool SSL { get; set; }
    }
}
