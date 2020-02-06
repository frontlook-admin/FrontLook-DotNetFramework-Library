using Roslyn.Scripting.CSharp;

namespace frontlook_dotnetframework_library.FL_universal
{
    /// <summary>
    /// Defines the <see cref="FL_MathExpression" />
    /// </summary>
    public static class FL_MathExpression
    {
        /// <summary>
        /// The FL_Result
        /// </summary>
        /// <param name="expression">The expression<see cref="string"/></param>
        /// <returns>The <see cref="double"/></returns>
        public static double FL_Result(string expression)
        {
            var engine = new ScriptEngine();
            var session = engine.CreateSession();
            return session.Execute<double>(expression);
        }
    }
}
