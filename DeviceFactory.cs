/****************/
// Mã sinh viên: 202419031
// Họ tên: Việt Anh
/****************/

namespace SmartHomeMini
{
    /// <summary>
    /// Factory (Simple Factory): tạo thiết bị theo loại do người dùng chọn,
    /// che giấu việc chọn lớp cụ thể và gọi constructor khỏi client.
    /// </summary>
    public static class DeviceFactory
    {
        /// <param name="type">Loại thiết bị: light, fan, door (không phân biệt hoa/thường).</param>
        /// <param name="name">Tên riêng của thiết bị.</param>
        /// <returns>Thiết bị thông qua abstraction IDevice.</returns>
        /// <exception cref="ArgumentException">Loại thiết bị không được hỗ trợ.</exception>
        public static IDevice Create(string type, string name)
        {
            // Trim + ToLowerInvariant để chuỗi vào không phân biệt hoa/thường
            return type.Trim().ToLowerInvariant() switch
            {
                "light" => new SmartLight(name),
                "fan"   => new SmartFan(name),
                "door"  => new SmartDoor(name),
                // Loại không hợp lệ: ném ngoại lệ, không trả về null
                _ => throw new ArgumentException($"Unsupported device type: {type}")
            };
        }
    }
}
