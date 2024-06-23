// pch.h: это предварительно скомпилированный заголовочный файл.
// Перечисленные ниже файлы компилируются только один раз, что ускоряет последующие сборки.
// Это также влияет на работу IntelliSense, включая многие функции просмотра и завершения кода.
// Однако изменение любого из приведенных здесь файлов между операциями сборки приведет к повторной компиляции всех(!) этих файлов.
// Не добавляйте сюда файлы, которые планируете часто изменять, так как в этом случае выигрыша в производительности не будет.

#ifndef PCH_H
#define PCH_H

// Добавьте сюда заголовочные файлы для предварительной компиляции
#include "framework.h"

#endif //PCH_H

extern "C"
{
	_declspec(dllexport) int _stdcall add(int, int);
	_declspec(dllexport) int _stdcall sub(int, int);
	_declspec(dllexport) int _stdcall mult(int, int);
	_declspec(dllexport) double _stdcall divide(int, int);
	_declspec(dllexport) int _stdcall fib(int);
}
