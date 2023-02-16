#include <iostream>
#include <time.h> // time(NULL) 함수를 사용할 수 있음 1970년 1월 자정부터 이후 지금까지 경과된 시간을 변환 
				  // srand() 난수 생성의 기준값(시드값)을 설정
#include <Windows.h> // Sleep() 프로그램이 잠시 멈춘다. 가로 안에 어느정도 기다릴지 정할 수 있음 1000 == 1초
					 // system("pause") 계속하려면 아무키나 누르세요 띄움
					 // system("cls") 콘솔창 다 지우기
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
	cout << "총 인원수 설정 : ";
	int num = 0;
	cin >> num;
	cout << "참여자 이름을 총 인원수에 맞게 기입하세요" << endl;
	string* names = new string[num];
	for (int i = 0; i < num; i++)
		cin >> names[i];
	TEST1(num, names);
	delete[] names;
	*/
#pragma endregion

#pragma region TEST2
	/*
	cout << "2과목의 시험 점수와 추가할 점수를 입력 하시오 : ";
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
		cout << "1누르면 뽑기 / 종료는 0" << endl;
		int key;
		cin >> key;
		if (key == 1)
		{
			cout << "뽑기를 시작합니다" << endl;

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
	cout << "2과목 시험점수에 점수가 추가된 뒤 점수는 : " << *x1 + *a << " " << *x2 + *a << endl;
}

void TEST2(int& x1, int& x2, int& a)
{
	cout << "2과목 시험점수에 점수가 추가된 뒤 점수는 : " << x1 + a << " " << x2 + a << endl;
}

void TEST3()
{
	int win = 0, same = 0, lose = 0;

	while (1)
	{
		system("cls");
		cout << "번호를 선택하세요. " << endl << "1.가위, 2.바위, 3.보, 4.종료" << endl << "Player : ";
		int index;
		cin >> index;
		if (index == stop)
			break;

		srand((unsigned int)time(NULL));
		int randomnum = rand() % 3 + 1;
		switch (randomnum)
		{
		case scissors:
			cout << "Bot :" << "가위" << endl;
			break;
		case rock:
			cout << "Bot :" << "바위" << endl;
			break;
		case paper:
			cout << "Bot :" << "보" << endl;
			break;
		}

		int result = index - randomnum;
		switch (result)
		{
		case 0:
			same++;
			cout << " 무승부 " << endl;
			break;
		case -2:
		case 1:
			win++;
			cout << " 승리 " << endl;
			break;
		default:
			lose++;
			cout << " 패배 " << endl;
			break;
		}

		cout << "승 : " << win << ", 패 : " << lose << ", 무승부 : " << same << endl;
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

	cout << "목표 빙고수는 ? : ";
	cin >> target;

	while (true)
	{
		system("cls");
		//숫자를 5*5로 출력
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

		cout << "숫자를 입력하세요(종료:0) : ";
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

		// 빙고 카운팅
		bingo = 0;

		for (int i = 0; i < 5; i++)
		{
			int h_star = 0, v_star = 0;
			for (int j = 0; j < 5; j++)
			{
				if (num[5 * i + j] == -1)
					h_star++; // 가로
				if (num[5 * j + i] == -1)
					v_star++; // 세로
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
