#pragma unmanaged
#include "../NativeLibrary/NativeLibrary.h"
#pragma managed

#include "NativeLibraryWrapper.h"
#include <msclr/marshal_cppstd.h>
#include <vcclr.h>

NativeLibraryWrapper::NativeLibraryWrapper()
{
	System::Console::WriteLine("NativeLibraryWrapper::NativeLibraryWrapper() called");
	// The native object is stored on the heap. To be noted that C++/CLI does not support smart pointers.
	this->p_NativeLibrary = new NativeLibrary();
}

NativeLibraryWrapper::~NativeLibraryWrapper()
{
	System::Console::WriteLine("NativeLibraryWrapper::~NativeLibraryWrapper() called");
	this->!NativeLibraryWrapper();
}

NativeLibraryWrapper::!NativeLibraryWrapper()
{
	System::Console::WriteLine("NativeLibraryWrapper::!NativeLibraryWrapper() called");
	// No smart pointer, we have to deallocate the native object....
	delete this->p_NativeLibrary;
}

interface class A
{

};

ref class B:A
{

};

ref class C:B
{

};

ref class D
{

};

void NativeLibraryWrapper::DisplayMessage(System::String^ from, System::String^ message, [System::Runtime::InteropServices::Out] System::String^% answer)
{
	System::Console::WriteLine("NativeLibraryWrapper::DisplayMessage called");

	// The native library function is:
	// void DisplayMessage(const std::wstring& from, const std::wstring& message);
	//
	// We have to marshal System::String to std::wstring
	// This can be easily done by:

	auto nFrom = msclr::interop::marshal_as<std::wstring>(from);
	auto nMessage = msclr::interop::marshal_as<std::wstring>(message);
	std::wstring nAnswer;

	this->p_NativeLibrary->DisplayMessage(nFrom, nMessage, nAnswer);

	answer = msclr::interop::marshal_as<System::String^>(nAnswer);

	System::String^ pStr = gcnew System::String("Stack");

	MyEnum^ pMyEnum = gcnew MyEnum();		// Heap
	MyEnum  myENum;							// Stack 

	B^ pB = gcnew B();
	C^ pC = gcnew C();
	A^ pA = (A^)pB;
	A^ pA = safe_cast<A^>(pB);

	C^ pC2 = dynamic_cast<C^>(pA);

	D^ pD = static_cast<D^>(pA);
}

int NativeLibraryWrapper::MessageBox_(System::IntPtr hWnd, System::String^ text,
	System::String^ caption, unsigned int type)
{
	auto textPtr = System::Runtime::InteropServices::Marshal::StringToHGlobalAnsi(text);
	auto captionPtr = System::Runtime::InteropServices::Marshal::StringToHGlobalAnsi(caption);
	auto nativeHWnd = (HWND)hWnd.ToPointer();

	auto ret = MessageBox(nativeHWnd, (LPCSTR)textPtr.ToPointer(), (LPCSTR)captionPtr.ToPointer(), type);

	System::Runtime::InteropServices::Marshal::FreeHGlobal(textPtr);
	System::Runtime::InteropServices::Marshal::FreeHGlobal(captionPtr);

	return ret;
}