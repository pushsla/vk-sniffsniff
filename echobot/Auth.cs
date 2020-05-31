using System;

namespace echobot
{
    internal static class Auth
    {
        public static Random Random = new Random();
        public const string Dumpfile = "Auth.dump";
        
        public static long Epoch = Random.Next();
        public static string AdminToken { get; set; }
        public static string AppSecurityKey { get; set; }
        public static string AppId { get; set; }
        public static string CallbackConfirmation { get; set; }
        public static string CallbackSecret { get; set; }
        public static string CallbackGroupToken { get; set; }
    }

    [Serializable]
    internal class AuthTransfer
    {
        private string __adminToken;
        private string __appSecurityKey;
        private string __appId;
        private string __callbackConfirmation;
        private string __callbackSecret;
        private string __callbackGroupToken;
        private long __epoch;

        public AuthTransfer()
        {
            __epoch = Auth.Epoch;
            __adminToken = Auth.AdminToken;
            __appSecurityKey = Auth.AppSecurityKey;
            __appId = Auth.AppId;
            __callbackConfirmation = Auth.CallbackConfirmation;
            __callbackSecret = Auth.CallbackSecret;
            __callbackGroupToken = Auth.CallbackGroupToken;
        }

        public void SetAuth()
        {
            __epoch = Auth.Random.Next();
            Auth.Epoch = __epoch;
            
            Auth.AdminToken = __adminToken;
            Auth.AppSecurityKey = __appSecurityKey;
            Auth.AppId = __appId;
            Auth.CallbackConfirmation = __callbackConfirmation;
            Auth.CallbackSecret = __callbackSecret;
            Auth.CallbackGroupToken = __callbackGroupToken;
        }
    }
}