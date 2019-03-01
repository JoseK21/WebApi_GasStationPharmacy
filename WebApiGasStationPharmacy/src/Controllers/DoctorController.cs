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
        public  IActionResult Get()
        {
            return Ok(Doctors);
        }

        [HttpGet]
        [Route("doctors/{id}")]
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
        public  IActionResult Post(string value)
        {
            System.Diagnostics.Debug.WriteLine(value);
            Doctor new_cust = JsonConvert.DeserializeObject<Doctor>(value);
            Doctors.Add(new_cust);
            return Ok();
        }

        [HttpPut]
        [Route("doctors/update/{id}")]
        public  IActionResult Put(string id, string value)
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
        public  IActionResult Delete(string id)
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
