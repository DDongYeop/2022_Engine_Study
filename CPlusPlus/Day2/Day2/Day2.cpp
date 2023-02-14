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
	::a++; //�̷��� ���������� ����Ѵٴ� �� "::"

#pragma region TEST1
	// int x = 1;
	// int y = 3;
	// cout << x << y << endl;
	// TEST1(&x, &y); // & �ּҸ� ��°� 
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
	cout << "�� ���� ���� ������ �Է��Ͻðڽ��ϱ�?" << endl;
	int index;
	cin >> index;
	cout << index << " �� ���� ������ �Է��ϼ���." << endl;
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
		cout << i + 1 << "��° ����� ������ " << score[i] << "�� �Դϴ�." << endl;
}

void Show(Car&c)
{
	cout << "������ȣ�� " << c.num << ", ������ ���� " << c.gas << "�Դϴ�" << endl;
}
