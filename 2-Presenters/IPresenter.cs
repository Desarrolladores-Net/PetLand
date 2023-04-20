using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presenters
{
    public interface IPresenter<FormatDataType>
    {
        FormatDataType Content { get;}
    }
}