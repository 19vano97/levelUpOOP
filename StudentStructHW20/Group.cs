using StudentStructHW20;

namespace _20240522_HW20;

public class Group
{
    #region private variables

        private Guid _id = Guid.NewGuid();
        private string _groupName;
        private DateTime _startDate;
        private int _currentYear;
        private Supervisor _groupSupervisor;
        private SubjectList[] _groupSubjects;
        private Student[] _groupOfStudents;
        private double _avrMarkOfGroup;
        private Specialization _groupSpecialization;

    #endregion

    public Group(string groupName, DateTime startDate, 
                    int currentYear, Supervisor groupSupervisor, 
                    SubjectList[] groupSubjects, Student[] studentsList,
                    double avrMarkOfGroup, Specialization groupSpecialization)
    {
        _groupName = groupName;
        _startDate = startDate;
        _currentYear = currentYear;
        _groupSupervisor = groupSupervisor;
        _groupSubjects = groupSubjects;
        _groupOfStudents = studentsList;
        _avrMarkOfGroup = avrMarkOfGroup;
        _groupSpecialization = groupSpecialization;
    }

    public Group(string groupName, DateTime startDate, 
                    int currentYear, Supervisor groupSupervisor,
                    Specialization groupSpecialization, string[] idRecords)
    {
        _groupName = groupName;
        _startDate = startDate;
        _currentYear = currentYear;
        _groupSupervisor = groupSupervisor;
        GetListOfSubjects();
        AddNewStudentsToGroupFromScratch(idRecords);
        _groupSpecialization = groupSpecialization;
    }

    public Guid UseId    
    {
        get { return _id; }
        set { _id = value; }
    }

    public string GroupName
    {
        get { return _groupName; }
        set { _groupName = value; }
    }

    public DateTime EnrollmentDateOfTheGroup
    {
        get { return _startDate; }
        set { _startDate = value; }
    }
    
    public int CurrentYear     
    {
        get { return _currentYear; }
        set { _currentYear = value; }
    }

    public Supervisor GroupSupervisor 
    { 
        get { return _groupSupervisor; } 
        set { _groupSupervisor = value; }
    }
    
    public Student[] GroupStudents
    { 
        get { return _groupOfStudents; } 
        set { _groupOfStudents = value; }
    }

    public double AvrMarkOfGroup
    { 
        get { return _avrMarkOfGroup; } 
        set { _avrMarkOfGroup = value; }
    }

    public SubjectList[] GroupSubjects
    { 
        get { return _groupSubjects; } 
        set { _groupSubjects = value; }
    }

    public Specialization GroupSpecialization
    { 
        get { return _groupSpecialization; } 
        set { _groupSpecialization = value; }
    }

    public DateTime StartDate { get; }

    public void DeleteStudent(Student studentToDelete)
    {
        int studentIndex = 0;

        for (int i = 0; i < _groupOfStudents.Length; i++)
        {
            if (_groupOfStudents[i].StudentIdRecord == studentToDelete.StudentIdRecord)
            {
                studentIndex = i;
                break;
            }
        }

        for (int i = studentIndex; i < _groupOfStudents.Length - 1; i++)
        {
            _groupOfStudents[i] = _groupOfStudents[i + 1];
        }

        Array.Resize(ref _groupOfStudents, _groupOfStudents.Length - 1);
    }
    
    private Student GetStudent(string[] idRecords)
    {
        Student studentCreate = new Student(BL.GetRandomFirstname(), 
                                            BL.GetRandomLastname(), 
                                            BL.GenerateStudentsMarksWithSubjects(_groupSubjects), 
                                            BL.GetDateRandom()
        );

        return studentCreate;
    }

    public void AddNewStudentsToGroupFromScratch(string[] idRecords)
    {
        int amountOfStudents = UI.EnterIntValue("amount of students");

        _groupOfStudents = new Student[amountOfStudents];

        for (int i = 0; i < _groupOfStudents.Length; i++)
        {
            _groupOfStudents[i] = GetStudent(idRecords);
        }

        GetAvgMarkOfGroup();
    }

    public void ChangeSubjectsForStudents()
    {
        GetListOfSubjects();

        for (int i = 0; i < _groupOfStudents.Length; i++)
        {
            _groupOfStudents[i].StudentMarks = BL.GenerateStudentsMarksWithSubjects(_groupSubjects);
        }

        GetAvgMarkOfGroup();
    }

    private void GetAvgMarkOfGroup()
    {
        for (int i = 0; i < _groupOfStudents.Length; i++)
        {
            _avrMarkOfGroup += _groupOfStudents[i].StudentAvgMark;
        }

        _avrMarkOfGroup /= _groupOfStudents.Length;
    }

    public Group CreateCopyOfGroup()
    {
        Group groupCopy = new Group(
            _groupName,
            _startDate,
            _currentYear,
            _groupSupervisor,
            _groupSubjects,
            _groupOfStudents,
            _avrMarkOfGroup,
            _groupSpecialization
        );

        return groupCopy;
    }

    public void GetListOfSubjects(int amountOfSubjects = -1)
    {
        if (amountOfSubjects == -1)
        {
            amountOfSubjects = UI.EnterIntValue("amount of subjects");
        }

        _groupSubjects = new SubjectList[amountOfSubjects];

        for (int i = 0; i < _groupSubjects.Length; i++)
        {
            _groupSubjects[i] = GetRandomSubjectList();
        }
    }

    private SubjectList GetRandomSubjectList()
    {
        int value = BL.GetRandomInt(1, Enum.GetValues(typeof(SubjectList)).Cast<int>().Max());

        for (int i = 0; i < _groupSubjects.Length; i++)
        {
            if (_groupSubjects[i] == (SubjectList)value)
            {
                return GetRandomSubjectList();
            }
        }

        return (SubjectList)value;
    }

    public Student[] FindStudentsBySearchInGroup(string name)
    {
        Student[] studentsFound = new Student[0];

        for (int i = 0; i < _groupOfStudents.Length; i++)
        {
            if (_groupOfStudents[i].IsStudentExists(name))
            {
                Array.Resize(ref studentsFound, studentsFound.Length + 1);
                studentsFound[studentsFound.Length - 1] = _groupOfStudents[i];
            }
        }

        return studentsFound;
    }
    
}
