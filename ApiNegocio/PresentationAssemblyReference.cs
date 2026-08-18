using System.Reflection;

namespace ApiNegocio
{
    public static class PresentationAssemblyReference
    {
        internal static readonly Assembly Assembly = typeof(PresentationAssemblyReference).Assembly;
    }
}
