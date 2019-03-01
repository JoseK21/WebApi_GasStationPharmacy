using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApiGasStationPharmacy.ViewModel;

namespace WebApiGasStationPharmacy.Controllers
{
    public class DoctorController : Controller
    {
        private static List<Doctor> Doctors = new List<Doctor>();

        [HttpGet]
        [Route("doctors")]
        [DisableCors]
        public  IActionResult Get()
        {
            return Ok(Doctors);
        }

        [HttpGet]
        [Route("doctors/{id}")]
        [DisableCors]
        public  IActionResult Get(string id)
        {
            for (int i = 0; i < Doctors.Count; i++)
            {
                if (Doctors.ElementAt(i).DoctorID.Equals(id)) return Ok(Doctors.ElementAt(i));
            }
            return NotFound();
        }

        [HttpPost]
        [Route("doctors/new")]
        [DisableCors]
        public  IActionResult Post([FromBody]string value)
        {
            System.Diagnostics.Debug.WriteLine(value);
            Doctor new_cust = JsonConvert.DeserializeObject<Doctor>(value);
            Doctors.Add(new_cust);
            return Ok();
        }

        [HttpPut]
        [Route("doctors/update/{id}")]
        [DisableCors]
        public  IActionResult Put(string id, [FromBody]string value)
        {
            Doctor new_doc = JsonConvert.DeserializeObject<Doctor>(value);

            for (int i = 0; i < Doctors.Count; i++)
            {
                if (Doctors.ElementAt(i).DoctorID.Equals(id))
                {
                    Doctor doc = Doctors.ElementAt(i);
                    doc.Address = new_doc.Address;
                    doc.Name = new_doc.Name;
                    doc.ID = new_doc.ID;
                    return Ok();
                }
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("doctors/delete/{id}")]
        [DisableCors]
        public  IActionResult Delete( string id)
        {
            for (int i = 0; i < Doctors.Count; i++)
            {
                if (Doctors.ElementAt(i).DoctorID.Equals(id))
                {
                    Doctors.RemoveAt(i);
                    return Ok();
                }
            }
            return NotFound();
        }
    }
}
