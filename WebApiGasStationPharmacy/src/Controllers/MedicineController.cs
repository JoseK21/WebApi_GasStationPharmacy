using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApiGasStationPharmacy.ViewModel;

namespace WebApiGasStationPharmacy.Controllers
{
    public class MedicineController : Controller
    {
        private static List<Medicine> Medicines = new List<Medicine>();

        [HttpGet]
        [Route("medicines")]
        public IActionResult Get()
        {
            return Ok(Medicines);
        }

        [HttpGet]
        [Route("medicines/{name}")]
        public IActionResult Get(string name)
        {
            for (int i = 0; i < Medicines.Count; i++)
            {
                if (Medicines.ElementAt(i).Name.Equals(name)) return Ok(Medicines.ElementAt(i));
            }
            return NotFound();
        }

        [HttpPost]
        [Route("medicines/new")]
        public IActionResult Post(string value)
        {
            System.Diagnostics.Debug.WriteLine(value);
            Medicine new_cust = JsonConvert.DeserializeObject<Medicine>(value);
            Medicines.Add(new_cust);
            return Ok();
        }

        [HttpPut]
        [Route("medicines/update/{name}")]
        public IActionResult Put(string name,string value)
        {
            Medicine new_med = JsonConvert.DeserializeObject<Medicine>(value);

            for (int i = 0; i < Medicines.Count; i++)
            {
                if (Medicines.ElementAt(i).Name.Equals(name))
                {
                    Medicine med = Medicines.ElementAt(i);
                    med.Manufacturer = new_med.Manufacturer;
                    med.Name = new_med.Name;
                    med.AvailableQnt = new_med.AvailableQnt;
                    med.Prescription = new_med.Prescription;
                    return Ok();
                }
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("medicines/delete/{name}")]
        public IActionResult Delete(string name)
        {
            for (int i = 0; i < Medicines.Count; i++)
            {
                if (Medicines.ElementAt(i).Name.Equals(name))
                {
                    Medicines.RemoveAt(i);
                    return Ok();
                }
            }
            return NotFound();
        }
    }
}
