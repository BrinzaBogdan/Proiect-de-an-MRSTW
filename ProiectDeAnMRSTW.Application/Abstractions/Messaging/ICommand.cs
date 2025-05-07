using MediatR;
using ProiectDeAnMRSTW.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDeAnMRSTW.Application.Abstractions.Messaging
{
    public interface ICommand : IRequest<Result>, IBaseCommand
    {
    }

    public interface ICommand<TReponse> : IRequest<Result<TReponse>>, IBaseCommand
    {
    }

    public interface IBaseCommand
    {
    }

}




/*
 Caracteristică	                                ICommand	                                            ICommand<TResponse>
Returnează un rezultat?	                    Result (doar succes/eșec)	                            Result<TResponse> (conține și date)
Folosit pentru?	                        Operații fără output (ex: ștergere, actualizare)	        Operații cu output (ex: creare, returnare date)
Ex:                                             Comandă	DeleteUserCommand	                                    CreateUserCommand<UserDto>
 
 
 
 
 
 */