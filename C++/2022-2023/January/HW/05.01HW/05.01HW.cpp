#include <iostream>
#include <Windows.h>
#include <math.h>

using namespace std;

enum OvercoatType
{
	NONE = -1,
	CLOAK,
	RAINCOAT,
	JACKET
};
class Overcoat
{
private:
	int type;
	int price;
public:
	Overcoat(int typeP, int priceP) : type{ typeP }, price{ priceP } {}
	Overcoat() : Overcoat{ NONE,0 } {}
	Overcoat(const Overcoat& obj) : Overcoat{ obj.type,obj.price } {}
	Overcoat(Overcoat&& obj) noexcept : Overcoat{ obj.type,obj.price } 
	{
		obj.type = NONE;
		obj.price = 0;
	}

	string getTypeInStr() const
	{
		string str = "";
		switch (type)
		{
		case NONE:
			str = "Н/Д";
			break;
		case CLOAK:
			str = "Плащ";
			break;
		case RAINCOAT:
			str = "Дождевик";
			break;
		case JACKET:
			str = "Куртка";
			break;
		default:
			break;
		}
		return str;
	}
	int getType() const { return type; }
	int getPrice() const { return price; }

	void setType(int typeP) { type = typeP; }
	void setPrice(int priceP) { price = priceP; }

	Overcoat& operator=(const Overcoat& obj)
	{
		if (this == &obj)
			return *this;
		type = obj.type;
		price = obj.price;

		return *this;
	}
	Overcoat& operator=(Overcoat&& obj) noexcept
	{
		if (this == &obj)
			return *this;
		type = obj.type;
		price = obj.price;

		obj.type = NONE;
		obj.price = 0;

		return *this;
	}
	friend ostream& operator<<(ostream& out, const Overcoat o)
	{
		out << "\nТип\tЦена\n"
			<< o.getTypeInStr() << "\t"
			<< o.price << endl;
		return out;
	}

	friend bool operator==(const Overcoat& o1, const Overcoat& o2)
	{
		return o1.type == o2.type;
	}
	friend bool operator>(const Overcoat& o1, const Overcoat& o2)
	{
		return o1.price > o2.price;
	}
	friend bool operator<(const Overcoat& o1, const Overcoat& o2)
	{
		return o1.price < o2.price;
	}
};

class Flat
{
private:
	int square;
	int price;
public:
	Flat(int squareP, int priceP) : square{ squareP }, price{ priceP } {}
	Flat() : Flat{ NONE,0 } {}
	Flat(const Flat& obj) : Flat{ obj.square,obj.price } {}
	Flat(Flat&& obj) noexcept : Flat{ obj.square,obj.price } 
	{
		obj.square = NONE;
		obj.price = 0;
	}

	int getSquare() const { return square; }
	int getPrice() const { return price; }

	void setSquare(int squareP) { square = squareP; }
	void setPrice(int priceP) { price = priceP; }

	Flat& operator=(const Flat& obj)
	{
		if (this == &obj)
			return *this;
		square = obj.square;
		price = obj.price;

		return *this;
	}
	Flat& operator=(Flat&& obj) noexcept
	{
		if (this == &obj)
			return *this;
		square = obj.square;
		price = obj.price;

		obj.square = NONE;
		obj.price = 0;

		return *this;
	}
	friend ostream& operator<<(ostream& out, const Flat f)
	{
		out << "\nПлощадь\tЦена\n"
			<< f.square << "\t"
			<< f.price << endl;
		return out;
	}

	friend bool operator==(const Flat& f1, const Flat& f2)
	{
		return f1.square == f2.square;
	}
	friend bool operator>(const Flat& f1, const Flat& f2)
	{
		return f1.price > f2.price;
	}
	friend bool operator<(const Flat& f1, const Flat& f2)
	{
		return f1.price < f2.price;
	}
};

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	while (true)
	{
		Overcoat o1{ CLOAK,3000 };
		Overcoat o2{ JACKET,4000 };

		Flat f1{ 150,5000000 };
		Flat f2{ 100,4000000 };


		int t;
		cout << "Введите номер задания(1 - 2):";
		cin >> t;
		system("cls");
		switch (t)
		{
		case 1:
			cout << "o1:" << o1 << endl;
			cout << "o2:" << o2 << endl;
			cout << "o1 == o2: " << (o1 == o2 ? "True" : "False") << endl;
			cout << "o1 > o2: " << (o1 > o2 ? "True" : "False") << endl;
			cout << "o1 < o2: " << (o1 < o2 ? "True" : "False") << endl;
			break;
		case 2:
			cout << "f1:" << f1 << endl;
			cout << "f2:" << f2 << endl;
			cout << "f1 == f2: " << (f1 == f2 ? "True" : "False") << endl;
			cout << "f1 > f2: " << (f1 > f2 ? "True" : "False") << endl;
			cout << "f1 < f2: " << (f1 < f2 ? "True" : "False") << endl;
			break;
		default:
			break;
		}
		cout << endl;
	}
}