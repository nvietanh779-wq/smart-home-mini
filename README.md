# Smart Home Mini – Bài thực hành 10

Ứng dụng console C# (.NET 8) điều khiển ngôi nhà thông minh với ba thiết bị: `SmartLight`, `SmartFan`, `SmartDoor`, áp dụng ba pattern **Factory**, **Singleton**, **Facade**.

## Chạy chương trình

```bash
dotnet run
```

Chương trình in phần demo, sau đó chạy kiểm thử T1–T5 và trả về mã thoát 0 nếu tất cả đạt.

## Cấu trúc

| File | Vai trò |
|---|---|
| `IDevice.cs`, `ILockable.cs` | Abstraction: bật/tắt; khóa/mở khóa |
| `SmartLight.cs`, `SmartFan.cs`, `SmartDoor.cs` | Thiết bị cụ thể |
| `DeviceFactory.cs` | Pattern Factory |
| `HomeConfiguration.cs` | Pattern Singleton |
| `SmartHomeFacade.cs` | Pattern Facade |
| `TestRunner.cs` | Kiểm thử T1–T5 |
| `Program.cs` | Demo + chạy kiểm thử |

## Vị trí sử dụng, lợi ích và hạn chế

| Pattern | Vị trí sử dụng | Lợi ích đạt được |
|---|---|---|
| Factory | `DeviceFactory.Create(type, name)` | Client tạo thiết bị qua chuỗi loại và nhận về `IDevice`, không gọi constructor cụ thể; chuỗi không phân biệt hoa/thường; loại sai gây `ArgumentException`. |
| Singleton | `HomeConfiguration.Instance` | Toàn ứng dụng dùng chung một cấu hình (`HomeName`, `NightLightLevel`); `Lazy<T>` giúp khởi tạo trễ và an toàn luồng. |
| Facade | `SmartHomeFacade.GoToWork()`, `GoToSleep()` | Client kích hoạt chế độ chỉ bằng một lời gọi; facade chỉ phụ thuộc `IDevice`/`ILockable`, vẫn cho phép điều khiển từng thiết bị riêng. |

**Một hạn chế của thiết kế:** `SmartHomeFacade.GoToSleep()` đọc trực tiếp `HomeConfiguration.Instance` nên facade bị gắn chặt với một Singleton toàn cục, khó thay cấu hình giả khi kiểm thử. Ngoài ra, thêm thiết bị mới (ví dụ `SmartCamera`) buộc phải sửa `DeviceFactory` (vi phạm Open/Closed).

## Phần G – Câu hỏi trả lời

**1. Factory đang che giấu quyết định thiết kế nào?**
Quyết định *lớp cụ thể nào* được tạo ứng với từng loại thiết bị và cách khởi tạo chúng (constructor, tham số). Client chỉ biết chuỗi loại và kiểu trả về `IDevice`.

**2. Singleton bảo đảm điều gì, nhưng tạo ra rủi ro nào?**
Bảo đảm chỉ có đúng một thể hiện và một điểm truy cập toàn cục. Rủi ro: trạng thái toàn cục ẩn khiến các lớp phụ thuộc ngầm vào nó, khó unit test (trạng thái rò rỉ giữa các test, khó thay bằng đối tượng giả), và dễ gây ràng buộc chặt/đa luồng nếu có thuộc tính thay đổi được.

**3. Facade khác Factory ở mục đích chính như thế nào?**
Factory là pattern *khởi tạo*: tách việc tạo đối tượng khỏi client. Facade là pattern *cấu trúc*: đưa ra giao diện đơn giản cho một nhóm thao tác trên nhiều đối tượng đã có.

**4. Nếu bỏ `SmartHomeFacade`, client sẽ phải biết thêm những chi tiết nào?**
Client phải biết có những thiết bị nào tham gia mỗi chế độ, thứ tự gọi (ví dụ đi ngủ: tắt quạt → khóa cửa → bật đèn), thiết bị nào có khả năng khóa (`ILockable`), và phải tự đọc `NightLightLevel` từ `HomeConfiguration` rồi thông báo mức sáng.

## Trả lời câu hỏi phân tích (Phần C, D)

- **Factory che giấu gì?** Lớp cụ thể và việc gọi constructor; client chỉ làm việc với `IDevice`.
- **Thêm `SmartCamera` cần sửa gì?** Thêm lớp `SmartCamera : IDevice`, và thêm một nhánh `"camera"` trong `DeviceFactory.Create`. Client, `IDevice` và facade không phải sửa.
- **Constructor của Singleton:** `private`.
- **Vì sao `sealed`?** Ngăn lớp con kế thừa rồi tạo thêm thể hiện, phá vỡ tính duy nhất.
- **Khó khăn cho unit test:** trạng thái dùng chung giữa các test, không thể inject bản giả.
- **Dùng `AddSingleton` của DI:** không còn bắt buộc tự cài Singleton; container quản lý vòng đời và vẫn giữ một thể hiện, đồng thời dễ inject/thay thế khi test.
