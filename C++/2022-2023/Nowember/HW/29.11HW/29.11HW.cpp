#include <iostream>
#include <Windows.h>
#include <string>
#include <algorithm>
#include <locale.h>

using namespace std;

enum AnimalType
{
    null = -1,
    Cat,
    Dog,
    Parrot
};

class Animal
{
private:
    string type;
    int typeNumber; // для использования enum
    string name;
    unsigned int age;
public:
    Animal(int typeP, string nameP, unsigned int ageP) : typeNumber{ typeP }, name{ nameP }, age{ ageP }
    {
        name = transformToName(name);
        switch (typeNumber)
        {
        case Cat:
            type = "Кошка";
            break;
        case Dog:
            type = "Собака";
            break;
        case Parrot:
            type = "Попугай";
            break;
        default:
            break;
        }
    }
    Animal() : Animal{ -1,"-",0 } {}
    void print()
    {
        cout << "Имя:" << name <<
            "\nТип:" << type <<
            "\nВозраст:" << age << endl;
    }
    string transformToName(string name)
    {
        transform(name.begin(), name.end(), name.begin(), ::tolower);
        name[0] = toupper(name[0]);
        /* второй вариант
        name[0] = toupper(name[0]);
        for (int i = 1; i < name.length(); i++)
        {
            name[i] = tolower(name[i]);
        }
        return name;
        */
        return name;
    }
    int getHumanAge()
    {
        switch (typeNumber)
        {
        case Cat:
            return age * 7;
            break;
        case Dog:
            return age * 5;
            break;
        case Parrot:
            return age * 2;
            break;
        default:
            break;
        }
        // P.S цифры взял из головы, они не точные)
    }
    string getType() { return type; }
    int getTypeNumber() { return typeNumber; }
    string getName() { return name; } 
    int getAge() { return age; }
    void setType(int newTypeNumber)
    {
        switch (newTypeNumber)
        {
        case Cat:
            type = "Кошка";
            break;
        case Dog:
            type = "Собака";
            break;
        case Parrot:
            type = "Попугай";
            break;
        default:
            break;
        }
    }
    void setName(string newName) { name = transformToName(newName); }
    void setAge(int newAge) { age = newAge; }
};

int main()
{
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
    setlocale(LC_ALL, "Russian"); // чтобы toupper() работал с кириллицой

    Animal cat(Cat, "мУсЯ", 5);
    Animal dog(Dog, "Мухтар", 2);
    Animal parrot(Parrot, "Кеша", 2);
    cat.print();
    cout << endl;
    dog.print();
    cout << endl;
    parrot.print();
    cout << endl;

    cat.setAge(6);
    cout << "Возраст кошки в переводе на человеский:" << cat.getHumanAge() << endl;

}