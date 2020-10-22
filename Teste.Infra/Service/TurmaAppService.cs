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
    public class TurmaAppService : ITurmaAppService
    {
        public List<Turma> GetTurmas()
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)768 | (SecurityProtocolType)3072;

                using (var client = new HttpClient(httpClientHandler))
                {
                    var url = "https://localhost:5001/api/Turmas";
                    var response = client.GetStringAsync(string.Format(url));

                    var turmas = JsonConvert.DeserializeObject(response.Result, typeof(List<Turma>));

                    return turmas as List<Turma>;
                }
            }
        }

        public Turma GetTurma(int id)
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)768 | (SecurityProtocolType)3072;
                //send request

                using (var client = new HttpClient(httpClientHandler))
                {
                    var url = "https://localhost:5001/api/Turmas/" + id;
                    var response = client.GetStringAsync(url);

                    var turma = JsonConvert.DeserializeObject(response.Result, typeof(Turma));

                    return turma as Turma;
                }
            }
        }

        public void AdicionarTurma(Turma turma)
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
                    string json = JsonConvert.SerializeObject(turma, Formatting.Indented);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(json);
                    var turmaJson = new ByteArrayContent(buffer);
                    turmaJson.Headers.ContentType = new MediaTypeHeaderValue("application/json");


                    var url = "https://localhost:5001/api/Turmas";
                    var response = client.PostAsync(url, turmaJson).Result;
                }
            }
        }

        public void AtualizarTurma(Turma turma)
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
                    string json = JsonConvert.SerializeObject(turma, Formatting.Indented);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(json);
                    var turmaJson = new ByteArrayContent(buffer);
                    turmaJson.Headers.ContentType = new MediaTypeHeaderValue("application/json");


                    var url = "https://localhost:5001/api/Turmas/" + turma.Id;
                    var response = client.PutAsync(url, turmaJson).Result;
                }
            }
        }

        public List<Turma> GetTurmasPorEscola(int id)
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)768 | (SecurityProtocolType)3072;

                using (var client = new HttpClient(httpClientHandler))
                {
                    var url = "https://localhost:5001/api/Turmas/getturmaescola/" + id;
                    var response = client.GetStringAsync(url);

                    var turmas = JsonConvert.DeserializeObject(response.Result, typeof(List<Turma>));

                    return turmas as List<Turma>;
                }
            }
        }

        public void DeletarTurma(int id)
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)768 | (SecurityProtocolType)3072;
                //send request

                using (var client = new HttpClient(httpClientHandler))
                {
                    var url = "https://localhost:5001/api/Turmas/" + id;
                    var response = client.DeleteAsync(url).Result;
                }
            }
        }
    }
}
