using Microsoft.VisualStudio.TestTools.UnitTesting;
using CLD3Net;

namespace CLD3Tests
{
    [TestClass]
    public class LanguageTests
    {
        [TestMethod]
        public void LanguageTests_DetectNMostFreqLangs()
        {
            var detector = new LanguageDetector();
            var lang = detector.DetectNMostFreqLangs("NEED TO BLOCK IN THE WHAREHOUSE THE COVERS MANUFACTURED IN THE MILEXX, TO NOT COLLAPSE FINAL INSPECTION. THESE COVERS ARE TO BE STORED AND DEPENDING ON THE RESULTS OF QUALIFICATION IN THE FUTURE WILL BE DECIDED TO DO WITH THEM. NECESIDAD DE BLOQUEAR EN EL ALMACEN LAS CUBIERTAS FABRICADAS EN LA MILEXX PARA NO COLAPSAR INSPECCION FINAL. ESTAS CUBIERTAS SE VAN A ALMACENAR Y DEPENDIENDO DE LOS RESULTADOS DE CUALIFICACION EN EL FUTURO SE DECIDIRA QUE HACER CON ELLAS.", 4);

            var expected1 = new RecognizedResult(
                    "Spanish; Castilian",
                    "es",
                    0.9275986f,
                    1f,
                    true
                    );
            var expected2 = new RecognizedResult(
                    "Undefined Language",
                    "und",
                    0f,
                    0f,
                    false
                    );
            var expected3 = new RecognizedResult(
                    "Undefined Language",
                    "und",
                    0f,
                    0f,
                    false
                    );
            var expected4 = new RecognizedResult(
                    "Undefined Language",
                    "und",
                    0f,
                    0f,
                    false
                    );

            Assert.IsTrue(expected1 == lang[0] && expected2 == lang[1] && expected3 == lang[2] && expected4 == lang[3]);

        }

        [TestMethod]
        public void LanguageTests_DetectLanguage()
        {
            var detector = new LanguageDetector();

            var detectedLanguage = detector.DetectLanguage("THIS IS A SAMPLE TEXT WRITTEN IN SOME LANGUAGE");
            var expected = new RecognizedResult(
                "English",
                "en",
                0.999887466f,
                1f,
                true
                );

            Assert.IsTrue(detectedLanguage == expected);
        }
    }
}
