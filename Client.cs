using System.Net.Http;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace myInvoices{    
    public class Client{
        HttpClient httpClient;
        public Client(bool isTest){
            httpClient = new HttpClient();
            if(isTest)
                httpClient.BaseAddress = new Uri("https://dev-myinvoices.orian.gr/webapi/");
            else
                httpClient.BaseAddress = new Uri("https://myinvoices.orian.gr/webapi/");            
        }
        public async Task<string> LoginAsync(string userName, string password)
        {
            var endPoint = "Authenticate/Login";
            var content = new StringContent(JsonSerializer.Serialize(new Credentials{Username=userName,Password=password}), System.Text.Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(endPoint, content);
            response.EnsureSuccessStatusCode();
            var token = await response.Content.ReadAsStringAsync();     
            AuthenticateClient(token);
            return token;
        }
        private void AuthenticateClient(string token) {
            var headerName = "Bearer";
            if (httpClient.DefaultRequestHeaders.Contains(headerName))
                httpClient.DefaultRequestHeaders.Remove(headerName);
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(headerName, token);
        }
        public async Task SendInvoiceToYpahesAsync(EInvoiceBody eInvoice)
        {                    
            
            var endPoint = "Invoices/SendInvoice";
            var content = new StringContent(JsonSerializer.Serialize(eInvoice), System.Text.Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(endPoint, content);
            response.EnsureSuccessStatusCode();
            var validationResult = response.Content.ReadAsStringAsync().Result;
            var myResponse=JsonSerializer.Deserialize<myInvoices.OrianMyDATAResponse>(validationResult);
            var description = myResponse.isSuccess ? "succesfully" : "with errors";
            Console.WriteLine($"Invoice sent {description}. Response: {validationResult}");
        }

    }
}
