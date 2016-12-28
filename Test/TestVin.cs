#region license
// Vin
// .NET Library for Validating Vehicle Identification Numbers
// Copyright 2016 Dale Newman
//  
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   
//       http://www.apache.org/licenses/LICENSE-2.0
//   
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
#endregion
using DaleNewman;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test {

    [TestClass]
    public class TestVin {

        [TestMethod]
        public void Test17Ones() {
            Assert.IsTrue(Vin.IsValid("11111111111111111"), "Is true because all ones pass.");
        }

        [TestMethod]
        public void Test16Ones() {
            Assert.IsFalse(Vin.IsValid("1111111111111111"), "Is false because it's 16 characters.");
        }

        [TestMethod]
        public void Test18Ones() {
            Assert.IsFalse(Vin.IsValid("111111111111111111"), "Is false because it's 18 characters.");
        }

        [TestMethod]
        public void TestOneThree() {
            Assert.IsFalse(Vin.IsValid("11111111111111113"), "Is false because I changed the last 1 to a 3.");
        }

        [TestMethod]
        public void TestRealVin() {
            Assert.IsTrue(Vin.IsValid("1FTKR1ADXAPA11957"), "Is true because this is a real VIN (I hope)");
        }

        [TestMethod]
        public void TestRealVinWithPInsteadOfF() {
            Assert.IsFalse(Vin.IsValid("1PTKR1ADXAPA11957"), "Is false because I replaced F with P.");
        }

        [TestMethod]
        public void TestInvalidWmi() {
            Assert.AreEqual(string.Empty, Vin.GetWorldManufacturer("111"));
        }

        [TestMethod]
        public void TestFord() {
            Assert.AreEqual("Ford Motor Company", Vin.GetWorldManufacturer("1FD"));
        }

        [TestMethod]
        public void TestInternational() {
            Assert.AreEqual("International", Vin.GetWorldManufacturer("1HT"));
        }

        [TestMethod]
        public void TestToyotaMatchingFirstTwo() {
            Assert.AreEqual("Toyota USA - trucks", Vin.GetWorldManufacturer("5TG"));
        }

        [TestMethod]
        public void TestGetYear() {
            Assert.AreEqual(2001, Vin.GetModelYear("1111111111"));
        }

        [TestMethod]
        public void TestGetYearForA() {
            Assert.AreEqual(2010, Vin.GetModelYear("111111111A"));
        }

        [TestMethod]
        public void TestGetYearForAForceDown() {
            Assert.AreEqual(1980, Vin.GetModelYear("111111111A", 1980));
        }

        [TestMethod]
        public void TestGetYearForK() {
            Assert.AreEqual(1989, Vin.GetModelYear("111111111K"), "This should be 1989 because 2019 vehicles do not exist yet (given now is 2016).");
        }

        [TestMethod]
        public void TestGetYearForD() {
            Assert.AreEqual(2013, Vin.GetModelYear("111111111D"), "This should be 2013 because 1983 is less likely (given now is 2016).");
        }


        [TestMethod]
        public void TestGetYearForDChar() {
            Assert.AreEqual(2013, Vin.GetModelYear('D'), "This should be 2013 because 1983 is less likely (given now is 2016).");
        }
    }
}
