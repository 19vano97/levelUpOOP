using System.Runtime.InteropServices.Marshalling;
using StudentStructHW20;

namespace _20240522_HW20;

public class UI
{
    const int DELAY = 500;

    public static void PrintMainMenu()
    {
        Console.Clear();
        System.Console.WriteLine("I. Create empty groups");
        System.Console.WriteLine("Esc. Exit");
        System.Console.WriteLine();
        System.Console.WriteLine("Your choice: ");

        ConsoleKey key;

        do
        {
            Console.SetCursorPosition(13, 3);
            key = Console.ReadKey().Key;

            switch (key)
            {
                case ConsoleKey.I:
                    System.Console.WriteLine();

                    string[] idRecords = new string[0];
                    Supervisor[] supervisorList = BL.GetRandomSupervisors();
                    Faculty groupList = BL.InitArrayOfEmptyGroups(supervisorList, idRecords);

                    PrintNextMainMenu(groupList, idRecords, supervisorList);
                    break;                
                default:
                break;
            }
        } while (key != ConsoleKey.Escape);
    }
    public static void PrintNextMainMenu(Faculty groupList, string[] idRecords, 
                                            Supervisor[] supervisorList)
    {
        Console.Clear();
        System.Console.WriteLine("O. Output a group");
        System.Console.WriteLine("V. Output all groups");
        System.Console.WriteLine("A. Add group");
        System.Console.WriteLine("E. Edit a group");
        System.Console.WriteLine("D. Delete a group");
        System.Console.WriteLine("I. Find a student");
        System.Console.WriteLine("C. Clear console");
        System.Console.WriteLine("Esc. Exit");
        System.Console.WriteLine();
        System.Console.WriteLine("Your choice: ");

        ConsoleKey key;

        do
        {
            Console.SetCursorPosition(13, 9);

            key = Console.ReadKey().Key;

            switch (key)
            {
                case ConsoleKey.O:
                    System.Console.WriteLine();
                    Group groupToView = UseGroupFromList(groupList);
                    PrintGroup(groupToView);
                    break;
                case ConsoleKey.V:
                    System.Console.WriteLine();
                    PrintAllGroups(groupList);
                    break;
                case ConsoleKey.A:
                    System.Console.WriteLine();
                    Group groupToAdd = BL.CreateGroup(supervisorList, idRecords);
                    groupList.AddGroup(groupToAdd);
                    break;
                case ConsoleKey.E:
                    System.Console.WriteLine();
                    Group groupToEdit = UseGroupFromList(groupList);
                    EditGroupUI(groupList, groupToEdit, idRecords, supervisorList);
                    break;
                case ConsoleKey.D:
                    System.Console.WriteLine();
                    Group groupToDelete = UseGroupFromList(groupList);
                    if (groupList.DeleteGroupFromList(groupToDelete))
                    {
                        System.Console.WriteLine("The {0} group has been succesfully removed", 
                                                    groupToDelete.GroupName);
                    }
                    else
                    {
                        System.Console.WriteLine("Something went wrong");
                    }
                    break;
                case ConsoleKey.I:
                    PrintStudentsBySearch(groupList ,EnterString("firstName / lastName / idRecord"));
                    break;
                case ConsoleKey.C:
                    Console.Clear();
                    PrintNextMainMenu(groupList, idRecords, supervisorList);
                    break;
                default:
                break;
            }
        } while (key != ConsoleKey.Escape);
    }

