#define PI 3.14

#include <iostream>
#include <Windows.h>
#include <math.h>


using namespace std;

class Circle
{
private:
	double radius;
public:
	Circle(double radiusP) : radius{ radiusP } {}
	Circle() : Circle{ 1 } {}
	Circle(const Circle& obj) : radius{obj.radius} {}
	Circle(Circle&& obj) noexcept : radius{ obj.radius } { obj.radius = 0; }

	double getRadius() const { return radius; }

	double setRadius(double radiusP) { radius = radiusP; }

	friend ostream& operator<<(ostream& out, const Circle c)
	{
		out << c.radius;
		return out;
	}

	friend bool operator==(const Circle& c1, const Circle& c2)
	{
		return c1.radius == c2.radius;
	}
	friend bool operator>(const Circle& c1, const Circle& c2)
	{
		return c1.radius > c2.radius; // не буду домножать на 2П, т.к это не влияет на результат(общий множетель)
	}
	friend bool operator<(const Circle& c1, const Circle& c2)
	{
		return c1.radius < c2.radius; // не буду домножать на 2П, т.к это не влияет на результат(общий множетель)
	}

	Circle& operator+=(int radiusP)
	{
		radius += radiusP;
		return *this;
	}
	Circle& operator-=(int radiusP)
	{
		radius -= radiusP;
		return *this;
	}
};

enum AirplaneType
{
	NONE = -1,
	BOMBER,
	PASSANGER,
	ATTACKER
};
class Airplane
{
private:
	int type;
	int maxPassenger;
	int currPassenger;
public:
	Airplane(int typeP, int maxPassengerP, int currPassengerP) : type{ typeP }, 
		maxPassenger{ maxPassengerP }, currPassenger{currPassengerP} 
	{
		if (currPassenger > maxPassenger)
		{
			currPassenger = maxPassenger;
		}
	}
	Airplane() : Airplane{ NONE,0,0 } {}
	Airplane(const Airplane& obj) : Airplane{ obj.type,obj.maxPassenger,obj.currPassenger } {}
	Airplane(Airplane&& obj) noexcept : Airplane{ obj.type,obj.maxPassenger,obj.currPassenger }
	{
		obj.type = NONE;
		obj.maxPassenger = 0;
		obj.currPassenger = 0;
	}
	
	int getType() { return type; }
	int getMaxPassenger() { return maxPassenger; }
	int getCurrPassenger() { return currPassenger; }

	void setType(int typeP) { type = typeP; }
	void setMaxPassenger(int maxPassengerP) { maxPassenger = maxPassengerP; }
	void setCurrPassenger(int currPassengerP) { currPassenger = currPassengerP; }

	string printType() const
	{
		string str;
		switch (type)
		{
		case NONE:
			str = "Н/Д";
			break;
		case BOMBER:
			str = "Бомбадировщик";
			break;
		case PASSANGER:
			str = "Пассажирский";
			break;
		case ATTACKER:
			str = "Штурмовик";
			break;
		default:
			break;
		}
		return str;
	}

	friend ostream& operator<<(ostream& out, const Airplane a)
	{
		out << "\nТип\t\tМакс.Пассажиров\tТекущее кол-во пассажиров\n"
			<< a.printType() << "\t"
			<< a.maxPassenger << "\t\t"
			<< a.currPassenger << endl;
		return out;
	}

	friend bool operator==(const Airplane& a1, const Airplane& a2)
	{
		return a1.type == a2.type;
	}
	friend bool operator>(const Airplane& a1, const Airplane& a2)
	{
		return a1.maxPassenger > a2.maxPassenger;
	}
	friend bool operator<(const Airplane& a1, const Airplane& a2)
	{
		return a1.maxPassenger < a2.maxPassenger;
	}

	Airplane& operator--()
	{
		if(currPassenger > 0)
			--currPassenger;
		return *this;
	}
	Airplane& operator++()
	{
		if(currPassenger < maxPassenger)
			++currPassenger;
		return *this;
	}

};

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	
	while(true)
	{
		Circle c1{ 5 };
		Circle c2{ 6 };

		Airplane a1{ PASSANGER,100,50 };
		Airplane a2{ BOMBER,3,2 };

		int t;
		cout << "Введите номер задания(1 - 2):";
		cin >> t;
		system("cls");
		switch (t)
		{
		case 1:
			cout << "c1:" << c1 << endl;
			cout << "c2:" << c2 << endl;
			cout << "c1 == c2: " << (c1 == c2 ? "True" : "False") << endl;
			cout << "c1 > c2: " << (c1 > c2 ? "True" : "False") << endl;
			cout << "c1 < c2: " << (c1 < c2 ? "True" : "False") << endl;
			cout << "c1 += 2" << (c1 += 2) << endl;
			cout << "c1 -= 2" << (c1 -= 2) << endl;
			break;
		case 2:
			cout << "a1:" << a1 << endl;
			cout << "a2:" << a2 << endl;
			cout << "a1 == a2: " << (a1 == a2 ? "True" : "False") << endl;
			cout << "a1 > a2: " << (a1 > a2 ? "True" : "False") << endl;
			cout << "a1 < a2: " << (a1 < a2 ? "True" : "False") << endl;
			cout << "++a1:" << ++a1 << endl;
			cout << "--a2:" << --a2 << endl;
			break;
		default:
			break;
		}
		cout << endl;
	}
}