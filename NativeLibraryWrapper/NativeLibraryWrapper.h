#pragma once

// Forward declaration of NativeLibrary. Aka compilation firewall
class NativeLibrary;

// This class will be seen by CLR world
public ref class NativeLibraryWrapper
{
private:
	// Pointer to native library
	NativeLibrary* p_NativeLibrary;

protected:
	// This is a finalizer, called when the garbage collector decide to delete this object
	!NativeLibraryWrapper();

public:
	NativeLibraryWrapper();

	// The desctrutor is called when the user delete the object
	~NativeLibraryWrapper();

	void DisplayMessage(System::String^ from, System::String^ message);
};