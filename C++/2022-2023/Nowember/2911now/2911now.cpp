#define _CRT_SECURE_NO_WARNINGS

#include <iostream>
#include <Windows.h>

using namespace std;

class Person
{
private:
    char* name;
    uint16_t age;
    uint32_t socialID;
public:
    Person(const char* name, uint16_t age, uint32_t socialID) : name{ name ? new char[strlen(name) + 1] : nullptr },
        age{ age },
        socialID{ socialID }
    {
        if (name)
            strcpy(this->name, name);

        cout << "Person constructred" << endl;
    }
    Person() : Person{ nullptr,0,0 } {}
    Person(const char* name) : Person{ name,0,0 } {}
    Person(const char* name, uint16_t age) : Person{ name,age,0 } {}
    ~Person()
    {
        delete[] name;
        cout << "Person destructred" << endl;
    }
    
    void print()
    {
        if (name)
        {
            cout << "Name:" << name << endl << "Age:" << age << endl << "SocialID:" << socialID << endl;
        }
        else
        {
            cout << "[empty person]" << endl;
        }
    }
    char* getName() { return name; }
    uint16_t getAge() { return age; }
    uint32_t getSocialID() { return socialID; }
    void setName(char* name) { this->name = name; }
    void setAge(uint16_t age) { this->age = age; }
    void setSocialID(uint32_t socialID) { this->socialID = socialID; }
};

int main()
{
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);

    Person nobody;
    nobody.print();
    cout << endl;

    Person person1("Иван");
    child.print();
    cout << endl;

    Person man("Пётр", 24);
    man.print();
    cout << endl;

    Person person("Иван", 20, 3);
    person.print();
    cout << endl;

    //int n; // 0 или 1
    //cin >> n;
    //cout << !n << endl; // 1-ый способ
    //cout << (n ? 0 : 1) << endl; // 2-ой способ
    //cout << abs(n - 1) << endl; // 3-ий способ
    //cout << (n <= 0) << endl; // 4-ый
    //cout << (n + 1) % 2 << endl; // 5-ый
    //cout << 1 - n << endl; // 6-ый
}
