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
using System.Collections.Generic;

namespace DaleNewman {

    public class Vin {

        private const int ValidVinLength = 17;
        private const int CheckDigitIndex = 8;
        // Character weights for 17 characters in VIN
        private static readonly int[] CharacterWeights = { 8, 7, 6, 5, 4, 3, 2, 10, 0, 9, 8, 7, 6, 5, 4, 3, 2 };

        private static readonly Dictionary<char, int> ValidCheckCharacters = new Dictionary<char, int> {
            {'0',0},
            {'1',1},
            {'2',2},
            {'3',3},
            {'4',4},
            {'5',5},
            {'6',6},
            {'7',7},
            {'8',8},
            {'9',9},
            {'X',10}
        };

        // Character transliteration, how to get from characters to numbers
        private static readonly Dictionary<char, int> CharacterTransliteration = new Dictionary<char, int> {
            {'A', 1},
            {'B', 2},
            {'C', 3},
            {'D', 4},
            {'E', 5},
            {'F', 6},
            {'G', 7},
            {'H', 8},
            {'J', 1},
            {'K', 2},
            {'L', 3},
            {'M', 4},
            {'N', 5},
            {'P', 7},
            {'R', 9},
            {'S', 2},
            {'T', 3},
            {'U', 4},
            {'V', 5},
            {'W', 6},
            {'X', 7},
            {'Y', 8},
            {'Z', 9},
            {'1', 1},
            {'2', 2},
            {'3', 3},
            {'4', 4},
            {'5', 5},
            {'6', 6},
            {'7', 7},
            {'8', 8},
            {'9', 9},
            {'0', 0}
        };

        public static bool IsValid(string vin) {

            var value = 0;

            if (vin?.Length != ValidVinLength) {
                return false;
            }

            var checkCharacter = vin[CheckDigitIndex];
            if (!ValidCheckCharacters.ContainsKey(checkCharacter)) {
                return false;
            }

            for (var i = 0; i < ValidVinLength; i++) {
                if (!CharacterTransliteration.ContainsKey(vin[i])) {
                    return false;
                }
                value += (CharacterWeights[i] * (CharacterTransliteration[vin[i]]));
            }

            return (value % 11) == ValidCheckCharacters[checkCharacter];
        }

    }
}
