namespace OclcApiTest
{
    public class OclcBadRequestResponse
    {
        public int errorCount { get; set; }

        public string[] errors { get; set; }

        public OclcFieldError[] fixedFieldErrors { get; set; }

        public OclcFieldError[] variableFieldErrors { get; set; }
    }
}
