using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebServicesCidades.Models;
using System.Linq;

namespace WebServicesCidades.Controllers
{
    //Vamos definir aqui a rota para a requisição do serviço
    [Route("api/[controller]")]
    public class PrimeiraController:Controller
    {
        Cidades cidade = new Cidades();
        DAOCidades dao = new DAOCidades();

        /*[HttpGet] //vou requisitar o serviço, mas também estou passando um parâmetro (id)
        public IEnumerable<string> Get(){
            return new string[] {"Curitiba", "Porto Alegre", "Salvador", "Belo Horizonte"};
            //Ienumerable no MVC: ler o conteúdo de uma lista, no View.
            //Ienumerable aqui: não temos View, mostraremos após a requisição, num formato de leitura, JSON.
        }*/
        
        /*[HttpGet("{id}")] //vou requisitar o serviço, mas também estou passando um parâmetro (id)
        public string Get(int id){
            return new string[] {"Curitiba", "Porto Alegre", "Salvador", "Belo Horizonte"}[id];
        }*/
                
        [HttpGet]
        public IEnumerable<Cidades> Get(){
            return cidade.Listar();
            //vai retornar todas as "cidades" em uma lista
        }
    }
}
