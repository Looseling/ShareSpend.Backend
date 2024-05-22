using ShareSpend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareSpend.Application.IRepository
{
    public interface IContainerRepository
    {
        //Cruds
        Task AddContainer(Container receiptContainer);

        Task<Container> GetContainer(string containerId);

        Task UpdateContainer(Container receiptContainer);

        Task DeleteContainer(string containerId);

        //Queries
        Task<bool> IsContainerExists(string containerId);
    }
}