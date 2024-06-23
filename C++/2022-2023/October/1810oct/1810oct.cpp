#define _CRT_SECURE_NO_WARNINGS

#include <iostream>
#include <Windows.h>
#include <string>
#include <stdio.h>

#include <fstream>

using namespace std;

struct Auto
{
    char mark[10];
    char model[10];
    int power;
    char kpp[10];
    int speed;
};

int main()
{
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
    
    Auto mobil[2];

    FILE* file;
    file = fopen("text.txt", "r");

    string str;
    if (file != NULL)
    {
        int i = 0;
        while (!feof(file))
        {
            fscanf(file, "%s", &mobil[i].mark);
            fscanf(file, "%s", &mobil[i].model);
            fscanf(file, "%d", &mobil[i].power);
            fscanf(file, "%s", &mobil[i].kpp);
            fscanf(file, "%d", &mobil[i].speed);
            i++;
        }
        for (int i = 0; i < 2; i++)
        {
            cout << mobil[i].mark << endl;
            cout << mobil[i].model << endl;
            cout << mobil[i].power << endl;
            cout << mobil[i].kpp << endl;
            cout << mobil[i].speed << endl;
            cout << endl;
        }
        fclose(file);
    }
   /*ifstream in("text.txt");*/

    /*if (in.is_open()) {
        while (getline(in, str)) {
            cout << str << endl;
        }
    }

    in.close();*/
   // ofstream out;
   // out.open("text.txt");

   // string str;
   // if (out.is_open())
   // {
   //     out << "HELLO WORLD!" << endl;
   // }
   // else
   // {
   //     cout << "BYE" << endl;
   // }
   // 

   ///* out.close();*/
   // 
   // 
    //FILE* myFile = nullptr;
    //fopen_s(&myFile, "text.txt", "r");
    //if(myFile != nullptr)
    //{
    ///*
    //    fprintf(myFile, "%s", "hello world");
    //    fprintf(myFile, "\n");*/

    //    char str[10];
    //
    //    int a = 0;

    //    while (!feof(myFile))
    //    {
    //        fscanf(myFile, "%s", &str);
    //    

    //    }

    //    fclose(myFile);

    //    cout << "String:" << str << endl;
    //}
    //else
    //{
    //    cout << "Error Stream" << endl;
    //}
}
