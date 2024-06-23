#define _CRT_SECURE_NO_WARNINGS

#include <iostream>
#include <Windows.h>
#include <string>
#include <stdio.h>
#include <fstream>

using namespace std;

int main()
{
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);

    FILE* binFile;

    char buff[10];

    const int size = 10;
    int arr[size];
    int arrBasic[size]{ 1,2,3,4,5,6,7,8,9,0 };
    int min, max;
    int imax, imin, i;

    binFile = fopen("testBinary.dat", "rb+");
    
    if (binFile != NULL)
    {
        fwrite(&arrBasic, sizeof(int), size, binFile);
        fread(&arr, sizeof(int), size, binFile);
        for (int i = 0; i < size; i++)
        {
            cout << arr[i] << endl;
        }
        cout << endl;
        for (imax = imin = 0, max = min = arr[0], i = 1; i < size; i++)
        {
            if (arr[i] > max)
            {
                max = arr[i];
                imax = i;
            }
            if (arr[i] < min)
            { 
                min = arr[i];
                imin = i;
            }
        }
        fseek(binFile, sizeof(int) + imax * sizeof(int), SEEK_SET);
        fwrite(&min, sizeof(int), 1, binFile);

        fseek(binFile, sizeof(int) + imin * sizeof(int), SEEK_SET);
        fwrite(&min, sizeof(int), 1, binFile);

        fread(&arr, sizeof(int), size, binFile);
        for (int i = 0; i < size; i++)
        {
            cout << arr[i] << endl;
        }
        //fwrite(&arr, sizeof(int), size, binFile);
        /*for (int i = 0; i < size; i++)
        {
            fwrite(&arr, sizeof(int), 1, binFile);
        }*/
        fclose(binFile);
    }
    /*fgetpos();
    fseek();*/

    /*fwrite("Key Logger!", sizeof(string), 10, binFile);*/
    /*int a = fgetc(file);*/
    /*int a = fputc(10545, file);*/
}
