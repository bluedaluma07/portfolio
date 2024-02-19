using Portfolio.Data.Models;
using Newtonsoft.Json;
using RestSharp.Authenticators;
using RestSharp;
using System.Diagnostics;

namespace Portfolio.Services
{
    public class SearchCouponMasterService
    {
        public SearchCouponMasterResponse GetProduct()
        {
            // サンプルデータを作成
            var coupons = new List<SearchCouponMasterCoupon>
            {
                new SearchCouponMasterCoupon
                {
                    coupon_code = 101,
                    coupon_name = "醤油らーめん",
                    coupon_expiration = "2024-12-31",
                    give_count = 1,
                    coupon_unit = 1000,
                    UseCount = 0
                },
                new SearchCouponMasterCoupon
                {
                    coupon_code = 102,
                    coupon_name = "塩らーめん",
                    coupon_expiration = "2024-06-30",
                    give_count = 1,
                    coupon_unit = 800,
                    UseCount = 0
                },
                new SearchCouponMasterCoupon
                {
                    coupon_code = 103,
                    coupon_name = "味噌らーめん",
                    coupon_expiration = "2024-12-31",
                    give_count = 1,
                    coupon_unit = 950,
                    UseCount = 0
                },
            };

            var response = new SearchCouponMasterResponse
            {
                coupon_list = coupons,
                result_code = 0, // 成功を示す例
                message = "クーポンの取得に成功しました。"
            };

            return response;
        }
    }
}