    public static void EditGroupUI(Faculty groupList, Group groupToEdit, string[] idRecords, 
                                    Supervisor[] supervisorList)
    {
        Console.Clear();
        System.Console.WriteLine("A. Add students to a group");
        System.Console.WriteLine("T. Transafer group to the next year");
        System.Console.WriteLine("D. Delete student to the group");
        System.Console.WriteLine("Backspace. Back");
        System.Console.WriteLine("Esc. Exit");
        System.Console.WriteLine();
        System.Console.WriteLine("Your choice: ");

        ConsoleKey key;

        do
        {
            Console.SetCursorPosition(13, 6);

            key = Console.ReadKey().Key;

            switch (key)
            {
                case ConsoleKey.A:
                    System.Console.WriteLine();

                    groupToEdit.AddNewStudentsToGroupFromScratch(idRecords);
                    groupList.UpdateGroupInTheList(groupToEdit);

                    System.Console.WriteLine("Students have been succesfully added and avarage mark og the groups has been succesfully updated");
                    Thread.Sleep(DELAY);
                    Console.Clear();

                    EditGroupUI(groupList, groupToEdit, idRecords, supervisorList);
                    break;
                case ConsoleKey.T:
                    System.Console.WriteLine();

                    groupList.MoveGroupToNextYear(groupToEdit);
                    groupList.UpdateGroupInTheList(groupToEdit);

                    System.Console.WriteLine("The group has been succefully moved to {0} year", 
                                                groupToEdit.CurrentYear);
                    Thread.Sleep(DELAY);
                    Console.Clear();

                    EditGroupUI(groupList, groupToEdit, idRecords, supervisorList);
                    break;
                case ConsoleKey.D:

                    Student studentToDelete = ChooseStudent(groupToEdit);
                    groupToEdit.DeleteStudent(studentToDelete);
                    groupList.UpdateGroupInTheList(groupToEdit);

                    System.Console.WriteLine("The student has successfully deleted");

                    break;

                case ConsoleKey.Backspace:
                    PrintNextMainMenu(groupList, idRecords, supervisorList);
                    break;
                default:
                break;
            }
        } while (key != ConsoleKey.Escape);
    }


    public static Group UseGroupFromList(Faculty groupList)
    {
        for (int i = 0; i < groupList.UsefacultyGroups.Length; i++)
        {
            System.Console.WriteLine("{0}. {1}", i, groupList.UsefacultyGroups[i].GroupName);
        }

        int value = EnterIntValue("number of a group");

        return groupList.UsefacultyGroups[value];
    }

    public static int EnterIntValue(string message)
    {
        System.Console.Write("Enter {0}:", message);
        string str = Console.ReadLine();
        
        if (int.TryParse(str, out int value))
        {
            return value;
        }
        else
        {
            System.Console.WriteLine("Wrong! Please, enter a correct value!");
            value = EnterIntValue(message);
            return value;
        }
    }

    public static string EnterString(string message)
    {
        System.Console.Write("Enter {0}:" , message);
        string str = Console.ReadLine();

        return str;
    }

    public static Specialization GetSpecialization()
    {
        for (int i = 1; i < Enum.GetValues(typeof(Specialization)).Cast<int>().Max(); i++)
        {
            if (i == Enum.GetValues(typeof(Specialization)).Cast<int>().Max() - 1)
            {
                System.Console.WriteLine("{0} - {1}", (Specialization)i, i);
                break;
            }

            System.Console.Write("{0} - {1}, ", (Specialization)i, i);
        }

        int specializationValue = EnterIntValue("specialization");

        return (Specialization)specializationValue;
    }

    public static Supervisor InitSupervisor()
    {
        Supervisor supervisorInit = new Supervisor(){
            firstName = EnterString("first name"),
            lastName = EnterString("last name"),
            supervisorsSpecialization = GetSpecialization(),
        };

        return supervisorInit;
    }

    public static Supervisor GetSupervisor(Supervisor[] supervisorsList)
    {
        for (int i = 0; i < supervisorsList.Length; i++)
        {
            System.Console.WriteLine("{0}. {1} {2} - {3}", i, supervisorsList[i].lastName, 
                                        supervisorsList[i].firstName, supervisorsList[i].supervisorsSpecialization);
        }

        int value = EnterIntValue("number of a supervisor");

        if (value > supervisorsList.Length)
        {
            return GetSupervisor(supervisorsList);
        }

        return supervisorsList[value];
    }

