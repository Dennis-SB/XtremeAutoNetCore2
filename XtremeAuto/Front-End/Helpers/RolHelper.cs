using Front_End.Models;
using Newtonsoft.Json;

namespace Front_End.Helpers
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
        public RolViewModel GetByID(int RolId)
        {
            RolViewModel rol = new RolViewModel();

            HttpResponseMessage responseMessage = repository.GetResponse("api/Rol/" + RolId);
            string content = responseMessage.Content.ReadAsStringAsync().Result;
            rol = JsonConvert.DeserializeObject<RolViewModel>(content);

            return rol;

        }



        #endregion


        #region Update
        public RolViewModel Edit(RolViewModel rol)
        {

            HttpResponseMessage responseMessage = repository.PutResponse("api/rol/", rol);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            RolViewModel rolAPI = JsonConvert.DeserializeObject<RolViewModel>(content);
            return rolAPI;

        }


        #endregion


        #region Create
        public RolViewModel Add(RolViewModel rol)
        {

            HttpResponseMessage responseMessage = repository.PostResponse("api/rol/", rol);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            RolViewModel rolAPI = JsonConvert.DeserializeObject<RolViewModel>(content);
            return rolAPI;

        }


        #endregion


        #region GetByID
        public RolViewModel Delete(int RolId)
        {
            RolViewModel rol = new RolViewModel();

            HttpResponseMessage responseMessage = repository.DeleteResponse("api/rueda/" + RolId);
            // string content = responseMessage.Content.ReadAsStringAsync().Result;
            // category = JsonConvert.DeserializeObject<CategoryViewModel>(content);

            return rol;
        }
        #endregion

    }
}
