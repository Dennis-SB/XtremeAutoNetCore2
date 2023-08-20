﻿using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class RuedumHelper
    {
        ServiceRepository repository;

        public RuedumHelper()
        {
            repository = new ServiceRepository();
        }

        #region  GetALL
        public List<RuedumViewModel> GetAll()
        {
            List<RuedumViewModel> lista = new List<RuedumViewModel>();
            HttpResponseMessage responseMessage = repository.GetResponse("api/Ruedum/");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<RuedumViewModel>>(content);
            }
            return lista;
        }
        #endregion
        
        #region GetByID
        public RuedumViewModel GetByID(int id)
        {
            RuedumViewModel entidad = new RuedumViewModel();
            HttpResponseMessage responseMessage = repository.GetResponse("api/Ruedum/" + id);
            string content = responseMessage.Content.ReadAsStringAsync().Result;
            entidad = JsonConvert.DeserializeObject<RuedumViewModel>(content);
            return entidad;
        }
        #endregion
        
        #region Update
        public RuedumViewModel Edit(RuedumViewModel entidad)
        {
            HttpResponseMessage responseMessage = repository.PutResponse("api/Ruedum/", entidad);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            RuedumViewModel entidadAPI = JsonConvert.DeserializeObject<RuedumViewModel>(content);
            return entidadAPI;
        }
        #endregion
        
        #region Create
        public RuedumViewModel Add(RuedumViewModel entidad)
        {
            HttpResponseMessage responseMessage = repository.PostResponse("api/Ruedum/", entidad);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            RuedumViewModel entidadAPI = JsonConvert.DeserializeObject<RuedumViewModel>(content);
            return entidadAPI;
        }
        #endregion
        
        #region GetByID
        public RuedumViewModel Delete(int id)
        {
            RuedumViewModel entidad = new RuedumViewModel();
            HttpResponseMessage responseMessage = repository.DeleteResponse("api/Ruedum/" + id);
            return entidad;
        }
        #endregion
    }
}