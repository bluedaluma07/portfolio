namespace Portfolio.Data.Models
{
    public class SystemSetting
    {
        public int SalesAllowStartTime { get; set; }

        public int SalesAllowStopTime { get; set; }

        public string LockerName { get; set; }

        public bool SkipInputFlag { get; set; } = true;

        public bool PointVisible { get; set; } = true;

        public bool UseCreditFlag { get; set; } = false;

        public bool CouponDialogDisplay { get; set; } = true;

        public int SettlementMenuDisplay { get; set; }

        public int CouponMenuDisplay { get; set; }

        public int CongestionMenuDisplay { get; set; }

        public int AccountMenuDisplay { get; set; }
    }
}
