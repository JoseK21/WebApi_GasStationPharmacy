using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Scaffolding.Internal;
using webapigasstationpharmacy.ViewModel;

namespace webapigasstationpharmacy.Controllers
{
    [Route("api/client/[controller]")]
    public class ClientController : Controller
    {
        List<Client> Client = new List<Client>()
        {
            new Client{id = 1,numCedula = 304220116,nombre = "Jose Leo",apellido = "Núñez Valverde",lugResidencia = "Cartago",fecNacimiento = "09/12/1995",tel = 87502593,historia = "Soy un programador obtimista. :>"},
        };
        
        // GET api/Client
        [HttpGet]
        public IEnumerable<Client> GetClients()
        {
            return Client;
        }
        
        // GET api/Client
        [HttpGet("{id:int}")]
        public IEnumerable<Client> GetClientsId(int id)
        {
            
            List<Client> ObjClien;
            ObjClien = new List<Client>();
            /*
            var clientList = (from client in Client where client.iD.Equals(id) select new {client.iD, client.age, client.name});
            var jose =  new Client {iD = 1, name = "Jose", age = 23};
            ObjClien.Add(jose); 
            */
            
            return ObjClien;
        }
        
        
        
        [HttpGet("LogIn/{userName}/{password}")]
        public IActionResult GetById(string userName,string password)
        {
            return Ok($"UserName: {userName} _> Password: {password}");
        }
     }
}