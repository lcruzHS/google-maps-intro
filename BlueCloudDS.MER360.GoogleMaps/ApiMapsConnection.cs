using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BlueCloudDS.MER360.GoogleMaps
{
    public abstract class ApiMapsConnection: IDisposable
    {
        private const string API_KEY = "key";

        HttpWebRequest httpClient = null;

        public ApiMapsConnection(string apiURL): this(new Uri(apiURL))
        {
        }

        public ApiMapsConnection(Uri apiUri)
        {
            if (apiUri == null) throw new ArgumentNullException("uri");

            Uri = apiUri;

            Parameters = new Dictionary<string, string>();
        }

        public Uri Uri { get; private set; } 

        public Dictionary<string, string> Parameters { get; private set; }

        /// <summary>
        /// Returns the routes information as text.
        /// </summary>
        /// <returns>The route information text.</returns>
        public string GetText()
        {
            try
            {
                var uri = GetUri();

                HttpWebRequest http = (HttpWebRequest)WebRequest.Create(uri);
                WebResponse response = http.GetResponse();

                StreamReader sr = new StreamReader(response.GetResponseStream());
                string content = sr.ReadToEnd();

                return content;
            }
            catch (WebException ex)
            {
                throw new ApplicationException("Communication with the Google API could not be stablished.", ex);
            }
            catch (ProtocolViolationException ex)
            {
                throw new ApplicationException("An invalid operation was performed trying to get directions.", ex);
            }
            catch(NotSupportedException ex)
            {
                throw new ApplicationException("A unsupported operation was performed trying to get directions.", ex);
            }
            catch (InvalidOperationException ex)
            {
                throw new ApplicationException("Directions cannot be retrieved due to the the current http client state.", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An unexpected error occurred trying to get directions.", ex);
            }
        }

        /// <summary>
        /// Returns the routes information as text asynchronously.
        /// </summary>
        /// <returns>The route information text.</returns>
        public Task<string> GetTextAsync()
        {
            return Task.Factory.StartNew<string>(() => GetText());
        }

        /// <summary>
        /// Returns the routes result asynchronously.
        /// </summary>
        /// <returns></returns>
        public abstract T GetDirections<T>() where T : class;

        /// <summary>
        /// Returns the routes result asynchronously.
        /// </summary>
        /// <returns></returns>
        public abstract Task<T> GetDirectionsAsync<T>() where T : class;

        private Uri GetUri()
        {
            NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);
            foreach (var item in Parameters)
            {
                queryString.Add(item.Key, item.Value);
            }
            queryString.Add(API_KEY, Properties.Settings.Default.Google_API_Key);

            var uriBuilder = new UriBuilder(Uri);
            uriBuilder.Query = queryString.ToString();

            return uriBuilder.Uri;
        }

        #region IDisposable members

        private bool _disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposing) return;
        }

        public void Dispose()
        {
            Dispose(_disposed);
            _disposed = true;
            GC.SuppressFinalize(this);
        }

        ~ApiMapsConnection()
        {
            Dispose(false);
        }

        #endregion //IDisposable members
    }
}
