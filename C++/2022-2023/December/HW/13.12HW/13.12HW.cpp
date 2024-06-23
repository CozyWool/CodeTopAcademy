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
            type = "Неизвестно";
            break;
        }
        cout << "Animal " << this << " constructed" << endl;
    }
    Animal(string nameP) : Animal{ null, nameP, 0 } {}
    Animal(string nameP, int ageP) : Animal{ null, nameP, ageP } {}
    Animal() : Animal{ null, "-", 0 } {}
    ~Animal() 
    {
        cout << "Animal " << this << " destructed" << endl;
    }
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
    Animal& setType(int newTypeNumber)
    {
        switch (newTypeNumber)
        {
        case Cat:
            type = "Кот";
            break;
        case Dog:
            type = "Собака";
            break;
        case Parrot:
            type = "Попугай";
            break;
        default:
            type = "Неизвестно";
            break;
        }
        return *this;
    }
    Animal& setName(string newName) 
    { 
        name = transformToName(newName); 
        return *this;
    }
    Animal& setAge(int newAge)
    { 
        age = newAge; 
        return *this;
    }
};

int main()
{
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
    setlocale(LC_ALL, "Russian"); // чтобы toupper() работал с кириллицой

    Animal null;
    Animal cat("МуСя");
    Animal dog("Мухтар", 2);
    Animal parrot(Parrot, "Кеша", 2);
    null.print();
    cout << endl;
    cat.print();
    cout << endl;
    dog.print();
    cout << endl;
    parrot.print();
    cout << endl;

    cat.setAge(6);
    cout << "Возраст кошки в переводе на человеский:" << cat.getHumanAge() << endl;
    cout << endl;
    null.setName("бАРсиК").setType(Cat).setAge(10).print();
}