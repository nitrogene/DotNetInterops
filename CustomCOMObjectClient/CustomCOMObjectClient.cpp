#include <comutil.h>
#include <iostream>
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

		auto hRes = pSaySomething.CreateInstance(__uuidof(CustomCOMObject::SaySomething));
		if (FAILED(hRes))
		{
			std::cout << "ISaySomethingPtr::CreateInstance failed:" << hRes << std::endl;
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