#include <iostream> // # >> 전처리자 해석하기 전에 이거부터 처리 시키겠다. iostreamdm을 포함시키겠다. 
                    // iostreamdm >> 입출력 하는 친구 
#include <string> // string 사용 가능하게 해주느 해더
using namespace std; // 소스파일에서 std에서 가져오겠다?? 대충 어떤 공간인지 구분하는 역할 
					 // 이게 없다면 cout이거를 std::cout이런식으로 써야한다 

// 무조건 메인 위에서 선언이 되어있어야한다. 아니면 오류가 난다.
void InOut(); // 입출력
void TEST1(); // 문제1
float TEST2(float index); // 문제2
void String(); // string 연습
string TEST3(string str); // 문제3
void TEST4(string str); // 문제4
string TEST5(int index); // 문제5
char TEST6(int index); // 문제6
void TEST7(int index); // 문제7
void TEST8(int index); // 문제8

int main() // 프로그래밍 시작점. 반환형식이 int. 리턴 없어도 있는 취급해준다 
{
#pragma region InOut
	// InOut();
#pragma endregion

#pragma region TEST1
	// TEST1();
#pragma endregion

#pragma region TEST2
	// cout << TEST2(12) << endl;
#pragma endregion

#pragma region String
	// String();
#pragma endregion

#pragma region TEST3
	// cout << "문자열을 입력하시오 : ";
	// string str;
	// cin >> str;
	// cout << TEST3(str);
#pragma endregion

#pragma region TEST4
	// cout << "Input string : ";
	// string str;
	// getline(cin, str);
	// TEST4(str);
#pragma endregion

#pragma region TEST5
	// cout << "Input Int : ";
	// int index;
	// cin >> index;
	// cout << TEST5(index);
#pragma endregion

#pragma region TEST6
	// cout << "점수를 입력하세요. : ";
	// int index;
	// cin >> index;
	// TEST6(index);
	// cout << "등급은 " << TEST6(index) << "입니다.";
#pragma endregion

#pragma region TEST7
	cout << "소수를 구할 최대 숫자를 입력하세요. : ";
	int index;
	cin >> index;
	TEST7(index);
#pragma endregion

#pragma region TEST8
	cout << "높이를 입력하세요. : ";
	int index;
	cin >> index;
	TEST8(index);
#pragma endregion
}

void InOut()
{
	char arr[100]; // char형 자료형을 100의 크기로 
	cout << "What's your name?" << endl; // cout 출력하는거 사용할때 <<을 무조건 넣어주어야한다.
										 // " "에서 cout로 보내준다고 생각하면 된다. 
										 // endl 줄바꿈.
	cin >> arr /* >> arr2 */; // 입력 받아서 arr에 넣겠다.
				// 받은 것을 arr에 보내준다라고 생각 하면 된다. 
				// 공백을 만나면 그냥 끝낸다. 즉 "Don gYeop"이라면 "Don"만 기록. 띄어쓰기를 기준으로 한다.
				// 띄어쓰기도 넣고 싶다면 "cin.getline" 한줄을 받는다. Enter을 기준으로 받는다. 
				// 예시 >> cin.getline(arr, 100);
	cout << "hi" << " " << arr; // cout 끼워쓰기 연산자로 구분.

	// cout cin 이런거는 함수는 아니다
}

void TEST1()
{
	char name[100];
	int old;
	char anythigSay[100];
	cout << "What's your name?" << endl << "How old are you?" << endl;
	cin >> name >> old;
	cout << "hi " << name << "You are " << old << "years old ~ !" << endl;
	cout << "Do you  anything to say?" << endl;
	cin.ignore(); // 엔터버퍼를 먹는다 
				  // cin에 엔터가 들어가 있는걸 다 정리해주는 역할 
	cin.getline(anythigSay, 100);
	cout << anythigSay;
}

float TEST2(float index)
{
	const float pi = 3.14;
	return (index * index * pi);
}

void String()
{
	string str = "hello";
	cout << str[4] << str.at(4); // str의 4번째 단어 o가 출력
	cout << str[5]; // Enter가 들어가있다. 즉 출력된다.
	// cout << str[6]; // Out of range가 뜬다. 빠르게 접근하지만 오류를 미리 체크할 수 없음 
	// cout << str.at(6); // 예외가 처리되지않음이 뜬다. 느리게 접근하지만 오류를 미리 체크할 수 있음. 즉 정확도를 중요시할때 
}

string TEST3(string str)
{
	for (int i = 0; i < str.length(); i++)
	{
		if (str[i] == 'o')
			str[i] = 'x';
		else if (str[i] == 'O')
			str[i] = 'X';
	}
	return str;
}

void TEST4(string str)
{
	for (int i = 0; i < str.length(); i++)
	{
		char front = str.front();
		for (int j = 0; j < str.length(); j++)
		{
			str[j] = str[j + 1];
		}
		str.back() = front;
		cout << str << endl;
	}
}

string TEST5(int index)
{
	return index % 2 == 0 ? "짝수입니다." : "홀수입니다.";
}

char TEST6(int index)
{
	switch (index / 10)
	{
	case 10:
	case 9:
		return 'A';
	case 8:
		return 'B';
	case 7:
		return 'C';
	case 6:
		return 'D';
	default:
		return 'E';
		break;
	}
}

void TEST7(int index)
{
	int i;
	int j;
	int count = 0;
	for (i = 2; i <= index; i++)
	{
		for (j = 2; j < i; j++)
		{
			if (i % j == 0)
				break;
		}
		if (j == i)
		{
			cout << i << " ";
			count++;
		}
	}
	cout << endl << "2부터 " << index << "사이의 소수의 개수는 " << count << "개 입니다. ";
}

void TEST8(int index)
{
	for (int i; i <= index; i++)
	{
		for (int j = 1; j < i; j++)
			cout << " ";
		//for (int j =1; j <)
	}
}
