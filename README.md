# cld3.net
Compact language detector v3 by Google for .NET 5.0
<br>
You can check the original CLD3 project [here](https://github.com/google/cld3).
<br>

### Use
Detecting 3 possible languages:
```csharp
var detector = new CLD3Net.LanguageDetector();
var languages = detector.DetectNMostFreqLangs("Hello, how are you? Привет, как дела?", 3);

// Resulting list of object: RecognizedResult
[
  {
    "languageName": "Russian",
    "languageCode": "ru",
    "probability": 0.9771,
    "is_reliable": 1,
    "proportion": 0.612245
  },
  {
    "languageName": "English",
    "languageCode": "en",
    "probability": 0.998582,
    "is_reliable": 1,
    "proportion": 0.387755
  },
  {
    "languageName": "Undefined",
    "languageCode": "und",
    "probability": 0,
    "is_reliable": 0,
    "proportion": 0
  }
]
```
Detect language:
```csharp
var detector = new CLD3Net.LanguageDetector();
var lang = detector.DetectLanguage("Hello, how are you? Привет, как дела?");

// Resulting object: RecognizedResult
{
  "languageName": "English",
  "language": "en",
  "probability": 0.855358,
  "is_reliable": 1,
  "proportion": 1
}
```
<br>

### Special thanks
 - To ezra100 for the library [(link)](https://gist.github.com/ezra100/ba69ec42600b2baa7430dd53bec3f37c)