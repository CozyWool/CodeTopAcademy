#include <iostream>
#include <Windows.h>

using namespace std;

class Student
{
private:
	string FIO;
	string birthDate;
	string telefonNumber;
	string town;
	string country;
	string universityName;
	int groupNumber;
	int* grades;
	int gradesCount;
	float avrGrade;
	string diploma;
	bool stipend;
public:
	Student(string FIO,
		string birthDate,
		string telefonNumber,
		string town,
		string country,
		string universityName,
		int groupNumber,
		int* grades,
		int gradesCount) :
		FIO{ FIO },
		birthDate{ birthDate },
		telefonNumber{ telefonNumber },
		town{ town },
		country{ country },
		universityName{ universityName },
		groupNumber{ groupNumber },
		gradesCount{ gradesCount },
		grades{ new int[gradesCount]}
	{
		for (int i = 0; i < gradesCount; i++)
		{
			this->grades[i] = grades[i];
		}
		averageGrade();
		defineDiploma();
		stipend = isGettingStipend();
	}
	Student() : Student("","","","","","",0,nullptr,0) {}
	~Student() { delete[] grades; }

	void print()
	{
		cout << "ФИО: " << FIO
			<< "\nДата рождения: " << birthDate
			<< "\nНомер телефона: " << telefonNumber
			<< "\nГород: " << town
			<< "\nСтрана: " << country
			<< "\nНазвание ВУЗ: " << universityName
			<< "\nНомер группы: " << groupNumber
			<< "\nСредняя оценка студента: " << avrGrade
			<< "\nДиплом: " << diploma
			<< "\nСтипендия: " << (stipend ? "Получает" : "Не получает")
			<< "\nОценки за экзамены: ";
		for (int i = 0; i < gradesCount; i++)
		{
			cout << grades[i] << " ";
		}
		cout << endl;
	}
	float averageGrade()
	{
		float sum = 0;
		for (int i = 0; i < gradesCount; i++)
		{
			sum += grades[i];
		}
		avrGrade = sum / gradesCount;
		return avrGrade;
	}
	string defineDiploma()
	{
		avrGrade = averageGrade();
		if (avrGrade >= 4.75)
			diploma = "Красный диплом";
		else if (avrGrade > 2)
			diploma = "Синий диплом";
		else
			diploma = "Н/д";
		return diploma;
	}
	bool isGettingStipend()
	{
		bool key = true; // в данный момент получает стипендию
		int i = 0;
		while(i < gradesCount && key)
		{
			if (grades[i] < 4)
				key = false; // найдена оценка меньше 4-ёх, стипендию не получает
			i++;
		}
		return key; // возращаем ответ
	}

	string getFIO() { return FIO; }
	string getBirthDate() { return birthDate; }
	string getTelefonNumber(){return telefonNumber;}
	string getTown() { return town; }
	string getCountry() { return country; }
	string getUniversityName() { return universityName; }
	int getGroupNumber() { return groupNumber; }
	int* getGrades() { return grades; }

	void setFIO() { this->FIO = FIO; }
	void setBirthDate() { this->birthDate = birthDate; }
	void setTelefonNumber() { this->telefonNumber = telefonNumber; }
	void setTown() { this->town = town; }
	void setCountry() { this->country = country; }
	void setUniversityName() { this->universityName = universityName; }
	void setGroupNumber() { this->groupNumber = groupNumber; }
	void setGrades(int* grades,int gradesCount) 
	{ 
		this->gradesCount = gradesCount;
		this->grades = new int[gradesCount];
		for (int i = 0; i < gradesCount; i++)
		{
			this->grades[i] = grades[i];
		}
	}

};

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	int size = 3;
	Student std
	{
		"Петров П.П",
		"20.03.92",
		"8800553535",
		"Тюмень",
		"Россия",
		"ТИУ",
		1,
		new int[size] {4, 4, 5},
		size
	};
	std.print();
}
//#include <iostream>
//#include <Windows.h>
//#include <math.h>
//
//using namespace std;
//
//class RectTriangle
//{
//private:
//	float a;
//	float b;
//	float c;
//public:
//	RectTriangle(float a, float b, float c) : a{ a }, b{ b }, c{ c } {}
//	RectTriangle(float a, float b) : RectTriangle(a, b, 0) {}
//	RectTriangle() : RectTriangle(0, 0, 0) {}
//	
//	float getA() { return a; }
//	float getB() { return b; }
//	float getC() { return c; }
//	void setA(float newA) { this->a = newA; }
//	void setB(float newB) { this->b = newB; }
//	void setC(float newC) { this->c = newC; }
//	float calcC()
//	{
//		c = sqrt(a * a + b * b);
//		return c;
//	}
//	float calcTg()
//	{
//		return float(a) / b;
//	}
//	void print()
//	{
//		cout << "A:" << a << endl;
//		cout << "B:" << b << endl;
//		cout << "C:" << c << endl;
//	}
//};
//
//int main()
//{
//	SetConsoleCP(1251);
//	SetConsoleOutputCP(1251);
//
//	float a, b;
//	cout << "Введите катеты треугольника с гипотенузой AO:";
//	cin >> a >> b;
//	RectTriangle triangleAO{ a,b };
//	cout << "Введите катеты треугольника с гипотенузой OB:";
//	cin >> a >> b;
//	RectTriangle triangleOB{ a,b };
//	cout << "Введите катеты треугольника с гипотенузой AB:";
//	cin >> a >> b;
//	RectTriangle triangleAB{ a,b };
//
//	RectTriangle triangleAOB{ triangleAB.calcC(),triangleAO.calcC(),triangleOB.calcC() };
//	cout << triangleAOB.calcTg() << endl;
//	triangleAOB.print();
//
//}