/****************/
// Mã sinh viên: 202419031
// Họ tên: Việt Anh
/****************/

namespace SmartHomeMini
{
    /// <summary>
    /// Abstraction chung của mọi thiết bị trong nhà thông minh.
    /// Client chỉ cần biết giao diện này, không cần biết lớp cụ thể.
    /// </summary>
    public interface IDevice
    {
        /// <summary>Bật thiết bị.</summary>
        void TurnOn();

        /// <summary>Tắt thiết bị.</summary>
        void TurnOff();
    }
}
