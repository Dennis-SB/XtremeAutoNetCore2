using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class CarroVendidoHelper
    {
        ServiceRepository repository;

        public CarroVendidoHelper()
        {
            repository = new ServiceRepository();
        }

        #region  GetALL
        public List<CarroVendidoViewModel> GetAll()
        {
            List<CarroVendidoViewModel> lista = new List<CarroVendidoViewModel>();
            HttpResponseMessage responseMessage = repository.GetResponse("api/CarroVendido/");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<CarroVendidoViewModel>>(content);
            }
            return lista;
        }
        #endregion

        #region GetByID
        public CarroVendidoViewModel GetByID(int id)
        {
            CarroVendidoViewModel entidad = new CarroVendidoViewModel();
            HttpResponseMessage responseMessage = repository.GetResponse("api/CarroVendido/" + id);
            string content = responseMessage.Content.ReadAsStringAsync().Result;
            entidad = JsonConvert.DeserializeObject<CarroVendidoViewModel>(content);
            return entidad;
        }
        #endregion

        #region Update
        public CarroVendidoViewModel Edit(CarroVendidoViewModel entidad)
        {
            HttpResponseMessage responseMessage = repository.PutResponse("api/CarroVendido/", entidad);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            CarroVendidoViewModel entidadAPI = JsonConvert.DeserializeObject<CarroVendidoViewModel>(content);
            return entidadAPI;
        }
        #endregion

        #region Create
        public CarroVendidoViewModel Add(CarroVendidoViewModel entidad)
        {
            HttpResponseMessage responseMessage = repository.PostResponse("api/CarroVendido/", entidad);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            CarroVendidoViewModel entidadAPI = JsonConvert.DeserializeObject<CarroVendidoViewModel>(content);
            return entidadAPI;
        }
        #endregion

        #region GetByID
        public CarroVendidoViewModel Delete(int id)
        {
            CarroVendidoViewModel entidad = new CarroVendidoViewModel();
            HttpResponseMessage responseMessage = repository.DeleteResponse("api/CarroVendido/" + id);
            return entidad;
        }
        #endregion
    }
}