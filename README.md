# GuardIt
C# Object Guard Extensions.

## Get strong-typed objects from Excel (XLS or XLSX)

```C#
// Argument guard: throw ArgumentNullException or ArgumentException
_service = service.NotNullArg(nameof(service));
_name = name.NotNullOrWhiteSpaceArg(nameof(name));

// Operation guard: throw InvalidOperationException
var entity = _service.GetEntities().FirstOrDefault();
entity.InvalidOperationIfNull("Custom error message");

// Custom exception
var obj = mapper.Take();
obj.ThrowIf(i => !IsValid(i), () => new MyCustomException("My error message."));