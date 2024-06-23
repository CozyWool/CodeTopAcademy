#define _CRT_SECURE_NO_WARNINGS

#include <iostream>
#include <Windows.h>

using namespace std;

class Date
{
private:
    int day;
    int month;
    int year;
public:
    Date(int dayP, int monthP, int yearP) : day{ dayP }, month{ monthP }, year{ yearP } {}
    Date() : Date(1, 1, 1970) {}
    Date(const Date& obj) : day{ obj.day }, month{ obj.month }, year{ obj.year } {}
    void print()
    {
        cout << (day < 10 ? "0" : "") << day << "." << (month < 10 ? "0" : "") << month << "." << year << endl;
    }
    void setDay(int dayP) { day = dayP; }
    int getDay() const { return day; }
};

class Product
{
private:
    int number;
    string name;
    int count;
    int price;
public:
    Product(int number, string name, int count, int price) :
        number{ number },
        name{ name },
        count{ count },
        price{ price }
    {}
    Product() : Product(0, "", 0, 0) {}
    Product(const Product& obj) : 
        number{ obj.number }, 
        name{ obj.name }, 
        count{ obj.count }, 
        price{ obj.price } 
    {}

    int getNumber() { return number; }
    string getName() { return name; }
    int getCount() { return count; }
    int getPrice() { return price; }

    void print()
    {
        cout << "\nНомер товара: " << number;
        cout << "\nНазвание товара: " << name;
        cout << "\nКол-во товаров: " << count;
        cout << "\nЦена одного товара: " << price << " руб.";
        cout << endl;
    }
};

class Order
{
private:
    int number;
    Date date;
    Date deliveryDate;
    Date period; // срок
    Product product;
    const double tax = 0.04;
public:
    Order(int number,
        Date date,
        Date deliveryDate,
        Date period,
        Product product) :
        number{ number },
        date{ date },
        deliveryDate{ deliveryDate },
        period{ period },
        product{ product }
    {

    }
    Order() : Order(0, Date(),Date(),Date(),Product()) {}

    int getNumber() { return number; }
    Date getDate() { return date; }
    Date getDeliveryDate() { return deliveryDate; }
    Date getPeriod() { return period; }
    Product getProduct() { return product; }

    void setNumber(int number) { this->number = number; }
    void setDate(Date date) { this->date = date; }
    void setDeliveryDate(Date deliveryDate) { this->deliveryDate = deliveryDate; }
    void setPeriod(Date period) { this->period = period; }
    void setProduct(Product product) { this->product = product; }


    void print()
    {
        cout << "\tЗаказ номер " << number << ":";
        cout << "\nДата заказа: "; date.print();
        cout << "Дата поставки: "; deliveryDate.print();
        cout << "Срок: "; period.print();
        product.print();
        cout << "Налог: " << tax * 100 << "%" << endl;
        cout << "\nПолная цена заказа: " << calcFullPrice() << " руб." << endl;
        cout << "Полная цена заказа с учётом налога: " << calcFullPriceWithTax() << " руб." << endl;
    }
    int calcFullPrice()
    {
        return product.getPrice() * product.getCount();
    }
    int calcFullPriceWithTax()
    {
        return product.getPrice() * product.getCount() * (1 + tax);
    }

};

int main()
{
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);

    // Нашел в интернете, как получить текущую дату
    time_t t = time(nullptr);
    tm* now = localtime(&t);
    int currYear = now->tm_year + 1900;
    int currMonth = now->tm_mon + 1; 
    int currDay = now->tm_mday;

    Order order
    { 
        1,
        Date(currDay,currMonth, currYear),
        Date(currDay + 7, currMonth, currYear),
        Date(currDay + 7, currMonth, currYear),
        Product(1,"Какой-то товар",2,1000) 
    };
    order.print();
}