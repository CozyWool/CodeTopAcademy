#include <iostream>
#include <string>
using namespace std;
class Device
{
public:
    virtual double getWeight() = 0;
    virtual double getSize() = 0;
    virtual double getPrice() = 0;
    virtual string getName() = 0;
    virtual string getSerialNumber() = 0;
};
class PC : public Device
{
private:
    double weight;
    double size;
    double price;
    string name;
    string serialNumber;
    string OS;
public:
    PC(double weight,double size, double price, string name, string serialNumber, string OS)
    {
        this->weight = weight;
        this->size = size;
        this->price = price;
        this->name = name;
        this->serialNumber = serialNumber;
        this->OS = OS;
    }
    double getWeight() override
    {
        return weight;
    }
    double getSize() override
    {
        return size;
    }
    double getPrice() override
    {
        return price;
    }
    string getName() override
    {
        return name;
    }
    string getSerialNumber() override
    {
        return serialNumber;
    }
};
class Smartphone : public Device
{
private:
    double weight;
    double size;
    double price;
    double screenSize;
    string name;
    string serialNumber;

public:
    Smartphone(double weight, double size, double price, double screenSize, string name, string serialNumber)
    {
        this->weight = weight;
        this->size = size;
        this->price = price;
        this->screenSize = screenSize;
        this->name = name;
        this->serialNumber = serialNumber;
    }
    double getWeight() override
    {
        return weight;
    }
    double getSize() override
    {
        return size;
    }
    double getPrice() override
    {
        return price;
    }
    string getName() override
    {
        return name;
    }
    string getSerialNumber() override
    {
        return serialNumber;
    }
};
class Headphones : public Device
{
private:
    double weight;
    double size;
    double price;
    string name;
    string serialNumber;
    bool haveBluetooth;
public:
    Headphones(double weight, double size, double price, string name, string serialNumber,bool haveBluetooth)
    {
        this->weight = weight;
        this->size = size;
        this->price = price;
        this->name = name;
        this->serialNumber = serialNumber;
        this->haveBluetooth = haveBluetooth;
    }
    double getWeight() override
    {
        return weight;
    }
    double getSize() override
    {
        return size;
    }
    double getPrice() override
    {
        return price;
    }
    string getName() override
    {
        return name;
    }
    string getSerialNumber() override
    {
        return serialNumber;
    }
};
int main()
{
    setlocale(0, "");
    PC p(10, 20, 30000, "Компьютер", "#001","Windows");
    Smartphone s(0.1, 1, 5000,5, "Телефон", "#002");
    Headphones h(1, 5, 2000, "Наушники", "#003",true);
    
}
