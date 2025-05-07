using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDeAnMRSTW.Application.Abstractions.Email
{
    public interface IEmailService
    {
        Task SendAsync(string name,string subject, string body);
    }
}
