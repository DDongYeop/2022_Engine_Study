#include <iostream>
#include <string>
#include <time.h>
#include <vector> // ���� ������. �迭�ε� ������ �Ű� �� �ᵵ �Ǵ°� 
 
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
	cout << "Area : " << circle1.GetArea() << endl; //����
	cout << "Perimeter : " << circle1.GetPerimeter() << endl << endl; //����
	*/
#pragma endregion

#pragma region �����ձ�
	/*
	int n = 0;
	string name, before, curr;

	string firstTxt[] = { "������", "�ǰ���", "�����", "�׸���" };
	srand((unsigned int)time(NULL));
	before = firstTxt[rand() % firstTxt->size() - 1];

	cout << "���� �ձ� ������ �����մϴ�. " << endl;
	cout << "���ӿ� ������ �ο��� ����Դϱ�?" << endl;
	cin >> n;

	Player* player = new Player[n];

	for (int i = 0; i < n; i++)
	{
		cout << "�������� �̸��� �Է��ϼ���. : ";
		cin >> name;
		player[i].SetName(name);
	}
	cout << "�����ϴ� �ܾ�� " << before << "�Դϴ�." << endl;
	 
	int flag = 1;
	while (flag)
	{
		for (int i = 0; i < n; i++)
		{
			player[i].ShowNaem();
			cin >> curr;
			cout << before << "  " << curr << endl;
			//if (before.back() == curr.front()) // ���� ����
			if (before[before.size()-2] == curr[0] && before[before.size() -1] == curr[1]) //�ѱ��� ���� 
			{
				cout << "��������" << endl;
				before = curr;
			}
			else 
			{
				cout << "���� ����" << endl;
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

	cout << "���⸦ �������� ���ڿ� �ΰ��� �Է��Ͻÿ� : ";
	cin >> s[0] >> s[1];
	cout << "���⸦ �������� �Ǽ� �ΰ��� �Է��Ͻÿ� : ";
	cin >> f[0] >> f[1];
	cout << "���⸦ �������� ���� �ΰ��� �Է��Ͻÿ� : ";
	cin >> f[0] >> f[1];

	cout << "Swap()�Լ� ����Դϴ�. " << endl;
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
		cout << "������ �Է��Ͻÿ� (����� -1) : ";
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
	cout << " ************************ ���� ��� = " << avg << endl;
	
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
