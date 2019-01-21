#pragma unmanaged
#include "../NativeLibrary/NativeLibrary.h"
#pragma managed

#include "NativeLibraryWrapper.h"
#include <msclr/marshal_cppstd.h>

NativeLibraryWrapper::NativeLibraryWrapper()
{
	System::Console::WriteLine("NativeLibraryWrapper::NativeLibraryWrapper called");
	// The native object is stored on the heap. To be noted that C++/CLI does not support smart pointers.
	this->p_NativeLibrary = new NativeLibrary();
}

NativeLibraryWrapper::~NativeLibraryWrapper()
{
	System::Console::WriteLine("NativeLibraryWrapper::~NativeLibraryWrapper called");
	this->!NativeLibraryWrapper();
}

NativeLibraryWrapper::!NativeLibraryWrapper()
{
	System::Console::WriteLine("NativeLibraryWrapper::!NativeLibraryWrapper called");
	// No smart pointer, we have to deallocate the native object....
	delete this->p_NativeLibrary;
}

void NativeLibraryWrapper::DisplayMessage(System::String^ from, System::String^ message)
{
	System::Console::WriteLine("NativeLibraryWrapper::DisplayMessage called");

	// The native library function is:
	// void DisplayMessage(const std::wstring& from, const std::wstring& message);
	//
	// We have to marshal System::String to std::wstring
	// This can be easily done by:

	auto nFrom = msclr::interop::marshal_as<std::wstring>(from);
	auto nMessage = msclr::interop::marshal_as<std::wstring>(message);

	this->p_NativeLibrary->DisplayMessage(nFrom, nMessage);
}