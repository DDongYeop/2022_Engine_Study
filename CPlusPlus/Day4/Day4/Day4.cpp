#include <iostream>
#include <string>
#include <time.h>
#include <vector> // 벡터 가져옴. 배열인데 사이즈 신경 안 써도 되는거 
 
using namespace std;

class Circle
{
private:
	double radius;

public:
	void SetRadius(float radius)
	{
		this->radius = radius;
	}
	double GetRadius()
	{
		return radius;
	}
	double GetArea()
	{
		return (radius * radius) * 3.14;
	}
	double GetPerimeter()
	{
		return radius + radius;
	}
};

class Player
{
	string name;

public:
	void SetName(string name)
	{
		this->name = name;
	}
	void ShowNaem()
	{
		cout << name << ">>";
	}
};

template<class T>
void Swap(T &x, T &y);

int main()
{
#pragma region Circle 
	/*
	cout << "Circle 1 : " << endl;
	Circle circle1;
	circle1.SetRadius(10.0);
	cout << "Radius : " << circle1.GetRadius() << endl; 
	cout << "Area : " << circle1.GetArea() << endl; //넓이
	cout << "Perimeter : " << circle1.GetPerimeter() << endl << endl; //지름
	*/
#pragma endregion

#pragma region 끝말잇기
	/*
	int n = 0;
	string name, before, curr;

	string firstTxt[] = { "씨피피", "피곤해", "모모모모", "겜마고" };
	srand((unsigned int)time(NULL));
	before = firstTxt[rand() % firstTxt->size() - 1];

	cout << "끝말 잇기 게임을 시작합니다. " << endl;
	cout << "게임에 참가는 인원은 몇명입니까?" << endl;
	cin >> n;

	Player* player = new Player[n];

	for (int i = 0; i < n; i++)
	{
		cout << "참가자의 이름을 입력하세요. : ";
		cin >> name;
		player[i].SetName(name);
	}
	cout << "시작하는 단어는 " << before << "입니다." << endl;
	 
	int flag = 1;
	while (flag)
	{
		for (int i = 0; i < n; i++)
		{
			player[i].ShowNaem();
			cin >> curr;
			cout << before << "  " << curr << endl;
			//if (before.back() == curr.front()) // 영어 가능
			if (before[before.size()-2] == curr[0] && before[before.size() -1] == curr[1]) //한국어 가능 
			{
				cout << "다음차례" << endl;
				before = curr;
			}
			else 
			{
				cout << "게임 종료" << endl;
				flag = 0;
				break;
			}
		}
	}
	*/
#pragma endregion

#pragma region Swap
	/*
	string s[2];
	float f[2];
	int i[2];

	cout << "띄어쓰기를 기준으로 문자열 두개를 입력하시오 : ";
	cin >> s[0] >> s[1];
	cout << "띄어쓰기를 기준으로 실수 두개를 입력하시오 : ";
	cin >> f[0] >> f[1];
	cout << "띄어쓰기를 기준으로 정수 두개를 입력하시오 : ";
	cin >> f[0] >> f[1];

	cout << "Swap()함수 결과입니다. " << endl;
	Swap(s[0], s[1]);
	Swap(i[0], i[1]);
	Swap(f[0], f[1]);
	cout << s[0] << " " << s[1] << endl;
	cout << f[0] << " " << f[1] << endl;
	cout << f[0] << " " << f[1] << endl;
	*/
#pragma endregion

#pragma region Vector
	/*
	vector<int> v1(10);
	v1[0] = 10;
	v1[1] = 20;
	v1.push_back(12);
	cout << v1[10];
	*/
#pragma endregion

#pragma region MyRegion

	vector<int> scores;
	int score, sum = 0;
	
	while (true)
	{
		cout << "성적을 입력하시오 (종료는 -1) : ";
		cin >> score;
	
		if (score == -1)
			break;
		scores.push_back(score);
	}

	// vector<int>::iterator it = scores.begin();
	// while (it != scores.end())
	// 	sum += *it;

	for (auto& n : scores)
		sum += n;

	double avg = (double)sum / scores.size();
	cout << " ************************ 성적 평균 = " << avg << endl;
	
#pragma endregion


	string a;
	a.push_back(a.size());

}

template<class T>
void Swap(T &x, T &y)
{
	T temp = x;
	x = y;
	y = temp;
}
