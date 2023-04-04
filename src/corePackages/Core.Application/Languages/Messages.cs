using System.Globalization;

namespace Core.Application.Languages
{
    public static class Messages
    {
        private static CultureInfo CultureInfo => CultureInfo.CurrentCulture;
        public static string ClaimsNotFound => CultureInfo.Name == "en-US" ? "Your identity could not be verified" : "Kimliğiniz doğrulanamadı";
        public static string EmailAddressIsNotConfirmed => CultureInfo.Name == "en-US" ? "Email address is not confirmed" : "Email adresiniz doğrulanmamış";
        public static string YouAreNotAuthorized => CultureInfo.Name == "en-US" ? "You are not authorized." : "Yetkili değilsiniz";
    }
}
