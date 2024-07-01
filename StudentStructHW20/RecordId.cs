using _20240522_HW20;

namespace StudentStructHW20;

public class RecordId
{
    private string _recordId;
    private string[] _recordIdDictionary;
    private const int RECORD_ID_LENGTH = 8;
    
    public string UniqueRecordId { get {return _recordId;} private set{} }

    public RecordId()
    {
        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        char[] idRecordChar = new char[RECORD_ID_LENGTH];

        for (int i = 0; i < idRecordChar.Length; i++)
        {
            idRecordChar[i] = chars[BL.GetRandomInt(0, chars.Length)];
        }

        _recordId = new string(idRecordChar);

        if (!CheckUniqueString())
        {
            new RecordId();
        }

        AddRecordToId();
    }

    private bool CheckUniqueString()
    {
        for (int i = 0; i < _recordIdDictionary.Length; i++)
        {
            if (string.Equals(_recordIdDictionary[i], _recordId))
            {
                return false;
            }
        }

        return true;
    }

    private void AddRecordToId()
    {
        Array.Resize(ref _recordIdDictionary, _recordId.Length + 1);

        _recordIdDictionary[_recordIdDictionary.Length - 1] = _recordId;
    }
}
