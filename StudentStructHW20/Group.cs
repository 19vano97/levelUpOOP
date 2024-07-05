﻿using StudentStructHW20;

namespace _20240522_HW20;

public class Group
{
    #region private variables

        private Guid _id = Guid.NewGuid();
        private string _groupName;
        private DateTime _startDate;
        private int _currentYear;
        private Supervisor _groupSupervisor;
        private Subject[] _groupSubjects;
        private Student[] _groupOfStudents;
        private double _avrMarkOfGroup;
        private Specialization _groupSpecialization;

    #endregion

    #region shitCode

        // public Group(string groupName, DateTime startDate, 
        //                 int currentYear, Supervisor groupSupervisor, 
        //                 string[] idRecords,
        //                 Specialization groupSpecialization)
        // {
        //     _id.GetGuid();
        //     _groupName = groupName;
        //     _startDate = startDate;
        //     _currentYear = currentYear;
        //     _groupSupervisor = groupSupervisor;
        //     _groupSubjects = BL.GetListOfSubjects();
        //     _groupOfStudents = AddNewStudentsToGroupFromScretch(idRecords);
        //     _avrMarkOfGroup = GetAvgMarkOfGroup();
        //     _groupSpecialization = groupSpecialization;
        // }

    #endregion

    public Group(string groupName, DateTime startDate, 
                    int currentYear, Supervisor groupSupervisor, 
                    Subject[] groupSubjects, Student[] studentsList,
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

    #region Get/Set

    // public Guid GetId()
    // {
    //     return _id;
    // }

    // public string GetGroupName()
    // {
    //     return _groupName;
    // }

    // public DateTime GetEnrollmentDateOfTheGroup()
    // {
    //     return _startDate;
    // }

    // public int GetCurrentYear()
    // {
    //     return _currentYear;
    // }

    // public Supervisor GetGroupsSupervisor()
    // {
    //     return _groupSupervisor;
    // }

    // public Student[] GetStudentsOfTheGroup()
    // {
    //     return _groupOfStudents;
    // }

    // public int GetAvgMarkOfTheGroup()
    // {
    //     return _avrMarkOfGroup;
    // }

    // public Subject[] GetSubjectsForTheGroup()
    // {
    //     return _groupSubjects;
    // }

    // public Specialization GetSpecializationOfTheGroup()
    // {
    //     return _groupSpecialization;
    // }

    // public void SetGroupName(string groupName = null)
    // {
    //     if (groupName == null)
    //     {
    //         System.Console.Write("Enter groupName: ");
    //         groupName = Console.ReadLine();
    //     }

    //     _groupName = groupName;
    // }

    // public void SetEnrollmentDateOfTheGroup(DateTime enrollmentDate)
    // {
    //     _startDate = enrollmentDate;
    // }

    // public void SetCurrentYear(int currentYear)
    // {
    //     if (currentYear < 0)
    //     {
    //         return; //add error
    //     }

    //     _currentYear = currentYear;
    // }

    // public void SetGroupsSupervisor(Supervisor supervisorOfTheGroup)
    // {
    //     _groupSupervisor = supervisorOfTheGroup;
    // }

    // public void SetStudentsOfTheGroup(Student[] students)
    // {
    //     _groupOfStudents = students;
    // }

    // public void SetAvgMarkOfTheGroup(int avrMarkOfGroup)
    // {
    //     if (avrMarkOfGroup < 0)
    //     {
    //         return; //add error
    //     }

    //     _avrMarkOfGroup = avrMarkOfGroup;
    // }

    // public void SetSubjectsForTheGroup(Subject[] subjects)
    // {
    //     _groupSubjects = subjects;
    // }

    // public void SetSpecializationOfTheGroup(Specialization groupSpecialization)
    // {
    //     _groupSpecialization = groupSpecialization;
    // }


    #endregion

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

    public Subject[] GroupSubjects
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

        _groupSubjects = new Subject[amountOfSubjects];

        for (int i = 0; i < _groupSubjects.Length; i++)
        {
            _groupSubjects[i].UseSubjectName = GetRandomSubjectList();
        }
    }

    private SubjectList GetRandomSubjectList()
    {
        int value = BL.GetRandomInt(1, Enum.GetValues(typeof(SubjectList)).Cast<int>().Max());

        for (int i = 0; i < _groupSubjects.Length; i++)
        {
            if (_groupSubjects[i].UseSubjectName == (SubjectList)value)
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
