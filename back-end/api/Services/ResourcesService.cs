using System;
using System.Collections.Generic;
using System.Linq;
using api.Data;
using api.Handlers;
using api.Models;

namespace api.Services
{
    public class ResourcesService
    {
        private readonly DataContext _context;

        public ResourcesService(DataContext context)
        {
            this._context = context;
        }

        public List<ResourceList> GetResources()
        {
            try
            {
                List<ResourceList> response = new List<ResourceList>();

                var resources = _context.Resources.ToList();

                foreach(var x in resources)
                {
                    response.Add(new ResourceList{
                      //  Nome = x.Name,
                        Descricao = x.Description,
                 //       Quantidade = x.Quantity,
                        Observacao = x.Observation,
                        InseridoPor = _context.Users.FirstOrDefault(y => y.Id == x.CreationUserId)?.Name,
                        DataInsercao = x.CreationDate.ToString("dd/MM/yyyy HH:mm:ss")
                    });
                }

                return response;
            }
            catch (System.Exception e)
            {
                var errorMessage = e.InnerException;
                throw;
            }
        }

        public void InsertResource(ResourceAdd data, int userId)
        {
            try
            {
                Resource res = new Resource
                {
                    ResourceTypeId = data.ResourceTypeId,
                    Description = data.Description,
                    Status = data.Status,
                    MinQuantity = data.MinQuantity,
                    MaxQuantity = data.MaxQuantity,
                    Observation = data.Observation,
                    CreationUserId = userId,
                    CreationDate = DateTime.Now
                };

                _context.Resources.Add(res);
                _context.SaveChanges();
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        public void InsertResourceEntry(ResourceMovimentation data, int userId)
        {
            try
            {
                ResourceEntry resEntry = new ResourceEntry
                {
                    ResourceId = data.ResourceId,
                    Quantity = data.Quantity,
                    CreationUserId = userId,
                    CreationDate = DateTime.Now
                };

                _context.ResourceEntries.Add(resEntry);
                _context.SaveChanges();
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        public void InsertResourceDeparture(ResourceMovimentation data, int userId)
        {
            try
            {
                ResourceDeparture resDeparture = new ResourceDeparture
                {
                    ResourceId = data.ResourceId,
                    Quantity = data.Quantity,
                    CreationUserId = userId,
                    DepartureDate = DateTime.Now
                };

                _context.ResourceDepartures.Add(resDeparture);
                _context.SaveChanges();
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
}