using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ResultObject;
public record struct RegisterResult(
    string Fullname,
    string Email,
    string Phone,
    string Token
);
