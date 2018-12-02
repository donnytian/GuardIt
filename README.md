# GuardIt
C# Object Guard Extensions.

## Install
```> dotnet add package GuardIt```

## Dependencies
.NETStandard 1.0


## Examples

```C#
// Argument guard: throw ArgumentNullException or ArgumentException
_service = service.NotNullArg(nameof(service));
_name = name.NotNullOrWhiteSpaceArg(nameof(name));

// Operation guard: throw InvalidOperationException
var entity = _service.GetEntities().FirstOrDefault();
entity.InvalidOperationIfNull("Custom error message");
entity.InvalidOperationIf(e => !IsValid(e), () => "Another custom error message");

// Any other / custom exceptions
var obj = mapper.Take();
obj.ThrowIf(i => !IsValid(i), () => new MyCustomException("My error message."));
