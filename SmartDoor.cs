/****************/
// Mã sinh viên: 202419031
// Họ tên: Việt Anh
/****************/

namespace SmartHomeMini
{
    /// <summary>
    /// Cửa thông minh: ngoài bật/tắt (IDevice) còn có thể khóa/mở khóa (ILockable).
    /// </summary>
    public class SmartDoor : IDevice, ILockable
    {
        private readonly string name; // Tên riêng của thiết bị, truyền qua constructor

        public SmartDoor(string name)
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

        public void Lock()
        {
            Console.WriteLine($"{name}: LOCKED");
        }

        public void Unlock()
        {
            Console.WriteLine($"{name}: UNLOCKED");
        }
    }
}
