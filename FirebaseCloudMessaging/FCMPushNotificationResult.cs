using System;

namespace FirebaseCloudMessaging
{
    public class FCMPushNotificationResult
    {
        public FCMResponse Response { get; set; }
        public Exception Error { get; set; }
    }
}
