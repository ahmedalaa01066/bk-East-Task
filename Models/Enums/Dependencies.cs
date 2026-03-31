namespace EasyTask.Models.Enums
{
    public enum Dependencies
    {
        StartToStart=1,  // ss
        StartToFinish, // sf
        FinishToStart, // fs
        FinishToFinish, // ff
        None // no
    }
}
