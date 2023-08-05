using Front_End.Models;
using Newtonsoft.Json;

namespace Front_End.Helpers
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
            HttpResponseMessage responseMessage = repository.GetResponse("api/seguro/");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<SeguroViewModel>>(content);

            }

            return lista;
        }
        #endregion


        #region GetByID
        public SeguroViewModel GetByID(int id)
        {
            SeguroViewModel carroModelo = new SeguroViewModel();

            HttpResponseMessage responseMessage = repository.GetResponse("api/seguro/" + id);
            string content = responseMessage.Content.ReadAsStringAsync().Result;
            carroModelo = JsonConvert.DeserializeObject<SeguroViewModel>(content);

            return carroModelo;

        }

        #endregion


        #region Update
        public SeguroViewModel Edit(SeguroViewModel seguro)
        {

            HttpResponseMessage responseMessage = repository.PutResponse("api/seguro/", seguro);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            SeguroViewModel seguroAPI = JsonConvert.DeserializeObject<SeguroViewModel>(content);
            return seguroAPI;

        }


        #endregion


        #region Create
        public SeguroViewModel Add(SeguroViewModel category)
        {

            HttpResponseMessage responseMessage = repository.PostResponse("api/carroModelo/", category);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            SeguroViewModel seguroAPI = JsonConvert.DeserializeObject<SeguroViewModel>(content);
            return seguroAPI;

        }


        #endregion


        #region GetByID

        public SeguroViewModel Delete(int id)
        {
            SeguroViewModel seguro  = new SeguroViewModel();

            HttpResponseMessage responseMessage = repository.DeleteResponse("api/seguro/" + id);
            // string content = responseMessage.Content.ReadAsStringAsync().Result;
            // category = JsonConvert.DeserializeObject<CategoryViewModel>(content);

            return seguro;

        }



        #endregion

    }
}
