using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Domain;


public enum ErrorReason{
    AlreadyExist,
    FailDatabase   
}

public class Error : Exception
{
    public ErrorReason Reason { get; set; }
    public string Message { get; set; }

    public Error()
    {
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
