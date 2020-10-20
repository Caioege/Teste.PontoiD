﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
    }
}
