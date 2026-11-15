/****************/
// Mã sinh viên: 202419031
// Họ tên: Việt Anh
/****************/

namespace SmartHomeMini
{
    /// <summary>
    /// Facade: cung cấp thao tác mức cao (GoToWork, GoToSleep) cho nhiều thiết bị.
    /// Chỉ phụ thuộc vào abstraction (IDevice, ILockable), không phụ thuộc lớp cụ thể.
    /// Không thay thế các lớp thiết bị: client vẫn điều khiển riêng từng thiết bị được.
    /// </summary>
    public sealed class SmartHomeFacade
    {
        private readonly IDevice light;
        private readonly IDevice fan;
        private readonly ILockable door;

        public SmartHomeFacade(IDevice light, IDevice fan, ILockable door)
        {
            this.light = light;
            this.fan = fan;
            this.door = door;
        }

        /// <summary>Chế độ Đi làm: tắt đèn, tắt quạt, khóa cửa.</summary>
        public void GoToWork()
        {
            light.TurnOff();
            fan.TurnOff();
            door.Lock();
        }

        /// <summary>
        /// Chế độ Đi ngủ: tắt quạt, khóa cửa, bật đèn ngủ,
        /// đọc mức sáng từ HomeConfiguration và thông báo.
        /// </summary>
        public void GoToSleep()
        {
            fan.TurnOff();
            door.Lock();
            light.TurnOn();
            int level = HomeConfiguration.Instance.NightLightLevel;
            Console.WriteLine($"Night light level: {level}%");
        }
    }
}
