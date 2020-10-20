using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
    }
}
