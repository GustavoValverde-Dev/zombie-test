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
                List<ResourceType> resType = _context.ResourceTypes.ToList();
                List<Resource> resources = _context.Resources.ToList();

                foreach(var x in resources)
                {
                    response.Add(new ResourceList{
                        ResourceTypeName = _context.ResourceTypes.FirstOrDefault(s => s.Id == x.ResourceTypeId).Description,
                        Description = x.Description,
                        Status = x.Status,
                        MinQuantity = x.MinQuantity,
                        MaxQuantity = x.MaxQuantity,
                        Quantity = _context.ResourceStocks.FirstOrDefault(s => s.ResourceId == x.Id)?.Quantity ?? 0,
                        Observation = x.Observation,
                        CreatedBy = _context.Users.FirstOrDefault(y => y.Id == x.CreationUserId).Name,
                        CreationDate = x.CreationDate
                    });
                }

                return response.OrderBy(x => x.Status).ThenBy(x => x.Description).ToList();
            }
            catch (System.Exception e)
            {
                var errorMessage = e.InnerException;
                throw;
            }
        }

        public List<ResourceMovimentationList> GetResourceEntries()
        {
            try
            {
                List<ResourceMovimentationList> response = new List<ResourceMovimentationList>();
                List<ResourceEntry> resEntries = _context.ResourceEntries.ToList();
                List<Resource> resources = _context.Resources.ToList();

                foreach(var x in resEntries)
                {
                    response.Add(new ResourceMovimentationList{
                        Resource = resources.FirstOrDefault(s => s.Id == x.ResourceId).Description,
                        Quantity = x.Quantity,
                        User = _context.Users.FirstOrDefault(y => y.Id == x.CreationUserId).Name,
                        Date = x.CreationDate
                    });
                }

                return response.OrderBy(x => x.Date).ToList();
            }
            catch (System.Exception e)
            {
                var errorMessage = e.InnerException;
                throw;
            }
        }

        public List<ResourceMovimentationList> GetResourceDepartures()
        {
            try
            {
                List<ResourceMovimentationList> response = new List<ResourceMovimentationList>();
                List<ResourceDeparture> resDepartures = _context.ResourceDepartures.ToList();
                List<Resource> resources = _context.Resources.ToList();

                foreach(var x in resDepartures)
                {
                    response.Add(new ResourceMovimentationList{
                        Resource = resources.FirstOrDefault(s => s.Id == x.ResourceId).Description,
                        Quantity = x.Quantity,
                        User = _context.Users.FirstOrDefault(y => y.Id == x.CreationUserId).Name,
                        Date = x.DepartureDate
                    });
                }

                return response.OrderBy(x => x.Date).ToList();
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

        public bool ResourceDepartureCheck(ResourceMovimentation data)
        {
            try
            {
                Resource res = _context.Resources.FirstOrDefault(x => x.Id == data.ResourceId);
                ResourceStock stock = _context.ResourceStocks.FirstOrDefault(x => x.ResourceId == data.ResourceId);
                int newQuantityValue = stock.Quantity - data.Quantity;
                if (newQuantityValue < res.MinQuantity)
                {
                    return false;
                }
                else if (newQuantityValue == res.MinQuantity)
                {
                    res.Status = false;
                    _context.Resources.Update(res);
                    _context.SaveChanges();

                    return true;
                }
                else
                {
                    return true;
                }
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        public bool ResourceEntryCheck(ResourceMovimentation data)
        {
            try
            {
                Resource res = _context.Resources.FirstOrDefault(x => x.Id == data.ResourceId);
                ResourceStock stock = _context.ResourceStocks.FirstOrDefault(x => x.ResourceId == data.ResourceId);

                if (stock != null)
                {
                    int newQuantityValue = stock.Quantity + data.Quantity;

                    if (stock.Quantity == res.MinQuantity)
                    {
                        res.Status = true;
                        _context.Resources.Update(res);
                        _context.SaveChanges();
                    }

                    if (newQuantityValue > res.MaxQuantity)
                    {
                        return false;
                    }                    
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    res.Status = true;
                    _context.Resources.Update(res);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
}