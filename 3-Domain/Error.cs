using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Domain;


public enum ErrorReason{
    AlreadyExist,
    FailDatabase,
    CreateFile,
    SaveEntity   
}

public class Error : Exception
{
    public ErrorReason Reason { get; set; }
    public string Message { get; set; }

    
    public Error(ErrorReason reason, string message)
    {
        Reason = reason;
        Message = message;
    }

    public Error(string message)
        : base(message)
    {
    }

    public Error(string message, Exception inner)
        : base(message, inner)
    {
    }
}
