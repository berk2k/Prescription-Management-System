using static se4458_final_utility.SD;

namespace se4458_final_web.Models
{
    public class APIRequest
    {
        public ApiType ApiType { get; set; } = ApiType.GET;

        public string Url { get; set; }

        public object Data { get; set; }
    }
}
