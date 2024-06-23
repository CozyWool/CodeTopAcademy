#include <iostream>
#include <Windows.h>
#include <stdlib.h>
#include <algorithm>

using namespace std;

enum WorkerParam
{
	FIO,
	AGE,
	EXP,
	POST,
	SALARY
};

class Worker
{
private:
	string fio;
	int age;
	int exp;
	string post;
	int salary;
public:
	Worker(string fio, int age, int exp, string post, int salary) :
		fio{ fio },
		age{ age },
		exp{ exp },
		post{ post },
		salary{ salary } 
	{
		
	}
	Worker() : Worker{ "",0,0,"",0 } {}
	Worker(const Worker& obj) :
		fio{ obj.fio },
		age{ obj.age },
		exp{ obj.exp },
		post{ obj.post },
		salary{ obj.salary }
	{
		//cout << "Copy constructed for " << this << endl;
	}
	Worker(Worker&& obj) noexcept : 
		fio{ obj.fio },
		age{ obj.age },
		exp{ obj.exp },
		post{ obj.post },
		salary{ obj.salary }
	{
		obj.fio = "";
		obj.age = 0;
		obj.exp = 0;
		obj.post = "";
		obj.salary = 0;
		//cout << "Move constructed for " << this << endl;
	}
	~Worker()
	{
		// cout << "Destructed for " << this << endl;
	}

	string getFio() { return fio; }
	int getAge() { return age; }
	int getExp() { return exp; }
	string getPost() { return post; }
	int getSalary() { return salary; }
	
	void setFio(string fio) { this->fio = fio; }
	void setAge(int age) { this->age = age; }
	void setExp(int exp) { this->exp = exp; }
	void setPost(string post) { this->post = post; }
	void setSalary(int salary) { this->salary = salary; }

	friend ostream& operator<<(ostream& out, const Worker work)
	{
		out << work.fio << "\t"
			<< work.age << "\t"
			<< work.exp << "\t"
			<< work.post << "\t"
			<< work.salary << "\t"
			<< endl;
		return out;
	}

	const Worker& operator()(Worker& work) // Перегрузил этот оператор как сокращение дроби
	{
		Worker temp{ *this };
		*this = work;
		work = temp;
		return *this;
	}
	const Worker& operator=(const Worker& w)
	{
		if (this != &w)
		{
			fio = w.fio;
			age = w.age;
			exp = w.exp;
			post = w.post;
			salary = w.salary;
		}
		return *this;
	}

	void filter(int type, string value)
	{
		switch (type)
		{
		case FIO:
			if(fio == value)
				cout << *this;
			break;
		case AGE:
			if (age == atoi(value.c_str()))
				cout << *this;
			break;
		case EXP:
			if (exp == atoi(value.c_str()))
				cout << *this;
			break;
		case POST:
			if (post == value)
				cout << *this;
			break;
		case SALARY:
			if (salary == atoi(value.c_str()))
				cout << *this;
			break;
		default:
			break;
		}
	}
	static Worker* sort(Worker* workers, int size, int type)
	{
		switch (type)
		{
		case EXP:
			for (int i = 0; i < size - 1; i++) 
			{
				for (int j = 0; j < size - i - 1; j++)
				{
					if (lessByExp(workers[j],workers[j + 1]))
					{
						workers[j](workers[j + 1]);
					}
				}
			}
			break;
		case SALARY:
			for (int i = 0; i < size - 1; i++) 
			{
				for (int j = 0; j < size - i - 1; j++)
				{
					if (lessBySalary(workers[j],workers[j + 1]))
					{
						workers[j](workers[j + 1]);
					}
				}
			}
			break;
		case AGE:
			for (int i = 0; i < size - 1; i++)
			{
				for (int j = 0; j < size - i - 1; j++)
				{
					if (lessByAge(workers[j], workers[j + 1]))
					{
						workers[j](workers[j + 1]);
					}
				}
			}
			break;
		default:
			break;
		}
		return workers;
	}
	friend bool lessByExp(const Worker& a, const Worker& b)
	{
		return a.exp < b.exp;
	}
	friend bool lessBySalary(const Worker& a, const Worker& b)
	{
		return a.salary < b.salary;
	}
	friend bool lessByAge(const Worker& a, const Worker& b)
	{
		return a.age < b.age;
	}
};

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	
	int size = 5;

	Worker w1{ "Петров П.П.", 45,20,"Директор",100000 };
	Worker w2{ "Иванов И.И.", 25,6,"Менеджер",70000 };
	Worker w3{ "Сидоров С.С.", 20,10,"Работник",50000 };
	Worker w4{ "Соколов С.С.", 24,3,"Работник",45000 };
	Worker w5{ "Васильев В.В.", 25,5,"Работник",55000 };
	Worker* workers = new Worker[size]{ w1,w2,w3,w4,w5 };

	cout << "ФИО\t\tВозраст\tСтаж\tДолжность\tСтавка" << endl;
	for (int i = 0; i < size; i++)
	{
		cout << workers[i];
	}

	cout << "\n\tФильтр по имени" << endl;
	cout << "ФИО\t\tВозраст\tСтаж\tДолжность\tСтавка" << endl;
	for (int i = 0; i < size; i++)
	{
		workers[i].filter(FIO, "Сидоров С.С.");
	}

	cout << "\n\tСортировка по стажу" << endl;
	cout << "ФИО\t\tВозраст\tСтаж\tДолжность\tСтавка" << endl;

	Worker::sort(workers, size, EXP);
	for (int i = 0; i < size; i++)
	{
		cout << workers[i];
	}

	cout << "\n\tСортировка по ставке" << endl;
	cout << "ФИО\t\tВозраст\tСтаж\tДолжность\tСтавка" << endl;

	Worker::sort(workers, size, SALARY);
	for (int i = 0; i < size; i++)
	{
		cout << workers[i];
	}

	cout << "\n\tСортировка по возрасту" << endl;
	cout << "ФИО\t\tВозраст\tСтаж\tДолжность\tСтавка" << endl;

	Worker::sort(workers, size, AGE);
	for (int i = 0; i < size; i++)
	{
		cout << workers[i];
	}
}