#include <iostream>
#include <iomanip>
#include <Windows.h>

using namespace std;

class Room
{
private:
	int length;
	int width;
	float square;
public:
	Room(int lengthP, int widthP) : length{ lengthP }, width{ widthP } { calcSquare(); }
	Room() : Room{ 0,0 } {}
	Room(const Room& room) : length{ room.length }, width{ room.width }, square{ room.square } { cout << "Copy" << endl; }

	float transferToSquareMeter(float value) { return value / 10000; }
	float calcSquare()
	{
		square = transferToSquareMeter(length * width);
		return square;
	}
	void printSquare()
	{
		cout << "Площадь комнаты:" << square << " м^2" << endl;
	}

	int getLength() { return length; }
	int getWidth() { return width; }
	float getSquare() { return square; }

	Room& setLength(int lengthP)
	{
		length = lengthP;
		calcSquare();
		return *this;
	}
	Room& setWidth(int widthP)
	{
		width = widthP;
		calcSquare();
		return *this;
	}
};

class Flat
{
private:
	const int priceForOneMeter = 80000;
	int roomCount;
	Room* rooms;
	float square;
public:
	Flat(int roomCountP, Room* roomsP) : roomCount{ roomCountP }, rooms{ new Room[roomCountP] }
	{
		for (int i = 0; i < roomCount; i++)
			rooms[i] = roomsP[i];
		calcSquare();
	}
	Flat() : Flat(0, nullptr) {}
	~Flat() { delete[] rooms; }

	float calcSquare()
	{
		float result = 0;
		for (int i = 0; i < roomCount; i++)
		{
			result += rooms[i].getSquare();
		}
		square = result;
		return square;
	}
	double calcFullPrice() { return square * priceForOneMeter; }
	void printSquare()
	{
		cout << "Общая площадь квартиры:" << square << " м^2" << endl;
	}

	int getPriceForOneMeter() { return priceForOneMeter; }
	int getRoomCount() { return roomCount; }
	float getSquare() { return square; }
	Room getRoom(int index) { return rooms[index]; }

};

/* ТЗ
Пользователь вводит количество n комнат: 2

Запрашиваете пользователя ввести:
- Длину и ширину Кухни
- Длину и ширину Коридора
...
- Длину и ширину 1 комнаты
- Длину и ширину 2 комнаты
...

Вывести площадь каждой комнаты и части квартиры (Кухня, коридор и т.д.)
Выводите площадь всей квартиры
Выводить стоимость квартиры (от стоимость м^2 * площадь квартиры)

1. Ввод величин производится в см, а площадь в м^2
2. Выполнить задачу в стиле ООП: класс Квартиры и класс Комнаты
3. Реализовать следующие функции в классе Комната:
    - конструкторы и деструкторы есть
    - геттеры и сеттеры есть
    - вывод площади комнаты есть
    - перевод см^2 в м^2 есть
4. Реализовать следующие функции в классе Квартира:
    - конструкторы и деструкторы есть
    - геттеры и сеттеры а нужны ли они?
    - вывод площади квартиры есть
    - расчет стоимость квартиры есть
5. Переменные в классе Комната: длина и ширина есть
6. Переменные в классе Квартира: стоимость м^2, общая площадь кв., список комнат есть
Room* rooms = new Room[1];
*/
/* Для тестов
2
200
300
400
300
1000
200
500
300
*/
int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	int n = 0;
	while (n <= 0)
	{
		cout << "Введите кол-во комнат:";
		cin >> n;
	}
	int roomCount = 2 + n;
	Room* rooms = new Room[roomCount];

	int length, width;
	cout << "Введите длину кухни:";
	cin >> length;
	cout << "Введите ширину кухни:";
	cin >> width;
	rooms[0].setLength(length).setWidth(width);

	cout << "Введите длину санузла:";
	cin >> length;
	cout << "Введите ширину санузла:";
	cin >> width;
	rooms[1].setLength(length).setWidth(width).calcSquare();

	for (int i = 2; i < roomCount; i++)
	{
		cout << "Введите длину " << i - 1 << " комнаты:";
		cin >> length;
		cout << "Введите ширину " << i - 1 << " комнаты:";
		cin >> width;
		rooms[i].setLength(length).setWidth(width).calcSquare();
	}
	cout << endl;

	for (int i = 0; i < roomCount; i++)
		rooms[i].printSquare();

	Flat flat{ roomCount,rooms };
	flat.printSquare();
	cout << "Полная стоимость квартиры: " << fixed << setprecision(0) << flat.calcFullPrice() << " руб." << endl;

}