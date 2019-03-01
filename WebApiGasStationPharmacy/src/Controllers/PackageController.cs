using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApiGasStationPharmacy.ViewModel;

namespace WebApiGasStationPharmacy.Controllers
{
    public class PackageController : Controller
    {
        private static List<Package> Packages = new List<Package>();

        [HttpGet]
        [Route("packages")]
        public  IActionResult Get()
        {
            return Ok(Packages);
        }

        [HttpGet]
        [Route("packages/{id}")]
        public  IActionResult Get(string id)
        {
            for (int i = 0; i < Packages.Count; i++)
            {
                if (Packages.ElementAt(i).ID.Equals(id)) return Ok(Packages.ElementAt(i));
            }
            return NotFound();
        }

        [HttpPost]
        [Route("packages/new")]
        public  IActionResult Post(string value)
        {
            System.Diagnostics.Debug.WriteLine(value);
            Package new_cust = JsonConvert.DeserializeObject<Package>(value);
            Packages.Add(new_cust);
            return Ok();
        }

        [HttpPut]
        [Route("packages/update/{id}")]
        public  IActionResult Put(string id, string value)
        {
            Package new_pckg = JsonConvert.DeserializeObject<Package>(value);
            System.Diagnostics.Debug.WriteLine(value);

            for (int i = 0; i < Packages.Count; i++)
            {
                if (Packages.ElementAt(i).ID.Equals(id))
                {
                    Package pckg = Packages.ElementAt(i);
                    pckg.PickUpBranch = new_pckg.PickUpBranch;
                    pckg.PickUpTime = new_pckg.PickUpTime;
                    pckg.PhoneNumber = new_pckg.PhoneNumber;
                    pckg.Status = new_pckg.Status;
                    pckg.Client = new_pckg.Client;
                    pckg.Content = new_pckg.Content;
                    return Ok();
                }
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("packages/delete/{id}")]
        public  IActionResult Delete(string id)
        {
            for (int i = 0; i < Packages.Count; i++)
            {
                if (Packages.ElementAt(i).ID.Equals(id))
                {
                    Packages.RemoveAt(i);
                    return Ok();
                }
            }
            return NotFound();
        }
    }
}
