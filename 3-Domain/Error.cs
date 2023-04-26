using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Domain;


public enum ErrorReason{
    AlreadyExist,
    CreateFile,
    SaveEntity   
}

public class Error : Exception
{
    public ErrorReason Reason { get; set; }
    public string Message { get; set; }
}
