using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class TarjetumHelper
    {
        ServiceRepository repository;

        public TarjetumHelper()
        {
            repository = new ServiceRepository();
        }

        #region  GetALL

        public List<TarjetumViewModel> GetAll()
        {



            List<TarjetumViewModel> lista = new List<TarjetumViewModel>();
            HttpResponseMessage responseMessage = repository.GetResponse("api/Tarjetum/");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<TarjetumViewModel>>(content);

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
        public TarjetumViewModel GetByID(int id)
        {
            TarjetumViewModel tarjetum = new TarjetumViewModel();

            HttpResponseMessage responseMessage = repository.GetResponse("api/Tarjetum/" + id);
            string content = responseMessage.Content.ReadAsStringAsync().Result;
            tarjetum = JsonConvert.DeserializeObject<TarjetumViewModel>(content);

            return tarjetum;

        }



        #endregion


        #region Update
        public TarjetumViewModel Edit(TarjetumViewModel tarjetum)
        {

            HttpResponseMessage responseMessage = repository.PutResponse("api/Tarjetum/", tarjetum);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            TarjetumViewModel tarjetumAPI = JsonConvert.DeserializeObject<TarjetumViewModel>(content);
            return tarjetumAPI;

        }


        #endregion


        #region Create
        public TarjetumViewModel Add(TarjetumViewModel tarjetum)
        {

            HttpResponseMessage responseMessage = repository.PostResponse("api/Tarjetum/", tarjetum);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            TarjetumViewModel tarjetumAPI = JsonConvert.DeserializeObject<TarjetumViewModel>(content);
            return tarjetumAPI;

        }


        #endregion


        #region GetByID

        /// <summary>
        /// Obtener Categoria por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TarjetumViewModel Delete(int id)
        {
            TarjetumViewModel tarjetum = new TarjetumViewModel();

            HttpResponseMessage responseMessage = repository.DeleteResponse("api/Tarjetum/" + id);
            // string content = responseMessage.Content.ReadAsStringAsync().Result;
            // category = JsonConvert.DeserializeObject<CategoryViewModel>(content);

            return tarjetum;

        }



        #endregion

    }
}