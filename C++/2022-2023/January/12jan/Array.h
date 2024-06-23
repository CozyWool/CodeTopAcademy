#pragma once
#include <iostream>
#include <Windows.h>

using namespace std;

class Array
{
private:
	int size;
	char* arr;

	friend ostream& operator<<(ostream&, const Array&);
	friend istream& operator>>(istream&, Array&);
public:
	explicit Array(int size);
	Array(const Array&);
	Array();
	~Array();
	int length() const;
	void printFigure();


	const Array& operator=(const Array& array);
	bool operator==(const Array& array) const;
	bool operator!=(const Array& arr) const;

	char& operator[](int);
	char operator[](int) const;
};

