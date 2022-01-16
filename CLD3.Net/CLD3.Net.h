#pragma once
#include "Resource.h"
#include <list>

using namespace System;
using namespace System::Text;
using namespace System::Collections::Generic;

namespace CLD3Net
{
	public ref struct RecognizedResult
	{
		// Attributes
		String^ languageName;
		String^ languageCode;
		float probability = 0.0;
		float proportion = 0.0;
		bool isReliable = false;

		// Constructors
		RecognizedResult(Result result) : RecognizedResult(
			gcnew String(codeToLangName[result.languageCode].c_str()),
			gcnew String(result.languageCode.c_str()),
			result.probability,
			result.proportion,
			result.is_reliable
		) {};

		RecognizedResult(
			String^ languageName,
			String^ languageCode,
			float probability,
			float proportion,
			bool isReliable
		)
		{
			this->languageName = languageName;
			this->languageCode = languageCode;
			this->probability = probability;
			this->proportion = proportion;
			this->isReliable = isReliable;
		};

		// Override Equals method
		static bool operator==(RecognizedResult^ a, RecognizedResult^ b)
		{
			return a->languageCode == b->languageCode &&
				a->languageName == b->languageName &&
				a->probability == b->probability &&
				a->proportion == b->proportion &&
				a->isReliable == b->isReliable;
		};
	};

	public ref class LanguageDetector
	{
	public:
		RecognizedResult^ DetectLanguage(String^ text);
		List<RecognizedResult^>^ DetectNMostFreqLangs(String^ text, int numberOfLangs);
	};
}
