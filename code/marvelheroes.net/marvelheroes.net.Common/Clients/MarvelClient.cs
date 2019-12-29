using marvelheroes.net.Common.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;

namespace marvelheroes.net.Common.Clients
{
    public class MarvelClient
    {
        private readonly string _baseUrl = "http://gateway.marvel.com/v1/public/";
        private readonly string _privateKey = "2f0790c794257024b302cad1eccca1827c433077";
        private readonly string _publicKey = "516ca093fc5f91cf30d467b140987746";

        public IEnumerable<Character> FindCharacters(Dictionary<string, string> parameters)
        {
            if (parameters is null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }
             
            var charactersResult = new List<Character>();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                string ts = DateTime.Now.Ticks.ToString();
                string hash = GetHash(ts, _publicKey, _privateKey);

                string uriFilters = string.Empty;

                parameters.AsParallel().ForAll(pair => uriFilters += $"&{pair.Key}={pair.Value}");

                string requestUri = $"{_baseUrl}characters?ts={ts}&apikey={_publicKey}&hash={hash}{Uri.EscapeUriString(uriFilters)}";

                using (HttpResponseMessage response = client.GetAsync(requestUri).Result)
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        string responseResult = response.Content.ReadAsStringAsync().Result;

                        var marvel = JsonConvert.DeserializeObject<MarvelRoot<Character>>(responseResult);

                        if (marvel.Data.Results.Any())
                        {
                            charactersResult = marvel.Data.Results;
                        }
                    }
                }              
            }
            
            return charactersResult;
        }

        public IEnumerable<Story> FindStoriesByCharacters(string characterId)
        {
            if (string.IsNullOrWhiteSpace(characterId))
            {
                throw new ArgumentNullException(nameof(characterId));
            }

            var storiesResults = new List<Story>();
             
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                string ts = DateTime.Now.Ticks.ToString();
                string hash = GetHash(ts, _publicKey, _privateKey);

                string requestUri = $"{_baseUrl}characters/{Uri.EscapeUriString(characterId)}/stories?ts={ts}&apikey={_publicKey}&hash={hash}";

                using (HttpResponseMessage response = client.GetAsync(requestUri).Result)
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        string responseResult = response.Content.ReadAsStringAsync().Result;

                        var marvel = JsonConvert.DeserializeObject<MarvelRoot<Story>>(responseResult);

                        if (marvel.Data.Results.Any())
                        {
                            storiesResults = marvel.Data.Results;
                        }
                    }
                }
            }

            return storiesResults;
        }

        private string GetHash(string ts, string publicKey, string privateKey)
        {
            using (MD5 gerador = MD5.Create())
            {
                byte[] bytesHash = gerador.ComputeHash(Encoding.UTF8.GetBytes($"{ts}{privateKey}{publicKey}"));

                return BitConverter.ToString(bytesHash)
                    .ToLower().Replace("-", string.Empty);
            }
        }
    }
}
