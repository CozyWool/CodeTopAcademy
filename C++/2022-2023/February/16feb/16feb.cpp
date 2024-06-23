#include <iostream>
#include <Windows.h>

using namespace std;

enum CashType
{
	NONE = -1,
	RUB,
	USD,
	EUR
};

class Cash
{
private:
	long money; // рубли, доллары, евро
	//Если использовать unsigned char, то при переводе произойдет переполнение
	long coins; // копейки, центы, евроценты; 
	int type; // Текущий тип денег(rub,usd,euro)
public:
	Cash(long moneyP, long coinsP, int typeP) : money{ moneyP }, coins{ coinsP }, type{ typeP } 
	{
		convertToMoney();
	}
	Cash() : Cash{ 0,0,NONE } {}
	Cash(const Cash& obj) : Cash{ obj.money,obj.coins,obj.type } {}
	Cash(Cash&& obj) noexcept : Cash{ obj.money,obj.coins,obj.type }
	{
		obj.money = 0;
		obj.coins = 0;
	}

	Cash& convertToMoney()
	{
		if (coins < 100)
			return *this;

		money += coins / 100;
		coins %= 100;

		return *this;
	}
	Cash& convertRub() // 1 дол = 74 руб, 1 руб = 100 коп, 1 дол = 100 центов; => 1 цент = 74 коп;
	{
		int exchangeRate = 1;

		coins += money * 100;
		money = 0;
		switch (type)
		{
		case USD:
			exchangeRate = 74;
			break;
		case EUR:
			exchangeRate = 80;
			break;
		default:
			break;
		}

		coins *= exchangeRate;
		money += coins / 100;
		coins %= 100;
		type = RUB;

		return *this;
	}
	Cash& convertDollar() // 1 дол = 74 руб, 1 руб = 100 коп, 1 дол = 100 центов; => 1 цент = 74 коп; Примем, что 1 евро = 1 доллар(1.072)
	{
		int exchangeRate = 1;

		coins += money * 100;
		money = 0;
		switch (type)
		{
		case RUB:
			exchangeRate = 74;
			break;
		default:
			break;
		}
		
		coins /= exchangeRate;
		money += coins / 100;
		coins %= 100;
		type = USD;

		return *this;
	}
	Cash& convertEuro() // 1 евро = 80 руб, 1 руб = 100 коп, 1 евро = 100 евроцентов; => 1 евро = 80 коп; Примем, что 1 доллар = 1 евро(0.9327)
	{
		int exchangeRate = 1;

		coins += money * 100;
		money = 0;
		switch (type)
		{
		case RUB:
			exchangeRate = 80;
			break;
		default:
			break;
		}
		coins /= exchangeRate;
		money = coins / 100;
		coins %= 100;
		type = EUR;

		return *this;
	}
	
	friend ostream& operator<<(ostream& out, const Cash& c)
	{
		switch (c.type)
		{
		case NONE:
			out << c.money << " н/д, "
				<< c.coins << " н/д";
			break;
		case RUB:
			out << c.money << " руб., "
				<< c.coins << " коп.";
			break;
		case USD:
			out << c.money << " USD., "
				<< c.coins << " cent.";
			break;
		case EUR:
			out << c.money << " EUR., "
				<< c.coins << " eurocent.";
			break;
		default:
			break;
		}

		return out;
	}
	Cash& operator()()
	{
		if (coins >= 50)
			money++;
		coins = 0;

		return *this;
	}

	friend bool operator==(const Cash& cash1, const Cash& cash2)
	{
		Cash c1{ cash1 };
		Cash c2{ cash2 };
		c1.convertDollar();
		c2.convertDollar();
		return (c1.money * 100 + c1.coins) == (c2.money * 100 + c2.coins);
	}
	friend bool operator!=(const Cash& cash1, const Cash& cash2)
	{
		return !(cash1 == cash2);
	}
	friend bool operator>(const Cash& cash1, const Cash& cash2)
	{
		Cash c1{ cash1 };
		Cash c2{ cash2 };
		c1.convertDollar();
		c2.convertDollar();
		return (c1.money * 100 + c1.coins) > (c2.money * 100 + c2.coins);
	}
	friend bool operator<(const Cash& cash1, const Cash& cash2)
	{
		Cash c1{ cash1 };
		Cash c2{ cash2 };
		c1.convertDollar();
		c2.convertDollar();
		return (c1.money * 100 + c1.coins) < (c2.money * 100 + c2.coins);
	}
	friend bool operator>=(const Cash& cash1, const Cash& cash2)
	{
		Cash c1{ cash1 };
		Cash c2{ cash2 };
		c1.convertDollar();
		c2.convertDollar();
		return (c1.money * 100 + c1.coins) >= (c2.money * 100 + c2.coins);
	}
	friend bool operator<=(const Cash& cash1, const Cash& cash2)
	{
		Cash c1{ cash1 };
		Cash c2{ cash2 };
		c1.convertDollar();
		c2.convertDollar();
		return (c1.money * 100 + c1.coins) <= (c2.money * 100 + c2.coins);
	}

