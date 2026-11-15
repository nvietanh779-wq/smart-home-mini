/****************/
// Mã sinh viên: 202419031
// Họ tên: Việt Anh
/****************/

namespace SmartHomeMini
{
    /// <summary>
    /// Bộ kiểm thử tối thiểu T1–T5 (không phụ thuộc thư viện ngoài).
    /// Mỗi test in PASS/FAIL; Run() trả về true nếu tất cả đều đạt.
    /// </summary>
    public static class TestRunner
    {
        private static int passed = 0;
        private static int failed = 0;

        public static bool Run()
        {
            Console.WriteLine("=== KIEM THU ===");
            T1_FactoryCreatesCorrectTypes();
            T2_FactoryRejectsUnsupportedType();
            T3_SingletonSameInstance();
            T4_GoToWork();
            T5_GoToSleep();
            Console.WriteLine($"Ket qua: {passed} PASS, {failed} FAIL");
            return failed == 0;
        }

        // T1: Tạo light, fan, door -> đúng kiểu đối tượng (kể cả khi viết hoa/thường lẫn lộn)
        private static void T1_FactoryCreatesCorrectTypes()
        {
            IDevice light = DeviceFactory.Create("light", "Living room light");
            IDevice fan = DeviceFactory.Create("FAN", "Living room fan");
            IDevice door = DeviceFactory.Create("  Door ", "Main door");

            Report("T1", "Factory tra dung kieu doi tuong",
                light is SmartLight && fan is SmartFan && door is SmartDoor && door is ILockable);
        }

        // T2: Loại camera chưa hỗ trợ -> ArgumentException
        private static void T2_FactoryRejectsUnsupportedType()
        {
            bool thrown = false;
            try
            {
                DeviceFactory.Create("camera", "Garden camera");
            }
            catch (ArgumentException ex)
            {
                thrown = true;
                Console.WriteLine($"  (ngoai le: {ex.Message})");
            }
            Report("T2", "Phat sinh ArgumentException", thrown);
        }

        // T3: Lấy Instance hai lần -> cùng một tham chiếu
        private static void T3_SingletonSameInstance()
        {
            var c1 = HomeConfiguration.Instance;
            var c2 = HomeConfiguration.Instance;
            Report("T3", "Hai bien cung tham chieu mot doi tuong", ReferenceEquals(c1, c2));
        }

        // T4: GoToWork -> đèn tắt, quạt tắt, cửa khóa
        private static void T4_GoToWork()
        {
            string output = Capture(facade => facade.GoToWork());
            string[] expected = { "Living room light: OFF", "Living room fan: OFF", "Main door: LOCKED" };
            Report("T4", "Den tat, quat tat, cua khoa", ContainsInOrder(output, expected));
        }

        // T5: GoToSleep -> quạt tắt, cửa khóa, đèn bật, hiện mức sáng
        private static void T5_GoToSleep()
        {
            string output = Capture(facade => facade.GoToSleep());
            string[] expected =
            {
                "Living room fan: OFF",
                "Main door: LOCKED",
                "Living room light: ON",
                $"Night light level: {HomeConfiguration.Instance.NightLightLevel}%"
            };
            Report("T5", "Quat tat, cua khoa, den bat, hien muc sang", ContainsInOrder(output, expected));
        }

        // ---------- Hàm hỗ trợ ----------

        // Tạo bộ thiết bị bằng Factory, chạy hành động trên Facade và bắt toàn bộ output
        private static string Capture(Action<SmartHomeFacade> action)
        {
            var original = Console.Out;
            var writer = new StringWriter();
            try
            {
                Console.SetOut(writer);
                IDevice light = DeviceFactory.Create("light", "Living room light");
                IDevice fan = DeviceFactory.Create("fan", "Living room fan");
                IDevice door = DeviceFactory.Create("door", "Main door");
                var facade = new SmartHomeFacade(light, fan, (SmartDoor)door);
                action(facade);
            }
            finally
            {
                Console.SetOut(original);
            }
            string result = writer.ToString();
            Console.Write(result); // in lại để quan sát hành vi thiết bị
            return result;
        }

        // Kiểm tra các dòng mong đợi xuất hiện đúng thứ tự
        private static bool ContainsInOrder(string output, string[] expected)
        {
            var lines = output.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            return lines.SequenceEqual(expected);
        }

        private static void Report(string id, string description, bool ok)
        {
            if (ok) passed++; else failed++;
            Console.WriteLine($"[{(ok ? "PASS" : "FAIL")}] {id}: {description}");
        }
    }
}
