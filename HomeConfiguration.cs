/****************/
// Mã sinh viên: 202419031
// Họ tên: Việt Anh
/****************/

namespace SmartHomeMini
{
    /// <summary>
    /// Singleton: cấu hình chung của ngôi nhà, chỉ có một thể hiện duy nhất.
    /// - sealed: không cho kế thừa để tránh tạo ra thể hiện thứ hai thông qua lớp con.
    /// - constructor private: client không thể tự gọi new.
    /// - Lazy&lt;T&gt;: khởi tạo trễ và an toàn luồng.
    /// </summary>
    public sealed class HomeConfiguration
    {
        private static readonly Lazy<HomeConfiguration> lazy =
            new(() => new HomeConfiguration());

        /// <summary>Điểm truy cập toàn cục tới thể hiện duy nhất.</summary>
        public static HomeConfiguration Instance => lazy.Value;

        /// <summary>Tên ngôi nhà.</summary>
        public string HomeName { get; set; } = "My Home";

        /// <summary>Mức sáng đèn ngủ (%).</summary>
        public int NightLightLevel { get; set; } = 30;

        private HomeConfiguration()
        {
        }
    }
}
