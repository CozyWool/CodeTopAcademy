// pch.cpp: файл исходного кода, соответствующий предварительно скомпилированному заголовочному файлу

#include "pch.h"

// При использовании предварительно скомпилированных заголовочных файлов необходим следующий файл исходного кода для выполнения сборки.

_declspec(dllexport) int _stdcall add(int a , int b)
{
	return a + b;
}
_declspec(dllexport) int _stdcall sub(int a, int b)
{
	return a - b;
}
_declspec(dllexport) int _stdcall mult(int a, int b)
{
	return a * b;
}
_declspec(dllexport) double _stdcall divide(int a, int b)
{
	return a / (double)b;
}
_declspec(dllexport) int _stdcall fib(int number)
{
	if (number < 1) return 0;
	if (number == 1) return 1;
	return fib(number - 1) + fib(number - 2);
}