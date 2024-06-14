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
                    Supervisor[] supervisorList = BL.GetRandomSupervisors();
                    Group[] groupCreateList = BL.InitArrayOfEmptyGroups(supervisorList);
                    string[] idRecords = new string[0];
                    PrintNextMainMenu(groupCreateList, idRecords, supervisorList);
                    break;                
                default:
                break;
            }
        } while (key != ConsoleKey.Escape);
    }
    public static void PrintNextMainMenu(Group[] groupList, string[] idRecords, Supervisor[] supervisorList)
    {
        Console.Clear();
        System.Console.WriteLine("O. Output a group");
        System.Console.WriteLine("V. Output all groups");
        System.Console.WriteLine("A. Add group");
        System.Console.WriteLine("E. Edit a group");
        System.Console.WriteLine("D. Delete a group");
        System.Console.WriteLine("C. Clear console");
        System.Console.WriteLine("Esc. Exit");
        System.Console.WriteLine();
        System.Console.WriteLine("Your choice: ");

        ConsoleKey key;

        do
        {
            Console.SetCursorPosition(13, 8);

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
                    BL.PrintAllGroups(groupList);
                    break;
                case ConsoleKey.A:
                    System.Console.WriteLine();
                    Group groupToAdd = BL.CreateGroup(supervisorList);
                    groupList = BL.AddGroup(ref groupList, groupToAdd);
                    System.Console.WriteLine(groupList.Length);
                    break;
                case ConsoleKey.E:
                    System.Console.WriteLine();
                    Group groupToEdit = UseGroupFromList(groupList);
                    EditGroupUI(groupList, groupToEdit, idRecords, supervisorList);
                    break;
                case ConsoleKey.D:
                    System.Console.WriteLine();
                    Group groupToDelete = UseGroupFromList(groupList);
                    if (BL.DeleteGroupFromListBL(groupList, groupToDelete))
                    {
                        System.Console.WriteLine("The {0} group has been succesfully removed", groupToDelete.GetGroupName());
                    }
                    else
                    {
                        System.Console.WriteLine("Something went wrong");
                    }
                    break;
                case ConsoleKey.S:

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

    public static void EditGroupUI(Group[] groupList, Group groupToEdit, string[] idRecords, Supervisor[] supervisorList)
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
                    groupToEdit.SetStudentsOfTheGroup(BL.CreateStudentsArray(groupToEdit, idRecords));
                    groupToEdit.SetAvgMarkOfTheGroup(BL.AvgMarkOfGroup(groupToEdit));
                    BL.UpdateGroups(groupList, groupToEdit, groupToEdit);
                    System.Console.WriteLine("Students have been succesfully added and avarage mark og the groups has been succesfully updated");
                    Thread.Sleep(DELAY);
                    Console.Clear();
                    EditGroupUI(groupList, groupToEdit, idRecords, supervisorList);
                    break;
                case ConsoleKey.R:
                    System.Console.WriteLine();
                    System.Console.WriteLine("TBD");
                    break;
                case ConsoleKey.T:
                    System.Console.WriteLine();
                    groupToEdit = BL.MoveGroupToNextYear(ref groupToEdit);
                    BL.UpdateGroups(groupList, groupToEdit, groupToEdit);
                    System.Console.WriteLine("The group has been succefully moved to {0} year", groupToEdit.GetCurrentYear());
                    Thread.Sleep(DELAY);
                    Console.Clear();
                    EditGroupUI(groupList, groupToEdit, idRecords, supervisorList);
                    break;
                case ConsoleKey.D:
                    Student studentToDelete = ChooseStudent(groupToEdit);
                    // BL.DeleteStudent(groupToEdit, studentToDelete);
                    BL.UpdateGroups(groupList, groupToEdit, groupToEdit);
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


    public static Group UseGroupFromList(Group[] groupList = null)
    {
        for (int i = 0; i < groupList.Length; i++)
        {
            System.Console.WriteLine("{0}. {1}", i, groupList[i].GetGroupName());
        }

        int value = EnterIntValue("number of a group");

        return groupList[value];
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
        System.Console.WriteLine("Group name: {0}", groupPrint.GetGroupName());
        System.Console.WriteLine("Start date of enrollment: {0}", groupPrint.GetEnrollmentDateOfTheGroup().ToString("yyyy-MM-dd"));
        System.Console.WriteLine("Current year: {0}", groupPrint.GetCurrentYear());
        System.Console.Write("Supervisor: "); 
        PrintSupervisor(groupPrint.GetGroupsSupervisor());

        System.Console.WriteLine("Students");

       if (groupPrint.GetStudentsOfTheGroup() != null)
       {
            for (int i = 0; i < groupPrint.GetStudentsOfTheGroup().Length; i++)
            {
                System.Console.WriteLine("{0}. {1} {2}, IdRecord: {3}, Avarage mark: {4}", i, 
                                            groupPrint.GetStudentsOfTheGroup()[i].GetLastNameOfAStudent(),
                                            groupPrint.GetStudentsOfTheGroup()[i].GetFirstNameOfAStudent(), 
                                            groupPrint.GetStudentsOfTheGroup()[i].GetIdRecordOfAStudent(),
                                            groupPrint.GetStudentsOfTheGroup()[i].GetAvarageMarkOfAStudent());
            }
       }
       else
       {
            System.Console.WriteLine("There are no students in ths group");
       }

        System.Console.WriteLine("Avarage mark of the group: {0}", groupPrint.GetAvgMarkOfTheGroup());

    }

    public static Student ChooseStudent(Group studentGroup)
    {
        for (int i = 0; i < studentGroup.GetStudentsOfTheGroup().Length; i++)
        {
            System.Console.WriteLine("{0}. {1} {2}, IdRecord: {3}", i, 
                                        studentGroup.GetStudentsOfTheGroup()[i].GetLastNameOfAStudent(),
                                        studentGroup.GetStudentsOfTheGroup()[i].GetFirstNameOfAStudent(), 
                                        studentGroup.GetStudentsOfTheGroup()[i].GetIdRecordOfAStudent());
        }

        int studentIndex = EnterIntValue("number of the student");

        return studentGroup.GetStudentsOfTheGroup()[studentIndex];
    }

    public static void PrintStudent(Student key)
    {
        System.Console.WriteLine("Name: {0} {1}", key.GetFirstNameOfAStudent(), key.GetLastNameOfAStudent());
        System.Console.WriteLine("Student identification code: {0}", key.GetIdRecordOfAStudent());
        System.Console.WriteLine("Avarage Mark: {0}", key.GetAvarageMarkOfAStudent());
        System.Console.WriteLine("Date of birth: {0}", key.GetDateOfBirthOfAStudent().ToString("yyyy-MM-dd"));
    }
}
