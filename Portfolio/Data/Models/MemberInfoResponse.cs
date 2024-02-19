using Newtonsoft.Json;

namespace Portfolio.Data.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class MemberInfoResponse
    {
        public string member_name { get; set; }

        public string member_kana { get; set; }

        public string expiration { get; set; }

        public string gender { get; set; }

        public string birthday { get; set; }

        public string phone_number { get; set; }

        public string class_name { get; set; }

        public int member_point { get; set; }

        public string point_expiration { get; set; }

        public List<MemberInfoCoupon> coupon_list { get; set; }

        public int result_code { get; set; }

        public string message { get; set; }
    }

    public class MemberInfoCoupon
    {
        public int coupon_code { get; set; }

        public string coupon_name { get; set; }

        public int remain_count { get; set; }

        public string coupon_expiration { get; set; }

        public int give_count { get; set; }

        public int coupon_unit { get; set; }

        public int? allow_count { get; set; }
    }

}
