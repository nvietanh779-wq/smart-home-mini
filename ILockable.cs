/****************/
// Mã sinh viên: 202419031
// Họ tên: Việt Anh
/****************/

namespace SmartHomeMini
{
    /// <summary>
    /// Khả năng khóa/mở khóa. Tách riêng khỏi IDevice (nguyên tắc ISP)
    /// vì đèn và quạt không có khả năng khóa.
    /// </summary>
    public interface ILockable
    {
        /// <summary>Khóa.</summary>
        void Lock();

        /// <summary>Mở khóa.</summary>
        void Unlock();
    }
}
