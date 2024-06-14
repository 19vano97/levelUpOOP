namespace _20240522_HW20;

public struct Student
{
    private string _firstName;
    private string _lastName;
    private string _idRecord;
    private int _avgMark;
    private DateTime _dateOfBirth;

    public static Student CreateOneStudent(Group studentGroup, string[] idRecords)
    {
        Student studentCreate = new Student()
        {
            _firstName = BL.GetRandomFirstname(),
            _lastName = BL.GetRandomLastname(),
            _idRecord = BL.GenerateRandomRecordId(idRecords),
            _avgMark = BL.AvgMarkOfOneStudentRandom(studentGroup.GetSubjectsForTheGroup()),
            _dateOfBirth = BL.GetDateRandom("date of birth")
        };

        return studentCreate;
    }

    public Student (string firstName, string lastName, 
                                            string idRecord, int avgMark, 
                                            DateTime dateOfBirth)
    {
       _firstName = firstName;
       _lastName = lastName;
       _idRecord = idRecord;
       _avgMark = avgMark;
       _dateOfBirth = dateOfBirth;
    }

    public string GetFirstNameOfAStudent()
    {
        return _firstName;
    }

    public string GetLastNameOfAStudent()
    {
        return _lastName;
    }

    public string GetIdRecordOfAStudent()
    {
        return _idRecord;
    }

    public int GetAvarageMarkOfAStudent()
    {
        return _avgMark;
    }

    public DateTime GetDateOfBirthOfAStudent()
    {
        return _dateOfBirth;
    }

    public void SetFirstNameOfAStudent(string firstName)
    {
        _firstName = firstName;
    }

    public void SetLasttNameOfAStudent(string lastName)
    {
        _lastName = lastName;
    }

    public void SetIdRecordOfAStudent(string idRecord)
    {
        _idRecord = idRecord;
    }

    public void SetAvarageMarkOfAStudent(int avgMark)
    {
        _avgMark = avgMark;
    }

    public void SetDateOfBirthOfAStudent(DateTime dateOfBirth)
    {
        _dateOfBirth = dateOfBirth;
    }
}
