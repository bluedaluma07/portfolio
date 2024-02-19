using Portfolio.Data.Models;
using Newtonsoft.Json;
using RestSharp.Authenticators;
using RestSharp;
using System.Diagnostics;

namespace Portfolio.Services;

/// <summary>
/// 会員情報取得サービス
/// </summary>
public class MemberInfoService
{
    /// <summary>
    /// 会員情報
    /// </summary>
    MemberInfoResponse memberInfoResponse;

    public MemberInfoService()
    {
        // クーポン情報のリストを作成
        var coupons = new List<MemberInfoCoupon>
            {
                new MemberInfoCoupon
                {
                    coupon_code = 1001,
                    coupon_name = "初回特典クーポン",
                    remain_count = 1,
                    coupon_expiration = "2024/12/31",
                    give_count = 1,
                    coupon_unit = 500,
                    allow_count = null
                },
                new MemberInfoCoupon
                {
                    coupon_code = 1002,
                    coupon_name = "誕生日クーポン",
                    remain_count = 1,
                    coupon_expiration = "2024/12/31",
                    give_count = 1,
                    coupon_unit = 1000,
                    allow_count = 1
                }
            };

        // メンバー情報を設定
        memberInfoResponse = new MemberInfoResponse
        {
            member_name = "山田太郎",
            member_kana = "ヤマダタロウ",
            expiration = "2025/01/01",
            gender = "男性",
            birthday = "1990/01/01",
            phone_number = "090-1234-5678",
            class_name = "ゴールド",
            member_point = 5000,
            point_expiration = "2024/12/31",
            coupon_list = coupons,
            result_code = 0,
            message = "成功"
        };
    }

    /// <summary>
    /// 会員情報取得
    /// </summary>
    /// <returns></returns>
    public async Task<MemberInfoResponse> SendRequestAsync()
    {
        return memberInfoResponse;
    }

    /// <summary>
    /// 会員情報変更
    /// </summary>
    /// <param name="inputModel"></param>
    public void ChangeMemberInfo(MemberInfoInputModel inputModel)
    {
        memberInfoResponse.member_name = inputModel.FirstName + inputModel.LastName;
        memberInfoResponse.phone_number = inputModel.PhoneNumber;
        memberInfoResponse.member_kana = inputModel.FirstNameYomi + inputModel.LastNameYomi;
        memberInfoResponse.gender = inputModel.GenderText;
    }
}
