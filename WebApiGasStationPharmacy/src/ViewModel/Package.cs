using System.Collections.Generic;

namespace WebApiGasStationPharmacy.ViewModel
{
    public class Package
    {
        public string ID;
        public string PickUpBranch;
        public string Client;
        public int PhoneNumber;
        public List<Medicine> Content;
        public string PickUpTime;
        public string Status;
    }
}