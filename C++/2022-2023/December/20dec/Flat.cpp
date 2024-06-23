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
		cout << "������� �������:" << square << " �^2" << endl;
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
		cout << "����� ������� ��������:" << square << " �^2" << endl;
	}

	int getPriceForOneMeter() { return priceForOneMeter; }
	int getRoomCount() { return roomCount; }
	float getSquare() { return square; }
	Room getRoom(int index) { return rooms[index]; }

};

/* ��
������������ ������ ���������� n ������: 2

������������ ������������ ������:
- ����� � ������ �����
- ����� � ������ ��������
...
- ����� � ������ 1 �������
- ����� � ������ 2 �������
...

������� ������� ������ ������� � ����� �������� (�����, ������� � �.�.)
�������� ������� ���� ��������
�������� ��������� �������� (�� ��������� �^2 * ������� ��������)

1. ���� ������� ������������ � ��, � ������� � �^2
2. ��������� ������ � ����� ���: ����� �������� � ����� �������
3. ����������� ��������� ������� � ������ �������:
    - ������������ � ����������� ����
    - ������� � ������� ����
    - ����� ������� ������� ����
    - ������� ��^2 � �^2 ����
4. ����������� ��������� ������� � ������ ��������:
    - ������������ � ����������� ����
    - ������� � ������� � ����� �� ���?
    - ����� ������� �������� ����
    - ������ ��������� �������� ����
5. ���������� � ������ �������: ����� � ������ ����
6. ���������� � ������ ��������: ��������� �^2, ����� ������� ��., ������ ������ ����
Room* rooms = new Room[1];
*/
/* ��� ������
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
		cout << "������� ���-�� ������:";
		cin >> n;
	}
	int roomCount = 2 + n;
	Room* rooms = new Room[roomCount];

	int length, width;
	cout << "������� ����� �����:";
	cin >> length;
	cout << "������� ������ �����:";
	cin >> width;
	rooms[0].setLength(length).setWidth(width);

	cout << "������� ����� �������:";
	cin >> length;
	cout << "������� ������ �������:";
	cin >> width;
	rooms[1].setLength(length).setWidth(width).calcSquare();

	for (int i = 2; i < roomCount; i++)
	{
		cout << "������� ����� " << i - 1 << " �������:";
		cin >> length;
		cout << "������� ������ " << i - 1 << " �������:";
		cin >> width;
		rooms[i].setLength(length).setWidth(width).calcSquare();
	}
	cout << endl;

	for (int i = 0; i < roomCount; i++)
		rooms[i].printSquare();

	Flat flat{ roomCount,rooms };
	flat.printSquare();
	cout << "������ ��������� ��������: " << fixed << setprecision(0) << flat.calcFullPrice() << " ���." << endl;

}