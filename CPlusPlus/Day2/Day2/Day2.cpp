#include <iostream>
#include <string>

using namespace std;

struct Car
{
	int num;
	double gas;
};

void TEST1(int*x, int*y); 
void TEST2(int&x, int&y);
void TEST3(int index, int score[]);
void Show(Car&c);

int a = 0;
int main()
{
	int a = 0;
	::a++; //이러면 전역변수를 사용한다는 뜻 "::"

#pragma region TEST1
	// int x = 1;
	// int y = 3;
	// cout << x << y << endl;
	// TEST1(&x, &y); // & 주소를 담는거 
	// cout << x << y << endl;
#pragma endregion

#pragma region TEST2
	// int x = 1, y = 3;
	// cout << x << " " << y << endl;
	// TEST2(x, y); 
	// cout << x << " " << y << endl;
#pragma endregion

#pragma region TEST3
	/*
	cout << "몇 명의 시험 점수를 입력하시겠습니까?" << endl;
	int index;
	cin >> index;
	cout << index << " 명 분의 점수를 입력하세요." << endl;
	int* score = new int[index];
	for (int i = 0; i < index; i++)
		cin >> score[i];
	TEST3(index, score);
	delete[] score;
	*/
#pragma endregion

#pragma region Show
	/*
	Car car;
	car.num = 5592;
	car.gas = 90.09;
	Show(car);
	*/
#pragma endregion

}

void TEST1(int*x, int*y)
{
	int temp;
	temp = *x; // temp = 1
	*x = *y; // x = 3
	*y = temp; 
}

void TEST2(int&x, int&y)
{
	int temp = x; // temp = 1
	x = y; // x = 3
	y = temp;
}

void TEST3(int index, int score[])
{
	for (int i = 0; i <= index - 1; i++)
		cout << i + 1 << "번째 사람의 점수는 " << score[i] << "점 입니다." << endl;
}

void Show(Car&c)
{
	cout << "차량번호는 " << c.num << ", 연료의 양은 " << c.gas << "입니다" << endl;
}
