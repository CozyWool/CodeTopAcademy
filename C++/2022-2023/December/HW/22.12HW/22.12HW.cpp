#include <iostream>
#include <Windows.h>

using namespace std;

enum searchType
{
	AUTHOR,
	PUBLISHER,
	YEAR
};

class Book
{
private:
	string author;
	string name;
	string publisher;
	int year;
	int pagesCount;
public:
	Book(string authorP, string nameP, string publisherP, int yearP, int pagesCountP) :
		author{ authorP },
		name{ nameP },
		publisher{ publisherP },
		year{ yearP },
		pagesCount{ pagesCountP }
	{

	}
	Book() : Book("","","",0,0) {}
	
	string getAuthor() { return author; }
	string getName() { return name; }
	string getPublisher() { return publisher; }
	int getYear() { return year; }
	int getPagesCount() { return pagesCount; }
	
	void setAuthor(string newParam) { author = newParam; }
	void setName(string newParam) { name = newParam; }
	void setPublisher(string newParam) { publisher = newParam; }
	void setYear(int newParam) { year = newParam; }
	void setPagesCount(int newParam) { pagesCount = newParam; }

	void print()
	{
		cout << "\nАвтор:" << author
			<< "\nИмя:" << name
			<< "\nИздатель:" << publisher
			<< "\nГод:" << year
			<< "\nКол-во страниц:" << pagesCount
			<< endl;
	}
};

class Library
{
private:
	Book* books;
	int bookCount;
public:
	Library(int bookCountP, Book* booksP) : bookCount{ bookCountP }, books{ new Book[bookCountP] }
	{
		for (int i = 0; i < bookCount; i++)
		{
			books[i] = booksP[i];
		}
	}
	Library() : Library(0, nullptr) {}
	~Library()
	{
		delete[] books;
	}

	void search(string searchP,int type)
	{
		int yearP = 0; // для поиска по году
		cout << "Найденные книги по вашему запросу:\n----------";
		switch (type)
		{
		case 0:
			for (int i = 0; i < bookCount; i++)
			{
				if (books[i].getAuthor() == searchP)
				{
					books[i].print();
					cout << "----------" << endl;
				}
			}
			break;
		case 1:
			for (int i = 0; i < bookCount; i++)
			{
				if (books[i].getPublisher() == searchP)
				{
					books[i].print();
					cout << "----------" << endl;
				}
			}
			break;
		case 2:
			yearP = atoi(searchP.c_str());
			for (int i = 0; i < bookCount; i++)
			{
				if (books[i].getYear() >= yearP)
				{
					books[i].print();
					cout << "----------" << endl;
				}
			}
			break;
		default:
			break;
		}
	}
};

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	int size = 3;
	Book book1{ "Пушкин","Капитанская дочка","Дрофа",2016,200 };
	Book book2{ "Лермонтов","Герой нашего времени","Азбука",2010,300 };
	Book book3{ "Пушкин","Евгений Онегин","Дрофа",2013,150 };

	Book* books = new Book[size]{ book1,book2,book3 };
	Library lib{ size, books };
	cout << "\tПОИСК ПО АВТОРУ\n" << endl;
	lib.search("Пушкин",AUTHOR);
	cout << "\tПОИСК ПО ИЗДАТЕЛЮ\n" << endl;
	lib.search("Азбука",PUBLISHER);
	cout << "\tПОИСК ПО ГОДУ\n" << endl;
	lib.search("2012",YEAR);
}