#define _CRT_SECURE_NO_WARNINGS

#include <iostream>
#include <Windows.h>
#include <string>
#include <cstdio>
#include <stdio.h>
#include <stdlib.h>
#include <fstream>

#include <io.h>

using namespace std;

int main()
{
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);

    /*_findfirst(path, fileinfo);

    _finddata_t*/
    struct _finddata_t my_fileInfo;
        
   

    char path[200] = "D:\\notes\\*.txt";
    char mask[20];

    cout << "Введите путь: ";
    cin >> path;
    cout << "Введите маску: ";
    cin >> mask;

    strcat_s(path, mask);

    long done = _findfirst(path, &my_fileInfo);

        cout << my_fileInfo.name << endl;
    while (done != -1)
    {
        done = _findnext(done, &my_fileInfo);
    }
}