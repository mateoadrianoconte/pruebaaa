using ProduccionBack.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProduccionBack.Services
{
    public interface IComponenteService
    {
        bool Create(Componente oComponente);
        List<Componente> GetAll();
        Componente? GetById(int id);
        bool Update(Componente oComponente);
        bool Delete(int id, string ? motivo);
    }
}
