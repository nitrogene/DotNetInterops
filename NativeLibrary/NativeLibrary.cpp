#include <windows.h>
#include <string>
#include "NativeLibrary.h"

void NativeLibrary::DisplayMessage(const std::wstring & from, const std::wstring & message, std::wstring& answer)
{
	MessageBox(0, (LPCWSTR)message.c_str(), (LPCWSTR)from.c_str(), MB_OK);

	answer = L"Job's done from NativeLibrary";
}
