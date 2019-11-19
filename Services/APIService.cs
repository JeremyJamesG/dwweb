using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using dwweb_rhino.Models;
using Newtonsoft.Json;

namespace dwweb_rhino.Services
{
    public class APIService
    {
        private string baseUrl;

        public APIService()
        {
            this.baseUrl = "http://localhost:53228/api/v1";
        }

        public User AuthenticateUser(string username, string password)
        {
            string endpoint = this.baseUrl + "/identity/login";
            string method = "POST";
            string json = JsonConvert.SerializeObject(new
            {
                email = username,
                password = password

            });

            WebClient client = new WebClient();

            client.Headers["Content-Type"] = "application/json";

             //Maybe need to see if can use refresh token here instead of getting new token?
            try
            {
                string response = client.UploadString(endpoint, method, json);

                User user = JsonConvert.DeserializeObject<User>(response);
                return user;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public User RegisterUser(string username, string password)
        {
            string endpoint = this.baseUrl + "/identity/register";
            string method = "POST";
            string json = JsonConvert.SerializeObject(new
            {
                email = username,
                password = password
            });

            WebClient client = new WebClient();
            client.Headers["Content-Type"] = "application/json";

            try
            {
                string response = client.UploadString(endpoint, method, json);

                User user = JsonConvert.DeserializeObject<User>(response);
                user.Email = username;
                return user;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Project> GetAllProjects(User user)
        {
            throw new NotImplementedException();
        }

        public Project GetProjectById(User user, Guid projectId)
        {
            throw new NotImplementedException();
        }

        public string PostProjet(User user, string projectAsJson)
        {
            string endpoint = this.baseUrl + "/projects";
            string method = "POST";
            string accessToken = "bearer " + user.Token;

            WebClient client = new WebClient();
            client.Headers["Content-Type"] = "application/json";
            client.Headers["Authorization"] = accessToken;

            try
            {
                string response = client.UploadString(endpoint,method, projectAsJson);
                return response;
            }
            catch
            {
                return null;
            }
        }
    }

    
}
