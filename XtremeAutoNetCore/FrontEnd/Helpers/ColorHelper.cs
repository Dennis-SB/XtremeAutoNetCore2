﻿using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class ColorHelper
    {
        ServiceRepository repository;

        public ColorHelper()
        {
            repository = new ServiceRepository();
        }

        #region  GetALL
        public List<ColorViewModel> GetAll()
        {
            List<ColorViewModel> lista = new List<ColorViewModel>();
            HttpResponseMessage responseMessage = repository.GetResponse("api/Color/");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<ColorViewModel>>(content);
            }
            return lista;
        }
        #endregion
        
        #region GetByID
        public ColorViewModel GetByID(int id)
        {
            ColorViewModel entidad = new ColorViewModel();
            HttpResponseMessage responseMessage = repository.GetResponse("api/Color/" + id);
            string content = responseMessage.Content.ReadAsStringAsync().Result;
            entidad = JsonConvert.DeserializeObject<ColorViewModel>(content);
            return entidad;
        }
        #endregion
        
        #region Update
        public ColorViewModel Edit(ColorViewModel entidad)
        {
            HttpResponseMessage responseMessage = repository.PutResponse("api/Color/", entidad);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            ColorViewModel entidadAPI = JsonConvert.DeserializeObject<ColorViewModel>(content);
            return entidadAPI;
        }
        #endregion
        
        #region Create
        public ColorViewModel Add(ColorViewModel entidad)
        {
            HttpResponseMessage responseMessage = repository.PostResponse("api/Color/", entidad);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            ColorViewModel entidadAPI = JsonConvert.DeserializeObject<ColorViewModel>(content);
            return entidadAPI;
        }
        #endregion

        #region GetByID
        public ColorViewModel Delete(int id)
        {
            ColorViewModel entidad = new ColorViewModel();
            HttpResponseMessage responseMessage = repository.DeleteResponse("api/Color/" + id);
            return entidad;
        }
        #endregion
    }
}