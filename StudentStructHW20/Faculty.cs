using _20240522_HW20;

namespace StudentStructHW20;

public class Faculty
{
    private Group[] _facultyGroups;

    public Faculty (Group[] groups)
    {
        _facultyGroups = groups;
    }
    
    public Group[] UsefacultyGroups
    {
        get { return _facultyGroups; }
        set { _facultyGroups = value; }
    }

    public void AddGroup(Group groupToAdd)
    {
        Array.Resize(ref _facultyGroups, _facultyGroups.Length + 1);

        _facultyGroups[_facultyGroups.Length - 1] = groupToAdd;

        UpdateGroupInTheList(groupToAdd);
    }

    public void UpdateGroupInTheList(Group groupToUpdate)
    {
        int value = 0;

        for (int i = 0; i < _facultyGroups.Length; i++)
        {
            if (_facultyGroups[i].UseId == groupToUpdate.UseId)
            {
                value = i;
                break;
            }
        }

        _facultyGroups[value] = groupToUpdate;
    }

    public bool DeleteGroupFromList(Group groupToDelete)
    {
        int index = -1;

        for (int i = 0; i < _facultyGroups.Length; i++)
        {
            if (_facultyGroups[i].UseId == groupToDelete.UseId)
            {
                index = i;
                break;
            }
        }

        if (index == -1)
        {
            return false;
        }

        for (int i = index; i < _facultyGroups.Length - 1; i++)
        {
            _facultyGroups[i] = _facultyGroups[i + 1];
        }

        Array.Resize(ref _facultyGroups, _facultyGroups.Length - 1);

        return true;
    }
    
    public void MoveGroupToNextYear(Group studentGroup)
    {
        Group groupCopy = studentGroup.CreateCopyOfGroup();

        groupCopy.ChangeSubjectsForStudents();
        groupCopy.CurrentYear++;

        AddGroup(groupCopy);
    }

    public Group this[int index]
    {
        get 
        {
            if (index > _facultyGroups.Length || index < 0)
            {
                return null;
            }

            return _facultyGroups[index];
        }
        set 
        {
            if (index > _facultyGroups.Length || index < 0)
            {
                return;
            }
            
            _facultyGroups[index] = value;
        }
    }

}
