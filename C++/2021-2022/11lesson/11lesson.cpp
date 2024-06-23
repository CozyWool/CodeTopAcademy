#include <iostream>
#include <stdlib.h>
#include <clocale>
using namespace std;
#include "Person.h"
#include "Rectangle.h"
int main()
{
    setlocale(0, "");
    /*Person* p1 = new Person(12, 150);
    p1->setSurname("Васин");
    p1->setName("Вася");
    p1->Print();

    Person p2;
    p2.setAge(18);
    p2.setHeight(176);
    p2.setSurname("Иванов");
    p2.setName("Иван");
    cout << endl;
    p2.Print();*/
    
    Rectangle* r1 = new Rectangle(5,5);
    cout << r1->CalcP() << " " << r1->CalcS() << endl;
    r1->PrintRect();
}
