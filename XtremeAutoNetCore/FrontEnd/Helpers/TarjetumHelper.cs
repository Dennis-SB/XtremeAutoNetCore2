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
        public TarjetumViewModel GetByID(int id)
        {
            TarjetumViewModel entidad = new TarjetumViewModel();
            HttpResponseMessage responseMessage = repository.GetResponse("api/Tarjetum/" + id);
            string content = responseMessage.Content.ReadAsStringAsync().Result;
            entidad = JsonConvert.DeserializeObject<TarjetumViewModel>(content);
            return entidad;
        }
        #endregion
        
        #region Update
        public TarjetumViewModel Edit(TarjetumViewModel entidad)
        {
            HttpResponseMessage responseMessage = repository.PutResponse("api/Tarjetum/", entidad);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            TarjetumViewModel entidadAPI = JsonConvert.DeserializeObject<TarjetumViewModel>(content);
            return entidadAPI;
        }
        #endregion
        
        #region Create
        public TarjetumViewModel Add(TarjetumViewModel entidad)
        {
            HttpResponseMessage responseMessage = repository.PostResponse("api/Tarjetum/", entidad);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            TarjetumViewModel entidadAPI = JsonConvert.DeserializeObject<TarjetumViewModel>(content);
            return entidadAPI;
        }
        #endregion
        
        #region GetByID
        public TarjetumViewModel Delete(int id)
        {
            TarjetumViewModel entidad = new TarjetumViewModel();
            HttpResponseMessage responseMessage = repository.DeleteResponse("api/Tarjetum/" + id);
            return entidad;
        }
        #endregion
    }
}