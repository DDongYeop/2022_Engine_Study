#include <iostream>
#include <time.h> // time(NULL) �Լ��� ����� �� ���� 1970�� 1�� �������� ���� ���ݱ��� ����� �ð��� ��ȯ 
				  // srand() ���� ������ ���ذ�(�õ尪)�� ����
#include <Windows.h> // Sleep() ���α׷��� ��� �����. ���� �ȿ� ������� ��ٸ��� ���� �� ���� 1000 == 1��
					 // system("pause") ����Ϸ��� �ƹ�Ű�� �������� ���
					 // system("cls") �ܼ�â �� �����
#include <string>

using namespace std;

enum TEST3enum{	scissors = 1, rock, paper, stop};

void RandomExample1();
void TEST1(int num, string names[]);
void TEST2(int * x1, int * x2, int * a);
void TEST2(int& x1, int& x2, int& a);
void TEST3();
void TEST4();

int main()
{
#pragma region RandomExample1
	/*
	RandomExample1();
	*/
#pragma endregion

#pragma region TEST1
	/*
	cout << "�� �ο��� ���� : ";
	int num = 0;
	cin >> num;
	cout << "������ �̸��� �� �ο����� �°� �����ϼ���" << endl;
	string* names = new string[num];
	for (int i = 0; i < num; i++)
		cin >> names[i];
	TEST1(num, names);
	delete[] names;
	*/
#pragma endregion

#pragma region TEST2
	/*
	cout << "2������ ���� ������ �߰��� ������ �Է� �Ͻÿ� : ";
	int x, y, z;
	cin >> x >> y >> z;
	TEST2(&x, &y, &z);
	TEST2(x, y, z);
	*/
#pragma endregion

#pragma region TEST3
	/*
	TEST3();
	*/
#pragma endregion

#pragma region TEST4

	TEST4();

#pragma endregion

}

void RandomExample1()
{
	srand((unsigned int)time(NULL));
	int randomnum = rand() % 18 + 1; // 1 ~ 17
	cout << randomnum << endl;
}

void TEST1(int num, string names[])
{
	while (true)
	{
		cout << "1������ �̱� / ����� 0" << endl;
		int key;
		cin >> key;
		if (key == 1)
		{
			cout << "�̱⸦ �����մϴ�" << endl;

			Sleep(1000);

			srand((unsigned int)time(NULL));
			int index = rand() % num;
			cout << names[index] << endl << endl;
		}
		else if (key == 0)
			break;
	}
}

void TEST2(int* x1, int* x2, int* a)
{
	cout << "2���� ���������� ������ �߰��� �� ������ : " << *x1 + *a << " " << *x2 + *a << endl;
}

void TEST2(int& x1, int& x2, int& a)
{
	cout << "2���� ���������� ������ �߰��� �� ������ : " << x1 + a << " " << x2 + a << endl;
}

void TEST3()
{
	int win = 0, same = 0, lose = 0;

	while (1)
	{
		system("cls");
		cout << "��ȣ�� �����ϼ���. " << endl << "1.����, 2.����, 3.��, 4.����" << endl << "Player : ";
		int index;
		cin >> index;
		if (index == stop)
			break;

		srand((unsigned int)time(NULL));
		int randomnum = rand() % 3 + 1;
		switch (randomnum)
		{
		case scissors:
			cout << "Bot :" << "����" << endl;
			break;
		case rock:
			cout << "Bot :" << "����" << endl;
			break;
		case paper:
			cout << "Bot :" << "��" << endl;
			break;
		}

		int result = index - randomnum;
		switch (result)
		{
		case 0:
			same++;
			cout << " ���º� " << endl;
			break;
		case -2:
		case 1:
			win++;
			cout << " �¸� " << endl;
			break;
		default:
			lose++;
			cout << " �й� " << endl;
			break;
		}

		cout << "�� : " << win << ", �� : " << lose << ", ���º� : " << same << endl;
		system("pause");
	}
}

void TEST4()
{
	srand(unsigned int(time(NULL)));
	int num[25] = {};
	for (int i = 0; i < 25; i++)
		num[i] = i + 1;

	//shuffle
	int temp, idx1, idx2;
	for (int i = 0; i < 100; i++) {
		idx1 = rand() % 25;
		idx2 = rand() % 25;
		temp = num[idx1];
		num[idx1] = num[idx2];
		num[idx2] = temp;
	}
	int bingo = 0, target = 0;

	cout << "��ǥ ������� ? : ";
	cin >> target;

	while (true)
	{
		system("cls");
		//���ڸ� 5*5�� ���
		for (int i = 0; i < 5; i++) {
			for (int j = 0; j < 5; j++)
			{
				if (num[i * 5 + j] == -1)
					cout << "*" << "\t";
				else
					cout << num[i * 5 + j] << "\t";
			}
			cout << "\n";
		}

		cout << " target line : " << target << " bingo line : " << bingo << endl << endl;

		if (bingo >= target)
		{
			cout << "##   ##   ####    ##   ## " << endl;
			cout << "##   ##    ##     ###  ##" << endl;
			cout << "##   ##    ##     #### ##" << endl;
			cout << "## # ##    ##     ## ####" << endl;
			cout << "#######    ##     ##  ###" << endl;
			cout << "### ###    ##     ##   ##" << endl;
			cout << "##   ##   ####    ##   ##" << endl;
			system("pause");
		}

		cout << "���ڸ� �Է��ϼ���(����:0) : ";
		int input;
		cin >> input;
		if (input == 0) break;
		else if (input < 1 || input>25) continue;
		for (int i = 0; i < 25; i++) {
			if (input == num[i])
			{
				num[i] = -1;
				break;
			}
		}

		// ���� ī����
		bingo = 0;

		for (int i = 0; i < 5; i++)
		{
			int h_star = 0, v_star = 0;
			for (int j = 0; j < 5; j++)
			{
				if (num[5 * i + j] == -1)
					h_star++; // ����
				if (num[5 * j + i] == -1)
					v_star++; // ����
			}
			if (h_star == 5) bingo++;
			if (v_star == 5) bingo++;
		}

		int d_star = 0;
		for (int i = 0; i < 25; i += 6)
		{
			if (num[i] == -1) d_star++;
		}
		if (d_star == 5) bingo++;

		d_star = 0;
		for (int i = 4; i <= 20; i += 4)
		{
			if (num[i] == -1) d_star++;
		}
		if (d_star == 5) bingo++;
	}
}
