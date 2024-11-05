using System.Collections;

namespace buyinfo_ex
{
    struct buy
    {
        public string company; // 구매처
        public string item; // 구매품목
        public int qty; // 구매량
        public bool complete; // 입고 여부
    }
    class Program
    {
        // 일별 구매계획 등록
        static void BuySlip(buy[] s) 
        {
            Console.Write("날짜를 입력하세요 (1~31)");
            int day = int.Parse(Console.ReadLine());
            if (0 < day && day < 32)
            {
                Console.Write("구매처를 입력하세요");
                s[day - 1].company = Console.ReadLine();
                Console.Write("구매 품목을 입력하세요");
                s[day - 1].item = Console.ReadLine();
                Console.Write("구매량을 입력하세요");
                s[day - 1].qty = int.Parse(Console.ReadLine());
                s[day - 1].complete = false;
            }
            else
            {
                Console.WriteLine("잘못된 날짜 입력입니다");
            }
        }
        // 특정 구매건에 대해 입고되었음을 저장
        static void CompleteProcess(buy[] s) 
        {
            Console.Write("구매계획이 입력된 날짜는");
            for (int i = 0; i < 31; i++)
            {
                if (s[i].qty > 0 && s[i].complete == false)
                {
                    Console.Write("{0},", i + 1); // 아직 입고되지않은 계획건의 날짜를 출력
                }
                Console.WriteLine("입니다");
                Console.WriteLine("입고된 구매건에 대한 입고 여부를 입력하세요 (0~31)");
                int day = int.Parse(Console.ReadLine());
                if (0 < day && day < 32)
                {
                    s[day - 1].complete = true; // 입고건 여부를 true로 설정
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다");
                }
            }
                
        }
        //품목별로 구매계획과 입고량을 화면에 출력
        static void ItemBuySummary(buy[] s)
        {
            Hashtable itemPlan = new Hashtable(); // 품목별 구매 계획량을 저장한다
            for (int i = 0; i < 31; i++)
            {
                string key = s[i].item;
                if (key == null)
                {
                    continue;
                }
                else if (itemPlan.ContainsKey(key))
                { // 품목이 있으면 기존수량에 추가
                    int newQty = (int)itemPlan[key] + s[i].qty;
                    itemPlan[key] = newQty;
                }
                else
                {
                    itemPlan.Add(s[i].item, s[i].qty); // 품목이 없으면 구매 계획 수량에 등록
                }
            }
            Hashtable  itemComplete = new Hashtable();
            for (int i = 0; i < 31; i++)
            {
                string key = s[i].item;
                if (key == null)
                {
                    continue;
                }
                else if (s[i].complete == false)
                {
                    continue;
                }
                else if (itemComplete.ContainsKey(key)) // 품목의 입고량이 있으면 수량 추가
                {
                    int newQty = (int)itemComplete[key] + s[i].qty;
                    itemComplete[key] = newQty;
                }
                else
                {
                    itemComplete.Add(s[i].item, s[i].qty); // 품목이 없으면 품목 입고량 등록
                }
            }
            foreach (DictionaryEntry cs in itemPlan) // 품목별 구매 계획량을 꺼내서 반복
            {
                string item = (string)cs.Key; // cs의 key 값을 품목 이름으로 가져옴
                int planQty = (int)cs.Value; // cs의 value를 품목 구매 계획량으로 가져옴
                int completeQty = 0; // 입고량은 0으로 초기화
                if (itemComplete.ContainsKey(item))
                {
                    completeQty = (int)itemComplete[item]; // 입고량이 있으면 변경
                }
                Console.WriteLine("{0} 품목 구매 계획량 = {1}, 입고량 = {2}", item,planQty, completeQty); // 품목별 입고량을 출력한다
            }
        }
        static void Main(string[] args)
        {
            buy[] buydata = new buy[31];
            while (true)
            {
                Console.WriteLine("#1=구매계획입력, 2=입고입력, 3=품목별구매분석, 0=프로그램종료#)");
                Console.Write("원하는 작업을 입력하세요");
                int command = int.Parse(Console.ReadLine());
                if (command == 0)
                {
                    break;
                }
                switch (command)
                {
                    case 1:
                        {
                            BuySlip(buydata); // 1번 선택시 구매 계획
                            Console.WriteLine();
                            break;
                        }
                    case 2:
                        {
                            CompleteProcess(buydata); // 2번 선택시 입고업무 진행
                            Console.WriteLine();
                            break;
                        }
                    case 3:
                        {
                            ItemBuySummary(buydata); // 3번 선택시 걔획과 입고량 정리
                            Console.WriteLine();
                            break;
                        }
                }
            }
                
        }
    }
}
