namespace Explorer.Payments.API.Internal
{
    public interface IInternalCouponService
    {
        bool IsCoupnValid(string couponHash);
        bool CheckIfAutorApplies(long id, string couponHash);
        void SetCouponToInvalid(string couponHash);
        bool CheckIfIsApplicableToAll(string couponHash);
        double GetDiscounyByCouponHash(string couponHash);
        int GetTourByCouponHash(string couponHash);
    }
}
