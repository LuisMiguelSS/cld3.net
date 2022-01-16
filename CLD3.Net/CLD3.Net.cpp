#include "CLD3.Net.h"
#include <string>
#include <iostream>

CLD3Net::RecognizedResult^ CLD3Net::LanguageDetector::DetectLanguage(System::String^ text)
{
	auto bytes = Encoding::UTF8->GetBytes( text );
	pin_ptr<Byte> pinnedBytes = &bytes[0];
	auto x = reinterpret_cast<char *>(pinnedBytes);
	std::string utf8NativeString( x );
	Result result = findLanguage( utf8NativeString );

	return gcnew RecognizedResult(result);
}

List<CLD3Net::RecognizedResult^>^ CLD3Net::LanguageDetector::DetectNMostFreqLangs(System::String^ text, int numberOfLangs)
{
	auto bytes = Encoding::UTF8->GetBytes( text );
	pin_ptr<Byte> pinnedBytes = &bytes[0];
	auto x = reinterpret_cast<char *>(pinnedBytes);
	std::string utf8NativeString( x );
	auto languages = findTopNMostFreqLangs(utf8NativeString, numberOfLangs);
	List<CLD3Net::RecognizedResult^>^ recognizedLanguages = gcnew List<CLD3Net::RecognizedResult^>();

	for (int i = 0; i < numberOfLangs; i++)
	{
		recognizedLanguages->Add(
			gcnew CLD3Net::RecognizedResult(languages[i])
		);
	}

	return recognizedLanguages;
}