using System;
using System.IO;
using System.Text;

namespace FirebaseCloudMessaging
{
    public class FCM
    {
        private const string FCM_URL_API = "https://fcm.googleapis.com/fcm/send";

        private string SERVER_API_KEY { get; set; }
        private string SENDER_ID { get; set; }

        public FCM(string server_api_key, string sender_id)
        {
            this.SERVER_API_KEY = server_api_key;
            this.SENDER_ID = sender_id;
        }

        public FCMPushNotificationResult SendNotification(FCMPushNotification notification)
        {
            var result = new FCMPushNotificationResult();

            try
            {
                var webRequest = System.Net.WebRequest.Create(FCM_URL_API);
                webRequest.Method = "post";
                webRequest.Headers.Add(string.Format("Authorization: key={0}", SERVER_API_KEY));
                webRequest.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));
                webRequest.ContentType = "application/json";

                var data = new
                {
                    to = notification.DeviceId,
                    notification = new
                    {
                        title = notification.Title,
                        body = notification.Body,
                        icon = notification.Icon
                    }
                };

                var json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                var byteArray = Encoding.UTF8.GetBytes(json);
                webRequest.ContentLength = byteArray.Length;

                using (var dataStream = webRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);

                    using (var webResponse = webRequest.GetResponse())
                    {
                        using (var dataStreamResponse = webResponse.GetResponseStream())
                        {
                            using (var streamReader = new StreamReader(dataStreamResponse))
                            {
                                result.Response = Newtonsoft.Json.JsonConvert.DeserializeObject<FCMResponse>(streamReader.ReadToEnd());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Error = ex;
            }

            return result;
        }
    }
}
