using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaPlus.Core.Framework
{
    /// <summary>
    /// Use it to define class is a repository
    /// </summary>
    public interface IRepository
    {
        IUnitOfWork unitOfWork { get; }
    }
}
