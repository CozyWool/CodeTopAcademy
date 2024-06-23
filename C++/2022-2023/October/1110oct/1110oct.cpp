#include <iostream>
#include <Windows.h>
#include <math.h>

using namespace std;

int main()
{
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);

    int a = 2;
    int b = 4;

    a ^= b;
    b ^= a;
    a ^= b;
    
    cout << "a:" << a << "\nb:" << b << endl;
}