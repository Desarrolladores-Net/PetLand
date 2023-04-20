using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Domain;


public enum ErrorReason{
    AlreadyExist   
}

public record class Error(ErrorReason Reason, string Message);
