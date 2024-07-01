using KHOpenApi.NET.Helpers;

namespace KHOpenApi.NET.Models;

/// <summary>TR관련 정보</summary>
public class TrProp
{
    /// <summary>생성자</summary>
    public TrProp(string filePath, string trCode, string trName)
    {
        FilePath = filePath;
        TRCode = trCode;
        TRName = trName;
    }

    /// <summary>파일 경로</summary>
    public string FilePath { get; }
    /// <summary>파일 텍스트</summary>
    public string FileText { get; set; } = string.Empty;
    /// <summary>TR코드</summary>
    public string TRCode { get; }
    /// <summary>TR이름</summary>
    public string TRName { get; set; }
    /// <summary>Caution</summary>
    public string Caution { get; set; } = string.Empty;
    /// <summary>출력 블록 갯수</summary>
    public int OutputCnt;
    /// <summary>히더</summary>
    public int DataHeader;

    /// <summary>FID요청인 경우 필드 데이터</summary>
    public string RefFids { get; set; } = string.Empty;

    ///// <summary>입력 데이터</summary>
    //public IList<(string, string)> InputDatas { get; } = new List<(string, string)>();
    /// <summary>INPUT 리스트</summary>
    public IList<KeySizeDesc> Inputs { get; } = [];

    /// <summary>OutputSingle 총 사이즈</summary>
    public int OutputSingleTotalSize;
    /// <summary>OUTPUT 리스트</summary>
    public IList<KeySizeDesc> OutputSingle { get; } = [];

    /// <summary>OutputMuti 자릿수</summary>
    public int OutputMutiCountDigit;
    /// <summary>OutputMuti 총 사이즈</summary>
    public int OutputMutiTotalSize;
    /// <summary>OutRec1 리스트</summary>
    public IList<KeySizeDesc> OutputMuti { get; } = [];

    /// <summary>키, 사이즈, 설명</summary>
    public record KeySizeDesc(string Key, int Size, string Desc);
}

