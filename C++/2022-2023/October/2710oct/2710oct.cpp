#define _CRT_SECURE_NO_WARNINGS

#include <iostream>
#include <Windows.h>
#include <string>
#include <stdio.h>
#include <stdlib.h>
#include <fstream>
#include <io.h>
#include <math.h>
#include <algorithm>

using namespace std;

void printArr(int* arr, int size)
{
    for (int i = 0; i < size; i++)
    {
        cout << arr[i] << endl;
    }
}

int main()
{
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
    srand(time(NULL));
    string a = "Hello";
    string b = "World";
    cout << (a > b);

   // //long long a, b;
   // //cin >> a >> b; // 13 8
   // //sort(a, b);
   // //long long num = ((a + 1) / (b + 1) * a) + ((b + 1) / (a + 1) * b);
   // //long long cnt = ((a + 1) / (b + 1)) + ((b + 1) / (a + 1));
   // //cout << num / cnt << endl;


   // const int size = 10;
   // int* arr = new int[size];

   // for (int i = 0; i < size; i++)
   // {
   //     arr[i] = rand() % 10;
   // }

   // printArr(arr, size);
   // cout << endl;

   ///* for (int i = 0; i < size - 1; i++)
   //     for (int j = 0; j < size - i - 1; j++)
   //     {
   //         if (arr[j] > arr[j + 1])
   //         {
   //             arr[j] ^= arr[j + 1];
   //             arr[j + 1] ^= arr[j];
   //             arr[j] ^= arr[j + 1];
   //         }
   //     }*/
   // int cnt = 0;
   // 
   // for (int i = 0; i < size - 1; i++)
   // {
   //     for (int j = size - 1; j > i; j--)
   //     {
   //         if (arr[j] > arr[j - 1])
   //         {
   //             arr[j] ^= arr[j - 1];
   //             arr[j - 1] ^= arr[j];
   //             arr[j] ^= arr[j - 1];
   //         }
   //         cnt++;
   //     }
   //     cnt++;
   // }
   // cout << "Кол-во итераций:" << cnt << endl;
   // printArr(arr, size);
   // delete[] arr;
   
}