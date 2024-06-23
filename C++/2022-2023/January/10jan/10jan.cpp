#include <iostream>
#include <Windows.h>
#include "Array.h"

using namespace std;



int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	Array array1;
	Array array2;

	cout << "Size of array1: " << array1.length() << endl;
	cout << "Array1: " << array1 << endl;

	cout << "Size of array2: " << array2.length() << endl;
	cout << "Array2: " << array2 << endl;

	if (array1 == array2)
	{
		cout << "array 1 == array2" << endl << endl;
	}
	else
	{
		cout << "array 1 != array2" << endl << endl;
	}

	cout << "Array array3{array1}; // copy constructor" << endl;
	Array array3{ array1 };
	cout << "Size of array3: " << array3.length() << endl;
	cout << "Array3: " << array3 << endl;
	
	cout << "array1 = array2; // assigment operator" << endl;
	array1 = array2;

	cout << "Array1: " << array1 << endl;
	cout << "Array2: " << array2 << endl;
	cout << "array2[5] = 1000" << endl;
	array2[5] = 1000;
}