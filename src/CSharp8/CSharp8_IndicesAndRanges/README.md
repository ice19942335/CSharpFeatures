# Indices and ranges
> https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/member-access-operators#range-operator-

### You can omit any of the operands of the .. operator to obtain an open-ended range:</br>
`a..` is equivalent to `a..^0`</br>
`..b` is equivalent to `0..b`</br>
`..`is equivalent to `0..^0`</br>

### The following table shows various ways to express collection ranges:</br>

| Range operator expression | Description |
| --- | ----------- |
| `..` | All values in the collection. |
| `..end` | Values from the start to the `end` exclusively. |
| `start..` | Values from the `start` inclusively to the end. |
| `start..end` | Values from the `start` inclusively to the `end` exclusively. |
| `^start..` | Values from the `start` inclusively to the end counting from the end. |
| `..^end` | Values from the start to the `end` exclusively counting from the end. |
| `start..^end` | Values from `start` inclusively to `end` exclusively counting from the end. |
| `^start..^end` | Values from `start` inclusively to `end` exclusively both counting from the end. |