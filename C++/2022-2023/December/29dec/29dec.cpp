#include <iostream>
#include <conio.h>
using namespace std;

class Point
{
private:
    double x;
    double y;
public:
    Point(double x, double y) : x{ x }, y{ y }
    {
    }

    Point() : Point{ 0, 0 }
    {
    }

    void display() const
    {
        cout << "(" << x << "," << y << ")";
    }

    void read()
    {
        cin >> x;
        cin.ignore(1); // пропуск запятой между x и y
        cin >> y;
    }

    // ++функции логических операций
    static bool isEqual(const Point& point1, const Point& point2)
    {
        return point1.x == point2.x && point1.y == point2.y;
    }

    static bool isNotEqual(const Point& point1, const Point& point2)
    {
        return !(point1.x == point2.x && point1.y == point2.y);
    }

    static double distance(const Point& point1, const Point& point2)
    {
        return sqrt((point1.x - point2.x) * (point1.x - point2.x) +
            (point1.y - point2.y) * (point1.y - point2.y));
    }

    static double length(const Point& point)
    {
        return distance(point, Point());
    }

    static bool isGreaterThan(const Point& point1, const Point& point2)
    {
        return length(point1) > length(point2);
    }
    // --функции логических операций

    // ++функции арифметических операций
    static const Point add(const Point& point1, const Point& point2)
    {
        return Point(point1.x + point2.x, point1.y + point2.y);
    }

    static const Point subtract(const Point& point1, const Point& point2)
    {
        return Point(point1.x - point2.x, point1.y - point2.y);
    }

    static const Point mult(const Point& point, double value)
    {
        return Point(point.x * value, point.y * value);
    }

    static const Point divide(const Point& point, double value)
    {
        return Point(point.x / value, point.y / value);
    }
    // --функции арифметических операций

    // ++операнды арифметических операций
    friend Point operator+(const Point& point1, const Point& point2)
    {
        return add(point1, point2);
    }

    friend const Point operator-(const Point& point1, const Point& point2)
    {
        return subtract(point1, point2);
    }

    friend const Point operator*(const Point& point, double value)
    {
        return mult(point, value);
    }

    friend const Point operator*(double value, const Point& point)
    {
        return mult(point, value);
    }

    friend const Point operator/(const Point& point, double value)
    {
        return divide(point, value);
    }
    // --операнды арифметических операций

    // ++унарный минус
    const Point operator-()
    {
        return Point(-x, -y);
    }
    // --унарный минус

    // ++перегрузка операторов инкремента и декремента
    // префиксная форма
    Point& operator++()
    {
        ++x; ++y; return *this;
    }

    Point& operator--()
    {
        --x; --y; return *this;
    }

    // постфиксная форма
    const Point operator++(int)
    {
        Point point{ x, y };
        ++(*this);
        return point;
    }

    const Point operator--(int)
    {
        Point point{ x, y };
        --(*this);
        return point;
    }
    // --перегрузка операторов инкремента и декремента

    // ++логические операторы
    friend bool operator==(const Point& point1, const Point& point2)
    {
        return point1.x == point2.x && point1.y == point2.y;
    }

    friend bool operator!=(const Point& point1, const Point& point2)
    {
        return !(point1.x == point2.x && point1.y == point2.y);
    }

    friend bool operator>(const Point& point1, const Point& point2)
    {
        return length(point1) > length(point2);;
    }
    // --логические операторы

    // ++операторы ввода-вывода
    friend ostream& operator<< (ostream& output, const Point& point)
    {
        output << "(" << point.x << "," << point.y << ")";
        return output;
    }

    friend istream& operator>> (istream& input, Point& point)
    {
        input >> point.x;
        input.ignore(1);
        input >> point.y;
        return input;
    }
    // --операторы ввода-вывода

    double operator!()
    {
        return distance(*this, Point());
    }
};

int main()
{
    int x = 1;
    cout << ++(++x) << endl;

    Point point1(1, 1);
    cout << ++(++point1) << endl;

    const Point point2(2, 2);
    Point point3(3, 3);

    cout << "point1: " << point1 << endl;
    cout << "point2 (const): " << point2 << endl;
    cout << "point3: " << point3 << endl;
    cout << endl;

    cout << "point2 == point1: "
        << (point2 == point1) << endl;

    cout << "point2 > point1: "
        << (point2 > point1) << endl;

    cout << "point1 + point2 + point3: "
        << (point1 + point2 + point3) << endl;

    cout << "point2 - point1: "
        << (point2 - point1) << endl;

    cout << "point1 * 5: "
        << (point1 * 5) << endl;

    cout << "3 * point2: "
        << (3 * point2) << endl;

    cout << "-point3 / 5: "
        << (-point3 / 5) << endl;

    cout << "++point1: "
        << ++point1 << endl;

    cout << "point3++: "
        << point3++ << endl;

    cout << "point3: "
        << point3 << endl;

    point1 = point3;

    cout << "point1: "
        << point1 << endl;


    cout << "\nPoint1 = " << point1 << endl;
    cout << "Point2 = " << point2 << endl;

    Point point5{ point1++ };

    cout << "\nPoint1 = " << point1 << endl;
    cout << "Point5 = " << point5 << endl;
    _getch();
    return 0;
}

