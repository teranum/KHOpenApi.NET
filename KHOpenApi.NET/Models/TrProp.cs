using KHOpenApi.NET.Helpers;

namespace KHOpenApi.NET.Models;

/// <summary>TR관련 정보</summary>
public class TrProp
{
    /// <summary>생성자</summary>
    public TrProp(string FilePath)
    {
        this.FilePath = FilePath;
        FileTitle = Path.GetFileNameWithoutExtension(FilePath);
        TRCode = FileTitle.Split('_')[0];
    }

    /// <summary>파일 경로</summary>
    public string FilePath { get; }
    /// <summary>파일 제목</summary>
    public string FileTitle { get; }
    /// <summary>TR코드</summary>
    public string TRCode { get; }
    /// <summary>TR이름</summary>
    public string TRName { get; set; } = string.Empty;
    /// <summary>출력 블록 갯수</summary>
    public int OutputCnt;
    /// <summary>히더</summary>
    public int DataHeader;

    /// <summary>FID요청인 경우 필드 데이터</summary>
    public string RefFids { get; set; } = string.Empty;

    ///// <summary>입력 데이터</summary>
    //public IList<(string, string)> InputDatas { get; } = new List<(string, string)>();
    /// <summary>INPUT 리스트</summary>
    public IList<KeySizeDesc> INPUTs { get; } = [];

    /// <summary>OUTPUT 데이터 총 사이즈</summary>
    public int OutputTotalSize;
    /// <summary>OUTPUT 리스트</summary>
    public IList<KeySizeDesc> OUTPUTs { get; } = [];

    /// <summary>OutRec1 자릿수</summary>
    public int OutRec1RowCountDigit;
    /// <summary>OutRec1 총 사이즈</summary>
    public int OutRec1TotalSize;
    /// <summary>OutRec1 리스트</summary>
    public IList<KeySizeDesc> OutRec1s { get; } = [];


    /// <summary>OutRec2 자릿수</summary>
    public int OutRec2RowCountDigit;
    /// <summary>OutRec2 총 사이즈</summary>
    public int OutRec2TotalSize;
    /// <summary>OutRec2 리스트</summary>
    public IList<KeySizeDesc> OutRec2s { get; } = [];

    /// <summary>REQKindClass</summary>
    public REQKindClass? DefReqData;

    /// <summary>키, 사이즈, 설명</summary>
    public record KeySizeDesc(string Key, int Size, string Desc);
}

