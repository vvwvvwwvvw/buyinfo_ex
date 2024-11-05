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
            Console.Write("날짜를 입력하세요 (1~31");
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
        
        }
        //품목별로 구매계획과 입고량을 화면에 출력
        static void ItemBuySummary(buy[] s)
        {
        
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
