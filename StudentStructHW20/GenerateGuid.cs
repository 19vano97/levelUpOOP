namespace StudentStructHW20;

public class GenerateGuid
{
    private Guid _guid;
    private Guid[] _guids;

    public GenerateGuid()
    {
        _guid = Guid.NewGuid();

        if (!CheckGuidForDuplicates())
        {
            new GenerateGuid();
        }

        AddGuidToArray();
    }

    private bool CheckGuidForDuplicates()
    {
        if (_guids == null)
        {
            return true;
        }

        for (int i = 0; i < _guids.Length; i++)
        {
            if (_guids[i] == _guid)
            {
                return true;
            }
        }

        return false;
    }

    private void AddGuidToArray()
    {
        Array.Resize(ref _guids, _guids.Length + 1);

        _guids[_guids.Length - 1] = _guid;
    }
}
