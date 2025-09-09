using ProduccionBack.Data;
using ProduccionBack.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProduccionBack.Services
{
    public class ComponenteService : IComponenteService
    {
        private IComponenteRepository _repository;

        public ComponenteService(IComponenteRepository repository)
        {
            _repository = repository;
        }

        public bool Create(Componente oComponente)
        {
            return _repository.Create(oComponente);
        }

        public bool Delete(int id, string ? motivo)
        {
            return _repository.Delete(id, motivo);
        }

        public List<Componente> GetAll()
        {
            return _repository.GetAll();
        }

        public Componente? GetById(int id)
        {
            return _repository.GetById(id);
        }

        public bool Update(Componente oComponente)
        {
            return _repository.Update(oComponente);
        }
    }
}
