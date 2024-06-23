#include <iostream>
#include <Windows.h>

using namespace std;

class Person
{
private:
	string FIO;
	int age;
public:
	Person(string FIO, int age) : FIO{ FIO }, age{ age } {}
	Person() : Person{ "",0 } {}
	Person(const Person& obj) : Person{ obj.FIO,obj.age } {}
	Person(Person&& obj) noexcept : Person{ obj.FIO,obj.age } 
	{
		obj.FIO = "";
		obj.age = 0;
	}

	string getFIO() { return FIO; }
	int getAge() { return age; }

	void setFIO(string FIO) { this->FIO = FIO; }
	void setAge(int age) { this->age = age; }

	friend ostream& operator<<(ostream& out, const Person& p)
	{
		out << p.FIO << "\t"
			<< p.age;
		return out;
	}

	Person& operator=(const Person& obj)
	{
		if (this == &obj)
			return *this;
		FIO = obj.FIO;
		age = obj.age;

		return *this;
	}

	Person& operator=(Person&& obj) noexcept
	{
		if (this == &obj)
			return *this;
		FIO = obj.FIO;
		age = obj.age;

		obj.FIO = "";
		obj.age = 0;

		return *this;
	}
};

class Flat
{
private:
	int square;
	int price;
	Person* residents;
	int residentsAmount;
public:
	Flat(int square, int price, int residentsAmount, Person* residents) : square{ square }, 
		price{ price }, 
		residentsAmount{ residentsAmount }, 
		residents{ new Person[residentsAmount] }
			
	{
		for (int i = 0; i < residentsAmount; i++)
		{
			this->residents[i] = residents[i];
		}
	}
	Flat() : Flat{ 0,0,0,nullptr } {}
	Flat(const Flat& obj) : Flat{ obj.square,obj.price,obj.residentsAmount,obj.residents } {}
	Flat(Flat&& obj) noexcept : Flat{ obj.square,obj.price,obj.residentsAmount,obj.residents }
	{
		obj.square = 0;
		obj.price = 0;
		obj.residentsAmount = 0;
		obj.residents = nullptr;
	}

	int getSquare() { return square; }
	int getPrice() { return price; }

	void setSquare(int square) { this->square = square; }
	void setPrice(int price) { this->price = price; }

	friend ostream& operator<<(ostream& out, const Flat& f)
	{
		out << "Площадь\tЦена" << endl;
		out << f.square << "\t"
			<< f.price << endl;
		out << "\tЖители" << endl;
		out << "ФИО\t\tВозраст" << endl;
		for (int i = 0; i < f.residentsAmount; i++)
		{
			out << f.residents[i] << endl;
		}
		return out;
	}

	Flat& operator=(const Flat& obj)
	{
		if (this == &obj)
			return *this;
		square = obj.square;
		price = obj.price;
		residentsAmount = obj.residentsAmount;
		residents = new Person[residentsAmount];

		for (int i = 0; i < residentsAmount; i++)
		{
			residents[i] = obj.residents[i];
		}

		return *this;
	}

	Flat& operator=(Flat&& obj) noexcept
	{
		if (this == &obj)
			return *this;
		square = obj.square;
		price = obj.price;
		residentsAmount = obj.residentsAmount;
		residents = new Person[residentsAmount];

		for (int i = 0; i < residentsAmount; i++)
		{
			residents[i] = obj.residents[i];
		}

		obj.square = 0;
		obj.price = 0;
		obj.residentsAmount = 0;
		obj.residents = nullptr;

		return *this;
	}
};

class BlockOfFlats
{
private:
	int size;
	Flat* flats;
public:
	BlockOfFlats(int size, Flat* flats) : size{ size }, flats{ new Flat[size] }
	{
		for (int i = 0; i < size; i++)
		{
			this->flats[i] = flats[i];
		}
	}
	BlockOfFlats() : BlockOfFlats{ 0,nullptr } {}
	BlockOfFlats(const BlockOfFlats& obj) : BlockOfFlats{ obj.size,obj.flats } {}
	BlockOfFlats(BlockOfFlats&& obj) noexcept : BlockOfFlats{ obj.size,obj.flats }
	{
		obj.size = 0;
		obj.flats = nullptr;
	}

	Flat* getFlats() { return flats; }

	BlockOfFlats& setFlats(int size,Flat* flats)
	{ 
		this->size = size; 
		for (int i = 0; i < size; i++)
		{
			this->flats[i] = flats[i];
		}
		return *this;
	}

	friend ostream& operator<<(ostream& out, const BlockOfFlats& bf)
	{
		for (int i = 0; i < bf.size; i++)
		{
			out << bf.flats[i] << endl;
			out << "--------------------------" << endl;
		}
		return out;
	}
};

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	int size = 2;

	Person p1{ "Петров П.П",20 };
	Person p2{ "Сидоров С.С",25 };

	Person p3{ "Иванов И.И",18 };
	Person p4{ "Соколов С.С",24 };

	Flat f1{ 100,3000000,size,new Person[size]{p1,p2} };
	Flat f2{ 150,4000000,size,new Person[size]{p3,p4} };

	BlockOfFlats bf1{ size, new Flat[size]{f1,f2} };
	cout << bf1 << endl;
}