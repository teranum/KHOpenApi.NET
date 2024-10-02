using ConsoleTables;
using KHOpenApi.NET;
using System.Collections;
using System.Diagnostics;

namespace CSharp
{
    internal class SampleBase
    {
        // Api 객체선언
        public static KHOpenApi.NET.AxKHOpenAPI api = null!;
        protected SampleBase()
        {
            Debug.Assert(api != null);
        }

        public SampleBase(nint Handle)
        {
            api = new(Handle);
            api.OnReceiveMsg += (s, e) =>
            {
                Console.WriteLine($"OnMessageEvent: sScrNo = {e.sScrNo}, sRQName = {e.sRQName}, sTrCode = {e.sTrCode}, sMsg = {e.sMsg}");
            };
            api.OnReceiveRealData += (s, e) =>
            {
                Console.WriteLine($"OnRealtimeEvent: sRealKey = {e.sRealKey}, sRealType = {e.sRealType}, sRealData = {e.sRealData}");
            };
        }

        // Main: 로그인 및 구현부 호출
        protected static string _sCondList = string.Empty;
        public async Task Main()
        {
            // 로그인
            print("로그인 요청중...");
            var (nRet, sMsg) = await api.CommConnectAsync();
            if (nRet != 0)
            {
                print($"연결실패: {sMsg}");
                return;
            }

            // 조건검색식 목록 로딩
            (nRet, sMsg) = await api.GetConditionLoadAsync();
            if (nRet != 1)
            {
                print($"조건검색식 로딩실패: {sMsg}");
                return;
            }
            _sCondList = sMsg;
            // 추가로 조건검색식 요청시 현재가 포함되게 설정해준다.
            api.KOA_Functions("SetConditionSearchFlag", "AddPrice");

            print($"연결성공");
            var isSimulation = string.Equals(api.GetLoginInfo("GetServerGubun"), "1");
            print($"접속서버: {(isSimulation ? "모의투자" : "실투자")}");
        }

        // 구현부: 파생 클래스에서 구현
        public virtual Task ActionImplement() => Task.CompletedTask;


        // Helper Methods: print, GetInputAsync

        public static void print<T>(IEnumerable<T>? array)
        {
            if (array == null) return;
            if (array is string text)
            {
                Console.WriteLine(text);
                return;
            }

            var type = typeof(T);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            if (type is null || type.IsValueType || type == typeof(string))
            {
                if (type == typeof(KeyValuePair<string, string>))
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    ConsoleTable.From(array).Write(Format.MarkDown);
                }
                else
                {
                    Console.WriteLine($"array, Data Count = {array.Count()}");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    int n = 0;
                    var IdArray = array.Select(x => new KeyValuePair<int, T>(++n, x));
                    ConsoleTable.From(IdArray).Configure(o => o.NumberAlignment = Alignment.Right).Write(Format.MarkDown);
                }
            }
            else
            {
                Console.WriteLine($"{type.Name}[], Field Count = {type.GetProperties().Length}, Data Count = {array.Count()}");
                Console.ForegroundColor = ConsoleColor.Gray;
                ConsoleTable.From(array).Configure(o => o.NumberAlignment = Alignment.Right).Write(Format.MarkDown);
            }
        }

        public static void print(object? data)
        {
            if (data == null) return;
            var type = data.GetType();
            if (type.IsValueType || type == typeof(string))
            {
                Console.WriteLine(data);
                return;
            }
            List<KeyValuePair<string, object>> keyValuePairs = [];
            if (data is IEnumerable ienum)
            {
                int n = 0;
                foreach (var item in ienum)
                {
                    keyValuePairs.Add(new($"{++n}", item));
                }
                ConsoleTable.From(keyValuePairs).Write(Format.MarkDown);
                return;
            }

            foreach (var prop in type.GetProperties())
            {
                keyValuePairs.Add(new(prop.Name, prop.GetValue(data) ?? string.Empty));
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"{type.Name}, Field Count = {keyValuePairs.Count}");
            Console.ForegroundColor = ConsoleColor.Gray;
            ConsoleTable.From(keyValuePairs).Write(Format.MarkDown);
        }

        public static void print(string RecName, string[] ColNames, string[][] data)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"{RecName}, Field Count = {ColNames.Length}, Row Count = {data.Length}");
            Console.ForegroundColor = ConsoleColor.Gray;

            var table = new ConsoleTable();

            int nColumCount = ColNames.Length;
            if (nColumCount > 0)
            {
                table.AddColumn(ColNames);
            }
            else
            {
                var columNames = Enumerable.Range(1, data[0].Length).Select(x => x.ToString());
                table.AddColumn(columNames);
            }
            foreach (var row in data)
            {
                if (row.Length > 0)
                    table.AddRow(row);
            }

            table.Write(Format.MarkDown);
        }

        public static async Task<string> GetInputAsync(string msg) => await Task.Run(() =>
        {
            Console.Write(msg);
            return Console.ReadLine() ?? string.Empty;
        });

        public static async Task<ConsoleKey> GetReadKeyAsync(string msg = "") => await Task.Run(() =>
        {
            if (msg.Length > 0) Console.Write(msg);
            return Console.ReadKey().Key;
        });

        public static void print(ResponseData responseTrData)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"tr_cd: {responseTrData.tr_cd}");
            Console.WriteLine("입력데이터");
            Console.ForegroundColor = ConsoleColor.Gray;
            print(responseTrData.InValues);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("출력데이터");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"nErrCode: {responseTrData.nErrCode}");
            Console.WriteLine($"rsp_msg: {responseTrData.rsp_msg}");
            Console.WriteLine($"cont_key: {responseTrData.cont_key}");
            Console.WriteLine();

            if (responseTrData.InSingleFields.Length > 0)
            {
                print("싱글데이터", responseTrData.InSingleFields, [responseTrData.OutputSingleDatas]);
            }

            if (responseTrData.InMultiFields.Length > 0)
            {
                print("멀티데이터", responseTrData.InMultiFields, [.. responseTrData.OutputMultiDatas]);
            }
        }
    }
}
