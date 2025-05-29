using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentDemo.Service.Interfaces
{
    public interface IEntityService<TEntity>
    {
        TEntity Create(TEntity entity);
        IEnumerable<TEntity> GetAll();
        TEntity? Get(int id);
        bool Delete(int id);
        TEntity? Update(int id, TEntity entity);
    }
}
