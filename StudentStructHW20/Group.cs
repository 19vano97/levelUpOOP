namespace _20240522_HW20;

public struct Group
{
    private string _groupName;
    private DateTime _startDate;
    private int _currentYear;
    private Supervisor _groupSupervisor;
    private Student[] _groupOfStudents;
    private int _avrMarkOfGroup;
    private Subject[] _groupSubjects;
    private Specialization _groupSpecialization;

    public Group(string groupName, DateTime startDate, 
                    int currentYear, Supervisor groupSupervisor, 
                    Student[] groupOfStudents, int avgMarkOfGroup,
                    Subject[] groupSubjects, Specialization groupSpecialization)
    {
        _groupName = groupName;
        _startDate = startDate;
        _currentYear = currentYear;
        _groupSupervisor = groupSupervisor;
        _groupOfStudents = groupOfStudents;
        _avrMarkOfGroup = avgMarkOfGroup;
        _groupSubjects = groupSubjects;
        _groupSpecialization = groupSpecialization;
    }

    public string GetGroupName()
    {
        return _groupName;
    }

    public DateTime GetEnrollmentDateOfTheGroup()
    {
        return _startDate;
    }

    public int GetCurrentYear()
    {
        return _currentYear;
    }

    public Supervisor GetGroupsSupervisor()
    {
        return _groupSupervisor;
    }

    public Student[] GetStudentsOfTheGroup()
    {
        return _groupOfStudents;
    }

    public int GetAvgMarkOfTheGroup()
    {
        return _avrMarkOfGroup;
    }

    public Subject[] GetSubjectsForTheGroup()
    {
        return _groupSubjects;
    }

    public Specialization GetSpecializationOfTheGroup()
    {
        return _groupSpecialization;
    }

    public void SetGroupName(string groupName = null)
    {
        if (groupName == null)
        {
            System.Console.Write("Enter groupName: ");
            groupName = Console.ReadLine();
        }

        _groupName = groupName;
    }

    public void SetEnrollmentDateOfTheGroup(DateTime enrollmentDate)
    {
        _startDate = enrollmentDate;
    }

    public void SetCurrentYear(int currentYear)
    {
        if (currentYear < 0)
        {
            return; //add error
        }

        _currentYear = currentYear;
    }

    public void SetGroupsSupervisor(Supervisor supervisorOfTheGroup)
    {
        _groupSupervisor = supervisorOfTheGroup;
    }

    public void SetStudentsOfTheGroup(Student[] students)
    {
        _groupOfStudents = students;
    }

    public void SetAvgMarkOfTheGroup(int avrMarkOfGroup)
    {
        if (avrMarkOfGroup < 0)
        {
            return; //add error
        }

        _avrMarkOfGroup = avrMarkOfGroup;
    }

    public void SetSubjectsForTheGroup(Subject[] subjects)
    {
        _groupSubjects = subjects;
    }

    public void SetSpecializationOfTheGroup(Specialization groupSpecialization)
    {
        _groupSpecialization = groupSpecialization;
    }
}
