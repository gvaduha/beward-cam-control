using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace gvaduha.beward
{
    public abstract class BewardCam
    {
        public static class OutputFormat
        {
            public const string Inf = "inf";
            public const string Script = "";
        }

        public class RequestTraits
        {
            public string Script { get; }
            public string Command { get; }

            public RequestTraits(string script, string command)
            {
                Script = script;
                Command = command;
            }
        }

        protected HttpClient _httpClient;
        protected Uri _baseUri;

        public BewardCam(Uri baseUri, string user, string password)
        {
            _baseUri = baseUri;
            _httpClient = new HttpClient();
            if (!string.IsNullOrEmpty(user))
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Basic",
                            Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", user, password))));
            }
        }

        public abstract Task<string> GetSectionAsync(string command, string format = OutputFormat.Inf);
        public abstract Task<string> SetSectionAsync(string strCommand, string[] data);

        protected T TryParseCommand<T>(string strCommand)
        {
            if (Enum.TryParse(typeof(T), strCommand, out var command))
                return (T)command;
            else
                throw new ApplicationException($"wrong command: {strCommand}");
        }
    }

    public static class BewardCamFactory
    {
        public static BewardCam Create(string camtype, Uri baseUri, string user, string password)
        {
            if (camtype == "SV")
                return new SVseriesCam(baseUri, user, password);
            else if (camtype == "BD")
                return new BDseriesCam(new UriBuilder(baseUri).Uri, user, password);
            else
                throw new ApplicationException("wrong cam type");
        }
    }
}
