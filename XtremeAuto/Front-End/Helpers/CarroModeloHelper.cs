using Front_End.Models;
using Newtonsoft.Json;

namespace Front_End.Helpers
{
    public class CarroModeloHelper
    {
        ServiceRepository repository;

        public CarroModeloHelper()
        {
            repository = new ServiceRepository();
        }

        #region  GetALL

        public List<CarroModeloViewModel> GetAll()
        {



            List<CarroModeloViewModel> lista = new List<CarroModeloViewModel>();
            HttpResponseMessage responseMessage = repository.GetResponse("api/CarroModelo/");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<CarroModeloViewModel>>(content);

            }




            return lista;
        }
        #endregion


        #region GetByID
        public CarroModeloViewModel GetByID(int id)
        {
            CarroModeloViewModel carroModelo = new CarroModeloViewModel();

            HttpResponseMessage responseMessage = repository.GetResponse("api/carroModelo/" + id);
            string content = responseMessage.Content.ReadAsStringAsync().Result;
            carroModelo = JsonConvert.DeserializeObject<CarroModeloViewModel>(content);

            return carroModelo;

        }



        #endregion


        #region Update
        public CarroModeloViewModel Edit(CarroModeloViewModel carromodelo)
        {

            HttpResponseMessage responseMessage = repository.PutResponse("api/carroModelo/", carromodelo);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            CarroModeloViewModel carroModeloAPI = JsonConvert.DeserializeObject<CarroModeloViewModel>(content);
            return carroModeloAPI;

        }


        #endregion


        #region Create
        public CarroModeloViewModel Add(CarroModeloViewModel category)
        {

            HttpResponseMessage responseMessage = repository.PostResponse("api/carroModelo/", category);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            CarroModeloViewModel carroModeloAPI = JsonConvert.DeserializeObject<CarroModeloViewModel>(content);
            return carroModeloAPI;

        }


        #endregion


        #region GetByID

        /// <summary>
        /// Obtener Categoria por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CarroModeloViewModel Delete(int id)
        {
            CarroModeloViewModel carroModelo = new CarroModeloViewModel();

            HttpResponseMessage responseMessage = repository.DeleteResponse("api/carroModelo/" + id);
            // string content = responseMessage.Content.ReadAsStringAsync().Result;
            // category = JsonConvert.DeserializeObject<CategoryViewModel>(content);

            return carroModelo;

        }



        #endregion

    }
}

