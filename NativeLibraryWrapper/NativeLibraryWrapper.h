#pragma once

// Forward declaration of NativeLibrary. Aka compilation firewall
class NativeLibrary;


public interface class DisplayMessageInterface
{
	void DisplayMessage(System::String^ from, System::String^ message, [System::Runtime::InteropServices::Out] System::String^% answer);
};

public value struct MyStruct
{
	System::String^ from;
	System::String^ message;
};

public enum struct MyEnum
{
	UN, DOS, TRES
};


// This class will be seen by CLR world
public ref class NativeLibraryWrapper:DisplayMessageInterface	// :IDisposable, automatically added by compiler
{
private:
	// Pointer to native library
	NativeLibrary* p_NativeLibrary;

protected:
	// This is a finalizer, called when the garbage collector decides to delete this object
	!NativeLibraryWrapper();			// converted to virtual void Finalize() by compiler;

public:
	NativeLibraryWrapper();

	// The destructor is called when the user delete the object
	~NativeLibraryWrapper();			// converted to IDispposable.Dispose() by compiler;

	static int MessageBox_(System::IntPtr hWnd, System::String^ text,
		System::String^ caption, unsigned int type);

	virtual void DisplayMessage(System::String^ from, System::String^ message, [System::Runtime::InteropServices::Out] System::String^% answer);
};

