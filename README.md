### Vin

[![NuGet Pre Release](https://img.shields.io/nuget/vpre/Vin.svg?style=plastic)](https://www.nuget.org/packages/Vin)

This is a .NET library for **V**ehicle **I**dentification **N**umbers.

```csharp
    Vin.IsValid("11111111111111111") // --> true
    Vin.GetWorldManufacturer("1J4..............") // --> Jeep
    Vin.GetModelYear(".........D.......") // --> 2013
    Vin.GetModelYear('D') // --> 2013
```

#### Disclaimers

* `IsValid` assumes 9th digit is a check digit<br/>
* `GetWorldManufacturer` using snapshot of <a href="https://en.wikibooks.org/wiki/Vehicle_Identification_Numbers_(VIN_codes)/World_Manufacturer_Identifier_(WMI)">Wikibooks</a> data<br/>
* `GetModelYear` assumes 10th digit is model year