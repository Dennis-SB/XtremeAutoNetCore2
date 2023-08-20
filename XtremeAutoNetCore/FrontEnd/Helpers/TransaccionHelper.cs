using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class TransaccionHelper
    {
        ServiceRepository repository;

        public TransaccionHelper()
        {
            repository = new ServiceRepository();
        }

        #region  GetALL
        public List<TransaccionViewModel> GetAll()
        {
            List<TransaccionViewModel> lista = new List<TransaccionViewModel>();
            HttpResponseMessage responseMessage = repository.GetResponse("api/Ventum/");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<TransaccionViewModel>>(content);
            }
            return lista;
        }
        #endregion

        #region GetByID
        public TransaccionViewModel GetByID(int id)
        {
            TransaccionViewModel entidad = new TransaccionViewModel();
            HttpResponseMessage responseMessage = repository.GetResponse("api/Ventum/" + id);
            string content = responseMessage.Content.ReadAsStringAsync().Result;
            entidad = JsonConvert.DeserializeObject<TransaccionViewModel>(content);
            return entidad;
        }
        #endregion

        #region Update
        public TransaccionViewModel Edit(TransaccionViewModel entidad)
        {
            HttpResponseMessage responseMessage = repository.PutResponse("api/Ventum/", entidad);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            TransaccionViewModel entidadAPI = JsonConvert.DeserializeObject<TransaccionViewModel>(content);
            return entidadAPI;
        }
        #endregion

        #region Create
        public TransaccionViewModel Add(TransaccionViewModel entidad)
        {
            HttpResponseMessage responseMessage = repository.PostResponse("api/Ventum/", entidad);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            TransaccionViewModel entidadAPI = JsonConvert.DeserializeObject<TransaccionViewModel>(content);
            return entidadAPI;
        }
        #endregion

        #region GetByID
        public TransaccionViewModel Delete(int id)
        {
            TransaccionViewModel entidad = new TransaccionViewModel();
            HttpResponseMessage responseMessage = repository.DeleteResponse("api/Ventum/" + id);
            return entidad;
        }
        #endregion
    }
}