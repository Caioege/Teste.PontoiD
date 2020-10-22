using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Teste.Dominio.Models;
using Teste.Infra.Service.Interfaces;

namespace Teste.Infra.Service
{
    public class EscolaAppService : IEscolaAppService
    {
        public EscolaAppService()
        {

        }

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
                    var response = client.GetStringAsync(url);

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
                    var response = client.GetStringAsync(url);

                    var escolas = JsonConvert.DeserializeObject(response.Result, typeof(List<Escola>));

                    return escolas as List<Escola>;
                }
            }
        }

        public void AdicionarEscola(Escola escola)
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
                    var response = client.PostAsync(url, escolaJson).Result;
                }
            }
        }

        public void AtualizarEscola(Escola escola)
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


                    var url = "https://localhost:5001/api/Escolas/" + escola.Id;
                    var response = client.PutAsync(string.Format(url), escolaJson).Result;
                }
            }
        }

        public void DeletarEscola(int Id)
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)768 | (SecurityProtocolType)3072;
                //send request

                using (var client = new HttpClient(httpClientHandler))
                {
                    var url = "https://localhost:5001/api/Escolas/" + Id;
                    var response = client.DeleteAsync(url).Result;
                }
            }
        }
    }
}
