using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class UsuarioHelper
    {
        ServiceRepository repository;

        public UsuarioHelper()
        {
            repository = new ServiceRepository();
        }

        #region  GetALL
        public List<UsuarioViewModel> GetAll()
        {
            List<UsuarioViewModel> lista = new List<UsuarioViewModel>();
            HttpResponseMessage responseMessage = repository.GetResponse("api/Usuario/");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<UsuarioViewModel>>(content);
            }
            return lista;
        }
        #endregion

        #region GetByID
        public UsuarioViewModel GetByID(int id)
        {
            UsuarioViewModel entidad = new UsuarioViewModel();
            HttpResponseMessage responseMessage = repository.GetResponse("api/Usuario/" + id);
            string content = responseMessage.Content.ReadAsStringAsync().Result;
            entidad = JsonConvert.DeserializeObject<UsuarioViewModel>(content);
            return entidad;
        }
        #endregion

        #region Update
        public UsuarioViewModel Edit(UsuarioViewModel entidad)
        {
            HttpResponseMessage responseMessage = repository.PutResponse("api/Usuario/", entidad);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            UsuarioViewModel entidadAPI = JsonConvert.DeserializeObject<UsuarioViewModel>(content);
            return entidadAPI;
        }
        #endregion

        #region Create
        public UsuarioViewModel Add(UsuarioViewModel entidad)
        {
            HttpResponseMessage responseMessage = repository.PostResponse("api/Usuario/", entidad);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            UsuarioViewModel entidadAPI = JsonConvert.DeserializeObject<UsuarioViewModel>(content);
            return entidadAPI;
        }
        #endregion

        #region GetByID
        public UsuarioViewModel Delete(int id)
        {
            UsuarioViewModel entidad = new UsuarioViewModel();
            HttpResponseMessage responseMessage = repository.DeleteResponse("api/Usuario/" + id);
            return entidad;
        }
        #endregion
    }
}