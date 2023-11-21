using EBuy.DAL.Models.EF_Models;
using EBuy.DAL.Models.Results;
using EBuy.Website.Models.Identity;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace EBuy.Website.ApiCalls
{
    public class IdentityCaller
    {
        private const string apiUrl = "https://localhost:44308/";
        public List<RoleResult> ApiCall_GetAllRoles()
        {
            List<RoleResult> roles = new List<RoleResult>();

            var client = new RestClient(apiUrl + "api/identity/getallroles");
            var restRequest = new RestRequest();
            var result = client.Get(restRequest);

            if (result.StatusCode == HttpStatusCode.OK)
            {
                roles = JsonConvert.DeserializeObject<List<RoleResult>>(result.Content);
            }

            return roles;
        }

        public void ApiCall_RegisterUser(User user)
        {
            var userJson = JsonConvert.SerializeObject(user);
            var client = new RestClient(apiUrl+"api/identity/register");
            var request = new RestRequest();

            request.Method = Method.Post;
            request.AddHeader("Accept", "application/json");
            request.AddParameter("application/json", userJson, ParameterType.RequestBody);
            client.Post(request);
        }

        public UserResult ApiCall_Login(User user)
        {
            var userJson = JsonConvert.SerializeObject(user);
            var client = new RestClient(apiUrl + "api/identity/login");
            var request = new RestRequest();

            request.Method = Method.Post;
            request.AddHeader("Accept", "application/json");
            request.AddParameter("application/json", userJson, ParameterType.RequestBody);
            var result = client.Post(request);
            return JsonConvert.DeserializeObject<UserResult>(result.Content);
        }
    }
}
