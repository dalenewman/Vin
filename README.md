### Vin

[![Build status](https://ci.appveyor.com/api/projects/status/8jk3ws0uql554q5t?svg=true)](https://ci.appveyor.com/project/dalenewman/vin)
[![NuGet Pre Release](https://img.shields.io/nuget/vpre/Vin.svg)](https://www.nuget.org/packages/Vin)

This is a .NET library for **V**ehicle **I**dentification **N**umbers.

#### Usage

```csharp
    Vin.IsValid("11111111111111111") // --> true
    Vin.GetWorldManufacturer("1J4..............") // --> Jeep
    Vin.GetModelYear(".........D.......") // --> 2013
    Vin.GetModelYear('D') // --> 2013
```

#### Notes

* `IsValid` assumes 9th digit is check digit.<br/>
* `GetWorldManufacturer` uses combination of data from <a href="https://en.wikibooks.org/wiki/Vehicle_Identification_Numbers_(VIN_codes)/World_Manufacturer_Identifier_(WMI)">Wikibooks</a> and [here](http://www.autocalculator.org/VIN/WMI.aspx).<br/>
* `GetModelYear` assumes 10th digit is model year.