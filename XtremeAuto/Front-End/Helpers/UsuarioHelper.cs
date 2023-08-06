using Front_End.Models;
using Newtonsoft.Json;

namespace Front_End.Helpers
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
        public UsuarioViewModel GetByID(int UsuarioId)
        {
            UsuarioViewModel usuario = new UsuarioViewModel();

            HttpResponseMessage responseMessage = repository.GetResponse("api/usuario/" + UsuarioId);
            string content = responseMessage.Content.ReadAsStringAsync().Result;
            usuario = JsonConvert.DeserializeObject<UsuarioViewModel>(content);

            return usuario;

        }



        #endregion


        #region Update
        public UsuarioViewModel Edit(UsuarioViewModel usuario)
        {

            HttpResponseMessage responseMessage = repository.PutResponse("api/rol/", usuario);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            UsuarioViewModel usuarioAPI = JsonConvert.DeserializeObject<UsuarioViewModel>(content);
            return usuarioAPI;

        }


        #endregion


        #region Create
        public UsuarioViewModel Add(UsuarioViewModel usuario)
        {

            HttpResponseMessage responseMessage = repository.PostResponse("api/usuario/", usuario);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            UsuarioViewModel usuarioAPI = JsonConvert.DeserializeObject<UsuarioViewModel>(content);
            return usuarioAPI;

        }


        #endregion


        #region GetByID
        public UsuarioViewModel Delete(int UsuarioId)
        {
            UsuarioViewModel usuario = new UsuarioViewModel();

            HttpResponseMessage responseMessage = repository.DeleteResponse("api/tarjeta/" + UsuarioId);
            // string content = responseMessage.Content.ReadAsStringAsync().Result;
            // category = JsonConvert.DeserializeObject<CategoryViewModel>(content);

            return usuario;
        }
        #endregion

    }
}