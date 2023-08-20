using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class RolHelper
    {
        ServiceRepository repository;

        public RolHelper()
        {
            repository = new ServiceRepository();
        }

        #region  GetALL
        public List<RolViewModel> GetAll()
        {
            List<RolViewModel> lista = new List<RolViewModel>();
            HttpResponseMessage responseMessage = repository.GetResponse("api/Rol/");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<RolViewModel>>(content);
            }
            return lista;
        }
        #endregion

        #region GetByID
        public RolViewModel GetByID(int id)
        {
            RolViewModel entidad = new RolViewModel();
            HttpResponseMessage responseMessage = repository.GetResponse("api/Rol/" + id);
            string content = responseMessage.Content.ReadAsStringAsync().Result;
            entidad = JsonConvert.DeserializeObject<RolViewModel>(content);
            return entidad;
        }
        #endregion

        #region Update
        public RolViewModel Edit(RolViewModel entidad)
        {
            HttpResponseMessage responseMessage = repository.PutResponse("api/Rol/", entidad);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            RolViewModel entidadAPI = JsonConvert.DeserializeObject<RolViewModel>(content);
            return entidadAPI;
        }
        #endregion

        #region Create
        public RolViewModel Add(RolViewModel entidad)
        {
            HttpResponseMessage responseMessage = repository.PostResponse("api/Rol/", entidad);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            RolViewModel entidadAPI = JsonConvert.DeserializeObject<RolViewModel>(content);
            return entidadAPI;
        }
        #endregion

        #region GetByID
        public RolViewModel Delete(int id)
        {
            RolViewModel entidad = new RolViewModel();
            HttpResponseMessage responseMessage = repository.DeleteResponse("api/Rol/" + id);
            return entidad;
        }
        #endregion
    }
}