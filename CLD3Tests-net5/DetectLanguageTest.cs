﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CLD3Tests
{
    [TestClass]
    public class LangugaTests
    {
        [TestMethod]
        public void LangugaTests_DetectNMostFreqLangs()
        {
            var detector = new CLD3Net.LanguageDetector();
            var lang = detector.DetectNMostFreqLangs("NEED TO BLOCK IN THE WHAREHOUSE THE COVERS MANUFACTURED IN THE MILEXX, TO NOT COLLAPSE FINAL INSPECTION. THESE COVERS ARE TO BE STORED AND DEPENDING ON THE RESULTS OF QUALIFICATION IN THE FUTURE WILL BE DECIDED TO DO WITH THEM. NECESIDAD DE BLOQUEAR EN EL ALMACEN LAS CUBIERTAS FABRICADAS EN LA MILEXX PARA NO COLAPSAR INSPECCION FINAL. ESTAS CUBIERTAS SE VAN A ALMACENAR Y DEPENDIENDO DE LOS RESULTADOS DE CUALIFICACION EN EL FUTURO SE DECIDIRA QUE HACER CON ELLAS.", 4);
            Assert.AreEqual("[{\"language\":\"Spanish; Castilian\",\"probability\":0.927599,\"is_reliable\":1,\"proportion\":1.000000},{\"language\":\"Undefined Language\",\"probability\":0.000000,\"is_reliable\":0,\"proportion\":0.000000},{\"language\":\"Undefined Language\",\"probability\":0.000000,\"is_reliable\":0,\"proportion\":0.000000},{\"language\":\"Undefined Language\",\"probability\":0.000000,\"is_reliable\":0,\"proportion\":0.000000}]", lang);
        }
    }
}
