using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApiGasStationPharmacy.ViewModel;

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace WebApiGasStationPharmacy.Controllers
{
    public class RoleController : Controller
    {
        private static List<Role> Roles = new List<Role>();

        [HttpGet]
        [Route("roles")]
         
        public  IActionResult Get()
        {
            return Ok(Roles);
        }

        [HttpGet]
        [Route("roles/{name}")]
        public  IActionResult Get(  string name)
        {
            for (int i = 0; i < Roles.Count; i++)
            {
                if (Roles.ElementAt(i).Name.Equals(name)) return Ok(Roles.ElementAt(i));
            }
            return NotFound();
        }

        [HttpPost]
        [Route("roles/new")]
         
        public  IActionResult Post([FromBody]string value)
        {
            System.Diagnostics.Debug.WriteLine(value);
            Role new_cust = JsonConvert.DeserializeObject<Role>(value);
            Roles.Add(new_cust);
            return Ok();
        }

        [HttpPut]
        [Route("roles/update/{name}")]
         
        public  IActionResult Put(string name, [FromBody]string value)
        {
            Role new_role = JsonConvert.DeserializeObject<Role>(value);

            for (int i = 0; i < Roles.Count; i++)
            {
                if (Roles.ElementAt(i).Name.Equals(name))
                {
                    Role role = Roles.ElementAt(i);
                    role.Name = new_role.Name;
                    role.Description = new_role.Description;
                    return Ok();
                }
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("roles/delete/{name}")]
         
        public  IActionResult Delete(   string name)
        {
            for (int i = 0; i < Roles.Count; i++)
            {
                if (Roles.ElementAt(i).Name.Equals(name))
                {
                    Roles.RemoveAt(i);
                    return Ok();
                }
            }
            return NotFound();
        }
    }
}
