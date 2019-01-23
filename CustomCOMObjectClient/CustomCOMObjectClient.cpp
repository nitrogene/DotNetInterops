#include <comutil.h>
#include <iostream>
#include <string>

// To set the path to the folder containing the tlb, fo to project 
// settings VC++ Directories/Library Directories
#import "CustomCOMObject.tlb" named_guids


// https ://alala666888.wordpress.com/2010/08/31/c-com-server-and-c-com-client-simple-sample/
int main(int argc, char** argv)
{
	CoInitialize(NULL);
	try
	{
		CustomCOMObject::ISaySomethingPtr pSaySomething;

		// To be noted that the both client and com server must char the same bitness (in this example 64bits)
		// otherwise, the CreateInstance will failed with a "Class is not registered" error.
		auto hRes = pSaySomething.CreateInstance(__uuidof(CustomCOMObject::SaySomething));
		if (FAILED(hRes))
		{
			_com_error err(hRes);
			LPCTSTR errMsg = err.ErrorMessage();


			std::wcout << L"ISaySomethingPtr::CreateInstance failed:" << std::wstring(errMsg) << std::endl;
		}
		else
		{
			pSaySomething->Greet("My name is Bond, Jean-Pierre Bond!");
		}

	}
	catch(...)
	{
		std::cout << "Something strange has happened...";
	}
	CoUninitialize();

	return 0;
}