namespace Portfolio.Data.Models
{
    public class SearchCouponMasterResponse
    {
        public List<SearchCouponMasterCoupon> coupon_list { get; set; }

        public int result_code { get; set; }

        public string message { get; set; }
    }

    public class SearchCouponMasterCoupon
    {
        public int coupon_code { get; set; }

        public string coupon_name { get; set; }

        public string coupon_expiration { get; set; }

        public int give_count { get; set; }

        public int coupon_unit { get; set; }

        public int UseCount { get; set; }
    }
}
