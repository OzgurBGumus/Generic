namespace StartupV0001.Models
{
    public class JwtToken
    {
        /// <summary>
        /// The JWT token string
        /// </summary>
        public string Value { get;}

        /// <summary>
        /// The expiry date of the JWT Token
        /// </summary>
        public string Expiry { get;}

        public JwtToken(string value, string expiry)
        {
            Value = value;
            Expiry = expiry;
        }
    }
}
