namespace _20240729_Lesson_Iterator;

public interface IContainer
{
    object this[int index] { get; set; }
    int Size { get; }
}
