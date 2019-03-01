using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApiGasStationPharmacy.ViewModel;

namespace WebApiGasStationPharmacy.Controllers
{
    public class RecipeController : Controller
    {
        private static List<Recipe> Recipes = new List<Recipe>();

        [HttpGet]
        [Route("recipes")]
        [DisableCors]
        public  IActionResult Get()
        {
            return Ok(Recipes);
        }

        [HttpGet]
        [Route("recipes/{id}")]
        [DisableCors]
        public  IActionResult Get(string id)
        {
            for (int i = 0; i < Recipes.Count; i++)
            {
                if (Recipes.ElementAt(i).RecpID.Equals(id)) return Ok(Recipes.ElementAt(i));
            }
            return NotFound();
        }

        [HttpPost]
        [Route("recipes/new")]
        [DisableCors]
        public  IActionResult Post([FromBody]string value)
        {
            System.Diagnostics.Debug.WriteLine(value);
            Recipe new_cust = JsonConvert.DeserializeObject<Recipe>(value);
            Recipes.Add(new_cust);
            return Ok();
        }

        [HttpPut]
        [Route("recipes/update/{id}")]
        [DisableCors]
        public  IActionResult Put(string id, [FromBody]string value)
        {
            Recipe new_rcp = JsonConvert.DeserializeObject<Recipe>(value);

            for (int i = 0; i < Recipes.Count; i++)
            {
                if (Recipes.ElementAt(i).RecpID.Equals(id))
                {
                    Recipe recp = Recipes.ElementAt(i);
                    recp.Doctor = new_rcp.Doctor;
                    recp.Medicines = new_rcp.Medicines;
                    return Ok();
                }
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("recipes/delete/{id}")]
        [DisableCors]
        public  IActionResult Delete( string id)
        {
            for (int i = 0; i < Recipes.Count; i++)
            {
                if (Recipes.ElementAt(i).RecpID.Equals(id))
                {
                    Recipes.RemoveAt(i);
                    return Ok();
                }
            }
            return NotFound();
        }
    }
}
