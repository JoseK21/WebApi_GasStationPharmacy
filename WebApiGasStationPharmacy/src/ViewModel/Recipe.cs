using System.Collections.Generic;

namespace WebApiGasStationPharmacy.ViewModel
{
    public class Recipe
    {
        public int RecpID;
        public string Doctor;
        public List<Medicine> Medicines;
    }
}