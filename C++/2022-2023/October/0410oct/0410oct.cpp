#include <iostream>
#include <Windows.h>
#include <string>
#include <math.h>

using namespace std;

int main()
{
    /*Есть дом, в котором есть несколько подъездов. В каждом подъезде есть 
    одинаковое количество квартир. Квартиры нумеруются подряд. 
    В каком-то подъезде может ли некоторая первая квартира иметь номер x
    а последняя номер y*/
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);

    #define Odd(a) (a % 2 == 0)
    #define NotOdd(a) (a % 2 == 1)

    #define Square(n) n*n
    #define Pow(n,m) pow(n,m)

    cout << (Odd(4) ? "Odd" : "Not odd") << endl;
    cout << (NotOdd(5) ? "Not odd" : "Odd") << endl;

    cout << Square(5) << endl;
    cout << Pow(2,10) << endl;

    /*#define More(a,b) ((a > b) ? a : b)
    #define Less(a,b) ((a < b) ? a : b)
    #define Str(a,b) #a###b

    cout << More(22, 17) << endl;
    cout << Less(22, 17) << endl;
    cout << Str(hello, world);*/

    /*#define N 10
    int n;
    for (int i = 0; i < N; i++)
    {
        cin >> n;
    }
    */
  /*  #define KEY true

    #if KEY
        int a = 5;
        cout << a << endl;
    #else   
        int b = 19;
        cout << b << endl;
    #endif*/


    /*int x, y;
    cout << "Введите номер первой квартиры: ";
    cin >> x;
    cout << "Введите номер последней квартиры: ";
    cin >> y;
    
    int sizeInOne = y - x + 1;
    cout << (y % (y - x + 1) == 0 ? "yes" : "no") << endl;*/
}