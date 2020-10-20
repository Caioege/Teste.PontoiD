using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Teste.Dominio.Models;

namespace Teste.Web.Service
{
    public class EscolaAppService
    {
        public Escola GetEscola(int id)
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)768 | (SecurityProtocolType)3072;
                //send request

                using (var client = new HttpClient(httpClientHandler))
                {
                    var url = "https://localhost:5001/api/Escolas/" + id;
                    var response = client.GetStringAsync(string.Format(url));

                    var escolas = JsonConvert.DeserializeObject(response.Result, typeof(Escola));

                    return escolas as Escola;
                }
            }
        }

        public List<Escola> GetEscolas()
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)768 | (SecurityProtocolType)3072;
                //send request

                using (var client = new HttpClient(httpClientHandler))
                {
                    var url = "https://localhost:5001/api/Escolas";
                    var response = client.GetStringAsync(string.Format(url));

                    var escolas = JsonConvert.DeserializeObject(response.Result, typeof(List<Escola>));

                    return escolas as List<Escola>;
                }
            }
        }

        public bool AdicionarEscola(Escola escola)
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)768 | (SecurityProtocolType)3072;
                //send request

                using (var client = new HttpClient(httpClientHandler))
                {
                    //CONVERTE DE STRING PARA HTTP CONTENT
                    string json = JsonConvert.SerializeObject(escola, Formatting.Indented);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(json);
                    var escolaJson = new ByteArrayContent(buffer);
                    escolaJson.Headers.ContentType = new MediaTypeHeaderValue("application/json");


                    var url = "https://localhost:5001/api/Escolas";
                    var response = client.PostAsync(string.Format(url), escolaJson).Result;

                    return true;
                }
            }
        }

        public bool AtualizarEscola(Escola escola)
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)768 | (SecurityProtocolType)3072;
                //send request

                using (var client = new HttpClient(httpClientHandler))
                {
                    //CONVERTE DE STRING PARA HTTP CONTENT
                    string json = JsonConvert.SerializeObject(escola, Formatting.Indented);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(json);
                    var escolaJson = new ByteArrayContent(buffer);
                    escolaJson.Headers.ContentType = new MediaTypeHeaderValue("application/json");


                    var url = "https://localhost:5001/api/Escolas";
                    var response = client.PutAsync(string.Format(url), escolaJson).Result;

                    return true;
                }
            }
        }
    }
}
