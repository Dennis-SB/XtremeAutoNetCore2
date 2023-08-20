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

        /// <summary>
        /// Obtener Categoria por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public RuedumViewModel GetByID(int id)
        {
            RuedumViewModel ruedum = new RuedumViewModel();

            HttpResponseMessage responseMessage = repository.GetResponse("api/Ruedum/" + id);
            string content = responseMessage.Content.ReadAsStringAsync().Result;
            ruedum = JsonConvert.DeserializeObject<RuedumViewModel>(content);

            return ruedum;

        }



        #endregion


        #region Update
        public RuedumViewModel Edit(RuedumViewModel ruedum)
        {

            HttpResponseMessage responseMessage = repository.PutResponse("api/Ruedum/", ruedum);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            RuedumViewModel ruedumAPI = JsonConvert.DeserializeObject<RuedumViewModel>(content);
            return ruedumAPI;

        }


        #endregion


        #region Create
        public RuedumViewModel Add(RuedumViewModel ruedum)
        {

            HttpResponseMessage responseMessage = repository.PostResponse("api/Ruedum/", ruedum);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            RuedumViewModel ruedumAPI = JsonConvert.DeserializeObject<RuedumViewModel>(content);
            return ruedumAPI;

        }


        #endregion


        #region GetByID

        /// <summary>
        /// Obtener Categoria por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public RuedumViewModel Delete(int id)
        {
            RuedumViewModel ruedum = new RuedumViewModel();

            HttpResponseMessage responseMessage = repository.DeleteResponse("api/Ruedum/" + id);
            // string content = responseMessage.Content.ReadAsStringAsync().Result;
            // category = JsonConvert.DeserializeObject<CategoryViewModel>(content);

            return ruedum;

        }



        #endregion

    }
}