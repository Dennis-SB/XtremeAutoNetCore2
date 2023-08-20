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

        /// <summary>
        /// Obtener Categoria por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ColorViewModel GetByID(int id)
        {
            ColorViewModel color = new ColorViewModel();

            HttpResponseMessage responseMessage = repository.GetResponse("api/Color/" + id);
            string content = responseMessage.Content.ReadAsStringAsync().Result;
            color = JsonConvert.DeserializeObject<ColorViewModel>(content);

            return color;

        }



        #endregion


        #region Update
        public ColorViewModel Edit(ColorViewModel color)
        {

            HttpResponseMessage responseMessage = repository.PutResponse("api/Color/", color);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            ColorViewModel colorAPI = JsonConvert.DeserializeObject<ColorViewModel>(content);
            return colorAPI;

        }


        #endregion


        #region Create
        public ColorViewModel Add(ColorViewModel color)
        {

            HttpResponseMessage responseMessage = repository.PostResponse("api/Color/", color);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            ColorViewModel colorAPI = JsonConvert.DeserializeObject<ColorViewModel>(content);
            return colorAPI;

        }


        #endregion


        #region GetByID

        /// <summary>
        /// Obtener Categoria por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ColorViewModel Delete(int id)
        {
            ColorViewModel color = new ColorViewModel();

            HttpResponseMessage responseMessage = repository.DeleteResponse("api/Color/" + id);
            // string content = responseMessage.Content.ReadAsStringAsync().Result;
            // category = JsonConvert.DeserializeObject<CategoryViewModel>(content);

            return color;

        }



        #endregion

    }
}