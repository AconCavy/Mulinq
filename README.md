# Mulinq

C# LINQ extensions for collections and for multidimensional arrays.

## Supported frameworks

- .NET Core 3.1
- .NET 6.0


## Installation

```
dotnet add package Mulinq
```

## Functions

### for IEnumerable&lt;T&gt;

- Transform
    - Cumulate
    - Delta
    - SkipEach
    - SplitBy
- Aggregation
    - MaxBy
    - MinBy
    - TryGetFirst
    - TryGetLast
- Other
    - Combine
    - Permute

### for 2D Array

- Transform
    - AsEnumerable
    - Select
    - Where
    - Column
    - Row
- Condition
    - All
    - Any
    - Contains
- Aggregation
    - Sum
    - Average
    - Count
    - Max
    - Min

### for 3D Array

- Transform
    - AsEnumerable
    - Select
    - Where
- Condition
    - All
    - Any
    - Contains
- Aggregation
    - Count
    - Max
    - Min

## License

This library is under the [MIT License](https://github.com/AconCavy/Mulinq/blob/main/LICENSE)