//#include <iostream>
//#include <Windows.h>
//
//using namespace std;
//
//
//class Date
//{
//private:
//	int day;
//	int month;
//	int year;
//public:
//	Date(int d, int m, int y) : day{ d }, month{ m }, year{ y } {}
//	Date() : Date{ 1,1,1970 } {}
//	Date(const Date& obj) : day{ obj.day }, month{ obj.month }, year{ obj.year } {}
//
//	friend void displayDate(Date date)
//	{
//		cout << (date.day < 10 ? "0" : "") << date.day 
//			<< "." << (date.month < 10 ? "0" : "") << date.month 
//			<< "." << date.year << endl;
//	}
//	bool isLeap() 
//	{
//		return (year % 4 == 0 && year % 100 != 0) || (year % 400);
//	}
//	int getDaysInMonth()
//	{
//		switch (month)
//		{
//		case 1:
//			return 31;
//			break;
//		case 2:
//			return isLeap() ? 29 : 28;
//			break;
//		case 3:
//			return 31;
//			break;
//		case 4:
//			return 30;
//			break;
//		case 5:
//			return 31;
//			break;
//		case 6:
//			return 30;
//			break;
//		case 7:
//			return 31;
//			break;
//		case 8:
//			return 31;
//			break;
//		case 9:
//			return 30;
//			break;
//		case 10:
//			return 31;
//			break;
//		case 11:
//			return 30;
//			break;
//		case 12:
//			return 31;
//			break;
//		default:
//			break;
//		}
//	}
//	int getDaysInYear() { return isLeap() ? 366 : 365; }
//
//	void nextMonth() { month++; }
//	void nextYear() { year++; month = 1; }
//	int getYear() { return year; }
//	int getMonth() { return month; }
//};
//
//class Deposit
//{
//private:
//	float summa;
//	float summaAdd;
//	int daysYear;
//	int days;
//	Date currDate;
//	Date endDate;
//	const float percent = 10;
//public:
//	Deposit(float summa, Date currDate, Date endDate) : summa{ summa }, summaAdd{ 0 }, currDate{ currDate }, endDate{ endDate }
//	{
//		days = currDate.getDaysInMonth();
//		daysYear = currDate.getDaysInYear();
//	}
//	Deposit() : Deposit{ 0, Date(), Date() } {}
//	Deposit(const Deposit& obj) : Deposit{ obj.summa, obj.currDate, obj.endDate} {}
//
//	float calcEndSumma()
//	{
//		do
//		{
//			days = currDate.getDaysInMonth();
//			daysYear = currDate.getDaysInYear();
//			summa += summaAdd + summa * days * (percent / 100) / daysYear;
//			
//			if (currDate.getMonth() == 12)
//				currDate.nextYear();
//			else
//				currDate.nextMonth();
//		} while (currDate.getYear() <= endDate.getYear() && currDate.getMonth() != endDate.getMonth());
//		return summa;
//	}
//
//	void setSummaAdd(float summaAddP) { summaAdd = summaAddP; }
//};
//
//int main()
//{
//	SetConsoleCP(1251);
//	SetConsoleOutputCP(1251);
//	
//	float summa;
//	cout << "Введите сумму вклада: ";
//	cin >> summa;
//
//	int period;
//	do
//	{
//		cout << "Введите срок вклада: ";
//		cin >> period;
//		cout << (period < 1 || period > 5 ? "Введите срок вклада от 1 года до 5 лет!\n" : "");
//	} while (period < 1 || period > 5);
//	
//	int day, month, year;
//	cout << "Введите дату пополнения (в формате DD.MM.YYYY): ";
//	cin >> day;
//	cin.ignore(1);
//	cin >> month;
//	cin.ignore(1);
//	cin >> year;
//	Date addDate{ day,month,year };
//	Date endDate{ day,month,year + period };
//
//	Deposit dep{ summa,addDate,endDate };
//
//	char additionKey;
//	cout << "Будете ли вы пополнять вклад ежемесячно?(Y/N): ";
//	cin >> additionKey;
//	if (toupper(additionKey) == 'Y')
//	{
//		float summa_add;
//		cout << "Введите сумму ежемесячного пополнения: ";
//		cin >> summa_add;
//		dep.setSummaAdd(summa_add);
//	}
//	cout << "\nРезультат: " << dep.calcEndSumma() << endl;
//}