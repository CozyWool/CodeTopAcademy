#include <iostream>
#include <string>
#include <cstring>
using namespace std;
void append()
{

}
int main()
{
    int m1 = 10;
    int m2 = 5;

    char** ptr = new char* [m1];

    for (int i = 0; i < m1; i++)
    {
        ptr[i] = new char[m2];
    }
    ptr[1][0] = 't';
    char arr[] = "helloworld";
    char** newptr = new char* [m1 + 1];
    newptr[0] = arr;
    
    for (size_t i = 1; i < m1; i++)
    {
        newptr[i] = ptr[i];
    }
    delete[] newptr;
    cout << ptr[0];
   /* ptr_ptrarr[10] = str;

    cout << ptr_ptrarr[10];*/
    /*string str;
    cin >> str;

    char* ptr = new char[str.length()];

    str.copy(ptr, str.length());

    ptr[str.length()] = '\0';

    cout << ptr;*/
    
   /* char str[] = "hello";
    char* ptr = str;
    char* ptr2;
    char ch = 'l';

    int count = 0;
    ptr2 = strchr(ptr, ch);
    
    while (ptr2 != nullptr)
    {
        ptr = ++ptr2;
        ptr2 = strchr(ptr, ch);
        count++;
    }
    cout << count;*/
}