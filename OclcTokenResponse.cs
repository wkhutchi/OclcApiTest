using System;

namespace OclcApiTest
{
    public class OclcTokenResponse
    {
        public string access_token { get; set; }

        public DateTime expires_at { get; set; }

        public string authenticating_institution_id { get; set; }

        public string scope { get; set; }

        public string principalID { get; set; }

        public string context_institution_id { get; set; }

        public string scopes { get; set; }

        public string token_type { get; set; }

        public int expires_in { get; set; }

        public string principalIDNS { get; set; }
    }
}