	friend Cash operator+(const Cash& cash1, const Cash& cash2)
	{
		Cash c1{ cash1 };
		Cash c2{ cash2 };
		c1.convertDollar();
		c2.convertDollar(); 
		long resCoins = (c1.money * 100 + c1.coins) + (c2.money * 100 + c2.coins);
		return { 0,resCoins, USD }; // money = 0, т.к в конструкторе все равно происходит конвертация
	}
	friend Cash operator-(const Cash& cash1, const Cash& cash2)
	{
		Cash c1{ cash1 };
		Cash c2{ cash2 };
		c1.convertDollar();
		c2.convertDollar();
		long resCoins = abs((c1.money * 100 + c1.coins) - (c2.money * 100 + c2.coins));
		return { 0,resCoins, USD };// money = 0, т.к в конструкторе все равно происходит конвертация
	}
	friend Cash operator*(const Cash& cash1, const Cash& cash2)
	{
		Cash c1{ cash1 };
		Cash c2{ cash2 };
		c1.convertDollar();
		c2.convertDollar(); 
		long resCoins = (c1.money * 100 + c1.coins) * (c2.money * 100 + c2.coins);
		resCoins /= (c1.money > 0 || c2.money > 0 ? 100 : 1); // / 100 т.к дважды умножали на 100
		return { 0,resCoins, USD }; // money = 0, т.к в конструкторе все равно происходит конвертация
	}
	friend Cash operator/(const Cash& cash1, const Cash& cash2)
	{
		Cash c1{ cash1 };
		Cash c2{ cash2 };
		c1.convertDollar();
		c2.convertDollar(); 
		long resCoins = (c1.money * 100 + c1.coins) / (c2.money * 100 + c2.coins);
		return { 0,resCoins, USD }; // money = 0, т.к в конструкторе все равно происходит конвертация
	}

};

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	Cash rubles1{ 8,30,RUB };
	Cash rubles2{ 12,70,RUB };
	Cash dollars{ 10,14,USD };
	Cash euro{ 20,54,EUR };

	cout << "Рубли 1: " << rubles1 << endl;
	cout << "Рубли 2: " << rubles2 << endl;
	cout << "Доллары: " << dollars << endl;
	cout << "Евро: " << euro << endl;

	cout << "\n----------------------------------\n" << endl;

	// При подсчетах немного теряются данные из-за целочисленного типа данных
	cout << rubles1 << " + " << rubles2 << " ~ " << (rubles1 + rubles2).convertRub()() << endl;
	cout << rubles1 << " - " << rubles2 << " ~ " << (rubles1 - rubles2).convertRub()() << endl;
	cout << rubles1 << " * " << rubles2 << " ~ " << (rubles1 * rubles2).convertRub()() << endl;
	cout << rubles2 << " / " << rubles1 << " ~ " << (rubles2 / rubles1).convertRub()() << endl;
	cout << rubles1 << " == " << rubles2 << " = " << (rubles1 == rubles2 ? "True" : "False") << endl;
	cout << rubles1 << " > " << rubles2 << " = " << (rubles1 > rubles2 ? "True" : "False") << endl;
	cout << rubles1 << " < " << rubles2 << " = " << (rubles1 < rubles2 ? "True" : "False") << endl;
	cout << rubles1 << " != " << rubles2 << " = " << (rubles1 != rubles2 ? "True" : "False") << endl;

	cout << endl;
	cout << rubles1;
	cout << " после округления: " << rubles1() << endl;
	cout << rubles2;
	cout << " после округления: " << rubles2() << endl;

	cout << "\n----------------------------------\n" << endl;

	cout << dollars << " + " << euro << " = " << (dollars + euro) << endl;
	cout << dollars << " - " << euro << " = " << (dollars - euro) << endl;
	cout << dollars << " * " << euro << " = " << (dollars * euro) << endl;
	cout << euro << " / " << dollars << " = " << (euro / dollars) << endl;
	cout << dollars << " == " << euro << " = " << (dollars == euro ? "True" : "False") << endl;
	cout << dollars << " > " << euro << " = " << (dollars > euro ? "True" : "False") << endl;
	cout << dollars << " < " << euro << " = " << (dollars < euro ? "True" : "False") << endl;
	cout << dollars << " != " << euro << " = " << (dollars != euro ? "True" : "False") << endl;

	cout << endl;
	cout << dollars;
	cout << " после округления: " << dollars() << endl;

	cout << euro;
	cout << " после округления: " << euro() << endl;

	return 0;
}