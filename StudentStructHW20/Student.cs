using StudentStructHW20;

namespace _20240522_HW20;

public struct Student
{
    private string _firstName;
    private string _lastName;
    private Guid _recordId = Guid.NewGuid();
    private int[,] _studentMarks;
    private double _avgMark;
    private DateTime _dateOfBirth;

    public Student (string firstName, string lastName, 
                    int[,] avgMark, DateTime dateOfBirth)
    {
       _firstName = firstName;
       _lastName = lastName;
       _studentMarks = avgMark;
       _dateOfBirth = dateOfBirth;
       _avgMark = GetAvgMarkOfTheStudent();
    }

    public string StudentFirstName
    {
        get { return _firstName; }
        set { _firstName = value; }
    }

    public string StudentLastName
    {
        get { return _lastName; }
        set { _lastName = value; }
    }

    public Guid StudentIdRecord
    {
        get { return _recordId; }
        set { _recordId = value; }
    }

    public int[,] StudentMarks
    {
        get { return _studentMarks; }
        set { _studentMarks = value; }
    }

    public DateTime StudentDateOfBirth
    {
        get { return _dateOfBirth; }
        set { _dateOfBirth = value; }
    }

    public double StudentAvgMark
    {
        get { return _avgMark; }
        set { _avgMark = value; }
    }

    public double GetAvgMarkOfTheStudent()
    {
        double sum = 0;

        for (int i = 0; i < _studentMarks.GetLength(0); i++)
        {
            sum += _studentMarks[i, 1];
        }

        sum /= _studentMarks.GetLength(0);

        return sum;
    }

    public bool IsStudentExists(string name)
    {
        if (_firstName == name || _lastName == name || _recordId.ToString() == name)
        {
            return true;
        }

        return false;
    }
}
