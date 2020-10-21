using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Teste.Dominio.Models;

namespace Teste.Web.Service
{
    public class TurmaAppService
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

        public bool AdicionarTurma(Turma turma)
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

                    return true;
                }
            }
        }

        public bool AtualizarTurma(Turma turma)
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

                    return true;
                }
            }
        }
    }
}
