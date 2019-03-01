using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApiGasStationPharmacy.ViewModel;

namespace webapigasstationpharmacy.Controllers
{
    public class BranchController : Controller
    {
        private static List<Branch> Branches = new List<Branch>();

        [HttpGet]
        [Route("branches")]
        public IActionResult Get()
        {
            return Ok(Branches);
        }

        [HttpGet]
        [Route("branches/{name}")]
        
        public IActionResult Get(string name)
        {
            for (int i = 0; i < Branches.Count; i++)
            {
                if (Branches.ElementAt(i).Name.Equals(name)) return Ok(Branches.ElementAt(i));
            }
            return NotFound();
        }

        [HttpPost]
        [Route("Branchs/new")]
        public IActionResult Post([FromBody]string value)
        {
            System.Diagnostics.Debug.WriteLine(value);
            Branch new_cust = JsonConvert.DeserializeObject<Branch>(value);
            Branches.Add(new_cust);
            return Ok();
        }

        [HttpPut]
        [Route("Branchs/update/{name}")]
        
        public IActionResult Put(string name, [FromBody]string value)
        {
            Branch new_branch = JsonConvert.DeserializeObject<Branch>(value);

            for (int i = 0; i < Branches.Count; i++)
            {
                if (Branches.ElementAt(i).Name.Equals(name))
                {
                    Branch branch = Branches.ElementAt(i);
                    branch.Name = new_branch.Name;
                    branch.Description = new_branch.Description;
                    branch.Address = new_branch.Address;
                    branch.Admin = new_branch.Admin;
                    return Ok();
                }
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("branches/delete/{name}")]
        public IActionResult Delete( string name)
        {
            for (int i = 0; i < Branches.Count; i++)
            {
                if (Branches.ElementAt(i).Name.Equals(name))
                {
                    Branches.RemoveAt(i);
                    return Ok();
                }
            }
            return NotFound();
        }
    }
}
