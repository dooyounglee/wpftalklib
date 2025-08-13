using OTILib.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace talkLib.Util
{
    public class HttpUtil
    {
        private static string domain = "http://localhost:5103";
        private static string version = "/v1";
        private static string contextPath = "/api";
        private static string apiUrl = domain + contextPath + version;

        private static readonly HttpClient _httpClient = new HttpClient();

        public static async Task<string> Get(string requestUrl)
        {
            string url = apiUrl + requestUrl;
            OtiLogger.log1(url);

            string response = await GetApiResponseAsync(url);
            OtiLogger.log1(response);
            return response;
        }

        public static string GetSync(string requestUrl)
        {
            string url = apiUrl + requestUrl;
            OtiLogger.log1(url);

            string response = GetApiResponseSync(url);
            OtiLogger.log1(response);
            return response;
        }

        public static async Task<string> Post(string requestUrl, Object? data)
        {
            string url = apiUrl + requestUrl;
            OtiLogger.log1(url);

            string response = await PostApiResponseAsync(url, data);
            OtiLogger.log1(response);
            return response;
        }

        public static async Task<string> Post(string requestUrl, Object? data, byte[] fileBytes, string fileName)
        {
            string url = apiUrl + requestUrl;
            OtiLogger.log1(url);

            string response = await PostApiResponseAsync(url, data, fileBytes, fileName);
            OtiLogger.log1(response);
            return response;
        }

        public static Task<string> Post(string requestUrl)
        {
            return Post(requestUrl, new Object());
        }

        private static string GetApiResponseSync(string url)
        {
            HttpResponseMessage response = _httpClient.GetAsync(url).GetAwaiter().GetResult();
            response.EnsureSuccessStatusCode(); // 에러 발생 시 예외 throw
            return response.Content.ReadAsStringAsync().GetAwaiter().GetResult(); ;
        }

        private static async Task<string> GetApiResponseAsync(string url)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode(); // 에러 발생 시 예외 throw
            return await response.Content.ReadAsStringAsync();
        }

        private static async Task<string> PostApiResponseAsync(string url, object data)
        {
            var json = JsonSerializer.Serialize(data);
            OtiLogger.log1(json);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        private static async Task<string> PostApiResponseAsync(string url, object data, byte[] fileBytes, string fileName)
        {
            var content = new MultipartFormDataContent();

            // 1. object의 각 속성을 개별 필드로 추가
            foreach (PropertyInfo prop in data.GetType().GetProperties())
            {
                object value = prop.GetValue(data);
                if (value != null)
                {
                    content.Add(
                        new StringContent(value.ToString()),
                        prop.Name
                    );
                }
            }

            // 2. 파일 추가
            var fileContent = new ByteArrayContent(fileBytes);
            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/octet-stream");
            content.Add(fileContent, "file", fileName);

            HttpResponseMessage response = await _httpClient.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
