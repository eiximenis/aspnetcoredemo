using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Domain
{
    public interface IUnitOfWork
    {
        int SaveChanges();
    }
}
