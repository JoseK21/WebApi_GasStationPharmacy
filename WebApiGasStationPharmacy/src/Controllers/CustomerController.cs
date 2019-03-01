using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApiGasStationPharmacy.ViewModel;

namespace WebApiGasStationPharmacy.Controllers
{
    public class CustomerController : Controller
    {
        private static List<Customer> customers = new List<Customer>();

        [HttpGet]
        [Route("customers")]
         
        public  IActionResult Get()
        {
            return Ok(customers);
            // return Ok(JsonConvert.SerializeObject(customers));
        }

        // GET: api/Customer/5
        [HttpGet]
        [Route("customers/{id}")]
         
        public  IActionResult Get(string id)
        {
            for (int i = 0; i < customers.Count; i++)
            {
                if (customers.ElementAt(i).ID.Equals(id)) return Ok(customers.ElementAt(i));
            }
            return NotFound();
        }

        // POST: api/Customer
        [HttpPost]
        [Route("customers/new")]
         
        public  IActionResult Post([FromBody]string value)
        {
            System.Diagnostics.Debug.WriteLine(value);
            Customer new_cust = JsonConvert.DeserializeObject<Customer>(value);
            customers.Add(new_cust);
            return Ok();
        }

        // PUT: api/Customer/5
        [HttpPut]
        [Route("customers/update/{id}")]
         
        public  IActionResult Put(string id, [FromBody]string value)
        {
            Customer new_cust = JsonConvert.DeserializeObject<Customer>(value);

            for (int i = 0; i < customers.Count; i++)
            {
                if (customers.ElementAt(i).ID.Equals(id))
                {
                    Customer cust = customers.ElementAt(i);
                    cust.Address = new_cust.Address;
                    cust.Birthday = new_cust.Address;
                    cust.Name = new_cust.Name;
                    cust.MedicalHistory = new_cust.MedicalHistory;
                    cust.PhoneNumber = new_cust.PhoneNumber;
                    return Ok();
                }
            }
            return NotFound();
        }

        // DELETE: api/Customer/5
        [HttpDelete]
        [Route("customers/delete/{id}")]
         
        public  IActionResult Delete( string id)
        {
            for (int i = 0; i < customers.Count; i++)
            {
                if (customers.ElementAt(i).ID.Equals(id))
                {
                    customers.RemoveAt(i);
                    return Ok();
                }
            }
            return NotFound();
        }
    }
}
