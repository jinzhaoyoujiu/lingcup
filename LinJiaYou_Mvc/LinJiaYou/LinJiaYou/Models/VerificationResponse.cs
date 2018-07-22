
namespace LinJiaYou.Models
{
    public class VerificationResponse
    {
//result =Newtonsoft.Json.JsonConvert.SerializeObject("{'code':'000000','count':'1','create_date':'2018-01-11 23:49:00','mobile':'15832578508','msg':'OK','smsid':'a0b912c08b3f77000e04a6a167bc2b06','uid':''}");

        public string Code { get; set; }
        public string Count { get; set; }
        public string Create_date { get; set; }
        public string Mobile { get; set; }
        public string Msg { get; set; }
        public string Smsid { get; set; }
        public string Uid { get; set; }
    }
}