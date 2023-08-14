using Front_End.Models;
using Newtonsoft.Json;

namespace Front_End.Helpers
{
    public class ColorHelper
    {
        ServiceRepository repository;

        public ColorHelper()
        {
            repository = new ServiceRepository();
        }

        #region  GetALL

        public List<ColorViewModel> GetAll()
        {

            List<ColorViewModel> lista = new List<ColorViewModel>();
            HttpResponseMessage responseMessage = repository.GetResponse("/api/Color/");
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                lista = JsonConvert.DeserializeObject<List<ColorViewModel>>(content);

            }

            return lista;
        }
        #endregion


        #region GetByID
        public ColorViewModel GetByID(int ColorId)
        {
            ColorViewModel color = new ColorViewModel();

            HttpResponseMessage responseMessage = repository.GetResponse("/api/Color/" + ColorId);
            string content = responseMessage.Content.ReadAsStringAsync().Result;
            color = JsonConvert.DeserializeObject<ColorViewModel>(content);

            return color;

        }



        #endregion


        #region Update
        public ColorViewModel Edit(ColorViewModel color)
        {

            HttpResponseMessage responseMessage = repository.PutResponse("/api/Color/", color);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            ColorViewModel colorAPI = JsonConvert.DeserializeObject<ColorViewModel>(content);
            return colorAPI;

        }


        #endregion


        #region Create
        public ColorViewModel Add(ColorViewModel color)
        {

            HttpResponseMessage responseMessage = repository.PostResponse("/api/Color/", color);
            var content = responseMessage.Content.ReadAsStringAsync().Result;
            ColorViewModel colorAPI = JsonConvert.DeserializeObject<ColorViewModel>(content);
            return colorAPI;

        }


        #endregion


        #region GetByID
        public ColorViewModel Delete(int ColorId)
        {
            ColorViewModel color = new ColorViewModel();

            HttpResponseMessage responseMessage = repository.DeleteResponse("/api/Color/" + ColorId);
            // string content = responseMessage.Content.ReadAsStringAsync().Result;
            // category = JsonConvert.DeserializeObject<CategoryViewModel>(content);

            return color;
        }
        #endregion

    }
}