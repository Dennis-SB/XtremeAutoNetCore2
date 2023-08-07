using Front_End.Models;
using Newtonsoft.Json;

namespace Front_End.Helpers
{
    public class TarjetaHelper
    {
        ServiceRepository repository;

        public TarjetaHelper()
        {
            repository = new ServiceRepository();
        }

        #region  GetALL

        public List<TarjetaViewModel> GetAll()
        {



            List<TarjetaViewModel> lista = new List<TarjetaViewModel>();
            HttpResponseMessage responseMessage = repository.GetResponse("/api/Tarjeta/");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<TarjetaViewModel>>(content);

            }

            return lista;
        }
        #endregion


        #region GetByID
        public TarjetaViewModel GetByID(int TarjetaId)
        {
            TarjetaViewModel tarjeta = new TarjetaViewModel();

            HttpResponseMessage responseMessage = repository.GetResponse("/api/Tarjeta/" + TarjetaId);
            string content = responseMessage.Content.ReadAsStringAsync().Result;
            tarjeta = JsonConvert.DeserializeObject<TarjetaViewModel>(content);

            return tarjeta;

        }



        #endregion


        #region Update
        public TarjetaViewModel Edit(TarjetaViewModel tarjeta)
        {

            HttpResponseMessage responseMessage = repository.PutResponse("/api/Tarjeta/", tarjeta);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            TarjetaViewModel tarjetaAPI = JsonConvert.DeserializeObject<TarjetaViewModel>(content);
            return tarjetaAPI;

        }


        #endregion


        #region Create
        public TarjetaViewModel Add(TarjetaViewModel tarjeta)
        {

            HttpResponseMessage responseMessage = repository.PostResponse("/api/Tarjeta/", tarjeta);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            TarjetaViewModel tarjetaAPI = JsonConvert.DeserializeObject<TarjetaViewModel>(content);
            return tarjetaAPI;

        }


        #endregion


        #region GetByID
        public TarjetaViewModel Delete(int TarjetaId)
        {
            TarjetaViewModel tarjeta = new TarjetaViewModel();

            HttpResponseMessage responseMessage = repository.DeleteResponse("/api/Tarjeta/" + TarjetaId);
            // string content = responseMessage.Content.ReadAsStringAsync().Result;
            // category = JsonConvert.DeserializeObject<CategoryViewModel>(content);

            return tarjeta;
        }
        #endregion

    }
}
