/****************/
// Mã sinh viên: 202419031
// Họ tên: Việt Anh
/****************/

using SmartHomeMini;

// ---------- Demo: Factory ----------
Console.WriteLine("=== DEMO FACTORY ===");
IDevice light = DeviceFactory.Create("light", "Living room light");
IDevice fan = DeviceFactory.Create("fan", "Living room fan");
IDevice door = DeviceFactory.Create("door", "Main door");

light.TurnOn();
fan.TurnOff();
((ILockable)door).Lock();

// ---------- Demo: Singleton ----------
Console.WriteLine();
Console.WriteLine("=== DEMO SINGLETON ===");
HomeConfiguration config1 = HomeConfiguration.Instance;
HomeConfiguration config2 = HomeConfiguration.Instance;
Console.WriteLine(ReferenceEquals(config1, config2)); // True

// Kiểm tra bắt buộc theo đề
var c1 = HomeConfiguration.Instance;
var c2 = HomeConfiguration.Instance;
if (!ReferenceEquals(c1, c2))
{
    throw new Exception("Singleton implementation is incorrect.");
}

// ---------- Demo: Facade ----------
Console.WriteLine();
Console.WriteLine("=== DEMO FACADE ===");
var facade = new SmartHomeFacade(light, fan, (SmartDoor)door);
Console.WriteLine("-- GoToWork --");
facade.GoToWork();
Console.WriteLine("-- GoToSleep --");
facade.GoToSleep();

// ---------- Kiểm thử T1–T5 ----------
Console.WriteLine();
bool allPassed = TestRunner.Run();
return allPassed ? 0 : 1;
