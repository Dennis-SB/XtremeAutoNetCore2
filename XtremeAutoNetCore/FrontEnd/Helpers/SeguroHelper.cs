using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class SeguroHelper
    {
        ServiceRepository repository;

        public SeguroHelper()
        {
            repository = new ServiceRepository();
        }

        #region  GetALL

        public List<SeguroViewModel> GetAll()
        {



            List<SeguroViewModel> lista = new List<SeguroViewModel>();
            HttpResponseMessage responseMessage = repository.GetResponse("api/Seguro/");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<SeguroViewModel>>(content);

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
        public SeguroViewModel GetByID(int id)
        {
            SeguroViewModel seguro = new SeguroViewModel();

            HttpResponseMessage responseMessage = repository.GetResponse("api/Seguro/" + id);
            string content = responseMessage.Content.ReadAsStringAsync().Result;
            seguro = JsonConvert.DeserializeObject<SeguroViewModel>(content);

            return seguro;

        }



        #endregion


        #region Update
        public SeguroViewModel Edit(SeguroViewModel seguro)
        {

            HttpResponseMessage responseMessage = repository.PutResponse("api/Seguro/", seguro);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            SeguroViewModel seguroAPI = JsonConvert.DeserializeObject<SeguroViewModel>(content);
            return seguroAPI;

        }


        #endregion


        #region Create
        public SeguroViewModel Add(SeguroViewModel seguro)
        {

            HttpResponseMessage responseMessage = repository.PostResponse("api/Seguro/", seguro);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            SeguroViewModel seguroAPI = JsonConvert.DeserializeObject<SeguroViewModel>(content);
            return seguroAPI;

        }


        #endregion


        #region GetByID

        /// <summary>
        /// Obtener Categoria por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SeguroViewModel Delete(int id)
        {
            SeguroViewModel seguro = new SeguroViewModel();

            HttpResponseMessage responseMessage = repository.DeleteResponse("api/Seguro/" + id);
            // string content = responseMessage.Content.ReadAsStringAsync().Result;
            // category = JsonConvert.DeserializeObject<CategoryViewModel>(content);

            return seguro;

        }



        #endregion

    }
}