    public static void PrintSupervisor(Supervisor supervisorName)
    {
        System.Console.WriteLine("{0} {1} - {2}", supervisorName.lastName, 
                                        supervisorName.firstName, supervisorName.supervisorsSpecialization);
    }

    public static void PrintGroup(Group groupPrint)
    {
        System.Console.WriteLine();
        System.Console.WriteLine("Group ID: {0}", groupPrint.UseId);
        System.Console.WriteLine("Group name: {0}", groupPrint.GroupName);
        System.Console.WriteLine("Start date of enrollment: {0}", groupPrint.EnrollmentDateOfTheGroup.ToString("yyyy-MM-dd"));
        System.Console.WriteLine("Current year: {0}", groupPrint.CurrentYear);
        System.Console.Write("Supervisor: "); 
        PrintSupervisor(groupPrint.GroupSupervisor);

        System.Console.WriteLine("Students");

       if (groupPrint.GroupStudents != null)
       {
            for (int i = 0; i < groupPrint.GroupStudents.Length; i++)
            {
                System.Console.WriteLine("{0}. {1} {2}, IdRecord: {3}", i, 
                                            groupPrint.GroupStudents[i].StudentLastName,
                                            groupPrint.GroupStudents[i].StudentFirstName, 
                                            groupPrint.GroupStudents[i].StudentIdRecord);
                
                for (int y = 0; y < groupPrint.GroupStudents[i].StudentMarks.GetLength(0); y++)
                {
                    Console.CursorLeft = 10;
                    System.Console.WriteLine("{0, 10}: {1}", (SubjectList)groupPrint.GroupStudents[i].StudentMarks[y, 0],
                                                                        groupPrint.GroupStudents[i].StudentMarks[y, 1]);
                }

                Console.CursorLeft = 10;
                System.Console.WriteLine("Avarage mark: {0}", groupPrint.GroupStudents[i].StudentAvgMark);
            }

            

       }
       else
       {
            System.Console.WriteLine("There are no students in ths group");
       }

        System.Console.WriteLine("Avarage mark of the group: {0}", groupPrint.AvrMarkOfGroup);

    }

    public static Student ChooseStudent(Group studentGroup)
    {
        for (int i = 0; i < studentGroup.GroupStudents.Length; i++)
        {
            System.Console.WriteLine("{0}. {1} {2}, IdRecord: {3}", i, 
                                        studentGroup.GroupStudents[i].StudentLastName,
                                        studentGroup.GroupStudents[i].StudentFirstName, 
                                        studentGroup.GroupStudents[i].StudentIdRecord);
        }

        int studentIndex = EnterIntValue("number of the student");

        return studentGroup.GroupStudents[studentIndex];
    }

    public static void PrintStudent(Student key)
    {
        System.Console.WriteLine("Name: {0} {1}", key.StudentLastName, key.StudentFirstName);
        System.Console.WriteLine("Student identification code: {0}", key.StudentIdRecord);
        System.Console.WriteLine("Avarage Mark: {0}", key.StudentAvgMark);
        System.Console.WriteLine("Date of birth: {0}", key.StudentDateOfBirth.ToString("yyyy-MM-dd"));
    }

    public static void PrintAllGroups(Faculty groupList)
    {
        for (int i = 0; i < groupList.UsefacultyGroups.Length; i++)
        {
            System.Console.WriteLine();
            UI.PrintGroup(groupList.UsefacultyGroups[i]);
            System.Console.WriteLine();
        }
    }

    public static void PrintStudentsBySearch(Faculty facultyGroups, string name)
    {
        for (int i = 0; i < facultyGroups.UsefacultyGroups.Length; i++)
        {
            int studentSize = facultyGroups[i].FindStudentsBySearchInGroup(name).Length;

            Student[] foundStudents = facultyGroups[i].FindStudentsBySearchInGroup(name);
            
            for (int y = 0; y < studentSize; y++)
            {
                System.Console.WriteLine("Group: {0}", facultyGroups[i].GroupName);
                PrintStudent(foundStudents[y]);
                System.Console.WriteLine();
            }
        }
    }
}
