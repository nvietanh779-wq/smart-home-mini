/****************/
// Mã sinh viên: 202419031
// Họ tên: Việt Anh
/****************/

namespace SmartHomeMini
{
    /// <summary>Đèn thông minh: chỉ có hành vi bật/tắt.</summary>
    public class SmartLight : IDevice
    {
        private readonly string name; // Tên riêng của thiết bị, truyền qua constructor

        public SmartLight(string name)
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
