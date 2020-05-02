using ConsultarCep.Servico.Modelo;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace ConsultarCep.Servico
{
    public class ViaCEPServico
    {
        private static string EnderecoURL = "http://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            //Variável que monta a url
            string NovoEnderecoURL = string.Format(EnderecoURL, cep);

            //Requisição da url
            WebClient wc = new WebClient();
            string Conteudo = wc.DownloadString(NovoEnderecoURL);

            //Deserializar o conteúdo
            Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo);

            if(end.cep == null) { return null; }

            return end;

        }
    }
}
