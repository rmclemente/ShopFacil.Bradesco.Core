namespace ShopFacil.Bradesco.Core.Settings
{
    public class ShopFacilSettings
    {
        public const string Settings = nameof(ShopFacilSettings);
        public string MerchantId { get; set; }
        public string Email { get; set; }
        public string SecurityKey { get; set; }
        public string BaseAddress { get; set; }
    }
}
