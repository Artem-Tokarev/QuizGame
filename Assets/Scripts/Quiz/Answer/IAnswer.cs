public interface IAnswer<in T, out A>
{
    A GenerateAnswer();
    void CorrectAnswer(T dataForAnswer);
    void IncorrectAnswer(T dataForAnswer);
}