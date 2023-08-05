using Front_End.Models;
using Newtonsoft.Json;

namespace Front_End.Helpers
{
    public class RuedaHelper
    {
        ServiceRepository repository;

        public RuedaHelper()
        {
            repository = new ServiceRepository();
        }

        #region  GetALL

        public List<RuedaViewModel> GetAll()
        {



            List<RuedaViewModel> lista = new List<RuedaViewModel>();
            HttpResponseMessage responseMessage = repository.GetResponse("api/Rueda/");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<RuedaViewModel>>(content);

            }

            return lista;
        }
        #endregion


        #region GetByID
        public RuedaViewModel GetByID(int id)
        {
            RuedaViewModel rueda = new RuedaViewModel();

            HttpResponseMessage responseMessage = repository.GetResponse("api/Rueda/" + id);
            string content = responseMessage.Content.ReadAsStringAsync().Result;
            rueda = JsonConvert.DeserializeObject<RuedaViewModel>(content);

            return rueda;

        }



        #endregion


        #region Update
        public RuedaViewModel Edit(RuedaViewModel rueda)
        {

            HttpResponseMessage responseMessage = repository.PutResponse("api/rueda/", rueda);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            RuedaViewModel ruedaAPI = JsonConvert.DeserializeObject<RuedaViewModel>(content);
            return ruedaAPI;

        }


        #endregion


        #region Create
        public RuedaViewModel Add(RuedaViewModel rueda)
        {

            HttpResponseMessage responseMessage = repository.PostResponse("api/rueda/", rueda);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            RuedaViewModel ruedaAPI = JsonConvert.DeserializeObject<RuedaViewModel>(content);
            return ruedaAPI;

        }


        #endregion


        #region GetByID
        public RuedaViewModel Delete(int id)
        {
            RuedaViewModel rueda = new RuedaViewModel();

            HttpResponseMessage responseMessage = repository.DeleteResponse("api/rueda/" + id);
            // string content = responseMessage.Content.ReadAsStringAsync().Result;
            // category = JsonConvert.DeserializeObject<CategoryViewModel>(content);

            return rueda;
        }
        #endregion

    }
}