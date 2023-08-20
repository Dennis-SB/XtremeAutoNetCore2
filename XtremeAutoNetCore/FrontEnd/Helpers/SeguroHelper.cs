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
        public SeguroViewModel GetByID(int id)
        {
            SeguroViewModel entidad = new SeguroViewModel();
            HttpResponseMessage responseMessage = repository.GetResponse("api/Seguro/" + id);
            string content = responseMessage.Content.ReadAsStringAsync().Result;
            entidad = JsonConvert.DeserializeObject<SeguroViewModel>(content);
            return entidad;
        }
        #endregion
        
        #region Update
        public SeguroViewModel Edit(SeguroViewModel entidad)
        {
            HttpResponseMessage responseMessage = repository.PutResponse("api/Seguro/", entidad);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            SeguroViewModel entidadAPI = JsonConvert.DeserializeObject<SeguroViewModel>(content);
            return entidadAPI;
        }
        #endregion
        
        #region Create
        public SeguroViewModel Add(SeguroViewModel entidad)
        {
            HttpResponseMessage responseMessage = repository.PostResponse("api/Seguro/", entidad);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            SeguroViewModel entidadAPI = JsonConvert.DeserializeObject<SeguroViewModel>(content);
            return entidadAPI;
        }
        #endregion
        
        #region GetByID
        public SeguroViewModel Delete(int id)
        {
            SeguroViewModel entidad = new SeguroViewModel();
            HttpResponseMessage responseMessage = repository.DeleteResponse("api/Seguro/" + id);
            return entidad;
        }
        #endregion
    }
}