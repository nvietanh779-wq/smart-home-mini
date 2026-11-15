/****************/
// Mã sinh viên: 202419031
// Họ tên: Việt Anh
/****************/

namespace SmartHomeMini
{
    /// <summary>Quạt thông minh: chỉ có hành vi bật/tắt.</summary>
    public class SmartFan : IDevice
    {
        private readonly string name; // Tên riêng của thiết bị, truyền qua constructor

        public SmartFan(string name)
        {
            this.name = name;
        }

        public void TurnOn()
        {
            Console.WriteLine($"{name}: ON");
        }

        public void TurnOff()
        {
            Console.WriteLine($"{name}: OFF");
        }
    }
}
