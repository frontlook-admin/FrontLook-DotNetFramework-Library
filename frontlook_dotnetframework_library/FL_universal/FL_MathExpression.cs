using Roslyn.Scripting.CSharp;

namespace frontlook_dotnetframework_library.FL_universal
{
    public static class FL_MathExpression
    {
        public static double FL_Result(string expression)
        {
            var engine = new ScriptEngine();
            var session = engine.CreateSession();
            return session.Execute<double>(expression);
        }
    }
}