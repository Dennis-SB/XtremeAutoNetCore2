using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class VentumHelper
    {
        ServiceRepository repository;

        public VentumHelper()
        {
            repository = new ServiceRepository();
        }

        #region  GetALL
        public List<VentumViewModel> GetAll()
        {
            List<VentumViewModel> lista = new List<VentumViewModel>();
            HttpResponseMessage responseMessage = repository.GetResponse("api/Ventum/");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<VentumViewModel>>(content);
            }
            return lista;
        }
        #endregion

        #region GetByID
        public VentumViewModel GetByID(int id)
        {
            VentumViewModel entidad = new VentumViewModel();
            HttpResponseMessage responseMessage = repository.GetResponse("api/Ventum/" + id);
            string content = responseMessage.Content.ReadAsStringAsync().Result;
            entidad = JsonConvert.DeserializeObject<VentumViewModel>(content);
            return entidad;
        }
        #endregion

        #region Update
        public VentumViewModel Edit(VentumViewModel entidad)
        {
            HttpResponseMessage responseMessage = repository.PutResponse("api/Ventum/", entidad);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            VentumViewModel entidadAPI = JsonConvert.DeserializeObject<VentumViewModel>(content);
            return entidadAPI;
        }
        #endregion

        #region Create
        public VentumViewModel Add(VentumViewModel entidad)
        {
            HttpResponseMessage responseMessage = repository.PostResponse("api/Ventum/", entidad);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            VentumViewModel entidadAPI = JsonConvert.DeserializeObject<VentumViewModel>(content);
            return entidadAPI;
        }
        #endregion

        #region GetByID
        public VentumViewModel Delete(int id)
        {
            VentumViewModel entidad = new VentumViewModel();
            HttpResponseMessage responseMessage = repository.DeleteResponse("api/Ventum/" + id);
            return entidad;
        }
        #endregion
    }
}