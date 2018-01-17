using System.Collections.Generic;

namespace WebServicesCidades.Models
{
    public class Cidades
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Estado { get; set; }
        public int Habitantes { get; set; }

        public List<Cidades> Listar(){
            return new List<Cidades>(){
                new Cidades{Id=10,Nome="Leme",Estado="SP",Habitantes=154},
                new Cidades{Id=51,Nome="Curitiba",Estado="PR",Habitantes=547},
                new Cidades{Id=22,Nome="Itu",Estado="SP",Habitantes=4578},
                new Cidades{Id=58,Nome="Santos",Estado="SP",Habitantes=6589}
            };
        }
    }
}