#include <iostream>
#include <Windows.h>
#include "Array.h"

using namespace std;

int main()
{
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
    srand(time(NULL));
    Array array;
    array.randomize();
    cout << array << endl;
    array(1);
    cout << "Увеличение на 1: " << array << endl;
    array(10);
    cout << "Увеличение на 10: " << array << endl;
}