﻿using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class CarroModeloHelper
    {
        ServiceRepository repository;

        public CarroModeloHelper()
        {
            repository = new ServiceRepository();
        }

        #region  GetALL
        public List<CarroModeloViewModel> GetAll()
        {
            List<CarroModeloViewModel> lista = new List<CarroModeloViewModel>();
            HttpResponseMessage responseMessage = repository.GetResponse("api/CarroModelo/");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<CarroModeloViewModel>>(content);
            }
            return lista;
        }
        #endregion

        #region GetByID
        public CarroModeloViewModel GetByID(int id)
        {
            CarroModeloViewModel entidad = new CarroModeloViewModel();
            HttpResponseMessage responseMessage = repository.GetResponse("api/CarroModelo/" + id);
            string content = responseMessage.Content.ReadAsStringAsync().Result;
            entidad = JsonConvert.DeserializeObject<CarroModeloViewModel>(content);
            return entidad;
        }
        #endregion
        
        #region Update
        public CarroModeloViewModel Edit(CarroModeloViewModel entidad)
        {
            HttpResponseMessage responseMessage = repository.PutResponse("api/CarroModelo/", entidad);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            CarroModeloViewModel entidadAPI = JsonConvert.DeserializeObject<CarroModeloViewModel>(content);
            return entidadAPI;
        }
        #endregion
        
        #region Create
        public CarroModeloViewModel Add(CarroModeloViewModel entidad)
        {
            HttpResponseMessage responseMessage = repository.PostResponse("api/CarroModelo/", entidad);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            CarroModeloViewModel entidadAPI = JsonConvert.DeserializeObject<CarroModeloViewModel>(content);
            return entidadAPI;
        }
        #endregion
        
        #region GetByID
        public CarroModeloViewModel Delete(int id)
        {
            CarroModeloViewModel entidad = new CarroModeloViewModel();
            HttpResponseMessage responseMessage = repository.DeleteResponse("api/CarroModelo/" + id);
            return entidad;
        }
        #endregion
    }
}