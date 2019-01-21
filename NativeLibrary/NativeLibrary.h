#pragma once
#include <string>

class NativeLibrary
{
public:
	void DisplayMessage(const std::wstring& from, const std::wstring& message);
};