using marvelheroes.net.Common.Clients;
using marvelheroes.net.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace marvelheroes.net.Controllers
{
    public class HomeController : Controller
    {        
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetCharactersByName(string term)
        {
            var model = new List<Select2ViewModel>();

            var client = new MarvelClient();

            var characters = client.FindCharacters(new Dictionary<string, string>() { { "nameStartsWith", term } });

           if (characters.Any())
            {
                model = characters.Select(ch => new Select2ViewModel() { id = ch.Id.ToString(), text = ch.Name }).ToList();
            }
                                   
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCharactersById(string characterId)
        {
            var model = new CharacterViewModel();

            var client = new MarvelClient();

            var characters = client.FindCharacters(new Dictionary<string, string>() { { "id", characterId } });

            if (characters.Any())
            {
                model = characters.Select(x => (CharacterViewModel)x).FirstOrDefault();
            }

            return Json(model, JsonRequestBehavior.AllowGet);
        }
         
        public JsonResult GetStoriesByCharacterId(string characterId)
        {
            var model = new List<StoryViewModel>();

            var client = new MarvelClient(); 

            var characters = client.FindStoriesByCharacters(characterId);

            if (characters.Any())
            {
                model = characters.Select(x => (StoryViewModel)x).ToList();
            }

            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}