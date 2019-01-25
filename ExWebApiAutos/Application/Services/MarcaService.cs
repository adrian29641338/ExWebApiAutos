using Application.DTOs;
using Application.IServices;
using ExWebApiAutos.Model;
using ExWebApiAutos.Model.ExWebApiAutos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class MarcaService : IMarcaService
    {
        IMarcaRepository repository;
        public MarcaService(IMarcaRepository repo)
        {
            repository = repo;
        }
        public void Delete(Guid entityId)
        {
            repository.DeleteProyecto(entityId);
        }
        public IList<MarcaDTO> GetAll()
        {
            return Builders.GenericBuilder.builderListEntityDTO<MarcaDTO, TMarca>(repository.Marcas);
        }
        public void Insert(MarcaDTO entityDTO)
        {
            var entity = Builders.GenericBuilder.builderDTOEntity<TMarca, MarcaDTO>(entityDTO);
            repository.SaveProject(entity);
        }
        public void Update(MarcaDTO entityDTO)
        {
            var entity = Builders.GenericBuilder.builderDTOEntity<TMarca, MarcaDTO>(entityDTO);
            repository.SaveProject(entity);
        }
    }
}
