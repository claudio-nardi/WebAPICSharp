using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAppCSharp.Models;

namespace WebAppCSharp.Controllers
{
    public class VeiculosController : ApiController
    {
        public static List<Veiculos> listaVeiculos = new List<Veiculos>();

        [HttpGet]
        [Route("api/veiculos/popular")]
        public JObject Popular()
        {
            listaVeiculos.Add(new Veiculos(1, "Ford Fiesta", "1.0 MPI Personnalité Sedan 4P", 2005,
                                            2005, "Preto", 2, false, 25000, true));
            listaVeiculos.Add(new Veiculos(2, "Kia Cerato", "1.0 MPI Personnalité Sedan 4P", 2005,
                                            2005, "Preto", 2, false, 25000, true));
            listaVeiculos.Add(new Veiculos(3, "Hyundai HB20", "1.0 MPI Personnalité Sedan 4P", 2005,
                                            2005, "Preto", 2, false, 25000, true));
            listaVeiculos.Add(new Veiculos(4, "Chevrolet Prisma", "1.0 MPI Personnalité Sedan 4P", 2005,
                                            2005, "Preto", 2, false, 25000, true));
            listaVeiculos.Add(new Veiculos(5, "Volkswagen Polo", "1.0 MPI Personnalité Sedan 4P", 2005,
                                            2005, "Preto", 2, false, 25000, true));
            var resultado = JObject.Parse("{resultado: \"populado\"}");
            return resultado;
        }

        // GET api/veiculos
        [HttpGet]
        [Route("api/veiculos")]
        public List<Veiculos> Get()
        {
            return listaVeiculos;
        }

        // GET api/veiculos/5
        [HttpGet]
        [Route("api/veiculos/{id}")]
        public Veiculos Get(int id)
        {
            return listaVeiculos.Find(x => x.Id.Equals(id));
        }

        // POST api/veiculos
        [HttpPost]
        [Route("api/veiculos")]
        public JObject Post([FromBody] Veiculos veiculo)
        {
            var resultado = "";

            if (veiculo.Id == 0)
                resultado = "{resultado: \"Id não pode ser nulo e nem zero\"}";
            else if (String.IsNullOrEmpty(veiculo.Marca))
                resultado += "{resultado: \"A marca deve ser informada\"}";
            else if (String.IsNullOrEmpty(veiculo.Modelo))
                resultado += "{resultado: \"A marca deve ser informada\"}";
            else if (veiculo.Valor == 0)
                resultado += "{resultado: \"Valor tem que maior que zero\"}";
            else 
            { 
                listaVeiculos.Add(new Veiculos(veiculo.Id, veiculo.Marca, veiculo.Modelo, veiculo.Ano,
                    veiculo.Fabricacao, veiculo.Cor, veiculo.Combustivel, veiculo.Automatico,
                    veiculo.Valor, veiculo.Ativo));
                resultado = "{resultado: \"Cadastrado Id:"+veiculo.Id+"\"}";
            }
            return JObject.Parse(resultado);
        }

        // PUT api/veiculos/5
        [HttpPut]
        [Route("api/veiculos/{id}")]
        public void Put(int id, [FromBody] Veiculos veiculo)
        {
            var veiculoPesquisado = listaVeiculos.Single(x => x.Id.Equals(id));
            veiculoPesquisado.Marca = veiculo.Marca;
            veiculoPesquisado.Modelo = veiculo.Modelo;
            veiculoPesquisado.Ano = veiculo.Ano;
            veiculoPesquisado.Fabricacao = veiculo.Fabricacao;
            veiculoPesquisado.Cor = veiculo.Cor;
            veiculoPesquisado.Combustivel = veiculo.Combustivel;
            veiculoPesquisado.Automatico = veiculo.Automatico;
            veiculoPesquisado.Valor = veiculo.Valor;
            veiculoPesquisado.Ativo = veiculo.Ativo;
        }

        // DELETE api/veiculos/5
        [HttpDelete]
        [Route("api/veiculos/{id}")]
        public void Delete(int id)
        {
            var veiculo = listaVeiculos.Single(x => x.Id.Equals(id));
            listaVeiculos.Remove(veiculo);
            //var resultado = JObject.Parse("{resultado: \"Removido Id:" + id + "\"}");
            //return resultado;
        }
    }
}
