namespace Portfolio.Data.Models;

public class CouponTicketSalesRequest
{
    public int member_no { get; set; }

    public List<CouponTicketSalesCoupon> coupon_list { get; set; }

    public string service_name { get; set; }
}

public class CouponTicketSalesCoupon
{
    public int coupon_code { get; set; }

    public int count { get; set; }

}
