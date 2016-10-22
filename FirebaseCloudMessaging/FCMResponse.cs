namespace FirebaseCloudMessaging
{
    public class FCMResponse
    {
        public long multicast_id { get; set; }
        public bool success { get; set; }
        public bool failure { get; set; }
        public int canonical_ids { get; set; }
        public FCMResult[] results { get; set; }
    }
}
