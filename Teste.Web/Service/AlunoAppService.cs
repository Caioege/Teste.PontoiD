﻿using Newtonsoft.Json;
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
    public class AlunoAppService
    {
        public List<Aluno> GetAlunos()
        {

            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)768 | (SecurityProtocolType)3072;
                //send request

                using (var client = new HttpClient(httpClientHandler))
                {
                    var url = "https://localhost:5001/api/Alunos";
                    var response = client.GetStringAsync(string.Format(url));

                    var alunos = JsonConvert.DeserializeObject(response.Result, typeof(List<Aluno>));

                    return alunos as List<Aluno>;
                }
            }
        }

        public Aluno GetAluno(int id)
        {

            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)768 | (SecurityProtocolType)3072;
                //send request

                using (var client = new HttpClient(httpClientHandler))
                {
                    var url = "https://localhost:5001/api/Alunos/" + id;
                    var response = client.GetStringAsync(url);

                    var aluno = JsonConvert.DeserializeObject(response.Result, typeof(Aluno));

                    return aluno as Aluno;
                }
            }
        }

        public List<Aluno> GetAlunosPorTurma(int Id)
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)768 | (SecurityProtocolType)3072;
                //send request

                using (var client = new HttpClient(httpClientHandler))
                {
                    var url = "https://localhost:5001/api/Alunos/getalunoturma/" + Id;
                    var response = client.GetStringAsync(string.Format(url));

                    var alunos = JsonConvert.DeserializeObject(response.Result, typeof(List<Aluno>));

                    return alunos as List<Aluno>;
                }
            }
        }

        public bool AtualizarAluno(Aluno aluno)
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
                    string json = JsonConvert.SerializeObject(aluno, Formatting.Indented);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(json);
                    var alunoJson = new ByteArrayContent(buffer);
                    alunoJson.Headers.ContentType = new MediaTypeHeaderValue("application/json");


                    var url = "https://localhost:5001/api/Alunos/" + aluno.Id;
                    var response = client.PutAsync(url, alunoJson).Result;

                    return true;
                }
            }
        }
    }
}
