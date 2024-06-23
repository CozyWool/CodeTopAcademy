#pragma once
#include <iostream>
#include <Windows.h>

using namespace std;

class Array
{
private:
	int size;
	int* arr;

	friend ostream& operator<<(ostream&, const Array&);
	friend istream& operator>>(istream&, Array&);
public:
	explicit Array(int);
	Array(const Array&);
	Array();
	~Array();
	int length() const;
	void randomize();

	const Array& operator=(const Array& array);
	bool operator==(const Array& array) const;
	bool operator!=(const Array& arr) const;

	int& operator[](int);
	int operator[](int) const;
	const Array& operator()(int);
};

