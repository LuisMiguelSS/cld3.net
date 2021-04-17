using System;
using Newtonsoft.Json;
using CLD3Net;
using System.Collections.Generic;

namespace CLD3WinNET472
{

	public class intermediateLanguage
	{
		public string language;
		public double probability;
		public int is_reliable;
		public double proportion;
	}

	public class cld3WinProcess
    {
		LanguageDetector languageMachine;
		//object languageMachine;
		//MethodInfo detectLanguage;
		Dictionary<string, string> languages = new Dictionary<string, string>() {
	{"ab", "Abkhazian"},
	{"aa", "Afar"},
	{"af", "Afrikaans"},
	{"sq", "Albanian"},
	{"am", "Amharic"},
	{"ar", "Arabic"},
	{"an", "Aragonese"},
	{"hy", "Armenian"},
	{"as", "Assamese"},
	{"ae", "Avestan"},
	{"ay", "Aymara"},
	{"az", "Azerbaijani"},
	{"ba", "Bashkir"},
	{"eu", "Basque"},
	{"be", "Belarusian"},
	{"bn", "Bengali"},
	{"bh", "Bihari"},
	{"bi", "Bislama"},
	{"bs", "Bosnian"},
	{"br", "Breton"},
	{"bg", "Bulgarian"},
	{"my", "Burmese"},
	{"ca", "Catalan"},
	{"ch", "Chamorro"},
	{"ce", "Chechen"},
	{"zh", "Chinese"},
	{"cu", "Church Slavic; Slavonic; Old Bulgarian"},
	{"cv", "Chuvash"},
	{"kw", "Cornish"},
	{"co", "Corsican"},
	{"hr", "Croatian"},
	{"cs", "Czech"},
	{"da", "Danish"},
	{"dv", "Divehi; Dhivehi; Maldivian"},
	{"nl", "Dutch"},
	{"dz", "Dzongkha"},
	{"en", "English"},
	{"eo", "Esperanto"},
	{"et", "Estonian"},
	{"fo", "Faroese"},
	{"fj", "Fijian"},
	{"fi", "Finnish"},
	{"fr", "French"},
	{"gd", "Gaelic; Scottish Gaelic"},
	{"gl", "Galician"},
	{"ka", "Georgian"},
	{"de", "German"},
	{"el", "Greek, Modern (1453-)"},
	{"gn", "Guarani"},
	{"gu", "Gujarati"},
	{"ht", "Haitian; Haitian Creole"},
	{"ha", "Hausa"},
	{"he", "Hebrew"},
	{"hz", "Herero"},
	{"hi", "Hindi"},
	{"ho", "Hiri Motu"},
	{"hu", "Hungarian"},
	{"is", "Icelandic"},
	{"io", "Ido"},
	{"id", "Indonesian"},
	{"ia", "Interlingua (International Auxiliary Language Association)"},
	{"ie", "Interlingue"},
	{"iu", "Inuktitut"},
	{"ik", "Inupiaq"},
	{"ga", "Irish"},
	{"it", "Italian"},
	{"ja", "Japanese"},
	{"jv", "Javanese"},
	{"kl", "Kalaallisut"},
	{"kn", "Kannada"},
	{"ks", "Kashmiri"},
	{"kk", "Kazakh"},
	{"km", "Khmer"},
	{"ki", "Kikuyu; Gikuyu"},
	{"rw", "Kinyarwanda"},
	{"ky", "Kirghiz"},
	{"kv", "Komi"},
	{"ko", "Korean"},
	{"kj", "Kuanyama; Kwanyama"},
	{"ku", "Kurdish"},
	{"lo", "Lao"},
	{"la", "Latin"},
	{"lv", "Latvian"},
	{"li", "Limburgan; Limburger; Limburgish"},
	{"ln", "Lingala"},
	{"lt", "Lithuanian"},
	{"lb", "Luxembourgish; Letzeburgesch"},
	{"mk", "Macedonian"},
	{"mg", "Malagasy"},
	{"ms", "Malay"},
	{"ml", "Malayalam"},
	{"mt", "Maltese"},
	{"gv", "Manx"},
	{"mi", "Maori"},
	{"mr", "Marathi"},
	{"mh", "Marshallese"},
	{"mo", "Moldavian"},
	{"mn", "Mongolian"},
	{"na", "Nauru"},
	{"nv", "Navaho, Navajo"},
	{"nd", "Ndebele, North"},
	{"nr", "Ndebele, South"},
	{"ng", "Ndonga"},
	{"ne", "Nepali"},
	{"se", "Northern Sami"},
	{"no", "Norwegian"},
	{"nb", "Norwegian Bokmal"},
	{"nn", "Norwegian Nynorsk"},
	{"ny", "Nyanja; Chichewa; Chewa"},
	{"oc", "Occitan (post 1500); Provencal"},
	{"or", "Oriya"},
	{"om", "Oromo"},
	{"os", "Ossetian; Ossetic"},
	{"pi", "Pali"},
	{"pa", "Panjabi"},
	{"fa", "Persian"},
	{"pl", "Polish"},
	{"pt", "Portuguese"},
	{"ps", "Pushto"},
	{"qu", "Quechua"},
	{"rm", "Raeto-Romance"},
	{"ro", "Romanian"},
	{"rn", "Rundi"},
	{"ru", "Russian"},
	{"sm", "Samoan"},
	{"sg", "Sango"},
	{"sa", "Sanskrit"},
	{"sc", "Sardinian"},
	{"sr", "Serbian"},
	{"sn", "Shona"},
	{"ii", "Sichuan Yi"},
	{"sd", "Sindhi"},
	{"si", "Sinhala; Sinhalese"},
	{"sk", "Slovak"},
	{"sl", "Slovenian"},
	{"so", "Somali"},
	{"st", "Sotho, Southern"},
	{"es", "Spanish; Castilian"},
	{"su", "Sundanese"},
	{"sw", "Swahili"},
	{"ss", "Swati"},
	{"sv", "Swedish"},
	{"tl", "Tagalog"},
	{"ty", "Tahitian"},
	{"tg", "Tajik"},
	{"ta", "Tamil"},
	{"tt", "Tatar"},
	{"te", "Telugu"},
	{"th", "Thai"},
	{"bo", "Tibetan"},
	{"ti", "Tigrinya"},
	{"to", "Tonga (Tonga Islands)"},
	{"ts", "Tsonga"},
	{"tn", "Tswana"},
	{"tr", "Turkish"},
	{"tk", "Turkmen"},
	{"tw", "Twi"},
	{"ug", "Uighur"},
	{"uk", "Ukrainian"},
	{"ur", "Urdu"},
	{"uz", "Uzbek"},
	{"vi", "Vietnamese"},
	{"vo", "Volapuk"},
	{"wa", "Walloon"},
	{"cy", "Welsh"},
	{"fy", "Western Frisian"},
	{"wo", "Wolof"},
	{"xh", "Xhosa"},
	{"yi", "Yiddish"},
	{"yo", "Yoruba"},
	{"za", "Zhuang; Chuang"},
	{"zu", "Zulu"} ,
	{"und", "Undefined Language"}
};
		Dictionary<string, string> reverseLanguages;

		public cld3WinProcess()
		{
			languageMachine = new LanguageDetector();
			reverseLanguages = new Dictionary<string, string>();
			foreach (var kvp in languages)
			{
				reverseLanguages.Add(kvp.Value, kvp.Key);
			}
		}

		public string run(cld3Input input)
        {
			var r = languageMachine.DetectLanguage(input.Text);
			//var r = (string) detectLanguage.Invoke(languageMachine, new string[] { input.Text });
			var intermediate = JsonConvert.DeserializeObject<intermediateLanguage>(r);
			var output= new cld3Output()
			{
				Iso639 = reverseLanguages[intermediate.language],
				IsReliable = (intermediate.is_reliable == 1),
				Probability = intermediate.probability
			};
			return JsonConvert.SerializeObject(output);
        }

        public void Dispose()
        {

        }
    }
}

